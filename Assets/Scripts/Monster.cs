using System;

public class Monster : LiveActor
{
	public const sbyte STAND = 0;

	public const sbyte DEAD = 1;

	public const sbyte WALK = 2;

	public const sbyte ATTACK = 3;

	public const sbyte INJURE = 4;

	public const sbyte DEADFLY = 5;

	public const sbyte MOVE_TO_TARGET = 6;

	public const sbyte GO_TO_XYFIRST = 7;

	public const sbyte WAIT = 8;

	public const sbyte TYPE4 = 0;

	public const sbyte TYPE2 = 1;

	public const sbyte TYPE1 = 2;

	public const sbyte TYPE3 = 3;

	public const sbyte TYPE0 = 4;

	public bool isMineralC;

	public LiveActor target;

	public static sbyte[][][] REAL_FRAME = new sbyte[5][][]
	{
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				4,
				5,
				6,
				7
			},
			new sbyte[4]
			{
				8,
				9,
				10,
				11
			},
			new sbyte[4]
			{
				12,
				13,
				14,
				15
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				4,
				5,
				6,
				7
			},
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				4,
				5,
				6,
				7
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				4,
				5,
				6,
				7
			},
			new sbyte[4]
			{
				0,
				1,
				2,
				3
			},
			new sbyte[4]
			{
				4,
				5,
				6,
				7
			}
		},
		new sbyte[4][]
		{
			new sbyte[4],
			new sbyte[4],
			new sbyte[4],
			new sbyte[4]
		}
	};

	public SkillAnimate currentSkillAnimate;

	public LiveActor attackTarget;

	public int idChar = -1;

	public short xTo;

	public short yTo;

	public short p1;

	public short p2;

	public short p3;

	public short monster_type;

	public long timeCreate;

	public bool isTarget;

	public bool isDied;

	public int xadd;

	public int yadd;

	public sbyte[] nh = new sbyte[5]
	{
		1,
		4,
		0,
		2,
		3
	};

	public bool getMonsterTemplate;

	public long timeBeginDie;

	public long timeRevive;

	public int timeWait;

	public int timeLimit;

	public short lastDir = -100;

	public int lastTimeStop;

	public sbyte vx;

	public sbyte vy;

	private int a;

	private int b;

	private bool isTargetPlayer = true;

	public short range = 60;

	public bool isSetInfo;

	public long timeGetInfo = mSystem.getCurrentTimeMillis();

	public int rangestop = 12;

	public int targethplost;

	public int eff;

	public Monster()
	{
		isDied = false;
		dir = (byte)LiveActor.r.nextInt(4);
		timeLimit = Res.random(10, 20);
		state = 0;
		timeWait = 0;
		p1 = (p2 = (p3 = 0));
	}

	public override string getDisplayName()
	{
		if (Res.monsterTemplates == null)
		{
			return string.Empty;
		}
		return (Res.monsterTemplates[monster_type] != null) ? Res.monsterTemplates[monster_type].name : string.Empty;
	}

	public override void setType(short type)
	{
		monster_type = type;
		if (Res.monsterTemplates != null && Res.monsterTemplates[type] == null)
		{
			Res.monsterTemplates[type] = new MonsterTemplate();
			GameService.gI().sendGetMonsterTEmplate(0, monster_type);
		}
		timeCreate = mSystem.currentTimeMillis() + 10000;
	}

	public void setRemoveTarget()
	{
		target = null;
		if (state != 5)
		{
			state = 7;
		}
	}

	public void setTarget(LiveActor tg)
	{
		target = tg;
		state = 6;
	}

	public override void dead()
	{
	}

	public override bool isPaint()
	{
		if (x < GameScr.cmx)
		{
			return false;
		}
		if (x > GameScr.cmx + Canvas.w)
		{
			return false;
		}
		if (y < GameScr.cmy)
		{
			return false;
		}
		if (y > GameScr.cmy + Canvas.h + 30)
		{
			return false;
		}
		return true;
	}

	public override void paint(MyGraphics g)
	{
		if (!isPaint() || state == 8 || hp <= 0)
		{
			return;
		}
		paintDataEff_Top(g, x, y, isHorse: false);
		if (!isFreeze)
		{
			if (z != 0)
			{
				frame = 3;
			}
			if (Res.monsterTemplates[monster_type] != null)
			{
				int f = REAL_FRAME[Res.monsterTemplates[monster_type].moveType][dir][frame];
				int num = 0;
				int num2 = 0;
				if (Res.monsterTemplates[monster_type].image != null)
				{
					num = Res.monsterTemplates[monster_type].xadd;
					num2 = Res.monsterTemplates[monster_type].yadd;
				}
				if (dynamicEffBottom != null)
				{
					for (int i = 0; i < dynamicEffBottom.size(); i++)
					{
						((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, y);
					}
				}
				g.drawImage(Res.imgShadow, x + num, y + num2, 3);
				Res.monsterTemplates[monster_type].paint(g, x + vangx, y + vangy + dy + z, 0, 0, f);
			}
			for (int j = 0; j < buff.size(); j++)
			{
				((CharBuff)buff.elementAt(j)).paint(g);
			}
			if (dynamicEffTop != null)
			{
				for (int k = 0; k < dynamicEffTop.size(); k++)
				{
					((DynamicEffect)dynamicEffTop.elementAt(k)).paint(g, x, y);
				}
			}
		}
		paintDataEff_Bot(g, x, y, isHorse: false);
		base.paint(g);
	}

	public override void paintActive(MyGraphics g, int x, int y)
	{
	}

	public override void paintCorner(MyGraphics g, int xCorner, int yCorner)
	{
		if (z != 0)
		{
			frame = 3;
		}
		try
		{
			int num = REAL_FRAME[Res.monsterTemplates[monster_type].moveType][0][frame];
			g.drawRegion(Res.monsterTemplates[monster_type].image, 0, num * Res.monsterTemplates[monster_type].h, Res.monsterTemplates[monster_type].w, Res.monsterTemplates[monster_type].h, 0, xCorner - Res.monsterTemplates[monster_type].xCenter, yCorner - 20, 0);
			g.drawRegion(Res.imgNguHanh, nh[he] * 16, 0, 16, 16, 0, xCorner - 15, yCorner + 3, MyGraphics.TOP | MyGraphics.LEFT);
		}
		catch (Exception)
		{
		}
	}

	public override void createBuff(int typeBuffEff, int timeLive)
	{
		buff.addElement(new CharBuff(x, y, typeBuffEff));
	}

	public override void updateBuff()
	{
		for (int i = 0; i < buff.size(); i++)
		{
			CharBuff charBuff = (CharBuff)buff.elementAt(i);
			charBuff.update();
			if (charBuff.wantDetroy)
			{
				buff.removeElementAt(i);
			}
			else
			{
				charBuff.setXY(x, (!charBuff.isCenter()) ? y : (y - 12));
			}
		}
	}

	public override void startDeadFly(int dx, int dy)
	{
		state = 5;
		p1 = 0;
		p2 = (short)dx;
		p3 = (short)dy;
		if (isDied)
		{
			Canvas.gameScr.startExplosionAt(x, y);
			wantDestroy = true;
		}
	}

	public override void update()
	{
		if (Res.monsterTemplates[monster_type].moveType == 4)
		{
			p1 = (p2 = (p3 = 0));
			state = 0;
			return;
		}
		updateDataEffect();
		speed = Res.monsterTemplates[monster_type].speed;
		if ((wantDestroy || hp <= 0) && timeLive != -1 && state != 8)
		{
			state = 8;
		}
		if (!isSetInfo && mSystem.getCurrentTimeMillis() - timeGetInfo > 15000)
		{
			timeGetInfo = mSystem.getCurrentTimeMillis();
			Canvas.gameScr.gameService.requestMonsterInfo(ID);
		}
		if (Res.monsterTemplates != null)
		{
			if (Res.monsterTemplates[monster_type] == null)
			{
				if (!getMonsterTemplate && mSystem.currentTimeMillis() > timeCreate)
				{
					getMonsterTemplate = false;
					GameService.gI().sendGetMonsterTEmplate(0, monster_type);
					timeCreate = mSystem.currentTimeMillis() + 10000;
				}
			}
			else if (!getMonsterTemplate)
			{
				setType(monster_type);
				getMonsterTemplate = true;
				speed = Res.monsterTemplates[monster_type].speed;
				height = Res.monsterTemplates[monster_type].height;
				if (Res.monsterTemplates[monster_type].image == null)
				{
					Res.monsterTemplates[monster_type].loadImage();
				}
			}
		}
		if (beStune && mSystem.getCurrentTimeMillis() > timeBeStune)
		{
			beStune = false;
		}
		updateDynamicBuff();
		updateBuff();
		base.update();
		if (realHPSyncTime > 0)
		{
			realHPSyncTime--;
			if (realHPSyncTime == 0)
			{
				if (realHP < 0)
				{
					realHP = 0;
				}
				if (hp > realHP || realHP == 0)
				{
					hp = realHP;
				}
				if (hp == 0)
				{
					state = 4;
				}
			}
		}
		isPoinson();
		switch (state)
		{
		case 4:
			frame = 3;
			p1++;
			if (p1 == 5)
			{
				Canvas.gameScr.startExplosionAt(x, y);
			}
			if (p1 > 7)
			{
				p1 = 0;
				state = 0;
			}
			break;
		case 0:
		{
			frame = 0;
			timeWait++;
			if (timeWait <= timeLimit || idChar != -1)
			{
				break;
			}
			short num = (short)(xFirst - range);
			short num2 = (short)(xFirst + range);
			short num3 = (short)(yFirst - range);
			short num4 = (short)(yFirst + range);
			sbyte b = (sbyte)LiveActor.r.nextInt(4);
			if (lastDir != -100 && lastDir == b)
			{
				if (b == Char.LEFT)
				{
					b = Char.RIGHT;
				}
				else if (b == Char.RIGHT)
				{
					b = Char.LEFT;
				}
				else if (b == Char.UP)
				{
					b = Char.DOWN;
				}
				else if (b == Char.DOWN)
				{
					b = Char.UP;
				}
			}
			if (b == Char.LEFT)
			{
				vx = (sbyte)(-speed);
				vy = 0;
				if (Math.abs(x - num) < 32)
				{
					b = Char.RIGHT;
					vx = (sbyte)speed;
				}
			}
			else if (b == Char.RIGHT)
			{
				vx = (sbyte)speed;
				vy = 0;
				if (Math.abs(x - num2) < 32)
				{
					b = Char.LEFT;
					vx = (sbyte)(-speed);
				}
			}
			else if (b == Char.UP)
			{
				vx = 0;
				vy = (sbyte)(-speed);
				if (Math.abs(y - num3) < 32)
				{
					b = Char.DOWN;
					vy = (sbyte)speed;
				}
			}
			else if (b == Char.DOWN)
			{
				vx = 0;
				vy = (sbyte)speed;
				if (Math.abs(y - num4) < 32)
				{
					b = Char.UP;
					vy = (sbyte)(-speed);
				}
			}
			dir = b;
			state = 2;
			timeWait = 0;
			break;
		}
		case 3:
			frame = 2;
			p1++;
			if (p1 > 6)
			{
				p1 = 0;
				state = 2;
			}
			else if (currentSkillAnimate != null)
			{
				currentSkillAnimate.updateSkill(this);
			}
			break;
		case 5:
			frame = 3;
			p1++;
			if (!isMineralC)
			{
				x += p2;
				y += p3;
			}
			p2 >>= 1;
			p3 >>= 1;
			if (p1 == 5)
			{
				Canvas.gameScr.startExplosionAt(x, y);
				timeRevive = mSystem.getCurrentTimeMillis() + timeLive;
			}
			isDied = true;
			timeBeginDie = mSystem.getCurrentTimeMillis() / 1000 + 3;
			if (p1 > 7)
			{
				isDied = false;
				wantDestroy = true;
			}
			break;
		case 8:
			if (Canvas.gameScr.focusedActor != null && Canvas.gameScr.focusedActor == this && Canvas.gameScr.mainChar.state == 0)
			{
				Canvas.gameScr.focusedActor = null;
			}
			if (timeRevive - mSystem.getCurrentTimeMillis() < 0)
			{
				wantDestroy = false;
				isDied = false;
				dir = (byte)LiveActor.r.nextInt(4);
				timeLimit = Res.random(10, 20);
				state = 0;
				timeWait = 0;
				p1 = (p2 = (p3 = 0));
				x = (xTo = xFirst);
				y = (yTo = yFirst);
				hp = maxhp;
				Canvas.gameScr.startExplosionAt(x, y);
				timeRevive = mSystem.getCurrentTimeMillis() + timeLive;
			}
			break;
		case 2:
		case 6:
		case 7:
			p1++;
			if (p1 > 6)
			{
				p1 = 0;
			}
			if (p1 > 2)
			{
				frame = 1;
			}
			else
			{
				frame = 0;
			}
			if (FuntioncanMove())
			{
				if (idChar > -1)
				{
					move();
				}
				else if (state == 7)
				{
					setMove(xFirst, yFirst);
				}
				else if (state == 2)
				{
					move();
				}
				else if (target == null)
				{
					p1 = (p2 = (p3 = 0));
					state = 0;
					timeLimit = Res.random(10, 20);
					vx = (vy = 0);
					lastDir = dir;
				}
				else if (target != null && Math.abs(x - target.x) <= rangestop && Math.abs(y - target.y) <= rangestop)
				{
					vx = (vy = 0);
				}
				else
				{
					setMove(target.x + xadd, target.y + yadd);
				}
			}
			break;
		}
		if (isDied && timeBeginDie - mSystem.getCurrentTimeMillis() / 1000 <= 0 && !wantDestroy)
		{
			Canvas.gameScr.startExplosionAt(x, y);
			wantDestroy = true;
			isDie = false;
		}
		if (hp <= 0 && Canvas.gameScr.focusedActor != null && Canvas.gameScr.focusedActor == this)
		{
			Canvas.gameScr.focusedActor = null;
		}
	}

	public void setMove(int i, int j)
	{
		if (Res.monsterTemplates[monster_type].moveType != 4)
		{
			bool flag = false;
			bool flag2 = false;
			int num = Math.abs(x - i);
			int num2 = Math.abs(y - j);
			if (num <= speed)
			{
				x = (short)i;
				flag = true;
			}
			if (num2 < speed)
			{
				y = (short)j;
				flag2 = true;
			}
			if (flag && flag2)
			{
				p1 = (p2 = (p3 = 0));
				state = 0;
				timeLimit = Res.random(10, 20);
				vx = (vy = 0);
				lastDir = dir;
			}
			else if (x < i)
			{
				x += speed;
				dir = Char.RIGHT;
			}
			else if (x > i)
			{
				x -= speed;
				dir = Char.LEFT;
			}
			else if (y > j)
			{
				y -= speed;
				dir = Char.UP;
			}
			else if (y < j)
			{
				dir = Char.DOWN;
				y += speed;
			}
		}
	}

	public virtual void move()
	{
		if (Res.monsterTemplates[monster_type].moveType == 4)
		{
			p1 = (p2 = (p3 = 0));
			state = 0;
			return;
		}
		if (idChar == -1)
		{
			short num = (short)(xFirst - range + speed);
			short num2 = (short)(xFirst + range - speed);
			short num3 = (short)(yFirst - range + speed);
			short num4 = (short)(yFirst + range - speed);
			int px = x - speed;
			int px2 = x + speed;
			int py = y - speed;
			int py2 = y + speed;
			int num5 = LiveActor.r.nextInt(50);
			if ((x >= num2 && dir == Char.RIGHT) || (x <= num && dir == Char.LEFT) || (y <= num3 && dir == Char.UP) || (y >= num4 && dir == Char.DOWN) || (Tilemap.tileTypeAtPixel(px, y, 2) && dir == Char.LEFT) || (Tilemap.tileTypeAtPixel(px2, y, 2) && dir == Char.RIGHT) || (Tilemap.tileTypeAtPixel(x, py, 2) && dir == Char.UP) || (Tilemap.tileTypeAtPixel(x, py2, 2) && dir == Char.DOWN) || num5 == 5)
			{
				p1 = (p2 = (p3 = 0));
				state = 0;
				timeLimit = Res.random(10, 20);
				vx = (vy = 0);
				lastDir = dir;
			}
			x = (short)(x + vx);
			y = (short)(y + vy);
			return;
		}
		bool flag = false;
		bool flag2 = false;
		int num6 = Math.abs(x - xTo);
		int num7 = Math.abs(y - yTo);
		if (num6 <= speed)
		{
			x = xTo;
			flag = true;
		}
		if (num7 < speed)
		{
			y = yTo;
			flag2 = true;
		}
		if (flag && flag2)
		{
			p1 = (p2 = (p3 = 0));
			state = 0;
		}
		else if (x < xTo)
		{
			x += speed;
			dir = Char.RIGHT;
		}
		else if (x > xTo)
		{
			x -= speed;
			dir = Char.LEFT;
		}
		else if (y > yTo)
		{
			y -= speed;
			dir = Char.UP;
		}
		else if (y < yTo)
		{
			dir = Char.DOWN;
			y += speed;
		}
	}

	public override void setPosTo(short xTo, short yTo)
	{
		if (idChar <= -1)
		{
			return;
		}
		if (state != 3 && x == xTo && y == yTo)
		{
			state = 0;
			return;
		}
		this.xTo = xTo;
		if (Res.monsterTemplates[monster_type].moveType == 4)
		{
			this.yTo = yTo;
		}
		else
		{
			this.yTo = (short)(yTo - 4 + Canvas.r.nextInt() % 8);
		}
		if (state != 3)
		{
			state = 2;
		}
		if (state != 3 && x == this.xTo && y == this.yTo)
		{
			state = 0;
		}
	}

	public virtual void setInfo(MonsterInfo monsterInfo)
	{
		timeLive = monsterInfo.timeLive;
		int[] array = new int[6]
		{
			16,
			32,
			48,
			-16,
			-32,
			-48
		};
		xadd = array[LiveActor.r.nextInt(array.Length - 1)];
		yadd = array[LiveActor.r.nextInt(array.Length - 1)];
		if (isMineralC)
		{
			x = monsterInfo.x;
			y = monsterInfo.y;
		}
		else
		{
			xTo = monsterInfo.x;
			yTo = monsterInfo.y;
			a = monsterInfo.x;
			b = monsterInfo.y;
		}
		rangestop = LiveActor.r.nextInt(10) + 6;
		realHP = (hp = monsterInfo.hp);
		he = monsterInfo.he;
		state = 0;
		p1 = 0;
		p2 = 0;
		p3 = 0;
		monster_type = monsterInfo.monster_type;
		if (Res.monsterTemplates != null && Res.monsterTemplates[monster_type] != null)
		{
			speed = Res.monsterTemplates[monster_type].speed;
			height = Res.monsterTemplates[monster_type].height;
			if (Res.monsterTemplates[monster_type].image == null)
			{
				Res.monsterTemplates[monster_type].loadImage();
			}
		}
		level = (sbyte)monsterInfo.lv;
		maxhp = monsterInfo.maxhp;
		isSetInfo = true;
	}

	public virtual void startAttack()
	{
		state = 3;
		p1 = (p2 = (p3 = 0));
	}

	public virtual void startAttack(LiveActor target, int hpLost, sbyte skillID, sbyte clazz)
	{
		state = 3;
		p1 = (p2 = (p3 = 0));
		targethplost = hpLost;
		attackTarget = target;
		currentSkillAnimate = SkillManager.getSkillAnimate(skillID, clazz);
	}

	public virtual void startAttack(mVector list, sbyte skillID)
	{
		state = 3;
		p1 = (p2 = (p3 = 0));
		if (monster_type == 90)
		{
			currentSkillAnimate = SkillManager.setSkillBoss_Xmas();
			currentSkillAnimate.setMonster(list);
		}
	}

	public override void jump()
	{
		if (!isMineralC)
		{
			z = -3;
			dz = -5;
		}
	}

	public virtual void setHp(int dam)
	{
		hp -= dam;
	}

	public override void setRealHP(int realHP)
	{
		base.realHP = realHP;
		hp = base.realHP;
		realHPSyncTime = 20;
	}

	public override bool isMonster()
	{
		return true;
	}

	public override bool isMineral()
	{
		return isMineralC;
	}
}
