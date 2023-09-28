public class Skill_Dua_Type3 : SkillAnimate
{
	private class Eff_DauRong_Down : Effect
	{
		public new int x;

		public new int y;

		public int xTo;

		public int yTo;

		public int vy = 5;

		public int power;

		public LiveActor to;

		private int[] wImg = new int[4]
		{
			0,
			0,
			24,
			24
		};

		public Eff_DauRong_Down(int xF, int yF, LiveActor to)
		{
			x = Canvas.random(xF - 15, xF + 15);
			y = Canvas.random(yF - 20, yF + 20);
			this.to = to;
		}

		public override void update()
		{
			y += vy;
			vy += 2;
			if (y > to.y - 15)
			{
				EffectManager.hiEffects.removeElement(this);
				EffectManager.addHiEffect(x, y - 5, 30);
			}
			if (power != 0)
			{
				Canvas.gameScr.startFlyText("-" + power, 0, x, y - 15, 1, -2);
			}
			else
			{
				Canvas.gameScr.startFlyText("MISS", 0, x, y - 15, 1, -2);
			}
		}

		public override void paint(MyGraphics g)
		{
			if (Res.getImgArrow(4) != null)
			{
				g.drawRegion(Res.imgArrow[4], wImg[0], wImg[1], wImg[2], wImg[3], 5, x, y, 3);
			}
		}
	}

	private int pmonster;

	private int lvSkill;

	private int ID;

	private sbyte loop;

	private sbyte lap;

	private sbyte nDragon = 1;

	public Skill_Dua_Type3(int id)
		: base(-1)
	{
		ID = id;
	}

	public override void setLvSkill(int lv)
	{
		lvSkill = lv;
	}

	public override int getX2()
	{
		if (lvSkill < SkillAnimate.nDra.Length)
		{
			nDragon = (sbyte)SkillAnimate.nDra[lvSkill];
			return SkillAnimate.nDra[lvSkill];
		}
		return 1;
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
		if (c.p1 == 8)
		{
			loop = 0;
			lap = 0;
		}
		updateSkillDua(c);
		if (c.p1 == 3 && ID == 0)
		{
			short[][] array = new short[4][]
			{
				new short[11]
				{
					90,
					315,
					225,
					270,
					315,
					225,
					90,
					315,
					225,
					315,
					225
				},
				new short[11]
				{
					270,
					135,
					45,
					90,
					135,
					45,
					270,
					135,
					45,
					135,
					45
				},
				new short[11]
				{
					180,
					45,
					315,
					180,
					45,
					315,
					180,
					45,
					315,
					45,
					315
				},
				new short[11]
				{
					0,
					135,
					225,
					0,
					135,
					225,
					0,
					135,
					225,
					135,
					225
				}
			};
			if (c.dir <= SkillAnimate.splashDuaX.Length - 1 && c.dir <= SkillAnimate.splashDuaY.Length - 1 && c.dir <= array.Length - 1 && loop <= array[c.dir].Length - 1)
			{
				Canvas.gameScr.startNewMagicBeam(3, c, c.attackTarget, c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, array[c.dir][loop]);
			}
			loop++;
			if (loop < nDragon)
			{
				c.p1 = 0;
			}
		}
		if (lap % 2 == 0 && ID == 1)
		{
			int num = 1;
			if (lvSkill < 7 && lvSkill > 3)
			{
				num = 2;
			}
			else if (lvSkill >= 7)
			{
				num = 4;
			}
			for (int i = 0; i < num; i++)
			{
				Eff_DauRong_Down eff_DauRong_Down = new Eff_DauRong_Down(c.attackTarget.x, c.attackTarget.y - 200, c.attackTarget);
				if (c.attkPower != 2000000)
				{
					eff_DauRong_Down.power = c.attkPower / nDragon;
				}
				else
				{
					eff_DauRong_Down.power = c.attkPower;
				}
				EffectManager.hiEffects.addElement(eff_DauRong_Down);
				EffectManager.addHiEffect(c.x, c.y - 15, 23);
			}
		}
		c.p1++;
		if (ID == 1)
		{
			lap++;
		}
	}

	public override void updateSkill(Monster c)
	{
	}
}
