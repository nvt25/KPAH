public class Command
{
	public string caption = string.Empty;

	public ActionPerform action;

	public ActionPaintCmd actionPaint;

	public ActionChat actionChat;

	public int idMap = -1;

	public Command(string caption)
	{
		this.caption = caption;
	}

	public Command()
	{
	}

	public void perform()
	{
		if (action != null)
		{
			action();
		}
	}

	public void paint(MyGraphics g, int x, int y)
	{
		if (actionPaint != null)
		{
			actionPaint(g, x, y);
		}
	}

	public void perform(string str)
	{
		if (actionChat != null)
		{
			actionChat(str);
		}
	}
}
