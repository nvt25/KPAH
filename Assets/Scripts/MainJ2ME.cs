public abstract class MainJ2ME
{
	public Command left;

	public Command center;

	public Command right;

	public static int hTab = 45;

	public static int ITEM_HEIGHT = 40;

	public static int CHAR_HEIGHT = 20;

	private static bool isQwerty;

	public virtual void paint(MyGraphics g)
	{
		int num = GameMidlet.hDrawStringCmd - 2;
		Canvas.resetTrans(g);
		if (left != null && left.caption != string.Empty)
		{
			if (Canvas.pointCmdBar() != 1)
			{
				g.drawImage(Res.imgButtonBar, 4, Canvas.h - hTab + (hTab - Res.imgButtonBar.getHeight()) / 2 + 2, 0);
			}
			else
			{
				g.drawImage(Res.imgButtonBar1, 4, Canvas.h - hTab + (hTab - Res.imgButtonBar1.getHeight()) / 2 + 2, 0);
			}
			MFont.borderFont.drawString(g, left.caption, 4 + Res.imgButtonBar.getWidth() / 2, num + 2, 2);
		}
		if (center != null && center.caption != string.Empty)
		{
			if (Canvas.pointCmdBar() != 2)
			{
				g.drawImage(Res.imgButtonBar, Canvas.w / 2 - Res.imgButtonBar.getWidth() / 2, Canvas.h - hTab + (hTab - Res.imgButtonBar.getHeight()) / 2 + 2, 0);
			}
			else
			{
				g.drawImage(Res.imgButtonBar1, Canvas.w / 2 - Res.imgButtonBar1.getWidth() / 2, Canvas.h - hTab + (hTab - Res.imgButtonBar.getHeight()) / 2 + 2, 0);
			}
			MFont.borderFont.drawString(g, center.caption, Canvas.hw, num + 2, 2);
		}
		if (right != null && right.caption != string.Empty)
		{
			if (Canvas.pointCmdBar() != 3)
			{
				g.drawImage(Res.imgButtonBar, Canvas.w - Res.imgButtonBar.getWidth() - 4, Canvas.h - hTab + (hTab - Res.imgButtonBar.getHeight()) / 2 + 2, 0);
			}
			else
			{
				g.drawImage(Res.imgButtonBar1, Canvas.w - Res.imgButtonBar1.getWidth() - 4, Canvas.h - hTab + (hTab - Res.imgButtonBar.getHeight()) / 2 + 2, 0);
			}
			MFont.borderFont.drawString(g, right.caption, Canvas.w - Res.imgButtonBar.getWidth() / 2 - 4, num + 2, 2);
		}
	}

	public virtual void updateKey()
	{
		if (Canvas.isPointerClick && Math.abs(Canvas.pyLast - Canvas.py) <= 10 && Math.abs(Canvas.pxLast - Canvas.px) <= 10)
		{
			switch (Canvas.collisionCmdBar())
			{
			case 0:
				if (left != null && left.action != null)
				{
					left.perform();
					Canvas.isPointerClick = false;
				}
				break;
			case 1:
				if (center != null && center.action != null)
				{
					Canvas.endDlg();
					center.perform();
					Canvas.isPointerClick = false;
				}
				break;
			case 2:
				if (right != null && right.action != null)
				{
					right.perform();
					Canvas.isPointerClick = false;
				}
				break;
			}
		}
		if (Canvas.keyPressed[5])
		{
			if (center != null && center.action != null)
			{
				center.perform();
				Canvas.keyPressed[5] = false;
			}
		}
		else if (Canvas.keyPressed[12])
		{
			if (left != null && left.action != null)
			{
				left.perform();
				Canvas.keyPressed[12] = false;
			}
		}
		else if (Canvas.keyPressed[13] && right != null && right.action != null)
		{
			right.perform();
			Canvas.keyPressed[13] = false;
		}
	}
}
