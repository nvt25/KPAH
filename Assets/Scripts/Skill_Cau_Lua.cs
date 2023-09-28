public class Skill_Cau_Lua : Effect
{
	private class Pos
	{
		private int x;

		private int y;

		private int xTo;

		private int yTo;

		public bool isRemove;

		public Pos(int x, int y, int angle)
		{
			this.x = x;
			this.y = y;
			xTo = x + Util.Cos(angle) * 100 / 1024;
			yTo = y + Util.Sin(angle) * 100 / 1024;
		}

		public void update()
		{
			if (x != xTo)
			{
				if (xTo - x >> 1 == 0)
				{
					x = xTo;
				}
				else
				{
					x += xTo - x >> 1;
				}
			}
			if (y != yTo)
			{
				if (yTo - y >> 1 == 0)
				{
					y = yTo;
				}
				else
				{
					y += yTo - y >> 1;
				}
			}
			if (x == xTo && y == yTo)
			{
				isRemove = true;
			}
			if (isRemove)
			{
				for (int i = 0; i < 5; i++)
				{
					EffectManager.addHiEffect(x + Res.rnd(10) - 5, y + Res.rnd(10) - 10, 28);
				}
			}
			else
			{
				EffectManager.addHiEffect(x, y, 15);
				EffectManager.addHiEffect(x, y, 49);
			}
		}
	}

	private mVector total = new mVector();

	private mVector list;

	private int[] angle = new int[12]
	{
		0,
		30,
		60,
		90,
		120,
		150,
		180,
		210,
		240,
		270,
		300,
		330
	};

	public Skill_Cau_Lua(int xC, int yC, mVector list)
	{
		total = new mVector();
		this.list = new mVector();
		this.list = list;
		for (int i = 0; i < angle.Length; i++)
		{
			total.addElement(new Pos(xC, yC, angle[i]));
		}
	}

	public override void update()
	{
		for (int i = 0; i < total.size(); i++)
		{
			Pos pos = (Pos)total.elementAt(i);
			if (pos != null)
			{
				pos.update();
				if (pos.isRemove)
				{
					total.removeElement(pos);
				}
			}
		}
		if (total.size() != 0)
		{
			return;
		}
		wantDetroy = true;
		for (int j = 0; j < list.size(); j++)
		{
			LiveActor liveActor = (LiveActor)list.elementAt(j);
			if (liveActor != null)
			{
				int damAttack = liveActor.damAttack;
				liveActor.doublejump();
				if (damAttack > 0)
				{
					Canvas.gameScr.startFlyText("-" + damAttack, 0, liveActor.x, liveActor.y + liveActor.dy - 15, 1, -2);
				}
				else
				{
					Canvas.gameScr.startFlyText("MISS", 0, liveActor.x, liveActor.y + liveActor.dy - 15, 1, -2);
				}
			}
		}
	}
}
