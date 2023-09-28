using System;

public class ChangScr : MyScreen
{
	private static ChangScr me;

	private int x;

	private int y;

	private int index;

	private int trans;

	private int ang;

	private int dis;

	private int lastTime;

	private mVector list = new mVector();

	private int map = -1;

	private int xMap;

	private int yMap;

	public static ChangScr gI()
	{
		return (me != null) ? me : (me = new ChangScr());
	}

	public void setMap(int map, int xMap, int yMap)
	{
		this.map = map;
		this.xMap = xMap;
		this.yMap = yMap;
	}

	public override void update()
	{
		if (map > -1 && Environment.TickCount / 1000 - lastTime > 30)
		{
			lastTime = Environment.TickCount / 1000;
			GameService.gI().changeMap(map, xMap, yMap);
		}
		updateWaiting();
	}

	public void disConnectWhenTimeLimit()
	{
		Canvas.instance.timeRemove = -1L;
		Canvas.infoDisConnect = "Mất kết nối.";
		Canvas.xInfoDisConnect = Canvas.w;
		Main.isDisConnect = true;
		Main.isStartSaveIp = false;
		Canvas.endDlg();
		Canvas.instance.init();
		Session_ME.gI().close();
		Tilemap.loadMap(0, null);
		ServerListScr.gI().switchToMe();
	}

	public override bool keyPress(int keyCode)
	{
		return base.keyPress(keyCode);
	}

	public override void paint(MyGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, Canvas.w, Canvas.h);
		for (int i = 0; i < list.size(); i++)
		{
			Position position = (Position)list.elementAt(i);
			if (Res.imgEffect[8] == null)
			{
				Res.getImgEffect(8);
			}
			g.drawRegion(Res.imgEffect[8], 0, position.index / 2 * 10, 10, 10, 0, position.x, position.y, 3);
		}
		if (Res.imgArrow[3] == null)
		{
			Res.loadImgArrow(3);
		}
		if (Res.imgArrow[3] != null)
		{
			g.drawRegion(Res.imgArrow[3], 0, index * 24, 24, 24, trans, x, y, 3);
		}
	}

	public override void switchToMe()
	{
		ang = 0;
		dis = 5;
		list.removeAllElements();
		lastTime = Environment.TickCount / 1000;
		base.switchToMe();
	}

	private void updateWaiting()
	{
		ang += 15;
		if (ang >= 360)
		{
			ang -= 360;
		}
		int num = ang - 15;
		if (num < 0)
		{
			num = 360 + num;
		}
		int num2 = dis * Util.Cos(Util.fixangle(ang)) >> 10;
		int num3 = -(dis * Util.Sin(Util.fixangle(ang))) >> 10;
		int num4 = dis * Util.Cos(Util.fixangle(num)) >> 10;
		int num5 = -(dis * Util.Sin(Util.fixangle(num))) >> 10;
		if (dis < 30)
		{
			dis++;
		}
		x = Canvas.hw + num2;
		y = Canvas.hh + num3;
		int num6 = Arrow.findDirIndexFromAngle(Util.angle(x - (Canvas.hw + num4), -(y - (Canvas.hh + num5))));
		index = Arrow.FRAME[num6];
		trans = Arrow.TRANSFORM[num6];
		list.addElement(new Position(x, y));
		for (int i = 0; i < list.size(); i++)
		{
			Position position = (Position)list.elementAt(i);
			position.index++;
			if (position.index >= 20)
			{
				list.removeElement(position);
			}
		}
	}
}
