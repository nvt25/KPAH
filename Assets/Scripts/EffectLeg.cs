public class EffectLeg : EffBack
{
	public EffectLeg(int x, int y, int type, int limit, int w, int h, bool isEffVong, bool isEffUpDown)
		: base(x, y, type, limit, w, h, isEffVong, isEffUpDown)
	{
		base.x = x;
		base.y = y;
		base.type = type;
	}

	public override void paint(MyGraphics g)
	{
		if (Canvas.gameTick % 2 == 0)
		{
			g.drawRegion(Res.getWayPoint(), 0, type * 24, 39, 24, 0, x, y, 3);
		}
	}
}
