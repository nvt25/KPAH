public class Skill_Bua_Type3 : SkillAnimate
{
	private int lvSkill;

	private int ID;

	private sbyte nDragon = 1;

	private int loop;

	public Skill_Bua_Type3(int id)
		: base(0)
	{
		ID = id;
	}

	public override void setLvSkill(int lv)
	{
		lvSkill = lv;
	}

	public override int getX2()
	{
		if (lvSkill < SkillAnimate.nDra.Length)
		{
			nDragon = (sbyte)SkillAnimate.nDra[lvSkill];
			return SkillAnimate.nDra[lvSkill];
		}
		return 1;
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
		if (c.p1 == 20)
		{
			loop = 0;
		}
		updateSkillBua_2_3(c, is3: true, nDragon, ID, lvSkill);
		if (c.p1 == 13)
		{
			if (c.attackTarget != null && ID == 0)
			{
				loop++;
				if (loop < nDragon)
				{
					c.p1 = 10;
				}
			}
			if (ID == 1)
			{
				Skill_Eff_end o = new Skill_Eff_end(c.attackTarget.x, c.attackTarget.y - 200, c.attackTarget);
				EffectManager.hiEffects.addElement(o);
			}
		}
		c.p1++;
	}
}
