public class TileTop
{
	public short x;

	public short y;

	public short index;

	public void paint(MyGraphics g, Image img)
	{
		g.drawImagaByDrawTexture(img, x << 4, y << 4);
	}

	public void paintSmall(MyGraphics g)
	{
	}
}
