using System;

public class Skill_Kiem_TypeAEO : SkillAnimate
{
	private mVector mst = new mVector();

	private int xPos;

	private int yPos;

	private int type;

	private Lightning light;

	private bool isMonster;

	public Skill_Kiem_TypeAEO(int type)
		: base(-1)
	{
		this.type = type;
	}

	public override void setMonster(mVector mst)
	{
		add(mst);
	}

	private void addEff()
	{
		if (light == null)
		{
			light = new Lightning();
		}
		light.reset();
		for (int i = 0; i < mst.size(); i++)
		{
			Actor actor = (Actor)mst.elementAt(i);
			light.listPos.addElement(new Position(actor.x, actor.y));
		}
		if (light.listPos.size() > 0)
		{
			light.setInfo(light.listPos, new Position(xPos, yPos - 40), (type == 4) ? true : false);
			EffectManager.hiEffects.addElement(light);
		}
	}

	public override void setActorter(mVector mst)
	{
		add(mst);
		isMonster = false;
	}

	private void add(mVector mst)
	{
		this.mst.removeAllElements();
		for (int i = 0; i < mst.size(); i++)
		{
			LiveActor liveActor = (LiveActor)mst.elementAt(i);
			Actor actor = Canvas.gameScr.findActorByID(liveActor.ID);
			if (actor != null)
			{
				this.mst.addElement(actor);
			}
		}
	}

	public override void updateSkill(Char c)
	{
		if (c == null)
		{
			return;
		}
		c.frame = 4;
		if (c.p1 == 16)
		{
			c.state = 0;
			c.p1 = (c.p2 = (c.p3 = 0));
			c.weapon_frame = 0;
		}
		else if (c.p1 >= 14 && c.p1 < 16)
		{
			c.frame = 5;
			c.weapon_frame = 7;
		}
		else if (c.p1 == 13 || c.p1 == 12)
		{
			c.frame = 5;
			c.weapon_frame = 6;
		}
		else if (c.p1 == 11 || c.p1 == 10)
		{
			c.frame = 4;
			c.weapon_frame = 5;
		}
		else
		{
			if (c.p1 % 2 == 0)
			{
				xPos = c.x;
				yPos = c.y;
				EffectManager.addHiEffect(c.x, c.y - 40, 3);
			}
			c.frame = 4;
			c.weapon_frame = 4;
		}
		if (c.p1 == 9)
		{
			addEff();
			for (int i = 0; i < mst.size(); i++)
			{
				try
				{
					if (!((Actor)mst.elementAt(i)).isNPC())
					{
						LiveActor liveActor = (LiveActor)mst.elementAt(i);
						if (c.attkPower != 0 && c.attkPower != 2000000)
						{
							Canvas.gameScr.startFlyText("-" + c.attkPower, 0, liveActor.x, liveActor.y - 15, 1, -2);
						}
						if (c.attkEffect != 0 && c.attkEffect < AttackResult.EFF_NAME.Length)
						{
							Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[c.attkEffect], 0, liveActor.x, liveActor.y - 15, 2, -2);
						}
						liveActor.jump();
					}
				}
				catch (Exception)
				{
				}
			}
			isMonster = false;
		}
		c.p1++;
	}

	public override void updateSkill(Monster c)
	{
	}
}
