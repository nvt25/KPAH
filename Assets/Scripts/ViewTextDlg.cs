public class ViewTextDlg : Dialog
{
	private static ViewTextDlg me;

	private string[] list;

	private string title;

	private int x;

	private int y;

	private int w;

	private int h;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int selected;

	public static int lastSe;

	public ViewTextDlg()
	{
		x = 50;
		y = 20;
		w = Canvas.w - 100;
		h = Canvas.h - 40 - MyScreen.deltaY;
		ActionPerform action = delegate
		{
			Canvas.currentDialog = null;
		};
		right = new Command("Đóng");
		right.action = action;
		lastSe = (h - 30) / 2 / 14;
	}

	public static ViewTextDlg gI()
	{
		return (me != null) ? me : (me = new ViewTextDlg());
	}

	public void setInfo(string list, string title)
	{
		this.list = MFont.arialFontW.splitFontBStrInLine(list, w - 15);
		this.title = title;
		cmyLim = this.list.Length * 14 - (h - 25) + 15;
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		cmy = (cmtoY = 0);
		selected = lastSe;
		show();
	}

	public override void paint(MyGraphics g)
	{
		Canvas.resetTrans(g);
		Res.paintDlgFull(g, x, y, w, h);
		MFont.bigFont.drawString(g, title, x + w / 2, y + 2, 2);
		g.translate(x, y + 25);
		g.setClip(0, 0, w, h - 30);
		g.translate(0, -cmy);
		int num = cmy / 14;
		int num2 = num + h / 14 + 1;
		if (num2 >= list.Length)
		{
			num2 = list.Length;
		}
		for (int i = num; i < num2; i++)
		{
			MFont.arialFontW.drawString(g, list[i], 7, 5 + i * 14, 0);
		}
		base.paint(g);
	}

	public override void update()
	{
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
			if (selected > list.Length - lastSe + 1)
			{
				selected = list.Length - lastSe + 1;
			}
		}
		if (flag)
		{
			cmtoY = selected * 14 - (h - 25) / 2;
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
		updateKey();
	}
}
