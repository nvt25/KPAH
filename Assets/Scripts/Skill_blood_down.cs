public class Skill_blood_down : Effect
{
	private int count = 120;

	private sbyte frame;

	private sbyte g = 5;

	private sbyte delay = 10;

	private sbyte countPop;

	private new sbyte f;

	private sbyte[] arrframe = new sbyte[4]
	{
		0,
		1,
		2,
		3
	};

	private int dame;

	public Skill_blood_down(int x, int y, int dame)
	{
		base.x = x;
		base.y = y;
		delay = (sbyte)Canvas.random(5, 20);
		EffectManager.addLowEffect(new Effect(x, y, 34)
		{
			loop = 3
		});
		this.dame = dame;
	}

	public override void update()
	{
		f++;
		if (f > arrframe.Length - 1)
		{
			f = 0;
		}
		frame = arrframe[f];
		if (delay > 0)
		{
			delay--;
		}
		if (delay <= 0 && count > 0)
		{
			count -= g;
			g = (sbyte)(g + 8);
			if (count < 0)
			{
				count = 0;
				EffectManager.hiEffects.removeElement(this);
				EffectManager.lowEffects.addElement(this);
			}
		}
		if (count == 0 && Canvas.gameTick % 2 == 1)
		{
			EffectManager.addLowEffect(x, y, 62);
			EffectManager.lowEffects.removeElement(this);
			Canvas.gameScr.startFlyText("- " + dame, 0, x, y - 25, 1, -2);
		}
	}

	public override void paint(MyGraphics g)
	{
		Image imgeffect = Res.getImgeffect(61);
		if (imgeffect != null)
		{
			g.drawRegion(imgeffect, 0, frame * Effect.HEIGHT[61], Effect.WIDTH[61], Effect.HEIGHT[61], 0, x, y - count, MyGraphics.VCENTER | MyGraphics.HCENTER);
		}
	}
}
