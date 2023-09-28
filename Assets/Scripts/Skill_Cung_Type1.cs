public class Skill_Cung_Type1 : SkillAnimate
{
	public Skill_Cung_Type1()
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
		if (c.p1 == 15)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
		}
		else if (c.p1 == 12 || c.p1 == 11)
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
			if (c.p1 == 1)
			{
				EffectManager.addHiEffect(c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], 16);
			}
			c.frame = 4;
			c.weapon_frame = 4;
		}
		if (c.p1 == 5)
		{
			Canvas.gameScr.startNewArrow(0, c, c.attackTarget, c.x, c.y - 15, c.attkPower, c.attkEffect, 1);
		}
		c.p1++;
	}
}
