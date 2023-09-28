public class PopupName : Tree
{
	public string name;

	public byte num;

	public byte iPrivate;

	public static FrameImage imgArrow;

	public PopupName(string name, int x, int y)
		: base(x, y, 0)
	{
		base.x = (short)x;
		base.y = (short)y;
		this.name = name;
		num = (byte)Res.rnd(8);
	}

	public new void update()
	{
		num++;
		if (num >= 8)
		{
			num = 0;
		}
	}

	public bool canPaint(int x, int y, int w, int h)
	{
		if (x - w / 2 > GameScr.cmx + Canvas.w || x + w / 2 < GameScr.cmx || y < GameScr.cmy || y + h > GameScr.cmy + Canvas.h)
		{
			return false;
		}
		return true;
	}

	public override void paint(MyGraphics g)
	{
		g.drawImage(Res.imgShadow, x, y, 3);
		if (imgArrow != null)
		{
			imgArrow.drawFrame(0, x, y - 10 + (int)num / 2, 0, MyGraphics.BOTTOM | MyGraphics.HCENTER, g);
		}
		MFont.normalFont[0].drawString(g, name, x, y - 32 + (int)num / 2 - 2, 2);
	}
}
