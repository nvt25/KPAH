public class MessageScr : MyScreen
{
	public static MessageScr me;

	protected string[] info;

	private mVector list;

	private int focusTab = 1;

	private MyScreen lastScr;

	private int wTab = 60;

	private new int hTab = 20;

	private int du = 10;

	private int w;

	private int h;

	private int x;

	private int y;

	private int xTr;

	private int yTr;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int selected;

	public static int lastSe;

	public static int limit;

	public static long chatDelay;

	private ChatTab focusT;

	private ChatTab publicTab;

	private TField tfInput;

	public static sbyte nMSG;

	private bool trans;

	private int pa;

	private int a;

	public bool transYShowText;

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

	public float vYT;

	public MessageScr()
	{
		Command command = new Command("Menu");
		ActionPerform actionPerform = command.action = delegate
		{
			mVector mVector = new mVector();
			if (focusTab != 0)
			{
				Command command2 = new Command("Đóng tab");
				ActionPerform actionPerform2 = command2.action = delegate
				{
					list.removeElementAt(focusTab);
					if (focusTab >= list.size())
					{
						focusTab = list.size() - 1;
					}
					setWTab();
					changTab();
				};
				mVector.addElement(command2);
			}
			Command command3 = new Command("Đóng");
			ActionPerform actionPerform3 = command3.action = delegate
			{
				lastScr.switchToMe();
			};
			mVector.addElement(command3);
			Canvas.menu.startAt(mVector, 0);
		};
		left = command;
		tfInput = new TField();
		init();
		tfInput.isFocus = true;
		list = new mVector();
		publicTab = new ChatTab("Tin đến", null, null, isInput: false);
		focusTab = 0;
		publicTab.text = new mVector();
		list.addElement(publicTab);
		changTab();
		setWTab();
	}

	public static MessageScr gI()
	{
		return (me != null) ? me : (me = new MessageScr());
	}

	public override bool keyPress(int keyCode)
	{
		if (focusT.isInput && tfInput.isFocus && !Canvas.menu.showMenu)
		{
			tfInput.keyPressed(keyCode);
		}
		return base.keyPress(keyCode);
	}

	public override void paint(MyGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		lastScr.paint(g);
		Canvas.resetTrans(g);
		base.paint(g);
		paintTab(g, x + xTr, y + yTr, w, h);
		paintText(g);
	}

	public override void pointerPress(int dx, int dy)
	{
		base.pointerPress(dx, dy);
	}

	public override void switchToMe()
	{
		lastScr = Canvas.currentScreen;
		changTab();
		nMSG = 0;
		chatDelay = (int)mSystem.getCurrentTimeMillis() / 100;
		base.switchToMe();
		init();
	}

	public override void update()
	{
		lastScr.update();
		updateKeyShowText();
	}

	public override void updateKey()
	{
		if (focusT.isInput && !Canvas.menu.showMenu)
		{
			tfInput.update();
		}
		if (Canvas.py <= 100 + yTr && Canvas.isPointerClick)
		{
			Canvas.isPointerClick = false;
			if (Canvas.px < Canvas.hw)
			{
				Canvas.keyPressed[4] = true;
				Out.println("44444");
			}
			else if (Canvas.px > Canvas.hw)
			{
				Canvas.keyPressed[6] = true;
				Out.println("6666");
			}
		}
		bool flag = false;
		if (Canvas.isKeyPressed(4))
		{
			focusTab--;
			if (focusTab < 0)
			{
				focusTab = list.size() - 1;
			}
			changTab();
		}
		else if (Canvas.isKeyPressed(6))
		{
			focusTab++;
			if (focusTab >= list.size())
			{
				focusTab = 0;
			}
			changTab();
		}
		if (Canvas.keyHold[2])
		{
			selected--;
			if (selected < lastSe)
			{
				selected = lastSe;
			}
			flag = true;
		}
		else if (Canvas.keyHold[8])
		{
			if (cmy < cmyLim)
			{
				selected++;
			}
			if (selected > focusT.text.size() - lastSe)
			{
				selected = focusT.text.size() - lastSe;
			}
			flag = true;
		}
		if (flag)
		{
			cmtoY = selected * 14 - limit / 2;
			if (cmtoY < 0)
			{
				cmtoY = 0;
			}
			if (cmtoY > cmyLim)
			{
				cmtoY = cmyLim;
			}
		}
		xBegint = 20 + xTr;
		yBegint = 20 + yTr;
		int num = Canvas.w;
		if (num > 480)
		{
			num = 480;
		}
		int num2 = Canvas.h;
		if (num2 > 320)
		{
			num2 = 320;
		}
		wToucht = num - 40;
		hToucht = num2 - 60;
		base.updateKey();
	}

	public void moveCameraY()
	{
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
	}

	public override void init()
	{
		int num = Canvas.w;
		if (num > 480)
		{
			num = 480;
		}
		int num2 = Canvas.h;
		if (num2 > 320)
		{
			num2 = 320;
		}
		w = num - 48;
		h = num2 - 64;
		if (Canvas.w * Canvas.h > 153600)
		{
			xTr = (Canvas.w - num) / 2;
			yTr = (Canvas.h - num2) / 2;
		}
		x = (y = 24);
		tfInput.x = x + 4 + xTr;
		tfInput.y = y + h - 25 + yTr;
		tfInput.height = 20;
		tfInput.width = w - 8;
		setWTab();
	}

	public void setWTab()
	{
		if (list != null && focusT != null)
		{
			du = 20;
			wTab = w - du * list.size() + du - 1;
			if (wTab < MFont.borderFont.getWidth(focusT.name) + 15)
			{
				wTab = MFont.borderFont.getWidth(focusT.name) + 15;
				du = (w - wTab) / (list.size() - 1);
			}
			if (list.size() == 1)
			{
				wTab = w - 1;
			}
		}
	}

	public void setFocusTab(string name)
	{
		for (int i = 0; i < list.size(); i++)
		{
			ChatTab chatTab = (ChatTab)list.elementAt(i);
			if (chatTab.name.Equals(name))
			{
				chatTab.isOpen = false;
				focusT = chatTab;
				focusTab = i;
			}
		}
	}

	public Command setCmd(string cation, ActionPerform action0)
	{
		Command command = new Command(cation);
		command.action = action0;
		return command;
	}

	public void addTab(string te, string name, int type)
	{
		ChatTab chatTab = null;
		if (name != null && !name.Equals(publicTab.name))
		{
			chatTab = getTab(name);
			if (this != Canvas.currentScreen)
			{
				nMSG = 1;
			}
		}
		else
		{
			chatTab = publicTab;
		}
		if (chatTab == null)
		{
			ActionPerform action = delegate
			{
				doChat();
			};
			Command cen = setCmd("Chat", action);
			chatTab = new ChatTab(name, cen, tfInput.cmdClear, isInput: true);
			chatTab.text = new mVector();
			list.addElement(chatTab);
			setWTab();
		}
		if (!te.Equals(string.Empty))
		{
			string[] array = MFont.arialFontW.splitFontBStrInLine(te, w - 20);
			for (int i = 0; i < array.Length; i++)
			{
				chatTab.text.addElement(array[i]);
				if (chatTab.text.size() > 50)
				{
					chatTab.text.removeElementAt(0);
				}
			}
		}
		if (chatTab == focusT)
		{
			if (selected + 1 == focusT.text.size() - lastSe)
			{
				selected = focusT.text.size() - lastSe;
				cmtoY = selected * 14 - limit / 2;
			}
			cmyLim = focusT.text.size() * 14 - limit + 50;
			if (cmyLim < 0)
			{
				cmyLim = 0;
			}
		}
	}

	protected void doChat()
	{
		if (!tfInput.getText().Equals(string.Empty))
		{
			chatDelay = mSystem.getCurrentTimeMillis() / 100;
			if (focusT.name.Equals("Bang hội"))
			{
				GameService.gI().chatToClan(tfInput.getText());
			}
			else
			{
				addTab(Canvas.gameScr.mainChar.name + ": " + tfInput.getText(), focusT.name, 0);
				GameService.gI().sendMsgPrivate(focusT.name, tfInput.getText());
			}
			tfInput.setText(string.Empty);
		}
	}

	private ChatTab getTab(string name)
	{
		for (int i = 0; i < list.size(); i++)
		{
			ChatTab chatTab = (ChatTab)list.elementAt(i);
			if (chatTab.name.Equals(name))
			{
				return chatTab;
			}
		}
		return null;
	}

	private void changTab()
	{
		focusT = (ChatTab)list.elementAt(focusTab);
		focusT.isOpen = false;
		limit = h - hTab;
		if (focusT.isInput)
		{
			limit -= 21;
		}
		cmyLim = focusT.text.size() * 14 - limit + 50;
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		cmy = (cmtoY = 0);
		lastSe = (limit - 10) / 2 / 14;
		selected = lastSe;
		center = focusT.center;
		right = focusT.right;
	}

	private void paintText(MyGraphics g)
	{
		MFont.bigFont.drawString(g, focusT.name, x + wTab / 2 + focusTab * du + xTr, y + hTab / 2 - 6 + yTr, 2);
		if (focusT.isInput && !Canvas.menu.showMenu)
		{
			tfInput.paint(g);
		}
		g.setClip(x + xTr, y + hTab + 5 + yTr, w - 3, limit - 9);
		g.translate(0 + xTr, -cmy + yTr);
		if (focusT.text.size() <= 0)
		{
			return;
		}
		int num = cmy / 14;
		if (num <= 0)
		{
			num = 0;
		}
		int num2 = num + limit / 14 + 1;
		if (num2 >= focusT.text.size())
		{
			num2 = focusT.text.size();
		}
		for (int i = num; i < num2; i++)
		{
			string text = (string)focusT.text.elementAt(i);
			if (text != null)
			{
				MFont.arialFontW.drawString(g, text, x + 8, y + i * 14 + hTab + 3, 0);
			}
		}
	}

	private void paintTab(MyGraphics g, int x, int y, int w, int h)
	{
		g.setColor(277044);
		g.fillRect(x, y + hTab, w, h - hTab);
		for (int i = 0; i < 3; i++)
		{
			g.setColor(Res.color[i]);
			g.drawRect(x + i, y + i + hTab, w - i * 2 - 1, h - i * 2 - hTab - 1);
		}
		for (int num = list.size() - 1; num > focusTab; num--)
		{
			ChatTab chatTab = (ChatTab)list.elementAt(num);
			for (int j = 0; j < 3; j++)
			{
				g.setColor(Res.color[j]);
				g.drawRect(x + j + num * du, y + j, wTab - j * 2, hTab - j * 2);
			}
			chatTab.count++;
			if (chatTab.count > 10)
			{
				chatTab.count = 0;
			}
			if (chatTab.isOpen && chatTab.count >= 5)
			{
				g.setColor(573098);
				g.fillRect(x + 3 + du * num, y + 3, wTab - 5, hTab - 3);
			}
			else
			{
				g.setClip(x + du * num + wTab - du, y, du - 2, hTab);
				g.drawImage(Res.imgInv[2], x + du * num + 3 + wTab - 70, y + 3, 0);
				g.setClip(x, y, w, h);
			}
		}
		for (int k = 0; k <= focusTab; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				g.setColor(Res.color[l]);
				g.drawRect(x + l + k * du, y + l, wTab - l * 2, hTab - l * 2);
			}
			ChatTab chatTab2 = (ChatTab)list.elementAt(k);
			chatTab2.count++;
			if (chatTab2.count > 10)
			{
				chatTab2.count = 0;
			}
			if (chatTab2.isOpen && chatTab2.count >= 5)
			{
				g.setColor(573098);
				g.fillRect(x + 3 + du * k, y + 3, wTab - 5, hTab - 3 + ((k == focusTab) ? 4 : 0));
			}
			else if (k == focusTab)
			{
				g.setClip(x + du * k + 3, y, wTab - 5, hTab + 3);
				for (int m = 0; m < wTab / 70 + 1; m++)
				{
					g.drawImage(Res.imgInv[2], x + 3 + du * k + 70 * m, y + 3, 0);
				}
			}
			else
			{
				g.setClip(x + du * k, y, du, hTab);
				g.drawImage(Res.imgInv[2], x + du * k + 3, y + 3, 0);
			}
			g.setClip(x - 4, y - 4, w + 8, h + 9);
		}
		g.drawImage(Res.imgInv[0], x - 2 + du * focusTab, y - 2, 0);
		g.drawRegion(Res.imgInv[0], 0, 0, 18, 19, 2, x + 3 + wTab + du * focusTab, y - 2, MyGraphics.TOP | MyGraphics.RIGHT);
		for (int n = 0; n < 2; n++)
		{
			for (int num2 = 0; num2 < 2; num2++)
			{
				g.setColor(Res.color[(n != 0) ? (2 - num2) : (1 + num2)]);
				g.fillRect(x + focusTab * du + (num2 + 1) + (wTab - 3) * n, y + hTab - 8 + 6 + ((n != 0) ? (1 - num2) : num2), 1, 3);
			}
		}
		g.setClip(0, 0, Canvas.w, Canvas.h);
		g.drawRegion(Res.imgInv3, 0, 0, 18, 19, 2, x - 2, y + h + 2, MyGraphics.BOTTOM | MyGraphics.LEFT);
		g.drawImage(Res.imgInv3, x + w + 2, y + h + 2, MyGraphics.BOTTOM | MyGraphics.RIGHT);
	}

	public void updateKeyShowText()
	{
		countShowText++;
		if (Canvas.isPointerDownText && Canvas.isPointer(xBegint, yBegint, wToucht, hToucht))
		{
			pyLastt = Canvas.pyLast;
			Canvas.isPointerDownText = false;
			timeDelayt = countShowText;
			pa = cmy;
			transYShowText = true;
			vYT = 0f;
		}
		if (transYShowText)
		{
			long num = countShowText - timeDelayt;
			int num2 = pyLastt - Canvas.py;
			pyLastt = Canvas.py;
			if (Canvas.isPointerDown)
			{
				if (countShowText % 2 == 0)
				{
					dyTrant = Canvas.py;
					timePointYt = countShowText;
				}
				vYT = 0f;
				if (cmtoY <= 0 || cmtoY >= cmyLim)
				{
					if (Canvas.beginMoveCmrY())
					{
						cmtoY = pa + Canvas.dy() / 2;
					}
				}
				else if (Canvas.beginMoveCmrY())
				{
					cmtoY = pa + num2;
					pa = cmtoY;
				}
				cmy = cmtoY;
			}
			if (Canvas.isPointerRelease)
			{
				transYShowText = false;
				int num3 = (int)(countShowText - timePointYt);
				float num4 = dyTrant - Canvas.py;
				float num5 = dxTrant - Canvas.px;
				vYT = num4 / (float)num3 * 10f;
				timePointYt = -1L;
			}
		}
		moveCameraShowText();
	}

	public void moveCameraShowText()
	{
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		if (vYT != 0f)
		{
			if (cmy < 0 || cmy > cmyLim)
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
			cmy += (int)(vYT / 15f);
			cmtoY = cmy;
			vYT -= vYT / 20f;
		}
		else if (cmy < 0)
		{
			cmtoY = 0;
		}
		else if (cmy > cmyLim)
		{
			cmtoY = cmyLim;
		}
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
	}
}
