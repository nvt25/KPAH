public class Lightning : Effect
{
	private static int[] color = new int[2]
	{
		16579837,
		11188220
	};

	public mVector listPos = new mVector();

	public mVector[] list;

	private Position posangle;

	private long countDown;

	private long timeDel;

	public bool isContinue;

	public bool isRemove = true;

	private int cou;

	private int dem;

	private int aa = 7;

	public void reset()
	{
		countDown = mSystem.getCurrentTimeMillis() / 10;
		timeDel = mSystem.getCurrentTimeMillis() / 10;
		listPos.removeAllElements();
	}

	public void setInfo(mVector position, Position angle, bool isContinue)
	{
		if (position.size() == 0)
		{
			return;
		}
		this.isContinue = isContinue;
		if (!isContinue)
		{
			orderVector(position);
		}
		listPos = position;
		posangle = angle;
		list = new mVector[position.size()];
		for (int i = 0; i < list.Length; i++)
		{
			list[i] = new mVector();
		}
		angle.follow = -1;
		list[0].addElement(angle);
		int num = -1;
		for (int j = 0; j < position.size(); j++)
		{
			int x = angle.x;
			int y = angle.y;
			if (isContinue && num != -1)
			{
				Position position2 = (Position)position.elementAt(num);
				x = position2.x;
				y = position2.y;
			}
			num = (isContinue ? (num + 1) : rndIndexList(position));
			int num2 = rndIndex(position, 1);
			int num3 = list[num].size() - 1;
			Position position3 = (Position)position.elementAt(num);
			int num4 = Util.angle(position3.x - x, -(position3.y - y));
			int num5 = Res.rnd(15) + 10;
			int num6 = 0;
			int num7 = 0;
			while (true)
			{
				num7 = 0;
				if (num6 != 0)
				{
					num7 = num4 - 5 + Res.rnd(10);
				}
				num7 = Util.fixangle(num7);
				int num8 = num5 * num6 * Util.Cos(num7) >> 10;
				int num9 = -(num5 * num6 * Util.Sin(num7)) >> 10;
				Position o = new Position(x + num8, y + num9, num3++);
				list[num].addElement(o);
				if (Util.distance(x, y, x + num8, y + num9) >= Util.distance(x, y, position3.x, position3.y) - 20)
				{
					break;
				}
				num6++;
			}
		}
		for (int k = 0; k < list.Length; k++)
		{
			int num11 = list[k].size();
			Position position4 = (Position)position.elementAt(k);
			position4.follow = (sbyte)(list[k].size() - 1);
			position4.index = -1;
			Position position5 = new Position(position4.x, position4.y, position4.follow);
			position5.index = -1;
			list[k].addElement(position5);
			for (int l = 1; l < num11; l++)
			{
				Position position6 = (Position)list[k].elementAt(l);
				int num12 = Res.rnd(2);
				for (int m = 0; m < num12; m++)
				{
					int angle2 = 180 + Res.rnd(180);
					int num13 = 5 + Res.rnd(10);
					int num14 = num13 * Util.Cos(Util.fixangle(angle2)) >> 10;
					int num15 = -(num13 * Util.Sin(Util.fixangle(angle2))) >> 10;
					Position position7 = new Position(position6.x + num14, position6.y + num15, l);
					position7.index = 0;
					list[k].addElement(position7);
				}
			}
		}
	}

	public static mVector orderVector(mVector obj)
	{
		int num = obj.size();
		for (int i = 0; i < num - 1; i++)
		{
			Position position = (Position)obj.elementAt(i);
			for (int j = i + 1; j < num; j++)
			{
				Position position2 = (Position)obj.elementAt(j);
				if (position.x > position2.x)
				{
					obj.setElementAt(position, j);
					obj.setElementAt(position2, i);
					position = position2;
				}
			}
		}
		return obj;
	}

	private int rndIndex(mVector pos, int chieu)
	{
		int num = 0;
		for (int i = 0; i < pos.size(); i++)
		{
			Position position = (Position)pos.elementAt(i);
			if (position.index != -1)
			{
				num++;
			}
		}
		if (num != 0)
		{
			num = Res.rnd(num);
			int num2 = 0;
			for (int j = 0; j < pos.size(); j++)
			{
				Position position2 = (Position)pos.elementAt(j);
				if (position2.index != -1)
				{
					num2++;
					if (num == num2)
					{
						return j;
					}
				}
			}
			return -1;
		}
		return -1;
	}

	private int rndIndexList(mVector pos)
	{
		int num = 0;
		for (int i = 0; i < pos.size(); i++)
		{
			Position position = (Position)pos.elementAt(i);
			if (position.index == -1)
			{
				num++;
			}
		}
		if (num != 0)
		{
			num = Res.rnd(num);
			int num2 = 0;
			for (int j = 0; j < pos.size(); j++)
			{
				Position position2 = (Position)pos.elementAt(j);
				if (position2.index == -1)
				{
					if (num == num2)
					{
						position2.index = 0;
						return j;
					}
					num2++;
				}
			}
			return -1;
		}
		return -1;
	}

	public override void update()
	{
		if (Canvas.gameTick % 2 != 1)
		{
			return;
		}
		posangle.follow = -1;
		posangle.index = -1;
		for (int i = 0; i < listPos.size(); i++)
		{
			Position position = (Position)listPos.elementAt(i);
			if (position != null)
			{
				position.index = -1;
				position.follow = -1;
			}
		}
		if (isContinue && isRemove && listPos.size() > 1 && mSystem.getCurrentTimeMillis() / 10 - timeDel > 30)
		{
			timeDel = mSystem.getCurrentTimeMillis() / 10;
			posangle = (Position)listPos.elementAt(0);
			listPos.removeElementAt(0);
		}
		if (posangle != null)
		{
			setInfo(listPos, posangle, isContinue);
		}
		if (mSystem.getCurrentTimeMillis() / 10 - countDown > 60 + (isContinue ? 20 : 0))
		{
			aa = 7;
			if (EffectManager.hiEffects.conTains(this))
			{
				EffectManager.hiEffects.removeElement(this);
			}
		}
		countDown++;
	}

	public override void paint(MyGraphics g)
	{
		dem = 0;
		Res.imgSmoke.drawFrame(cou / 3, posangle.x, posangle.y, 0, 3, g);
		cou++;
		if (cou >= 12)
		{
			cou = 0;
		}
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Length; i++)
		{
			for (int j = 0; j < list[i].size(); j++)
			{
				Position position = (Position)list[i].elementAt(j);
				if (position == null || position.follow < 0 || position.follow >= list[i].size())
				{
					continue;
				}
				Position position2 = (Position)list[i].elementAt(position.follow);
				if (position2 != null)
				{
					paintLine(g, position, position2);
				}
				if (isContinue && isRemove)
				{
					dem++;
					if (dem >= aa)
					{
						aa += 7;
						return;
					}
				}
			}
			Position position3 = (Position)listPos.elementAt(i);
			if (position3 != null)
			{
				Res.backSmoke.drawFrame(1 + position3.count / 4, position3.x, position3.y, 0, 3, g);
				position3.count++;
				if (position3.count >= 12)
				{
					position3.count = 0;
				}
			}
		}
	}

	private void paintLine(MyGraphics g, Position pos1, Position pos2)
	{
		if (pos1 == null || pos2 == null)
		{
			return;
		}
		mVector mVector = new mVector();
		mVector.addElement(new mLine(pos1.x, pos1.y, pos2.x, pos2.y, color[0]));
		if (pos1.index == -1)
		{
			mVector.addElement(new mLine(pos1.x - 1, pos1.y, pos2.x - 1, pos2.y, color[1]));
			if (isContinue && isRemove)
			{
				mVector.addElement(new mLine(pos1.x + 1, pos1.y, pos2.x + 1, pos2.y, color[1]));
			}
		}
		g.totalLine = mVector;
		g.drawlineGL();
	}
}
