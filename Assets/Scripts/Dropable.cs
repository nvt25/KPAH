public abstract class Dropable : Actor
{
	public static readonly sbyte STATE_STAND;

	public static readonly sbyte STATE_DROP = 1;

	public static readonly sbyte STATE_FLY = 2;

	public short item_template_id;

	public bool isSendGet;

	private new int state;

	public short xTo;

	public short yTo;

	public short deltaH;

	public short g;

	private static short DROP_POWER = 6;

	public int itemClass;

	private long timeStart;

	public override void setType(short template_id)
	{
		item_template_id = template_id;
		timeStart = mSystem.getCurrentTimeMillis();
	}

	public void startFlyTo(short xTo, short yTo)
	{
		this.xTo = xTo;
		this.yTo = yTo;
		state = STATE_FLY;
		deltaH = 0;
		g = DROP_POWER;
	}

	public void startDropFrom(short xFrom, short yFrom, short xTo, short yTo)
	{
		x = xFrom;
		y = yFrom;
		this.xTo = xTo;
		this.yTo = yTo;
		state = STATE_DROP;
		deltaH = 0;
		g = DROP_POWER;
		timeStart = mSystem.getCurrentTimeMillis();
	}

	public override void setPosTo(short x, short y)
	{
		base.x = x;
		base.y = (short)(y - 4 + Canvas.r.nextInt() % 8);
	}

	public override void update()
	{
		long currentTimeMillis = mSystem.getCurrentTimeMillis();
		if (catagory == Actor.CAT_ITEM || catagory == Actor.CAT_GEM_ITEM)
		{
			if (currentTimeMillis - timeStart > 25000)
			{
				wantDestroy = true;
			}
		}
		else if (catagory == Actor.CAT_POTION)
		{
			int num = 15000;
			num = ((item_template_id < 10) ? num : 60000);
			if (currentTimeMillis - timeStart > num)
			{
				wantDestroy = true;
			}
		}
		if (state != STATE_DROP && state != STATE_FLY)
		{
			return;
		}
		x += (short)(xTo - x >> 2);
		y += (short)(yTo - y >> 2);
		if (g >= -DROP_POWER)
		{
			deltaH += g;
			g--;
		}
		if ((GameScr.abs(x - xTo) < 4 || GameScr.abs(y - yTo) < 4) && deltaH <= 1)
		{
			x = xTo;
			y = yTo;
			deltaH = 0;
			g = 0;
			if (state == STATE_FLY)
			{
				wantDestroy = true;
			}
			state = STATE_STAND;
		}
	}

	public override bool isItemCanGet()
	{
		return true;
	}

	public override bool isDropItem()
	{
		return true;
	}
}
