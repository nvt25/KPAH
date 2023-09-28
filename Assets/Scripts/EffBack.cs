public class EffBack : Effect
{
	private short[] xE;

	private short[] yE;

	private sbyte[] index;

	private sbyte[] count;

	public new int type;

	public int limit;

	public int w0;

	public int h0;

	private bool isEffVong;

	private bool isEffUpDown;

	private int aa;

	public EffBack(int x, int y, int type, int limit, int w, int h, bool isEffVong, bool isEffUpDown)
	{
		this.isEffVong = isEffVong;
		w0 = w;
		h0 = h;
		this.limit = limit;
		this.type = type;
		base.x = x;
		base.y = y;
		xE = new short[6];
		yE = new short[6];
		index = new sbyte[6];
		count = new sbyte[6];
		for (int i = 0; i < 6; i++)
		{
			xE[i] = (short)(x - 10 + Res.rnd(20) - 10);
			yE[i] = (short)(y + Res.rnd(20));
			index[i] = (sbyte)Res.rnd(6);
		}
		this.isEffUpDown = isEffUpDown;
	}

	public override void update()
	{
		for (int i = 0; i < xE.Length; i++)
		{
			index[i]++;
			if (index[i] < limit * 3)
			{
				continue;
			}
			xE[i] = (short)(x + Res.rnd(30) - 15);
			yE[i] = (short)(y + Res.rnd(14) + 3);
			index[i] = (sbyte)Res.rnd(6);
			count[i]++;
			if (count[i] > 3)
			{
				if (!isEffUpDown)
				{
					EffectManager.lowEffects.removeElement(this);
				}
				else
				{
					EffectManager.hiEffects.removeElement(this);
				}
			}
		}
		aa++;
		if (aa >= 6)
		{
			aa = 0;
		}
	}

	public override void paint(MyGraphics g)
	{
		for (int i = 0; i < 6; i++)
		{
			Res.paintImgEff(g, type, 0, index[i] / 3 * h0, w0, h0, xE[i], yE[i], MyGraphics.BOTTOM | MyGraphics.HCENTER);
		}
		if (isEffVong)
		{
			Res.paintImgEff(g, 13, 0, aa / 2 * 38, 58, 38, x, y - 3, 3);
		}
	}
}
