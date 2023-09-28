public class CharBuff : Effect
{
	public int timeLife = -1;

	public long tick;

	private int timeReceive;

	private int count;

	public CharBuff(int x, int y, int type)
		: base(x, y, type)
	{
		tick = 0L;
	}

	public void setTimeLive(int time)
	{
		timeLife = time;
		count = 0;
		tick = mSystem.getCurrentTimeMillis() + timeLife * 1000;
		if (timeLife <= 0)
		{
			wantDetroy = true;
		}
	}

	public bool isCenter()
	{
		return type == 20 || type == 22 || type == 23 || type == 24 || type == 25 || type == 27;
	}

	public override void update()
	{
		if (Canvas.gameTick % 2 == 0)
		{
			f = (f + 1) % Effect.FRAME[type].Length;
		}
		if (mSystem.getCurrentTimeMillis() > tick)
		{
			wantDetroy = true;
		}
	}

	public void setXY(int x, int y)
	{
		base.x = x;
		base.y = y;
	}
}
