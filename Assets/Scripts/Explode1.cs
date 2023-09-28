public class Explode1 : Exp
{
	private static sbyte[] frame = new sbyte[8]
	{
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1
	};

	private int f;

	private int degree;

	private Image img;

	private int xt;

	private int yt;

	private int d;

	private int delay = 10;

	private int delta = 10;

	public Explode1(Image img, int x, int y, int degree)
	{
		this.img = img;
		base.x = x;
		base.y = y;
		this.degree = degree;
	}

	public override void paint(MyGraphics g)
	{
		if (img != null)
		{
			g.drawImage(img, x + xt, y + yt, 20);
			Res.paintImgEff(g, 15, 0, frame[f] * Effect.HEIGHT[15], Effect.WIDTH[15], Effect.HEIGHT[15], x + xt + img.getWidth() / 2, y + yt + img.getHeight() / 2, MyGraphics.BOTTOM | MyGraphics.HCENTER);
			Res.paintImgEff(g, 15, 0, frame[f] * Effect.HEIGHT[15], Effect.WIDTH[15], Effect.HEIGHT[15], x + xt + img.getWidth() / 2 + 5, y + yt + img.getHeight() / 2, MyGraphics.BOTTOM | MyGraphics.HCENTER);
			Res.paintImgEff(g, 15, 0, frame[f] * Effect.HEIGHT[15], Effect.WIDTH[15], Effect.HEIGHT[15], x + xt + img.getWidth() / 2 - 5, y + yt + img.getHeight() / 2, MyGraphics.BOTTOM | MyGraphics.HCENTER);
			Res.paintImgEff(g, 15, 0, frame[f] * Effect.HEIGHT[15], Effect.WIDTH[15], Effect.HEIGHT[15], x + xt + img.getWidth() / 2 + 5, y + yt + img.getHeight() / 2 + 5, MyGraphics.BOTTOM | MyGraphics.HCENTER);
			Res.paintImgEff(g, 15, 0, frame[f] * Effect.HEIGHT[15], Effect.WIDTH[15], Effect.HEIGHT[15], x + xt + img.getWidth() / 2 - 5, y + yt + img.getHeight() / 2 + 5, MyGraphics.BOTTOM | MyGraphics.HCENTER);
		}
	}

	public override void update()
	{
		if (d < 100)
		{
			d += delta;
			xt = Util.Cos(degree) * d / 1024;
			yt = Util.Sin(degree) * d / 1024;
			delta += 10;
		}
		else
		{
			destroy = true;
		}
		if (Canvas.gameTick % 2 == 0)
		{
			f = (f + 1) % frame.Length;
		}
	}
}
