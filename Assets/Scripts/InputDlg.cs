public class InputDlg : Dialog
{
	protected string title;

	public TField tfInput;

	public ActionPerform okAction;

	public ActionPerform backAction;

	private int w;

	public bool isMax;

	public static InputDlg me = new InputDlg();

	private int hitem;

	private int wDia;

	private int hDia;

	private int xDia;

	private int yDia;

	private int numw;

	private int hTouch;

	private int istouchMore;

	private int numh;

	private string[] strinfo;

	private string[] name;

	private bool iscroll;

	private bool isShow;

	public TField[] mtfInput;

	public static Scroll scr = new Scroll();

	private int select;

	public InputDlg()
	{
		tfInput = new TField();
		tfInput.height = 21;
		tfInput.y = Canvas.h - 76;
		tfInput.isFocus = true;
	}

	public static InputDlg gI()
	{
		if (me == null)
		{
			me = new InputDlg();
		}
		return me;
	}

	public void init()
	{
		tfInput.y = Canvas.h - 76;
		w = MFont.borderFont.getWidth(title) + 30;
		if (w > Canvas.w)
		{
			string text = string.Empty;
			for (int i = 0; i < title.Length - 1; i++)
			{
				text += title.Substring(i, 1);
				if (MFont.borderFont.getWidth(text) >= Canvas.w - 50)
				{
					title = text + "...";
					w = MFont.borderFont.getWidth(title) + 30;
					break;
				}
			}
		}
		else if (!isMax)
		{
			w = Canvas.w - 30;
		}
		if (w < 110)
		{
			w = 110;
		}
		tfInput.width = w - 40;
		tfInput.x = Canvas.hw - tfInput.width / 2;
	}

	public void setInfo(string[] strinfo, string title, ActionPerform ok, int type, int num, bool isMaxW)
	{
		mtfInput = null;
		isMax = isMaxW;
		tfInput.setText(string.Empty);
		tfInput.setIputType(type);
		tfInput.setMaxTextLenght(num);
		this.title = title;
		isMax = isMaxW;
		tfInput.setText(string.Empty);
		tfInput.setIputType(type);
		tfInput.setMaxTextLenght(num);
		ActionPerform actionPerform = delegate
		{
		};
		this.title = title;
		okAction = ok;
		isShow = true;
		backAction = delegate
		{
			Canvas.gameScr.chatMode = false;
			Canvas.endDlg();
		};
		left = new Command("Đóng");
		left.action = backAction;
		center = new Command("Ok");
		center.action = okAction;
		right = tfInput.cmdClear;
		init();
		init();
		hitem = 50;
		wDia = Canvas.w - 30;
		if (wDia > 140)
		{
			wDia = 140;
		}
		mtfInput = new TField[strinfo.Length];
		this.strinfo = strinfo;
		name = name;
		if (mtfInput.Length > 3)
		{
			iscroll = true;
		}
		if (iscroll)
		{
			wDia = Canvas.w / 4 * 3;
			hDia = Canvas.h / 5 * 4;
			wDia = Canvas.w - 30;
			if (wDia > 140)
			{
				wDia = 140;
			}
			if (hDia < 210)
			{
				hDia = 210;
			}
			else if (hDia > 280)
			{
				hDia = 280;
			}
			if (hDia < 210)
			{
				hDia = 210;
			}
			else if (hDia > 280)
			{
				hDia = 280;
			}
			xDia = Canvas.hw - wDia / 2;
			yDia = Canvas.hh - hDia / 2;
			if (yDia < 20)
			{
				yDia = 20;
			}
			if (Canvas.isSmallScreen)
			{
				yDia = 0;
			}
		}
		else
		{
			hDia = (TField.getHeight() + 18) * strinfo.Length + 6 + Canvas.hCommand;
			hDia += hTouch + istouchMore;
			xDia = Canvas.hw - wDia / 2;
			yDia = Canvas.h - Canvas.hCommand * 2 - hDia + 15;
		}
		numw = (wDia - 6) / 32;
		numh = (hDia - 6) / 32;
		for (int i = 0; i < mtfInput.Length; i++)
		{
			mtfInput[i] = new TField(xDia + 10, yDia + 15 + (TField.getHeight() + 18) * i + istouchMore + Canvas.hCommand, wDia - 20, 21);
			mtfInput[i].setText(string.Empty);
		}
	}

	public void setInfo(string title, ActionPerform ok, int type, int num, bool isMaxW)
	{
		isMax = isMaxW;
		tfInput.setText(string.Empty);
		isShow = false;
		tfInput.setIputType(type);
		tfInput.setMaxTextLenght(num);
		this.title = title;
		okAction = ok;
		backAction = delegate
		{
			Canvas.gameScr.chatMode = false;
			Canvas.endDlg();
		};
		left = new Command("Đóng");
		left.action = backAction;
		center = new Command("Ok");
		center.action = okAction;
		right = tfInput.cmdClear;
		init();
	}

	public override void paint(MyGraphics g)
	{
		if (!isShow)
		{
			Canvas.resetTrans(g);
			Res.paintDlgFull(g, Canvas.hw - w / 2, Canvas.h - 110, w, 69);
			MFont.borderFont.drawString(g, title, Canvas.hw, Canvas.h - 104, 2);
			tfInput.paint(g);
		}
		else
		{
			paintList(g);
		}
		base.paint(g);
	}

	public void paintList(MyGraphics g)
	{
		Res.paintDlgFull(g, xDia, yDia, wDia, hDia);
		MFont.borderFont.drawString(g, title, xDia + wDia / 2, yDia + 3, 2);
		Canvas.resetTrans(g);
		scr.setStyle(mtfInput.Length + 1, 50, xDia, yDia, wDia, hDia, styleUPDOWN: true, 1);
		scr.setClip(g, xDia + 10, yDia + Canvas.hCommand, wDia, hDia - hitem - 10);
		int num = yDia + istouchMore + Canvas.hCommand;
		for (int i = 0; i < mtfInput.Length; i++)
		{
			MFont.borderFont.drawString(g, strinfo[i], Canvas.w / 2, num + i * (TField.getHeight() + 18), 2);
			mtfInput[i].paintByList(g);
		}
	}

	public override void keyPress(int keyCode)
	{
		if (isShow)
		{
			for (int i = 0; i < mtfInput.Length; i++)
			{
				if (mtfInput[i].isFocus)
				{
					mtfInput[i].keyPressed(keyCode);
				}
			}
		}
		if (tfInput.keyPressed(keyCode))
		{
			Canvas.keyPressed[5] = false;
		}
	}

	public override void update()
	{
		if (isShow)
		{
			for (int i = 0; i < mtfInput.Length; i++)
			{
				mtfInput[i].updatelist();
			}
			ScrollResult scrollResult = scr.updateKey();
			select = scrollResult.selected;
			scr.updatecm();
		}
		tfInput.update();
		base.updateKey();
	}

	public override void updateKey()
	{
	}
}
