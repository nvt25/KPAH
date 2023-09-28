using System;

public class MTickets : MyScreen
{
	public mVector vVs = new mVector();

	private sbyte numHp;

	private sbyte index;

	private int x0;

	private int y0;

	private int kc = 26;

	private int wcell = 46;

	public static MTickets me;

	private int timeOpen;

	private int timeHold;

	private int count;

	private int timeDelay;

	private bool canSel;

	private bool beginTouch;

	private bool isPaintFc;

	public static MTickets gi()
	{
		return (me != null) ? me : (me = new MTickets());
	}

	public void onHappy(Message msg)
	{
		try
		{
			vVs = new mVector();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < b; i++)
			{
				vVs.addElement(msg.reader().readByte() + string.Empty);
			}
		}
		catch (Exception)
		{
		}
	}

	public void sendSelectHp()
	{
		if (index >= 0 && index < vVs.size())
		{
			string s = (string)vVs.elementAt(index);
			int num = int.Parse(s);
			GameService.gI().sendTickets((sbyte)num);
		}
	}

	public override void paint(MyGraphics g)
	{
		Canvas.resetTrans(g);
		g.setColor(0);
		g.fillRect(0, 0, Canvas.w, Canvas.h);
		int num = x0;
		int num2 = y0;
		for (int i = 0; i < 3; i++)
		{
			g.setColor(Res.color[i]);
			g.fillRect(5 + i, 5 + i, Canvas.w - 10 - i * 2, Canvas.h - 50 - i * 2);
		}
		g.setColor(277044);
		g.fillRect(8, 8, Canvas.w - 16, Canvas.h - 56);
		g.drawImage(Res.imgInv[0], 3, 3, 0);
		g.drawRegion(Res.imgInv[0], 0, 0, 18, 19, 2, 5 + Canvas.w - 10 + 2, 3, MyGraphics.TOP | MyGraphics.RIGHT);
		g.drawRegion(Res.imgInv3, 0, 0, 18, 19, 2, 3, 5 + Canvas.h - 50 + 2, MyGraphics.BOTTOM | MyGraphics.LEFT);
		g.drawImage(Res.imgInv3, 5 + Canvas.w - 10 + 2, 5 + Canvas.h - 50 + 2, MyGraphics.BOTTOM | MyGraphics.RIGHT);
		g.setColor(6513507);
		g.fillRect(num, num2, wcell * 10, 260);
		g.setColor(0);
		for (int j = 0; j < 100; j++)
		{
			g.fillRect(num + 1 + j % 10 * wcell, num2 + 1 + j / 10 * kc, 44, kc - 2);
		}
		if (isPaintFc)
		{
			g.setColor(6568449);
			g.fillRect(num + 1 + index % 10 * wcell, num2 + 1 + index / 10 * kc, 44, kc - 2);
		}
		for (int k = 0; k < vVs.size(); k++)
		{
			string st = (string)vVs.elementAt(k);
			MFont.normalFont[1].drawString(g, st, num + 1 + k % 10 * wcell + wcell / 2, num2 + 1 + k / 10 * kc + 2, 2);
		}
		base.paint(g);
	}

	public override void update()
	{
		Canvas.gameScr.update();
		updateSelect();
		base.update();
	}

	public void updateSelect()
	{
		count++;
		if (timeOpen > 0)
		{
			timeOpen--;
			isPaintFc = true;
			if (timeOpen == 0 && canSel)
			{
				if (center != null)
				{
					center.perform();
				}
				canSel = false;
			}
			return;
		}
		if (Canvas.isPointerDownItem && Canvas.isPointer(x0, y0, 10 * wcell, 10 * kc))
		{
			timeDelay = count;
			beginTouch = true;
			Canvas.isPointerDownItem = false;
		}
		if (!beginTouch)
		{
			return;
		}
		if (Canvas.isPointerDown)
		{
			if (Main.canvas.canPutKey())
			{
				timeHold++;
				if (timeHold >= 5)
				{
					timeHold = 5;
					isPaintFc = true;
					checkSelect();
				}
			}
			else if (Canvas.canNotPutKey())
			{
				timeHold = 0;
				isPaintFc = false;
			}
		}
		if (!Canvas.isPointerRelease)
		{
			return;
		}
		long num = count - timeDelay;
		beginTouch = false;
		if (Main.canvas.canPutKey() && timeHold != 5)
		{
			if (num <= 4)
			{
				timeHold = 0;
				timeOpen = 5;
				canSel = true;
				checkSelect();
			}
		}
		else if (timeHold >= 5)
		{
			timeHold = 0;
			timeOpen = 5;
			canSel = true;
			checkSelect();
		}
	}

	public void checkSelect()
	{
		int num = (Canvas.pxLast - x0) / wcell;
		int num2 = (Canvas.pyLast - y0) / kc;
		index = (sbyte)(num2 * 10 + num);
		if (index <= 0)
		{
			index = 0;
		}
		if (index > 99)
		{
			index = 99;
		}
	}

	public override void updateKey()
	{
		base.updateKey();
	}

	public override void switchToMe()
	{
		base.switchToMe();
		init();
	}

	public override void init()
	{
		base.init();
		center = new Command();
		center.action = delegate
		{
			if (index >= 0 && index < vVs.size())
			{
				ActionPerform yesAction = delegate
				{
					sendSelectHp();
					Canvas.gameScr.switchToMe();
					index = 0;
					vVs.removeAllElements();
				};
				Canvas.startYesNoDlg("Bạn có muốn mua số này không ?", yesAction);
			}
			else
			{
				Canvas.startOKDlg("Chọn sai. Vui lòng chọn lại");
			}
		};
		right = new Command("Đóng");
		right.action = delegate
		{
			Canvas.gameScr.switchToMe();
			index = 0;
			vVs.removeAllElements();
		};
		x0 = Canvas.hw - 5 * wcell;
		y0 = (Canvas.h - 40) / 2 - 5 * kc;
		if (y0 < 10)
		{
			y0 = 10;
		}
		isPaintFc = false;
	}
}
