public class Skill_Da_Roi : Effect
{
	private short angle;

	private short v = 10;

	private short xGoc;

	private short yGoc;

	private short distant;

	private short angLimit;

	private short xFrom;

	private short yFrom;

	private short xTo;

	private short yTo;

	private short angHuong;

	private short dir;

	private short typeSkill;

	private int hpLost;

	public mVector list;

	private int xCu;

	private int yCu;

	private int[] index = new int[3]
	{
		0,
		2,
		4
	};

	public Skill_Da_Roi(int xTo, int yTo, int x, int y, int hpLost)
	{
		this.hpLost = hpLost;
		if (xTo < x)
		{
			dir = 1;
		}
		else
		{
			dir = -1;
		}
		this.xTo = (short)xTo;
		this.yTo = (short)yTo;
		base.x = (xFrom = (short)x);
		base.y = (yFrom = (short)y);
		angle = (short)Util.angle(xTo - x, -(yTo - y));
		angHuong = angle;
		int num = Util.distance(xTo, yTo, x, y);
		int num2 = num / 2 * Util.Cos(Util.fixangle(angle)) >> 10;
		int num3 = -(num / 2 * Util.Sin(Util.fixangle(angle))) >> 10;
		int num4 = Util.fixangle(angle + 90 * dir);
		int num5 = num / 3;
		int num6 = 0;
		num5 += 45 - ((angHuong >= 180) ? (Util.abs(angHuong - 270) / 2) : (Util.abs(angHuong - 90) / 2));
		int num7 = num5 * Util.Cos(Util.fixangle(num4)) >> 10;
		int num8 = -(num5 * Util.Sin(Util.fixangle(num4))) >> 10;
		xGoc = (short)(x + num2 + num7);
		yGoc = (short)(y + num3 + num8);
		distant = (short)Util.distance(xGoc, yGoc, x, y);
		angle = (short)Util.angle(x - xGoc, -(y - yGoc));
		angLimit = (short)Util.angle(xTo - xGoc, -(yTo - yGoc));
	}

	public void setTypeSkill(byte type)
	{
		typeSkill = type;
	}

	public override void update()
	{
		angle = (short)Util.fixangle(angle + v * dir);
		int num = distant * Util.Cos(Util.fixangle(angle)) >> 10;
		int num2 = -(distant * Util.Sin(Util.fixangle(angle))) >> 10;
		xCu = x;
		yCu = y;
		if (type != 1)
		{
			x = xGoc + num;
		}
		y = yGoc + num2;
		int num3 = Util.distance(xCu, yCu, x, y);
		if (num3 > 10)
		{
			v = (short)(10 - num3 % 10 / 2);
		}
		if (Util.abs(angle - angLimit) >= v)
		{
			return;
		}
		if (type != 1)
		{
			if (hpLost != 0)
			{
				Canvas.gameScr.startFlyText("-" + hpLost, 0, xTo, yTo - 45, 1, -2);
			}
			else
			{
				Canvas.gameScr.startFlyText("MISS", 0, xTo, yTo - 45, 1, -2);
			}
		}
		EffectManager.addHiEffect(xTo, yTo - 10, 12);
		EffBack effBack = null;
		if (type != 1)
		{
			effBack = new EffBack(xTo, yTo, 28, 3, 32, 31, isEffVong: false, isEffUpDown: false);
			EffectManager.lowEffects.addElement(effBack);
		}
		else
		{
			effBack = new EffBack(xTo, yTo, 28, 3, 32, 31, isEffVong: false, isEffUpDown: true);
			EffectManager.hiEffects.addElement(effBack);
			EffectManager.addHiEffect(xTo, yTo, 48);
		}
		EffectManager.hiEffects.removeElement(this);
		if (type == 1)
		{
			EffectManager.lowEffects.addElement(new Skill_Cau_Lua(xTo, yTo, list));
		}
	}

	public override void paint(MyGraphics g)
	{
		int num = Util.distance(xFrom, yFrom, x, y);
		int num2 = num * Util.Cos(Util.fixangle(angHuong)) >> 10;
		int num3 = -(num * Util.Sin(Util.fixangle(angHuong))) >> 10;
		g.drawImage(Res.imgShadow, xFrom + num2, yFrom + num3, 3);
		if (type == 1)
		{
			g.drawImage(Res.imgEffNew, x, y, 3);
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			Res.paintImgEff(g, 4, 0, index[i] * 14, 14, 14, x + Res.rnd(10) - 5, y + Res.rnd(10) - 10, 3);
			index[i]++;
			if (index[i] >= 5)
			{
				index[i] = 0;
			}
		}
	}
}
