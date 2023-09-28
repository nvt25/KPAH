public class Skill_AEO_CUNG_5 : Effect
{
	private mVector list;

	private Char c;

	private int v = 12;

	private int dir = 1;

	private int count;

	private int dem;

	public Skill_AEO_CUNG_5(mVector mst, Char c)
	{
		list = mst;
		v = 12;
		this.c = c;
		for (int i = 0; i < list.size(); i++)
		{
			LiveActor liveActor = (LiveActor)list.elementAt(i);
			if (liveActor is Monster)
			{
				((Monster)liveActor).state = 3;
			}
			else if (liveActor is Char)
			{
				((Char)liveActor).state = 2;
			}
		}
	}

	public override void update()
	{
		count++;
		if (dem > 6 && v == 0)
		{
			dir = -1;
		}
		if (dir == -1 && v != 11)
		{
			v++;
		}
		if (v > 0 && dir == 1)
		{
			v--;
		}
		if (dir == -1 && v == 11)
		{
			for (int i = 0; i < list.size(); i++)
			{
				LiveActor liveActor = (LiveActor)list.elementAt(i);
				if (liveActor is Monster)
				{
					((Monster)liveActor).state = 0;
				}
				else if (liveActor is Char)
				{
					((Char)liveActor).state = 0;
				}
			}
			EffectManager.hiEffects.removeElement(this);
		}
		for (int j = 0; j < list.size(); j++)
		{
			LiveActor liveActor2 = (LiveActor)list.elementAt(j);
			liveActor2.dy -= (short)(v * dir);
		}
		if (v != 0 || dir != 1 || count % 3 != 0)
		{
			return;
		}
		if (dem <= 3)
		{
			for (int k = 0; k < list.size(); k++)
			{
				LiveActor to = (LiveActor)list.elementAt(k);
				Canvas.gameScr.startNewArrow(0, c, to, c.x, c.y - 15, c.attkPower, c.attkEffect, 1);
			}
		}
		dem++;
	}

	public override void paint(MyGraphics g)
	{
	}
}
