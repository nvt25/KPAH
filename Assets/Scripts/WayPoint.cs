public class WayPoint : Effect
{
	private int index;

	public sbyte clazz;

	private static int[] color = new int[6]
	{
		15006715,
		11598072,
		7994363,
		4062203,
		16383610,
		16682106
	};

	private mVector list = new mVector();

	private bool isWayPoint;

	private bool isJoin;

	public WayPoint(int x, int y, short type, sbyte cla, bool isWay)
	{
		isWayPoint = isWay;
		base.x = x;
		base.y = y;
		base.type = type;
		clazz = cla;
		isJoin = false;
	}

	public override void update()
	{
		if (type != 0 && x + 20 > GameScr.cmx && x - 20 < GameScr.cmx + Canvas.w && y > GameScr.cmy && y < GameScr.cmy + Canvas.h)
		{
			for (int i = 0; i < 2; i++)
			{
				int angle = Res.rnd(360);
				int num = 18 * Util.Cos(Util.fixangle(angle)) >> 10;
				int num2 = -(18 * Util.Sin(Util.fixangle(angle))) >> 10;
				num2 += -(num2 / 3);
				Position position = new Position(x + num, y + num2, (sbyte)(15 + Res.rnd(20)));
				position.dir = (sbyte)Res.rnd(20);
				list.addElement(position);
			}
		}
		if (!isWayPoint)
		{
			return;
		}
		if (type != Canvas.gameScr.map)
		{
			if (clazz == 1)
			{
				EffectManager.hiEffects.removeAllElements();
			}
			else if (clazz == 0)
			{
				EffectManager.lowEffects.removeAllElements();
			}
		}
		else if (!isJoin && Util.distance(x, y, Canvas.gameScr.mainChar.x, Canvas.gameScr.mainChar.y) < 17)
		{
			GameService.gI().doWayPoint(x, y, type);
			Canvas.gameScr.focusedActor = null;
			ChangScr.gI().switchToMe();
			isJoin = true;
		}
	}

	public void paintEff(MyGraphics g)
	{
		paint(g);
	}

	public override void paint(MyGraphics g)
	{
		if (x + 20 <= GameScr.cmx || x - 20 >= GameScr.cmx + Canvas.w || y <= GameScr.cmy || y - 40 >= GameScr.cmy + Canvas.h)
		{
			return;
		}
		if (clazz == 0)
		{
			g.drawRegion(Res.getWayPoint(), 0, index / 6 * 24, 39, 24, 0, x, y, 3);
			index++;
			if (index >= 12)
			{
				index = 0;
			}
			return;
		}
		for (int i = 0; i < list.size(); i++)
		{
			Position position = (Position)list.elementAt(i);
			if (position.dir == 5)
			{
				g.setColor(color[4]);
			}
			else if (position.dir == 15)
			{
				g.setColor(color[5]);
			}
			else
			{
				g.setColor(color[position.follow / 10]);
			}
			g.fillRect(position.x, position.y - (1 + position.follow / 3), 1, 1 + position.follow / 3);
			position.y -= 2;
			position.follow--;
			if (position.follow < 0)
			{
				list.removeElementAt(i);
			}
		}
	}
}
