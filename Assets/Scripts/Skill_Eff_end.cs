public class Skill_Eff_end : Effect
{
	private new int x;

	private new int y;

	private int angle;

	private int delay;

	private int yTo;

	private int vy;

	public Skill_Eff_end(int x, int y, int transForm)
	{
		this.x = Canvas.random(x - 10, x + 10);
		this.y = Canvas.random(y - 10, y + 10);
		angle = transForm;
		type = 0;
	}

	public Skill_Eff_end(int xF, int yF, LiveActor to)
	{
		x = xF;
		y = yF;
		yTo = to.y;
		type = 1;
	}

	public override void update()
	{
		if (type == 0)
		{
			delay++;
			if (delay > 50)
			{
				EffectManager.hiEffects.removeElement(this);
				EffectManager.lowEffects.removeElement(this);
				delay = 0;
			}
		}
		else
		{
			y += vy;
			vy += 2;
			if (y > yTo)
			{
				vy = 0;
				EffectManager.hiEffects.removeElement(this);
			}
		}
	}

	public override void paint(MyGraphics g)
	{
		if (type == 0)
		{
			if (delay > 0 && Res.getImgArrow(7) != null)
			{
				g.drawRegion(Res.imgArrow[7], 0, 38, 20, 18, angle, x, y, 3);
			}
			return;
		}
		Image image = Res.loadImgEff(5);
		if (image != null)
		{
			g.drawRegion(image, 0, 0, 32, 32, 0, x, y, 3);
			g.drawRegion(image, 0, 32, 32, 32, 0, x, y, 3);
			g.drawRegion(image, 0, 0, 32, 32, 0, x + 2, y + 2, 3);
			g.drawRegion(image, 0, 32, 32, 32, 0, x + 2, y + 2, 3);
		}
	}
}
