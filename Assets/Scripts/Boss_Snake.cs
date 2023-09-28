using System;

public class Boss_Snake : Monster
{
	private mVector exp = new mVector();

	private mVector listAttack = new mVector();

	private sbyte[][] MOVE_FRAME = new sbyte[4][]
	{
		new sbyte[8]
		{
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2
		},
		new sbyte[8]
		{
			5,
			5,
			5,
			5,
			6,
			6,
			6,
			6
		},
		new sbyte[8]
		{
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2
		},
		new sbyte[8]
		{
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2
		}
	};

	private sbyte[][] ATT_FRAME = new sbyte[4][]
	{
		new sbyte[6]
		{
			3,
			3,
			3,
			3,
			3,
			3
		},
		new sbyte[6]
		{
			7,
			7,
			7,
			7,
			7,
			7
		},
		new sbyte[6]
		{
			3,
			3,
			3,
			3,
			3,
			3
		},
		new sbyte[6]
		{
			3,
			3,
			3,
			3,
			3,
			3
		}
	};

	private sbyte[][] STAND_FRAME = new sbyte[5][]
	{
		new sbyte[10]
		{
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[10]
		{
			5,
			5,
			5,
			5,
			5,
			6,
			6,
			6,
			6,
			6
		},
		new sbyte[10]
		{
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[10]
		{
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[10]
		{
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1
		}
	};

	private sbyte totalExp;

	private sbyte skillID;

	public override void paint(MyGraphics g)
	{
		if (!isFreeze)
		{
			if (Res.monsterTemplates[monster_type] != null && Res.monsterTemplates[monster_type].image != null)
			{
				g.drawImage(Res.imgShadow, x, y - 5, 3);
				if (dynamicEffBottom != null)
				{
					for (int i = 0; i < dynamicEffBottom.size(); i++)
					{
						((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, y);
					}
				}
				g.drawRegion(Res.monsterTemplates[monster_type].image, 0, frame * Res.monsterTemplates[monster_type].h, Res.monsterTemplates[monster_type].w, Res.monsterTemplates[monster_type].h, (dir == 3) ? 2 : 0, x, y, 33);
				if (dynamicEffTop != null)
				{
					for (int j = 0; j < dynamicEffTop.size(); j++)
					{
						((DynamicEffect)dynamicEffTop.elementAt(j)).paint(g, x, y);
					}
				}
			}
			paintExp(g);
		}
		paintEffSkill(g);
	}

	public override void paintCorner(MyGraphics g, int xCorner, int yCorner)
	{
		try
		{
			if (Res.monsterTemplates[monster_type] != null && Res.monsterTemplates[monster_type].image != null)
			{
				g.drawRegion(Res.monsterTemplates[monster_type].image, 0, 0, Res.monsterTemplates[monster_type].w, Res.monsterTemplates[monster_type].h / 2, 0, xCorner - Res.monsterTemplates[monster_type].xCenter, yCorner - 20, 0);
				g.drawRegion(Res.imgNguHanh, nh[he] * 16, 0, 16, 16, 0, xCorner - 15, yCorner + 3, MyGraphics.TOP | MyGraphics.LEFT);
			}
		}
		catch (Exception)
		{
		}
	}

	public override void jump()
	{
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
			((Explode)exp.elementAt(i))?.paint(g);
		}
	}

	private void updateExp()
	{
		for (int i = 0; i < exp.size(); i++)
		{
			Explode explode = (Explode)exp.elementAt(i);
			if (explode == null)
			{
				continue;
			}
			explode.update();
			if (explode.destroy)
			{
				exp.removeElement(explode);
				if (exp.size() == 0)
				{
					wantDestroy = true;
				}
			}
		}
	}

	public override void startDeadFly(int dx, int dy)
	{
		state = 5;
	}

	private void createExp()
	{
		if (totalExp < 15)
		{
			totalExp++;
			MyRandom myRandom = new MyRandom();
			exp.addElement(new Explode(x - 12 + GameScr.abs(myRandom.nextInt() % 25), y - 30 + GameScr.abs(myRandom.nextInt() % 35), 0));
		}
	}

	public override void update()
	{
		updateExp();
		updateDynamicBuff();
		switch (state)
		{
		case 4:
			if (dir != 1)
			{
				frame = 3;
			}
			else
			{
				frame = 7;
			}
			break;
		case 0:
			p1++;
			if (p1 > STAND_FRAME[dir].Length - 1)
			{
				p1 = 0;
			}
			frame = STAND_FRAME[dir][p1];
			break;
		case 3:
			p1++;
			if (p1 % 3 == 0)
			{
				EffectManager.addLowEffect(x - 20, y - 14, 30);
				EffectManager.addLowEffect(x + 20, y - 14, 30);
				EffectManager.addLowEffect(x - 20, y - 4, 30);
				EffectManager.addLowEffect(x + 20, y - 4, 30);
				EffectManager.addLowEffect(x, y + 4, 30);
			}
			if (p1 > ATT_FRAME[dir].Length - 1)
			{
				p1 = 0;
				if (skillID == 0)
				{
					for (int i = 0; i < listAttack.size(); i++)
					{
						LiveActor acTo = (LiveActor)listAttack.elementAt(i);
						Canvas.gameScr.SkillofBoss_Snake(this, acTo, 4, 52);
					}
				}
				else if (skillID != 1)
				{
					for (int j = 0; j < listAttack.size(); j++)
					{
						LiveActor liveActor = (LiveActor)listAttack.elementAt(j);
						if (liveActor != null)
						{
							int damAttack = liveActor.damAttack;
							liveActor.doublejump();
							Canvas.gameScr.startFlyText("-" + damAttack, 0, liveActor.x, liveActor.y + liveActor.dy - 15, 1, -2);
							for (int k = 0; k < 15; k++)
							{
								EffectManager.addHiEffect(liveActor.x - 12 + GameScr.abs(LiveActor.r.nextInt() % 25), liveActor.y - 30 + GameScr.abs(LiveActor.r.nextInt() % 35), 33);
							}
						}
					}
				}
				state = 2;
			}
			frame = ATT_FRAME[dir][p1];
			break;
		case 5:
			frame = 3;
			createExp();
			break;
		case 2:
			p1++;
			if (p1 > MOVE_FRAME[dir].Length - 1)
			{
				p1 = 0;
			}
			frame = MOVE_FRAME[dir][p1];
			if (!isFreeze)
			{
				move();
			}
			break;
		}
		updateEffSkill();
	}

	public override void startAttack(mVector list, sbyte skillID)
	{
		listAttack = list;
		state = 3;
		p1 = (p2 = (p3 = 0));
		this.skillID = skillID;
	}

	public override void setInfo(MonsterInfo monsterInfo)
	{
		base.setInfo(monsterInfo);
	}
}
