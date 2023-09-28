public class ThienThach_Skill : Effect
{
	private int xTo;

	private int yTo;

	private int v;

	private int dame;

	private byte index;

	public ThienThach_Skill(int x, int y, int dam)
	{
		xTo = x;
		yTo = y;
		base.x = x - 100;
		base.y = y - 200;
		v = 1;
		dame = dam;
	}

	public override void update()
	{
		v++;
		EffectManager.addHiEffect(x, y, 32);
		int a = Util.angle(xTo - x, -(yTo - y));
		int num = v * Util.Cos(a) >> 10;
		int num2 = -(v * Util.Sin(a)) >> 10;
		x += num;
		y += num2;
		if (Util.distance(x, y, xTo, yTo) <= v)
		{
			if (dame != 2000000)
			{
				Canvas.gameScr.startFlyText("-" + dame, 0, x, y - 15, 1, -2);
			}
			EffectManager.hiEffects.removeElement(this);
			EffBack o = new EffBack(xTo, yTo, 28, 3, 32, 31, isEffVong: false, isEffUpDown: false);
			EffectManager.lowEffects.addElement(o);
		}
	}

	public override void paint(MyGraphics g)
	{
		Res.paintImgEff(g, 31, 0, (int)index / 3 * 20, 20, 20, x, y, 3);
		index++;
		if (index >= 6)
		{
			index = 0;
		}
	}
}
