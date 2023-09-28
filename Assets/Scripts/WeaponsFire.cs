public class WeaponsFire : IArrow
{
	private int va;

	private int vx;

	private int vy;

	private int angle;

	private int x;

	private int y;

	private int type;

	private int dx;

	private int dy;

	private int xTo;

	private int yTo;

	private int himg;

	private LiveActor live_To;

	private int frame;

	private int transform;

	private EffectLeg effleg;

	private int frameEff;

	private int saveDir;

	private bool isStartEff;

	public WeaponsFire(LiveActor live_From, LiveActor live_To, int type)
	{
		this.type = type;
		this.live_To = live_To;
		x = live_From.x;
		y = live_From.y - 54;
		xTo = live_To.x;
		yTo = live_To.y;
		angle = Util.angle(x - live_To.x, live_To.y - (live_To.height >> 1) - y);
		va = 24;
		vx = va * Util.Cos(angle) >> 10;
		vy = va * Util.Sin(angle) >> 10;
		himg = live_To.height;
		if (type < 6)
		{
			effleg = new EffectLeg(xTo, yTo, (type == 3) ? 1 : 0, 0, 0, 0, isEffVong: false, isEffUpDown: false);
			EffectManager.lowEffects.addElement(effleg);
		}
		y = live_From.y - 31;
		if (live_From.dir == Char.LEFT)
		{
			x = live_From.x - 30;
		}
		else if (live_From.dir == Char.RIGHT)
		{
			x = live_From.x + 30;
		}
		int num = Arrow.findDirIndexFromAngle(Util.angle(live_To.x - x, -(live_To.y + (live_To.height >> 1) - y)));
		frame = Arrow.FRAME[num];
		transform = Arrow.TRANSFORM[num];
	}

	public override void onArrowTouchTarget()
	{
	}

	public override void paint(MyGraphics g)
	{
		if (!isStartEff)
		{
			if (Res.getImgArrow(type) != null && type != 6 && type != 7)
			{
				g.drawRegion(Res.imgArrow[type], 0, frame * Arrow.ARROWSIZE[1][type], Arrow.ARROWSIZE[0][type], Arrow.ARROWSIZE[1][type], transform, x, y, 3);
			}
		}
		else if (Res.imgEffect[38] != null)
		{
			g.drawRegion(Res.imgEffect[38], 0, frameEff * 27, 27, 27, 0, xTo, yTo, 33);
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
		if (live_To != null)
		{
			xTo = live_To.x;
			yTo = live_To.y;
		}
		dx = xTo - x;
		dy = yTo - (himg >> 1) - y;
		angle = Util.angle(dx, dy);
		vx = va * Util.Cos(angle) >> 10;
		vy = va * Util.Sin(angle) >> 10;
		x += vx;
		y += vy;
		bool flag = false;
		bool flag2 = false;
		if (!isStartEff)
		{
			if (type < 6)
			{
				EffectManager.addHiEffect(x, y, (type != 3) ? 6 : 8);
			}
			else if (type == 6)
			{
				EffectManager.addHiEffect(x, y, 46);
			}
		}
		if (Res.isDestroy(x - 20, x + 20, xTo - himg / 2, xTo + himg / 2, y - 20, y + 20, yTo - himg / 2, yTo + himg / 2))
		{
			if (!isStartEff)
			{
				if (type == 3)
				{
					creatMyEff(live_To, 0, 0, 18);
					creatMyEff(live_To, 1, 0, 24);
					creatMyEff(live_To, 2, 0, 28);
					creatMyEff(live_To, 3, 0, 32);
				}
				else if (type < 6)
				{
					EffectManager.addHiEffect(xTo, yTo - 10, 30);
					if (Canvas.gameScr.arrowsDown.conTains(this))
					{
						Canvas.gameScr.arrowsDown.removeElement(this);
					}
					if (GameScr.arrowsUp.conTains(this))
					{
						GameScr.arrowsUp.removeElement(this);
					}
					live_To.doublejump();
					creatMyEff(live_To, 0, 1, 40);
					creatMyEff(live_To, 1, 1, 40);
					creatMyEff(live_To, 2, 1, 40);
					creatMyEff(live_To, 3, 1, 40);
				}
				else if (type == 6)
				{
					if (Canvas.gameScr.arrowsDown.conTains(this))
					{
						Canvas.gameScr.arrowsDown.removeElement(this);
					}
					if (GameScr.arrowsUp.conTains(this))
					{
						GameScr.arrowsUp.removeElement(this);
					}
					live_To.doublejump();
				}
			}
			isStartEff = true;
		}
		if (!isStartEff || Canvas.gameTick % 2 != 0)
		{
			return;
		}
		frameEff++;
		if (frameEff > 4)
		{
			if (Canvas.gameScr.arrowsDown.conTains(this))
			{
				Canvas.gameScr.arrowsDown.removeElement(this);
			}
			if (GameScr.arrowsUp.conTains(this))
			{
				GameScr.arrowsUp.removeElement(this);
			}
			isStartEff = false;
			frameEff = 0;
		}
	}

	public void creatMyEff(LiveActor l_To, int dir, int type, int va)
	{
		EffectTarget o = new EffectTarget(l_To, dir, type, va);
		EffectManager.hiEffects.addElement(o);
	}
}
