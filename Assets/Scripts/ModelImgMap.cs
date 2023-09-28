public class ModelImgMap
{
	public int x;

	public int y;

	public int id;

	public int wImg;

	public int hImg;

	public Image image;

	public void setPos(int id, bool isLoad, int typePaint)
	{
		this.id = id;
		int num = id % 4;
		if (isLoad && image == null)
		{
			image = Image.createImage(Main.res + "/gc/m" + id);
			wImg = image.getWidth();
			hImg = image.getHeight();
			switch (typePaint)
			{
			case 0:
				x = num % 2 * wImg;
				y = num / 2 * hImg;
				break;
			case 1:
				x = num * wImg;
				y = 0;
				break;
			case 2:
				x = 0;
				y = num * hImg;
				break;
			}
		}
	}

	public void paint(MyGraphics g)
	{
		if (canPaint())
		{
			g.drawImagaByDrawTexture(image, x, y);
		}
	}

	public bool canPaint()
	{
		if (x > GameScr.cmx + Canvas.w || x + wImg < GameScr.cmx || y > GameScr.cmy + Canvas.h || y + hImg < GameScr.cmy)
		{
			return false;
		}
		return true;
	}

	public void checkLoadImg()
	{
	}
}
