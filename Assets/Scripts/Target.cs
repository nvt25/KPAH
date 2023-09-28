public class Target
{
	public short x;

	public short y;

	public byte index;

	public Target()
	{
		index = 0;
	}

	public void paint(MyGraphics g)
	{
		if (x != -1 && Canvas.gameScr.mainChar.state == 1 && y != -1 && Res.imgTG != null)
		{
			g.drawRegion(Res.imgTG, 0, index * 38, 38, 38, 0, x * 16, y * 16, 33);
		}
	}

	public void update()
	{
		if (Canvas.gameTick % 2 == 0)
		{
			index++;
			if (index > 6)
			{
				index = 0;
			}
		}
	}
}
