public class Skill_TruRong : Effect
{
	private int[] xw;

	private int[] yw;

	public int dx;

	public int dy;

	public int pos;

	public int time;

	public int lim;

	public int height;

	public int xto;

	public int yto;

	public int imgIndex;

	private sbyte frame;

	private sbyte frame1;

	private int TimeStarAtack;

	private bool isShot;

	private LiveActor target;

	public Skill_TruRong(int x, int y, int xto, int yto, LiveActor target, int timeAtt)
	{
		this.target = target;
		base.x = x;
		base.y = y + 30;
		this.xto = xto;
		this.yto = yto;
		imgIndex = 15;
		lim = y - 60;
		TimeStarAtack = timeAtt;
		setspeed();
	}

	public void setspeed()
	{
		dx = xto - x;
		dy = yto - lim;
		int num = (Math.abs(dx) + Math.abs(dy)) / 20;
		if (num < 2)
		{
			num = 2;
		}
		xw = new int[num];
		yw = new int[num];
		for (int i = 0; i < num; i++)
		{
			xw[i] = x + i * dx / num;
			yw[i] = lim + i * dy / num;
		}
	}

	public override void paint(MyGraphics g)
	{
		if (TimeStarAtack < 0)
		{
			if (y > lim)
			{
				g.drawRegion(Res.getImgeffect(55), 0, frame1 * Res.getImgeffect(55).getHeight() / 2, Res.getImgeffect(55).getWidth(), Res.getImgeffect(55).getHeight() / 2, 0, x, y, MyGraphics.VCENTER | MyGraphics.HCENTER);
			}
			if (isShot && Res.getImgArrow(imgIndex) != null)
			{
				g.drawRegion(Res.imgArrow[imgIndex], 0, frame * Arrow.ARROWSIZE[1][imgIndex], Arrow.ARROWSIZE[0][imgIndex], Arrow.ARROWSIZE[1][imgIndex], 0, xw[pos], yw[pos], 3);
			}
		}
	}

	public override void update()
	{
		frame = (sbyte)((frame + 1) % 3);
		frame1 = (sbyte)((frame1 + 1) % 2);
		if (TimeStarAtack >= 0)
		{
			TimeStarAtack--;
		}
		if (TimeStarAtack >= 0)
		{
			return;
		}
		if (y > lim)
		{
			y -= 10;
		}
		if (y <= lim && time <= 6)
		{
			time++;
		}
		if (time == 2)
		{
			EffectManager.addHiEffect(x, y, 54);
		}
		if (time >= 6 && !isShot)
		{
			isShot = true;
		}
		if (time > 6 && pos < xw.Length)
		{
			pos++;
		}
		if (pos >= xw.Length)
		{
			pos = xw.Length - 1;
			xw[pos] = xto;
			yw[pos] = yto;
			EffectManager.addLowEffect(xto, yto, 53);
			wantDetroy = true;
			if (target != null && target.damAttack != 0 && target.damAttack != 2000000)
			{
				Canvas.gameScr.startFlyText("-" + target.damAttack, 0, target.x, target.y + target.dy - 15, 1, -2);
			}
		}
	}
}
