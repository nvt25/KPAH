public abstract class SkillAnimate
{
	private int x;

	private int y;

	private int attackPower;

	public int dam;

	public static int[] nDra = new int[11]
	{
		3,
		3,
		3,
		3,
		4,
		4,
		5,
		6,
		7,
		8,
		8
	};

	public static sbyte[] splashKiemX = new sbyte[4]
	{
		-2,
		2,
		20,
		-20
	};

	public static sbyte[] splashKiemY = new sbyte[4]
	{
		-30,
		-30,
		-30,
		-30
	};

	public static sbyte[] splashDuaX = new sbyte[4]
	{
		-2,
		2,
		-8,
		8
	};

	public static sbyte[] splashDuaY = new sbyte[4]
	{
		-10,
		-30,
		-10,
		-10
	};

	public static sbyte[] splashCungX = new sbyte[4]
	{
		-2,
		2,
		-14,
		14
	};

	public static sbyte[] splashCungY = new sbyte[4]
	{
		-2,
		-28,
		-10,
		-10
	};

	public static sbyte[] splashBuaX = new sbyte[4]
	{
		-10,
		10,
		10,
		-10
	};

	public static sbyte[] splashBuaY = new sbyte[4]
	{
		-30,
		-26,
		-30,
		-30
	};

	protected static readonly sbyte[] rotateSplashDaoX = new sbyte[8]
	{
		-30,
		-15,
		0,
		15,
		30,
		15,
		0,
		-15
	};

	protected static readonly sbyte[] rotateSplashDaoY = new sbyte[8]
	{
		0,
		13,
		20,
		13,
		0,
		-13,
		-20,
		-13
	};

	public SkillAnimate(int skillWeapon)
	{
	}

	public virtual void updateSkill(Char c)
	{
		if (c.attackTarget == null)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = -1;
		}
		c.frame = 4;
	}

	public virtual void updateSkill(Monster c)
	{
	}

	public virtual void setMonster(mVector mst)
	{
	}

	public virtual void setActorter(mVector mst)
	{
	}

	public virtual int getX2()
	{
		return 1;
	}

	public virtual void setLvSkill(int lv)
	{
	}

	public void updateStateBua(Char c, int idSkill, int ID)
	{
		if (c.p1 == 20)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
			return;
		}
		if (c.p1 == 17 || c.p1 == 16 || c.p1 == 18 || c.p1 == 19)
		{
			c.frame = 5;
			c.weapon_frame = 7;
			return;
		}
		if (c.p1 == 15 || c.p1 == 14)
		{
			c.frame = 5;
			c.weapon_frame = 6;
			return;
		}
		if (c.p1 == 13 || c.p1 == 12)
		{
			c.frame = 4;
			c.weapon_frame = 5;
			return;
		}
		c.frame = 4;
		c.weapon_frame = 4;
		if (c.p1 < 6)
		{
			EffectManager.addLowEffect(c.x - (20 - c.p1), c.y - 4, 4);
			EffectManager.addLowEffect(c.x + (20 - c.p1), c.y - 4, 4);
			EffectManager.addLowEffect(c.x, c.y - 4 + (20 - c.p1), 4);
			if (ID == 1)
			{
				Canvas.gameScr.timerung = 20;
				EffectManager.addLowEffect(c.attackTarget.x - (20 - c.p1), c.attackTarget.y - 4, 4);
				EffectManager.addLowEffect(c.attackTarget.x + (20 - c.p1), c.attackTarget.y - 4, 4);
				EffectManager.addLowEffect(c.attackTarget.x, c.attackTarget.y - 4 - (20 - c.p1), 4);
				EffectManager.addLowEffect(c.attackTarget.x, c.attackTarget.y - 4 + (20 - c.p1), 4);
			}
		}
		if (c.p1 % 3 == 0)
		{
			EffectManager.addHiEffect(c.x + splashBuaX[c.dir], c.y + splashBuaY[c.dir], 11);
		}
	}

	public void updateSkillBua_2_3(Char c, bool is3, int nDragon, int ID, int lvSkill)
	{
		updateStateBua(c, 4, ID);
		if (c.p1 != 13)
		{
			return;
		}
		MyRandom myRandom = new MyRandom();
		int num = 0;
		int num2 = 0;
		if (is3)
		{
			num = myRandom.nextInt() % 20;
			num2 = num;
		}
		if ((c.dir == 0 || c.dir == 1) && is3)
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
					((Monster)c.attackTarget).jump();
				}
				else if (c.attkEffect == 2)
				{
					EffectManager.addHiEffect(c.attackTarget.x + num, c.attackTarget.y - 10 + num2, 12);
					((Monster)c.attackTarget).doublejump();
				}
			}
			c.attackTarget.realHPSyncTime = 2;
		}
		if (ID == 0)
		{
			EffectManager.addLowEffect(c.attackTarget.x - 10 + num, c.attackTarget.y - 25 + num2, 14);
			EffectManager.addLowEffect(c.attackTarget.x + 10 + num, c.attackTarget.y - 25 + num2, 14);
			EffectManager.addLowEffect(c.attackTarget.x + num, c.attackTarget.y - 25 - 10 + num2, 14);
		}
		if (c.attkPower != 0 && c.attkPower != 2000000)
		{
			Canvas.gameScr.startFlyText("-" + c.attkPower / nDragon, 0, c.attackTarget.x, c.attackTarget.y - 15, -1, -2);
		}
		if (c.attkEffect != 0 && c.attkEffect < AttackResult.EFF_NAME.Length)
		{
			Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[c.attkEffect], 0, c.attackTarget.x, c.attackTarget.y - 15, 2, -2);
		}
	}

	public void updateSkillCung_2_3(Char c)
	{
		if (c.p1 == 15)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
			return;
		}
		if (c.p1 == 14 || c.p1 == 13)
		{
			c.frame = 5;
			c.weapon_frame = 7;
			return;
		}
		if (c.p1 == 12 || c.p1 == 11)
		{
			c.frame = 5;
			c.weapon_frame = 6;
			return;
		}
		if (c.p1 == 10 || c.p1 == 9)
		{
			c.frame = 4;
			c.weapon_frame = 5;
			return;
		}
		if (c.p1 % 5 == 0)
		{
			EffectManager.addHiEffect(c.x + splashCungX[c.dir], c.y + splashCungY[c.dir], 16);
		}
		if (c.p1 % 7 == 0)
		{
			EffectManager.addLowEffect(c.x + splashCungX[c.dir] + 30 - c.p1, c.y + splashCungY[c.dir], 17);
			EffectManager.addLowEffect(c.x + splashCungX[c.dir] - 30 + c.p1, c.y + splashCungY[c.dir], 17);
			EffectManager.addLowEffect(c.x + splashCungX[c.dir], c.y + splashCungY[c.dir] + 30 - c.p1, 17);
			EffectManager.addLowEffect(c.x + splashCungX[c.dir], c.y + splashCungY[c.dir] - 30 + c.p1, 17);
		}
		c.frame = 4;
		c.weapon_frame = 4;
	}

	public void updateSkillDao(Char c)
	{
		if (c.p1 == 16)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
			return;
		}
		if (c.p1 >= 14 && c.p1 < 16)
		{
			c.frame = 5;
			c.weapon_frame = 7;
			return;
		}
		if (c.p1 == 13 || c.p1 == 12)
		{
			c.frame = 5;
			c.weapon_frame = 6;
			return;
		}
		if (c.p1 == 11 || c.p1 == 10)
		{
			c.frame = 4;
			c.weapon_frame = 5;
			return;
		}
		if (c.p1 < 4)
		{
			EffectManager.addHiEffect(c.x + rotateSplashDaoX[c.p1], c.y - 10 + rotateSplashDaoY[c.p1], 15);
		}
		else if (c.p1 < 8)
		{
			EffectManager.addLowEffect(c.x + rotateSplashDaoX[c.p1], c.y - 10 + rotateSplashDaoY[c.p1], 15);
		}
		c.frame = 4;
		c.weapon_frame = 4;
	}

	public void updateSkillDua(Char c)
	{
		if (c.p1 == 8)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
		}
		else if (c.p1 >= 6 && c.p1 < 8)
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
	}

	public void updateSkillKiem(Char c)
	{
		if (c.p1 == 8)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
		}
		else if (c.p1 == 7 || c.p1 == 6)
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
	}
}
