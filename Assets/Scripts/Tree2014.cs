using System;

public class Tree2014 : MyScreen
{
	public class ObjTree
	{
		public int x;

		public int y;

		public int idIconImg;

		public sbyte status;

		public string name = string.Empty;

		public string info = string.Empty;

		public void paint(MyGraphics g)
		{
			GameData.paintIconTuBinh(g, (short)(idIconImg + 8200), x, y, 0);
		}
	}

	public static Tree2014 me;

	public MyScreen last;

	public string name = string.Empty;

	private int[] xTrai;

	private int[] yTrai;

	private int index;

	private int xSh;

	private int ySh;

	private int wSh;

	private int hSh;

	private int wCell;

	private int hCell;

	private int xDr;

	private int yDr;

	private int wTree = 76;

	public Scroll mScrollShowText = new Scroll();

	public mVector allTree = new mVector();

	public string[] arrShowText = new string[1]
	{
		string.Empty
	};

	private Command cmdView;

	private Command cmdTuoi;

	private Command cmdThuHoach;

	private Command cmdClose;

	private Command cmdMenu;

	private Command cmdTangToc;

	private bool isShowText;

	private Command cmdErr;

	public string str;

	public Tree2014()
	{
		resetData();
		cmdClose = new Command("Đóng");
		cmdClose.action = delegate
		{
			if (isShowText && !Canvas.isSmartPhone)
			{
				isShowText = false;
				center = cmdView;
				left = cmdMenu;
				mScrollShowText.clear();
			}
			else
			{
				last.switchToMe();
			}
		};
		cmdThuHoach = new Command("Thu hoạch");
		cmdThuHoach.action = delegate
		{
			doThuhoach();
		};
		cmdTangToc = new Command("Tăng tốc");
		cmdTangToc.action = delegate
		{
			doTuoi();
		};
		cmdView = new Command((!Canvas.isSmartPhone) ? "Xem" : string.Empty);
		cmdView.action = delegate
		{
			doView();
		};
		cmdMenu = new Command("Menu");
		cmdMenu.action = delegate
		{
			mVector mVector = new mVector();
			if (allTree.size() > 0)
			{
				ObjTree objTree = (ObjTree)allTree.elementAt(index);
				if (objTree.status == 0)
				{
					mVector.addElement(cmdTangToc);
				}
				else if (objTree.status == 2 || objTree.status == 3)
				{
					mVector.addElement(cmdThuHoach);
				}
				Canvas.menu.startAt(mVector, 0);
			}
		};
		cmdErr = new Command(string.Empty);
		cmdErr.action = delegate
		{
		};
		right = cmdClose;
		center = cmdView;
		left = cmdMenu;
		wCell = 300;
		hCell = 180;
		if (!Canvas.isSmartPhone)
		{
			wCell = 180;
		}
		xDr = Canvas.w / 2 - wCell / 2;
		yDr = Canvas.h / 2 - hCell / 2;
		wSh = 140;
		if (Canvas.isSmartPhone && wCell == 300)
		{
			xSh = xDr + wCell / 2;
			ySh = yDr + 25;
			wSh = wCell / 2 - 6;
			hSh = hCell - 36;
		}
	}

	public static Tree2014 gI()
	{
		return (me != null) ? me : (me = new Tree2014());
	}

	protected void doView()
	{
		if (index >= 0 && index <= allTree.size() - 1)
		{
			GameService.gI().sendInfoFruit(index, 1);
			ObjTree objTree = (ObjTree)allTree.elementAt(index);
		}
	}

