public abstract class Dialog : MainJ2ME
{
	public override void paint(MyGraphics g)
	{
		base.paint(g);
	}

	public override void updateKey()
	{
		base.updateKey();
	}

	public virtual void keyPress(int keyCode)
	{
	}

	public virtual void update()
	{
		base.updateKey();
	}

	public void show()
	{
		Canvas.currentDialog = this;
	}
}
