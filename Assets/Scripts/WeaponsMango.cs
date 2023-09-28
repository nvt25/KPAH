using UnityEngine;

public class WeaponsMango : IArrow
{
	public int x;

	public int y;

	public int angleTo;

	public int angle;

	public int count;

	public int vangle;

	public int limCount;

	private bool isLR;

	public WeaponsMango(LiveActor acFr, LiveActor acTo, int vangle)
	{
		x = acFr.x;
		y = acFr.y;
		this.vangle = vangle;
		int num = Canvas.abs(Canvas.r.nextInt(2));
		limCount = Canvas.abs(Canvas.r.nextInt(3)) + 1;
		isLR = ((num == 0) ? true : false);
		angle = (angleTo = ((!isLR) ? 360 : 0));
		if (acTo != null)
		{
			int damAttack = acTo.damAttack;
			acTo.jump();
			EffectManager.addHiEffect(acTo.x, acTo.y + acTo.dy - 10, 11);
			Canvas.gameScr.startFlyText("-" + damAttack, 0, acTo.x, acTo.y + acTo.dy - 15, 1, -2);
		}
	}

	public override void onArrowTouchTarget()
	{
	}

	public void paint(Graphics g)
	{
	}

	public void set(int type, int x, int y, int power, byte effect, LiveActor owner, LiveActor target)
	{
	}

	public override void setAngle(int angle)
	{
	}

	public override void update()
	{
		if (isLR)
		{
			angleTo += 30;
			if (angleTo > 360)
			{
				angleTo -= 360;
			}
			if (angle != angleTo)
			{
				angle += vangle;
				if (angle > 360)
				{
					angle -= 360;
					count++;
				}
			}
		}
		else
		{
			angleTo -= 30;
			if (angleTo < 0)
			{
				angleTo = 360 + angleTo;
			}
			if (angle != angleTo)
			{
				angle -= vangle;
				if (angle < 0)
				{
					angle = 360 + angle;
					count++;
				}
			}
		}
		if (count >= limCount)
		{
			if (GameScr.arrowsUp.conTains(this))
			{
				GameScr.arrowsUp.removeElement(this);
			}
			count = 0;
		}
		if (angle % 30 == 0)
		{
			Canvas.gameScr.startWeapsAngleBoss(angle, 10, null, null, 1, isUpDown: false, 0, 0, x, y, lastActo: true);
		}
	}
}
