public class Skill_Bua_Type1 : SkillAnimate
{
	public Skill_Bua_Type1()
		: base(0)
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
		if (c.p1 == 15)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
		}
		else if (c.p1 == 12 || c.p1 == 11 || c.p1 == 13 || c.p1 == 14)
		{
			c.frame = 5;
			c.weapon_frame = 7;
		}
		else if (c.p1 == 10 || c.p1 == 9)
		{
			c.frame = 5;
			c.weapon_frame = 6;
		}
		else if (c.p1 == 8 || c.p1 == 7)
		{
			c.frame = 4;
			c.weapon_frame = 5;
		}
		else
		{
			c.frame = 4;
			c.weapon_frame = 4;
		}
		if (c.p1 == 8)
		{
			if (c.attackTarget != null)
			{
				if (c.attackTarget.catagory == 1)
				{
					if (c.attkEffect == 0)
					{
						EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 10, 11);
						((Monster)c.attackTarget).jumpVang(c);
					}
					else if (c.attkEffect == 2)
					{
						EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 10, 12);
						((Monster)c.attackTarget).doublejump();
					}
				}
				c.attackTarget.realHPSyncTime = 2;
			}
			if (c.attkEffect != 1)
			{
				EffectManager.addLowEffect(c.attackTarget.x, c.attackTarget.y - 10, 13);
			}
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
