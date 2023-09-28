public class Skill_Kiem_Type1 : SkillAnimate
{
	public Skill_Kiem_Type1()
		: base(0)
	{
	}

	public override void updateSkill(Monster c)
	{
	}

	public override void updateSkill(Char c)
	{
		if (c == null)
		{
			return;
		}
		base.updateSkill(c);
		if (c.state == 0)
		{
			return;
		}
		updateSkillKiem(c);
		if (c.p1 == 3)
		{
			if (c.attackTarget != null)
			{
				if (c.attackTarget.catagory == 1)
				{
					((Monster)c.attackTarget).jump();
				}
				c.attackTarget.realHPSyncTime = 2;
			}
			EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 10, 3);
			if (c.attkPower != 2000000)
			{
				Canvas.gameScr.startFlyText("-" + c.attkPower, 0, c.attackTarget.x, c.attackTarget.y - 15, -1, -2);
			}
		}
		c.p1++;
	}
}
