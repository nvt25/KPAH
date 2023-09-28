public class Skill_Cung_Type4 : SkillAnimate
{
	private mVector mst = new mVector();

	public Skill_Cung_Type4(int skillWeapon)
		: base(skillWeapon)
	{
	}

	public override void setMonster(mVector mst)
	{
		this.mst = mst;
	}

	public override void setActorter(mVector mst)
	{
		this.mst = mst;
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
		updateSkillCung_2_3(c);
		if (c.p1 == 10)
		{
			if (mst.size() > 0)
			{
				for (int i = 0; i < mst.size(); i++)
				{
					Actor actor = (Actor)mst.elementAt(i);
					Canvas.gameScr.startNewArrow(0, c, (LiveActor)actor, c.x, c.y - 15, c.attkPower, c.attkEffect, 1);
				}
			}
			else
			{
				Canvas.gameScr.startNewArrow(0, c, c.attackTarget, c.x, c.y - 15, c.attkPower, c.attkEffect, 1);
			}
		}
		if (c.p1 >= 13)
		{
			if (mst.size() > 0)
			{
				for (int j = 0; j < mst.size(); j++)
				{
					Actor ac = (Actor)mst.elementAt(j);
					attack(c, ac);
				}
			}
			else
			{
				attack(c, c.attackTarget);
			}
		}
		c.p1++;
	}

	private void attack(Char c, Actor ac)
	{
		int x = ac.x;
		int num = ac.y - 20;
		int num2 = Res.rnd(3) + 1;
		for (int i = 0; i < num2; i++)
		{
			int num3 = Res.rnd(50) + 50;
			int num4 = num3 * Util.Cos(i * 30) >> 10;
			int num5 = -(num3 * Util.Sin(i * 30)) >> 10;
			Canvas.gameScr.startNewArrow(0, c, (LiveActor)ac, x + num4, num + num5, c.attkPower, c.attkEffect, Res.rnd(2));
		}
	}

	public new void updateSkill(Monster c)
	{
	}
}
