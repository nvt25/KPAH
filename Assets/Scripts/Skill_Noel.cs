public class Skill_Noel : Effect
{
	private int[] xw;

	private int[] yw;

	public int dx;

	public int dy;

	public int angle;

	public int pos;

	public int frame;

	public int height;

	public int xto;

	public int yto;

	private LiveActor target;

	public Skill_Noel(int x, int y, int xto, int yto, LiveActor target)
	{
		this.target = target;
		base.x = x;
		base.y = y;
		this.xto = xto;
		this.yto = yto;
		setspeed();
	}

	public void setspeed()
	{
		dx = xto - x;
		dy = yto - y;
		angle = Util.angle(dx, dy);
		int num = (Math.abs(dx) + Math.abs(dy)) / 30;
		if (num < 2)
		{
			num = 2;
		}
		xw = new int[num];
		yw = new int[num];
		for (int i = 0; i < num; i++)
		{
			xw[i] = x + i * dx / num;
			yw[i] = y + i * dy / num;
		}
	}

	public void createEfect(int x, int y, int type)
	{
		Effect ef = new Effect(x, y, type);
		EffectManager.addLowEffect(ef);
	}

	public override void update()
	{
		if (pos >= 1)
		{
			createEfect(xw[pos] + 3, yw[pos] + 15, 52);
			createEfect(xw[pos], yw[pos], 51);
		}
		if (pos < xw.Length)
		{
			pos++;
		}
		if (pos >= xw.Length)
		{
			pos = xw.Length - 1;
			xw[pos] = xto;
			yw[pos] = yto;
			createEfect(xw[pos] + 3, yw[pos] + 15, 52);
			createEfect(xw[pos], yw[pos], 51);
			wantDetroy = true;
			if (target != null && target.damAttack != 0 && target.damAttack != 2000000)
			{
				Canvas.gameScr.startFlyText("-" + target.damAttack, 0, target.x, target.y + target.dy - 15, 1, -2);
			}
		}
	}
}
