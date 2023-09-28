using System;

public class Boss_Dragon : Monster
{
	private class sonLiveActor : LiveActor
	{
		public override void setPosTo(short x, short y)
		{
		}
	}

	public static ImageObj imgObj;

	public static Image img;

	public static Image imgShadow;

	public short[] xBody = new short[12];

	public short[] yBody = new short[12];

	public MagicLogic arrow;

	public Position posGo = new Position();

	public new LiveActor target;

	private LiveActor live;

	private int index;

	private int indexRear;

	private sbyte[] xDuHead = new sbyte[8]
	{
		5,
		3,
		-1,
		-8,
		-8,
		0,
		0,
		2
	};

	private sbyte[] yDuHead = new sbyte[8]
	{
		-5,
		-8,
		-10,
		-7,
		-2,
		0,
		0,
		-3
	};

	private int indexRan;

	private int count;

	private sbyte[] xDuRear = new sbyte[8]
	{
		-12,
		-6,
		0,
		10,
		10,
		7,
		0,
		-8
	};

	private sbyte[] yDuRear = new sbyte[8]
	{
		4,
		8,
		12,
		8,
		-2,
		-8,
		-10,
		-4
	};

	private sbyte[] arrIndex = new sbyte[8]
	{
		2,
		3,
		4,
		3,
		2,
		1,
		0,
		1
	};

	private sbyte[] tranIndex = new sbyte[8]
	{
		0,
		0,
		0,
		2,
		2,
		2,
		0,
		0
	};

	private sbyte[] IndexRear = new sbyte[8]
	{
		9,
		6,
		9,
		6,
		9,
		6,
		9,
		6
	};

	private sbyte[] tranRear = new sbyte[8]
	{
		4,
		3,
		3,
		1,
		7,
		0,
		0,
		2
	};

	public Boss_Dragon()
	{
		target = Canvas.gameScr.mainChar;
		x = (short)(target.x - 80);
		y = (short)(target.y - 80);
		for (int i = 0; i < xBody.Length; i++)
		{
			xBody[i] = x;
			yBody[i] = y;
		}
		live = new sonLiveActor();
		arrow = new MagicLogic();
		arrow.isSpeedUp = true;
		arrow.setAngle(20);
		arrow.set(7, x, y, 7, target);
	}

	public static void loadDragon()
	{
		imgObj = new ImageObj();
		try
		{
			imgShadow = Image.createImage(Main.res + "/rong/shadow");
			img = Image.createImage(Main.res + "/rong/Big0");
			DataInputStream resourceAsStream = DataInputStream.getResourceAsStream(Main.res + "/rong/dragonData");
			sbyte b = (sbyte)resourceAsStream.read();
			imgObj.index = new sbyte[b];
			imgObj.x0 = new sbyte[b];
			imgObj.y0 = new sbyte[b];
			imgObj.w = new sbyte[b];
			imgObj.h = new sbyte[b];
			for (int i = 0; i < b; i++)
			{
				imgObj.index[i] = (sbyte)resourceAsStream.read();
				imgObj.x0[i] = (sbyte)resourceAsStream.read();
				imgObj.y0[i] = (sbyte)resourceAsStream.read();
				imgObj.w[i] = (sbyte)resourceAsStream.read();
				imgObj.h[i] = (sbyte)resourceAsStream.read();
			}
		}
		catch (Exception ex)
		{
			Out.println(ex.StackTrace + " loi load rong");
		}
	}

	public override void update()
	{
		updateDynamicBuff();
		arrow.updateAngle();
		if (arrow.isEnd)
		{
			arrow.isEnd = false;
			arrow.life = 0;
			live.x = (short)(target.x - 80 + Res.rnd(160));
			live.y = (short)(target.y - 80 + Res.rnd(160));
			arrow.target = live;
		}
		x = (short)arrow.x;
		y = (short)arrow.y;
		index = arrow.index / 2;
		indexRear = Arrow.findDirIndexFromAngle(Util.angle(xBody[9] - xBody[11], -(yBody[9] - yBody[11]))) / 2;
		if (Canvas.gameTick % 2 == 0)
		{
			for (int num = xBody.Length - 1; num > 0; num--)
			{
				xBody[num] = xBody[num - 1];
				yBody[num] = yBody[num - 1];
			}
			xBody[0] = x;
			yBody[0] = y;
		}
		if (Canvas.gameTick % 20 == 10)
		{
			int num2 = Util.distance(target.x, target.y, xBody[2], yBody[2] - 50);
			int num3 = Util.distance(target.x, target.y, x + xDuHead[index], y + yDuHead[index] - 50);
			int num4 = Util.angle(target.x - xBody[2], -(target.y - (yBody[2] - 50)));
			int num5 = Util.angle(target.x - (x + xDuHead[index]), -(target.y - (y + yDuHead[index] - 50)));
			if (num2 > num3 && Util.abs(num4 - num5) < 50)
			{
				int num6 = Util.angle(xBody[2] - (x + xDuHead[index]), -(yBody[2] - 50 - (y + yDuHead[index] - 50)));
				int num7 = -10 * Util.Cos(num6) >> 10;
				int num8 = -(-10 * Util.Sin(num6)) >> 10;
				Canvas.gameScr.startNewMagicBeam(4, this, target, x + xDuHead[index] + num7, y + yDuHead[index] - 50 + num8, 0, 0, num6);
			}
		}
	}

	public override void paint(MyGraphics g)
	{
		g.drawImage(imgShadow, xBody[11], yBody[11], 3);
		for (int i = 0; i < xBody.Length - 1; i++)
		{
			g.drawImage(imgShadow, xBody[i], yBody[i], 3);
		}
		if (dynamicEffBottom != null)
		{
			for (int j = 0; j < dynamicEffBottom.size(); j++)
			{
				((DynamicEffect)dynamicEffBottom.elementAt(j)).paint(g, x, y);
			}
		}
		g.drawImage(imgShadow, x, y, 3);
		g.drawRegion(img, imgObj.x0[IndexRear[indexRear]], imgObj.y0[IndexRear[indexRear]], imgObj.w[IndexRear[indexRear]], imgObj.h[IndexRear[indexRear]], tranRear[indexRear], xBody[11] + xDuRear[indexRear], yBody[11] + yDuRear[indexRear] - 50, 3);
		if (index == 1 || index == 2 || index == 3)
		{
			paintHead(g);
			paintBody(g);
		}
		else
		{
			paintBody(g);
			paintHead(g);
		}
		if (dynamicEffTop != null)
		{
			for (int k = 0; k < dynamicEffTop.size(); k++)
			{
				((DynamicEffect)dynamicEffTop.elementAt(k)).paint(g, x, y);
			}
		}
	}

	public void paintBody(MyGraphics g)
	{
		for (int i = 0; i < xBody.Length - 1; i++)
		{
			g.drawRegion(img, imgObj.x0[5], imgObj.y0[5], imgObj.w[5], imgObj.h[5], 0, xBody[i], yBody[i] - 50, 3);
		}
	}

	public void paintHead(MyGraphics g)
	{
		g.drawRegion(img, imgObj.x0[arrIndex[index]], imgObj.y0[arrIndex[index]], imgObj.w[arrIndex[index]], imgObj.h[arrIndex[index]], tranIndex[index], x + xDuHead[index], y + yDuHead[index] - 50, 3);
	}
}
