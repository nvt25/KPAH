public class MagicBeam : IArrow
{
	public int power;

	public int type;

	public sbyte effect;

	public int hpLost;

	public int frame;

	public int w;

	public int h;

	public int x;

	public int y;

	private LiveActor owner;

	public static Image imgFire;

	private MagicLogic arrow = new MagicLogic();

	public static int[] HEADINDEX = new int[11]
	{
		-1,
		-1,
		-1,
		4,
		3,
		4,
		6,
		-1,
		7,
		16,
		19
	};

	private sbyte[][] frameFly = new sbyte[3][]
	{
		new sbyte[4]
		{
			0,
			0,
			1,
			1
		},
		new sbyte[4]
		{
			2,
			2,
			3,
			3
		},
		new sbyte[4]
		{
			4,
			4,
			5,
			5
		}
	};

	private byte framelocxuay;

	private sbyte fra;

	public override void setAngle(int angle)
	{
		arrow.setAngle(angle);
	}

	public override void set(int type, int x, int y, int power, sbyte effect, LiveActor owner, LiveActor target)
	{
		arrow.set(type, x, y, owner.dir, target);
		this.type = type;
		this.owner = owner;
		this.effect = effect;
		if (type == 20)
		{
			type = 2;
		}
		hpLost = power;
		this.power = power;
	}

	public override void update()
	{
		arrow.updateAngle();
		x = arrow.x;
		y = arrow.y;
		if (arrow.isEnd)
		{
			onArrowTouchTarget();
		}
		switch (type)
		{
		case 0:
			EffectManager.addHiEffect(x, y, 1);
			break;
		case 5:
		case 7:
			EffectManager.addHiEffect(x, y, 29);
			break;
		case 1:
			EffectManager.addHiEffect(x, y, 2);
			break;
		case 2:
			EffectManager.addHiEffect(x, y, 4);
			break;
		case 3:
			EffectManager.addHiEffect(x, y, 6);
			EffectManager.addHiEffect(x, y, 7);
			break;
		case 4:
			EffectManager.addHiEffect(x, y, 8);
			break;
		case 9:
		{
			EffectManager.addLowEffect(x, y + 25, 59);
			Eff_da_vang ef = new Eff_da_vang(x, y + 25);
			EffectManager.addLowEffect(ef);
			ef = null;
			ef = new Eff_da_vang(x, y + 25);
			EffectManager.addLowEffect(ef);
			framelocxuay++;
			if (framelocxuay > 3)
			{
				framelocxuay = 0;
			}
			break;
		}
		case 10:
			frame++;
			if (frame > frameFly[arrow.headArrowFrame].Length - 1)
			{
				frame = 0;
			}
			fra = frameFly[arrow.headArrowFrame][frame];
			break;
		}
	}

	public override void onArrowTouchTarget()
	{
		short num = arrow.target.x;
		short num2 = arrow.target.y;
		switch (type)
		{
		case 0:
			Canvas.gameScr.startExplosionAt(num, num2);
			break;
		case 1:
			EffectManager.addHiEffect(num, num2 - 10, 3);
			EffectManager.addLowEffect(num, num2 - 25, 11);
			EffectManager.addHiEffect(num, num2 - 15, 11);
			EffectManager.addHiEffect(num - 10, num2 - 20, 11);
			EffectManager.addHiEffect(num + 10, num2 - 20, 11);
			break;
		case 2:
			EffectManager.addHiEffect(num, num2 - 10, 5);
			break;
		case 3:
			EffectManager.addHiEffect(num, num2 - 10, 7);
			break;
		case 4:
			EffectManager.addLowEffect(num, num2 - 25, 15);
			EffectManager.addHiEffect(num, num2 - 15, 15);
			EffectManager.addHiEffect(num - 10, num2 - 20, 15);
			EffectManager.addHiEffect(num + 10, num2 - 20, 15);
			break;
		case 5:
		case 7:
			EffectManager.addHiEffect(num, num2 - 10, 30);
			break;
		case 8:
			EffectManager.addHiEffect(num, num2 - 10, 3);
			EffectManager.addLowEffect(num, num2 - 25, 11);
			EffectManager.addHiEffect(num, num2 - 15, 9);
			EffectManager.addHiEffect(num - 10, num2 - 20, 11);
			EffectManager.addHiEffect(num + 10, num2 - 20, 9);
			break;
		case 9:
			EffectManager.addHiEffect(num, num2 - 15, 50);
			break;
		case 10:
			EffectManager.addHiEffect(num, num2 - 15, 58);
			break;
		}
		if (effect != 0 && effect < AttackResult.EFF_NAME.Length)
		{
			Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[effect], 0, num, num2 - 25, 1, -2);
		}
		if (power != 2000000)
		{
			if (power != 0)
			{
				if (type < 20)
				{
					Canvas.gameScr.startFlyText("-" + power, 0, num, num2 - 15, 1, -2);
				}
				else
				{
					Canvas.gameScr.startFlyText("-" + hpLost, 0, num, num2 - 15, 1, -2);
				}
			}
			else
			{
				Canvas.gameScr.startFlyText("MISS", 0, num, num2 - 15, 1, -2);
			}
		}
		arrow.target.realHPSyncTime = 2;
		if (arrow.target.catagory == Actor.CAT_MONSTER)
		{
			if (effect == 0)
			{
				((Monster)arrow.target).jump();
				EffectManager.hiEffects.addElement(new Effect(num, num2 - 10, 11));
			}
			else if (effect == 2)
			{
				((Monster)arrow.target).doublejump();
				EffectManager.hiEffects.addElement(new Effect(num, num2 - 10, 12));
			}
		}
		else if (arrow.target.catagory == Actor.CAT_PLAYER)
		{
			if (effect == 0)
			{
				((Char)arrow.target).jump();
				EffectManager.hiEffects.addElement(new Effect(num, num2 - 10, 11));
			}
			else if (effect == 2)
			{
				((Char)arrow.target).doublejump();
				EffectManager.hiEffects.addElement(new Effect(num, num2 - 10, 12));
			}
		}
		wantDestroy = true;
	}

	public override void paint(MyGraphics g)
	{
		if (type < 20)
		{
			if (HEADINDEX[type] == -1)
			{
				return;
			}
			int num = HEADINDEX[type];
			if (Res.getImgArrow(num) != null)
			{
				if (type != 10 && type != 9)
				{
					g.drawRegion(Res.imgArrow[num], 0, arrow.headArrowFrame * Arrow.ARROWSIZE[1][num], Arrow.ARROWSIZE[0][num], Arrow.ARROWSIZE[1][num], arrow.headTransform, x, y, 3);
				}
				else if (type == 10)
				{
					g.drawRegion(Res.imgArrow[num], 0, fra * Arrow.ARROWSIZE[1][num], Arrow.ARROWSIZE[0][num], Arrow.ARROWSIZE[1][num], arrow.headTransform, x, y, 3);
				}
				else if (type == 9)
				{
					g.drawRegion(Res.imgArrow[num], 0, framelocxuay * Arrow.ARROWSIZE[1][num], Arrow.ARROWSIZE[0][num], Arrow.ARROWSIZE[1][num], 0, x, y, 3);
				}
			}
		}
		else
		{
			g.drawImage(imgFire, x, y, 3);
		}
	}
}
