public class MsgWorld : MyScreen
{
	public static MsgWorld me;

	public int cmtoY;

	public int cmy;

	public int cmdy;

	public int cmvy;

	public int cmyLim;

	public int selected;

	public int limSelect;

	public mVector data = new mVector();

	private bool trans;

	private int pa;

	public MsgWorld()
	{
		ActionPerform action = delegate
		{
			Canvas.gameScr.switchToMe();
			selected = (limSelect = 0);
		};
		right = new Command("Đóng");
		right.action = action;
	}

	public static MsgWorld gI()
	{
		return (me != null) ? me : (me = new MsgWorld());
	}

	public override void switchToMe()
	{
		base.switchToMe();
		init();
	}

	public override void init()
	{
		data = new mVector();
		for (int i = 0; i < GameScr.savemsgWorld.size(); i++)
		{
			MsgInfo msgInfo = (MsgInfo)GameScr.savemsgWorld.elementAt(i);
			msgInfo.arr = MFont.arialFontW.splitFontBStrInLine(msgInfo.message, Canvas.w - 44);
			data.addElement(msgInfo);
			limSelect += msgInfo.arr.Length;
		}
		cmyLim = limSelect * 15 - (Canvas.h - 60) + 35;
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		cmy = (cmtoY = 0);
	}

	public override void paint(MyGraphics g)
	{
		Canvas.gameScr.paint(g);
		Res.paintDlgFull(g, 20, 20, Canvas.w - 40, Canvas.h - 60);
		MFont.bigFont.drawString(g, "Kênh thế giới", Canvas.w / 2, 26, 2);
		g.setClip(20, 46, Canvas.w - 40, Canvas.h - 90);
		g.translate(20, 47);
		g.translate(0, -cmy);
		int num = 2;
		for (int i = 0; i < data.size(); i++)
		{
			MsgInfo msgInfo = (MsgInfo)data.elementAt(i);
			for (int j = 0; j < msgInfo.arr.Length; j++)
			{
				MFont.arialFontW.drawString(g, msgInfo.arr[j], 8, num, 0);
				num += 15;
			}
		}
		Canvas.resetTrans(g);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		base.paint(g);
	}

	public override void updateKey()
	{
		bool flag = false;
		if (Canvas.isPointer(20, 20, Canvas.w - 40, Canvas.h - 60))
		{
			if (Canvas.isPointerDown)
			{
				if (!trans)
				{
					pa = cmy;
					trans = true;
				}
				if (Math.abs(Canvas.pyLast - Canvas.py) != 0)
				{
					cmtoY = pa + (Canvas.pyLast - Canvas.py);
					if (cmtoY < 0)
					{
						cmtoY = 0;
					}
					if (cmtoY > cmyLim)
					{
						cmtoY = cmyLim;
					}
				}
			}
			if (Canvas.isPointerClick)
			{
				Canvas.isPointerClick = false;
				selected = (cmtoY + Canvas.py - 47) / 15;
				if (selected > limSelect - 1)
				{
					selected = limSelect - 1;
				}
				if (selected < 0)
				{
					selected = 0;
				}
				trans = false;
			}
		}
		if (Canvas.keyPressed[8])
		{
			Canvas.keyPressed[8] = false;
			selected++;
			if (selected > limSelect - 1)
			{
				selected = limSelect - 1;
			}
			flag = true;
		}
		else if (Canvas.keyPressed[2])
		{
			Canvas.keyPressed[2] = false;
			selected--;
			if (selected < 0)
			{
				selected = 0;
			}
			flag = true;
		}
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
			if (cmy < 0)
			{
				cmy = 0;
			}
			if (cmy > cmyLim)
			{
				cmy = cmyLim;
			}
		}
		if (flag)
		{
			cmtoY = selected * 15 - (Canvas.h - 60) / 5;
		}
		base.updateKey();
	}

	public override void update()
	{
		Canvas.gameScr.update();
		base.update();
	}
}
