public class ObjGame
{
	public bool isTfield;

	public int x;

	public int y;

	public int width;

	public int height;

	public ActionPerform acPopup;

	public string title = string.Empty;

	public virtual void paint(MyGraphics g)
	{
	}

	public virtual void update()
	{
	}

	public virtual void updateKey()
	{
	}

	public virtual bool keyPressed(int keyCode)
	{
		return false;
	}
}
