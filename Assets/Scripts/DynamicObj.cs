public class DynamicObj : Actor
{
	public Image img;

	public sbyte w;

	public sbyte h;

	public sbyte nFrame;

	public sbyte id;

	public DynamicObj()
	{
		catagory = 100;
	}

	public override void paint(MyGraphics g)
	{
		if (img != null)
		{
			g.drawRegion(img, 0, id * height, img.getWidth(), height, 0, x + 8, y + 8, MyGraphics.BOTTOM | MyGraphics.HCENTER);
		}
	}

	public override void setPosTo(short x, short y)
	{
		base.x = x;
		base.y = y;
	}

	public override void paintName(MyGraphics g)
	{
	}

	public override void update()
	{
		if (Canvas.gameTick % 3 == 0)
		{
			id = (sbyte)((id + 1) % nFrame);
		}
	}
}
