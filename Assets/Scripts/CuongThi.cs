public class CuongThi : Monster
{
	private int vNhay;

	private int dirNhay = 1;

	private int timeNhay;

	private int nhay;

	private int angle;

	private int indexDoc;

	private bool isNhay;

	private bool isFire;

	public static byte[] clip = new byte[4]
	{
		0,
		1,
		2,
		2
	};

	public CuongThi()
	{
		z = 0;
	}

	public override void paint(MyGraphics g)
	{
		if (!isFreeze)
		{
			g.drawImage(Res.imgShadow, base.x, base.y, 3);
			if (dynamicEffBottom != null)
			{
				for (int i = 0; i < dynamicEffBottom.size(); i++)
				{
					((DynamicEffect)dynamicEffBottom.elementAt(i)).paint(g, base.x, base.y);
				}
			}
			if (Res.monsterTemplates[monster_type].image != null)
			{
				g.drawRegion(Res.monsterTemplates[monster_type].image, 0, clip[dir] * 31, 20, 31, (dir == 3) ? 2 : 0, base.x + vangx, base.y - nhay + z + vangy + dy, MyGraphics.BOTTOM | MyGraphics.HCENTER);
			}
			if (isFire)
			{
				int num = 10 * (indexDoc / 3) * Util.Cos(angle) >> 10;
				int num2 = -(10 * (indexDoc / 3) * Util.Sin(angle)) >> 10;
				int x = base.x + num;
				int y = base.y + num2 - 25;
				g.drawRegion(Res.loadImgEff(33), 0, (11 - indexDoc) / 3 * 14, 14, 14, 0, x, y, 3);
			}
			if (dynamicEffTop != null)
			{
				for (int j = 0; j < dynamicEffTop.size(); j++)
				{
					((DynamicEffect)dynamicEffTop.elementAt(j)).paint(g, base.x, base.y);
				}
			}
		}
		paintEffSkill(g);
	}

	public override void update()
	{
		base.update();
		if (timeNhay == 0)
		{
			nhay += vNhay;
			vNhay += dirNhay * 2;
			if (Util.abs(vNhay) > 4)
			{
				dirNhay *= -1;
			}
			if (vNhay == 0 && dirNhay == 1)
			{
				timeNhay = 8;
			}
		}
		if (timeNhay > 0 && !isNhay)
		{
			timeNhay--;
		}
		if (x != xTo || y != yTo)
		{
			isNhay = false;
		}
		else
		{
			isNhay = true;
		}
		if (!isFreeze && isFire)
		{
			indexDoc++;
			if (indexDoc >= 12)
			{
				isFire = false;
				indexDoc = 0;
			}
		}
	}

	public override void move()
	{
		if (FuntioncanMove() && timeNhay == 0)
		{
			base.move();
		}
	}

	public override void startAttack(mVector list, sbyte skillID)
	{
		if (isFire)
		{
			return;
		}
		LiveActor liveActor = (LiveActor)list.elementAt(0);
		isFire = true;
		indexDoc = 0;
		angle = Util.angle(liveActor.x - x, -(liveActor.y - y));
		if (list == null || list.size() <= 0)
		{
			return;
		}
		for (int i = 0; i < list.size(); i++)
		{
			LiveActor liveActor2 = (LiveActor)list.elementAt(i);
			if (liveActor2 != null)
			{
				int hp = liveActor2.hp;
				liveActor2.doublejump();
				Canvas.gameScr.startFlyText("-" + hp, 0, liveActor2.x, liveActor2.y + liveActor2.dy - 15, 1, -2);
			}
		}
	}
}
