public class Skill_Dao_Type4 : SkillAnimate
{
	private mVector mst = new mVector();

	public Skill_Dao_Type4()
		: base(-1)
	{
	}

	public override void setMonster(mVector mst)
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
		if (c.p1 == 16)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
		}
		else if (c.p1 >= 14 && c.p1 < 16)
		{
			c.frame = 5;
			c.weapon_frame = 7;
		}
		else if (c.p1 == 13 || c.p1 == 12)
		{
			c.frame = 5;
			c.weapon_frame = 6;
		}
		else if (c.p1 == 11 || c.p1 == 10)
		{
			c.frame = 4;
			c.weapon_frame = 5;
		}
		else
		{
			if (c.p1 % 2 == 0)
			{
			}
			c.frame = 4;
			c.weapon_frame = 4;
		}
		if (c.p1 == 9)
		{
			if (mst.size() > 0)
			{
				for (int i = 0; i < mst.size(); i++)
				{
					Actor actor = (Actor)mst.elementAt(i);
					ThienThach_Skill o = new ThienThach_Skill(actor.x, actor.y, c.attkPower);
					EffectManager.hiEffects.addElement(o);
				}
			}
			else
			{
				ThienThach_Skill o2 = new ThienThach_Skill(c.attackTarget.x, c.attackTarget.y, c.attkPower);
				EffectManager.hiEffects.addElement(o2);
			}
		}
		c.p1++;
	}

	public override void updateSkill(Monster c)
	{
	}
}
