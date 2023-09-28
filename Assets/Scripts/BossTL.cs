public class BossTL : Monster
{
	private mVector exp = new mVector();

	private static int[] trans = new int[2]
	{
		0,
		2
	};

	private byte totalExp;

	public override void paint(MyGraphics g)
	{
		if (z != 0)
		{
			frame++;
			if (frame > 1)
			{
				frame = 0;
			}
		}
		if (Res.monsterTemplates[monster_type] != null)
		{
			int num = Monster.REAL_FRAME[Res.monsterTemplates[monster_type].moveType][dir][frame];
			g.drawImage(Res.imgShadow, x, y, 3);
			if (dynamicEffBottom != null)
			{
				for (int i = 0; i < dynamicEffBottom.size(); i++)
				{
					((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, y);
				}
			}
			g.drawRegion(Res.monsterTemplates[monster_type].image, 0, num % 4 * Res.monsterTemplates[monster_type].h, Res.monsterTemplates[monster_type].w, Res.monsterTemplates[monster_type].h, trans[num / 4], x - Res.monsterTemplates[monster_type].xCenter + vangx, y - Res.monsterTemplates[monster_type].yCenter + z + vangy, 0);
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
		switch (state)
		{
		case 1:
			break;
		case 4:
			break;
		case 0:
			frame = 0;
			break;
		case 3:
			frame = 2;
			p1++;
			if (p1 % 6 == 3)
			{
				Skill_Tia_Thuy skill_Tia_Thuy = null;
				if (targethplost != 0)
				{
					Canvas.gameScr.startFlyText("-" + targethplost, 0, attackTarget.x, attackTarget.y + attackTarget.dy - 15, 1, -2);
				}
				else
				{
					Canvas.gameScr.startFlyText("MISS", 0, attackTarget.x, attackTarget.y + attackTarget.dy - 15, 1, -2);
				}
				skill_Tia_Thuy = ((Monster.REAL_FRAME[Res.monsterTemplates[monster_type].moveType][dir][frame] >= 4) ? new Skill_Tia_Thuy(attackTarget, x + 20, y - 30) : new Skill_Tia_Thuy(attackTarget, x - 20, y - 30));
				EffectManager.hiEffects.addElement(skill_Tia_Thuy);
			}
			if (p1 > 10)
			{
				p1 = 0;
				state = 2;
			}
			break;
		case 5:
			frame = 3;
			p1++;
			x += p2;
			y += p3;
			p2 >>= 1;
			p3 >>= 1;
			createExp();
			break;
		case 2:
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
			move();
			break;
		}
	}

	public void startAttack(LiveActor live, int dam, byte skillID)
	{
		state = 3;
		p1 = (p2 = (p3 = 0));
		attackTarget = live;
		targethplost = dam;
	}
}
