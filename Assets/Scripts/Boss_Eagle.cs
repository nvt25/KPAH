public class Boss_Eagle : Monster
{
	private mVector exp = new mVector();

	private mVector listAttack = new mVector();

	private sbyte[] FRAME = new sbyte[3]
	{
		4,
		6,
		5
	};

	private new sbyte frame;

	private sbyte transChan;

	private sbyte f;

	private sbyte maxCount = 10;

	private sbyte totalExp;

	private sbyte skillID;

	private long timeGetImage = mSystem.getCurrentTimeMillis();

	public override void paint(MyGraphics g)
	{
		if (!isFreeze)
		{
			if (Res.monsterTemplates[monster_type].imageObj != null)
			{
				g.drawImage(Res.imgShadow, x, base.y + 15, 3);
				if (dynamicEffBottom != null)
				{
					for (int i = 0; i < dynamicEffBottom.size(); i++)
					{
						((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, base.y);
					}
				}
				int num = frame / 5;
				int y = base.y - num * 3;
				if (num > 2)
				{
					num = 2;
				}
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, 0, 0, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, f + 1, transChan, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, FRAME[num], 0, 1, 1);
				Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, FRAME[num], 2, -1, 1);
				if (state == 3)
				{
					Res.monsterTemplates[monster_type].imageObj.paint(g, x, y, 3, 0, 1, 1);
				}
				if (dynamicEffTop != null)
				{
					for (int j = 0; j < dynamicEffTop.size(); j++)
					{
						((DynamicEffect)dynamicEffTop.elementAt(j)).paint(g, x, base.y);
					}
				}
			}
			else if (mSystem.getCurrentTimeMillis() > timeGetImage)
			{
				timeGetImage = mSystem.getCurrentTimeMillis() + 10000;
				Res.monsterTemplates[monster_type].isLoad = false;
				Res.monsterTemplates[monster_type].loadImage();
			}
			paintExp(g);
		}
		paintEffSkill(g);
	}

	public override void jump()
	{
	}

	private void changeChan(int index)
	{
		if (z > 20)
		{
			f = (sbyte)index;
			z = 0;
		}
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
		updateDynamicBuff();
		z++;
		frame++;
		if (frame >= maxCount)
		{
			frame = 0;
		}
		transChan = 0;
		updateExp();
		switch (state)
		{
		case 0:
			maxCount = 10;
			changeChan(1);
			break;
		case 3:
			maxCount = 20;
			changeChan(0);
			p1++;
			if (frame / 5 <= 2 || p1 <= 20)
			{
				break;
			}
			p1 = 0;
			state = 2;
			if (skillID == 1)
			{
				sbyte[] array = new sbyte[2]
				{
					-1,
					1
				};
				for (int i = 0; i < 30; i++)
				{
					ArrowTarget arrowTarget = new ArrowTarget(6);
					int num = Res.rnd(2);
					arrowTarget.set(0, x + array[num] * 25, y - frame / 5 * 3, 0, 0, x + Res.rnd(200) * array[num] - 10 * array[num], y + 20 + Res.rnd(150), (sbyte)(Res.rnd(10) + 15), isTarget: false);
					GameScr.arrowsUp.addElement(arrowTarget);
				}
				for (int j = 0; j < listAttack.size(); j++)
				{
					LiveActor liveActor = (LiveActor)listAttack.elementAt(j);
					ArrowTarget arrowTarget2 = new ArrowTarget(6);
					int num2 = Res.rnd(2);
					arrowTarget2.set(0, x + array[num2] * 25, y - frame / 5 * 3, liveActor.damAttack, 0, liveActor.x, liveActor.y, 20, isTarget: true);
					GameScr.arrowsUp.addElement(arrowTarget2);
				}
			}
			else
			{
				for (int k = 0; k < listAttack.size(); k++)
				{
					LiveActor liveActor2 = (LiveActor)listAttack.elementAt(k);
					ThienThach_Skill o = new ThienThach_Skill(liveActor2.x, liveActor2.y, liveActor2.damAttack);
					EffectManager.hiEffects.addElement(o);
				}
			}
			break;
		case 5:
			changeChan(1);
			createExp();
			break;
		case 2:
			maxCount = 10;
			changeChan(0);
			if (frame / 5 == 1 && f == 0)
			{
				transChan = 2;
			}
			move();
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
		Res.monsterTemplates[monster_type].w = 50;
		timeGetImage = mSystem.getCurrentTimeMillis() + 10000;
		height = 100;
	}
}
