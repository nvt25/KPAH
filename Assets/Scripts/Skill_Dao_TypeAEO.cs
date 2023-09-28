public class Skill_Dao_TypeAEO : SkillAnimate
{
	private mVector mst;

	private bool isSkill5;

	private bool isMonster;

	public Skill_Dao_TypeAEO(bool isSkill5)
		: base(-1)
	{
		this.isSkill5 = isSkill5;
	}

	public override void setMonster(mVector mst)
	{
		this.mst = mst;
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
		c.frame = 4;
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
			c.frame = 4;
			c.weapon_frame = 4;
		}
		if (c.p1 == 9 && mst != null)
		{
			if (!isSkill5)
			{
				if (c.attkPower == 0)
				{
					Canvas.gameScr.startFlyText("MISS", 0, c.attackTarget.x, c.attackTarget.y - 15, 1, -2);
				}
				for (int i = 0; i < mst.size(); i++)
				{
					LiveActor liveActor = (LiveActor)mst.elementAt(i);
					Skill_AEO_DUA_DAO_5 skill_AEO_DUA_DAO_ = new Skill_AEO_DUA_DAO_5(c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c, liveActor, 3);
					if (c.attkPower != 0 && c.attkPower != 2000000)
					{
						skill_AEO_DUA_DAO_.textAttack[0] = "-" + c.attkPower;
					}
					if (c.attkEffect != 0)
					{
						skill_AEO_DUA_DAO_.textAttack[1] = AttackResult.EFF_NAME[c.attkEffect];
					}
					if (liveActor.catagory == 1)
					{
						((Monster)liveActor).isTarget = true;
					}
					EffectManager.hiEffects.addElement(skill_AEO_DUA_DAO_);
				}
			}
			else
			{
				for (int j = 0; j < mst.size(); j++)
				{
					LiveActor liveActor2 = (LiveActor)mst.elementAt(j);
					Skill_AEO_Dao_5 skill_AEO_Dao_ = new Skill_AEO_Dao_5(c.x, c.y + 30, liveActor2, 0, isEff: true);
					if (c.attkPower != 0 && c.attkPower != 2000000)
					{
						skill_AEO_Dao_.textAttack[0] = "-" + c.attkPower;
					}
					if (c.attkEffect != 0)
					{
						skill_AEO_Dao_.textAttack[1] = AttackResult.EFF_NAME[c.attkEffect];
					}
					if (liveActor2.catagory == 1)
					{
						((Monster)liveActor2).isTarget = true;
					}
					EffectManager.hiEffects.addElement(skill_AEO_Dao_);
				}
			}
		}
		c.p1++;
	}

	public override void updateSkill(Monster c)
	{
	}
}
