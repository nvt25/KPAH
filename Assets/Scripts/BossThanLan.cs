public class BossThanLan : Monster
{
	private mVector exp = new mVector();

	private mVector listAttack = new mVector();

	private int AEO = -1;

	private int dis;

	private int indexDapLeft = 2;

	private int indexDapRight = 2;

	private int countLeft;

	private int countRight;

	private sbyte indexDau = 4;

	private sbyte dirdau = 1;

	private sbyte count;

	private byte totalExp;

	private int a = -1;

	private long dlTime = 1L;

	private byte skillID;

	private long timeGetImage = mSystem.getCurrentTimeMillis();

	public override void paint(MyGraphics g)
	{
		monster_type = 39;
		if (totalExp < 15)
		{
			if (Res.monsterTemplates[monster_type].imageObj != null)
			{
				if (Canvas.gameTick % 2 == 1)
				{
					count = (sbyte)(count + dirdau);
					if (Util.abs(count) > 1)
					{
						dirdau = (sbyte)(dirdau * -1);
					}
				}
				if (dynamicEffBottom != null)
				{
					for (int i = 0; i < dynamicEffBottom.size(); i++)
					{
						((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, y);
					}
				}
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, 0, 0, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, 0, 2, -1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y + count, indexDau, 0, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y + count, indexDau, 2, -1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, 1, 0, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, 1, 0, -1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, indexDapLeft, 0, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, indexDapRight, 2, -1, 1);
				if (dynamicEffTop != null)
				{
					for (int j = 0; j < dynamicEffTop.size(); j++)
					{
						((DynamicEffect)dynamicEffTop.elementAt(j)).paint(g, x, y);
					}
				}
			}
			else if (mSystem.getCurrentTimeMillis() > timeGetImage)
			{
				timeGetImage = mSystem.getCurrentTimeMillis() + 10000;
				Res.monsterTemplates[monster_type].isLoad = false;
				Res.monsterTemplates[monster_type].loadImage();
			}
		}
		paintExp(g);
	}

	public void createExplode1()
	{
	}

	public override void jump()
	{
		base.jump();
	}

	public override void jumpVang(Actor causeBy)
	{
		base.jumpVang(causeBy);
	}

	private void paintExp(MyGraphics g)
	{
		int num = exp.size();
		for (int i = 0; i < num; i++)
		{
			((Exp)exp.elementAt(i))?.paint(g);
		}
	}

	private void updateExp()
	{
		for (int i = 0; i < this.exp.size(); i++)
		{
			Exp exp = (Exp)this.exp.elementAt(i);
			if (exp == null)
			{
				continue;
			}
			exp.update();
			if (exp.destroy)
			{
				this.exp.removeElement(exp);
				if (this.exp.size() == 0)
				{
					wantDestroy = true;
				}
			}
		}
	}

	private void createExp()
	{
		if (totalExp < 15)
		{
			totalExp++;
			if (totalExp == 15)
			{
				createExplode1();
			}
			MyRandom myRandom = new MyRandom();
			exp.addElement(new Explode(x - 12 + GameScr.abs(myRandom.nextInt() % 25), y - 30 + GameScr.abs(myRandom.nextInt() % 35), 0));
		}
	}

	public override void startDeadFly(int dx, int dy)
	{
		state = 5;
	}

	public override void paintCorner(MyGraphics g, int xCorner, int yCorner)
	{
		if (maxhp != 0 && Res.monsterTemplates[monster_type].imageObj != null)
		{
			Res.monsterTemplates[monster_type].imageObj.paint(g, xCorner, yCorner, 4, 0, 1, 1);
		}
	}

	public override void update()
	{
		updateDynamicBuff();
		monster_type = 39;
		updateExp();
		if (dlTime != 0L)
		{
			z += a;
			a++;
			if (a > 1)
			{
				dlTime = 0L;
				a = -1;
			}
		}
		else if (Canvas.gameTick % 10 == 0)
		{
			dlTime = 1L;
		}
		switch (state)
		{
		case 0:
			indexDau = 4;
			frame = 0;
			break;
		case 3:
			if (skillID == 1)
			{
				indexDau = 4;
			}
			else
			{
				indexDau = 5;
			}
			p1++;
			if (p1 > 6)
			{
				if (p1 > 15)
				{
					p1 = 0;
					state = 2;
				}
			}
			else if (p1 == 2 && currentSkillAnimate != null)
			{
				currentSkillAnimate.updateSkill(this);
			}
			break;
		case 5:
			indexDau = 4;
			frame = 2;
			p1++;
			x += p2;
			y += p3;
			p2 >>= 1;
			p3 >>= 1;
			createExp();
			break;
		case 2:
			indexDau = 4;
			p1++;
			if (p1 > 6)
			{
				p1 = 0;
			}
			frame = 0;
			break;
		}
		if (AEO != -1)
		{
			AEO++;
			if (AEO >= 8 || AEO % 2 == 0)
			{
			}
			if (AEO >= 8)
			{
				AEO = -1;
			}
		}
		if (countRight > 0)
		{
			countRight--;
			if (countRight == 0)
			{
				indexDapRight = 2;
				setFire(-1);
			}
		}
		if (countLeft > 0)
		{
			countLeft--;
			if (countLeft == 0)
			{
				indexDapLeft = 2;
				setFire(1);
			}
		}
	}

	private void setFire(int i)
	{
		for (int j = 0; j < listAttack.size(); j++)
		{
			LiveActor liveActor = (LiveActor)listAttack.elementAt(j);
			Skill_AEO_Dao_5 skill_AEO_Dao_ = new Skill_AEO_Dao_5(x + i * 40, y + 30, liveActor, 1, isEff: true);
			if (liveActor.damAttack != 0)
			{
				skill_AEO_Dao_.textAttack[0] = "-" + liveActor.damAttack;
			}
			EffectManager.addHiEffect(x + i * 50, y - 30, 14);
			EffectManager.hiEffects.addElement(skill_AEO_Dao_);
		}
	}

	public void startAttack(mVector list, byte skillID)
	{
		listAttack.removeAllElements();
		state = 3;
		p1 = (p2 = (p3 = 0));
		AEO = 0;
		int num = Res.rnd(2);
		this.skillID = (skillID = 0);
		if (skillID == 1)
		{
			if (num == 0 && indexDapLeft != 3)
			{
				indexDapLeft = 3;
				countLeft = 10;
				listAttack = list;
			}
			else
			{
				indexDapRight = 3;
				countRight = 10;
				listAttack = list;
			}
		}
		else
		{
			frame = 1;
			for (int i = 0; i < list.size(); i++)
			{
				LiveActor liveActor = (LiveActor)list.elementAt(i);
				Skill_Da_Roi o = new Skill_Da_Roi(liveActor.x, liveActor.y, x, y, liveActor.damAttack);
				EffectManager.hiEffects.addElement(o);
			}
		}
	}

	public override void setInfo(MonsterInfo monsterInfo)
	{
		Res.monsterTemplates[monster_type].w = 50;
		timeGetImage = mSystem.getCurrentTimeMillis() + 10000;
		height = 100;
	}
}
