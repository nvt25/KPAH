public class Skill_Bua_Type2 : SkillAnimate
{
	public Skill_Bua_Type2()
		: base(0)
	{
	}

	public override void updateSkill(Char c)
	{
		if (c != null)
		{
			base.updateSkill(c);
			if (c.state != 0)
			{
				updateSkillBua_2_3(c, is3: false, 1, 0, 0);
				c.p1++;
			}
		}
	}
}
