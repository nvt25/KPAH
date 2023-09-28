public class Skill_Bua_Type4 : SkillAnimate
{
	private mVector mst = new mVector();

	public Skill_Bua_Type4(int skillWeapon)
		: base(skillWeapon)
	{
	}

	public override void setMonster(mVector mst)
	{
		this.mst = mst;
	}

	public override void updateSkill(Char c)
	{
		base.updateSkill(c);
		if (c.state == 0)
		{
			return;
		}
		updateStateBua(c, 35, 0);
		if (c.p1 == 13)
		{
			if (mst.size() > 0)
			{
				for (int i = 0; i < mst.size(); i++)
				{
					Actor actor = (Actor)mst.elementAt(i);
					EffectManager.lowEffects.addElement(new Skill_Bua_4((LiveActor)actor, c.x, c.y, isBoss: false));
				}
			}
			else
			{
				EffectManager.lowEffects.addElement(new Skill_Bua_4(c.attackTarget, c.x, c.y, isBoss: false));
			}
		}
		c.p1++;
	}
}
