public class Skill_Dua_Type1 : SkillAnimate
{
	public Skill_Dua_Type1()
		: base(-1)
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
			if (c.p1 == 18)
			{
				c.state = 0;
				c.p1 = (c.p2 = (c.p3 = 0));
				c.weapon_frame = 0;
			}
			else if (c.p1 >= 6 && c.p1 < 18)
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
				Canvas.gameScr.startNewMagicBeam(0, c, c.attackTarget, c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c.attkPower, c.attkEffect);
			}
			c.p1++;
		}
	}
}
