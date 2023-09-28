public class Explode : Exp
{
	private int f;

	private int p;

	private static sbyte[] eff = new sbyte[1]
	{
		15
	};

	private static sbyte[][] frame = new sbyte[1][]
	{
		new sbyte[8]
		{
			0,
			1,
			2,
			1,
			0,
			1,
			2,
			0
		}
	};

	private byte type;

	public Explode(int x, int y, int typeEff)
	{
		base.x = x;
		base.y = y;
		type = (byte)typeEff;
	}

	public override void paint(MyGraphics g)
	{
		Res.paintImgEff(g, eff[type], 0, frame[type][f] * Effect.HEIGHT[eff[type]], Effect.WIDTH[eff[type]], Effect.HEIGHT[eff[type]], x, y, MyGraphics.BOTTOM | MyGraphics.HCENTER);
	}

	public override void update()
	{
		p++;
		if (p % 2 == 0)
		{
			f++;
			if (f >= frame[type].Length)
			{
				f = 0;
				destroy = true;
			}
		}
	}
}
