public class HelpScr : MyScreen
{
	private static HelpScr me;

	public int cmtoY;

	public int cmy;

	public int cmdy;

	public int cmvy;

	public int cmyLim = 10000;

	private string[] stInfo;

	private int[] font;

	private short x;

	private short y;

	private short w;

	private short h;

	public int xTr;

	public int yTr;

	private bool trans;

	private int pa;

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

	public HelpScr()
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
		x = (y = 20);
		w = (short)(num - x * 2);
		h = (short)(num2 - y * 2 - MyScreen.deltaY);
		if (Canvas.h * Canvas.w > 153600)
		{
			xTr = (Canvas.w - w) / 2;
			yTr = (Canvas.h - h) / 2;
		}
		ActionPerform action = delegate
		{
			Canvas.gameScr.switchToMe();
			me = null;
			stInfo = null;
		};
		right = new Command("Đóng");
		right.action = action;
		GameService.gI().requestString(0);
		Canvas.startWaitDlg();
	}

	public static HelpScr gI()
	{
		return (me != null) ? me : (me = new HelpScr());
	}

	public void setInfo(string st)
	{
		stInfo = MFont.normalFont[0].splitFontBStrInLine(st, w - 100);
		int num = 0;
		font = new int[stInfo.Length];
		for (int i = 0; i < stInfo.Length; i++)
		{
			if (stInfo[i].StartsWith("x0"))
			{
				stInfo[i] = stInfo[i].Substring(3);
				num = 0;
			}
			else if (stInfo[i].StartsWith("x1"))
			{
				stInfo[i] = stInfo[i].Substring(3);
				num = 1;
			}
			font[i] = num;
		}
		cmyLim = stInfo.Length * 13 - (h - 35);
		Canvas.endDlg();
	}

	public override bool keyPress(int keyCode)
	{
		return base.keyPress(keyCode);
	}

	public override void paint(MyGraphics g)
	{
		Canvas.gameScr.paint(g);
		g.translate(x, y - 10);
		Res.paintDlgFull(g, xTr, yTr, w, h);
		MFont.bigFont.drawString(g, "Hướng dẫn", Canvas.hw, 4 + yTr, 2);
		g.translate(0, 30);
		g.setClip(xTr, -2 + yTr, w - 4, h - 32);
		g.translate(0, -cmy);
		if (stInfo != null)
		{
			int num = cmy / 13;
			if (num <= 0)
			{
				num = 0;
			}
			int num2 = num + (h - 35) / 13 + 2;
			if (num2 > stInfo.Length)
			{
				num2 = stInfo.Length;
			}
			for (int i = num; i < num2; i++)
			{
				MFont mFont = (font[i] != 0) ? MFont.normalFont[0] : MFont.arialFontW;
				mFont.drawString(g, stInfo[i], 7 + xTr, i * 13 + yTr, 0);
			}
		}
		base.paint(g);
	}

	public override void switchToMe()
	{
		base.switchToMe();
	}

	public override void update()
	{
		Canvas.gameScr.update();
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
		updateKeyShowText();
		base.update();
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
