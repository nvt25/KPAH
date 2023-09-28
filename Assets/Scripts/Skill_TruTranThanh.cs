public class Skill_TruTranThanh : Effect
{
	private mVector lisAttack = new mVector();

	private LiveActor from;

	private int[] color = new int[0];

	private int xF;

	private int yF;

	private int vx;

	private int dem;

	private bool isEnd;

	public Skill_TruTranThanh(int x, int y, LiveActor From, mVector list)
	{
		base.x = x;
		base.y = y;
		for (int i = 0; i < 20; i++)
		{
			int num = (sbyte)(20 - Res.rnd(40));
			int num2 = (sbyte)(20 - Res.rnd(40));
			xF = x + num;
			yF = y + num2;
		}
		from = From;
		lisAttack = list;
	}

	public override void update()
	{
		if (xF < x)
		{
			xF += vx;
		}
		if (xF >= x)
		{
			xF -= vx;
		}
		if (yF < y)
		{
			yF += vx;
		}
		if (yF > y)
		{
			yF -= vx;
		}
		vx++;
		if (Math.abs(x - xF) <= 5 && Math.abs(y - yF) <= 5)
		{
			isEnd = true;
			vx = 0;
			EffectManager.hiEffects.removeElement(this);
		}
	}

	public override void paint(MyGraphics g)
	{
		for (int i = 0; i < 5; i++)
		{
			if (!isEnd)
			{
				g.drawRegion(Char.imgLight, 0, 7, 7, 7, 0, xF, yF, 0);
				g.drawRegion(Char.imgLight, 0, 14, 7, 7, 0, xF + 7 - Res.rnd(15), yF + 7 - Res.rnd(15), 0);
			}
		}
	}
}
