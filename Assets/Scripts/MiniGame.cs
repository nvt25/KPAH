using System;

public class MiniGame : MyScreen
{
	public static MiniGame me;

	private mVector modelCell = new mVector();

	private int idCell;

	private bool isClose;

	private bool isOpen;

	private bool isPointer;

	private Command cmdPlay;

	private Command cmdSelect;

	private Command cmdSelcetAll;

	private Command cmd;

	private long timeBegin;

	public string[] arrInfo;

	public string[] result;

	public int xchar;

	public int ychar;

	public int yTo;

	public MiniGame()
	{
		cmd = new Command(string.Empty);
		ActionPerform action = delegate
		{
		};
		cmd.action = action;
		ActionPerform action2 = delegate
		{
			isOpen = true;
			timeBegin = mSystem.getCurrentTimeMillis() / 1000 + 2;
			doClose();
			center = null;
		};
		cmdPlay = new Command("Bắt đầu");
		cmdPlay.action = action2;
		ActionPerform action3 = delegate
		{
			ActionPerform noAction2 = delegate
			{
				Canvas.endDlg();
			};
			ActionPerform yesAction2 = delegate
			{
				Canvas.gameScr.gameService.playMiniGame(1, (sbyte)idCell);
				Canvas.endDlg();
			};
			Canvas.startYesNoDlgPutArr("Bạn có muốn mở không? ", arrInfo, yesAction2, noAction2);
		};
		cmdSelect = new Command("Chọn");
		cmdSelect.action = action3;
		center = cmdPlay;
		ActionPerform action4 = delegate
		{
			ActionPerform yesAction = delegate
			{
				Canvas.gameScr.gameService.playMiniGame(2, 100);
				Canvas.endDlg();
				idCell = 0;
				isClose = false;
				isPointer = false;
				isOpen = false;
				center = cmdPlay;
				right = cmd;
				xchar = 0;
				ychar = (yTo = 0);
				if (result != null)
				{
					for (sbyte b = 0; b < result.Length; b = (sbyte)(b + 1))
					{
						result[b] = string.Empty;
					}
				}
				modelCell.removeAllElements();
				if (arrInfo != null)
				{
					for (sbyte b2 = 0; b2 < arrInfo.Length; b2 = (sbyte)(b2 + 1))
					{
						arrInfo[b2] = string.Empty;
					}
				}
			};
			ActionPerform noAction = delegate
			{
				Canvas.endDlg();
			};
			Canvas.startYesNoDlgPutArr("Bạn có muốn mở hết không? ", arrInfo, yesAction, noAction);
		};
		cmdSelcetAll = new Command("Mở hết");
		cmdSelcetAll.action = action4;
	}

	public static MiniGame gI()
	{
		return (me != null) ? me : (me = new MiniGame());
	}

	public override void switchToMe()
	{
		base.switchToMe();
		init();
	}

	public void reSetGame()
	{
		idCell = 0;
		isClose = false;
		isPointer = false;
		isOpen = false;
		center = cmdPlay;
		right = cmd;
		xchar = 0;
		ychar = (yTo = 0);
		if (result != null)
		{
			for (sbyte b = 0; b < result.Length; b = (sbyte)(b + 1))
			{
				result[b] = string.Empty;
			}
		}
		modelCell.removeAllElements();
		if (arrInfo != null)
		{
			for (sbyte b2 = 0; b2 < arrInfo.Length; b2 = (sbyte)(b2 + 1))
			{
				arrInfo[b2] = string.Empty;
			}
		}
	}

	public void updatePoint()
	{
		if (!Canvas.isPointerClick || this.modelCell.size() <= 0)
		{
			return;
		}
		int num = 0;
		ModelCell modelCell;
		while (true)
		{
			if (num >= this.modelCell.size())
			{
				return;
			}
			modelCell = (ModelCell)this.modelCell.elementAt(num);
			if (modelCell != null && Canvas.px >= modelCell.x - 16 && Canvas.px <= modelCell.x + 16 && Canvas.py >= modelCell.y - 16 && Canvas.py <= modelCell.y + 16)
			{
				Canvas.isPointerClick = false;
				if (isPointer)
				{
					break;
				}
			}
			num++;
		}
		idCell = modelCell.id;
		center.perform();
	}

	public void loadModelCell(int sum)
	{
		this.modelCell.removeAllElements();
		for (int i = 0; i < sum; i++)
		{
			ModelCell modelCell = new ModelCell();
			modelCell.id = i;
			this.modelCell.addElement(modelCell);
		}
	}

