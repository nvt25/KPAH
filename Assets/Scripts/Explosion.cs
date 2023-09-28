public class Explosion : Actor
{
	private int f;

	private int p1;

	public Explosion(short x, short y)
	{
		catagory = Actor.CAT_EXPLOTION;
		base.x = x;
		base.y = y;
		p1 = 0;
	}

	public override bool isPaint()
	{
		if (x < GameScr.cmx)
		{
			return false;
		}
		if (x > GameScr.cmx + Canvas.w)
		{
			return false;
		}
		if (y < GameScr.cmy)
		{
			return false;
		}
		if (y > GameScr.cmy + Canvas.h + 30)
		{
			return false;
		}
		return true;
	}

	public override void paint(MyGraphics g)
	{
		if (isPaint())
		{
			g.drawRegion(Res.imgExplosion, 0, f * 24, 24, 24, 0, x - 12, y - 24, 0);
		}
	}

	public override void setPosTo(short x, short y)
	{
		base.x = x;
		base.y = y;
	}

	public override void update()
	{
		p1++;
		if (p1 > 8)
		{
			p1 = 0;
			wantDestroy = true;
		}
		f = p1 >> 1;
	}
}
