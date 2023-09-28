public class Skill_Cung_Type3 : SkillAnimate
{
	private int lvSkill;

	private int ID;

	private sbyte nDragon = 1;

	private int loop;

	public Skill_Cung_Type3(int id)
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
		if (c.p1 == 15)
		{
			loop = 0;
		}
		updateSkillCung_2_3(c);
		if (c.p1 == 10)
		{
			if (ID == 0)
			{
				Canvas.gameScr.startNewArrow(0, c, c.attackTarget, c.x, c.y - 15, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, 2);
				loop++;
				if (loop < nDragon)
				{
					c.p1 = 7;
				}
			}
			else
			{
				int num = 0;
				int num2 = 0;
				if (c.dir == 3)
				{
					num2 = -22;
					num = 10;
				}
				else
				{
					num2 = -22;
					num = -10;
				}
				Canvas.gameScr.startWeaponsLazer(c, c.attackTarget, num, num2, c.dir, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), 1);
				EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 15, 32);
				EffectManager.addHiEffect(c.attackTarget.x, c.attackTarget.y - 10, 9);
			}
		}
		c.p1++;
	}

	public override void updateSkill(Monster c)
	{
	}
}
