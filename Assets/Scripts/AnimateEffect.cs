public class AnimateEffect : Effect
{
	public const sbyte RAIN = 0;

	public const sbyte FALLING_LEAVES = 1;

	public const sbyte SNOW = 2;

	public const sbyte FALLING_FLOWER = 3;

	public const sbyte FIREWORK = 4;

	public new sbyte type;

	public long number;

	public long timeLimit;

	public long curTime;

	private mVector list = new mVector();

	public bool isStop;

	public static int wind = 5;

	public static int countWind;

	public static int dirWind = Res.rnd(1, -1);

	public short idImg;

	public AnimateEffect(sbyte type, bool isStart, int number, int timeLimit)
	{
		this.timeLimit = timeLimit;
		curTime = mSystem.getCurrentTimeMillis() / 1000;
		this.type = type;
		this.number = number;
		switch (type)
		{
		case 1:
			idImg = 801;
			break;
		case 2:
			idImg = 805;
			break;
		case 3:
			idImg = 802;
			this.type = 3;
			break;
		case 4:
			idImg = 803;
			this.type = 3;
			break;
		case 5:
			idImg = 804;
			this.type = 3;
			break;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = null;
			if (isStart)
			{
				point = new Point((GameScr.cmx - Canvas.hw + Res.rnd(Canvas.w * 2)) * 10, (GameScr.cmy - Canvas.h * 2 + Res.rnd(Canvas.h * 2)) * 10);
			}
			else
			{
				point = new Point();
				rndPos(point);
			}
			if (type == 2 || this.type == 3)
			{
				point.h = Res.rnd(3);
			}
			else
			{
				point.h = Res.rnd(4);
			}
			point.limitY = 16 + Res.rnd(3) * 4;
			point.v = Res.rnd(-1, 1);
			point.color = Res.rnd(point.limitY);
			point.dis = (sbyte)Res.rnd(20);
			list.addElement(point);
		}
	}

	public void close()
	{
		GameScr.effAnimate.removeElement(this);
	}

	public void stop()
	{
		isStop = true;
	}

	public override void paint(MyGraphics g)
	{
		Canvas.resetTrans(g);
		g.translate(-GameScr.cmx, -GameScr.cmy);
		switch (type)
		{
		case 0:
			paintRain(g);
			break;
		case 1:
			paintFallingLeaves(g);
			break;
		case 3:
			paintFallingFlower(g);
			break;
		case 2:
			paintSnow(g);
			break;
		}
	}

	private void paintSnow(MyGraphics g)
	{
		Image image = null;
		if (GameData.getImgIcon(idImg) != null)
		{
			image = GameData.getImgIcon(idImg).img;
		}
		if (image == null)
		{
			return;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null && point.x / 10 > GameScr.cmx && point.x / 10 < GameScr.cmx + Canvas.w && point.y / 10 > GameScr.cmy && GameData.getImgIcon(idImg) != null)
			{
				g.drawRegion(image, 0, (2 - point.h) * 5, 5, 5, 0, point.x / 10, point.y / 10, 3);
			}
		}
	}

	private void paintFallingFlower(MyGraphics g)
	{
		Image image = null;
		if (GameData.getImgIcon(idImg) != null)
		{
			image = GameData.getImgIcon(idImg).img;
		}
		int num = 0;
		if (image == null)
		{
			return;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null && point.x / 10 > GameScr.cmx && point.x / 10 < GameScr.cmx + Canvas.w && point.y / 10 > GameScr.cmy)
			{
				num = 2 - point.h + 1;
				if (num < 2)
				{
					num = point.dis / 10;
				}
				g.drawRegion(image, 0, num * 10, 10, 10, 0, point.x / 10, point.y / 10, 3);
				point.dis++;
				if (point.dis >= 20)
				{
					point.dis = 0;
				}
			}
		}
	}

	private void paintFallingLeaves(MyGraphics g)
	{
		Image image = null;
		if (GameData.getImgIcon(idImg) != null)
		{
			image = GameData.getImgIcon(idImg).img;
		}
		if (image == null)
		{
			return;
		}
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null && point.x / 10 > GameScr.cmx && point.x / 10 < GameScr.cmx + Canvas.w && point.y / 10 > GameScr.cmy)
			{
				g.drawRegion(image, 0, point.color / (point.limitY / 4) * 10, 16, 10, 0, point.x / 10, point.y / 10, 3);
			}
		}
	}

	private void paintRain(MyGraphics g)
	{
		g.setColor(14540253);
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null && point.x / 10 > GameScr.cmx && point.x / 10 < GameScr.cmx + Canvas.w && point.y / 10 > GameScr.cmy)
			{
				g.fillRect(point.x / 10, point.y / 10, 1, point.h + 2);
			}
		}
	}

	public static void updateWind()
	{
		int num = 1;
		if (Canvas.gameTick % 6 == 3)
		{
			num = Res.rnd(15);
		}
		if (num == 0 && wind == 5)
		{
			wind = 5 + Res.rnd(20);
			countWind = 50 + Res.rnd(100);
		}
		if (countWind > 0)
		{
			countWind--;
		}
		if (countWind == 0 && wind > 5 && Canvas.gameTick % 4 == 2)
		{
			wind--;
		}
	}

	public override void update()
	{
		if (timeLimit > 0 && mSystem.getCurrentTimeMillis() / 1000 - curTime > timeLimit)
		{
			isStop = true;
		}
		switch (type)
		{
		case 0:
			updateRain();
			break;
		case 1:
			updateFallingLeaves();
			break;
		case 3:
			updateFlower();
			break;
		case 2:
			updateSnow();
			break;
		}
	}

	private void updateSnow()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null)
			{
				point.y += (point.h + 4) * 3;
				point.x += (point.h + 1) * 2 + wind * dirWind;
				if (point.y / 10 < GameScr.cmy - Canvas.hw || point.y / 10 > GameScr.cmy + (Canvas.h + Canvas.hh) - (4 - point.h) * 50 || point.x / 10 < GameScr.cmx - Canvas.hw || point.x / 10 > GameScr.cmx + Canvas.w + Canvas.hw)
				{
					rndPos(point);
				}
			}
		}
	}

	private void updateFlower()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null)
			{
				point.y += (point.h + 2) * 5;
				point.x += (point.h + 1) * 2 + wind * dirWind;
				if (point.y / 10 < GameScr.cmy - Canvas.hw || point.y / 10 > GameScr.cmy + (Canvas.h + Canvas.hh) - (4 - point.h) * 50 || point.x / 10 < GameScr.cmx - Canvas.hw || point.x / 10 > GameScr.cmx + Canvas.w + Canvas.hw)
				{
					rndPos(point);
				}
			}
		}
	}

	private void updateFallingLeaves()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null)
			{
				point.y += 10;
				point.x += point.v * 10 + wind * dirWind;
				point.color++;
				if (point.color >= point.limitY)
				{
					point.color = 0;
				}
				if (point.y / 10 < GameScr.cmy - Canvas.hw || point.y / 10 > GameScr.cmy + (Canvas.h + Canvas.hh) - (4 - point.h) * 50 || point.x / 10 < GameScr.cmx - Canvas.hw || point.x / 10 > GameScr.cmx + Canvas.w + Canvas.hw)
				{
					rndPos(point);
				}
			}
		}
	}

	private void updateRain()
	{
		for (int i = 0; i < number; i++)
		{
			Point point = (Point)list.elementAt(i);
			if (point != null)
			{
				point.y += (point.h + 1) * 15 + (3 - point.h) * 3;
				point.g++;
				point.x += (3 - point.h + 1) * 2 + wind * dirWind;
				if (point.y / 10 < GameScr.cmy - Canvas.hw || point.y / 10 > GameScr.cmy + (Canvas.h + Canvas.hh) - (4 - point.h) * 50 || point.x / 10 < GameScr.cmx - Canvas.hw || point.x / 10 > GameScr.cmx + Canvas.w + Canvas.hw)
				{
					rndPos(point);
				}
			}
		}
	}

	private void rndPos(Point pos)
	{
		if (isStop)
		{
			list.removeElement(pos);
			number = list.size();
			if (list.size() == 0)
			{
				close();
			}
		}
		else
		{
			pos.y = (GameScr.cmy - Canvas.hh + Res.rnd(Canvas.h * 2)) * 10;
			pos.x = (GameScr.cmx - Canvas.hw + Res.rnd(Canvas.w * 2)) * 10;
			if (type == 2 || type == 3)
			{
				pos.h = Res.rnd(3);
			}
			else
			{
				pos.h = Res.rnd(4);
			}
		}
	}
}
