public class Skill_Kiem_Type0 : SkillAnimate
{
	public Skill_Kiem_Type0(int cooldown)
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
		if (c.p1 == 3 && c.attackTarget != null)
		{
			if (c.attackTarget.catagory == 1)
			{
				if (c.attkEffect == 0)
				{
					EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 10, 11);
					((Monster)c.attackTarget).jump();
				}
				else if (c.attkEffect == 2)
				{
					EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 10, 12);
					((Monster)c.attackTarget).doublejump();
				}
			}
			c.attackTarget.realHPSyncTime = 2;
			if (c.attkPower != 0 && c.attkPower != 2000000)
			{
				Canvas.gameScr.startFlyText("-" + c.attkPower, 0, c.attackTarget.x, c.attackTarget.y - 15, -1, -2);
			}
			if (c.attkEffect != 0 && c.attkEffect < AttackResult.EFF_NAME.Length)
			{
				Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[c.attkEffect], 0, c.attackTarget.x, c.attackTarget.y - 15, 2, -2);
			}
		}
		c.p1++;
	}
}
