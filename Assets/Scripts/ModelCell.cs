public class ModelCell
{
	public int x;

	public int y;

	public int xTo;

	public int yTo;

	public int id;

	public int saveX;

	public int saveY;

	public int index;

	public ModelCell()
	{
		index = 0;
	}

	public void paint(MyGraphics g)
	{
		g.setColor(15852810);
		g.fillRect(x - 16, y - 16, 32, 32);
		g.setColor(34949);
		g.fillRect(x - 14, y - 14, 28, 28);
		g.drawImage(Res.imgBox[index], x, y, 3);
	}

	public void update()
	{
		if (x != xTo)
		{
			if (xTo - x >> 1 == 0)
			{
				x = xTo;
			}
			else
			{
				x += xTo - x >> 1;
			}
		}
		if (y != yTo)
		{
			if (yTo - y >> 1 == 0)
			{
				y = yTo;
			}
			else
			{
				y += yTo - y >> 1;
			}
		}
	}
}
