public class Skill_Cung_TypeAEO : SkillAnimate
{
	private bool isAEO;

	private sbyte idSkill;

	private sbyte imgIndex;

	private mVector mst = new mVector();

	private bool isMonster;

	public Skill_Cung_TypeAEO(sbyte idSkill2, bool iss, sbyte imgIndex)
		: base(0)
	{
		isAEO = iss;
		idSkill = idSkill2;
		this.imgIndex = imgIndex;
	}

	public override void setMonster(mVector mst)
	{
		this.mst = mst;
		isMonster = true;
	}

	public override void setActorter(mVector mst)
	{
		this.mst = mst;
		isMonster = false;
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
			for (int i = 0; i < mst.size(); i++)
			{
				LiveActor to = (LiveActor)mst.elementAt(i);
				Canvas.gameScr.startNewArrow(0, c, to, c.x, c.y - 15, c.attkPower, c.attkEffect, imgIndex);
			}
			isMonster = false;
		}
		if (isAEO && c.p1 == 14)
		{
			if (mst.size() > 0)
			{
				Skill_AEO_CUNG_5 o = new Skill_AEO_CUNG_5(mst, c);
				EffectManager.hiEffects.addElement(o);
			}
			else
			{
				mVector mVector = new mVector();
				mVector.addElement(c.attackTarget);
				Skill_AEO_CUNG_5 o2 = new Skill_AEO_CUNG_5(mVector, c);
				EffectManager.hiEffects.addElement(o2);
			}
		}
		c.p1++;
	}

	public override void updateSkill(Monster c)
	{
		if (mst != null && mst.size() > 0)
		{
			for (int i = 0; i < mst.size(); i++)
			{
				LiveActor to = (LiveActor)mst.elementAt(i);
				Canvas.gameScr.startNewArrow(0, c, to, c.x, c.y - 15, 0, 0, imgIndex);
			}
			isMonster = false;
		}
		else
		{
			Canvas.gameScr.startNewArrow(0, c, c.attackTarget, c.x, c.y - 15, 0, 0, imgIndex);
		}
		c.p1++;
	}
}
