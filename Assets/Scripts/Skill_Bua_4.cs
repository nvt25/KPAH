public class Skill_Bua_4 : Effect
{
	private LiveActor live;

	private bool isExpl;

	private bool isSkillBoss;

	private int count;

	public Skill_Bua_4(LiveActor live, int x, int y, bool isBoss)
	{
		base.x = x;
		base.y = y;
		this.live = live;
		isSkillBoss = isBoss;
	}

	public override void update()
	{
		if (!isExpl)
		{
			int a = Util.angle(live.x - x, -(live.y - y));
			int num = 10 * Util.Cos(a) >> 10;
			int num2 = -(10 * Util.Sin(a)) >> 10;
			x += num;
			y += num2;
			EffectManager.addLowEffect(x, y, (!isSkillBoss) ? 4 : 35);
			if (Util.distance(x, y, live.x, live.y) <= 10)
			{
				isExpl = true;
			}
		}
		else if (Canvas.gameTick % 2 == 0)
		{
			for (int i = 0; i < 5; i++)
			{
				int num3 = (sbyte)(20 - Res.rnd(40));
				int num4 = (sbyte)(10 - Res.rnd(20));
				EffectManager.addLowEffect(live.x + num3, live.y + num4, 35);
			}
			count++;
			if (count > 3)
			{
				EffectManager.lowEffects.removeElement(this);
			}
		}
	}

	public override void paint(MyGraphics g)
	{
	}
}
