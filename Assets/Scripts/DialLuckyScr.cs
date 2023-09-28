public class DialLuckyScr : MyScreen
{
	public class Gift
	{
		public short idPart;

		public sbyte type;

		public int xu;

		public int x;

		public int y;

		public int xp;

		public int luong;

		public string expire = string.Empty;
	}

	private static DialLuckyScr me;

	private Image imgCau_back;

	private Image imgDo;

	private Image imgDauHoi;

	private FrameImage imgFireWork;

	public int radius;

	public int degree;

	public int part;

	public int g;

	public int degreeKim;

	public int num;

	public int selectedNumber;

	private Position posCenter;

	private bool isTurn;

	private bool isPaint;

	private bool isable;

	public MyScreen lastScr;

	private Command cmdDial;

	private Command cmdWait;

	private Command cmdClose;

	private Command cmdErr;

	private Command cmdContinue;

	private Command cmdReChose;

	private mVector listGift = new mVector();

	private long timePaint;

	private bool[] isFireWork;

	private mVector listFireWork;

	public bool isStart;

	private MyRandom r = new MyRandom();

	private int hBorder;

	private static int[] posPaintX = new int[3];

	private static int[] posPaintY = new int[3];

	private sbyte cout = -1;

	public static sbyte[] arrayIndex = null;

	public DialLuckyScr()
	{
		FilePack.init(Main.res + "/qs/qs");
		imgDo = FilePack.getImg("8Chars");
		imgDauHoi = FilePack.getImg("q");
		imgFireWork = FrameImage.init("st", 11, 11);
		imgCau_back = FilePack.getImg("wood21");
		FilePack.reset();
		if (Canvas.w < 200)
		{
			radius = 80;
		}
		else
		{
			radius = 90;
		}
		posCenter = new Position(Canvas.w, Canvas.hh + 1);
		part = 30;
		num = 360 / part;
		ActionPerform action = delegate
		{
			isable = true;
		};
		cmdDial = new Command("Bắt đầu");
		cmdDial.action = action;
		ActionPerform action2 = delegate
		{
		};
		cmdWait = new Command("Xin chờ");
		cmdWait.action = action2;
		ActionPerform action3 = delegate
		{
			lastScr.switchToMe();
			doContinue();
			isStart = false;
		};
		cmdClose = new Command("Đóng");
		cmdClose.action = action3;
		ActionPerform action4 = delegate
		{
		};
		cmdReChose = new Command("Chọn lại");
		cmdReChose.action = delegate
		{
			doContinue();
			ItemQsScreen.gI().switchToMe();
			isStart = false;
		};
		cmdContinue = new Command("Tiếp tục");
		cmdContinue.action = delegate
		{
			doContinue();
			isStart = false;
			center = cmdDial;
			left = cmdErr;
			right = cmdClose;
		};
		cmdErr = new Command(string.Empty);
		cmdErr.action = action4;
		center = cmdDial;
		right = cmdClose;
		degreeKim = 90;
		isFireWork = new bool[3];
		listFireWork = new mVector();
		hBorder = MFont.borderFont.getHeight();
	}

	public static DialLuckyScr gI()
	{
		return (me != null) ? me : (me = new DialLuckyScr());
	}

	public override void switchToMe()
	{
		Canvas.keyHold[5] = false;
		base.switchToMe();
		doContinue();
		left = cmdErr;
	}

	protected void doContinue()
	{
		isPaint = false;
		isTurn = false;
		center = cmdDial;
		right = cmdClose;
		timePaint = 0L;
		for (int i = 0; i < 3; i++)
		{
			isFireWork[i] = false;
		}
		listFireWork.removeAllElements();
		listGift.removeAllElements();
		cout = -1;
	}

	public override void update()
	{
		if (lastScr != null)
		{
			lastScr.update();
		}
		if (g > 0)
		{
			degree -= g;
			if (degree < 0)
			{
				degree = 7200 + degree;
			}
			if (g < 10)
			{
				if (degree / 20 % 30 == 0)
				{
					g = 0;
				}
			}
			else
			{
				g--;
			}
		}
		else if (isTurn)
		{
			stop();
		}
		if (cout == 2 && listFireWork.size() == 0)
		{
			getResult();
			cout = 3;
		}
		if (!isPaint)
		{
			return;
		}
		if (center == cmdWait)
		{
			int num = 0;
			for (int i = 0; i < isFireWork.Length; i++)
			{
				if (isFireWork[i])
				{
					num++;
				}
			}
			if (num == 3)
			{
				center = cmdClose;
				left = cmdContinue;
				right = cmdReChose;
			}
		}
		for (int j = 0; j < listFireWork.size(); j++)
		{
			Point point = (Point)listFireWork.elementAt(j);
			point.x += point.g;
			if (point.g > 1 || point.g < -1)
			{
				point.g -= point.g / abs(point.g);
			}
			point.y += point.h;
			point.h++;
			point.color++;
			if (point.color > 20)
			{
				listFireWork.removeElement(point);
			}
		}
		if (arrayIndex == null)
		{
			return;
		}
		for (int k = 0; k < arrayIndex.Length; k++)
		{
			if (!isFireWork[k] && mSystem.getCurrentTimeMillis() / 100 - timePaint > (k + 1) * 5)
			{
				isFireWork[k] = true;
				addFire(posPaintX[k], posPaintY[k]);
			}
		}
	}

	private int abs(int a)
	{
		return (a >= 0) ? a : (-a);
	}

	private void addFire(int x, int y)
	{
		for (int i = 0; i < 10; i++)
		{
			int num = 1;
			if (i % 2 == 0)
			{
				num = -1;
			}
			Point point = new Point(x, y);
			point.color = 0;
			point.g = num * (r.nextInt(80) / 10);
			point.h = -r.nextInt(70) / 10;
			listFireWork.addElement(point);
		}
	}

	private void stop()
	{
		posPaintX = new int[arrayIndex.Length];
		posPaintY = new int[arrayIndex.Length];
		isTurn = false;
		isPaint = true;
		isable = false;
		timePaint = mSystem.getCurrentTimeMillis() / 100;
		for (int i = 0; i < arrayIndex.Length; i++)
		{
			int num = 0;
			switch (i)
			{
			case 0:
				num = 150;
				break;
			case 1:
				num = 180;
				break;
			default:
				num = 210;
				break;
			}
			num = Util.fixangle(num);
			int num2 = radius * Util.Cos(num) >> 10;
			int num3 = -(radius * Util.Sin(num)) >> 10;
			posPaintX[i] = posCenter.x + num2;
			posPaintY[i] = posCenter.y + num3;
		}
	}

	public override void updateKey()
	{
		if (!isPaint)
		{
			if (Canvas.collisionCmdBar() == 1)
			{
				if (Canvas.isPointerDown)
				{
					isable = true;
					Canvas.keyHold[5] = true;
				}
				if (Canvas.isPointerRelease)
				{
					Canvas.keyReleased[5] = true;
				}
			}
			if (Canvas.keyHold[5] && !isTurn && isable)
			{
				if (degreeKim < 270)
				{
					degreeKim += 3;
				}
			}
			else if (degreeKim > 90 && isStart)
			{
				degreeKim -= 3;
			}
			if (Canvas.keyReleased[5])
			{
				if (degreeKim > 90)
				{
					start();
				}
				Canvas.keyReleased[5] = false;
			}
		}
		base.updateKey();
	}

	private void start()
	{
		if (!isTurn && isable)
		{
			selectedNumber = degreeKim;
			GameService.gI().onStartLuckyDraw(ItemQsScreen.index);
			center = cmdWait;
		}
	}

	public void onStart()
	{
		center = cmdWait;
		g = 100 + (selectedNumber - 90);
		isTurn = true;
		right = cmdErr;
		isStart = true;
		Canvas.endDlg();
	}

	public override void paint(MyGraphics g)
	{
		if (lastScr != null)
		{
			lastScr.paint(g);
		}
		Canvas.resetTrans(g);
		int num = degree / 20;
		for (int i = 0; i < this.num; i++)
		{
			int num2 = num + i * part;
			if (num2 > 360)
			{
				num2 -= 360;
			}
			if (num2 >= 82 && num2 <= 278)
			{
				int a = Util.fixangle(num2);
				int num3 = radius * Util.Cos(a) >> 10;
				int num4 = -(radius * Util.Sin(a)) >> 10;
				g.drawImage(imgCau_back, posCenter.x + num3, posCenter.y + num4, 3);
			}
		}
		if (isPaint)
		{
			paintGift(g);
		}
		int num5 = 0;
		for (int j = 0; j < this.num; j++)
		{
			int num6 = num + j * part;
			if (num6 > 360)
			{
				num6 -= 360;
			}
			if (num6 >= 82 && num6 <= 278)
			{
				int a2 = Util.fixangle(num6);
				int num7 = radius * Util.Cos(a2) >> 10;
				int num8 = -(radius * Util.Sin(a2)) >> 10;
				long num9 = mSystem.getCurrentTimeMillis() / 100 - timePaint;
				if (!isPaint || num6 < 150 || num6 > 210 || (num9 <= (num5 + 1) * 5 && num9 > (num5 + 1) * 5 - 5))
				{
					g.drawImage(imgDauHoi, posCenter.x + num7, posCenter.y + num8, 3);
				}
				else
				{
					num5++;
				}
			}
		}
		g.setColor(9013127);
		g.fillRect(posCenter.x - 18, posCenter.y - 18, 18, 36);
		paintKim(g);
		g.drawRegion(imgDo, 0, 0, imgDo.getWidth(), imgDo.getHeight(), 0, posCenter.x, posCenter.y, MyGraphics.BOTTOM | MyGraphics.RIGHT);
		g.drawRegion(imgDo, 0, 0, imgDo.getWidth(), imgDo.getHeight(), 1, posCenter.x, posCenter.y, MyGraphics.TOP | MyGraphics.RIGHT);
		if (ItemQsScreen.index >= 0 && ItemQsScreen.index < ItemQsScreen.allItemLucky.size())
		{
			((ItemLuckyDraw)ItemQsScreen.allItemLucky.elementAt(ItemQsScreen.index))?.paint(g, posCenter.x - imgDo.getWidth() + 28, posCenter.y);
		}
		if (isPaint || this.g > 0)
		{
			paintFireWork(g);
		}
		base.paint(g);
	}

	private void paintFireWork(MyGraphics g)
	{
		for (int i = 0; i < listFireWork.size(); i++)
		{
			Point point = (Point)listFireWork.elementAt(i);
			int num = point.color / 5;
			if (num < 4)
			{
				imgFireWork.drawFrame(num, point.x, point.y, 0, 3, g);
			}
			cout++;
			if (cout >= 2)
			{
				cout = 2;
			}
		}
	}

	private void paintKim(MyGraphics g)
	{
		int a = Util.fixangle(degreeKim);
		int num = (radius / 3 + 2) * Util.Cos(a) >> 10;
		int num2 = -((radius / 3 + 2) * Util.Sin(a)) >> 10;
		int num3 = degreeKim + 90;
		if (num3 > 360)
		{
			num3 -= 360;
		}
		int a2 = Util.fixangle(num3);
		int num4 = 6 * Util.Cos(a2) >> 10;
		int num5 = -(6 * Util.Sin(a2)) >> 10;
		int num6 = degreeKim - 90;
		if (num6 < 0)
		{
			num6 = 360 + num6;
		}
		num6 = Util.fixangle(num6);
		int num7 = 6 * Util.Cos(num6) >> 10;
		int num8 = -(6 * Util.Sin(num6)) >> 10;
		g.setColor(13935404);
		int h = (degreeKim - 90) * 36 / 180;
		if (degreeKim - 90 <= 0)
		{
			h = 0;
		}
		g.fillRect(posCenter.x - 18, posCenter.y - 18, 18, h);
	}

	public void getResult()
	{
		string text = "Bạn nhận được: ";
		if (arrayIndex != null)
		{
			for (int i = 0; i < arrayIndex.Length; i++)
			{
				if (mSystem.getCurrentTimeMillis() / 100 - timePaint > (i + 1) * 5)
				{
					ItemLuckyDraw itemLuckyDraw = (ItemLuckyDraw)ItemQsScreen.allItemLucky.elementAt(arrayIndex[i]);
					text = text + "\n" + itemLuckyDraw.name;
				}
			}
		}
		Canvas.startOKDlg(text);
	}

	private void paintGift(MyGraphics g)
	{
		if (arrayIndex == null)
		{
			return;
		}
		for (int i = 0; i < arrayIndex.Length; i++)
		{
			if (mSystem.getCurrentTimeMillis() / 100 - timePaint > (i + 1) * 5)
			{
				ItemLuckyDraw itemLuckyDraw = (ItemLuckyDraw)ItemQsScreen.allItemLucky.elementAt(arrayIndex[i]);
				itemLuckyDraw.paint(g, posPaintX[i], posPaintY[i]);
			}
		}
	}
}
