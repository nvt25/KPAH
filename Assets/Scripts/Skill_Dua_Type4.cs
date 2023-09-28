public class Skill_Dua_Type4 : SkillAnimate
{
	private class Skill_Dua_4 : Effect
	{
		private int angle;

		private int xGo;

		private int yGo;

		private byte index;

		private byte g = 10;

		private bool isExplo;

		public Skill_Dua_4(int x, int y)
		{
			y -= 10;
			xGo = x;
			yGo = y;
			base.x = x + 50;
			base.y = y - 150;
			g = (byte)(5 + Res.rnd(10));
			angle = Util.angle(x - base.x, -(y - base.y));
		}

		public override void update()
		{
			if (!isExplo)
			{
				int num = g * Util.Cos(angle) >> 10;
				int num2 = -(g * Util.Sin(angle)) >> 10;
				g += 2;
				x += num;
				y += num2;
				if (Util.distance(x, y, xGo, yGo) <= 20)
				{
					y = yGo;
					index = 4;
					isExplo = true;
					EffectManager.lowEffects.addElement(this);
					EffectManager.hiEffects.removeElement(this);
				}
			}
			else
			{
				index++;
				if (index >= 12)
				{
					EffectManager.lowEffects.removeElement(this);
				}
			}
		}

		public override void paint(MyGraphics g)
		{
			g.drawRegion(img, 0, 15 * ((int)index / 3), 13, 15, 0, x, y, 3);
		}
	}

	public static Image img;

	private mVector mst = new mVector();

	public Skill_Dua_Type4(int skillWeapon)
		: base(skillWeapon)
	{
		FilePack.init(FilePack.effPublic);
		img = FilePack.getImg("muabang");
		FilePack.reset();
	}

	public override void setMonster(mVector mst)
	{
		this.mst = mst;
	}

	public override void setActorter(mVector mst)
	{
		this.mst = mst;
	}

	public override void updateSkill(Monster c)
	{
	}

	public override void updateSkill(Char c)
	{
		if (c == null)
		{
			return;
		}
		base.updateSkill(c);
		if (c.state == 0)
		{
			return;
		}
		updateSkillDua(c);
		if (c.p1 % 3 == 0)
		{
			if (mst.size() > 0)
			{
				for (int i = 0; i < mst.size(); i++)
				{
					Actor actor = (Actor)mst.elementAt(i);
					for (int j = 0; j < 6; j++)
					{
						Skill_Dua_4 o = new Skill_Dua_4(actor.x - 25 + Res.rnd(50), actor.y - 25 + Res.rnd(50));
						EffectManager.hiEffects.addElement(o);
					}
				}
			}
			else
			{
				for (int k = 0; k < 6; k++)
				{
					Skill_Dua_4 o2 = new Skill_Dua_4(c.attackTarget.x - 25 + Res.rnd(50), c.attackTarget.y - 25 + Res.rnd(50));
					EffectManager.hiEffects.addElement(o2);
				}
			}
		}
		c.p1++;
	}
}
