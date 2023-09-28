using System;

public class WeaponsAngleBoss : IArrow
{
	public int type;

	public int x;

	public int y;

	public int angle;

	public int typesize;

	public int power;

	public int xbg;

	public int ybg;

	public int upPower;

	public int angleTo;

	public int[] FLIP = new int[6]
	{
		0,
		2,
		1,
		3,
		7,
		4
	};

	private int index;

	public WeaponsAngleBoss(int angle, int power, LiveActor acFr, LiveActor acTo, int type, int addw, int addh, int xbg, int ybg, bool lastActo)
	{
		this.angle = angle;
		this.power = power;
		if (acFr != null)
		{
			this.xbg = acFr.x - addw;
			this.ybg = acFr.y - addh;
		}
		else
		{
			this.xbg = xbg;
			this.ybg = ybg;
		}
		this.type = type;
		typesize = typesize;
		if (lastActo && acTo != null)
		{
			acTo.jump();
			EffectManager.addHiEffect(acTo.x, acTo.y + acTo.dy - 10, 11);
			Canvas.gameScr.startFlyText("-" + acTo.damAttack, 0, acTo.x, acTo.y + acTo.dy - 15, 1, -2);
		}
		angleTo = angle;
	}

	public int getFlip(int angle)
	{
		switch (angle)
		{
		case 180:
		case 210:
		case 240:
			return 1;
		case 0:
		case 300:
		case 330:
			return 0;
		case 120:
		case 150:
			return 3;
		case 30:
		case 60:
			return 2;
		case 270:
			return 4;
		case 90:
			return 5;
		default:
			return 0;
		}
	}

	public override void onArrowTouchTarget()
	{
	}

	public int getIdFrame(int angle)
	{
		switch (angle)
		{
		case 30:
		case 150:
		case 210:
		case 330:
			return 1;
		case 60:
		case 120:
		case 240:
		case 300:
			return 2;
		default:
			return 0;
		}
	}

	public override void paint(MyGraphics g)
	{
		try
		{
			if (type != 0)
			{
				if (Res.imgEffect[34] == null)
				{
					Res.load.loadImgEffect(34);
				}
				else
				{
					g.drawRegion(Res.imgEffect[34], 0, index * 15, 24, 15, 0, x, y, 3);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void set(int type, int x, int y, int power, byte effect, LiveActor owner, LiveActor target)
	{
	}

	public override void setAngle(int angle)
	{
	}

	public override void update()
	{
		x = xbg + Util.Cos(angle) * power / 1024;
		y = ybg + Util.Sin(angle) * power / 1024;
		if (type == 0)
		{
			angleTo += 30;
			if (angleTo > 360)
			{
				angleTo -= 360;
			}
			if (angle != angleTo)
			{
				angle += 10;
				if (angle > 360)
				{
					angle -= 360;
				}
			}
			if (upPower < 15)
			{
				upPower += 2;
			}
			EffectManager.addHiEffect(x, y, 33);
		}
		else
		{
			if (upPower < 24)
			{
				upPower += 8;
			}
			if (Canvas.gameTick % 4 == 0)
			{
				if (index < 1)
				{
					index++;
				}
				else
				{
					index = 0;
				}
			}
		}
		power += upPower;
		if (x < GameScr.cmx - Canvas.w / 2 || x > GameScr.cmx + Canvas.w + Canvas.w / 2 || y < GameScr.cmy - Canvas.h / 2 || y > GameScr.cmy + Canvas.h + Canvas.h / 2)
		{
			if (Canvas.gameScr.arrowsDown.conTains(this))
			{
				Canvas.gameScr.arrowsDown.removeElement(this);
			}
			if (GameScr.arrowsUp.conTains(this))
			{
				GameScr.arrowsUp.removeElement(this);
			}
		}
	}
}
