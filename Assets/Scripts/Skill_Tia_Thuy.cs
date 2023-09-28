public class Skill_Tia_Thuy : Effect
{
	private LiveActor to;

	private int angle;

	private int index;

	public Skill_Tia_Thuy(LiveActor to, int xFrom, int yFrom)
	{
		this.to = to;
		x = xFrom;
		y = yFrom;
	}

	public override void update()
	{
		angle = Util.angle(to.x - x, -(to.y - y));
		int num = 10 * Util.Cos(Util.fixangle(angle)) >> 10;
		int num2 = -(10 * Util.Sin(Util.fixangle(angle))) >> 10;
		x += num;
		y += num2;
		if (Util.distance(x, y, to.x, to.y) <= 20)
		{
			EffectManager.addHiEffect(to.x, to.y - 10, 30);
			EffectManager.hiEffects.removeElement(this);
		}
	}

	public override void paint(MyGraphics g)
	{
		Res.paintImgEff(g, 19, 0, index % 3 * 14, 25, 14, x, y, 3);
		index++;
	}
}
