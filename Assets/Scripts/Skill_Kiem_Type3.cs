using System;

public class Skill_Kiem_Type3 : SkillAnimate
{
	private static sbyte[] x2 = new sbyte[13]
	{
		0,
		20,
		20,
		0,
		0,
		20,
		20,
		20,
		20,
		20,
		20,
		20,
		20
	};

	private static sbyte[] y2 = new sbyte[13]
	{
		0,
		0,
		0,
		20,
		20,
		20,
		20,
		20,
		20,
		20,
		20,
		20,
		20
	};

	private static short[][][] angle = new short[4][][]
	{
		new short[11][]
		{
			new short[3]
			{
				90,
				315,
				225
			},
			new short[3]
			{
				90,
				315,
				225
			},
			new short[3]
			{
				90,
				315,
				225
			},
			new short[4]
			{
				90,
				315,
				225,
				270
			},
			new short[4]
			{
				90,
				315,
				225,
				270
			},
			new short[5]
			{
				90,
				315,
				225,
				270,
				45
			},
			new short[6]
			{
				90,
				315,
				225,
				270,
				45,
				135
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				180
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			}
		},
		new short[11][]
		{
			new short[3]
			{
				270,
				135,
				45
			},
			new short[3]
			{
				270,
				135,
				45
			},
			new short[3]
			{
				270,
				135,
				45
			},
			new short[4]
			{
				270,
				135,
				45,
				90
			},
			new short[4]
			{
				270,
				135,
				45,
				90
			},
			new short[5]
			{
				270,
				135,
				45,
				90,
				315
			},
			new short[6]
			{
				270,
				135,
				45,
				90,
				315,
				235
			},
			new short[7]
			{
				270,
				135,
				45,
				90,
				315,
				235,
				180
			},
			new short[7]
			{
				270,
				135,
				45,
				90,
				315,
				235,
				0
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			}
		},
		new short[11][]
		{
			new short[3]
			{
				180,
				45,
				315
			},
			new short[3]
			{
				180,
				45,
				315
			},
			new short[3]
			{
				180,
				45,
				315
			},
			new short[4]
			{
				180,
				45,
				315,
				0
			},
			new short[4]
			{
				180,
				45,
				315,
				0
			},
			new short[5]
			{
				180,
				45,
				315,
				0,
				135
			},
			new short[6]
			{
				180,
				45,
				315,
				0,
				135,
				225
			},
			new short[7]
			{
				180,
				45,
				315,
				0,
				135,
				225,
				270
			},
			new short[8]
			{
				180,
				45,
				315,
				0,
				135,
				225,
				270,
				90
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			}
		},
		new short[11][]
		{
			new short[3]
			{
				0,
				135,
				225
			},
			new short[3]
			{
				0,
				135,
				225
			},
			new short[3]
			{
				0,
				135,
				225
			},
			new short[4]
			{
				0,
				135,
				225,
				180
			},
			new short[4]
			{
				0,
				135,
				225,
				180
			},
			new short[5]
			{
				0,
				135,
				225,
				180,
				45
			},
			new short[6]
			{
				0,
				135,
				225,
				180,
				45,
				90
			},
			new short[7]
			{
				0,
				135,
				225,
				180,
				45,
				90,
				270
			},
			new short[8]
			{
				0,
				135,
				225,
				180,
				45,
				90,
				270,
				315
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			},
			new short[7]
			{
				90,
				315,
				225,
				270,
				45,
				135,
				0
			}
		}
	};

	private int lvSkill;

	private int ID;

	private sbyte nDragon = 1;

	private int loop;

	public Skill_Kiem_Type3(int id)
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
		if (c != null)
		{
			base.updateSkill(c);
			try
			{
				if (c.state != 0)
				{
					if (c.p1 == 16)
					{
						loop = 0;
					}
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
							EffectManager.addHiEffect(c.x + SkillAnimate.splashKiemX[c.dir], c.y + SkillAnimate.splashKiemY[c.dir], 3);
							if (ID == 1)
							{
								EffectManager.addHiEffect(c.x, c.y - 15, 24);
							}
						}
						c.frame = 4;
						c.weapon_frame = 4;
					}
					if (c.p1 == 9 && lvSkill > 0)
					{
						if (ID == 0)
						{
							for (int i = 0; i < angle[c.dir][lvSkill - 1].Length; i++)
							{
								Canvas.gameScr.startNewMagicBeam(1, c, c.attackTarget, c.x + SkillAnimate.splashKiemX[c.dir] + x2[i], c.y + SkillAnimate.splashKiemY[c.dir] + y2[i], (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, angle[c.dir][lvSkill - 1][i]);
							}
						}
						else if (ID == 1)
						{
							if (loop <= (lvSkill - 1) / 2)
							{
								Canvas.gameScr.startNewArrow(7, c, c.attackTarget, c.x + SkillAnimate.splashKiemX[c.dir], c.y - 25, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, 7);
								Canvas.gameScr.startNewArrow(7, c, c.attackTarget, c.x + SkillAnimate.splashKiemX[c.dir] + 10, c.y - 15, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, 7);
								Canvas.gameScr.startNewArrow(8, c, c.attackTarget, c.x + SkillAnimate.splashKiemX[c.dir] - 10, c.y - 55, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, 7);
								Canvas.gameScr.startNewArrow(1, c, c.attackTarget, c.x + SkillAnimate.splashKiemX[c.dir] + 20, c.y - 35, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, 7);
								Canvas.gameScr.startNewArrow(1, c, c.attackTarget, c.x + SkillAnimate.splashKiemX[c.dir] - 20, c.y - 45, (c.attkPower == 2000000) ? c.attkPower : (c.attkPower / nDragon), c.attkEffect, 7);
							}
							loop++;
							if (loop < nDragon)
							{
								c.p1 = 7;
							}
						}
					}
					c.p1++;
				}
			}
			catch (Exception)
			{
				Out.println("error kiem");
			}
		}
	}

	public override void updateSkill(Monster c)
	{
	}
}
