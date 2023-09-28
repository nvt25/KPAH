public class CongThanh : Monster
{
	private int x0;

	private int y0;

	private int count;

	public override void update()
	{
		sbyte state = base.state;
		if (state == 5)
		{
			frame = 3;
			p1++;
			x += p2;
			y += p3;
			p2 >>= 1;
			p3 >>= 1;
			if (p1 == 5)
			{
				Canvas.gameScr.startExplosionAt(x, y);
			}
			if (p1 > 7)
			{
				Canvas.gameScr.actors.removeElement(this);
				GameScr.congThanh = null;
			}
		}
		x0 = 0;
		y0 = 0;
		if (count > 0)
		{
			count--;
			x0 = Res.rnd(2) - 1;
			y0 = Res.rnd(2) - 1;
		}
	}

	public override void setRealHP(int realHP)
	{
		base.setRealHP(realHP);
		count = 20;
	}

	public override void jumpVang(Actor causeBy)
	{
	}

	public override void paint(MyGraphics g)
	{
		if (Res.monsterTemplates[monster_type] != null && Res.monsterTemplates[monster_type].image != null)
		{
			g.drawRegion(Res.monsterTemplates[monster_type].image, 32, 0, 48, 89, 0, x - 48 + x0, y + y0, MyGraphics.BOTTOM | MyGraphics.LEFT);
			g.drawRegion(Res.monsterTemplates[monster_type].image, 32, 0, 48, 89, 2, x + x0, y + y0, MyGraphics.BOTTOM | MyGraphics.LEFT);
			g.drawRegion(Res.monsterTemplates[monster_type].image, 0, 9, 32, 76, 0, x - 127 - 48, y, MyGraphics.BOTTOM | MyGraphics.LEFT);
			g.drawRegion(Res.monsterTemplates[monster_type].image, 0, 9, 32, 76, 2, x - 127 + 31 - 48, y, MyGraphics.BOTTOM | MyGraphics.LEFT);
			g.drawRegion(Res.monsterTemplates[monster_type].image, 0, 9, 32, 76, 0, x + 161 - 48, y, MyGraphics.BOTTOM | MyGraphics.LEFT);
			g.drawRegion(Res.monsterTemplates[monster_type].image, 0, 9, 32, 76, 2, x + 161 + 31 - 48, y, MyGraphics.BOTTOM | MyGraphics.LEFT);
		}
	}
}
