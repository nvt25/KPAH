public class Arrow : IArrow
{
	public static int[] ARROWINDEX = new int[18]
	{
		0,
		15,
		37,
		52,
		75,
		105,
		127,
		142,
		165,
		195,
		217,
		232,
		255,
		285,
		307,
		322,
		345,
		370
	};

	public Effect end;

	public int power;

	public sbyte effect;

	public sbyte typeEffEnd = -1;

	private LiveActor target;

	private int[] xw;

	private int[] yw;

	private int frame;

	private int transform;

	private int pos;

	private int imgIndex;

	public static sbyte[][] ARROWSIZE = new sbyte[2][]
	{
		new sbyte[20]
		{
			16,
			24,
			36,
			24,
			24,
			36,
			17,
			28,
			28,
			73,
			32,
			14,
			21,
			56,
			56,
			42,
			46,
			24,
			29,
			32
		},
		new sbyte[20]
		{
			16,
			24,
			36,
			24,
			24,
			36,
			17,
			28,
			28,
			73,
			32,
			13,
			16,
			54,
			54,
			41,
			50,
			24,
			28,
			32
		}
	};

	public static int[] TRANSFORM = new int[16]
	{
		0,
		0,
		0,
		7,
		6,
		6,
		6,
		2,
		2,
		3,
		3,
		4,
		5,
		5,
		5,
		1
	};

	public static sbyte[] FRAME = new sbyte[25]
	{
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0
	};

	private int frameRun;

	public Arrow(int imgIndex)
	{
		this.imgIndex = imgIndex;
	}

	public override void setAngle(int angle)
	{
	}

	public override void onArrowTouchTarget()
	{
		if (power != 0 && power != 2000000)
		{
			Canvas.gameScr.startFlyText("-" + power, 0, target.x, target.y + target.dy - 15, 1, -2);
		}
		if (this.effect != 0 && this.effect < AttackResult.EFF_NAME.Length)
		{
			Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[this.effect], 0, target.x, target.y + target.dy - 15, 2, -2);
		}
		target.realHPSyncTime = 2;
		if (target.catagory == 1)
		{
			if (this.effect == 0)
			{
				((Monster)target).jump();
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 11);
			}
			else if (this.effect == 2)
			{
				((Monster)target).doublejump();
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 12);
			}
		}
		if (this.effect != 1)
		{
			if (imgIndex == 1)
			{
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 9);
			}
			if (imgIndex == 2)
			{
				EffectManager.addHiEffect(target.x - 10, target.y + target.dy, 16);
				EffectManager.addHiEffect(target.x + 10, target.y + target.dy, 16);
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 16);
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 16);
			}
			if (imgIndex == 5)
			{
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 30);
			}
			if (imgIndex == 7)
			{
				Skill_Eff_end o = new Skill_Eff_end(target.x, target.y + target.dy, transform);
				EffectManager.hiEffects.addElement(o);
				EffectManager.lowEffects.addElement(o);
			}
			if (imgIndex == 8)
			{
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 11);
			}
			if (imgIndex == 13)
			{
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 50);
			}
			if (imgIndex == 18)
			{
				EffectManager.addHiEffect(target.x, target.y + target.dy - 10, 50);
			}
			if (typeEffEnd != -1)
			{
				Effect effect = new Effect(target.x, target.y - target.height / 2, typeEffEnd);
				effect.loop = (sbyte)((typeEffEnd != 30) ? 1 : 0);
				EffectManager.hiEffects.addElement(effect);
			}
		}
		wantDestroy = true;
	}

	public override void paint(MyGraphics g)
	{
		if (Res.getImgArrow(imgIndex) != null)
		{
			if (imgIndex == 18)
			{
				g.drawRegion(Res.imgArrow[imgIndex], 0, frameRun * ARROWSIZE[1][imgIndex], ARROWSIZE[0][imgIndex], ARROWSIZE[1][imgIndex], 0, xw[pos], yw[pos], 3);
			}
			else
			{
				g.drawRegion(Res.imgArrow[imgIndex], 0, frame * ARROWSIZE[1][imgIndex], ARROWSIZE[0][imgIndex], ARROWSIZE[1][imgIndex], transform, xw[pos], yw[pos], 3);
			}
		}
	}

	public override void set(int type, int x, int y, int power, sbyte effect, LiveActor owner, LiveActor target)
	{
		this.effect = effect;
		this.target = target;
		this.power = power;
		int num = 0;
		int num2 = 0;
		num = target.x - x;
		num2 = target.y + target.dy - y;
		switch (type)
		{
		case 7:
			num = target.x + 10 - x;
			num2 = target.y + target.dy - y;
			break;
		case 8:
			num = target.x - 10 - x;
			num2 = target.y - 10 + target.dy - y;
			break;
		}
		int num3 = (GameScr.abs(num) + GameScr.abs(num2)) / 20;
		if (num3 < 2)
		{
			num3 = 2;
		}
		xw = new int[num3];
		yw = new int[num3];
		for (int i = 1; i < num3; i++)
		{
			xw[i] = x + i * num / num3;
			yw[i] = y + i * num2 / num3;
		}
		int num4 = findDirIndexFromAngle(Util.angle(num, -num2));
		if (num4 < FRAME.Length)
		{
			frame = FRAME[num4];
		}
		if (num4 < TRANSFORM.Length)
		{
			transform = TRANSFORM[num4];
		}
	}

	public static int findDirIndexFromAngle(int angle)
	{
		for (int i = 0; i < ARROWINDEX.Length - 1; i++)
		{
			if (angle >= ARROWINDEX[i] && angle <= ARROWINDEX[i + 1])
			{
				if (i >= 16)
				{
					return 0;
				}
				return i;
			}
		}
		return 0;
	}

	public override void update()
	{
		if (imgIndex == 18)
		{
			frameRun = (frameRun + 1) % 4;
		}
		pos++;
		if (pos >= xw.Length)
		{
			pos = xw.Length;
		}
		if (pos == xw.Length)
		{
			onArrowTouchTarget();
		}
	}
}
