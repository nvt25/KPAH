using System.IO;
using UnityEngine;

public class Skill_Kiem_Down : Effect
{
	private static FrameImage imgSword;

	private static Image imgCut;

	private int count = 120;

	private sbyte frame;

	private sbyte g = 5;

	private sbyte delay = 10;

	private sbyte countPop;

	public Skill_Kiem_Down(int x, int y)
	{
		base.x = x;
		base.y = y;
		Effect o = new Effect(x, y, 34)
		{
			loop = 3
		};
		EffectManager.lowEffects.addElement(o);
	}

	public static void load()
	{
		try
		{
			imgSword = new FrameImage(Image.createImage(Main.res + "/sword skill/kiem01"), 12, 39);
			imgCut = Image.createImage(Main.res + "/sword skill/all1");
		}
		catch (IOException)
		{
			UnityEngine.Debug.Log(" loi tai ham load skill kiem down");
		}
	}

	public override void update()
	{
		if (delay > 0)
		{
			delay--;
		}
		if (delay <= 0 && count > 0)
		{
			count -= g;
			g = (sbyte)(g + 5);
			if (count < 0)
			{
				count = 0;
				EffectManager.hiEffects.removeElement(this);
				EffectManager.lowEffects.addElement(this);
			}
		}
		if (count == 0 && Canvas.gameTick % 2 == 1)
		{
			for (int i = 0; i < 10; i++)
			{
				int num = countPop * Util.Cos(i * 36) >> 10;
				int num2 = -(countPop * Util.Sin(i * 36)) >> 10;
				num2 += -(num2 / 3) * 2;
				EffectManager.addLowEffect(x + num, y + num2 - 10, 15);
			}
			countPop = (sbyte)(countPop + 10);
			if (countPop == 30)
			{
				EffectManager.lowEffects.removeElement(this);
			}
		}
	}

	public override void paint(MyGraphics g)
	{
		if (count > 0)
		{
			imgSword.drawFrame(frame / 3, x, y - count, 0, MyGraphics.BOTTOM | MyGraphics.HCENTER, g);
		}
		else
		{
			g.drawImage(imgCut, x, y, MyGraphics.BOTTOM | MyGraphics.HCENTER);
		}
		frame++;
		if (frame >= 6)
		{
			frame = 0;
		}
	}
}
