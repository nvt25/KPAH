public class ArrowTarget : IArrow
{
	private sbyte imgIndex;

	private sbyte d;

	private sbyte v;

	private sbyte timeDelay;

	public short x;

	public short y;

	public short xShadow;

	public short yShadow;

	public short xTo;

	public short yTo;

	public short angle;

	public short angleShadow;

	public bool isTarget;

	private int power;

	public ArrowTarget(sbyte type)
	{
		imgIndex = type;
		timeDelay = 0;
	}

	public override void update()
	{
		int num = v * Util.Cos(angle) >> 10;
		int num2 = -(v * Util.Sin(angle)) >> 10;
		x += (short)num;
		y += (short)num2;
		int num3 = v * Util.Cos(angleShadow) >> 10;
		int num4 = -(v * Util.Sin(angleShadow)) >> 10;
		xShadow += (short)num3;
		yShadow += (short)num4;
		if (timeDelay == 0 && Util.distance(xTo, yTo, x, y) <= v * 2)
		{
			x = (xShadow = xTo);
			y = (yShadow = yTo);
			v = 0;
			if (!isTarget)
			{
				timeDelay = (sbyte)(Res.rnd(30) + 20);
				Canvas.gameScr.arrowsDown.addElement(this);
				Canvas.gameScr.startExplosionAt(x, (short)(y + 10));
			}
			else
			{
				if (power != 0)
				{
					Canvas.gameScr.startFlyText("-" + power, 0, x, y - 15, 1, -2);
				}
				EffectManager.addHiEffect(x, y - 20, 12);
			}
			GameScr.arrowsUp.removeElement(this);
		}
		else if (Util.distance(xTo, yTo, x, y) > 1000)
		{
			GameScr.arrowsUp.removeElement(this);
		}
		if (timeDelay > 0)
		{
			timeDelay--;
			if (timeDelay == 0)
			{
				Canvas.gameScr.arrowsDown.removeElement(this);
			}
		}
	}

	public override void onArrowTouchTarget()
	{
	}

	public override void paint(MyGraphics g)
	{
		if (Res.getImgArrow(imgIndex) != null)
		{
			g.drawImage(Res.imgShadow, xShadow, yShadow, MyGraphics.TOP | MyGraphics.HCENTER);
			g.drawRegion(Res.imgArrow[imgIndex], 0, Arrow.FRAME[d] * Arrow.ARROWSIZE[1][imgIndex], Arrow.ARROWSIZE[0][imgIndex], Arrow.ARROWSIZE[1][imgIndex], Arrow.TRANSFORM[d], x, y, 3);
		}
	}

	public void set(int type, int x, int y, int power, sbyte effect, int xTo, int yTo, sbyte v, bool isTarget)
	{
		this.power = power;
		this.isTarget = isTarget;
		this.v = v;
		int dx = xTo - x;
		int num = yTo - y;
		this.x = (xShadow = (short)x);
		this.y = (short)y;
		this.xTo = (short)xTo;
		this.yTo = (short)yTo;
		yShadow = (short)(y + 30);
		d = (sbyte)Arrow.findDirIndexFromAngle(Util.angle(dx, -num));
		angle = (short)Util.angle(xTo - x, -(yTo - y));
		angleShadow = (short)Util.angle(xTo - xShadow, -(yTo - yShadow));
	}

	public override void set(int type, int x, int y, int power, sbyte effect, LiveActor owner, LiveActor target)
	{
	}

	public override void setAngle(int angle)
	{
	}
}