	public void getInfoBox(sbyte id, string infoBox, string[] updateInfo)
	{
		arrInfo = updateInfo;
		string[] info = MFont.arialFontW.splitFontBStrInLine(infoBox, 100);
		int num = 0;
		ModelCell modelCell;
		while (true)
		{
			if (num < this.modelCell.size())
			{
				modelCell = (ModelCell)this.modelCell.elementAt(num);
				if (modelCell.id == id)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		modelCell.index = 1;
		starFlyString(info, modelCell.x, modelCell.y);
	}

	public void onMiniGame(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			arrInfo = new string[b2];
			for (sbyte b3 = 0; b3 < arrInfo.Length; b3 = (sbyte)(b3 + 1))
			{
				arrInfo[b3] = msg.reader().readUTF();
			}
			loadModelCell(b);
			init();
		}
		catch (Exception)
		{
		}
	}

	public void setSit()
	{
		int x = Canvas.w / 2;
		int y = Canvas.h / 2;
		int num = 0;
		int[][] array = new int[3][]
		{
			new int[5]
			{
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2 + Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2 + Canvas.w / 5
			},
			new int[7]
			{
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 + Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 + Canvas.w / 5
			},
			new int[9]
			{
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 + Canvas.w / 5,
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 + Canvas.w / 5,
				Canvas.w / 2 - Canvas.w / 5,
				Canvas.w / 2,
				Canvas.w / 2 + Canvas.w / 5
			}
		};
		int[][] array2 = new int[3][]
		{
			new int[5]
			{
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2,
				Canvas.h / 2 + Canvas.h / 5,
				Canvas.h / 2 + Canvas.h / 5
			},
			new int[7]
			{
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2,
				Canvas.h / 2 + Canvas.h / 5,
				Canvas.h / 2 + Canvas.h / 5,
				Canvas.h / 2 + Canvas.h / 5
			},
			new int[9]
			{
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2 - Canvas.h / 5,
				Canvas.h / 2,
				Canvas.h / 2,
				Canvas.h / 2,
				Canvas.h / 2 + Canvas.h / 5,
				Canvas.h / 2 + Canvas.h / 5,
				Canvas.h / 2 + Canvas.h / 5
			}
		};
		if (this.modelCell.size() == 7)
		{
			num = 1;
		}
		if (this.modelCell.size() == 9)
		{
			num = 2;
		}
		for (int i = 0; i < this.modelCell.size(); i++)
		{
			ModelCell modelCell = (ModelCell)this.modelCell.elementAt(i);
			modelCell.x = x;
			modelCell.y = y;
			modelCell.xTo = array[num][i];
			modelCell.yTo = array2[num][i];
			modelCell.saveX = modelCell.xTo;
			modelCell.saveY = modelCell.yTo;
		}
	}

	public override void init()
	{
		if (modelCell != null && modelCell.size() > 0)
		{
			setSit();
		}
		base.init();
	}

	public void starFlyString(string[] info, int x, int y)
	{
		result = info;
		xchar = x;
		ychar = y;
		yTo = y - 20;
	}

	public void updateFlyText()
	{
		if (ychar != yTo)
		{
			ychar--;
			return;
		}
		ychar = yTo;
		if (result != null)
		{
			for (sbyte b = 0; b < result.Length; b = (sbyte)(b + 1))
			{
				result[b] = string.Empty;
			}
		}
	}

	public override void paint(MyGraphics g)
	{
		Canvas.gameScr.paint(g);
		Res.paintDlgFull(g, 10, 20, Canvas.w - 20, Canvas.h - 60);
		MFont.borderFont.drawString(g, "Hộp may mắn", Canvas.hw, 25, 2);
		for (int i = 0; i < this.modelCell.size(); i++)
		{
			ModelCell modelCell = (ModelCell)this.modelCell.elementAt(i);
			if (modelCell != null)
			{
				modelCell.paint(g);
				if (Canvas.gameTick % 4 == 0 && idCell == i && !isClose)
				{
					g.setColor(16777215);
					g.drawRect(modelCell.x - 17, modelCell.y - 17, 34, 34);
				}
			}
		}
		if (ychar != yTo)
		{
			for (sbyte b = 0; b < result.Length; b = (sbyte)(b + 1))
			{
				MFont.normalFont[0].drawString(g, result[b], xchar, ychar + b * 14, 2);
			}
		}
		base.paint(g);
	}

	public override void update()
	{
		for (int i = 0; i < modelCell.size(); i++)
		{
			((ModelCell)modelCell.elementAt(i))?.update();
		}
		if (isClose && timeBegin - mSystem.getCurrentTimeMillis() / 1000 <= 0 && isOpen)
		{
			isOpen = false;
			doClose();
			center = cmdSelect;
			right = cmdSelcetAll;
			isPointer = true;
		}
		updateFlyText();
		base.update();
	}

	public override void updateKey()
	{
		if (Canvas.keyPressed[4])
		{
			Canvas.keyPressed[4] = false;
			if (!isClose)
			{
				idCell--;
				if (idCell < 0)
				{
					idCell = 0;
				}
			}
		}
		else if (Canvas.keyPressed[6])
		{
			Canvas.keyPressed[6] = false;
			if (!isClose)
			{
				idCell++;
				if (idCell > modelCell.size() - 1)
				{
					idCell = modelCell.size() - 1;
				}
			}
		}
		updatePoint();
		base.updateKey();
	}

	public void doClose()
	{
		isClose = ((!isClose) ? true : false);
		for (int i = 0; i < this.modelCell.size(); i++)
		{
			ModelCell modelCell = (ModelCell)this.modelCell.elementAt(i);
			if (isClose)
			{
				modelCell.xTo = Canvas.w / 2;
				modelCell.yTo = Canvas.h / 2;
			}
			else
			{
				modelCell.xTo = modelCell.saveX;
				modelCell.yTo = modelCell.saveY;
			}
		}
	}
}
