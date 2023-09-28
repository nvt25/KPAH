public class Skill_Bua_TypeAEO : SkillAnimate
{
	private bool isSkill5;

	private mVector mst = new mVector();

	public Skill_Bua_TypeAEO(bool isSkill5)
		: base(0)
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
		updateStateBua(c, 4, 0);
		if (c.p1 == 13)
		{
			MyRandom myRandom = new MyRandom();
			int num = myRandom.nextInt() % 20;
			int num2 = num;
			if (c.dir == 0 || c.dir == 1)
			{
				num2 = 0;
			}
			else
			{
				num = 0;
			}
			if (c.attackTarget != null)
			{
				if (c.attackTarget.catagory == 1)
				{
					if (c.attkEffect == 0)
					{
						EffectManager.addHiEffect(c.attackTarget.x + num, c.attackTarget.y - 10 + num2, 11);
						c.attackTarget.jump();
					}
					else if (c.attkEffect == 2)
					{
						EffectManager.addHiEffect(c.attackTarget.x + num, c.attackTarget.y - 10 + num2, 12);
						c.attackTarget.doublejump();
					}
				}
				c.attackTarget.realHPSyncTime = 2;
			}
			if (!isSkill5)
			{
				for (int i = 0; i < mst.size(); i++)
				{
					LiveActor liveActor = (LiveActor)mst.elementAt(i);
					EffectManager.addLowEffect(liveActor.x - 10 + num, liveActor.y - 25 + num2, 14);
					EffectManager.addLowEffect(liveActor.x + 10 + num, liveActor.y - 25 + num2, 14);
					EffectManager.addLowEffect(liveActor.x + num, liveActor.y - 25 - 10 + num2, 14);
					if (c.attkPower != 0 && c.attkPower != 2000000)
					{
						Canvas.gameScr.startFlyText("-" + c.attkPower, 0, liveActor.x, liveActor.y - 15, -1, -2);
					}
					if (c.attkEffect != 0 && c.attkEffect < AttackResult.EFF_NAME.Length)
					{
						Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[c.attkEffect], 0, liveActor.x, liveActor.y - 15, 2, -2);
					}
				}
			}
			else
			{
				for (int j = 0; j < mst.size(); j++)
				{
					LiveActor c2 = (LiveActor)mst.elementAt(j);
					Skill_AEO_Dao_5 skill_AEO_Dao_ = new Skill_AEO_Dao_5(c.x, c.y + 37, c2, 1, isEff: true);
					if (c.attkPower != 0 && c.attkPower != 2000000)
					{
						skill_AEO_Dao_.textAttack[0] = "-" + c.attkPower;
					}
					if (c.attkEffect != 0 && c.attkEffect < AttackResult.EFF_NAME.Length)
					{
						skill_AEO_Dao_.textAttack[1] = AttackResult.EFF_NAME[c.attkEffect];
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
