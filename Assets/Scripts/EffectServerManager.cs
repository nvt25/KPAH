public class EffectServerManager
{
	public short ID;

	public short loop;

	public short loopLimit;

	public short radius;

	public short x;

	public short y;

	public short count;

	public short indexLoop;

	public short indexPos;

	public short idPlayer;

	public sbyte style;

	public sbyte loopType;

	public short[] xLoop;

	public short[] yLoop;

	public static mVector effectList = new mVector();

	public EffectServerManager()
	{
		count = 0;
	}

	public void update()
	{
		EffectData effect = getEffect(ID);
		if (effect == null)
		{
			return;
		}
		if (style == 0)
		{
			Actor actor = Canvas.gameScr.findActorByID(idPlayer);
			x = actor.x;
			y = actor.y;
		}
		if (count == loopLimit)
		{
			count = 0;
			EffectObj effectObj = new EffectObj();
			effectObj.ID = ID;
			effectObj.idPlayer = idPlayer;
			effectObj.style = style;
			switch (loopType)
			{
			case 0:
				effectObj.x = x;
				effectObj.y = y;
				break;
			case 1:
			{
				int num = Res.rnd(radius);
				int angle = Res.rnd(360);
				int num2 = num * Util.Cos(Util.fixangle(angle)) >> 10;
				int num3 = -(num * Util.Sin(Util.fixangle(angle))) >> 10;
				effectObj.x = x;
				effectObj.y = y;
				effectObj.dx = (short)num2;
				effectObj.dy = (short)num3;
				break;
			}
			case 2:
				effectObj.x = x;
				effectObj.y = y;
				if (style == 0)
				{
					effectObj.dx = xLoop[indexPos];
					effectObj.dy = yLoop[indexPos];
				}
				else
				{
					effectObj.x += xLoop[indexPos];
					effectObj.y += yLoop[indexPos];
				}
				break;
			}
			indexLoop++;
			indexPos++;
			if (xLoop != null && indexPos >= xLoop.Length)
			{
				indexPos = 0;
			}
			if (loop != -1 && indexLoop >= loop)
			{
				GameScr.effManager.removeElement(this);
			}
			sbyte b = style;
			if (b == 0 || b == 1)
			{
				Canvas.gameScr.actors.addElement(effectObj);
			}
		}
		count++;
	}

	public static EffectData getEffect(short id)
	{
		for (int i = 0; i < effectList.size(); i++)
		{
			EffectData effectData = (EffectData)effectList.elementAt(i);
			if (effectData.ID == id)
			{
				return effectData;
			}
		}
		return null;
	}
}
