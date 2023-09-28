public class ItemQsScreen : MyScreen
{
	public static ItemQsScreen me;

	public MyScreen last;

	public Scroll mScroll = new Scroll();

	public static sbyte totalItemSelect = 0;

	public static mVector allItemLucky = new mVector();

	public static int xBg;

	public static int yBg;

	public static int w;

	public static int h;

	public static int index;

	public static int nC = 8;

	public static int nH;

	public static short total = 32;

	private int sizeCell = 20;

	public ItemQsScreen()
	{
		xBg = Canvas.w / 2 - 80 - 10;
		yBg = Canvas.hh - 40 - 10;
		w = 170;
		h = 90;
	}

	public static ItemQsScreen gI()
	{
		return (me != null) ? me : (me = new ItemQsScreen());
	}

	public void resetData()
	{
		mScroll.clear();
		totalItemSelect = 0;
		allItemLucky = new mVector();
		total = 32;
		index = 0;
	}

	public override void paint(MyGraphics g)
	{
		if (last != null)
		{
			last.paint(g);
		}
		Canvas.resetTrans(g);
		Res.paintDlgDragonFull(g, xBg, yBg, w, h);
		int num = total;
		mScroll.setStyle(num / nC, sizeCell, xBg + 5, yBg + 5, w, h - 5, styleUPDOWN: true, 8);
		mScroll.setClip(g, xBg + 5, yBg + 5, w, h - 3);
		int num2 = index / nC;
		int num3 = index - num2 * nC;
		g.setColor(10595790);
		g.fillRect(xBg + num3 * sizeCell + 5, yBg + num2 * sizeCell + 5, sizeCell, sizeCell);
		sbyte b = 0;
		sbyte b2 = 0;
		for (int i = 0; i < allItemLucky.size(); i++)
		{
			ItemLuckyDraw itemLuckyDraw = (ItemLuckyDraw)allItemLucky.elementAt(i);
			if (itemLuckyDraw.isSelect == 1)
			{
				itemLuckyDraw.paint(g, xBg + b * sizeCell + sizeCell / 2 + 5, yBg + b2 * sizeCell + sizeCell / 2 + 5);
				b = (sbyte)(b + 1);
				if (b >= nC)
				{
					b = 0;
					b2 = (sbyte)(b2 + 1);
				}
				continue;
			}
			break;
		}
		for (int j = 0; j < nH; j++)
		{
			for (int k = 0; k < nC; k++)
			{
				g.setColor(8684162);
				g.drawRect(xBg + k * sizeCell + 5, yBg + j * sizeCell + 5, sizeCell, sizeCell);
			}
		}
		base.paint(g);
	}

	public override void switchToMe()
	{
		base.switchToMe();
		ActionPerform action = delegate
		{
			doselect();
		};
		center = new Command("Chọn");
		center.action = action;
		ActionPerform action2 = delegate
		{
			if (index < allItemLucky.size() && index >= 0)
			{
				ItemLuckyDraw itemLuckyDraw = (ItemLuckyDraw)allItemLucky.elementAt(index);
				if (itemLuckyDraw.isSelect == 1)
				{
					DialLuckyScr.gI().switchToMe();
					DialLuckyScr.gI().lastScr = gI().last;
					DialLuckyScr.gI().degreeKim = 90;
					DialLuckyScr.gI().isStart = false;
				}
				else
				{
					Canvas.startOKDlg("Vui lòng chọn 1 vật phẩm để quay số.");
				}
			}
		};
		left = new Command("Quay số");
		left.action = action2;
		ActionPerform action3 = delegate
		{
			resetData();
			last.switchToMe();
		};
		right = new Command("Đóng");
		right.action = action3;
		mScroll.clear();
	}

	protected void doselect()
	{
		if (index < allItemLucky.size() && index >= 0)
		{
			ItemLuckyDraw itemLuckyDraw = (ItemLuckyDraw)allItemLucky.elementAt(index);
			if (itemLuckyDraw.isSelect == 1)
			{
				Canvas.startOKDlg(itemLuckyDraw.getDecript());
			}
		}
	}

	public override void update()
	{
		if (last != null)
		{
			last.update();
		}
		if (Canvas.currentDialog == null)
		{
			ScrollResult scrollResult = mScroll.updateKey();
			if (scrollResult.isDowning || scrollResult.isFinish)
			{
				index = scrollResult.selected;
			}
			nH = total / nC;
			mScroll.updatecm();
		}
		base.update();
	}

	public override void updateKey()
	{
		if (Canvas.keyPressed[2])
		{
			Canvas.keyPressed[2] = false;
			if (index >= 0 && index < nC)
			{
				index = 0;
			}
			else if (index - nC >= 0)
			{
				index -= nC;
			}
			mScroll.moveTo(index / nC * sizeCell);
		}
		else if (Canvas.keyPressed[8])
		{
			Canvas.keyPressed[8] = false;
			if (index + nC <= total - 1)
			{
				index += nC;
			}
			mScroll.moveTo(index / nC * sizeCell);
		}
		else if (Canvas.keyPressed[4])
		{
			Canvas.keyPressed[4] = false;
			index--;
			if (index < 0)
			{
				index = total - 1;
			}
			mScroll.moveTo(index / nC * sizeCell);
		}
		else if (Canvas.keyPressed[6])
		{
			Canvas.keyPressed[6] = false;
			index++;
			if (index > total)
			{
				index = 0;
			}
			mScroll.moveTo(index / nC * sizeCell);
		}
		base.updateKey();
	}
}
