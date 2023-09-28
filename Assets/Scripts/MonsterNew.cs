public class MonsterNew : Monster
{
	public const sbyte SKILL_BOSS_NOEL = 3;

	public const sbyte SKILL_LOC_XOAY = 4;

	public const sbyte SKILL_BLOOD_DOW = 5;

	public const sbyte SKILL_BAT = 6;

	public const sbyte SKILL_BABURAN = 7;

	public const sbyte SKILL_BI_NGO = 8;

	public const sbyte SKILL_THIEN_THACH = 9;

	public const sbyte SKILL_LUOI_KIEM = 10;

	public const sbyte SKILL_WEAPON_MAN_GO = 11;

	private Image[] img = new Image[2];

	private sbyte way;

	public mVector data = new mVector();

	private mVector listAttack = new mVector();

	private int IdvanTieu;

	private sbyte huongY;

	private sbyte flip;

	private sbyte[] splashDuaX = new sbyte[4]
	{
		-2,
		2,
		-8,
		8
	};

	private sbyte[] splashDuaY = new sbyte[4]
	{
		-10,
		-30,
		-10,
		-10
	};

	private sbyte[] x2 = new sbyte[9]
	{
		0,
		20,
		20,
		0,
		0,
		20,
		20,
		20,
		20
	};

	private sbyte[] y2 = new sbyte[9]
	{
		0,
		0,
		0,
		20,
		20,
		20,
		20,
		20,
		20
	};

	private sbyte skillID;

	private short idSkill = -1;

	private sbyte bymap;

	public bool isNewMonster;

	public MonsterNew(int idTemplate)
	{
		isDied = false;
		dir = (sbyte)LiveActor.r.nextInt(4);
		timeLimit = Res.random(10, 20);
		state = 0;
		timeWait = 0;
		p1 = (p2 = (p3 = 0));
		IdvanTieu = (short)idTemplate;
		if (Res.monsterTemplates[idTemplate] != null)
		{
			data = Res.monsterTemplates[idTemplate].getDataMonster();
		}
	}

	public override void paint(MyGraphics g)
	{
		if (data.size() == 0)
		{
			return;
		}
		DataEffect dataEffect = (DataEffect)data.elementAt(huongY);
		if (dataEffect == null)
		{
			return;
		}
		if (dynamicEffBottom != null)
		{
			for (int i = 0; i < dynamicEffBottom.size(); i++)
			{
				if ((DynamicEffect)dynamicEffBottom.elementAt(i) != null)
				{
					((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, y);
				}
			}
		}
		dataEffect.paint(g, dataEffect.getFrame(frame, state), x, y, flip, Res.monsterTemplates[monster_type].getImage(huongY));
		if (dynamicEffTop == null)
		{
			return;
		}
		for (int j = 0; j < dynamicEffTop.size(); j++)
		{
			if ((DynamicEffect)dynamicEffTop.elementAt(j) != null)
			{
				((DynamicEffect)dynamicEffTop.elementAt(j)).paint(g, x, y);
			}
		}
	}

	public override void paintCorner(MyGraphics g, int xCorner, int yCorner)
	{
	}

	public bool isMonsterVantieu()
	{
		return IdvanTieu >= 95 && IdvanTieu <= 112;
	}

	public override void paintName(MyGraphics g)
	{
		base.paintName(g);
	}

	public void set_Target(LiveActor acto)
	{
		if (Res.monsterTemplates[monster_type] != null && Res.monsterTemplates[monster_type].moveType != 4)
		{
			huongY = (sbyte)((y > acto.y) ? 1 : 0);
			flip = (sbyte)((x - acto.x <= 0) ? 2 : 0);
			dir = Util.findDirection(this, acto);
			setDir();
		}
	}

	public override void update()
	{
		updateDynamicBuff();
		DataEffect dataEffect = null;
		if (data.size() > 0)
		{
			dataEffect = (DataEffect)data.elementAt(0);
			frame = (sbyte)((frame + 1) % dataEffect.getAnim(state).frame.Length);
			if ((wantDestroy || hp <= 0) && timeLive != -1 && state != 8)
			{
				state = 8;
			}
		}
		else
		{
			setInfoTemplate();
		}
		if (!isSetInfo && mSystem.currentTimeMillis() - timeGetInfo > 15000)
		{
			timeGetInfo = mSystem.currentTimeMillis();
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
		updateBuff();
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
			if (dataEffect != null && frame == dataEffect.getAnim(state).frame.Length - 1)
			{
				state = 0;
			}
			break;
		case 0:
		{
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
			if (listAttack.size() == 0)
			{
				state = 0;
				return;
			}
			if (dataEffect == null)
			{
				break;
			}
			if (!isNewMonster)
			{
				if (monster_type == 117)
				{
					if (listAttack.size() > 0)
					{
						LiveActor liveActor = (LiveActor)listAttack.elementAt(0);
						set_Target(liveActor);
						if (frame == dataEffect.getAnim(state).frame.Length - 7)
						{
							if (skillID == 1)
							{
								Canvas.gameScr.startNewArrow(7, this, liveActor, x, y, liveActor.damAttack, 0, 18);
							}
							else
							{
								Canvas.gameScr.startSkill_BossHalloween(x, y, 0, listAttack);
							}
							listAttack.removeElementAt(0);
						}
					}
					if (listAttack.size() == 0 && frame == dataEffect.getAnim(state).frame.Length - 1)
					{
						state = 0;
					}
				}
				else if (monster_type == 116)
				{
					if (listAttack.size() > 0)
					{
						LiveActor liveActor2 = (LiveActor)listAttack.elementAt(0);
						set_Target(liveActor2);
						if (frame == dataEffect.getAnim(state).frame.Length - 7)
						{
							liveActor2.jump();
							if (skillID == 1)
							{
								Canvas.gameScr.startNewMagicBeam(9, this, liveActor2, x, y, liveActor2.damAttack, 0);
							}
							else if (skillID == 0)
							{
								for (int i = 0; i < 8; i++)
								{
									Canvas.gameScr.startNewMagicBeam(10, this, liveActor2, x + splashDuaX[dir] + x2[i], y + splashDuaY[dir] + y2[i], liveActor2.damAttack, 0, Skill_Dao_Type3.goc[dir][i]);
								}
							}
							else
							{
								Skill_blood_down o = new Skill_blood_down(liveActor2.x, liveActor2.y, liveActor2.damAttack);
								EffectManager.hiEffects.addElement(o);
							}
							listAttack.removeElementAt(0);
						}
					}
					if (listAttack.size() == 0 && frame == dataEffect.getAnim(state).frame.Length - 1)
					{
						state = 0;
					}
				}
				else if (!isMonsterVantieu() && (skillID == 0 || skillID == 2))
				{
					LiveActor target = (LiveActor)listAttack.elementAt(0);
					set_Target(target);
					if (frame == dataEffect.getAnim(state).frame.Length - 7 && dir != Char.LEFT)
					{
						if (dir == Char.RIGHT)
						{
							Canvas.gameScr.startSkill_Noel(x + 50, y, GameScr.cmy, listAttack);
						}
						else if (dir == Char.UP)
						{
							Canvas.gameScr.startSkill_Noel(x, y - 50, GameScr.cmy, listAttack);
						}
						else if (dir == Char.DOWN)
						{
							Canvas.gameScr.startSkill_Noel(x, y + 50, GameScr.cmy, listAttack);
						}
					}
					if (frame == dataEffect.getAnim(state).frame.Length - 1)
					{
						state = 0;
					}
				}
				else if (skillID == 1)
				{
					if (listAttack.size() > 0)
					{
						LiveActor liveActor3 = (LiveActor)listAttack.elementAt(0);
						set_Target(liveActor3);
						if (frame == dataEffect.getAnim(state).frame.Length - 7)
						{
							liveActor3.jump();
							if (monster_type == 115)
							{
								Canvas.gameScr.startNewArrow(14, this, liveActor3, x, y - 15, liveActor3.damAttack, 0, 14);
							}
							else
							{
								Canvas.gameScr.startNewArrow(13, this, liveActor3, x, y - 15, liveActor3.damAttack, 0, 13);
							}
						}
					}
					if (listAttack.size() == 0 && frame == dataEffect.getAnim(state).frame.Length - 1)
					{
						state = 0;
					}
				}
				startEffectSkill(skillID, dataEffect);
			}
			else
			{
				if (listAttack.size() <= 0)
				{
					break;
				}
				if (frame == dataEffect.getAnim(state).frame.Length - 7)
				{
					for (int j = 0; j < listAttack.size(); j++)
					{
						LiveActor liveActor4 = (LiveActor)listAttack.elementAt(j);
						GameScr.startSkillEffect(liveActor4, idSkill, 5000L, 1, liveActor4.damAttack, bymap);
					}
					listAttack.removeAllElements();
				}
				if (listAttack.size() == 0 && frame == dataEffect.getAnim(state).frame.Length - 1)
				{
					state = 0;
				}
			}
			break;
		case 5:
			wantDestroy = true;
			frame = 0;
			Canvas.gameScr.actors.removeElement(this);
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
				dir = (sbyte)LiveActor.r.nextInt(4);
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
			if (!isFreeze)
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
				else if (base.target == null)
				{
					p1 = (p2 = (p3 = 0));
					state = 0;
					timeLimit = Res.random(10, 20);
					vx = (vy = 0);
					lastDir = dir;
				}
				else if (base.target != null && Math.abs(x - base.target.x) <= rangestop && Math.abs(y - base.target.y) <= rangestop)
				{
					vx = (vy = 0);
				}
				else
				{
					setMove(base.target.x + xadd, base.target.y + yadd);
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

	private void setInfoTemplate()
	{
		if (Res.monsterTemplates[monster_type] != null)
		{
			data = Res.monsterTemplates[monster_type].getDataMonster();
		}
	}

	public override void startAttack(mVector list, sbyte skillID)
	{
		if (skillID == 2)
		{
			skillID = (sbyte)((monster_type == 113) ? 1 : 0);
		}
		listAttack = list;
		state = 3;
		p1 = (p2 = (p3 = 0));
		frame = 0;
		this.skillID = skillID;
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
		base.xTo = xTo;
		if (Res.monsterTemplates[monster_type].moveType == 4)
		{
			base.yTo = yTo;
		}
		else
		{
			base.yTo = yTo;
			huongY = (sbyte)((y > yTo) ? 1 : 0);
			flip = (sbyte)((x - xTo <= 0) ? 2 : 0);
			setDir();
		}
		if (state != 3)
		{
			state = 2;
		}
		if (state != 3 && x == base.xTo && y == base.yTo)
		{
			state = 0;
		}
	}

	private void startEffectSkill(int id, DataEffect deff)
	{
		if (listAttack.size() <= 0 || id <= 2)
		{
			return;
		}
		LiveActor liveActor = (LiveActor)listAttack.elementAt(0);
		set_Target(liveActor);
		switch (id)
		{
		case 3:
			if (frame == deff.getAnim(state).frame.Length - 7 && dir != Char.LEFT)
			{
				if (dir == Char.RIGHT)
				{
					Canvas.gameScr.startSkill_Noel(x + 50, y, GameScr.cmy, listAttack);
				}
				else if (dir == Char.UP)
				{
					Canvas.gameScr.startSkill_Noel(x, y - 50, GameScr.cmy, listAttack);
				}
				else if (dir == Char.DOWN)
				{
					Canvas.gameScr.startSkill_Noel(x, y + 50, GameScr.cmy, listAttack);
				}
			}
			if (frame == deff.getAnim(state).frame.Length - 1)
			{
				state = 0;
			}
			break;
		case 4:
			Canvas.gameScr.startNewMagicBeam(9, this, liveActor, x, y, liveActor.damAttack, 0);
			break;
		case 5:
		{
			Skill_blood_down o = new Skill_blood_down(liveActor.x, liveActor.y, liveActor.damAttack);
			EffectManager.hiEffects.addElement(o);
			break;
		}
		case 7:
			Canvas.gameScr.startNewArrow(7, this, liveActor, x, y, liveActor.damAttack, 0, 18);
			break;
		case 6:
			for (int k = 0; k < 8; k++)
			{
				Canvas.gameScr.startNewMagicBeam(10, this, liveActor, x + splashDuaX[dir] + x2[k], y + splashDuaY[dir] + y2[k], liveActor.damAttack, 0, Skill_Dao_Type3.goc[dir][k]);
			}
			break;
		case 8:
			Canvas.gameScr.startSkill_BossHalloween(x, y, 0, listAttack);
			break;
		case 9:
			for (int j = 0; j < listAttack.size(); j++)
			{
				LiveActor liveActor3 = (LiveActor)listAttack.elementAt(j);
				ThienThach_Skill o2 = new ThienThach_Skill(liveActor3.x, liveActor3.y, liveActor3.damAttack);
				EffectManager.hiEffects.addElement(o2);
			}
			break;
		case 10:
			for (int i = 0; i < listAttack.size(); i++)
			{
				LiveActor liveActor2 = (LiveActor)listAttack.elementAt(i);
				Canvas.gameScr.startNewArrow(7, this, liveActor2, x - 20, y - 50, liveActor2.damAttack, 2, 8);
				Canvas.gameScr.startNewArrow(7, this, liveActor2, x, y - 30, liveActor2.damAttack, 2, 8);
				Canvas.gameScr.startNewArrow(7, this, liveActor2, x - 20, y - 10, liveActor2.damAttack, 2, 8);
				liveActor.doublejump();
			}
			break;
		case 11:
			for (int l = 0; l < listAttack.size(); l++)
			{
				LiveActor acTo = (LiveActor)listAttack.elementAt(l);
				Canvas.gameScr.startWeapsMango(this, acTo, 30);
			}
			break;
		default:
			if (frame == deff.getAnim(state).frame.Length - 7 && dir != Char.LEFT)
			{
				if (dir == Char.RIGHT)
				{
					Canvas.gameScr.startSkill_Noel(x + 50, y, GameScr.cmy, listAttack);
				}
				else if (dir == Char.UP)
				{
					Canvas.gameScr.startSkill_Noel(x, y - 50, GameScr.cmy, listAttack);
				}
				else if (dir == Char.DOWN)
				{
					Canvas.gameScr.startSkill_Noel(x, y + 50, GameScr.cmy, listAttack);
				}
			}
			if (frame == deff.getAnim(state).frame.Length - 1)
			{
				state = 0;
			}
			break;
		}
		if (listAttack.size() == 0 && frame == deff.getAnim(state).frame.Length - 1)
		{
			state = 0;
		}
	}

	public void setDir()
	{
		if (data.size() > 2)
		{
			flip = 0;
			if (dir == Char.RIGHT)
			{
				flip = 2;
				huongY = 0;
			}
			else if (dir == Char.LEFT)
			{
				huongY = 0;
			}
			else if (dir == Char.DOWN)
			{
				huongY = 1;
			}
			else if (dir == Char.UP)
			{
				huongY = 2;
			}
		}
	}

	public override void setIdSkill(int idSkill)
	{
		this.idSkill = (short)idSkill;
	}

	public override void setByMap(int type)
	{
		bymap = (sbyte)type;
	}

	public override void setNewMonster(int isNewMonster)
	{
		this.isNewMonster = (isNewMonster == 1);
	}
}