	public void setShowText(string info)
	{
		int lineWidth = (!Canvas.isSmartPhone) ? 120 : (wSh - 16);
		string[] array = Util.split(info, "|");
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = MFont.normalFont[0].splitFontBStrInLine(array[i], lineWidth);
			num += array2.Length;
		}
		string[] array3 = new string[num];
		for (int j = 0; j < array.Length; j++)
		{
			string[] array4 = MFont.normalFont[0].splitFontBStrInLine(array[j], lineWidth);
			for (int k = 0; k < array4.Length; k++)
			{
				array3[num2] = array4[k];
				num2++;
			}
		}
		arrShowText = array3;
		if (!Canvas.isSmartPhone)
		{
			if (arrShowText.Length == 1)
			{
				hSh = 35;
				ySh = Canvas.h / 2 - MFont.normalFont[0].getHeight() / 2;
			}
			else
			{
				hSh = arrShowText.Length * 24;
				ySh = Canvas.h / 2 - arrShowText.Length * 24 / 2;
			}
			if (ySh < 5)
			{
				ySh = 5;
			}
			if (hSh > 150)
			{
				hSh = 150;
			}
			xSh = Canvas.w / 2 - 75;
		}
		isShowText = true;
		if (!Canvas.isSmartPhone)
		{
			center = cmdErr;
			left = cmdErr;
		}
	}

	protected void doTuoi()
	{
		GameService.gI().sendInfoFruit(index, 2);
	}

	protected void doThuhoach()
	{
		GameService.gI().sendInfoFruit(index, 3);
	}

	public void resetData()
	{
		xTrai = new int[8];
		yTrai = new int[8];
		int num = Canvas.w / 2 - 75;
		int num2 = Canvas.h / 2 - 75;
		xTrai[0] = 10;
		yTrai[0] = 72;
		xTrai[1] = 43;
		yTrai[1] = 62;
		xTrai[2] = 20;
		yTrai[2] = 28;
		xTrai[3] = 52;
		yTrai[3] = 17;
		xTrai[4] = 70;
		yTrai[4] = 56;
		xTrai[5] = 82;
		yTrai[5] = 7;
		xTrai[6] = 106;
		yTrai[6] = 22;
		xTrai[7] = 112;
		yTrai[7] = 64;
		num2 += 12;
		if (!Canvas.isSmartPhone)
		{
			wTree = 0;
		}
		for (int i = 0; i < xTrai.Length; i++)
		{
			xTrai[i] += num - wTree;
			yTrai[i] += num2;
		}
		mScrollShowText.clear();
		allTree = new mVector();
		index = 0;
		arrShowText = new string[1]
		{
			string.Empty
		};
	}

	public void setInfoTree(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if (b == 0)
			{
				resetData();
				allTree = new mVector();
				ObjTree objTree = null;
				name = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < b2; i++)
				{
					string text = msg.reader().readUTF();
					sbyte b3 = msg.reader().readByte();
					sbyte status = msg.reader().readByte();
					objTree = new ObjTree();
					objTree.idIconImg = b3;
					objTree.name = text;
					objTree.status = status;
					objTree.x = xTrai[i];
					objTree.y = yTrai[i];
					allTree.addElement(objTree);
				}
			}
			else if (b == 1)
			{
				sbyte b4 = msg.reader().readByte();
				ObjTree objTree2 = (ObjTree)allTree.elementAt(b4);
				objTree2.info = msg.reader().readUTF();
				setShowText(objTree2.info);
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintCell(MyGraphics g)
	{
		g.setColor(25695);
		g.fillRect(xSh - 5, ySh + 10, wSh, hSh - 10);
		g.setColor(16774720);
		g.drawRect(xSh - 5, ySh + 10, wSh, hSh - 10);
		if (!isShowText && str != null && Canvas.isSmartPhone)
		{
			string[] array = Util.split(str, "|");
			for (int i = 0; i < array.Length; i++)
			{
				MFont.normalFont[0].drawString(g, array[i], xSh, ySh + i * 14 + 14, 0);
			}
		}
	}

	public void paintShowText(MyGraphics g)
	{
		Canvas.resetTrans(g);
		if (wCell >= 300)
		{
			paintCell(g);
			if (!isShowText)
			{
				return;
			}
		}
		else
		{
			if (!isShowText)
			{
				return;
			}
			paintCell(g);
		}
		mScrollShowText.setStyle(arrShowText.Length, MyScreen.ITEM_HEIGHT, xSh, ySh, wSh - 2, hSh - 10, styleUPDOWN: true, 0);
		mScrollShowText.setClip(g, xSh - 3, ySh + 10, wSh - 2, hSh - 15);
		for (int i = 0; i < arrShowText.Length; i++)
		{
			MFont.normalFont[0].drawString(g, arrShowText[i], xSh, ySh + i * (MyScreen.ITEM_HEIGHT - 3) + 14, 0);
		}
	}

	public void paintNameTree(MyGraphics g, string clockInfo, int x, int y)
	{
		string[] array = Util.split(clockInfo, "|");
		int width = MFont.normalFont[0].getWidth(array[0]);
		int width2 = MFont.normalFont[0].getWidth(array[1]);
		width = ((width >= width2) ? width : width2);
		g.setColor(1593912);
		g.fillRect(x + 16 - width / 2 - 3, y - 16, width + 5, 30);
		g.setColor(16772608);
		g.drawRect(x + 16 - width / 2 - 3, y - 16, width + 5, 30);
		MFont.normalFont[0].drawString(g, array[0], x + 16, y - 15, 2);
		MFont.normalFont[0].drawString(g, array[1], x + 16, y, 2);
	}

	public override void paint(MyGraphics g)
	{
		if (last != null)
		{
			last.paint(g);
		}
		Res.paintDlgFull(g, xDr, yDr, wCell, hCell, 0, name, isDD: false, 0);
		int num = (!Canvas.isSmartPhone) ? (wCell / 2) : wTree;
		GameData.paintIconTuBinh(g, 8214, xDr + num, Canvas.h / 2 + 12, MyGraphics.VCENTER | MyGraphics.HCENTER);
		this.str = null;
		int x = 0;
		int y = 0;
		for (int i = 0; i < allTree.size(); i++)
		{
			ObjTree objTree = (ObjTree)allTree.elementAt(i);
			if (objTree == null)
			{
				continue;
			}
			if (index == i)
			{
				g.setColor(25695);
				g.fillRect(objTree.x, objTree.y, 16, 30);
				g.setColor(16774720);
				g.drawRect(objTree.x, objTree.y, 16, 30);
				x = objTree.x;
				y = objTree.y;
				string str = string.Empty;
				if (objTree.status == 1)
				{
					str = "héo";
				}
				if (objTree.status == 0)
				{
					str = "xanh";
				}
				if (objTree.status == 2)
				{
					str = "chín";
				}
				this.str = objTree.name + "|Trạng thái: " + str;
			}
			objTree.paint(g);
		}
		paintShowText(g);
		if (this.str != null && !Canvas.isSmartPhone && !isShowText)
		{
			paintNameTree(g, this.str, x, y);
		}
		base.paint(g);
	}

	public override void update()
	{
		if (last != null)
		{
			last.update();
		}
		if (Canvas.currentDialog == null)
		{
			ScrollResult scrollResult = mScrollShowText.updateKey();
			mScrollShowText.updatecm();
		}
		base.update();
	}

	public void updateKeyShowText()
	{
		if (Canvas.keyPressed[2])
		{
			Canvas.keyPressed[2] = false;
			mScrollShowText.cmtoY -= 50;
			if (mScrollShowText.cmtoY < 0)
			{
				mScrollShowText.cmtoY = 0;
			}
		}
		else if (Canvas.keyPressed[8])
		{
			Canvas.keyPressed[8] = false;
			mScrollShowText.cmtoY += 50;
			if (mScrollShowText.cmtoY > mScrollShowText.cmyLim)
			{
				mScrollShowText.cmtoY = mScrollShowText.cmyLim;
			}
		}
	}

	public override void updateKey()
	{
		if (isShowText && !Canvas.isSmartPhone)
		{
			updateKeyShowText();
		}
		else
		{
			if (Canvas.keyPressed[4])
			{
				Canvas.keyPressed[4] = false;
				index--;
				if (index < 0)
				{
					index = allTree.size() - 1;
				}
				if (Canvas.isSmartPhone)
				{
					isShowText = false;
					mScrollShowText.clear();
				}
			}
			if (Canvas.keyPressed[6])
			{
				Canvas.keyPressed[6] = false;
				index++;
				if (index > allTree.size() - 1)
				{
					index = 0;
				}
				if (Canvas.isSmartPhone)
				{
					isShowText = false;
					mScrollShowText.clear();
				}
			}
			if (Canvas.isSmartPhone)
			{
				updateKeyShowText();
			}
		}
		pointer();
		base.updateKey();
	}

	public override void switchToMe()
	{
		base.switchToMe();
	}

	public override void switchToMe(MyScreen lastSCR)
	{
		last = lastSCR;
		base.switchToMe(lastSCR);
	}

	public void pointer()
	{
		if ((!Canvas.isSmartPhone && isShowText) || !Canvas.isPointerClick)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < xTrai.Length)
			{
				if (Canvas.px >= xTrai[num] && Canvas.px <= xTrai[num] + 15 && Canvas.py >= yTrai[num] && Canvas.py <= yTrai[num] + 30)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		Canvas.isPointerClick = false;
		isShowText = false;
		mScrollShowText.clear();
		index = num;
		if (!isShowText && center != null)
		{
			center.perform();
		}
	}
}
