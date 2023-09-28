public class Menu : MainJ2ME
{
	public bool showMenu;

	public bool isBegin;

	public mVector menuItems;

	public int selected;

	public int menuX;

	public int menuY;

	public int menuW;

	public int menuH;

	public int menuTemY;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int xc;

	private int pa;

	private bool trans;

	private int cvyb;

	private int cdyb;

	private int ctoyBag;

	private int cyBag;

	private int cylim;

	public bool transYShowText;

	public bool canSelecet;

	public bool isPaintFc;

	public bool isClose;

	private long timePointYt;

	private long timeOpent;

	private long timeDelayt;

	private int pyLastt;

	private int dyTrant;

	private int dxTrant;

	private int xBegint;

	private int yBegint;

	private int wToucht;

	private int hToucht;

	private int countShowText;

	private int timeHold;

	public float vYT;

	public Menu()
	{
		ActionPerform action = delegate
		{
			showMenu = false;
			if (selected != -1)
			{
				if (GameScr.iTaskAuto == 2)
				{
					selected = 0;
				}
				if (Math.abs(Canvas.px - Canvas.pxLast) < 10 && Math.abs(Canvas.py - Canvas.pyLast) < 10)
				{
					Command command = (Command)menuItems.elementAt(selected);
					command.perform();
				}
			}
		};
		center = new Command(string.Empty);
		center.action = action;
		right = new Command(string.Empty);
		ActionPerform action2 = delegate
		{
			showMenu = false;
			Canvas.clearKeyHold();
			Canvas.clearKeyPressed();
			Canvas.isPointerDown = false;
		};
		right.action = action2;
		left = new Command();
		left.action = action;
	}

	public void setIndex()
	{
		if (menuItems != null)
		{
			selected = GameScr.r.nextInt(menuItems.size());
			ctoyBag = selected * MyScreen.ITEM_HEIGHT - MyScreen.ITEM_HEIGHT * 2;
			if (ctoyBag < 0)
			{
				ctoyBag = 0;
			}
			if (ctoyBag > cylim)
			{
				ctoyBag = cylim;
			}
		}
	}

	public void startAt(mVector menuItems, int pos)
	{
		if (menuItems.size() <= 0)
		{
			return;
		}
		Canvas.isPointerClick = (Canvas.isPointerDown = (Canvas.isPointerDownItem = (Canvas.isPointerDrange = (Canvas.isPointerRelease = false))));
		selected = -1;
		isPaintFc = false;
		this.menuItems = menuItems;
		menuW = 0;
		menuH = 0;
		int num = menuItems.size();
		for (int i = 0; i < num; i++)
		{
			Command command = (Command)menuItems.elementAt(i);
			int width = MFont.normalFont[0].getWidth(command.caption);
			if (width > menuW)
			{
				menuW = width;
			}
			menuH += MainJ2ME.ITEM_HEIGHT;
		}
		menuW += 60;
		if (menuW < 100)
		{
			menuW = 100;
		}
		menuH += 5;
		menuY = Canvas.h - MainJ2ME.hTab - menuH - 3;
		if (menuItems.size() > 5)
		{
			menuY = Canvas.h - MainJ2ME.ITEM_HEIGHT * 5 - MainJ2ME.hTab - 60;
			menuH = MainJ2ME.ITEM_HEIGHT * 5 + 50;
		}
		showMenu = true;
		selected = -1;
		cylim = this.menuItems.size() * MainJ2ME.ITEM_HEIGHT - MainJ2ME.ITEM_HEIGHT * 5;
		if (menuItems.size() > 5)
		{
			cylim = this.menuItems.size() * MainJ2ME.ITEM_HEIGHT - MainJ2ME.ITEM_HEIGHT * 6;
		}
		if (cylim < 0)
		{
			cylim = 0;
		}
		menuW += 30;
		cyBag = 0;
		ctoyBag = 0;
		selected = -1;
		xc = 50;
		menuTemY = menuY;
		switch (pos)
		{
		case 0:
			menuX = 5;
			break;
		case 1:
			menuX = Canvas.w - menuW - 10;
			break;
		default:
			menuX = (Canvas.w >> 1) - (menuW >> 1);
			break;
		}
		if (Main.isPC)
		{
			selected = 0;
			right.caption = "Đóng";
			left.caption = "Chọn";
			isPaintFc = true;
		}
		menuH -= 3;
		Canvas.clearKeyHold();
		Canvas.clearKeyPressed();
		Canvas.endDlg();
	}

	private void setKey(int dir)
	{
		if (Main.isPC)
		{
			isPaintFc = true;
			selected += dir;
			if (selected < 0)
			{
				selected = menuItems.size() - 1;
			}
			if (selected > menuItems.size() - 1)
			{
				selected = 0;
			}
			ctoyBag = selected * MainJ2ME.ITEM_HEIGHT - MainJ2ME.ITEM_HEIGHT * 2;
			if (ctoyBag < 0)
			{
				ctoyBag = 0;
			}
			if (ctoyBag > cylim)
			{
				ctoyBag = cylim;
			}
		}
	}

	public void updateMenuKey()
	{
		if (Canvas.isKeyPressed(2) || Canvas.isKeyPressed(KeyConst.A))
		{
			setKey(-1);
		}
		else if (Canvas.isKeyPressed(8) || Canvas.isKeyPressed(KeyConst.S))
		{
			setKey(1);
		}
		xBegint = menuX;
		yBegint = menuY;
		wToucht = menuW;
		hToucht = menuH;
		updateKeyShowText();
		base.updateKey();
	}

	public bool checkClose()
	{
		if ((Canvas.px >= xBegint && Canvas.px <= xBegint + wToucht && Canvas.py >= yBegint && Canvas.py <= yBegint + hToucht) || Canvas.py > Canvas.h - 40)
		{
			return false;
		}
		return true;
	}

	public void updateKeyShowText()
	{
		countShowText++;
		if (timeOpent > 0)
		{
			timeOpent--;
			if (!isClose)
			{
				isPaintFc = true;
			}
			if (timeOpent != 0L || !canSelecet)
			{
				return;
			}
			if (!isClose)
			{
				Out.println(selected + "  time " + timeOpent);
				if (selected != -1 && center != null)
				{
					center.perform();
				}
			}
			else
			{
				if (right != null)
				{
					right.perform();
				}
				isClose = false;
			}
			canSelecet = false;
			return;
		}
		if (Canvas.isPointerDownItem)
		{
			if (Canvas.isPointer(xBegint, yBegint, wToucht, hToucht))
			{
				pyLastt = Canvas.pyLast;
				Canvas.isPointerDownItem = false;
				timeDelayt = countShowText;
				pa = cyBag;
				transYShowText = true;
				vYT = 0f;
			}
			if (checkClose())
			{
				isClose = true;
				if (!Main.isPC)
				{
					isPaintFc = false;
				}
				transYShowText = false;
			}
		}
		if (transYShowText)
		{
			long num = countShowText - timeDelayt;
			int num2 = pyLastt - Canvas.py;
			if (!isClose)
			{
				pyLastt = Canvas.py;
				if (Canvas.isPointerDown)
				{
					if (countShowText % 2 == 0)
					{
						dyTrant = Canvas.py;
						timePointYt = countShowText;
					}
					vYT = 0f;
					if (ctoyBag <= 0 || ctoyBag >= cylim)
					{
						if (Canvas.beginMoveCmrY())
						{
							ctoyBag = pa + Canvas.dy() / 2;
						}
					}
					else if (Canvas.beginMoveCmrY())
					{
						ctoyBag = pa + num2;
						pa = ctoyBag;
					}
					cyBag = ctoyBag;
					if (Main.canvas.canPutKey())
					{
						timeHold++;
						if (timeHold >= 5)
						{
							timeHold = 5;
							isPaintFc = true;
							checkSelect();
						}
					}
					else if (Canvas.canNotPutKey())
					{
						timeHold = 0;
						isPaintFc = false;
					}
				}
				if (Canvas.isPointerRelease)
				{
					transYShowText = false;
					int num3 = (int)(countShowText - timePointYt);
					float num4 = dyTrant - Canvas.py;
					float num5 = dxTrant - Canvas.px;
					if (Canvas.beginMoveCmrY())
					{
						vYT = num4 / (float)num3 * 10f;
					}
					timePointYt = -1L;
					if (Main.canvas.canPutKey() && timeHold != 5)
					{
						if (num <= 4)
						{
							timeHold = 0;
							timeOpent = 5L;
							canSelecet = true;
							checkSelect();
							isClose = false;
						}
					}
					else if (timeHold >= 5)
					{
						timeHold = 0;
						timeOpent = 5L;
						canSelecet = true;
						checkSelect();
						isClose = false;
					}
				}
			}
		}
		if (isClose && Canvas.isPointerRelease)
		{
			if (Main.canvas.canPutKey())
			{
				timeHold = 0;
				timeOpent = 5L;
				canSelecet = true;
				isPaintFc = false;
			}
			else
			{
				isClose = false;
			}
		}
		moveCameraShowText();
	}

	public void checkSelect()
	{
		if (Canvas.px >= xBegint && Canvas.px <= xBegint + wToucht && Canvas.py >= yBegint && Canvas.py <= yBegint + hToucht)
		{
			int num = menuTemY + 2;
			int num2 = (ctoyBag + Canvas.py - num) / MainJ2ME.ITEM_HEIGHT;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > menuItems.size() - 1)
			{
				num2 = menuItems.size() - 1;
			}
			selected = num2;
		}
		else
		{
			selected = -1;
		}
	}

	public void moveCameraShowText()
	{
		if (vYT != 0f)
		{
			if (cyBag < 0 || cyBag > cylim)
			{
				if (vYT > 500f)
				{
					vYT = 500f;
				}
				else if (vYT < -500f)
				{
					vYT = -500f;
				}
				vYT -= vYT / 5f;
				if (Math.abs((int)(vYT / 10f)) <= 10)
				{
					vYT = 0f;
				}
			}
			cyBag += (int)(vYT / 15f);
			ctoyBag = cyBag;
			vYT -= vYT / 20f;
		}
		else if (cyBag < 0)
		{
			ctoyBag = 0;
		}
		else if (cyBag > cylim)
		{
			ctoyBag = cylim;
		}
		if (cyBag != ctoyBag)
		{
			cvyb = ctoyBag - cyBag << 2;
			cdyb += cvyb;
			cyBag += cdyb >> 4;
			cdyb &= 15;
		}
	}

	public void paintMenu(MyGraphics g)
	{
		Canvas.resetTrans(g);
		g.setColor(11908533);
		g.fillRect(menuX - 2, menuY - 2, menuW + 4, menuH + 5);
		g.setColor(2181450);
		g.fillRect(menuX, menuTemY, menuW, menuH);
		g.setClip(menuX - 2, menuY, menuW + 5, menuH);
		g.translate(menuX + 2, menuTemY);
		for (int i = 0; i < menuItems.size(); i++)
		{
			MFont mFont = MFont.normalFont[0];
			if (selected != -1 && i == selected && isPaintFc)
			{
				g.setColor(11495168);
				g.fillRect(-2, i * MainJ2ME.ITEM_HEIGHT - cyBag + 1, menuW, MainJ2ME.ITEM_HEIGHT);
				mFont = MFont.normalFont[0];
			}
			mFont.drawString(g, ((Command)menuItems.elementAt(i)).caption, 5, 10 + i * MainJ2ME.ITEM_HEIGHT - cyBag + 4, 0);
		}
		base.paint(g);
	}

	public void updateMenu()
	{
		if (menuTemY > menuY)
		{
			int num = menuTemY - menuY >> 1;
			if (num < 1)
			{
				num = 1;
			}
			menuTemY -= num;
		}
		menuTemY = menuY;
	}
}
