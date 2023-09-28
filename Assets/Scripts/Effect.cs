public class Effect
{
	public const sbyte TYPE_ICE = 10;

	public const sbyte TYPE_LIGHT = 11;

	public const sbyte TYPE_POISON = 12;

	public static readonly sbyte[][] FRAME = new sbyte[63][]
	{
		new sbyte[2],
		new sbyte[18]
		{
			17,
			16,
			15,
			14,
			13,
			12,
			11,
			10,
			9,
			8,
			7,
			6,
			5,
			4,
			3,
			2,
			1,
			0
		},
		new sbyte[8]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7
		},
		new sbyte[1],
		new sbyte[15]
		{
			0,
			1,
			2,
			3,
			4,
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4
		},
		new sbyte[2]
		{
			0,
			1
		},
		new sbyte[9]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8
		},
		new sbyte[3]
		{
			0,
			1,
			1
		},
		new sbyte[12]
		{
			5,
			5,
			5,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8
		},
		new sbyte[1],
		new sbyte[2]
		{
			0,
			1
		},
		new sbyte[2]
		{
			0,
			1
		},
		new sbyte[4]
		{
			0,
			0,
			1,
			1
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[9]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		},
		new sbyte[6]
		{
			0,
			0,
			1,
			1,
			2,
			2
		},
		new sbyte[8]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[36]
		{
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[5]
		{
			0,
			1,
			2,
			3,
			4
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[18]
		{
			17,
			16,
			15,
			14,
			13,
			12,
			11,
			10,
			9,
			8,
			7,
			6,
			5,
			4,
			3,
			2,
			1,
			0
		},
		new sbyte[9]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		},
		new sbyte[1],
		new sbyte[8]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3
		},
		new sbyte[8]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3
		},
		new sbyte[6]
		{
			0,
			0,
			0,
			1,
			1,
			1
		},
		new sbyte[10]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4
		},
		new sbyte[5]
		{
			0,
			1,
			2,
			3,
			4
		},
		new sbyte[5]
		{
			0,
			1,
			2,
			3,
			4
		},
		new sbyte[5]
		{
			0,
			1,
			2,
			3,
			4
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[4]
		{
			0,
			1,
			2,
			3
		},
		new sbyte[3]
		{
			0,
			1,
			2
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
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[4]
		{
			0,
			1,
			2,
			3
		},
		new sbyte[9]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[8]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3
		},
		new sbyte[23]
		{
			0,
			0,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2
		},
		new sbyte[42]
		{
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			0,
			0,
			0,
			0
		},
		new sbyte[9]
		{
			0,
			1,
			2,
			0,
			1,
			2,
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[2]
		{
			0,
			1
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
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[3]
		{
			0,
			1,
			2
		},
		new sbyte[1],
		new sbyte[1],
		new sbyte[6]
		{
			0,
			1,
			2,
			3,
			4,
			5
		}
	};

	public static readonly sbyte[] WIDTH = new sbyte[63]
	{
		52,
		11,
		12,
		41,
		14,
		32,
		12,
		32,
		10,
		32,
		16,
		32,
		32,
		58,
		64,
		17,
		31,
		22,
		32,
		25,
		25,
		25,
		21,
		25,
		24,
		21,
		21,
		21,
		32,
		11,
		40,
		0,
		12,
		14,
		24,
		24,
		25,
		24,
		27,
		27,
		39,
		27,
		40,
		32,
		42,
		45,
		32,
		42,
		32,
		16,
		35,
		38,
		53,
		88,
		55,
		50,
		40,
		42,
		32,
		50,
		10,
		44,
		50
	};

	public static readonly sbyte[] HEIGHT = new sbyte[63]
	{
		18,
		11,
		12,
		38,
		14,
		32,
		12,
		32,
		10,
		32,
		100,
		32,
		32,
		38,
		46,
		36,
		32,
		22,
		32,
		14,
		17,
		15,
		34,
		27,
		35,
		34,
		34,
		34,
		31,
		11,
		31,
		0,
		13,
		14,
		15,
		22,
		16,
		23,
		27,
		27,
		25,
		28,
		76,
		28,
		41,
		46,
		32,
		41,
		32,
		16,
		36,
		49,
		28,
		60,
		55,
		51,
		76,
		41,
		32,
		26,
		10,
		44,
		50
	};

	public int x;

	public int y;

	public int w;

	public int h;

	public short type;

	public int f;

	public bool wantDetroy;

	public LiveActor myChar;

	public sbyte loop;

	public sbyte yadd;

	public SubEff subEff;

	public SubArrow subArr;

	public Effect(int s)
	{
	}

	public Effect()
	{
	}

	public Effect(int x, int y, int type)
	{
		this.x = x;
		this.y = y;
		this.type = (short)type;
		w = WIDTH[type];
		h = HEIGHT[type];
		f = -1;
	}

	public static sbyte getWidth(int id)
	{
		return WIDTH[id];
	}

	public static sbyte getHeight(int id)
	{
		return HEIGHT[id];
	}

	public virtual void paint(MyGraphics g)
	{
		if (type >= 0)
		{
			if (f == -1)
			{
				f = 0;
			}
			Res.paintImgEff(g, type, 0, FRAME[type][f] * h, w, h, x, y, MyGraphics.VCENTER | MyGraphics.HCENTER);
		}
	}

	public virtual void update()
	{
		if (myChar != null)
		{
			x = myChar.x;
			y = myChar.y + yadd;
		}
		f++;
		if (f < FRAME[type].Length)
		{
			return;
		}
		f = 0;
		if (loop == 0)
		{
			wantDetroy = true;
			if (subEff != null)
			{
				Effect effect = GameScr.creatEff(subEff.ac, subEff.ac.x, subEff.ac.y, subEff.idEff);
				EffectManager.hiEffects.addElement(effect);
				effect.subArr = new SubArrow();
				effect.subArr.from = subEff.ac;
				effect.subArr.to = subEff.target;
				effect.subArr.power = subEff.power;
				effect.subArr.hp = subEff.hp;
				effect.subArr.imgIndex = subEff.indeximg;
				effect.subArr.ideff = subEff.eff;
				subEff = null;
			}
			if (subArr != null)
			{
				for (int i = 0; i < subArr.to.size(); i++)
				{
					LiveActor liveActor = (LiveActor)subArr.to.elementAt(i);
					int power = int.Parse((string)subArr.power.elementAt(i));
					GameScr.createNewSkill(subArr.from, liveActor, power, (sbyte)subArr.ideff, subArr.imgIndex);
					liveActor.hp = int.Parse((string)subArr.hp.elementAt(i));
				}
				subArr = null;
			}
		}
		else
		{
			loop--;
		}
	}
}
