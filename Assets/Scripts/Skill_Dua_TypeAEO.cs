public class Skill_Dua_TypeAEO : SkillAnimate
{
	private bool isSkill5;

	private mVector mst = new mVector();

	public Skill_Dua_TypeAEO(bool isSkill5)
		: base(-1)
	{
		this.isSkill5 = isSkill5;
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
		c.frame = 4;
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
			if (!isSkill5)
			{
				for (int i = 0; i < mst.size(); i++)
				{
					LiveActor to = (LiveActor)mst.elementAt(i);
					Canvas.gameScr.startNewMagicBeam(5, c, to, c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c.attkPower, c.attkEffect);
				}
			}
			else
			{
				for (int j = 0; j < mst.size(); j++)
				{
					LiveActor liveActor = (LiveActor)mst.elementAt(j);
					Skill_AEO_DUA_DAO_5 skill_AEO_DUA_DAO_ = new Skill_AEO_DUA_DAO_5(c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c, liveActor, 4);
					if (c.attkPower != 0 && c.attkPower != 2000000)
					{
						skill_AEO_DUA_DAO_.textAttack[0] = "-" + c.attkPower;
					}
					if (c.attkEffect != 0 && c.attkEffect < AttackResult.EFF_NAME.Length)
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
		}
		c.p1++;
	}

	public override void updateSkill(Monster c)
	{
	}
}
