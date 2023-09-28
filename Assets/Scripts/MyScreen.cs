public abstract class MyScreen : MainJ2ME
{
	public static short deltaY = 17;

	public int btnFocus;

	public new static int ITEM_HEIGHT = 20;

	public MyScreen()
	{
	}

	public virtual void init()
	{
	}

	public virtual void switchToMe()
	{
		Canvas.currentScreen = this;
	}

	public virtual void switchToMe(MyScreen scr)
	{
		Canvas.currentScreen = this;
	}

	public virtual bool keyPress(int keyCode)
	{
		return false;
	}

	public override void paint(MyGraphics g)
	{
		Canvas.resetTrans(g);
		if (Res.imgCmdBar != null)
		{
			g.drawImage(Res.imgCmdBar, 0, Canvas.h + 3, MyGraphics.LEFT | MyGraphics.BOTTOM);
		}
		if (Canvas.currentScreen == this && Canvas.currentDialog == null && !Canvas.menu.showMenu)
		{
			base.paint(g);
		}
	}

	public virtual void update()
	{
	}

	public override void updateKey()
	{
		if (Canvas.currentScreen == this)
		{
			base.updateKey();
		}
	}

	public virtual void pointerPress(int dx, int dy)
	{
	}

	public virtual void startXayBot(int idbot, int type, int sl)
	{
	}
}
