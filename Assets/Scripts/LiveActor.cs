public abstract class LiveActor : Actor
{
	public int realHP;

	public int realHPSyncTime;

	public int z;

	public int dz;

	public int dvangx;

	public int dvangy;

	public int vangx;

	public int vangy;

	public short dir;

	public short accurate;

	public short dodge;

	public short critical;

	public int attack;

	public int defend;

	public int defend_magic;

	public short dy;

	public short speed;

	public int damAttack;

	public sbyte level;

	public sbyte frame;

	public sbyte he;

	public sbyte idBoss = -1;

	public static readonly sbyte HE_THUY = 0;

	public static readonly sbyte HE_MOC = 1;

	public static readonly sbyte HE_HOA = 2;

	public static readonly sbyte HE_THO = 3;

	public static readonly sbyte HE_KIM = 4;

	public mVector effSkill = new mVector();

	public bool isFreeze;

	public mVector Vec_Effect_Skill = new mVector();

	public mVector dynamicEffTop = new mVector();

	public mVector dynamicEffBottom = new mVector();

	public static MyRandom r = new MyRandom();

	public short totalTime = 36;

	public LiveActor()
	{
	}

	public override void addBuff(CharBuff b)
	{
		base.addBuff(b);
	}

	public void updateDynamicBuff()
	{
		if (dynamicEffTop != null)
		{
			for (int i = 0; i < dynamicEffTop.size(); i++)
			{
				DynamicEffect dynamicEffect = (DynamicEffect)dynamicEffTop.elementAt(i);
				if (dynamicEffect == null)
				{
					dynamicEffect.update();
					if (dynamicEffect.canDestroy())
					{
						dynamicEffTop.removeElementAt(i);
					}
				}
			}
		}
		if (dynamicEffBottom == null)
		{
			return;
		}
		for (int j = 0; j < dynamicEffBottom.size(); j++)
		{
			DynamicEffect dynamicEffect2 = (DynamicEffect)dynamicEffBottom.elementAt(j);
			if (dynamicEffect2 == null)
			{
				dynamicEffect2.update();
				if (dynamicEffect2.canDestroy())
				{
					dynamicEffBottom.removeElementAt(j);
				}
			}
		}
	}

	public override void paint(MyGraphics g)
	{
		paintEffSkill(g);
	}

	public override void update()
	{
		updateEffSkill();
		updateDataEffect();
		if (z < 0)
		{
			z += dz;
			dz++;
			if (z > 0)
			{
				z = 0;
			}
		}
		vangx += dvangx;
		vangy += dvangy;
		if (dvangx > 0)
		{
			dvangx--;
		}
		if (dvangx < 0)
		{
			dvangx++;
		}
		if (dvangy > 0)
		{
			dvangy--;
		}
		if (dvangy < 0)
		{
			dvangy++;
		}
		if (dvangx == 0 && dvangy == 0)
		{
			if (vangx > 1)
			{
				vangx >>= 1;
			}
			else
			{
				vangx = 0;
			}
			if (vangy > 1)
			{
				vangy >>= 1;
			}
			else
			{
				vangy = 0;
			}
		}
		base.update();
	}

	public int nextInt(int max)
	{
		return GameScr.abs(r.nextInt(max));
	}

	public void addDynamicEffBuffTop(DynamicEffect d, int add_remove)
	{
		for (int i = 0; i < dynamicEffTop.size(); i++)
		{
			if (((DynamicEffect)dynamicEffTop.elementAt(i)).id == d.id)
			{
				if (add_remove == 1)
				{
					((DynamicEffect)dynamicEffTop.elementAt(i)).timeExist = 0L;
				}
				return;
			}
		}
		if (add_remove == 0)
		{
			dynamicEffTop.addElement(d);
		}
	}

	public void addDynamicEffBuffBottom(DynamicEffect d, int add_remove)
	{
		for (int i = 0; i < dynamicEffBottom.size(); i++)
		{
			if (((DynamicEffect)dynamicEffBottom.elementAt(i)).id == d.id)
			{
				if (add_remove == 1)
				{
					((DynamicEffect)dynamicEffBottom.elementAt(i)).timeExist = 0L;
				}
				return;
			}
		}
		if (add_remove == 0)
		{
			dynamicEffBottom.addElement(d);
		}
	}

	public virtual void setRealHP(int realHP)
	{
		this.realHP = realHP;
		realHPSyncTime = 20;
	}

	public virtual void updateBuff()
	{
	}

	public bool attackMiss(LiveActor actor)
	{
		int num = nextInt(accurate + 10);
		int num2 = nextInt(5000);
		if (num < accurate)
		{
			if (num2 < actor.dodge)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public bool isCritical()
	{
		return nextInt(100) < critical;
	}

	public virtual int attackDam(LiveActor actor)
	{
		int num = attack - actor.defend;
		if (num < 5)
		{
			num = 5;
		}
		num = num * (90 + nextInt(20)) / 100;
		if ((he + 2) % 5 == actor.he)
		{
			num = num * 12 / 10;
		}
		if (num <= 0)
		{
			num = 1;
		}
		return num;
	}

	public virtual void startDeadFly(int dx, int dy)
	{
	}

	public void paintTopDataEff(MyGraphics g)
	{
	}

	public void paintBottomDataEff(MyGraphics g)
	{
	}

	public virtual void isPoinson()
	{
		if (die)
		{
			hp = 0;
			die = false;
			tDelay = 0;
			timeOutPoinson = 0L;
			totalTime = 36;
			poinson = 0;
			int num = 0;
			int num2 = 0;
			num = (x - 5) * 2;
			num2 = (y - 5) * 2;
			while (num > 10 || num2 > 10 || num < -10 || num2 < -10)
			{
				num >>= 1;
				num2 >>= 1;
			}
			startDeadFly(num, num2);
		}
		else if ((mSystem.getCurrentTimeMillis() - timeOutPoinson >= tDelay * 1000) & (tDelay > 0))
		{
			hp -= poinson;
			totalTime -= tDelay;
			timeOutPoinson = mSystem.getCurrentTimeMillis();
			if (totalTime == 0)
			{
				tDelay = 0;
				totalTime = 36;
			}
			if (hp <= 0)
			{
				hp = 1;
				poinson = 0;
				tDelay = 0;
				totalTime = 36;
			}
		}
	}

	public virtual void updateEffSkill()
	{
		if (effSkill.size() > 0)
		{
			for (int i = 0; i < effSkill.size(); i++)
			{
				Effect effect = (Effect)effSkill.elementAt(i);
				effect.update();
			}
		}
	}

	public void paintEffSkill(MyGraphics g)
	{
		if (effSkill.size() > 0)
		{
			for (int i = 0; i < effSkill.size(); i++)
			{
				Effect effect = (Effect)effSkill.elementAt(i);
				effect.paint(g);
			}
		}
	}

	public virtual void jump()
	{
		z = -3;
		dz = -5;
	}

	public virtual void jumpVang(Actor causeBy)
	{
		z = -3;
		dz = -3;
		dvangx = (short)((x - causeBy.x) * 2);
		dvangy = (short)((y - causeBy.y) * 2);
		while (dvangx > 4 || dvangy > 4 || dvangx < -4 || dvangy < -4)
		{
			dvangx >>= 1;
			dvangy >>= 1;
		}
	}

	public virtual bool FuntioncanMove()
	{
		if (dynamicEffTop != null)
		{
			for (int i = 0; i < dynamicEffTop.size(); i++)
			{
				DynamicEffect dynamicEffect = (DynamicEffect)dynamicEffTop.elementAt(i);
				if (dynamicEffect.stop == 1)
				{
					return false;
				}
			}
		}
		if (dynamicEffBottom != null)
		{
			for (int j = 0; j < dynamicEffBottom.size(); j++)
			{
				DynamicEffect dynamicEffect2 = (DynamicEffect)dynamicEffBottom.elementAt(j);
				if (dynamicEffect2.stop == 1)
				{
					return false;
				}
			}
		}
		return !isFreeze && !beStune;
	}

	public void updateDataEffect()
	{
		int num = Vec_Effect_Skill.size();
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
			if (dataSkillEff != null)
			{
				dataSkillEff.update();
				if (dataSkillEff.wantDetroy)
				{
					Vec_Effect_Skill.removeElement(dataSkillEff);
				}
			}
		}
	}

	public void paintDataEff_Top(MyGraphics g, int x, int y, bool isHorse)
	{
		int num = Vec_Effect_Skill.size();
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
			if (dataSkillEff != null)
			{
				sbyte b = 0;
				if (isHorse)
				{
					b = dataSkillEff.dyhorse;
				}
				dataSkillEff.paintTop(g, x, y + b);
			}
		}
	}

	public void paintDataEff_Bot(MyGraphics g, int x, int y, bool isHorse)
	{
		int num = Vec_Effect_Skill.size();
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
			if (dataSkillEff != null)
			{
				sbyte b = 0;
				if (isHorse)
				{
					b = dataSkillEff.dyhorse;
				}
				dataSkillEff.paintBottom(g, x, y + b);
			}
		}
	}

	public override void addEffectSkillTime(int id, int x, int y, long timelive, bool canmove, bool canpaint, bool canfight, int loop, sbyte WaitLoop, sbyte dyhorse)
	{
		int num = Vec_Effect_Skill.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
				if (dataSkillEff != null && dataSkillEff.idEff == id)
				{
					dataSkillEff.timelive = timelive;
					return;
				}
			}
		}
		DataSkillEff dataSkillEff2 = new DataSkillEff(id, x, y, timelive, canmove, canpaint, canfight, loop, dyhorse);
		dataSkillEff2.setWaitLoop(WaitLoop);
		Vec_Effect_Skill.addElement(dataSkillEff2);
	}

	public void removeDataSkillEff(int id)
	{
		for (int i = 0; i < Vec_Effect_Skill.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.idEff == id)
			{
				Vec_Effect_Skill.removeElement(dataSkillEff);
			}
		}
	}

	public bool can_Paint()
	{
		for (int i = 0; i < Vec_Effect_Skill.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.canPaintActor)
			{
				return false;
			}
		}
		return true;
	}

	public override void addEffbuff(int id, int x, int y, long timelive)
	{
		int num = Vec_Effect_Skill.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
				if (dataSkillEff != null && dataSkillEff.idEff == id)
				{
					dataSkillEff.timelive = timelive;
					return;
				}
			}
		}
		DataSkillEff o = new DataSkillEff(id, x, y, timelive);
		Vec_Effect_Skill.addElement(o);
	}

	public override void setHP(int hp)
	{
		base.hp = hp;
	}

	public bool mcanmove()
	{
		for (int i = 0; i < Vec_Effect_Skill.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)Vec_Effect_Skill.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.canActorMove)
			{
				return false;
			}
		}
		return true;
	}

	public void doublejump()
	{
		z = -4;
		dz = -4;
	}

	public void smalljump()
	{
		z = -2;
		dz = -2;
		if (hp <= 0)
		{
			dead();
		}
	}

	public virtual sbyte getHorse()
	{
		return 0;
	}

	public override sbyte getState()
	{
		return state;
	}

	public override short getSpeed()
	{
		return speed;
	}

	public override short getDir()
	{
		return dir;
	}
}
