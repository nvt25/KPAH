public class Skill_Kham : Effect
{
	private LiveActor live;

	public long curTime;

	public long delay;

	public long timeDoc;

	private Image img;

	private int[] color;

	private short speedTemp;

	private CharBuff trungDoc;

	public static long t;

	public Skill_Kham(short type, int time, LiveActor live)
	{
		this.live = live;
		base.type = type;
		delay = time;
		curTime = mSystem.getCurrentTimeMillis() / 1000;
		switch (type)
		{
		case 0:
			if (live.ID == Canvas.gameScr.mainChar.ID)
			{
				Canvas.gameScr.isFillScr = true;
			}
			else
			{
				live.effSkill.removeElement(this);
			}
			break;
		case 1:
			timeDoc = mSystem.getCurrentTimeMillis() / 1000 - 1;
			trungDoc = new CharBuff(live.x, live.y - 17, 22);
			break;
		case 2:
			color = new int[5]
			{
				7053112,
				7517233,
				16317187,
				8386060,
				16453379
			};
			break;
		case 3:
			img = Res.imgIce;
			break;
		case 4:
			img = Res.imgStone;
			live.isFreeze = true;
			break;
		case 5:
			speedTemp = live.speed;
			live.speed /= 2;
			break;
		}
	}

	public override void update()
	{
		if (type == 1)
		{
			trungDoc.update();
			trungDoc.setXY(live.x, live.y - 17);
			if (mSystem.getCurrentTimeMillis() / 1000 - timeDoc > 1)
			{
				timeDoc = mSystem.getCurrentTimeMillis() / 1000;
				live.hp -= 1000;
				Canvas.gameScr.startFlyText("-" + 1000, 4, live.x, live.y - 40, 0, -1);
				if (live.hp < 0)
				{
					live.hp = 0;
				}
			}
		}
		t = delay - (mSystem.getCurrentTimeMillis() / 1000 - curTime);
		if (mSystem.getCurrentTimeMillis() / 1000 - curTime > delay)
		{
			switch (type)
			{
			case 0:
				Canvas.gameScr.isFillScr = false;
				break;
			case 3:
			case 4:
				live.isFreeze = false;
				break;
			case 5:
				live.speed = speedTemp;
				break;
			}
			live.effSkill.removeElement(this);
		}
	}

	public override void paint(MyGraphics g)
	{
		switch (type)
		{
		case 1:
			trungDoc.paint(g);
			break;
		case 2:
			for (int i = 0; i < 12; i++)
			{
				int num = 8 * Util.Cos(i * 30) >> 10;
				int num2 = -(8 * Util.Sin(i * 30)) >> 10;
				g.setColor(color[Res.rnd(5)]);
				g.fillRect(live.x + num, live.y - live.height + 4 + num2, 1, 5);
			}
			break;
		case 3:
		case 4:
			if (img != null)
			{
				g.drawImage(img, live.x, live.y + 5, MyGraphics.BOTTOM | MyGraphics.HCENTER);
			}
			break;
		}
	}
}
