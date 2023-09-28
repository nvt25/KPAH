public class Skill_AEO_Dao_5 : Effect
{
	private LiveActor c;

	private bool isNo;

	private bool isEff;

	private int angle;

	private int dis;

	private int countDown;

	private int v;

	private int xGoc;

	private int yGoc;

	private int[] index;

	public string[] textAttack;

	private new int type;

	public bool isDoubleDregon;

	private static sbyte[][] indexImg = new sbyte[3][]
	{
		new sbyte[2]
		{
			15,
			28
		},
		new sbyte[2]
		{
			4,
			4
		},
		new sbyte[2]
		{
			15,
			28
		}
	};

	private static byte[][] wImg = new byte[6][]
	{
		new byte[2]
		{
			17,
			36
		},
		new byte[2]
		{
			32,
			31
		},
		new byte[2]
		{
			14,
			14
		},
		new byte[2]
		{
			14,
			14
		},
		new byte[2]
		{
			17,
			36
		},
		new byte[2]
		{
			17,
			36
		}
	};

	private static byte[] indexLimit1 = new byte[3]
	{
		3,
		5,
		3
	};

	public Skill_AEO_Dao_5(int x0, int y0, LiveActor c, int t, bool isEff)
	{
		this.isEff = isEff;
		type = t;
		x = c.x;
		y = c.y - 10;
		xGoc = x0;
		yGoc = y0 - 40;
		this.c = c;
		angle = Util.angle(c.x - 10 - xGoc, -(c.y - yGoc));
		dis = Util.distance(xGoc, yGoc, c.x - 10, c.y);
		index = new int[3];
		for (int i = 0; i < 3; i++)
		{
			index[i] = Res.rnd(6);
		}
		textAttack = new string[2];
	}

	public override void update()
	{
		angle = Util.angle(x - xGoc, -(y - yGoc));
		dis = Util.distance(xGoc, yGoc, x, y);
		countDown += 6;
		v++;
		if (!isNo)
		{
			x = c.x;
			y = c.y - 10;
		}
		if (countDown <= dis || isNo)
		{
			return;
		}
		EffectManager.addHiEffect(c.x, c.y - 10, 12);
		EffectManager.hiEffects.removeElement(this);
		if (c.catagory == 1)
		{
			((Monster)c).isTarget = false;
		}
		c.jump();
		isNo = true;
		if (textAttack[0] != null)
		{
			Canvas.gameScr.startFlyText(textAttack[0], 0, x, y - 15, 1, -2);
		}
		if (textAttack[1] != null)
		{
			Canvas.gameScr.startFlyText(textAttack[1], 0, x, y - 15, 2, -2);
		}
		if (!isEff)
		{
			return;
		}
		EffBack effBack = null;
		if (type == 1)
		{
			effBack = new EffBack(x, y, 4, 5, 14, 14, isEffVong: false, isEffUpDown: false);
		}
		else
		{
			effBack = new EffBack(x, y, 28, 3, 32, 31, isEffVong: true, isEffUpDown: false);
			if (type == 2)
			{
				Skill_AEO_DUA_DAO_5 skill_AEO_DUA_DAO_ = new Skill_AEO_DUA_DAO_5(c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c, c, 5);
				skill_AEO_DUA_DAO_.isDoubleDragon = isDoubleDregon;
				EffectManager.hiEffects.addElement(skill_AEO_DUA_DAO_);
			}
		}
		EffectManager.lowEffects.addElement(effBack);
	}

	public override void paint(MyGraphics g)
	{
		int num = countDown * Util.Cos(Util.fixangle(angle)) >> 10;
		int num2 = -(countDown * Util.Sin(Util.fixangle(angle))) >> 10;
		g.drawImage(Res.imgShadow, xGoc + num, yGoc + num2, 3);
		for (int i = 0; i < 3; i++)
		{
			Res.paintImgEff(g, indexImg[type][0], 0, index[i] / 2 * wImg[type * 2][1], wImg[type * 2][0], wImg[type * 2][1], xGoc + num + Res.rnd(10) - 5, yGoc + num2 + Res.rnd(10) - 10, 3);
			index[i]++;
			if (index[i] >= indexLimit1[type])
			{
				index[i] = 0;
			}
		}
	}
}
