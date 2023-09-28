using System;

public class TruRong : Monster
{
	private mVector exp = new mVector();

	private sbyte[] ATT_FRAME = new sbyte[8]
	{
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		1
	};

	private sbyte[] STAND_FRAME = new sbyte[6]
	{
		0,
		0,
		0,
		1,
		1,
		1
	};

	private int typeID;

	public static bool isChopSang;

	private int dem;

	private int lap;

	private sbyte totalExp;

	private mVector listTarget = new mVector();

	public override void paint(MyGraphics g)
	{
		if (!isFreeze)
		{
			if (Res.monsterTemplates[monster_type] != null && Res.monsterTemplates[monster_type].image != null)
			{
				g.drawRegion(Res.monsterTemplates[monster_type].image, 0, frame * Res.monsterTemplates[monster_type].h, Res.monsterTemplates[monster_type].w, Res.monsterTemplates[monster_type].h, 0, x, y, MyGraphics.VCENTER | MyGraphics.HCENTER);
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
				if (dynamicEffBottom != null)
				{
					for (int i = 0; i < dynamicEffBottom.size(); i++)
					{
						((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, x, y);
					}
				}
				g.drawRegion(Res.monsterTemplates[monster_type].image, 0, 0 * Res.monsterTemplates[monster_type].h, Res.monsterTemplates[monster_type].w, 40, 0, xCorner - Res.monsterTemplates[monster_type].xCenter, yCorner - 20, 0);
				g.drawRegion(Res.imgNguHanh, nh[he] * 16, 0, 16, 16, 0, xCorner - 15, yCorner + 3, MyGraphics.TOP | MyGraphics.LEFT);
				if (dynamicEffTop != null)
				{
					for (int j = 0; j < dynamicEffTop.size(); j++)
					{
						((DynamicEffect)dynamicEffTop.elementAt(j)).paint(g, x, y);
					}
				}
			}
		}
		catch (Exception)
		{
			Out.println(" loi tai paintCorner monter");
		}
	}

	public override void update()
	{
		updateDynamicBuff();
		if (Canvas.gameTick % 5 == 0)
		{
			frame++;
		}
		if (frame >= 2)
		{
			frame = 0;
		}
		updateExp();
		switch (state)
		{
		case 2:
			frame = 0;
			break;
		case 3:
			p1++;
			if (p1 == ATT_FRAME.Length - 5)
			{
				for (int i = 0; i < listTarget.size(); i++)
				{
					LiveActor liveActor = (LiveActor)listTarget.elementAt(i);
					Skill_TruRong e = new Skill_TruRong(x, y, liveActor.x, liveActor.y, liveActor, i * 4);
					EffectManager.addHiEffect(e);
				}
			}
			if (p1 > ATT_FRAME.Length - 1)
			{
				p1 = 0;
				state = 0;
			}
			break;
		case 5:
			frame = 0;
			createExp();
			break;
		}
		updateEffSkill();
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
			Explode explode = (Explode)exp.elementAt(i);
			explode.paint(g);
		}
	}

	private void updateExp()
	{
		for (int i = 0; i < exp.size(); i++)
		{
			Explode explode = (Explode)exp.elementAt(i);
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

	public override void startAttack(mVector list, sbyte skillID)
	{
		state = 3;
		listTarget = list;
		p1 = (p2 = (p3 = 0));
	}

	public override void setInfo(MonsterInfo monsterInfo)
	{
		base.setInfo(monsterInfo);
	}

	public override bool allwayPaint()
	{
		return true;
	}
}
