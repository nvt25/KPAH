public class Skill_Cung_Type0 : SkillAnimate
{
	public Skill_Cung_Type0()
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
		if (c.state != 0)
		{
			if (c.p1 == 8)
			{
				c.state = 0;
				c.p1 = (c.p2 = (c.p3 = 0));
				c.weapon_frame = 0;
			}
			else if (c.p1 == 7 || c.p1 == 6)
			{
				c.frame = 5;
				c.weapon_frame = 7;
			}
			else if (c.p1 == 5 || c.p1 == 4)
			{
				c.frame = 5;
				c.weapon_frame = 6;
			}
			else if (c.p1 == 3 || c.p1 == 2)
			{
				c.frame = 4;
				c.weapon_frame = 5;
			}
			else
			{
				c.frame = 4;
				c.weapon_frame = 4;
			}
			if (c.p1 == 3)
			{
				Canvas.gameScr.startNewArrow(0, c, c.attackTarget, c.x, c.y - 15, c.attkPower, c.attkEffect, 0);
			}
			c.p1++;
		}
	}
}
