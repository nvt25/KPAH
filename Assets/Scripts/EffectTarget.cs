public class EffectTarget : Effect
{
	private int xTo;

	private int yTo;

	private int va;

	private int vx;

	private int vy;

	private int angle0;

	private int dir;

	private new int type;

	private LiveActor l_To;

	private int dx;

	private int dy;

	private int himg;

	private int flip;

	public EffectTarget(LiveActor l_To, int dir, int type, int va)
	{
		this.l_To = l_To;
		this.dir = dir;
		switch (dir)
		{
		case 0:
			x = l_To.x - ((type != 0) ? 20 : 100);
			y = l_To.y - 100 - ((type != 0) ? 100 : 0);
			xTo = l_To.x + ((type != 0) ? (-20) : 0);
			break;
		case 1:
			x = l_To.x + ((type != 0) ? (-10) : 100);
			y = l_To.y - 100 - ((type != 0) ? 100 : 0);
			xTo = l_To.x + ((type != 0) ? (-10) : 0);
			break;
		case 2:
			x = l_To.x + ((type != 0) ? 10 : 100);
			y = l_To.y + ((type != 0) ? (-200) : 100);
			xTo = l_To.x + ((type != 0) ? 10 : 0);
			break;
		default:
			x = l_To.x - ((type != 0) ? 20 : 100);
			y = l_To.y + ((type != 0) ? (-200) : 100);
			xTo = l_To.x + ((type != 0) ? 20 : 0);
			break;
		}
		yTo = l_To.y;
		this.type = type;
		angle0 = Util.angle(x - l_To.x, l_To.y - (l_To.height >> 1) - y);
		this.va = va;
		vx = va * Util.Cos(angle0) >> 10;
		vy = va * Util.Sin(angle0) >> 10;
		himg = l_To.height;
	}

	public override void update()
	{
		if (l_To != null)
		{
			if (dir == 0)
			{
				xTo = l_To.x + ((type != 0) ? (-20) : (-4));
				yTo = l_To.y - ((type != 15) ? 0 : 0);
			}
			else if (dir == 1)
			{
				xTo = l_To.x + ((type != 0) ? (-10) : 8);
				yTo = l_To.y - ((type != 10) ? 0 : 0);
			}
			else if (dir == 2)
			{
				xTo = l_To.x + ((type != 0) ? 10 : 4);
				yTo = l_To.y + ((type != 15) ? 0 : 0);
			}
			else
			{
				xTo = l_To.x + ((type != 0) ? 20 : (-8));
				yTo = l_To.y + ((type != 20) ? 0 : 0);
			}
		}
		dx = xTo - x;
		dy = yTo - (himg >> 1) - y;
		angle0 = Util.angle(dx, dy);
		vx = va * Util.Cos(angle0) >> 10;
		vy = va * Util.Sin(angle0) >> 10;
		x += vx;
		y += vy;
		EffectManager.addLowEffect(x, y, (type != 0) ? 29 : 32);
		if (Res.isDestroy(x - 20, x + 20, xTo - himg / 2, xTo + himg / 2, y - 20, y + 20, yTo - himg / 2, yTo + himg / 2))
		{
			EffectManager.addHiEffect(xTo, yTo - 10, (type != 0) ? 30 : 38);
			EffectManager.hiEffects.removeElement(this);
			if (l_To != null)
			{
				int damAttack = l_To.damAttack;
				l_To.doublejump();
				Canvas.gameScr.startFlyText("-" + damAttack, 0, l_To.x, l_To.y + l_To.dy - 15, 1, -2);
			}
		}
		if (type != 1)
		{
			if (dir == 0)
			{
				flip = 0;
			}
			else if (dir == 1)
			{
				flip = 2;
			}
			else if (dir == 3)
			{
				flip = 1;
			}
			else
			{
				flip = 7;
			}
		}
	}

	public override void paint(MyGraphics g)
	{
		if (type == 1)
		{
			if (Res.getImgArrow(4) != null)
			{
				g.drawRegion(Res.imgArrow[4], 0, 0, 24, 24, 5, x, y, 3);
			}
		}
		else if (Res.imgEffect[31] != null)
		{
			g.drawRegion(Res.imgEffect[31], 0, 0, 20, 20, flip, x, y, 3);
		}
	}
}
