public class Skill_Cung_Type2 : SkillAnimate
{
	public Skill_Cung_Type2()
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
			updateSkillCung_2_3(c);
			if (c.p1 == 10)
			{
				Canvas.gameScr.startNewArrow(0, c, c.attackTarget, c.x, c.y - 15, c.attkPower, c.attkEffect, 2);
			}
			c.p1++;
		}
	}
}
