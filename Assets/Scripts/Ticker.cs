public class Ticker
{
	private int x;

	private int y;

	public bool end;

	public string info = string.Empty;

	public Ticker(string info, int x, int y)
	{
		this.info = info;
		this.x = x;
		this.y = y;
	}

	public void paint(MyGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, Canvas.w, MFont.normalFont[0].getHeight() + 4);
		MFont.normalFont[0].drawString(g, info, x, y, 0);
	}

	public void update()
	{
		if (x + MFont.normalFont[0].getWidth(info) + 10 < 0)
		{
			end = true;
		}
		x -= 2;
	}
}
