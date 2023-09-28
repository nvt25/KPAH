public class MsgDlg : Dialog
{
	protected string[] info;

	public int[] translate = new int[4]
	{
		0,
		7,
		3,
		6
	};

	public int state;

	private long time;

	public byte size;

	public bool isIcon = true;

	public bool isShowDelay;

	private int w;

	private int h;

	private int ySt;

	private int y;

	public mVector listDelay;

	private int selected;

	private int dis;

	private int disLim;

	private int wText;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int lastSe;

	public bool isUseArr;

	public int hArr;

	public string[] arr;

	private int dir = 1;

	private int x2;

	public void setInfo(string info, Command left, Command center, Command right)
	{
		this.info = MFont.arialFont.splitFontBStrInLine(info, Canvas.w / 2);
		base.left = left;
		base.center = center;
		base.right = right;
		isShowDelay = false;
		init();
		selected = lastSe;
		isUseArr = false;
	}

	public void setInfo(string[] info2, Command left, Command center, Command right)
	{
		info = info2;
		base.left = left;
		base.center = center;
		base.right = right;
		isShowDelay = false;
		init();
		selected = lastSe;
		isUseArr = false;
	}

	public void setInfoArr(string info, string[] arr, Command left, Command center, Command right)
	{
		this.info = MFont.arialFontW.splitFontBStrInLine(info, Canvas.w / 2);
		base.left = left;
		base.center = center;
		base.right = right;
		isShowDelay = false;
		this.arr = arr;
		init();
		selected = lastSe;
		hArr = arr.Length * MainJ2ME.CHAR_HEIGHT + MainJ2ME.CHAR_HEIGHT * this.info.Length;
		isUseArr = true;
	}

	public void init()
	{
		w = Canvas.w - 40;
		h = 20;
		dis = 100;
		y = Canvas.hh - 42;
		ySt = 15;
		if (isIcon)
		{
			dis -= 50;
			ySt += 50;
		}
		disLim = dis + 20;
		if (info.Length * MainJ2ME.CHAR_HEIGHT < dis)
		{
			ySt += dis / 2 - info.Length * MainJ2ME.CHAR_HEIGHT / 2;
			disLim -= dis - info.Length * MainJ2ME.CHAR_HEIGHT;
		}
		cmyLim = info.Length * MainJ2ME.CHAR_HEIGHT - dis;
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		lastSe = dis / 2 / MainJ2ME.CHAR_HEIGHT;
	}

	public void paintArr(MyGraphics g)
	{
		Canvas.resetTrans(g);
		int num = Canvas.hh - hArr / 2 - 20;
		if (num <= 10)
		{
			num = 10;
		}
		Res.paintDlgDragonFull(g, 70, num, Canvas.w - 140, hArr + 20);
		int num2 = 10;
		for (int i = 0; i < arr.Length; i++)
		{
			MFont.arialFontW.drawString(g, arr[i], Canvas.hw, i * MainJ2ME.CHAR_HEIGHT + num2 + num, 2);
		}
		num2 += 32;
		for (int j = 0; j < info.Length; j++)
		{
			MFont.normalFont[0].drawString(g, info[j], Canvas.hw, j * MainJ2ME.CHAR_HEIGHT + (arr.Length - 1) * MainJ2ME.CHAR_HEIGHT + num2 + num - 4, 2);
		}
		g.translate(0, y);
	}

	public override void paint(MyGraphics g)
	{
		Canvas.resetTrans(g);
		g.translate(0, y);
		if (isUseArr)
		{
			paintArr(g);
		}
		else
		{
			Res.paintDlgDragonFull(g, 70, 12, Canvas.w - 140, 100);
			if (isIcon)
			{
				g.drawRegion(Res.imgWaitIcon, 0, 0, 25, 25, translate[state], Canvas.hw, 47, 3);
			}
			g.translate(0, ySt);
			g.setClip(0, 0, Canvas.w, disLim);
			g.translate(0, -cmy);
			for (int i = 0; i < info.Length; i++)
			{
				MFont.arialFontW.drawString(g, info[i], Canvas.hw, i * MainJ2ME.CHAR_HEIGHT, 2);
			}
		}
		base.paint(g);
	}

	public override void update()
	{
		state++;
		if (state > 3)
		{
			state = 0;
		}
		bool flag = false;
		if (Canvas.keyHold[2])
		{
			selected--;
			if (selected < lastSe)
			{
				selected = lastSe;
			}
			flag = true;
		}
		else if (Canvas.keyHold[8])
		{
			flag = true;
			if (cmy < cmyLim)
			{
				selected++;
			}
			if (selected > info.Length - lastSe)
			{
				selected = info.Length - lastSe;
			}
		}
		if (flag)
		{
			cmtoY = selected * 13 - dis / 2;
			if (cmtoY < 0)
			{
				cmtoY = 0;
			}
			if (cmtoY > cmyLim)
			{
				cmtoY = cmyLim;
			}
		}
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
		base.update();
	}
}
