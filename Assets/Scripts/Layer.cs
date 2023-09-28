public class Layer
{
	public ActionPerform isUpdate;

	public ActionKey isKeyCode;

	public ActionPaintCmd isPaint;

	public void update()
	{
		isUpdate();
	}

	public void paint(MyGraphics g, int x, int y)
	{
		isPaint(g, x, y);
	}

	public void keyPress(int keyCode)
	{
		isKeyCode(keyCode);
	}
}
