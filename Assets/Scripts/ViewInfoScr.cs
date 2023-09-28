public class ViewInfoScr : MyScreen
{
	private static ViewInfoScr me;

	private mVector text;

	private short w;

	private short h;

	private MyScreen lastScr;

	private int type;

	private short idClan = -1;

	private string title;

	private string status = string.Empty;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int selected;

	public static int lastSe;

	public sbyte nationID = -1;

	private int xa;

	private int dir = 1;

	public ViewInfoScr()
	{
		Command command = new Command("Đóng");
		ActionPerform actionPerform = command.action = delegate
		{
			lastScr.switchToMe();
			lastScr = null;
			text.removeAllElements();
			me = null;
		};
		right = command;
		left = new Command("Menu");
		ActionPerform action = delegate
		{
			mVector mVector = new mVector();
			if (type == 0)
			{
				if (Canvas.gameScr.mainChar.isMaster == 0)
				{
					Command command2 = new Command("Đặt slogan");
					ActionPerform actionPerform2 = command2.action = delegate
					{
						ActionPerform ok = delegate
						{
							string text = Canvas.inputDlg.tfInput.getText();
							if (!text.Equals(string.Empty))
							{
								GameService.gI().setSologan(text);
								status = text;
								Canvas.endDlg();
								xa = 0;
								dir = 1;
							}
						};
						Canvas.inputDlg.setInfo("Slogan", ok, TField.INPUT_TYPE_ANY, 50, isMaxW: false);
						Canvas.inputDlg.show();
					};
					mVector.addElement(command2);
				}
				Command command3 = new Command("Danh sách thành viên");
				ActionPerform actionPerform3 = command3.action = delegate
				{
					Canvas.startWaitDlg();
					GameService.gI().requestClanList(idClan, 0);
				};
				mVector.addElement(command3);
			}
			Canvas.menu.startAt(mVector, 0);
		};
		left.action = action;
		w = (short)Canvas.hw;
		h = 170;
		lastSe = (h - 30) / 2 / 14;
	}

	public static ViewInfoScr gI()
	{
		return (me != null) ? me : (me = new ViewInfoScr());
	}

	public override void switchToMe()
	{
		if (lastScr == null)
		{
			lastScr = Canvas.currentScreen;
		}
		base.switchToMe();
	}

	public void setInfo(string title, string str)
	{
		this.title = title;
		type = 2;
		text = new mVector();
		string[] array = MFont.normalFont[0].splitFontBStrInLine(str, w - 15);
		for (int i = 0; i < array.Length; i++)
		{
			text.addElement(array[i]);
		}
		setLim();
	}

	private void setLim()
	{
		cmyLim = text.size() * 14 - (h - 25) + 20;
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		cmy = (cmtoY = 0);
		selected = lastSe;
	}

	public void setInfo(ClanInfo clan)
	{
		title = clan.name.ToUpper();
		type = 0;
		idClan = clan.id;
		text = new mVector();
		status = clan.status;
		text.addElement("Bang chủ: " + clan.master);
		text.addElement("Cấp độ: " + clan.level);
		text.addElement("Xu: " + Canvas.getMoneys(clan.money));
		text.addElement("Thành viên: " + clan.members);
		text.addElement("Điểm cống hiến: " + clan.dedicationPoint);
		text.addElement("Điểm kinh ngiệm: " + clan.xp);
		text.addElement("Thành lập: " + clan.date);
		if (clan.dissolved)
		{
			string[] array = MFont.normalFont[0].splitFontBStrInLine(clan.strDissolved, w - 15);
			for (int i = 0; i < array.Length; i++)
			{
				text.addElement(array[i]);
			}
		}
		setLim();
	}

	public override void updateKey()
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
			if (selected > text.size() - lastSe + 1)
			{
				selected = text.size() - lastSe + 1;
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
		base.updateKey();
		if (lastScr != null)
		{
			lastScr.update();
		}
	}

	public override void paint(MyGraphics g)
	{
		if (lastScr != null)
		{
			lastScr.paint(g);
		}
		Canvas.resetTrans(g);
		g.translate(Canvas.hw - w / 2, Canvas.hh - h / 2);
		Res.paintDlgFull(g, 0, 0, w, h);
		g.setClip(-w / 2, 0, 2 * w, h);
		MFont.bigFont.drawString(g, title, w >> 1, 4, 2);
		g.setClip(0, 27, w, h - 30);
		g.translate(0, -cmy);
		if (type == 2)
		{
			paintText(g);
		}
		else
		{
			paintTextNormal(g);
		}
		base.paint(g);
	}

	private void paintTextNormal(MyGraphics g)
	{
		int num = 34;
		if (nationID > -1)
		{
			g.drawRegion(Res.imgNation, 0, nationID * 11, 11, 11, 0, 5, num, 20);
			num += 15;
		}
		for (int i = 0; i < text.size(); i++)
		{
			string st = (string)text.elementAt(i);
			MFont.arialFontW.drawString(g, st, 5, num, 0);
			num += 14;
		}
	}

	private void paintText(MyGraphics g)
	{
		int num = 34;
		if (idClan != -1)
		{
			GameData.paintIcon(g, (short)(idClan + 1000), w / 2, num);
			num += 6;
		}
		if (type == 0 && !status.Equals(string.Empty))
		{
			int width = MFont.arialFontW.getWidth(status);
			if (width > w)
			{
				if (dir == 1)
				{
					xa--;
				}
				else
				{
					xa++;
				}
				if (Math.abs(xa) > width / 2 - w / 2 + 10)
				{
					dir *= -1;
				}
			}
			g.setClip(3, 0, w - 6, h);
			MFont.borderFont.drawString(g, status, (w >> 1) + xa, num, 2);
			num += 14;
		}
		for (int i = 0; i < text.size(); i++)
		{
			string st = (string)text.elementAt(i);
			MFont.arialFontW.drawString(g, st, 5, num, 0);
			num += 14;
		}
	}
}
