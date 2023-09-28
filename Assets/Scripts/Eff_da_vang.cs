public class Eff_da_vang : Effect
{
	public int vx;

	public int vy;

	public int t;

	public int y_changspeed;

	public int tt;

	private int[] arry = new int[3]
	{
		-10,
		12,
		0
	};

	public int[] time = new int[2]
	{
		0,
		1
	};

	public Image img;

	public Eff_da_vang(int x, int y)
	{
		base.x = x;
		base.y = y;
		vx = Canvas.random(-1, 3);
		t = Canvas.random(5, 10);
		y_changspeed = y + arry[Math.abs(Canvas.r.nextInt() % arry.Length)];
		tt = time[Math.abs(Canvas.r.nextInt() % time.Length)];
		img = Res.imgEffect[60];
	}

	public override void paint(MyGraphics g)
	{
		g.drawImage(img, x, y, 3);
	}

	public override void update()
	{
		if (tt >= 0)
		{
			tt--;
		}
		if (tt < 0)
		{
			x += vx;
			y += vy;
			if (vy < 10)
			{
				vy += 2;
			}
			if (y >= y_changspeed)
			{
				vy = -t;
				t /= 3;
			}
			if (t <= 2)
			{
				vx = 0;
				wantDetroy = true;
			}
		}
	}
}
