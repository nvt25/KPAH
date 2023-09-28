public class Skill_AEO_DUA_DAO_5 : Effect
{
	private MagicLogic magic;

	private int countDau = 7;

	private int dir = -1;

	private int xDau_1;

	private int yDau_1;

	private int xDau_2;

	private int yDau_2;

	private int xlast;

	private int yLast;

	private int xDau_3;

	private int yDau_3;

	private int xDau_4;

	private int yDau_4;

	private mVector listPos = new mVector();

	public string[] textAttack;

	private LiveActor to;

	public bool isDoubleDragon;

	public Skill_AEO_DUA_DAO_5(int xFrom, int yFrom, LiveActor from, LiveActor to, sbyte type)
	{
		base.type = type;
		this.to = to;
		magic = new MagicLogic();
		xlast = xFrom;
		yLast = yFrom;
		if (type == 5)
		{
			xlast = to.x;
			yLast = to.y;
			to.x = (short)xlast;
			to.y = (short)(yLast - 200);
			this.to = to;
			magic.set(type, xlast, yLast, to.dir, to);
			int num = Util.angle(xlast - x, -(yLast - y));
			magic.setAngle(Util.fixangle(num - 45));
		}
		else
		{
			magic.set(type, xFrom, yFrom, from.dir, to);
			int num2 = Util.angle(xFrom - x, -(yFrom - y));
			magic.setAngle(Util.fixangle(num2 - 180));
		}
		textAttack = new string[2];
	}

	public override void update()
	{
		if (magic == null)
		{
			return;
		}
		magic.updateAngle();
		if (magic.isEnd)
		{
			if (type != 5)
			{
				EffectManager.addLowEffect(magic.x, magic.y, (type != 4) ? 28 : 30);
			}
			EffectManager.addLowEffect(magic.x, magic.y, (type != 4) ? 28 : 30);
			EffectManager.hiEffects.removeElement(this);
			if (to.catagory == 1)
			{
				((Monster)to).isTarget = false;
			}
			to.jump();
			if (textAttack[0] != null)
			{
				Canvas.gameScr.startFlyText(textAttack[0], 0, x, y - 15, 1, -2);
			}
			if (textAttack[1] != null)
			{
				Canvas.gameScr.startFlyText(textAttack[1], 0, x, y - 15, 2, -2);
			}
			return;
		}
		x = magic.x;
		y = magic.y;
		int num = Util.angle(xlast - x, -(yLast - y));
		int a = Util.fixangle(num + 90);
		int num2 = countDau * Util.Cos(a) >> 10;
		int num3 = -(countDau * Util.Sin(a)) >> 10;
		xDau_1 = x + num2;
		yDau_1 = y + num3;
		int a2 = Util.fixangle(num - 90);
		int num4 = countDau * Util.Cos(a2) >> 10;
		int num5 = -(countDau * Util.Sin(a2)) >> 10;
		xDau_2 = x + num4;
		yDau_2 = y + num5;
		if (type == 5 && isDoubleDragon)
		{
			int a3 = Util.fixangle(num + 135);
			int num6 = countDau * Util.Cos(a3) >> 10;
			int num7 = -(countDau * Util.Sin(a3)) >> 10;
			xDau_3 = x + num6 + 10;
			yDau_3 = y + num7 - 10;
			int a4 = Util.fixangle(num - 135);
			int num8 = countDau * Util.Cos(a4) >> 10;
			int num9 = -(countDau * Util.Sin(a4)) >> 10;
			xDau_4 = x + num8 + 10;
			yDau_4 = y + num9 - 10;
		}
		countDau += dir * 3;
		if (Util.abs(countDau) > 9)
		{
			dir *= -1;
		}
		Position o = new Position(xDau_1, yDau_1, 0);
		listPos.addElement(o);
		Position o2 = new Position(xDau_2, yDau_2, 0);
		listPos.addElement(o2);
		if (type == 5 && isDoubleDragon)
		{
			Position o3 = new Position(xDau_3, yDau_3, 0);
			listPos.addElement(o3);
			Position o4 = new Position(xDau_4, yDau_4, 0);
			listPos.addElement(o4);
		}
		xlast = x;
		yLast = y;
	}

	public override void paint(MyGraphics g)
	{
		if (type == 4)
		{
			for (int i = 0; i < listPos.size(); i++)
			{
				Position position = (Position)listPos.elementAt(i);
				Res.paintImgEff(g, 29, 0, (17 - position.follow) * 11, 11, 11, position.x, position.y, 3);
				position.follow++;
				if (position.follow >= 18)
				{
					listPos.removeElement(position);
				}
			}
		}
		else
		{
			for (int j = 0; j < listPos.size(); j++)
			{
				Position position2 = (Position)listPos.elementAt(j);
				Res.paintImgEff(g, 8, 0, position2.follow * 10, 10, 10, position2.x, position2.y, 3);
				position2.follow++;
				if (position2.follow >= 10)
				{
					listPos.removeElement(position2);
				}
			}
		}
		if (Res.getImgArrow(type) == null || magic.isEnd)
		{
			return;
		}
		if (type == 5)
		{
			g.drawRegion(Res.imgArrow[3], 0, magic.headArrowFrame * 24, 24, 24, magic.headTransform, xDau_1, yDau_1, 3);
			g.drawRegion(Res.imgArrow[3], 0, magic.headArrowFrame * 24, 24, 24, magic.headTransform, xDau_2, yDau_2, 3);
			if (isDoubleDragon)
			{
				g.drawRegion(Res.imgArrow[3], 0, magic.headArrowFrame * 24, 24, 24, magic.headTransform, xDau_3, yDau_3, 3);
				g.drawRegion(Res.imgArrow[3], 0, magic.headArrowFrame * 24, 24, 24, magic.headTransform, xDau_4, yDau_4, 3);
			}
		}
		else
		{
			g.drawRegion(Res.imgArrow[type], 0, magic.headArrowFrame * 24, 24, 24, magic.headTransform, xDau_1, yDau_1, 3);
			g.drawRegion(Res.imgArrow[type], 0, magic.headArrowFrame * 24, 24, 24, magic.headTransform, xDau_2, yDau_2, 3);
		}
	}
}
