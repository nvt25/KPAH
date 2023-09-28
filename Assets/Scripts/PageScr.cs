public class PageScr : MyScreen
{
	public static PageScr me;

	public Layer layer;

	private MyScreen lastScr;

	private int x;

	private int y;

	private int w;

	private int h;

	public int indexFont;

	private string title;

	public bool isBigMap;

	public static PageScr gI()
	{
		return (me != null) ? me : (me = new PageScr());
	}

	public override void switchToMe()
	{
		if (Canvas.currentScreen != this)
		{
			lastScr = Canvas.currentScreen;
		}
		base.switchToMe();
	}

	public static void tr()
	{
	}

	public void setInfo(int x, int y, int w, int h, string title, Command cmd)
	{
		Canvas.isPointerDown = (Canvas.isPointerClick = false);
		Canvas.clearKeyPressed();
		indexFont = 0;
		this.x = x;
		this.y = y;
		this.w = w;
		this.h = h;
		this.title = title;
		center = cmd;
		left = new Command("Đóng");
		ActionPerform action = delegate
		{
			lastScr.switchToMe();
		};
		left.action = action;
	}

	public override void update()
	{
		if (lastScr != null && lastScr != Canvas.shop)
		{
			lastScr.update();
		}
		if (layer != null)
		{
			layer.update();
		}
	}

	public override bool keyPress(int keyCode)
	{
		layer.keyPress(keyCode);
		return false;
	}

	public override void paint(MyGraphics g)
	{
		lastScr.paint(g);
		Canvas.resetTrans(g);
		if (indexFont == 0)
		{
			Res.paintDlgFull(g, x, y, w, h);
			if (indexFont == 0)
			{
				MFont.bigFont.drawString(g, title, x + w / 2, y + 5, 2);
			}
			if (layer != null)
			{
				layer.paint(g, 0, 0);
			}
		}
		else
		{
			g.translate(x, y);
			Res.paintDlgFull(g, 0, 0, w, h);
			MFont.bigFont.drawString(g, title, w / 2, 6, 2);
			if (layer != null)
			{
				layer.paint(g, 0, 35);
			}
		}
		base.paint(g);
	}

	public override void switchToMe(MyScreen scr)
	{
		lastScr = scr;
		base.switchToMe(scr);
	}
}
