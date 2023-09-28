using System;

public class MenuWindows : MyScreen
{
	public static MenuWindows me;

	public int wTab;

	public new int hTab = 25;

	public int wKhung;

	public int hKhung;

	public int xKhung;

	public int yKhung;

	public int wSubTab;

	public int selected;

	public int numW = 7;

	public int numH;

	public int xShow;

	public int yShow;

	public int wShow;

	public int w;

	public int h;

	public int hShow;

	public int wSmall;

	public int hSmall;

	public int x0;

	public int y0;

	public int idFrame;

	public int countPop;

	public static int cmtoYText;

	public static int cmyText;

	public static int cmdyText;

	public static int cmvyText;

	public static int cmyLimText;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int cmtoX;

	public static int cmx;

	public static int cmdx;

	public static int cmvx;

	public static int cmxLim;

	public static int cmtoXTab;

	public static int cmxTab;

	public static int cmdxTab;

	public static int cmvxTab;

	public static int cmxLimTab;

	public static int cmtoXSubTab;

	public static int cmxSubTab;

	public static int cmdxSubTab;

	public static int cmvxSubTab;

	public static int cmxLimSubTab;

	public static int cmtoYParty;

	public static int cmyParty;

	public static int cmdyParty;

	public static int cmvyParty;

	public static int cmyLimParty;

	private MyScreen lastScr;

	public int focusTabChinh = 2;

	public int focusTabCuaHang = 1;

	public static int focusTab;

	private string[] tabName = new string[10] { "C.hàng", "H.trang", "Trang bị", "T.bị thú", "Kỹ năng", "T.năng", "N.vụ", "Cài đặt", "Bang hội", "Khác" };

	private string[] tabCuaHang = new string[3] { "Gian hàng 1", "Gian hàng 2", "Gian hàng 3" };

	private string[] tabSkill = new string[3] { "Level 1", "Level 2", "Level 3" };

	private string[] tabCaiDat = new string[6] { "Bản đồ lớn", "Hướng dẫn", "Bật/tắt lời mời", "Bật/tắt giao diện", "Bật/tắt tự động đánh", "Chế độ focus" };

	private string[] tabKhac = new string[9] { "Tin nhắn", "Kênh thế giới", "Bạn bè", "Top cao thủ", "Top đại gia", "Bảng top", "Cây thần", "Cổ vật", "Khác" };

	public bool isDefault;

	public bool isLoad;

	public bool isChangeTab = true;

	public bool isPaintMoney;

	public bool isSell;

	public bool isShowText;

	public bool trans;

	public bool isTextArr;

	public bool leftRightSetting;

	public static Char charWearing;

	public static sbyte[] index;

	private sbyte[] arrayKhamNgoc;

	public mVector list = new mVector();

	private string[] showText;

	private int limMyBag;

	private int countTabMyitem;

	private int excess;

	private int maxSize;

	private int pb;

	private int pa;

	private int paTab;

	private string[] nameClan;

	public static int yTr;

	public static int xTr;

	public int[][] arrFrame = new int[2][]
	{
		new int[3] { 0, 1, 2 },
		new int[2] { 0, 1 }
	};

	public int countFrame;

	private int xCus = -20;

	private int saveSelect;

	private int countClick;

	private int tdy;

	private int tdx;

	private int indexUseKey;

	private bool isFocusMainTab = true;

	private Image imgCharWear;

	private int hView;

	private int addHclip;

	private int xInfo;

	private int yInfo;

	private int wCell = 32;

	private int hCell = 32;

	public int selectConfig;

	private int newSise = 42;

	private int smallS = 34;

	private int yaddBag;

	private mVector questInfo;

	public int saveSelected;

	private bool first;

	private static sbyte[] idWearChar = new sbyte[10] { 12, -1, 0, 9, 2, 8, 1, 8, 10, 11 };

	private static sbyte[] idWearAnimal = new sbyte[10] { 18, 19, 14, 20, 15, 21, 16, 22, 17, 23 };

	private static sbyte[][] posWearChar = new sbyte[10][]
	{
		new sbyte[2] { 10, 11 },
		new sbyte[2] { 56, 11 },
		new sbyte[2] { 10, 32 },
		new sbyte[2] { 56, 32 },
		new sbyte[2] { 10, 52 },
		new sbyte[2] { 56, 52 },
		new sbyte[2] { 10, 73 },
		new sbyte[2] { 56, 94 },
		new sbyte[2] { 10, 94 },
		new sbyte[2] { 56, 94 }
	};

	private string[] charInfo;

	public Command cmdShop;

	public mVector potionShop = new mVector();

	private int www = 180;

	public static int[] posPaintWearingX = new int[20]
	{
		15 + xTr,
		15 + xTr,
		15 + xTr,
		165 + xTr,
		165 + xTr,
		165 + xTr,
		165 + xTr,
		165 + xTr,
		165 + xTr,
		165 + xTr,
		15 + xTr,
		165 + xTr,
		15 + xTr,
		115 + xTr,
		15 + xTr,
		15 + xTr,
		15 + xTr,
		15 + xTr,
		15 + xTr,
		34 + xTr
	};

	public static int[] posPaintWearingY = new int[20]
	{
		56 + yTr,
		140 + yTr,
		96 + yTr,
		16 + yTr,
		16 + yTr,
		16 + yTr,
		16 + yTr,
		16 + yTr,
		96 + yTr,
		56 + yTr,
		180 + yTr,
		180 + yTr,
		16 + yTr,
		180 + yTr,
		56 + yTr,
		96 + yTr,
		140 + yTr,
		180 + yTr,
		16 + yTr,
		92 + yTr
	};

	public bool transY;

	public bool transX;

	public bool canSelecet;

	public bool isTabIp;

	public bool isPaintFc;

	private long timePointY;

	private long timePointX;

	private long count;

	private long timeOpen;

	private long timeDelay;

	private int pxLast;

	private int pyLast;

	private int xCamLast;

	private int dyTran;

	private int dxTran;

	private int hOne = 44;

	private int wOne = 44;

	private int sizeW;

	private int sizeH;

	private int disX;

	private int xBegin;

	private int yBegin;

	private int wTouch;

	private int hTouch;

	private int curentTabUpdate;

	private int timeHold;

	public float vY;

	public float vX;

	public bool transYShowText;

	private long timePointYt;

	private long timeOpent;

	private long timeDelayt;

	private int pyLastt;

	private int dyTrant;

	private int dxTrant;

	private int xBegint;

	private int yBegint;

	private int wToucht;

	private int hToucht;

	private int countShowText;

	public float vYT;

	public MenuWindows()
	{
		init();
		ActionPerform action = delegate
		{
			focusTabChinh = 2;
			focusTabCuaHang = 1;
			cmxTab = 0;
			cmxSubTab = 0;
			cmtoXTab = 0;
			cmtoXSubTab = 0;
			selected = 0;
			index = null;
			charInfo = null;
			closeText();
			Canvas.gameScr.switchToMe();
			list.removeAllElements();
		};
		right = new Command("Đóng");
		right.action = action;
	}

	public void initName()
	{
		if (Canvas.gameScr.mainChar.idClan == -1)
		{
			nameClan = new string[2] { "Top bang hội", "Đăng ký bang hội" };
		}
		else if (Canvas.gameScr.mainChar.isMaster == 0)
		{
			nameClan = new string[9] { "Top bang hội", "Nhiệm vụ", "Thành viên bang hội", "Thông tin bang hội", "Tin nhắn bang hội", "Kỹ năng", "Chat toàn bang", "Quyên góp", "Giải tán bang hội" };
			if (Char.dissolved)
			{
				nameClan[8] = "Phục hồi bang hội";
			}
		}
		else
		{
			nameClan = new string[9] { "Top bang hội", "Nhiệm vụ", "Thành viên bang hội", "Thông tin bang hội", "Tin nhắn bang hội", "Kỹ năng", "Chat toàn bang", "Quyên góp", "Rời bang" };
		}
	}

	public static MenuWindows gI()
	{
		return (me != null) ? me : (me = new MenuWindows());
	}

	public override void switchToMe()
	{
		lastScr = Canvas.currentScreen;
		base.switchToMe();
		init();
		isChangeTab = true;
		focusTabChinh = 2;
		Khoitao();
		leftRightSetting = false;
		isPaintFc = false;
		closeText();
		isFocusMainTab = true;
	}

	private void Khoitao()
	{
		setInfo(0, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
		charWearing = Canvas.gameScr.mainChar;
		setImageCharWear();
		setSelectTab();
		setCmdCenter();
		indexUseKey = 0;
	}

	public override void init()
	{
		selected = 0;
		wKhung = Canvas.w - 20;
		hKhung = Canvas.h - 60;
		if (hKhung > GameMidlet.MAX_H - 60)
		{
			hKhung = GameMidlet.MAX_H - 60;
		}
		if (wKhung > GameMidlet.MAX_W - 20)
		{
			wKhung = GameMidlet.MAX_W - 20;
		}
		if (Canvas.w * Canvas.h > 153600)
		{
			xTr = (Canvas.w - wKhung) / 2;
			yTr = (Canvas.h - hKhung) / 2;
		}
		xKhung = 10;
		yKhung = 20;
		wTab = 70;
		wSubTab = wKhung / 3;
		cmx = 0;
		cmtoXTab = 0;
		cmxTab = 0;
		cmxLimTab = tabName.Length * wTab - wKhung;
		posPaintWearingX = new int[20]
		{
			15 + xTr,
			15 + xTr,
			15 + xTr,
			165 + xTr,
			165 + xTr,
			165 + xTr,
			165 + xTr,
			165 + xTr,
			165 + xTr,
			165 + xTr,
			15 + xTr,
			165 + xTr,
			15 + xTr,
			115 + xTr,
			15 + xTr,
			15 + xTr,
			15 + xTr,
			15 + xTr,
			15 + xTr,
			58 + xTr
		};
		posPaintWearingY = new int[20]
		{
			56 + yTr,
			140 + yTr,
			96 + yTr,
			16 + yTr,
			16 + yTr,
			16 + yTr,
			16 + yTr,
			16 + yTr,
			96 + yTr,
			56 + yTr,
			180 + yTr,
			180 + yTr,
			16 + yTr,
			180 + yTr,
			56 + yTr,
			96 + yTr,
			140 + yTr,
			180 + yTr,
			16 + yTr,
			184 + yTr
		};
	}

	public override void paint(MyGraphics g)
	{
		Canvas.gameScr.paint(g);
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		paintTab(g, xKhung + xTr, yKhung + yTr, wKhung, hKhung);
		Canvas.resetTrans(g);
		base.paint(g);
	}

	public override void update()
	{
		lastScr.update();
		if (cmxTab != cmtoXTab)
		{
			cmvxTab = cmtoXTab - cmxTab << 2;
			cmdxTab += cmvxTab;
			cmxTab += cmdxTab >> 4;
			cmdxTab &= 15;
		}
		if (cmxSubTab != cmtoXSubTab)
		{
			cmvxSubTab = cmtoXSubTab - cmxSubTab << 2;
			cmdxSubTab += cmvxSubTab;
			cmxSubTab += cmdxSubTab >> 4;
			cmdxSubTab &= 15;
		}
		if (cmyParty != cmtoYParty)
		{
			cmvyParty = cmtoYParty - cmyParty << 2;
			cmdyParty += cmvyParty;
			cmyParty += cmdyParty >> 4;
			cmdyParty &= 15;
		}
		updateKeyShowText();
		updateTab();
		moveCameraTab();
		updateKeyDong();
		moveCamera();
		if (focusTabChinh != 4 || charWearing == null || charWearing.imgAnimal == null)
		{
			return;
		}
		if (Canvas.gameTick % charWearing.timeChangeFrame == 0)
		{
			countFrame++;
			if (countFrame > arrFrame[(charWearing.numFrame != 3) ? 1u : 0u].Length - 1)
			{
				countFrame = 0;
			}
		}
		idFrame = arrFrame[(charWearing.numFrame != 3) ? 1u : 0u][countFrame];
	}

	public override void updateKey()
	{
		if ((Canvas.currentDialog == null || !Canvas.menu.showMenu) && isShowText)
		{
			xBegint = xShow;
			yBegint = y0;
			wToucht = wKhung - (x0 + 5 * (wCell + 12)) - 1;
			hToucht = Canvas.h - 60;
		}
		updateKeyMain();
		base.updateKey();
	}

	private void updateKeyMain()
	{
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		int num = 34;
		if (focusTabChinh == 2)
		{
			if (Canvas.isPointer(x0 - 5 + xTr, y0 + hView + addHclip + yTr, 40, 30))
			{
				if (Canvas.isPointerClick)
				{
					Canvas.isPointerClick = false;
					countTabMyitem--;
					if (countTabMyitem < 0)
					{
						countTabMyitem = limMyBag;
					}
					setSize(5 * wCell, 112, 7, 9, num, num);
					selected = 0;
					closeText();
				}
			}
			else if (Canvas.isPointer(x0 + 5 * wCell + xTr, y0 + hView + addHclip + yTr, 50, 30) && Canvas.isPointerClick)
			{
				Canvas.isPointerClick = false;
				countTabMyitem++;
				if (countTabMyitem > limMyBag)
				{
					countTabMyitem = 0;
				}
				setSize(5 * wCell, 112, 7, 9, num, num);
				selected = 0;
				closeText();
			}
		}
		if (focusTabChinh == 1 || focusTabChinh == 2)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 - 10 + xTr;
			yBegin = y0 - 10 + yTr;
			wTouch = 5 * (wCell + 12) + 10;
			hTouch = hView + addHclip;
		}
		else if (focusTabChinh == 3)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 + xTr;
			yBegin = y0 + yTr;
			wTouch = 200;
			hTouch = 200;
		}
		else if (focusTabChinh == 4)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 + xTr;
			yBegin = y0 + yTr;
			wTouch = 200;
			hTouch = 200;
		}
		else if (focusTabChinh == 5)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 - 10 + xTr;
			yBegin = y0 - 10 + yTr;
			wTouch = 270;
			hTouch = 160;
		}
		else if (focusTabChinh == 6)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 + xTr;
			yBegin = y0 + 2 + yTr;
			wTouch = Res.imgInfoWindow[1].getWidth();
			hTouch = Res.imgInfoWindow[1].getHeight() + 40;
		}
		else if (focusTabChinh == 7)
		{
			if (Canvas.isPointer(x0 - 10 + xTr, y0 - 10 + yTr, 140, 130) && !Canvas.menu.showMenu)
			{
				int i = Canvas.pyLast - Canvas.py;
				int num2 = Canvas.pxLast - Canvas.px;
				if (!Canvas.isMove && !Canvas.isPointerClick)
				{
					trans = false;
				}
				if (Canvas.isPointerDown)
				{
					if (!trans)
					{
						pb = cmy;
						trans = true;
					}
					if (Math.abs(i) > 10)
					{
						cmtoY = pb + (Canvas.pyLast - Canvas.py);
						if (cmtoY < -10)
						{
							cmtoY = -10;
						}
						if (cmtoY > cmyLim)
						{
							cmtoY = cmyLim;
						}
					}
					int num3 = (cmtoY + Canvas.py - (y0 - 5) - yTr) / hSmall;
					int num4 = (cmtoX + Canvas.px - (x0 - 5) - xTr) / wSmall;
					selected = num3 * numW + num4;
				}
				if (Canvas.isPointerClick)
				{
					xCus = -20;
					isChangeTab = false;
					Canvas.isPointerClick = false;
					trans = false;
				}
				if (cmy != cmtoY)
				{
					cmvy = cmtoY - cmy << 2;
					cmdy += cmvy;
					cmy += cmdy >> 4;
					cmdy &= 15;
				}
			}
			else
			{
				if (!Canvas.isPointer(x0 + 140 + xTr, y0 + yTr, wKhung - (x0 - 2 + 140), 140) || Canvas.menu.showMenu)
				{
					return;
				}
				int i2 = Canvas.pyLast - Canvas.py;
				int i3 = Canvas.pxLast - Canvas.px;
				if (!Canvas.isMove && !Canvas.isPointerClick)
				{
					trans = false;
				}
				if (Canvas.isPointerDown)
				{
					if (!trans)
					{
						pb = cmyParty;
						trans = true;
					}
					if (Math.abs(i2) > 10)
					{
						cmtoYParty = pb + (Canvas.pyLast - Canvas.py);
						if (cmtoYParty < -10)
						{
							cmtoYParty = -10;
						}
						if (cmtoYParty > cmyLim)
						{
							cmtoYParty = cmyLim;
						}
					}
					int num5 = (cmtoYParty + Canvas.py - y0 - yTr) / 32;
					if (Math.abs(i2) < 10 && Math.abs(i3) < 10)
					{
						selected = num5;
					}
					if (selected > Char.party.size() - 1)
					{
						selected = Char.party.size() - 1;
					}
				}
				if (Canvas.isPointerClick)
				{
					xCus = -20;
					isChangeTab = false;
					Canvas.isPointerClick = false;
					trans = false;
					if (Math.abs(Canvas.pyLast - Canvas.py) < 10 && Math.abs(Canvas.pxLast - Canvas.px) < 10)
					{
						doSelectedParty();
					}
				}
				if (cmyParty != cmtoYParty)
				{
					cmvyParty = cmtoYParty - cmyParty << 2;
					cmdyParty += cmvyParty;
					cmyParty += cmdyParty >> 4;
					cmdyParty &= 15;
				}
			}
		}
		else if (focusTabChinh == 8)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 + xTr;
			yBegin = y0 + 2 + yTr;
			wTouch = wKhung;
			hTouch = Canvas.h - 60;
			if (Canvas.pxLast >= x0 && Canvas.pxLast <= x0 + 140)
			{
				leftRightSetting = false;
			}
			else
			{
				leftRightSetting = true;
			}
		}
		else if (focusTabChinh == 9)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 + xTr;
			yBegin = y0 + yTr;
			wTouch = wKhung;
			hTouch = Canvas.h - 60;
			if (Canvas.pxLast < Canvas.hw)
			{
				leftRightSetting = false;
			}
			else
			{
				leftRightSetting = true;
			}
		}
		else if (focusTabChinh == 10)
		{
			curentTabUpdate = focusTabChinh;
			xBegin = x0 + xTr;
			yBegin = y0 + yTr;
			wTouch = wKhung;
			hTouch = Canvas.h - 60;
			if (Canvas.pxLast < Canvas.hw)
			{
				leftRightSetting = false;
			}
			else
			{
				leftRightSetting = true;
			}
		}
	}

	private void doClan(int id)
	{
		switch (id)
		{
		case 0:
			Canvas.gameScr.switchToMe();
			GameService.gI().requestTopStronger_Righer(5, 0);
			break;
		case 1:
			Canvas.gameScr.switchToMe();
			Canvas.startWaitDlg();
			if (Canvas.gameScr.mainChar.idClan == -1)
			{
				GameService.gI().registerClan();
				break;
			}
			GameService.gI().questClan(0);
			Canvas.gameScr.showWindow(0, isSell: false, new sbyte[1] { 27 });
			Canvas.startWaitDlg();
			break;
		case 2:
			Canvas.gameScr.switchToMe();
			Canvas.startWaitDlg();
			GameService.gI().requestClanList(Canvas.gameScr.mainChar.idClan, 0);
			break;
		case 3:
			Canvas.gameScr.switchToMe();
			Canvas.startWaitDlg();
			GameService.gI().requestClanInfo(Canvas.gameScr.mainChar.idClan);
			break;
		case 4:
			Canvas.gameScr.switchToMe();
			GameService.gI().msgClanAll(null, 1, 0);
			break;
		case 5:
			Canvas.gameScr.showWindow(0, isSell: true, new sbyte[2] { 29, 30 });
			break;
		case 6:
			Canvas.gameScr.switchToMe();
			MessageScr.gI().addTab(string.Empty, "Bang hội", 1);
			MessageScr.gI().setFocusTab("Bang hội");
			MessageScr.gI().switchToMe();
			break;
		case 7:
		{
			ActionPerform ok = delegate
			{
				string text = Canvas.inputDlg.tfInput.getText();
				if (!text.Equals(string.Empty))
				{
					try
					{
						GameService.gI().transMoney(int.Parse(text));
						Canvas.startOKDlg("Đã chuyển tiền thành công");
						Canvas.gameScr.switchToMe();
					}
					catch (Exception)
					{
						Canvas.startOKDlg("Bạn phải nhập số");
					}
				}
			};
			Canvas.inputDlg.setInfo("Số lượng", ok, TField.INPUT_TYPE_NUMERIC, 100, isMaxW: false);
			Canvas.inputDlg.show();
			break;
		}
		case 8:
			if (Canvas.gameScr.mainChar.isMaster == 0)
			{
				ActionPerform yesAction = delegate
				{
					Canvas.gameScr.switchToMe();
					GameService.gI().dissolveCLan();
					Canvas.startOKDlg((!Char.dissolved) ? "Đã giãi tán bang hội" : "Đã khôi phục lại bang hội");
					Char.dissolved = !Char.dissolved;
					initName();
				};
				Canvas.startYesNoDlg((!Char.dissolved) ? "Bạn có chắc muốn giải tán bang hội không ?" : "Bạn có chắc muốn phục hồi lại bang hội không ?", yesAction);
			}
			else
			{
				ActionPerform yesAction2 = delegate
				{
					GameService.gI().outClan();
					Canvas.gameScr.mainChar.idClan = -1;
					Canvas.gameScr.switchToMe();
					initName();
					Canvas.startOKDlg("Rời bang thành công");
				};
				Canvas.startYesNoDlg("Bạn có chắc muốn rời bang không ?", yesAction2);
			}
			break;
		}
	}

	private void doBigMap()
	{
		short[][] location = new short[17][]
		{
			new short[2] { 28, 105 },
			new short[2] { 55, 100 },
			new short[2] { 24, 138 },
			new short[2] { 61, 148 },
			new short[2] { 105, 76 },
			new short[2] { 80, 128 },
			new short[2] { 112, 132 },
			new short[2] { 136, 111 },
			new short[2] { 76, 60 },
			new short[2] { 129, 158 },
			new short[2] { 173, 155 },
			new short[2] { 153, 160 },
			new short[2] { 145, 60 },
			new short[2] { 127, 87 },
			new short[2] { 126, 62 },
			new short[2] { 35, 60 },
			new short[2] { 35, 60 }
		};
		short[] array = new short[17]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 110, 111, 112, 202, 104
		};
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (Canvas.gameScr.map == array[i])
			{
				num = i;
				break;
			}
		}
		int id = num;
		PageScr.gI().setInfo(Canvas.hw - 94, Canvas.hh - 84 - MyScreen.deltaY, 197, 168, Res.nameBigMap[id], null);
		PageScr.gI().indexFont = 1;
		PageScr.gI().isBigMap = true;
		ActionPerform action = delegate
		{
			Canvas.gameScr.switchToMe();
		};
		PageScr.gI().left = new Command("Trở lại");
		PageScr.gI().left.action = action;
		PageScr.gI().layer = new Layer();
		ActionPaintCmd isPaint = delegate(MyGraphics g, int x, int y)
		{
			GameData.paintIconCayThan(g, 800, 98, 95);
			Res.getCharPartInfo(2, Canvas.gameScr.mainChar.currentHead).paint(g, location[id][0], location[id][1], 0, 1);
		};
		ActionPerform isUpdate = delegate
		{
		};
		PageScr.gI().layer.isUpdate = isUpdate;
		PageScr.gI().layer.isPaint = isPaint;
		PageScr.gI().switchToMe();
	}

	public void updateCMRMainTab()
	{
		if (Canvas.menu.showMenu)
		{
			return;
		}
		if (focusTabChinh == 1)
		{
			cmtoXTab = 0;
			cmxLimSubTab = tabCuaHang.Length * wSubTab - wKhung;
			if (focusTabCuaHang == 1)
			{
				cmtoXSubTab = 0;
			}
			else if (focusTabCuaHang == 2)
			{
				cmtoXSubTab = 0;
			}
			else if (focusTabCuaHang == tabCuaHang.Length)
			{
				cmtoXSubTab = cmxLimSubTab;
			}
			else
			{
				cmtoXSubTab = (focusTabCuaHang - 1) * wSubTab - (wSubTab + 20);
			}
		}
		else if (focusTabChinh == 2)
		{
			cmtoXTab = 0;
		}
		else if (focusTabChinh == tabName.Length)
		{
			cmtoXTab = cmxLimTab;
		}
		else
		{
			cmtoXTab = (focusTabChinh - 1) * wTab - wTab * 2;
		}
	}

	private void moveCameraTab()
	{
		cmxLimTab = tabName.Length * wTab - wKhung;
		if (Canvas.isPointerClick && Math.abs(Canvas.pxLast - Canvas.px) < 10 && Math.abs(Canvas.pyLast - Canvas.py) < 10)
		{
			updateCMRMainTab();
		}
		if (cmtoXTab < 0)
		{
			cmtoXTab = 0;
		}
		if (cmtoXTab > cmxLimTab)
		{
			cmtoXTab = cmxLimTab;
		}
		if (cmtoXSubTab < 0)
		{
			cmtoXSubTab = 0;
		}
		if (cmtoXSubTab > cmxLimSubTab)
		{
			cmtoXSubTab = cmxLimSubTab;
		}
	}

	public void resetMainTab(bool isUseKey, int index)
	{
		selected = 0;
		if (!isUseKey)
		{
			tdx = (cmtoXTab + Canvas.px - xKhung - xTr) / wTab;
		}
		else
		{
			tdx = index + 1;
		}
		isPaintFc = false;
		focusTabChinh = tdx + 1;
		isChangeTab = true;
		Canvas.endDlg();
		curentTabUpdate = -1;
		setCmdCenter();
		cmy = (cmtoY = 0);
		Out.LogWarning("tab chinh thu : " + focusTabChinh);
	}

	public void setInfoSelectMainTab()
	{
		switch (focusTabChinh)
		{
		case 1:
		{
			int num = 0;
			for (int k = 0; k < Res.shopTemplate.size(); k++)
			{
				GemTemp gemTemp = (GemTemp)Res.shopTemplate.elementAt(k);
				if (gemTemp.shopType + 1 > num)
				{
					num = gemTemp.shopType + 1;
				}
			}
			sbyte[] array2 = new sbyte[num];
			for (int l = 0; l < array2.Length; l++)
			{
				array2[l] = 20;
			}
			setInfo(0, isSell: true, array2);
			focusTab = focusTabCuaHang - 1;
			setSelectTab();
			setCmdCenter();
			break;
		}
		case 2:
			setInfo(0, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
			charWearing = Canvas.gameScr.mainChar;
			setImageCharWear();
			setSelectTab();
			setCmdCenter();
			break;
		case 3:
			setInfo(1, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
			charWearing = Canvas.gameScr.mainChar;
			setImageCharWear();
			setSelectTab();
			setCmdCenter();
			break;
		case 4:
			setInfo(7, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
			charWearing = Canvas.gameScr.mainChar;
			setImageCharWear();
			setSelectTab();
			setCmdCenter();
			break;
		case 5:
			setInfo(3, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
			charWearing = Canvas.gameScr.mainChar;
			setImageCharWear();
			setSelectTab();
			setCmdCenter();
			break;
		case 6:
			setInfo(4, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
			charWearing = Canvas.gameScr.mainChar;
			setImageCharWear();
			setSelectTab();
			setCmdCenter();
			if (charInfo != null)
			{
				sbyte b = (sbyte)charInfo.Length;
				sbyte b2 = 0;
				if (WindowInfoScr.infoMainCharServer != null)
				{
					b2 = (sbyte)WindowInfoScr.infoMainCharServer.Length;
				}
				string[] array = new string[b + b2];
				for (int i = 0; i < b; i++)
				{
					array[i] = charInfo[i];
				}
				for (int j = 0; j < b2; j++)
				{
					array[j + b] = WindowInfoScr.infoMainCharServer[j];
				}
				setShowTextArr(array, 0, 0);
			}
			break;
		case 7:
			setInfo(6, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
			charWearing = Canvas.gameScr.mainChar;
			setImageCharWear();
			setSelectTab();
			setCmdCenter();
			break;
		case 8:
			selectConfig = (selected = -1);
			cmyLim = tabCaiDat.Length * 30 - 140 + 20;
			break;
		case 9:
		case 10:
			selected = -1;
			cmyLim = tabCaiDat.Length * 30 - 140 + 20;
			break;
		}
		if (focusTabChinh != 6)
		{
			closeText();
		}
	}

	private void updateTab()
	{
		if (Canvas.isPointerDown && Canvas.isPointer(xKhung + xTr, 0 + yTr, wKhung, hTab + 20) && !Canvas.menu.showMenu)
		{
			if (!Canvas.isMove && !Canvas.isPointerClick)
			{
				trans = false;
			}
			if (!trans)
			{
				pa = cmxTab;
				trans = true;
			}
			cmtoXTab = pa + (Canvas.pxLast - Canvas.px);
			if (cmtoXTab < -Canvas.pxLast)
			{
				cmtoXTab = -Canvas.pxLast;
			}
			if (cmtoXTab > cmxLimTab + Canvas.pxLast)
			{
				cmtoXTab = cmxLimTab + Canvas.pxLast;
			}
		}
		if (Canvas.isPointerClick)
		{
			trans = false;
		}
		if (cmxTab != cmtoXTab)
		{
			cmvxTab = cmtoXTab - cmxTab << 2;
			cmdxTab += cmvxTab;
			cmxTab += cmdxTab >> 4;
			cmdxTab &= 15;
		}
		if (Canvas.isPointer(xKhung + xTr, 0 + yTr, wKhung, hTab + 20) && Canvas.isPointerClick && !Canvas.menu.showMenu && Math.abs(Canvas.pxLast - Canvas.px) < 10 && Math.abs(Canvas.pyLast - Canvas.py) < 10)
		{
			resetMainTab(isUseKey: false, 0);
			setInfoSelectMainTab();
		}
		else
		{
			if (!Canvas.isPointer(xKhung + xTr, yKhung + hKhung - hTab + yTr, wKhung, hTab) || !Canvas.isPointerClick || (focusTabChinh != 1 && focusTabChinh != 5) || Canvas.menu.showMenu || Math.abs(Canvas.pxLast - Canvas.px) >= 10 || Math.abs(Canvas.pyLast - Canvas.py) >= 10)
			{
				return;
			}
			selected = 0;
			int num = (cmtoXSubTab + Canvas.px - xKhung - xTr) / wSubTab;
			focusTabCuaHang = num + 1;
			isChangeTab = true;
			Canvas.endDlg();
			setCmdCenter();
			switch (focusTabChinh)
			{
			case 1:
			{
				int num2 = 0;
				for (int i = 0; i < Res.shopTemplate.size(); i++)
				{
					GemTemp gemTemp = (GemTemp)Res.shopTemplate.elementAt(i);
					if (gemTemp.shopType + 1 > num2)
					{
						num2 = gemTemp.shopType + 1;
					}
				}
				sbyte[] array = new sbyte[num2];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 20;
				}
				setInfo(0, isSell: true, array);
				focusTab = focusTabCuaHang - 1;
				setSelectTab();
				setCmdCenter();
				break;
			}
			case 5:
				setInfo(3, isSell: false, new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 31 });
				charWearing = Canvas.gameScr.mainChar;
				setImageCharWear();
				setSelectTab();
				setCmdCenter();
				break;
			}
			closeText();
		}
	}

	public void setImageCharWear()
	{
		int num = 0;
		for (int i = 0; i < charWearing.wearingItems.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)charWearing.wearingItems.elementAt(i);
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (item.plus > 13)
			{
				num++;
			}
		}
		if (num < 3 || charWearing.idFashion != -1)
		{
			return;
		}
		int[] array = new int[6000];
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] != 16777215)
			{
				if (j - 1 > 0 && array[j - 1] == 16777215)
				{
					array[j] = -1;
				}
				else if (j + 1 < array.Length && array[j + 1] == 16777215)
				{
					array[j] = -1;
				}
			}
		}
	}

	private void paintTab(MyGraphics g, int x, int y, int w, int h)
	{
		Res.paintDlgDragonFull(g, x, y - 10, w, h + 10);
		Canvas.resetTrans(g);
		g.setClip(x, y - 12, w, hTab + 12);
		g.translate(-cmxTab, 0);
		sbyte b = (sbyte)tabName.Length;
		for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
		{
			if (b2 == focusTabChinh - 1)
			{
				MFont.normalFont[0].drawString(g, tabName[b2], x + wTab / 2 + (wTab - 1) * b2, y - 2, 2);
			}
			else
			{
				MFont.arialFontW.drawString(g, tabName[b2], x + wTab / 2 + (wTab - 1) * b2, y - 2, 2);
			}
		}
		g.setColor(9755120, 0.5f);
		g.fillRect(x + (wTab - 1) * focusTabChinh - wTab + 1, y - 7, 69, hTab + 4);
		g.setColor(10591392);
		for (sbyte b3 = 0; b3 < b; b3 = (sbyte)(b3 + 1))
		{
			g.drawImage(Res.imgK0, x + wTab + (wTab - 1) * b3 - 70, y - 7, 0);
		}
		g.translate(cmxTab, 0);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		for (int i = 0; i < 3; i++)
		{
			g.setColor(Res.color[i]);
			g.fillRect(x + i - 1, y + (hTab - i), w - i * 2 + 2, 1);
		}
		g.translate(x0, y0);
		int num = yTr - 10;
		switch (focusTabChinh)
		{
		case 1:
		{
			g.setColor(16774720);
			int num11 = hView - 6;
			int num12 = 7 * wCell - 2 + xTr;
			g.fillRect(num12, num - 1, wKhung - (x0 - 2 + 7 * wCell), num11);
			num11--;
			g.setColor(25695);
			g.fillRect(num12 + 1, num, wKhung - (x0 - 2 + 7 * wCell) - 2, num11 - 1);
			int num13 = -24 + num11;
			MFont.smallFontColor[0].drawString(g, Canvas.gameScr.mainChar.charXu + "$", num12 + (wKhung - (x0 - 2 + 7 * wCell)) - 4, num13 + yTr, MFont.RIGHT);
			MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luong + "L", num12 + 2, num13 + yTr, MFont.LEFT);
			if (Canvas.gameScr.mainChar.luongKhoa > -1)
			{
				MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luongKhoa + "LK", num12 + (wKhung - (x0 - 2 + 7 * wCell)) / 2, num13 + yTr, MFont.CENTER);
			}
			Canvas.resetTrans(g);
			paintTabCuaHang(g, x, y, w, h, 0);
			break;
		}
		case 2:
		{
			g.setColor(16774720);
			int num14 = hView - 6;
			int num15 = 7 * wCell - 2 + xTr;
			int num16 = -10 + yTr;
			g.fillRect(num15, num16 - 1, wKhung - (x0 - 2 + 7 * wCell), num14);
			num14--;
			g.setColor(25695);
			g.fillRect(num15 + 1, num16, wKhung - (x0 - 2 + 7 * wCell) - 2, num14 - 1);
			int num17 = Canvas.h;
			if (num17 > 320)
			{
				num17 = 320;
			}
			int num18 = num17 - 140 + yTr;
			MFont.smallFont.drawString(g, countTabMyitem + 1 + "/" + Canvas.gameScr.mainChar.limItemBag, 104 + xTr, num18 - 4, 2);
			g.drawImage(Res.imgBar, 4 + xTr, num18, 3);
			g.drawRegion(Res.imgBar, 0, 0, 11, 7, 2, num15 - wCell / 2, num18, 3);
			g.setColor(0);
			num18 += 20;
			MFont.smallFontColor[0].drawString(g, Canvas.gameScr.mainChar.charXu + "$", num15 - wCell / 2, num18, MFont.LEFT);
			MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luong + "L", 2 + xTr, num18, MFont.LEFT);
			if (Canvas.gameScr.mainChar.luongKhoa > -1)
			{
				MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luongKhoa + "LK", 104 + xTr, num18, MFont.CENTER);
			}
			paintHanhTrang(g, w);
			Canvas.resetTrans(g);
			break;
		}
		case 3:
		{
			g.setColor(16774720);
			int num9 = hView;
			g.fillRect(Res.wTrangbi + 30 + xTr, num - 1, wKhung - (Res.wTrangbi + 30 + x0), num9 + 2);
			num9--;
			g.setColor(25695);
			g.fillRect(Res.wTrangbi + 31 + xTr, num, wKhung - (Res.wTrangbi + 30 + x0) - 2, num9 + 1);
			paintCharWearing(g);
			Canvas.resetTrans(g);
			break;
		}
		case 4:
		{
			g.setColor(16774720);
			int num6 = hView;
			g.fillRect(Res.wTrangbi + 30 + xTr, num - 1, wKhung - (Res.wTrangbi + 30 + x0), num6 + 2);
			num6--;
			g.setColor(25695);
			g.fillRect(Res.wTrangbi + 31 + xTr, num, wKhung - (Res.wTrangbi + 30 + x0) - 2, num6 + 1);
			paintAnimalWearing(g);
			Canvas.resetTrans(g);
			break;
		}
		case 5:
		{
			Canvas.resetTrans(g);
			g.translate(x0, y0);
			g.setColor(16774720);
			int num19 = hView;
			g.fillRect(Res.wTrangbi + 30 + xTr, num - 1, wKhung - (Res.wTrangbi + 30 + x0), num19 + 2);
			num19--;
			g.setColor(25695);
			g.fillRect(Res.wTrangbi + 31 + xTr, num, wKhung - (Res.wTrangbi + 30 + x0) - 2, num19 + 1);
			paintTabSkill(g, x, y, w, h);
			Canvas.resetTrans(g);
			break;
		}
		case 6:
		{
			g.setColor(16774720);
			int num5 = hView;
			g.fillRect(Res.wTrangbi + 30 + xTr, num - 1, wKhung - (Res.wTrangbi + 30 + x0), num5 + 2);
			g.fillRect(-9 + xTr, num - 1, 200, num5);
			num5--;
			g.setColor(25695);
			g.fillRect(Res.wTrangbi + 31 + xTr, num, wKhung - (Res.wTrangbi + 30 + x0) - 2, num5 + 1);
			g.fillRect(-8 + xTr, num, 198, num5 - 1);
			paintFeatures(g);
			Canvas.resetTrans(g);
			break;
		}
		case 7:
		{
			int num10 = hView;
			g.setColor(16774720);
			g.fillRect(-5 + xTr, num - 1, 168, num10);
			g.fillRect(168 + xTr, num - 1, wKhung - (x0 - 2 + 168), num10);
			g.setColor(25695);
			num10--;
			g.fillRect(-4 + xTr, num, 166, num10 - 1);
			g.fillRect(169 + xTr, num, wKhung - (x0 - 2 + 168) - 2, num10 - 1);
			paintQuest(g);
			Canvas.resetTrans(g);
			g.translate(x0 + xTr, y0 + yTr);
			paintParty(g);
			Canvas.resetTrans(g);
			break;
		}
		case 8:
		{
			g.setClip(-20 + xTr, -12 + yTr, wKhung, hView + 2);
			g.translate(0 + xTr, -cmy + yTr);
			int num7 = hView;
			num7--;
			g.setColor(16774720);
			g.drawRect(-5, -11 + cmy, 139, num7);
			g.drawRect(140, -11 + cmy, wKhung - (x0 - 2 + 140) - 1, num7);
			MFont.normalFont[0].drawString(g, "Cấu hình", 0, 5 + (leftRightSetting ? cmy : 0), 0);
			g.fillRect(-5, 23 + (leftRightSetting ? cmy : 0), 139, 2);
			if (selectConfig != -1 && isPaintFc)
			{
				g.setColor(4108239, 0.5f);
				g.fillRect(-4, 25 + selectConfig * 35 + (leftRightSetting ? cmy : 0), 138, 35);
			}
			g.setColor(13684176);
			int num8 = 30;
			MFont.arialFontW.drawString(g, "Thấp", 60, num8 + 5 + (leftRightSetting ? cmy : 0), 2);
			num8 += 35;
			for (int l = 0; l < 4; l++)
			{
				g.fillRect(-5, num8 - 5 + l * 35 + (leftRightSetting ? cmy : 0), 139, 1);
			}
			MFont.arialFontW.drawString(g, "Vừa", 60, num8 + 5 + (leftRightSetting ? cmy : 0), 2);
			num8 += 35;
			MFont.arialFontW.drawString(g, "Cao", 60, num8 + 5 + (leftRightSetting ? cmy : 0), 2);
			num8 += 35;
			MFont.arialFontW.drawString(g, "Rất thấp", 60, num8 + 5 + (leftRightSetting ? cmy : 0), 2);
			if (selected != -1 && isPaintFc)
			{
				g.setColor(4108239, 0.5f);
				g.fillRect(143, selected * 36 - 12 + ((!leftRightSetting) ? cmy : 0), wKhung - (x0 - 2 + 140) - 6, 36);
			}
			g.setColor(13684176);
			for (int m = 0; m < 6; m++)
			{
				g.fillRect(143, m * 36 - 12 + ((!leftRightSetting) ? cmy : 0), wKhung - (x0 - 2 + 140) - 6, 1);
			}
			for (int n = 0; n < tabCaiDat.Length; n++)
			{
				MFont.normalFont[0].drawString(g, string.Empty + tabCaiDat[n], 140 + (wKhung - (x0 - 2 + 140)) / 2, n * 35 + ((!leftRightSetting) ? cmy : 0), 2);
			}
			Canvas.resetTrans(g);
			break;
		}
		case 9:
		{
			g.setClip(-20 + xTr, -12 + yTr, wKhung, hView + 2);
			int num20 = (leftRightSetting ? cmy : 0);
			int num21 = ((!leftRightSetting) ? cmy : 0);
			g.translate(0, -cmy);
			int num22 = hView;
			if (selected > -1 && isPaintFc)
			{
				g.setColor(4108239, 0.5f);
				g.fillRect(((selected % 2 != 0) ? (-5) : (-4)) + selected % 2 * (wKhung / 2) + xTr, 1 + selected / 2 * 35 - 5 + yTr, (selected % 2 != 0) ? (wKhung - (x0 + wKhung / 2) + 5) : (wKhung / 2 - 11), 34);
			}
			g.setColor(16774720);
			g.drawRect(-5 + xTr, num - 1 + cmy, wKhung / 2 - 10, num22 - 1);
			g.drawRect(wKhung / 2 - 5 + xTr, -11 + cmy + yTr, wKhung - (x0 + wKhung / 2) + 5, num22 - 1);
			g.setColor(10591392);
			for (int num23 = 0; num23 < 5; num23++)
			{
				g.fillRect(-5 + xTr, 20 + 35 * num23 + 10 + num20 + yTr, wKhung / 2 - 10, 1);
				g.fillRect(wKhung / 2 - 5 + xTr, 20 + 35 * num23 + 10 + num21 + yTr, wKhung - (x0 + wKhung / 2) + 5, 1);
			}
			for (int num24 = 0; num24 < nameClan.Length; num24++)
			{
				MFont.normalFont[0].drawString(g, string.Empty + nameClan[num24], (wKhung / 2 - 10) / 2 + num24 % 2 * (wKhung / 4 + (wKhung - (x0 + wKhung / 2)) / 2) + xTr, num24 / 2 * 35 + 5 + ((num24 % 2 != 0) ? num21 : num20) + yTr, 2);
			}
			Canvas.resetTrans(g);
			break;
		}
		case 10:
		{
			g.setClip(-20 + xTr, -12 + yTr, wKhung, hView + 2);
			int num2 = (leftRightSetting ? cmy : 0);
			int num3 = ((!leftRightSetting) ? cmy : 0);
			g.translate(0, -cmy);
			if (selected > -1 && isPaintFc)
			{
				g.setColor(4108239, 0.5f);
				g.fillRect(((selected % 2 != 0) ? (-5) : (-4)) + selected % 2 * (wKhung / 2) + xTr, selected / 2 * 35 + yTr, (selected % 2 != 0) ? (wKhung - (x0 + wKhung / 2) + 5) : (wKhung / 2 - 11), 35);
			}
			g.setColor(16774720);
			int num4 = hView;
			g.drawRect(-5 + xTr, num - 1 + cmy, wKhung / 2 - 10, num4 - 1);
			g.drawRect(wKhung / 2 - 5 + xTr, num - 1 + cmy, wKhung - (x0 + wKhung / 2) + 5, num4 - 1);
			g.setColor(10591392);
			for (int j = 0; j < 4; j++)
			{
				g.fillRect(-5 + xTr, 25 + 35 * j + 10 + num2 + yTr, wKhung / 2 - 10, 1);
				g.fillRect(wKhung / 2 - 5 + xTr, 25 + 35 * j + 10 + num3 + yTr, wKhung - (x0 + wKhung / 2) + 5, 1);
			}
			for (int k = 0; k < tabKhac.Length; k++)
			{
				MFont.normalFont[0].drawString(g, string.Empty + tabKhac[k], (wKhung / 2 - 10) / 2 + k % 2 * (wKhung / 4 + (wKhung - (x0 + wKhung / 2)) / 2) + xTr, k / 2 * 35 + 10 + ((k % 2 != 0) ? num3 : num2) + yTr, 2);
			}
			Canvas.resetTrans(g);
			break;
		}
		}
		if (isShowText)
		{
			g.translate(x0, y0);
			paintShowText(g);
			Canvas.resetTrans(g);
		}
	}

	private void paintParty(MyGraphics g)
	{
		int num = Char.party.size();
		g.setClip(168, -10, wKhung - (x0 - 2 + 168), 153);
		g.translate(0, -cmyParty);
		if (num > 0)
		{
			g.setColor(6448384);
			g.fillRect(170, selected * 32, wKhung - (x0 + 2 + 168), 32);
			for (int i = 0; i < num; i++)
			{
				PartyInfo partyInfo = (PartyInfo)Char.party.elementAt(i);
				MFont.arialFontW.drawString(g, "NV:" + partyInfo.name, 176, i * 33, 0);
				MFont.arialFontW.drawString(g, "LV: " + partyInfo.lv, 176, (i * 2 + 1) * 16, 0);
				g.setColor(16777215);
				g.fillRect(142, (i * 2 + 1) * 16 + 15, wKhung - (x0 - 2 + 168), 1);
			}
		}
		else
		{
			MFont.arialFontW.drawString(g, "Chưa có nhóm", 176, -7, 0);
		}
	}

	public static string getInfoQuestPaint(int type)
	{
		string result = string.Empty;
		if (type == 0 && GameScr.mainQuest != null)
		{
			result = GameScr.mainQuest.getInfoPaintScr();
		}
		if (GameScr.subQuest != null && type == 1)
		{
			try
			{
				result = GameScr.subQuest.getInfoPaintScr();
			}
			catch (Exception)
			{
			}
		}
		if (GameScr.clanQuest != null && type == 2)
		{
			try
			{
				result = GameScr.clanQuest.getInfoPaintScr();
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}
		return result;
	}

	private void paintQuest(MyGraphics g)
	{
		string infoQuestPaint = getInfoQuestPaint(0);
		string infoQuestPaint2 = getInfoQuestPaint(1);
		string infoQuestPaint3 = getInfoQuestPaint(2);
		if (infoQuestPaint.Equals(string.Empty) && infoQuestPaint2.Equals(string.Empty) && infoQuestPaint3.Equals(string.Empty))
		{
			MFont.arialFontW.drawString(g, "Chưa nhận nhiệm vụ", 8 + xTr, -7 + yTr, 0);
			return;
		}
		g.setClip(-5 + xTr, -10 + yTr, 140, hView + addHclip);
		g.translate(0 + xTr, -cmy + yTr);
		string[] array = null;
		if (!infoQuestPaint.Equals(string.Empty))
		{
			string[] array2 = Util.split(infoQuestPaint, "|");
			array = new string[array2.Length + 1];
			array[0] = GameScr.mainQuest.name;
			for (int i = 0; i < array2.Length; i++)
			{
				array[i + 1] = array2[i];
			}
		}
		int num = 0;
		if (array != null)
		{
			MFont.normalFont[1].drawString(g, array[0], 4, num * 15 - 8, 0);
			for (int j = 1; j < array.Length; j++)
			{
				MFont.arialFontW.drawString(g, array[j], 4, j * 15 - 8, 0);
			}
			num = array.Length;
		}
		array = null;
		if (!infoQuestPaint2.Equals(string.Empty))
		{
			string[] array3 = Util.split(infoQuestPaint2, "|");
			array = new string[array3.Length + 1];
			array[0] = GameScr.subQuest.name;
			for (int k = 0; k < array3.Length; k++)
			{
				array[k + 1] = array3[k];
			}
		}
		if (array != null)
		{
			MFont.normalFont[1].drawString(g, array[0], 4, num * 15 - 8, 0);
			for (int l = 1; l < array.Length; l++)
			{
				MFont.arialFontW.drawString(g, array[l], 4, (l + num) * 15 - 8, 0);
			}
			num += array.Length;
		}
		array = null;
		if (!infoQuestPaint3.Equals(string.Empty))
		{
			string[] array4 = Util.split(infoQuestPaint3, "|");
			array = new string[array4.Length + 1];
			array[0] = GameScr.clanQuest.name;
			for (int m = 0; m < array4.Length; m++)
			{
				array[m + 1] = array4[m];
			}
		}
		if (array != null)
		{
			MFont.normalFont[1].drawString(g, array[0], 4, num * 15 - 8, 0);
			for (int n = 1; n < array.Length; n++)
			{
				MFont.arialFontW.drawString(g, array[n], 4, (n + num) * 15 - 8, 0);
			}
			num = array.Length;
		}
	}

	private void paintFeatures(MyGraphics g)
	{
		if (selected > 4)
		{
			selected = 4;
		}
		if (isPaintFc)
		{
			g.setColor(7278866);
			g.fillRect(-4 + xTr, selected * 35 + 25 + yTr, 188, 34);
		}
		g.drawImage(Res.imgInfoWindow[1], -5 + xTr, -7 + yTr, 0);
		MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.basePointLeft + string.Empty, 160 + xTr, 5 + yTr, MFont.CENTER);
		MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.strength + string.Empty, 160 + xTr, 36 + yTr, MFont.CENTER);
		MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.agility + string.Empty, 160 + xTr, 71 + yTr, MFont.CENTER);
		MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.spirit + string.Empty, 160 + xTr, 103 + yTr, MFont.CENTER);
		MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.health + string.Empty, 160 + xTr, 138 + yTr, MFont.CENTER);
		MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luck + string.Empty, 160 + xTr, 173 + yTr, MFont.CENTER);
	}

	private void paintSkill(MyGraphics g)
	{
		MFont.normalFont[0].drawString(g, "Điểm kỹ năng: " + Canvas.gameScr.mainChar.skillPointLeft, (5 * newSise + 9) / 2, -17, MFont.CENTER);
		g.setColor(11908533);
		g.fillRect(-5, 1, 5 * newSise + 9, 1);
		g.setColor(10595790, 0.5f);
		if (selected != -1 && isPaintFc)
		{
			g.fillRect(selected % 5 * newSise - 10, h / 2 + selected / 5 * newSise - 10, newSise, newSise);
		}
		int num = Canvas.gameScr.mainChar.getnSkill();
		for (int i = 0; i < num; i++)
		{
			g.drawImage(Res.imgCell[1], i % 5 * newSise - 10, h / 2 + i / 5 * newSise - 10, 0);
			if (GameData.imgSkillIcon != null)
			{
				GameData.imgSkillIcon.drawFrame(i, i % 5 * newSise + 3 + 7, h / 2 + i / 5 * newSise + 10, 0, 3, g);
				g.drawImage(Res.imgKhung, i % 5 * newSise + 10, h / 2 + i / 5 * newSise + 10, 3);
				MFont.smallFontColor[1].drawString(g, Char.skillLevelLearnt[i] + string.Empty, i % 5 * newSise + 20, h / 2 + 4 + i / 5 * newSise + 15, MFont.RIGHT);
			}
		}
	}

	private void paintShowText(MyGraphics g)
	{
		int num = 0;
		g.setClip(xShow + xTr, yShow + 1 + yTr, wShow, hView - yaddBag);
		g.translate(0 + xTr, -cmyText + yTr);
		if (!isTextArr)
		{
			for (int i = 0; i < showText.Length + countPop; i++)
			{
				if (i == 1 && arrayKhamNgoc != null && arrayKhamNgoc.Length > 0)
				{
					for (int j = 0; j < arrayKhamNgoc.Length; j++)
					{
						g.drawImage(Res.imgKham, xShow + 12 + j * 20, yShow + 12 + num, 3);
						if (arrayKhamNgoc[j] != -1)
						{
							Res.paintGem(g, arrayKhamNgoc[j], xShow + 12 + j * 20, yShow + 12 + num);
						}
					}
					num += 18;
				}
				if (!showText[i].Equals(string.Empty))
				{
					sbyte b = (sbyte)(showText[i][0] - 48);
					sbyte b2 = 1;
					if (!isDegit(showText[i][0]))
					{
						b = 0;
						b2 = 0;
					}
					MFont.normalFont[(b < 6) ? b : 0].drawString(g, showText[i].Substring(b2), xShow + 4, yShow + 4 + num, 0);
					num += Res.hString;
				}
			}
			if (countPop < 0)
			{
				countPop++;
			}
			return;
		}
		for (int k = 0; k < showText.Length + countPop; k++)
		{
			if (k == 0)
			{
				MFont.normalFont[0].drawString(g, showText[k], xShow + 4, yShow + 4 + num, 0);
			}
			else
			{
				MFont.arialFontW.drawString(g, showText[k], xShow + 4, yShow + 4 + num, 0);
			}
			num += Res.hString;
		}
		if (countPop < 0)
		{
			countPop++;
		}
	}

	public static bool isDegit(char c)
	{
		return c >= '0' && c <= '9';
	}

	private void paintTabCuaHang(MyGraphics g, int x, int y, int w, int h, int i)
	{
		Canvas.resetTrans(g);
		g.setClip(x + 2, y + h - hTab, w - 6, hTab - 3);
		g.translate(-cmxSubTab, 0);
		g.setColor(9755120, 0.5f);
		g.fillRect(x + wSubTab * focusTabCuaHang - wSubTab, y + h - hTab, wSubTab, hTab - 2);
		sbyte b = (sbyte)tabCuaHang.Length;
		for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
		{
			if (b2 == focusTabCuaHang - 1)
			{
				MFont.normalFont[0].drawString(g, string.Empty + tabCuaHang[b2], x + wSubTab / 2 + wSubTab * b2 - 1, y + h - hTab + 3, 2);
			}
			else
			{
				MFont.arialFontW.drawString(g, string.Empty + tabCuaHang[b2], x + wSubTab / 2 + wSubTab * b2 - 1, y + h - hTab + 3, 2);
			}
		}
		g.setColor(10591392);
		for (int j = 1; j < b; j++)
		{
			g.fillRect(x + wSubTab * j, y + h - hTab, 2, hTab);
		}
		g.translate(cmxSubTab, 0);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		for (int k = 0; k < 3; k++)
		{
			g.setColor(Res.color[k]);
			g.fillRect(x + k - 1, y + (hTab - k) + (h - hTab * 2) + 2, w - k * 2 + 2, 1);
		}
		g.translate(x0, y0);
		switch (focusTabCuaHang)
		{
		case 1:
		case 2:
		case 3:
			paintHanhTrang(g, w);
			break;
		}
		Canvas.resetTrans(g);
	}

	private void paintTabSkill(MyGraphics g, int x, int y, int w, int h)
	{
		Canvas.resetTrans(g);
		g.setClip(x + 3 + xTr, y + h - hTab + yTr, w - 6, hTab - 3);
		g.translate(-cmxSubTab + xTr, 0 + yTr);
		g.setColor(9755120, 0.7f);
		g.fillRect(x + wSubTab * focusTabCuaHang - wSubTab + xTr, y + h - hTab + yTr, wSubTab, hTab - 2);
		sbyte b = (sbyte)tabSkill.Length;
		for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
		{
			if (b2 == focusTabCuaHang - 1)
			{
				MFont.normalFont[0].drawString(g, string.Empty + tabSkill[b2], x + wSubTab / 2 + wSubTab * b2 - 1 + xTr, y + h - hTab + 3 + yTr, 2);
			}
			else
			{
				MFont.arialFontW.drawString(g, string.Empty + tabSkill[b2], x + wSubTab / 2 + wSubTab * b2 - 1 + xTr, y + h - hTab + 3 + yTr, 2);
			}
		}
		for (sbyte b3 = 1; b3 < b; b3 = (sbyte)(b3 + 1))
		{
			g.setColor(10591392);
			g.fillRect(x + wSubTab * b3 + xTr, y + h - hTab + xTr, 1, hTab);
			g.setColor(8092283);
			g.fillRect(x + wSubTab * b3 + 1 + xTr, y + h - hTab + yTr, 1, hTab);
		}
		g.translate(cmxSubTab, 0);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		for (int i = 0; i < 3; i++)
		{
			g.setColor(Res.color[i]);
			g.fillRect(x + i - 1 + xTr, y + (hTab - i) + (h - hTab * 2) + 2 + yTr, w - i * 2 + 2, 1);
		}
		g.translate(x0, y0);
		switch (1)
		{
		case 1:
			paintSkill(g);
			break;
		}
		Canvas.resetTrans(g);
	}

	private void paintHanhTrang(MyGraphics g, int w)
	{
		isDefault = true;
		int num = hView;
		g.setClip(-10 + xTr, -10 + yTr, 5 * (wSmall + 10) + 10, num + addHclip);
		g.translate(0 + xTr, -cmy + yTr);
		int num2 = cmy / (hSmall + 10);
		if (num2 < 0)
		{
			num2 = 0;
		}
		int num3 = num2 + (w + 20) / (hSmall + 10);
		if (index[focusTab] == 0 && num3 > 9)
		{
			num3 = 9;
		}
		for (int i = num2; i < num3; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				paintGrid(g, j * (wSmall + 10) - 7, i * (hSmall + 10) - 10);
			}
		}
		g.setColor(10595790, 0.5f);
		if (selected != -1 && isPaintFc)
		{
			g.fillRect(selected % 5 * (wSmall + 10) - 5, selected / 5 * (hSmall + 10) - 8, wSmall + 10 - 3, hSmall + 10 - 3);
		}
		if (index[focusTab] != 0)
		{
			paintProduct(g);
		}
		else
		{
			paintBag(g);
		}
	}

	public void setCurTab()
	{
		if (Canvas.currentScreen == gI() && focusTabChinh == 2)
		{
			setSelectTab();
			isChangeTab = false;
		}
	}

	public void setSelectTab()
	{
		Out.LogWarning(" tab thu : " + index[focusTab]);
		left = null;
		isPaintMoney = false;
		list.removeAllElements();
		x0 = xKhung + 15;
		y0 = yKhung + hTab + 20;
		yaddBag = 0;
		hView = hKhung - y0 + 20;
		addHclip = 0;
		switch (index[focusTab])
		{
		case 20:
		{
			isPaintMoney = true;
			int num2 = 34;
			setSize(126, 112, 1, 1, num2, num2);
			getShopTemplate();
			setInfo(list);
			doBuyShopSpecial();
			hView = hKhung - y0 + 5;
			addHclip = 0;
			break;
		}
		case 0:
		{
			yaddBag = 10;
			isDefault = true;
			isPaintMoney = true;
			setInfo(getInventori());
			int hBig = 90;
			if (isDefault)
			{
				hBig = 4 * wCell;
			}
			int num3 = 34;
			setSize(5 * wCell, hBig, 7, 9, num3, num3);
			ActionPerform actionPerform = delegate
			{
				doSelectedInventori();
			};
			hView = hKhung - y0 + 20;
			addHclip = -40;
			break;
		}
		case 1:
		{
			setSize(117, 104, 3, 5, 97, 21);
			mVector mVector2 = new mVector();
			if (Canvas.gameScr.mainChar.idFashion != -1)
			{
				ActionPerform action3 = delegate
				{
					ActionPerform yesAction2 = delegate
					{
						GameService.gI().unRideHorse(1);
						Canvas.endDlg();
						Canvas.gameScr.switchToMe();
					};
					Canvas.startYesNoDlg("Bạn có muốn bỏ áo thời trang vào rương không ?", yesAction2);
				};
				Command command = new Command("Thay áo");
				command.action = action3;
				mVector2.addElement(command);
			}
			if (Canvas.gameScr.mainChar.isDoing)
			{
				ActionPerform action4 = delegate
				{
					ActionPerform yesAction = delegate
					{
						GameService.gI().unRideHorse(2);
						Canvas.endDlg();
						Canvas.gameScr.switchToMe();
					};
					Canvas.startYesNoDlg("Bạn có muốn cất cuốc vào rương không ?", yesAction);
				};
				Command command2 = new Command("Cất cuốc");
				command2.action = action4;
				mVector2.addElement(command2);
			}
			mVector menuItem = mVector2;
			if (mVector2.size() == 1)
			{
				left = (Command)mVector2.elementAt(0);
			}
			else if (mVector2.size() == 2)
			{
				ActionPerform action5 = delegate
				{
					Canvas.menu.startAt(menuItem, 0);
				};
				left = new Command("Chọn");
				left.action = action5;
			}
			break;
		}
		case 2:
			setSize(124, 94, 1, 5, 125, 19);
			isPaintMoney = true;
			break;
		case 3:
			left = null;
			setSize(114, 30, 5, 2, 30, 20);
			break;
		case 6:
			isPaintMoney = true;
			setQuestInfo();
			setSize(134, 190, 1, questInfo.size(), 130, 15);
			questInfo.removeAllElements();
			if (Canvas.gameScr.mainChar.receiveQuest)
			{
				ActionPerform action6 = delegate
				{
					GameService.gI().receiveQuest(0, 0, 3);
					//CS_0024_003C_003E8__locals1._003C_003Ef__this.questInfo.removeAllElements();
				};
				left = new Command("Hủy");
				left.action = action6;
			}
			break;
		case 28:
		{
			int num = WindowInfoScr.gI().listEp.size() / 2;
			if (num < 6)
			{
				num = 6;
			}
			setSize(144, 144, num, 3, 24, 45);
			ActionPerform action = delegate
			{
				//CS_0024_003C_003E8__locals1._003C_003Ef__this.doSelectedCheDo();
			};
			center = new Command("Chọn");
			center.action = action;
			ActionPerform action2 = delegate
			{
				//CS_0024_003C_003E8__locals1._003C_003Ef__this.doLeftCheDo();
			};
			left = new Command("Xong");
			left.action = action2;
			break;
		}
		case 31:
			setSize(117, 104, 3, 5, 97, 21);
			break;
		}
	}

	private void setQuestInfo()
	{
		try
		{
			questInfo = new mVector();
			string infoQuestPaint = getInfoQuestPaint(0);
			string infoQuestPaint2 = getInfoQuestPaint(1);
			string infoQuestPaint3 = getInfoQuestPaint(2);
			if (!infoQuestPaint.Equals(string.Empty))
			{
				string[] array = Util.split(infoQuestPaint, "|");
				questInfo.addElement(GameScr.mainQuest.name);
				for (int i = 0; i < array.Length; i++)
				{
					questInfo.addElement(array[i]);
				}
			}
			if (!infoQuestPaint2.Equals(string.Empty))
			{
				string[] array2 = Util.split(infoQuestPaint2, "|");
				questInfo.addElement(GameScr.subQuest.name);
				for (int j = 0; j < array2.Length; j++)
				{
					questInfo.addElement(array2[j]);
				}
			}
			if (!infoQuestPaint3.Equals(string.Empty))
			{
				string[] array3 = Util.split(infoQuestPaint3, "|");
				questInfo.addElement(GameScr.clanQuest.name);
				for (int k = 0; k < array3.Length; k++)
				{
					questInfo.addElement(array3[k]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static int getIndex()
	{
		return index[focusTab];
	}

	public void setCmdCenter()
	{
		charInfo = null;
		switch (focusTabChinh)
		{
		case 1:
		case 2:
		{
			int num = selected + ((index[focusTab] == 0) ? (countTabMyitem * 42) : 0);
			center = null;
			if (num < list.size())
			{
				center = (Command)list.elementAt(num);
				center.perform();
				saveSelected = selected;
			}
			break;
		}
		case 3:
		{
			ActionPerform action5 = delegate
			{
				showCharWearingInfo();
			};
			center = new Command(string.Empty);
			center.action = action5;
			break;
		}
		case 4:
		{
			ActionPerform action4 = delegate
			{
				if (charWearing != null && (charWearing.useHorse != -1 || charWearing.idhorse > -1))
				{
					showInfoWearingAnimal();
				}
			};
			center = new Command(string.Empty);
			center.action = action4;
			break;
		}
		case 5:
		{
			ActionPerform action3 = delegate
			{
				doSelectedSkill();
			};
			center = new Command(string.Empty);
			center.action = action3;
			ActionPerform actionPerform2 = delegate
			{
				doSelectedSkill();
			};
			left = null;
			break;
		}
		case 6:
		{
			ActionPerform action2 = delegate
			{
				dofireBasePoint();
			};
			center = new Command(string.Empty);
			center.action = action2;
			ActionPerform actionPerform = delegate
			{
				dofireBasePoint();
			};
			left = null;
			setTextCharInfo();
			break;
		}
		case 7:
		{
			ActionPerform action = delegate
			{
				doSelectedQuest();
			};
			left = new Command("Chọn");
			left.action = action;
			break;
		}
		case 8:
		case 9:
			left = null;
			break;
		}
	}

	protected void doSelectedParty()
	{
		try
		{
			if (Char.party.size() <= 0)
			{
				return;
			}
			MainChar mainChar = Canvas.gameScr.mainChar;
			mVector mVector2 = new mVector();
			if (mainChar.ID == mainChar.IDMasterParty)
			{
				Command command = new Command("Đuổi");
				ActionPerform action = delegate
				{
					Canvas.gameScr.gameService.kickOutParty(((PartyInfo)Char.party.elementAt(selected)).id, 0);
				};
				command.action = action;
				mVector2.addElement(command);
				Command command2 = new Command("Giải tán");
				ActionPerform action2 = delegate
				{
					Canvas.gameScr.gameService.kickOutParty(0, 1);
				};
				command2.action = action2;
				mVector2.addElement(command2);
			}
			else
			{
				Command command3 = new Command("Rời nhóm");
				ActionPerform action3 = delegate
				{
					Canvas.gameScr.gameService.kickOutParty(Canvas.gameScr.mainChar.ID, 2);
				};
				command3.action = action3;
				mVector2.addElement(command3);
			}
			Canvas.menu.startAt(mVector2, 2);
		}
		catch (Exception)
		{
		}
	}

	protected void doSelectedQuest()
	{
		if (Canvas.gameScr.mainChar.receiveQuest)
		{
			ActionPerform yesAction = delegate
			{
				Canvas.gameScr.mainChar.resetQuest();
				Canvas.gameScr.dellPotionQuest();
				GameService.gI().receiveQuest(0, 0, 3);
				Canvas.startWaitDlg();
			};
			Canvas.startYesNoDlg("Bạn thật sự muốn từ bỏ nhiệm vụ này?", yesAction);
		}
	}

	private void setTextCharInfo()
	{
		charInfo = new string[17];
		MainChar mainChar = Canvas.gameScr.mainChar;
		charInfo[0] = "Nhân vật: " + mainChar.name;
		charInfo[1] = "Level: " + mainChar.level + "+" + mainChar.getPercent();
		charInfo[2] = "HP: " + mainChar.hp + "/" + mainChar.maxhp;
		charInfo[3] = "MP: " + mainChar.mp + "/" + mainChar.maxmp;
		charInfo[4] = "Tấn công: " + mainChar.getAttack();
		charInfo[5] = "Thủ vật lý: " + mainChar.defend;
		charInfo[6] = "Thủ ma pháp: " + mainChar.defend_magic;
		charInfo[7] = "Chính xác: " + mainChar.accurate;
		charInfo[8] = "Né tránh: " + mainChar.dodge;
		charInfo[9] = "Bạo kích: " + ((mainChar.baokich <= 0) ? "0" : (mainChar.baokich / 10 + "." + mainChar.baokich % 10)) + "%";
		charInfo[10] = "Chí mạng: " + mainChar.critical;
		charInfo[11] = "Cống hiến: " + mainChar.dedicationPoint + " điểm.";
		charInfo[12] = "Liên trảm: " + mainChar.lienTram + " điểm.";
		charInfo[13] = "Công trạng: " + mainChar.congTrang + " điểm.";
		charInfo[14] = "Điểm hoạt động: " + mainChar.hoatdong + " điểm.";
		charInfo[15] = "Điểm đấu trường: " + mainChar.pArena + " điểm.";
		charInfo[16] = ((!mainChar.nameHusband_wife.Equals(string.Empty)) ? mainChar.nameHusband_wife : "Độc thân");
		numH = charInfo.Length + 1;
		setLim();
	}

	private void dofireBasePoint()
	{
		if (Canvas.gameScr.mainChar.basePointLeft == 0)
		{
			Canvas.startOKDlg("Đã hết điểm tiềm năng để cộng. Xin đánh lên level để có điểm tiềm năng.");
			return;
		}
		ActionPerform ok = delegate
		{
			string text = Canvas.inputDlg.tfInput.getText();
			if (text.Equals(string.Empty))
			{
				return;
			}
			try
			{
				int num = int.Parse(text);
				if (num > Canvas.gameScr.mainChar.basePointLeft)
				{
					Canvas.startOKDlg("Bạn chỉ còn " + Canvas.gameScr.mainChar.basePointLeft + " điểm tiềm năng");
				}
				else
				{
					GameService.gI().addBasePoint(selected, num);
					Canvas.startWaitDlg();
				}
			}
			catch (Exception)
			{
				Canvas.startOKDlg("Có lỗi xảy ra. Vui lòng chỉ nhập số.");
			}
		};
		Canvas.inputDlg.setInfo("Nhập số", ok, TField.INPUT_TYPE_NUMERIC, 10, isMaxW: true);
		Canvas.inputDlg.show();
	}

	public bool isBuffSkill()
	{
		sbyte[][] array = new sbyte[5][]
		{
			new sbyte[2] { 4, 5 },
			new sbyte[2] { 4, 5 },
			new sbyte[4] { 4, 5, 6, 7 },
			new sbyte[2] { 4, 5 },
			new sbyte[2] { 4, 5 }
		};
		for (int i = 0; i < array[Canvas.gameScr.mainChar.clazz].Length; i++)
		{
			if (selected == array[Canvas.gameScr.mainChar.clazz][i])
			{
				return true;
			}
		}
		return false;
	}

	private void doSelectedSkill()
	{
		if (Char.skillLevelLearnt[selected] == -1)
		{
			Canvas.startOKDlg("Xin gặp Lâm tướng quân để học kỹ năng này");
			return;
		}
		mVector mVector2 = new mVector();
		bool flag = false;
		bool isBuff = isBuffSkill();
		if (isBuff)
		{
			flag = SkillManager.SKILL_CAN_BUFF_TO_USER[Canvas.gameScr.mainChar.clazz][selected - 4] == -1;
		}
		if (isBuff && !flag)
		{
			Command command = new Command("Sử dụng");
			ActionPerform action = delegate
			{
				if (Char.skillLevelLearnt[selected] > 0)
				{
					Canvas.menu.showMenu = false;
					int num = SkillManager.EFF_BUFF_SKILL[Canvas.gameScr.mainChar.clazz][selected - 4];
					int skillMP = SkillManager.getSkillMP(selected, Char.skillLevelLearnt[selected - 4], Canvas.gameScr.mainChar.clazz);
					if (skillMP > Canvas.gameScr.mainChar.mp)
					{
						if (!first)
						{
							Canvas.gameScr.addChat(new ChatInfo(string.Empty, "Không đủ MP", 0));
							first = true;
						}
					}
					else
					{
						first = false;
						if (Canvas.gameScr.focusedActor != null && Canvas.gameScr.focusedActor.catagory == Actor.CAT_PLAYER)
						{
							if (selected == 6)
							{
								GameService.gI().useBuff(Canvas.gameScr.focusedActor.ID, 0, (sbyte)num, 0);
								Canvas.gameScr.mainChar.mp -= skillMP;
							}
							else
							{
								Canvas.gameScr.mainChar.mp -= skillMP;
								if (isBuff && (Canvas.gameScr.indexBuff == -1 || Canvas.gameScr.indexBuff == selected))
								{
									Canvas.gameScr.indexBuff = selected;
								}
								doCastBuffToActor(Canvas.gameScr.mainChar, Canvas.gameScr.focusedActor, num, SkillManager.SKILL_CAN_BUFF_TO_USER[Canvas.gameScr.mainChar.clazz][selected - 4] == 1);
							}
						}
						else if (selected != 6)
						{
							Canvas.gameScr.mainChar.mp -= skillMP;
							if (isBuff && (Canvas.gameScr.indexBuff == -1 || Canvas.gameScr.indexBuff == selected))
							{
								Canvas.gameScr.indexBuff = selected;
							}
							GameService.gI().useBuff(Canvas.gameScr.mainChar.ID, 0, (sbyte)num, 0);
						}
						else
						{
							Canvas.startOKDlg("Chỉ có thể hồi sinh cho người đã hết HP.");
						}
					}
				}
				else
				{
					Canvas.startOKDlg("Chưa học kĩ năng này");
				}
			};
			command.action = action;
			mVector2.addElement(command);
		}
		if (!flag)
		{
			Command command2 = new Command("Cho vào phím tắt");
			ActionPerform action2 = delegate
			{
				if (Char.skillLevelLearnt[selected] > 0)
				{
					doGiveSkillToQuickSlot(selected, isBuff);
				}
				else
				{
					Canvas.startOKDlg("Chưa học kỹ năng này");
				}
			};
			command2.action = action2;
			mVector2.addElement(command2);
		}
		Command command3 = new Command("Cộng");
		ActionPerform action3 = delegate
		{
			if (Canvas.gameScr.mainChar.skillPointLeft == 0)
			{
				Canvas.startOKDlg("Đã hết điểm kỹ năng để cộng. Xin đánh lên level để có điểm kỹ năng.");
			}
			else if (Canvas.gameScr.mainChar.level < SkillManager.getLvAddSkill(Canvas.gameScr.mainChar.clazz, selected, Char.skillLevelLearnt[selected]))
			{
				Canvas.startOKDlg("Chưa đủ cấp độ để cộng. Xin đánh lên level yêu cầu để có thể cộng.");
			}
			else
			{
				GameService.gI().addSkillPoint(selected);
				Canvas.startWaitDlg("Xin chờ..", isIcon: true);
			}
		};
		command3.action = action3;
		mVector2.addElement(command3);
		Canvas.menu.startAt(mVector2, 2);
	}

	protected void doGiveSkillToQuickSlot(int skillType, bool isBuff)
	{
		mVector mVector2 = new mVector();
		for (int i = 0; i < 3; i++)
		{
			int ii = i;
			Command command = null;
			if (!Main.isPC)
			{
				command = new Command("Phím số " + (1 + i * 2));
			}
			else
			{
				string[] array = new string[3] { "G", "H", "J" };
				command = new Command("Phím  " + array[i]);
			}
			ActionPerform action = delegate
			{
				MainChar.quickSlot[GameScr.indexTabSlot][ii].setIsSkill(skillType, Canvas.gameScr.mainChar.clazz, isBuff);
				RMS.saveQuickSlot();
			};
			command.action = action;
			mVector2.addElement(command);
		}
		Canvas.menu.startAt(mVector2, 2);
	}

	public void doCastBuffToActor(MainChar actor1, Actor actor2, int skillIdEff, bool buff2Friend)
	{
		mVector mVector2 = new mVector();
		if (buff2Friend)
		{
			Command command = new Command("Cho mình");
			ActionPerform action = delegate
			{
				GameService.gI().useBuff(actor1.ID, 0, (sbyte)skillIdEff, 0);
			};
			command.action = action;
			mVector2.addElement(command);
			Command command2 = new Command("Cho bạn");
			ActionPerform action2 = delegate
			{
				GameService.gI().useBuff(actor2.ID, 0, (sbyte)skillIdEff, 0);
			};
			command2.action = action2;
			mVector2.addElement(command2);
		}
		else
		{
			GameService.gI().useBuff(actor1.ID, 0, (sbyte)skillIdEff, 0);
		}
		Canvas.menu.startAt(mVector2, 2);
	}

	private void showInfoWearingAnimal()
	{
		try
		{
			int num = 0;
			int num2 = 0;
			if (charWearing.wearingAnimal == null || charWearing.wearingAnimal.size() <= 0)
			{
				return;
			}
			for (int i = 0; i < charWearing.wearingAnimal.size(); i++)
			{
				ItemInInventory itemInInventory = (ItemInInventory)charWearing.wearingAnimal.elementAt(i);
				ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				if (item.type == idWearAnimal[selected])
				{
					num++;
					showItemInventoryAnimalInfo(itemInInventory, isSell: false, posWearChar[num2][0] + 5, posWearChar[num2][1] - 2);
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void showCharWearingInfo()
	{
		try
		{
			int num = 0;
			int num2 = 0;
			if (selected % 3 == 1 || charWearing.isDoing)
			{
				if (charWearing.isDoing)
				{
					if (selected == 4)
					{
						return;
					}
					num2 = selected / 3 * 2 + (selected % 3 - ((selected % 3 > 0) ? 1 : 0));
					for (int i = 0; i < charWearing.wearingItems.size(); i++)
					{
						ItemInInventory itemInInventory = (ItemInInventory)charWearing.wearingItems.elementAt(i);
						ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
						if (item.type == 13)
						{
							showItemInventoryInfo(itemInInventory, isSell: false, posWearChar[num2][0] + 5, posWearChar[num2][1] - 2);
						}
					}
					return;
				}
				if (index.Length == 1)
				{
					if (selected != 4)
					{
						mVector mVector2 = new mVector();
						Command command = new Command("Thông tin");
						ActionPerform action = delegate
						{
							setShowText(charWearing.infoAnimal, 100, 120);
							Canvas.endDlg();
						};
						command.action = action;
						mVector2.addElement(command);
						Command command2 = new Command("Trang bị linh thú");
						ActionPerform action2 = delegate
						{
							Char @char = (Char)Canvas.gameScr.findCharByID(Canvas.gameScr.saveIDViewInfoAnimal);
							if (@char != null)
							{
								Canvas.gameScr.gameService.requestSomeOneInfo(@char.ID, 1);
							}
							else
							{
								right.perform();
							}
							Canvas.endDlg();
						};
						command2.action = action2;
						mVector2.addElement(command2);
						Canvas.menu.startAt(mVector2, 3);
						return;
					}
					int num3 = charWearing.wearingItems.size();
					for (int j = 0; j < num3; j++)
					{
						ItemInInventory itemInInventory2 = (ItemInInventory)charWearing.wearingItems.elementAt(j);
						ItemTemplate item2 = Res.getItem(itemInInventory2.charClazz, itemInInventory2.idTemplate);
						if (item2.type == 19)
						{
							showItemInventoryInfo(itemInInventory2, isSell: false, posWearChar[9][0] + 5, posWearChar[9][1] - 2);
							break;
						}
					}
					return;
				}
				if (selected != 4)
				{
					mVector mVector3 = new mVector();
					Command command3 = new Command("Linh thú");
					ActionPerform action3 = delegate
					{
						if (!charWearing.infoAnimal.Equals(string.Empty))
						{
							setShowText(charWearing.infoAnimal, 80, 120);
						}
					};
					command3.action = action3;
					mVector3.addElement(command3);
					Command command4 = new Command("Thú cưng");
					ActionPerform action4 = delegate
					{
						if (charWearing.myPet != null)
						{
							setShowText(ItemInInventory.setTemp(charWearing.myPet.infoPet, "0") + ItemInInventory.setTemp("Còn lại: " + (charWearing.myPet.totalTime - (mSystem.getCurrentTimeMillis() - charWearing.myPet.timeStart) / 60000) + " phút", "0"), 80, 120);
						}
					};
					command4.action = action4;
					mVector3.addElement(command4);
					Canvas.menu.startAt(mVector3, 3);
					return;
				}
				int num4 = charWearing.wearingItems.size();
				for (int k = 0; k < num4; k++)
				{
					ItemInInventory itemInInventory3 = (ItemInInventory)charWearing.wearingItems.elementAt(k);
					ItemTemplate item3 = Res.getItem(itemInInventory3.charClazz, itemInInventory3.idTemplate);
					if (item3.type == 19)
					{
						showItemInventoryInfo(itemInInventory3, isSell: false, posWearChar[9][0] + 5, posWearChar[9][1] - 2);
						break;
					}
				}
				return;
			}
			num2 = selected / 3 * 2 + (selected % 3 - ((selected % 3 > 0) ? 1 : 0));
			for (int l = 0; l < charWearing.wearingItems.size(); l++)
			{
				ItemInInventory itemInInventory4 = (ItemInInventory)charWearing.wearingItems.elementAt(l);
				ItemTemplate item4 = Res.getItem(itemInInventory4.charClazz, itemInInventory4.idTemplate);
				if (item4.type == idWearChar[num2] || (idWearChar[num2] == -1 && item4.type > 2 && item4.type < 8))
				{
					num++;
					if (num2 != 7 || num != 1)
					{
						showItemInventoryInfo(itemInInventory4, isSell: false, posWearChar[num2][0] + 5, posWearChar[num2][1] - 2);
						break;
					}
				}
			}
		}
		catch (Exception)
		{
			Out.println("Ngoai mang");
		}
	}

	private void showMenuForPotion(int potionType)
	{
		mVector mVector2 = new mVector();
		if (potionType >= 14 && potionType <= 18 && Canvas.gameScr.mainChar.pk > 0)
		{
			Command command = new Command("Tháo khăn");
			ActionPerform action = delegate
			{
				if (mSystem.getCurrentTimeMillis() - Canvas.gameScr.mainChar.timeWearScarves < 180000)
				{
					Canvas.startOKDlg("Sau 3 phút tính từ thời điểm đeo khăn mới được tháo khăn.");
				}
				else
				{
					Canvas.gameScr.doUsePotion(Canvas.gameScr.mainChar.pk);
					Canvas.gameScr.mainChar.pk = 0;
				}
			};
			command.action = action;
			mVector2.addElement(command);
		}
		else
		{
			Command command2 = new Command("Sử dụng");
			ActionPerform action2 = delegate
			{
				if (Canvas.gameScr.mainChar.iskiller && potionType >= 14 && potionType <= 18)
				{
					Canvas.startOKDlg("Không thể đeo khăn khi đang phạm tội.");
				}
				else
				{
					Canvas.gameScr.doUsePotion(potionType);
					if (Canvas.gameScr.mainChar.potions[potionType] == 0)
					{
						list.removeElementAt(selected);
					}
					if (potionType >= 14 && potionType <= 18)
					{
						Canvas.gameScr.mainChar.timeWearScarves = mSystem.getCurrentTimeMillis();
						Canvas.gameScr.mainChar.pk = (sbyte)potionType;
					}
				}
			};
			command2.action = action2;
			mVector2.addElement(command2);
		}
		if (potionType < 14 || potionType >= 21)
		{
			Command command3 = new Command("Cho vào phím tắt");
			ActionPerform action3 = delegate
			{
				mVector mVector3 = new mVector();
				for (int i = 0; i < 2; i++)
				{
					int ii = i;
					Command command5 = null;
					if (!Main.isPC)
					{
						command5 = new Command("Phím số " + (7 + 2 * i));
					}
					else
					{
						string[] array = new string[2] { "K", "L" };
						command5 = new Command("Phím  " + array[i]);
					}
					ActionPerform action5 = delegate
					{
						MainChar.quickSlot[GameScr.indexTabSlot][3 + ii].setIsPotion(potionType);
						RMS.saveQuickSlot();
					};
					command5.action = action5;
					mVector3.addElement(command5);
				}
				Canvas.menu.startAt(mVector3, 2);
			};
			command3.action = action3;
			mVector2.addElement(command3);
		}
		Command command4 = new Command("Bỏ ra đất");
		ActionPerform action4 = delegate
		{
			ActionPerform yesAction = delegate
			{
				Canvas.endDlg();
				GameService.gI().dellPotion(potionType);
				list.removeElementAt(selected);
				Canvas.gameScr.mainChar.potions[potionType] = 0;
				Canvas.currentDialog = null;
			};
			Canvas.startYesNoDlg("Bạn muốn bỏ vật phẩm này không ?", yesAction);
		};
		command4.action = action4;
		mVector2.addElement(command4);
		Canvas.menu.startAt(mVector2, 2);
	}

	private Command cmdDelItem(GemTemplate item, int index, mVector lit, sbyte khoa)
	{
		Command command = new Command("Bỏ ra đất");
		ActionPerform action = delegate
		{
			ActionPerform yesAction = delegate
			{
				GameService.gI().dellGemItem(item.id, index, khoa);
				Canvas.endDlg();
			};
			Canvas.startYesNoDlg("Bạn có muốn bỏ hết vật phẩm này không ?", yesAction);
		};
		command.action = action;
		return command;
	}

	protected void doUseItem(ItemInInventory item)
	{
		ItemTemplate item2 = Res.getItem(item.charClazz, item.idTemplate);
		if (item2.gender != 0 && item2.gender != Canvas.gameScr.mainChar.gender)
		{
			Canvas.startOKDlg("Vật phẩm này chỉ dành cho " + Res.GENDERNAME[item2.gender] + ".");
		}
		else if (item2.clazz != -1 && item2.clazz != Canvas.gameScr.mainChar.clazz && isWeapone(item2.type))
		{
			Canvas.startOKDlg("Vật phẩm này chỉ dành cho " + CreateCharScr.clazz[item2.clazz][CreateCharScr.selectGender].name + ".");
		}
		else if (item2.level > Canvas.gameScr.mainChar.level)
		{
			Canvas.startOKDlg("Bạn phải đạt cấp " + item2.level + " để có thể dùng.");
		}
		else
		{
			GameService.gI().useItem(item.itemID);
		}
	}

	private bool isWeapone(int type)
	{
		return type >= 3 && type <= 7;
	}

	public void doSelectedInventori()
	{
		int element = selected + ((index[focusTab] == 0) ? (countTabMyitem * 42) : 0);
		int num = element;
		int num2 = 0;
		for (int i = 1; i < Canvas.gameScr.mainChar.potions.Length; i++)
		{
			int num3 = Canvas.gameScr.mainChar.potions[i];
			if (num3 > 0)
			{
				if (element == num2)
				{
					showMenuForPotion(i);
					return;
				}
				num2++;
			}
		}
		num -= num2;
		if (num < MainChar.shopItem.size())
		{
			GemTemplate shop2 = (GemTemplate)MainChar.shopItem.elementAt(num);
			mVector mVector2 = new mVector();
			Command command = new Command("Sử dụng");
			ActionPerform action = delegate
			{
				GameService.gI().doUseSpecialItem(shop2.rID);
			};
			command.action = action;
			mVector2.addElement(command);
			mVector2.addElement(cmdDelItem(shop2, 1, MainChar.shopItem, 0));
			Canvas.menu.startAt(mVector2, 2);
			return;
		}
		num -= MainChar.shopItem.size();
		if (num < MainChar.gemItemKhoa.size())
		{
			GemTemplate item3 = (GemTemplate)MainChar.gemItemKhoa.elementAt(num);
			if (isSell)
			{
				GemTemp gemByID = Res.getGemByID(item3.id);
				ActionPerform yesAction = delegate
				{
					GameService.gI().sellGemItem(item3.rID, 1);
					Canvas.startWaitDlg("Đang bán..", isIcon: true);
					list.removeElementAt(element);
				};
				Canvas.startYesNoDlg("Bạn có muốn bán vật phẩm này với giá " + gemByID.price / 5 + "$ không?", yesAction);
				return;
			}
			mVector mVector3 = new mVector();
			GemTemp gemByID2 = Res.getGemByID(item3.id);
			if (gemByID2 != null && gemByID2.type == 4)
			{
				Command command2 = new Command("Sử dụng");
				command2.action = delegate
				{
					GameService.gI().douseGemItem(item3.id, 1);
				};
				mVector3.addElement(command2);
			}
			mVector3.addElement(cmdDelItem(item3, 0, MainChar.gemItemKhoa, 1));
			Canvas.menu.startAt(mVector3, 2);
			return;
		}
		num -= MainChar.gemItemKhoa.size();
		if (num < MainChar.gemItem.size())
		{
			GemTemplate item2 = (GemTemplate)MainChar.gemItem.elementAt(num);
			if (isSell)
			{
				ActionPerform yesAction2 = delegate
				{
					GameService.gI().sellGemItem(item2.rID, 0);
					Canvas.startWaitDlg("Đang bán..", isIcon: true);
					list.removeElementAt(element);
				};
				GemTemp gemByID3 = Res.getGemByID(item2.id);
				Canvas.startYesNoDlg("Bạn có muốn bán vật phẩm này với giá " + gemByID3.price / 5 + "$ không?", yesAction2);
				return;
			}
			mVector mVector4 = new mVector();
			GemTemp gemByID4 = Res.getGemByID(item2.id);
			if (gemByID4 != null && gemByID4.type == 4)
			{
				Command command3 = new Command("Sử dụng");
				command3.action = delegate
				{
					GameService.gI().douseGemItem(item2.id, 0);
				};
				mVector4.addElement(command3);
			}
			mVector4.addElement(cmdDelItem(item2, 0, MainChar.gemItem, 0));
			Canvas.menu.startAt(mVector4, 2);
			return;
		}
		num -= MainChar.gemItem.size();
		if (num < Char.animal.size())
		{
			AnimalInfo shop = (AnimalInfo)Char.animal.elementAt(num);
			mVector mVector5 = new mVector();
			Command command4 = new Command("Sử dụng");
			ActionPerform action2 = delegate
			{
				if ((Canvas.gameScr.mainChar.useHorse > -1 || Canvas.gameScr.mainChar.idhorse > -1) && shop.typeAnimal == 0)
				{
					Canvas.startOKDlg("Không thể cưỡi.");
				}
				else
				{
					GameService.gI().doRideAnimal(shop.id, shop.typeAnimal);
				}
			};
			command4.action = action2;
			mVector5.addElement(command4);
			Canvas.menu.startAt(mVector5, 2);
			return;
		}
		num -= Char.animal.size();
		if (num >= Char.inventory.size())
		{
			return;
		}
		ItemInInventory item = (ItemInInventory)Char.inventory.elementAt(num);
		if (!isSell)
		{
			mVector mVector6 = new mVector();
			Command command5 = new Command("Sử dụng");
			ActionPerform action3 = delegate
			{
				doUseItem(item);
			};
			command5.action = action3;
			mVector6.addElement(command5);
			if (item.colorName == 1 && item.level >= 50 && !ItemInInventory.isAnimalArmor(item.getTemplate().type))
			{
				Command command6 = new Command("Tách trang bị");
				command6.action = delegate
				{
					ActionPerform yesAction5 = delegate
					{
						GameService.gI().doRequestTachNguyenLIeu(item.itemID, 0, -1, 0);
						Canvas.endDlg();
					};
					Canvas.startYesNoDlg("Bạn có muốn tách nguyên liệu từ vật phẩm này không?", yesAction5);
				};
				mVector6.addElement(command6);
			}
			Command command7 = new Command("Bỏ ra đất");
			ActionPerform action4 = delegate
			{
				ActionPerform yesAction4 = delegate
				{
					GameService.gI().giveItemToGround(item.itemID);
					Canvas.endDlg();
					list.removeElementAt(element);
				};
				Canvas.startYesNoDlg("Vật phẩm sẽ mất khi bạn bỏ ra đất. Bạn có muốn tiếp tục không?", yesAction4);
			};
			command7.action = action4;
			mVector6.addElement(command7);
			if (item.colorName != 0 && item.colorName != 4)
			{
				if (item.colorName == 1)
				{
					Command command8 = new Command("Thăng cấp thường");
					ActionPerform action5 = delegate
					{
						GameService.gI().doRequestActionCheDo(10, item.itemID);
					};
					command8.action = action5;
					mVector6.addElement(command8);
					Command command9 = new Command("Thăng cấp giữ thuộc tính ");
					ActionPerform action6 = delegate
					{
						GameService.gI().doRequestActionCheDo(11, item.itemID);
					};
					command9.action = action6;
					mVector6.addElement(command9);
				}
				if (item.nameCharSeal.Equals(string.Empty))
				{
					Command command10 = new Command("Đóng dấu");
					ActionPerform action7 = delegate
					{
						GameService.gI().doRequestActionCheDo(14, item.itemID);
					};
					command10.action = action7;
					mVector6.addElement(command10);
				}
				if (!item.nameCharSeal.ToLower().Equals(Canvas.gameScr.mainChar.name.ToLower()))
				{
					Command command11 = new Command("Đóng dấu lại");
					ActionPerform action8 = delegate
					{
						GameService.gI().doRequestActionCheDo(14, item.itemID);
					};
					command11.action = action8;
					mVector6.addElement(command11);
				}
				else
				{
					ItemTemplate item4 = Res.getItem(item.charClazz, item.idTemplate);
					if ((item4.type >= 3 && item4.type <= 7) || item4.type == 8 || item4.type == 9)
					{
						Command command12 = new Command("Sửa thuộc tính kỹ năng");
						ActionPerform action9 = delegate
						{
							GameService.gI().doRequestActionCheDo(15, item.itemID);
						};
						command12.action = action9;
						mVector6.addElement(command12);
					}
				}
				if (item.islock == 0)
				{
					Command command13 = new Command("Khoá");
					ActionPerform action10 = delegate
					{
						GameService.gI().doRequestActionCheDo(12, item.itemID);
					};
					command13.action = action10;
					mVector6.addElement(command13);
				}
				if (item.islock == 1)
				{
					Command command14 = new Command("Khoá lại");
					ActionPerform action11 = delegate
					{
						GameService.gI().doRequestActionCheDo(12, item.itemID);
					};
					command14.action = action11;
					mVector6.addElement(command14);
				}
				Command command15 = new Command("Sửa thuộc tính khác");
				ActionPerform action12 = delegate
				{
					GameService.gI().doRequestActionCheDo(13, item.itemID);
				};
				command15.action = action12;
				mVector6.addElement(command15);
			}
			Canvas.menu.startAt(mVector6, 2);
		}
		else
		{
			ItemTemplate item5 = Res.getItem(item.charClazz, item.idTemplate);
			ActionPerform yesAction3 = delegate
			{
				GameService.gI().sellItem(item.itemID);
				Canvas.startWaitDlg("Đang bán..", isIcon: true);
				list.removeElementAt(element);
			};
			Canvas.startYesNoDlg("Bạn có muốn bán vật phẩm này với giá " + (item5.price / 5 + item5.plus * 1000) + "$ không?", yesAction3);
		}
	}

	private void getShopTemplate()
	{
		list.removeAllElements();
		for (int i = 0; i < Res.shopTemplate.size(); i++)
		{
			GemTemp shop = (GemTemp)Res.shopTemplate.elementAt(i);
			int ii = i;
			if (shop.shopType == focusTab && shop.isSell)
			{
				Command command = new Command();
				ActionPerform action = delegate
				{
					string empty = string.Empty;
					GemTemp shopByID = Res.getShopByID(shop.id);
					empty = ItemInInventory.setTemp(shopByID.name, "0");
					empty += ItemInInventory.setTemp(shopByID.decript, "0");
					empty += ItemInInventory.setTemp("Giá mua: " + shopByID.price + " " + ((shopByID.typeMoney != 0) ? "xu" : "lượng"), "0");
					setShowText(empty, ii % numW * 18, ii / numW * 18);
				};
				ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
				{
					GameData.paintIcon(g, (short)(Res.getShopByID(shop.id).idImage + 5500), x, y);
					MFont.smallFont.drawString(g, (short)((shop.id <= 1) ? 1 : Res.getShopByID(shop.id).value) + string.Empty, x + 10, y + 10, MFont.RIGHT);
				};
				command.action = action;
				command.actionPaint = actionPaint;
				list.addElement(command);
			}
		}
	}

	public void doBuyShopSpecial()
	{
		ActionPerform action = delegate
		{
			closeText();
			if (selected < Res.shopTemplate.size())
			{
				if (Canvas.gameScr.mainChar.isFullInventory())
				{
					Canvas.startOKDlg("Hành trang đã đầy.");
				}
				else
				{
					int num = 0;
					for (int i = 0; i < Res.shopTemplate.size(); i++)
					{
						GemTemp gemTemp = (GemTemp)Res.shopTemplate.elementAt(i);
						if (gemTemp.shopType == focusTab && gemTemp.isSell)
						{
							if (num == selected)
							{
								GemTemp item = (GemTemp)Res.shopTemplate.elementAt(i);
								ActionPerform yesAction = delegate
								{
									GameService.gI().buyItemShopSpecial(item.id);
									Canvas.startWaitDlg();
								};
								Canvas.startYesNoDlg("Bạn có muốn mua vật phẩm này không ?", yesAction);
								break;
							}
							num++;
						}
					}
				}
			}
		};
		cmdShop = new Command();
		cmdShop.action = action;
	}

	private void setLim()
	{
		int num = hSmall;
		cmxLim = numW * wSmall - w;
		if (isDefault)
		{
			num += 10;
		}
		int num2 = hView - 6;
		cmyLim = (numH + 1) * num - num2;
		if (cmxLim < 0)
		{
			cmxLim = 0;
		}
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
	}

	public void setInfo(mVector list)
	{
		this.list = list;
		numW = 7;
		numH = list.size() / 5;
		if (list.size() % numW != 0)
		{
			numH++;
		}
		if (numH < 5)
		{
			numH = 5;
		}
		if (index[focusTab] == 0 && numH > 6)
		{
			numH = 6;
		}
		setLim();
		isChangeTab = true;
		setCmdCenter();
	}

	public void setInfo1(int focus, bool isSell, sbyte[] iin)
	{
		this.isSell = isSell;
		index = iin;
		focusTab = focus;
		selected = 0;
		setCmdCenter();
		setSelectTab();
	}

	public void setInfo(int focus, bool isSell, sbyte[] iin)
	{
		try
		{
			this.isSell = isSell;
			index = iin;
			focusTab = focus;
			setCmdCenter();
			setSelectTab();
		}
		catch (Exception)
		{
		}
	}

	public void setSize(int wBig, int hBig, int numW, int numH, int wSmall, int hSmall)
	{
		w = wBig;
		h = hBig;
		this.numW = numW;
		this.numH = numH;
		this.wSmall = wSmall;
		this.hSmall = hSmall;
		setLim();
		if (index[focusTab] == 3)
		{
			cmx = (cmtoX = (cmy = (cmtoY = 10)));
		}
		else
		{
			cmx = (cmy = (cmtoX = (cmtoY = -10)));
		}
		if (isDefault)
		{
			cmx = (cmtoX = -10);
			cmy = (cmtoY = 0);
		}
	}

	public bool canPaint(int x, int y)
	{
		if (y > cmy + (Canvas.h - 100) || y + 42 < cmy)
		{
			return false;
		}
		return true;
	}

	private void paintNewCell(MyGraphics g, int x, int y, int wSmall)
	{
		g.setColor(6513507);
		g.drawRect(x, y, wSmall, wSmall);
		g.setColor(8684162);
		g.drawRect(x + 1, y + 1, wSmall - 2, wSmall - 2);
	}

	private void paintGrid(MyGraphics g, int x, int y)
	{
		if (canPaint(x, y))
		{
			int num = ((!isDefault) ? 34 : 44);
			g.setColor(6513507);
			g.drawRect(x, y, num, num);
			g.setColor(8684162);
			g.drawRect(x + 1, y + 1, num - 2, num - 2);
		}
	}

	private void paintProduct(MyGraphics g)
	{
		if (isDefault)
		{
			int num = cmy / (hSmall + 10) * 5;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num + 45;
			if (num2 > list.size())
			{
				num2 = list.size();
			}
			Command command = null;
			for (int i = num; i < num2; i++)
			{
				if (isLoad)
				{
					break;
				}
				command = (Command)list.elementAt(i);
				int x = i % 5 * (wSmall + 10) + (wSmall + 10) / 2 - 7;
				int y = i / 5 * (hSmall + 10) + (hSmall + 10) / 2 - 10;
				if (canPaint(x, y))
				{
					command.paint(g, x, y);
				}
			}
			return;
		}
		int num3 = cmy / hSmall * numW;
		if (num3 < 0)
		{
			num3 = 0;
		}
		int num4 = num3 + numW * numH;
		if (num4 > list.size())
		{
			num4 = list.size();
		}
		Command command2 = null;
		for (int j = num3; j < num4; j++)
		{
			if (isLoad)
			{
				break;
			}
			command2 = (Command)list.elementAt(j);
			int x2 = j % numW * wSmall + wSmall / 2;
			int y2 = j / numW * hSmall + hSmall / 2;
			if (canPaint(x2, y2))
			{
				command2.paint(g, x2, y2);
			}
		}
	}

	private void paintBag(MyGraphics g)
	{
		int num = cmy / (hSmall + 10) * 5;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = num + 45;
		if (list != null && list.size() > 0)
		{
			limMyBag = Canvas.gameScr.mainChar.limItemBag - 1;
			if (limMyBag <= 0)
			{
				limMyBag = 0;
			}
			excess = list.size() % 42;
			maxSize = list.size();
		}
		if (num2 > 42)
		{
			num2 = 42;
		}
		if (countTabMyitem * 42 + 42 > maxSize)
		{
			num2 = excess;
		}
		Command command = null;
		for (int i = num; i < num2; i++)
		{
			if (isLoad)
			{
				break;
			}
			int num3 = i + countTabMyitem * 42;
			if (num3 < list.size())
			{
				command = (Command)list.elementAt(num3);
				int x = i % 5 * (wSmall + 10) + (wSmall + 10) / 2 - 7;
				int y = i / 5 * (hSmall + 10) + (hSmall + 10) / 2 - 10;
				if (command != null)
				{
					canPaint(x, y);
					command.paint(g, x, y);
				}
			}
		}
	}

	protected void showShopItemInfo(short id, int count)
	{
		GemTemp shopByID = Res.getShopByID(id);
		string text = ItemInInventory.setTemp(shopByID.name, "0");
		text += ItemInInventory.setTemp(shopByID.decript, "0");
		if (isSell)
		{
			text += ItemInInventory.setTemp("Giá bán lại: " + Canvas.getMoneys(shopByID.price / 5), "0");
		}
		setShowText(text, count % numW * 18, count / numW * 18);
	}

	protected void showGemItemInfo(short id, int xx, int yy)
	{
		GemTemp gemByID = Res.getGemByID(id);
		string text = ItemInInventory.setTemp(gemByID.name, "0");
		text += ItemInInventory.setTemp(gemByID.decript, "0");
		if (isSell)
		{
			text += ItemInInventory.setTemp("Giá bán lại: " + gemByID.price / 5, "0");
		}
		setShowText(text, xx, yy);
	}

	protected void showGemItemKhoaInfo(short id, int xx, int yy)
	{
		GemTemp gemByID = Res.getGemByID(id);
		string text = ItemInInventory.setTemp(gemByID.name, "0");
		text += "- Đã khóa";
		text += ItemInInventory.setTemp(gemByID.decript, "0");
		if (isSell)
		{
			text += ItemInInventory.setTemp("Giá bán lại: " + gemByID.price / 5, "0");
		}
		setShowText(text, xx, yy);
	}

	public string getInfoItemQuest(int id)
	{
		string text = "0" + ItemQuest.NAME_ITEM[id];
		return text + "\nSố lượng: " + MainChar.itemQuest[id];
	}

	private string getPotionInfo(int aa)
	{
		string text;
		if (aa < 7 || aa >= 14)
		{
			text = "0" + MainChar.listPotion[aa].name;
			text = text + "\nSố lượng: " + Canvas.gameScr.mainChar.potions[aa];
			if (isSell)
			{
				text += "\nKhông thể bán lại";
			}
			if (!potionShop.conTains(aa + string.Empty))
			{
				try
				{
					text += ItemInInventory.setTemp("\nHồi phục: " + ((aa - 19 >= 0) ? Res.potionTemplates[aa - 19].recovered : Res.potionTemplates[aa].recovered) + " " + MainChar.listPotion[aa].name2, "0");
					return text;
				}
				catch (Exception)
				{
					return text;
				}
			}
			GemTemp gemTemp = null;
			for (int i = 0; i < Res.shopTemplate.size(); i++)
			{
				if (((GemTemp)Res.shopTemplate.elementAt(i)).id == aa - 19)
				{
					gemTemp = (GemTemp)Res.shopTemplate.elementAt(i);
					break;
				}
			}
			if (gemTemp != null && (aa < 69 || aa > 77))
			{
				text += ItemInInventory.setTemp(gemTemp.decript, "0");
			}
		}
		else if (aa >= 7 && aa < 14)
		{
			text = "0" + MainChar.listPotion[aa].name;
			text = text + "\nSố lượng: " + Canvas.gameScr.mainChar.potions[aa];
		}
		else
		{
			text = Res.PORTION_ITEM_NAME_CLAN;
			text = text + "\nSố lượng: " + Canvas.gameScr.mainChar.potions[aa];
		}
		return text;
	}

	public int getCountPotion(int i)
	{
		return Canvas.gameScr.mainChar.potions[i];
	}

	public mVector getInventori()
	{
		mVector mVector2 = new mVector();
		int num = 0;
		try
		{
			for (int i = 1; i < MainChar.listPotion.Length; i++)
			{
				int aa = i;
				if (getCountPotion(i) > 0)
				{
					int ii2 = num;
					Command command = new Command();
					ActionPerform action = delegate
					{
						setShowText(getPotionInfo(aa), ii2 % numW * 18, ii2 / numW * 18);
					};
					ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
					{
						Res.paintPotion(g, MainChar.listPotion[aa].index, x, y, 3);
						MFont.smallFont.drawString(g, getCountPotion(aa) + string.Empty, x + 11, y + 10, MFont.RIGHT);
					};
					command.action = action;
					command.actionPaint = actionPaint;
					mVector2.addElement(command);
					num++;
				}
			}
			for (int j = 0; j < MainChar.shopItem.size(); j++)
			{
				GemTemplate item = (GemTemplate)MainChar.shopItem.elementAt(j);
				int aa2 = num;
				Command command2 = new Command();
				ActionPerform action2 = delegate
				{
					showShopItemInfo(item.id, aa2);
				};
				ActionPaintCmd actionPaint2 = delegate(MyGraphics g, int x, int y)
				{
					Res.paintPotion(g, Res.getShopByID(item.id).idImage, x, y, 3);
					MFont.smallFont.drawString(g, item.number + string.Empty, x + 11, y + 10, MFont.RIGHT);
				};
				command2.action = action2;
				command2.actionPaint = actionPaint2;
				mVector2.addElement(command2);
				num++;
			}
			for (int k = 0; k < MainChar.gemItemKhoa.size(); k++)
			{
				int aa3 = num;
				GemTemplate item2 = (GemTemplate)MainChar.gemItemKhoa.elementAt(k);
				GemTemp ge = Res.getGemByID(item2.id);
				Command command3 = new Command();
				command3.action = delegate
				{
					showGemItemKhoaInfo(item2.id, aa3 % numW * 18, aa3 / numW * 18);
				};
				command3.actionPaint = delegate(MyGraphics g, int x, int y)
				{
					if (Res.getGemByID(item2.id) != null)
					{
						if (aa3 - ((index[focusTab] == 0) ? (countTabMyitem * 42) : 0) != selected)
						{
							g.setColor(3276851, 0.5f);
							g.fillRect(x - 20, y - 20, 40, 40);
						}
						Res.paintGemKhoa(g, Res.getGemByID(item2.id).idImage, x, y);
						if (ge.isEff != -1 && ge.isEff >= 0 && ge.isEff < GemTemp.color.Length)
						{
							Res.paintRectColor(g, x - 9, y - 9, 17, 17, ge.count, GemTemp.color[ge.isEff], 16516369);
							ge.count += 3;
							if (ge.count > 68)
							{
								ge.count = 0;
							}
						}
						MFont.smallFont.drawString(g, item2.number + string.Empty, x + 8, y + 10, MFont.RIGHT);
					}
				};
				mVector2.addElement(command3);
				num++;
			}
			for (int l = 0; l < MainChar.gemItem.size(); l++)
			{
				int aa4 = num;
				GemTemplate item3 = (GemTemplate)MainChar.gemItem.elementAt(l);
				GemTemp ge2 = Res.getGemByID(item3.id);
				Command command4 = new Command();
				ActionPerform action3 = delegate
				{
					showGemItemInfo(item3.id, aa4 % numW * 18, aa4 / numW * 18);
				};
				ActionPaintCmd actionPaint3 = delegate(MyGraphics g, int x, int y)
				{
					if (Res.getGemByID(item3.id) != null)
					{
						Res.paintGem(g, Res.getGemByID(item3.id).idImage, x, y);
						if (ge2.isEff != -1)
						{
							if (ge2.isEff < GemTemp.color.Length)
							{
								Res.paintRectColor(g, x - 9, y - 9, 17, 17, ge2.count, GemTemp.color[ge2.isEff], 16516369);
							}
							ge2.count += 3;
							if (ge2.count > 68)
							{
								ge2.count = 0;
							}
						}
						MFont.smallFont.drawString(g, item3.number + string.Empty, x + 11, y + 10, MFont.RIGHT);
					}
				};
				command4.action = action3;
				command4.actionPaint = actionPaint3;
				mVector2.addElement(command4);
				num++;
			}
			for (int m = 0; m < Char.animal.size(); m++)
			{
				int ii3 = num;
				AnimalInfo item4 = (AnimalInfo)Char.animal.elementAt(m);
				Command command5 = new Command();
				ActionPerform action4 = delegate
				{
					if (!item4.info.Equals(string.Empty))
					{
						if (item4.typeAnimal == 0)
						{
							setShowText(ItemInInventory.setTemp(item4.name + " lv" + item4.level, "0") + ItemInInventory.setTemp(item4.info, "0"), ii3 % numW * 18, ii3 / numW * 18);
						}
						else
						{
							long num4 = item4.totalTimeCon - (mSystem.getCurrentTimeMillis() - item4.timeStart) / 60000;
							setShowText(ItemInInventory.setTemp(item4.name, "0") + ItemInInventory.setTemp(item4.info, "0") + ItemInInventory.setTemp("Còn lại: " + num4 + " phút", "0"), ii3 % numW * 18, ii3 / numW * 18);
						}
					}
				};
				ActionPaintCmd actionPaint4 = delegate(MyGraphics g, int x, int y)
				{
					item4.paint(g, x, y);
				};
				command5.action = action4;
				command5.actionPaint = actionPaint4;
				mVector2.addElement(command5);
				num++;
			}
			for (int n = 0; n < Char.inventory.size(); n++)
			{
				int ii4 = num;
				ItemInInventory item5 = (ItemInInventory)Char.inventory.elementAt(n);
				Command command6 = new Command();
				ActionPerform action5 = delegate
				{
					showItemInventoryInfo(item5, isSell, ii4 % numW * 18, ii4 / numW * 18);
				};
				ActionPaintCmd actionPaint5 = delegate(MyGraphics g, int x, int y)
				{
					if (item5.isSelling)
					{
						g.setColor(7706352);
						g.fillRect(x - 8, y - 8, 16, 16);
					}
					item5.paint(g, x, y);
				};
				command6.action = action5;
				command6.actionPaint = actionPaint5;
				mVector2.addElement(command6);
				num++;
			}
			if (MainChar.itemQuest != null)
			{
				int num2 = MainChar.itemQuest.Length;
				for (int num3 = 0; num3 < num2; num3++)
				{
					int aa5 = num3;
					if (MainChar.itemQuest[num3] > 0)
					{
						int ii = num;
						int idImg = ItemQuest.ICON_IMG[num3] + 8000;
						string sl = MainChar.itemQuest[num3] + string.Empty;
						Command command7 = new Command();
						command7.action = delegate
						{
							setShowText(getInfoItemQuest(aa5), ii % numW * 18, ii / numW * 18);
						};
						command7.actionPaint = delegate(MyGraphics g, int x, int y)
						{
							GameData.paintIcon(g, (short)idImg, x, y);
							MFont.smallFontColor[3].drawString(g, sl, x + 8, y + 1, MFont.RIGHT);
						};
						mVector2.addElement(command7);
					}
				}
				return mVector2;
			}
			return mVector2;
		}
		catch (Exception)
		{
			return mVector2;
		}
	}

	private void showItemInventoryAnimalInfo(ItemInInventory item, bool isSell, int x, int y)
	{
		arrayKhamNgoc = null;
		if (item.totalKham > 0)
		{
			arrayKhamNgoc = new sbyte[item.totalKham];
			for (int i = 0; i < item.totalKham; i++)
			{
				arrayKhamNgoc[i] = -1;
			}
			for (int j = 0; j < item.property.Length; j++)
			{
				if (item.property[j] > 0)
				{
					for (int k = 0; k < item.numKham; k++)
					{
						arrayKhamNgoc[k] = Res.idNgocKham[j];
					}
					break;
				}
			}
		}
		setShowText(item.getDescription(isSell), x, y);
		if (!item.isEnoughData)
		{
			item.isEnoughData = true;
			GameService.gI().requestItemInfo(item.itemID, (charWearing != null) ? charWearing.ID : Canvas.gameScr.mainChar.ID);
		}
	}

	private void showItemInventoryInfo(ItemInInventory item, bool isSell, int x, int y)
	{
		arrayKhamNgoc = null;
		if (item.totalKham > 0)
		{
			arrayKhamNgoc = new sbyte[item.totalKham];
			for (int i = 0; i < item.totalKham; i++)
			{
				arrayKhamNgoc[i] = -1;
			}
			sbyte b = 0;
			for (int j = 0; j < item.allAttribute.size(); j++)
			{
				InfoAttributeItem infoAttributeItem = (InfoAttributeItem)item.allAttribute.elementAt(j);
				if (infoAttributeItem.getColorPaint(kick: false) == 3)
				{
					for (int k = 0; k < item.numKham; k++)
					{
						arrayKhamNgoc[b++] = Res.idNgocKham[infoAttributeItem.getID() - 10];
					}
					break;
				}
			}
		}
		if (!item.isEnoughData)
		{
			GameService.gI().requestItemInfo(item.itemID, (charWearing != null) ? charWearing.ID : Canvas.gameScr.mainChar.ID);
		}
		else
		{
			setShowText(item.getDescription(isSell), x, y);
		}
	}

	public void closeText()
	{
		isShowText = false;
		arrayKhamNgoc = null;
	}

	private void setShowTextArr(string[] text, int x1, int y1)
	{
		isTextArr = true;
		isShowText = true;
		wShow = wKhung - (x0 - 2 + 7 * wCell);
		xShow = 7 * wCell;
		yShow = -10;
		showText = text;
		hShow = hView;
		if (countPop == 0)
		{
			countPop = -(showText.Length - 1);
		}
		cmyText = (cmtoYText = (cmyLimText = 0));
		cmyLimText = showText.Length * 18 - hShow;
		if (cmyLimText < 0)
		{
			cmyLimText = 0;
		}
	}

	private void setShowText(string text, int x1, int y1)
	{
		isTextArr = false;
		isShowText = true;
		wShow = wKhung - (x0 - 2 + 7 * wCell);
		xShow = 7 * wCell;
		yShow = -10;
		showText = MFont.arialFontW.splitFontBStrInLine(text, www);
		hShow = hView;
		if (countPop == 0)
		{
			countPop = -(showText.Length - 1);
		}
		cmyText = (cmtoYText = (cmyLimText = 0));
		cmyLimText = showText.Length * 18 - hShow;
		if (cmyLimText < 0)
		{
			cmyLimText = 0;
		}
	}

	private void paintCharWearing(MyGraphics g)
	{
		if (selected > 14)
		{
			selected = 14;
		}
		if (selected < 0)
		{
			selected = 0;
		}
		charWearing.paintAvatar(g, (short)(90 + xTr), (short)(120 + yTr));
		if (imgCharWear != null && Canvas.gameTick % 16 >= 8)
		{
			g.drawImage(imgCharWear, w / 2 + 5 + xTr, 5 + yTr, MyGraphics.TOP | MyGraphics.HCENTER);
		}
		g.setColor(14605278);
		g.drawRect(39 + xTr, -5 + yTr, 104, 208);
		g.fillRect(43 + xTr, -5 + yTr + 175, 30, 30);
		g.fillRect(110 + xTr, -5 + yTr + 175, 30, 30);
		for (int i = 0; i < 5; i++)
		{
			g.fillRect(-3 + xTr, -5 + i * 42 + yTr, 40, 40);
			g.fillRect(147 + xTr, -5 + i * 42 + yTr, 40, 40);
		}
		g.setColor(4802889);
		g.fillRect(44 + xTr, -5 + yTr + 176, 28, 28);
		g.fillRect(111 + xTr, -5 + yTr + 176, 28, 28);
		for (int j = 0; j < 5; j++)
		{
			g.fillRect(-2 + xTr, -4 + j * 42 + yTr, 38, 38);
			g.fillRect(148 + xTr, -4 + j * 42 + yTr, 38, 38);
		}
		if (isPaintFc)
		{
			g.setColor(10595790, 0.5f);
			if (selected % 3 != 1)
			{
				int num = 0;
				if (selected == 2 || selected == 5 || selected == 8 || selected == 11 || selected == 14)
				{
					num = 1;
				}
				g.fillRect(-2 + num * 150 + xTr, selected / numW * 42 - 4 + yTr, 38, 38);
			}
			else if (selected != 4)
			{
				g.fillRect(111 + xTr, -5 + yTr + 176, 28, 28);
			}
			else
			{
				g.fillRect(44 + xTr, -5 + yTr + 176, 28, 28);
			}
		}
		int num2 = 0;
		if (charWearing.wearingItems != null)
		{
			sbyte b = (sbyte)charWearing.wearingItems.size();
			ItemInInventory itemInInventory = null;
			ItemTemplate itemTemplate = null;
			for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
			{
				itemInInventory = (ItemInInventory)charWearing.wearingItems.elementAt(b2);
				itemTemplate = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				if (itemTemplate.type == 8)
				{
					if (itemInInventory.viTriVe == 1)
					{
						paintItemIcon(g, itemInInventory, 165 + xTr, 96 + yTr);
					}
					else
					{
						paintItemIcon(g, itemInInventory, 165 + xTr, 140 + yTr);
					}
				}
				else
				{
					paintItemIcon(g, itemInInventory, posPaintWearingX[itemTemplate.type], posPaintWearingY[itemTemplate.type]);
				}
			}
		}
		if (!Canvas.gameScr.mainChar.isDoing && charWearing.idAnimal > -1)
		{
			GameData.paintIcon(g, (short)(charWearing.idPaintIconAnimal + 7500), 125 + xTr, 185 + yTr);
		}
	}

	private void paintAnimalWearing(MyGraphics g)
	{
		if (charWearing != null && charWearing.imgAnimal != null && (charWearing.useHorse != -1 || charWearing.idhorse > -1))
		{
			g.drawRegion(charWearing.imgAnimal, 0, charWearing.himg * idFrame, charWearing.wimg, charWearing.himg, 0, Res.imgInfoWindow[0].getWidth() / 2 + xTr, Res.imgInfoWindow[0].getHeight() / 2 + yTr, 3);
		}
		g.drawImage(Res.imgInfoWindowt, -3 + xTr, -5 + yTr, 0);
		g.setColor(14605278);
		for (int i = 0; i < 5; i++)
		{
			g.fillRect(-3 + xTr, -5 + i * 42 + yTr, 40, 40);
			g.fillRect(147 + xTr, -5 + i * 42 + yTr, 40, 40);
		}
		g.setColor(4802889);
		for (int j = 0; j < 5; j++)
		{
			g.fillRect(-2 + xTr, -4 + j * 42 + yTr, 38, 38);
			g.fillRect(148 + xTr, -4 + j * 42 + yTr, 38, 38);
		}
		if (isPaintFc)
		{
			g.setColor(10595790, 0.5f);
			if (selected % 2 == 0)
			{
				g.fillRect(-2 + xTr, selected / 2 * 42 - 4 + yTr, 38, 38);
			}
			else
			{
				g.fillRect(148 + xTr, selected / 2 * 42 - 4 + yTr, 38, 38);
			}
		}
		int num = 0;
		if (charWearing == null || charWearing.wearingAnimal == null || (charWearing.useHorse == -1 && charWearing.idhorse <= -1))
		{
			return;
		}
		sbyte b = (sbyte)charWearing.wearingAnimal.size();
		ItemInInventory itemInInventory = null;
		ItemTemplate itemTemplate = null;
		for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
		{
			itemInInventory = (ItemInInventory)charWearing.wearingAnimal.elementAt(b2);
			if (itemInInventory != null)
			{
				itemTemplate = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				if (itemTemplate != null)
				{
					paintItemIcon(g, itemInInventory, posPaintWearingX[itemTemplate.type], posPaintWearingY[itemTemplate.type]);
				}
			}
		}
	}

	private void paintItemIcon(MyGraphics g, ItemInInventory item, int x, int y)
	{
		ItemTemplate item2 = Res.getItem(item.charClazz, item.idTemplate);
		GameData.paintIcon(g, item2.idIcon, x, y);
	}

	private void paintCheDo(MyGraphics g)
	{
		int num = 0;
		g.setClip(-10, -10, w + 5, h + 20);
		for (int i = 0; i < WindowInfoScr.gI().listCheDo.size(); i++)
		{
			Mineral mineral = (Mineral)WindowInfoScr.gI().listCheDo.elementAt(i);
			MFont.normalFont[0].drawString(g, mineral.name + ": " + mineral.number + " Cái.", -10, i * 13 + 2 - 10, 0);
		}
		g.setColor(16766498);
		g.fillRect(-10, 4 + WindowInfoScr.gI().listCheDo.size() * 13 - 10, w + 2, 2);
		g.fillRect(-10, 4 + (hSmall - 27) * 3 + WindowInfoScr.gI().listCheDo.size() * 13, w + 2, 2);
		int num2 = 0;
		int num3 = WindowInfoScr.gI().listEp.size() / 2;
		if (num3 < 6)
		{
			num3 = 6;
		}
		g.translate(0, 0);
		g.setColor(10595790);
		if (selected / numW < 2)
		{
			g.fillRect(selected % numW * 24 - 9, WindowInfoScr.gI().listCheDo.size() * 13 + selected / numW * 24 + 13 - 10, 23, 23);
		}
		g.translate(0, 0);
		for (int j = 0; j < WindowInfoScr.gI().listEp.size(); j++)
		{
			GemTemplate gemTemplate = (GemTemplate)WindowInfoScr.gI().listEp.elementAt(j);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, j % num3 * 24 + wSmall / 2 + 4 - 10, WindowInfoScr.gI().listCheDo.size() * 13 + 13 + j / num3 * 24 + wSmall / 2 - 10);
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, j % num3 * 24 + wSmall / 2 - 10, WindowInfoScr.gI().listCheDo.size() * 13 + 13 + j / num3 * 24 + wSmall / 2 - 10, MFont.RIGHT);
			num2++;
		}
		for (int k = 0; k < 3; k++)
		{
			g.setColor(8092027);
			g.fillRect(-10, k * 24 + 27, 146, 2);
		}
		for (int l = 0; l < 7; l++)
		{
			g.setColor(8092027);
			g.fillRect(l * 24 - 10, 27, 2, 48);
		}
		if (selected / numW >= 2)
		{
			g.translate(-cmx, 0);
			g.setColor(10595790);
			g.fillRect(selected % numW * 24 + 1, (hSmall - 27) * 5 + 1, 23, 23);
		}
		else
		{
			g.translate(-10, 0);
		}
		paintGemItemCheDo(g, num, (hSmall - 27) * 5);
		for (num += WindowInfoScr.gI().listTemp.size(); num < 6; num++)
		{
			int num4 = 5 * (hSmall - 27);
			for (int m = 0; m < 2; m++)
			{
				g.setColor(8092027);
				g.fillRect(0, m * 24 + num4, num * 24 + 24 + 2, 2);
			}
			for (int n = 0; n < num + 2; n++)
			{
				g.setColor(8092027);
				g.fillRect(n * 24, num4, 2, 24);
			}
		}
	}

	private void paintGemItemCheDo(MyGraphics g, int count, int y)
	{
		for (int i = 0; i < WindowInfoScr.gI().listTemp.size(); i++)
		{
			for (int j = 0; j < 2; j++)
			{
				g.setColor(8092027);
				g.fillRect(0, j * 24 + y, count * 24 + 24 + 2, 2);
			}
			for (int k = 0; k < count + 2; k++)
			{
				g.setColor(8092027);
				g.fillRect(k * 24, y, 2, 24);
			}
			GemTemplate gemTemplate = (GemTemplate)WindowInfoScr.gI().listTemp.elementAt(i);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, count * 24 + 12, y + 12);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			string s = gemByID.name.Substring(gemByID.name.Length - 1);
			try
			{
				int num = int.Parse(s);
				MFont.smallFont.drawString(g, num + string.Empty, count * 24, y + 2, MFont.LEFT);
			}
			catch (Exception)
			{
			}
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, count * 24 + 20, y + 17, MFont.RIGHT);
			count++;
		}
	}

	protected void doSelectedCheDo()
	{
		try
		{
			bool iss = selected / numW < 2;
			GemTemplate gem = null;
			if (iss)
			{
				if (selected < WindowInfoScr.gI().listEp.size())
				{
					gem = (GemTemplate)WindowInfoScr.gI().listEp.elementAt(selected);
				}
			}
			else if (selected % numW < WindowInfoScr.gI().listTemp.size())
			{
				gem = (GemTemplate)WindowInfoScr.gI().listTemp.elementAt(selected % numW);
			}
			if (gem == null)
			{
				return;
			}
			GemTemplate g = gem;
			int xx = selected % numW * wSmall + cmx;
			int yy = selected / numW * wSmall;
			short idTem = gem.id;
			mVector mVector2 = new mVector();
			Command command = new Command(iss ? "Lấy ra" : "Bỏ vào");
			ActionPerform action = delegate
			{
				if (iss)
				{
					removeItemCheDo(g);
				}
				else
				{
					int num = 0;
					for (int i = 0; i < WindowInfoScr.gI().listCheDo.size(); i++)
					{
						Mineral mineral = (Mineral)WindowInfoScr.gI().listCheDo.elementAt(i);
						if (g.id - mineral.idTemplate >= 0 && g.id - mineral.idTemplate <= 5)
						{
							for (int j = 0; j < WindowInfoScr.gI().listEp.size(); j++)
							{
								GemTemplate gemTemplate = (GemTemplate)WindowInfoScr.gI().listEp.elementAt(j);
								if (gemTemplate.id - mineral.idTemplate >= 0 && gemTemplate.id - mineral.idTemplate <= 5)
								{
									num += gem.number;
								}
							}
							if (num >= mineral.number)
							{
								Canvas.startOKDlg("Đã đủ số lượng.");
								return;
							}
						}
					}
					bool flag = false;
					for (int k = 0; k < WindowInfoScr.gI().listEp.size(); k++)
					{
						GemTemplate gemTemplate2 = (GemTemplate)WindowInfoScr.gI().listEp.elementAt(k);
						if (gemTemplate2.id == g.id)
						{
							gemTemplate2.number++;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						GemTemplate gemTemplate3 = new GemTemplate(g.id);
						GemTemplate.copyData(g, gemTemplate3);
						gemTemplate3.number = 1;
						WindowInfoScr.gI().listEp.addElement(gemTemplate3);
					}
					g.number--;
					if (g.number <= 0)
					{
						WindowInfoScr.gI().listTemp.removeElement(g);
					}
				}
				setLimitCheDo();
			};
			command.action = action;
			mVector2.addElement(command);
			Command command2 = new Command("Thông tin");
			ActionPerform action2 = delegate
			{
				showGemItemInfo(idTem, xx, yy);
			};
			command2.action = action2;
			mVector2.addElement(command2);
			Canvas.menu.startAt(mVector2, 2);
		}
		catch (Exception)
		{
		}
	}

	private void removeItemCheDo(GemTemplate g)
	{
		g.number--;
		if (g.number <= 0)
		{
			WindowInfoScr.gI().listEp.removeElement(g);
		}
		bool flag = false;
		for (int i = 0; i < WindowInfoScr.gI().listTemp.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)WindowInfoScr.gI().listTemp.elementAt(i);
			if (gemTemplate.id == g.id)
			{
				gemTemplate.number++;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			GemTemplate gemTemplate2 = new GemTemplate(g.id);
			GemTemplate.copyData(g, gemTemplate2);
			gemTemplate2.number = 1;
			WindowInfoScr.gI().listTemp.addElement(g);
		}
	}

	private void setLimitCheDo()
	{
		int num = selected % numW;
		if (selected / numW == 1)
		{
			int num2 = WindowInfoScr.gI().listEp.size() / 2;
			if (num2 < 6)
			{
				num2 = 6;
			}
			numW = num2;
			if (numW < 6)
			{
				numW = 6;
			}
			if (num >= numW)
			{
				num = numW - 1;
			}
			selected = numW + num;
		}
		else if (selected / numW == 2)
		{
			numW = WindowInfoScr.gI().listTemp.size();
			if (numW < 6)
			{
				numW = 6;
			}
			if (num >= numW)
			{
				num = numW - 1;
			}
			selected = 2 * numW + num;
		}
		setLim();
		cmxLim = numW * wSmall - 124;
		if (cmx < 0)
		{
			cmx = -10;
		}
		if (cmx > cmxLim)
		{
			cmx = (cmtoX = cmxLim + 30);
		}
	}

	protected void doLeftCheDo()
	{
		if (WindowInfoScr.gI().listEp.size() == 0)
		{
			return;
		}
		sbyte[][] array = new sbyte[WindowInfoScr.gI().listCheDo.size()][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new sbyte[6];
		}
		for (int j = 0; j < WindowInfoScr.gI().listEp.size(); j++)
		{
			GemTemplate gemTemplate = (GemTemplate)WindowInfoScr.gI().listEp.elementAt(j);
			for (int k = 0; k < WindowInfoScr.gI().listCheDo.size(); k++)
			{
				Mineral mineral = (Mineral)WindowInfoScr.gI().listCheDo.elementAt(k);
				int num = gemTemplate.id - mineral.idTemplate;
				if (num <= 5)
				{
					array[k][num] = (sbyte)gemTemplate.number;
					break;
				}
			}
		}
		sbyte[][] ar = array;
		ActionPerform yesAction = delegate
		{
			for (int num2 = WindowInfoScr.gI().listEp.size() - 1; num2 >= 0; num2--)
			{
				GemTemplate g = (GemTemplate)WindowInfoScr.gI().listEp.elementAt(num2);
				removeItemCheDo(g);
			}
			GameService.gI().doCheDo((short)WindowInfoScr.gI().listCheDo.size(), WindowInfoScr.idTemp, ar);
			right.perform();
			Canvas.startWaitDlg();
		};
		Canvas.startYesNoDlg("Bạn có muốn hoàn thành không ?", yesAction);
	}

	public void updateKeyDong()
	{
		count++;
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		if (timeOpen > 0)
		{
			timeOpen--;
			isPaintFc = true;
			if (timeOpen != 0L || !canSelecet)
			{
				return;
			}
			switch (curentTabUpdate)
			{
			case 1:
			case 2:
				if (selected <= -1)
				{
					break;
				}
				if (saveSelect != selected)
				{
					countClick = 0;
				}
				setCmdCenter();
				if (center == null)
				{
					break;
				}
				countClick++;
				saveSelect = selected;
				center.perform();
				if (countClick >= 2)
				{
					if (curentTabUpdate == 2)
					{
						doSelectedInventori();
					}
					else if (cmdShop != null)
					{
						cmdShop.perform();
					}
					countClick = 0;
				}
				break;
			case 3:
				if (center != null)
				{
					center.perform();
				}
				setCmdCenter();
				break;
			case 4:
				if (Canvas.px > 120 + xTr && Canvas.px <= 160 + xTr && Canvas.py > 220 + yTr && Canvas.py <= 260 + yTr)
				{
					closeText();
				}
				else if (((Canvas.px > x0 + xTr && Canvas.px <= x0 + 40 + xTr) || (Canvas.px > x0 + 150 + xTr && Canvas.px <= x0 + 190 + xTr)) && Canvas.py > 60 + yTr && Canvas.py <= 260 + yTr)
				{
					if (center != null)
					{
						center.perform();
					}
					setCmdCenter();
				}
				break;
			case 5:
			{
				if (center != null)
				{
					center.perform();
				}
				setCmdCenter();
				if (selected < 0)
				{
					selected = 0;
				}
				else if (selected > SkillManager.SKILL_NAME[Canvas.gameScr.mainChar.clazz].Length - 1)
				{
					selected = SkillManager.SKILL_NAME[Canvas.gameScr.mainChar.clazz].Length - 1;
				}
				string text = SkillManager.SKILL_NAME[Canvas.gameScr.mainChar.clazz][selected];
				sbyte b = Char.skillLevelLearnt[selected];
				if (b == 9)
				{
					text = text + " MAX" + b;
				}
				else if (b >= 1)
				{
					text = text + " lv " + b;
				}
				string[] infoSkill = Canvas.gameScr.mainChar.getInfoSkill(selected);
				string[] array = new string[infoSkill.Length + 1];
				array[0] = text;
				for (int j = 1; j < infoSkill.Length + 1; j++)
				{
					array[j] = infoSkill[j - 1];
				}
				setShowTextArr(array, 0, 0);
				break;
			}
			case 6:
				setCmdCenter();
				if (center != null)
				{
					center.perform();
				}
				break;
			case 8:
				if (Canvas.px >= x0 + xTr && Canvas.px <= x0 + 140 + xTr && Canvas.py >= y0 + yTr && Canvas.py <= y0 + 168 + yTr)
				{
					Canvas.gameScr.gameService.setConfig(selectConfig);
					Canvas.gameScr.switchToMe();
				}
				else
				{
					if (Canvas.px < x0 + 140 + xTr || Canvas.px > Canvas.w || Canvas.py < y0 + yTr || Canvas.py > y0 + 168 + yTr)
					{
						break;
					}
					switch (selected)
					{
					case 0:
						Canvas.gameScr.switchToMe();
						doBigMap();
						break;
					case 1:
						Canvas.gameScr.switchToMe();
						HelpScr.gI().switchToMe();
						break;
					case 2:
						Canvas.gameScr.onoffInvite = ((!Canvas.gameScr.onoffInvite) ? true : false);
						GameService.gI().setConfig(Canvas.gameScr.onoffInvite ? 5 : 4);
						Canvas.gameScr.switchToMe();
						Canvas.startOKDlg(Canvas.gameScr.onoffInvite ? "Đã tắt chức năng nhận lời mời." : "Đã bật chức năng nhận lời mời.");
						break;
					case 3:
						Canvas.gameScr.switchToMe();
						Canvas.gameScr.isBatMiniMap = true;
						Canvas.gameScr.hideGUI += 2;
						if (Canvas.gameScr.hideGUI > 2)
						{
							Canvas.gameScr.hideGUI = 0;
						}
						break;
					case 4:
						Canvas.autoTab.switchToMe();
						break;
					case 5:
						Canvas.autoTab.switchToMe();
						Canvas.autoTab.isOptionFocus = true;
						Canvas.autoTab.currentIndex = GameScr.typeOptionFocus;
						Canvas.autoTab.setInfo();
						break;
					}
				}
				break;
			case 9:
				doClan(selected);
				break;
			case 10:
				switch (selected)
				{
				case 0:
					Canvas.gameScr.switchToMe();
					MessageScr.gI().switchToMe();
					break;
				case 1:
					MsgWorld.gI().switchToMe();
					break;
				case 2:
					Canvas.gameScr.switchToMe();
					try
					{
						if (ListScr.gI().freindList == null || ListScr.gI().freindList.size() == 0)
						{
							Canvas.startOKDlg("Chưa có bạn");
							break;
						}
						mVector mVector2 = new mVector();
						for (int i = 0; i < ListScr.gI().freindList.size(); i++)
						{
							Char o = (Char)ListScr.gI().freindList.elementAt(i);
							mVector2.addElement(o);
						}
						ListScr.gI().setInfo(mVector2, 0, "BẠN BÈ");
						ListScr.gI().switchToMe();
					}
					catch (Exception)
					{
						Out.println("Loi chua co ban be!");
					}
					break;
				case 3:
					GameService.gI().requestTopStronger_Righer(ListScr.STRONGER, 0);
					break;
				case 4:
					Canvas.gameScr.switchToMe();
					GameService.gI().requestTopStronger_Righer(ListScr.RIGHER, 0);
					break;
				case 5:
					Canvas.gameScr.switchToMe();
					GameService.gI().requestTopStronger_Righer(ListScr.TOP, 0);
					break;
				case 6:
					Tree2014.gI().switchToMe(Canvas.gameScr);
					break;
				case 7:
					TuBinhScr.gI().switchToMe(Canvas.gameScr);
					break;
				case 8:
					GameService.gI().dosendKhacMenu();
					break;
				}
				break;
			}
			canSelecet = false;
			return;
		}
		if (Canvas.isPointerDownItem && Canvas.isPointer(xBegin, yBegin, wTouch, hTouch))
		{
			pyLast = Canvas.pyLast;
			pxLast = Canvas.pxLast;
			Canvas.isPointerDownItem = false;
			timeDelay = count;
			pa = cmy;
			pb = cmx;
			xCamLast = cmx;
			transY = true;
			vY = 0f;
			vX = 0f;
		}
		if (!transY)
		{
			return;
		}
		long num = count - timeDelay;
		int num2 = pyLast - Canvas.py;
		pyLast = Canvas.py;
		int num3 = pxLast - Canvas.px;
		pxLast = Canvas.px;
		if (Canvas.isPointerDown)
		{
			if (count % 2 == 0L)
			{
				dyTran = Canvas.py;
				dxTran = Canvas.px;
				timePointY = count;
				timePointX = count;
			}
			vY = 0f;
			vX = 0f;
			if (cmtoY <= 0 || cmtoY >= cmyLim)
			{
				if (Canvas.beginMoveCmrY())
				{
					cmtoY = pa + Canvas.dy() / 2;
				}
			}
			else if (Canvas.beginMoveCmrY())
			{
				cmtoY = pa + num2;
				pa = cmtoY;
			}
			if (cmtoX <= 0 || cmtoX >= cmxLim)
			{
				if (Canvas.beginMoveCmrX())
				{
					cmtoX = pb + Canvas.dx() / 2;
				}
			}
			else if (Canvas.beginMoveCmrX())
			{
				cmtoX = pb + num3;
				pb = cmtoX;
			}
			cmy = cmtoY;
			cmx = cmtoX;
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
				if (curentTabUpdate != 6)
				{
					closeText();
				}
				isPaintFc = false;
			}
		}
		if (!Canvas.isPointerRelease)
		{
			return;
		}
		transY = false;
		int num4 = (int)(count - timePointY);
		float num5 = dyTran - Canvas.py;
		float num6 = dxTran - Canvas.px;
		if (Canvas.beginMoveCmrY())
		{
			vY = num5 / (float)num4 * 10f;
		}
		int num7 = (int)(count - timePointX);
		if (Math.abs((int)num6) > 40 && num7 < 20 && cmtoX > 0 && cmtoX < cmxLim)
		{
			vX = num6 / (float)num7 * 10f;
		}
		timePointY = -1L;
		timePointX = -1L;
		if (Main.canvas.canPutKey() && timeHold != 5)
		{
			if (num <= 4)
			{
				timeHold = 0;
				timeOpen = 5L;
				canSelecet = true;
				checkSelect();
			}
		}
		else if (timeHold >= 5)
		{
			timeHold = 0;
			timeOpen = 5L;
			canSelecet = true;
			checkSelect();
		}
		transX = false;
	}

	public void checkSelect()
	{
		switch (curentTabUpdate)
		{
		case 1:
		case 2:
		{
			cmtoX = 0;
			int num11 = (cmtoY + Canvas.py - (y0 - 10) - yTr) / (hSmall + 10);
			int num12 = (cmtoX + Canvas.px - (x0 - 10) - xTr) / (wSmall + 10);
			selected = num11 * 5 + num12;
			if (selected > 41)
			{
				selected = 41;
			}
			if (selected < 0)
			{
				selected = 0;
			}
			break;
		}
		case 3:
			if (Canvas.px > 70 + xTr && Canvas.px <= 110 + xTr && Canvas.py > 200 + yTr && Canvas.py <= 300 + yTr)
			{
				closeText();
				selected = 4;
				Out.println("thong tin ao choang ");
			}
			else if (Canvas.px > 120 + xTr && Canvas.px <= 160 + xTr && Canvas.py > 200 + yTr && Canvas.py <= 300 + yTr)
			{
				closeText();
				selected = 1;
			}
			else if (Canvas.px > x0 + xTr && Canvas.px <= x0 + 40 + xTr && Canvas.py > 50 + yTr && Canvas.py <= 280 + yTr)
			{
				int num19 = hSmall + 20;
				int num20 = (Canvas.py - (y0 + 5) - yTr) / num19;
				int num21 = (Canvas.px - (x0 + 5) - xTr) / wSmall;
				int num22 = num20 * numW + num21;
				if (num22 < 0)
				{
					num22 = 0;
				}
				if (num22 > 13)
				{
					num22 = 13;
				}
				selected = num22;
				Out.println("h menu>>>>>>>>>>>>>>>> " + num19);
			}
			else if (Canvas.px > x0 + 150 + xTr && Canvas.px <= x0 + 190 + xTr && Canvas.py > 50 + yTr && Canvas.py <= 280 + yTr)
			{
				int num23 = (Canvas.py - (y0 + 5) - yTr) / (hSmall + 20);
				int num24 = (Canvas.px - x0 - xTr) / wSmall;
				int num25 = num23 * numW + num24 + 1;
				if (num25 < 2)
				{
					num25 = 2;
				}
				if (num25 > 14)
				{
					num25 = 14;
				}
				selected = num25;
			}
			break;
		case 4:
			if (Canvas.px > 120 + xTr && Canvas.px <= 160 + xTr && Canvas.py > 220 + yTr && Canvas.py <= 260 + yTr)
			{
				closeText();
			}
			else if (Canvas.px > x0 + xTr && Canvas.px <= x0 + 40 + xTr && Canvas.py > 60 + yTr && Canvas.py <= 260 + yTr)
			{
				int num26 = (Canvas.py - (y0 + 5) - yTr) / (hSmall + 20);
				selected = num26 * 2;
				if (selected < 0)
				{
					selected = 0;
				}
				if (selected > 8)
				{
					selected = 8;
				}
			}
			else if (Canvas.px > x0 + 150 + xTr && Canvas.px <= x0 + 190 + xTr && Canvas.py > 60 + yTr && Canvas.py <= 260 + yTr)
			{
				int num27 = (Canvas.py - (y0 + 5) - yTr) / (hSmall + 20);
				selected = num27 * 2 + 1;
				if (selected > 9)
				{
					selected = 9;
				}
			}
			break;
		case 5:
		{
			int num16 = (Canvas.py - y0 - yTr) / (newSise + 10);
			int num17 = (Canvas.px - (x0 - 10) - xTr) / newSise;
			int num18 = num16 * 5 + num17;
			if (num18 < 0)
			{
				num18 = 0;
			}
			if (num18 > Canvas.gameScr.mainChar.getnSkill() - 1)
			{
				num18 = Canvas.gameScr.mainChar.getnSkill() - 1;
			}
			selected = num18;
			break;
		}
		case 6:
		{
			int num13 = (Canvas.py - (y0 + 5) - yTr - 34) / 30;
			if (num13 < 0)
			{
				num13 = 0;
			}
			if (num13 > 4)
			{
				num13 = 4;
			}
			selected = num13;
			break;
		}
		case 8:
			if (Canvas.pxLast >= x0 + xTr && Canvas.pxLast <= x0 + 140 + xTr && Canvas.pyLast >= y0 + yTr && Canvas.pyLast <= y0 + 168 + yTr)
			{
				int num5 = Canvas.pyLast - Canvas.py;
				int num6 = Canvas.pxLast - Canvas.px;
				int num7 = (Canvas.py - (y0 + 15) - yTr) / 40;
				if (num7 > 3)
				{
					num7 = 3;
				}
				leftRightSetting = false;
				selectConfig = num7;
				selected = -1;
			}
			if (Canvas.pxLast >= x0 + 140 + xTr && Canvas.pxLast <= Canvas.w && Canvas.pyLast >= y0 + yTr && Canvas.pyLast <= y0 + 168 + yTr)
			{
				int num8 = Canvas.pyLast - Canvas.py;
				int num9 = Canvas.pxLast - Canvas.px;
				leftRightSetting = true;
				int num10 = (cmtoY + Canvas.py - y0 - yTr) / 35;
				selected = num10;
				selectConfig = -1;
			}
			break;
		case 9:
		{
			int num14 = (Canvas.py - (y0 + 5) - yTr) / 35;
			int num15 = (Canvas.px - (x0 - 5) - xTr) / (wKhung / 2);
			if (Canvas.pxLast < Canvas.hw)
			{
				leftRightSetting = false;
			}
			else
			{
				leftRightSetting = true;
			}
			selected = num14 * 2 + num15;
			if (selected > nameClan.Length - 1)
			{
				selected = nameClan.Length - 1;
			}
			break;
		}
		case 10:
		{
			int num = (Canvas.py - (y0 + 5) - yTr) / 35;
			int num2 = (Canvas.px - (x0 - 5) - xTr) / (wKhung / 2);
			int num3 = Canvas.pyLast - Canvas.py;
			int num4 = Canvas.pxLast - Canvas.px;
			if (Canvas.pxLast < Canvas.hw)
			{
				leftRightSetting = false;
			}
			else
			{
				leftRightSetting = true;
			}
			selected = num * 2 + num2;
			break;
		}
		case 7:
			break;
		}
	}

	public void moveCamera()
	{
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		if (vY != 0f)
		{
			if (cmy < 0 || cmy > cmyLim)
			{
				if (vY > 500f)
				{
					vY = 500f;
				}
				else if (vY < -500f)
				{
					vY = -500f;
				}
				vY -= vY / 5f;
				if (Math.abs((int)(vY / 10f)) <= 10)
				{
					vY = 0f;
				}
			}
			cmy += (int)(vY / 15f);
			cmtoY = cmy;
			vY -= vY / 20f;
		}
		else if (cmy < 0)
		{
			cmtoY = 0;
		}
		else if (cmy > cmyLim)
		{
			cmtoY = cmyLim;
		}
		if (vX != 0f)
		{
			if (cmx < 0 || cmx > cmxLim)
			{
				if (vX > 500f)
				{
					vX = 500f;
				}
				else if (vX < -500f)
				{
					vX = -500f;
				}
				vX -= vX / 5f;
				if (Math.abs((int)(vX / 10f)) <= 10)
				{
					vX = 0f;
				}
			}
			cmx += (int)(vX / 15f);
			cmtoX = cmx;
			vX -= vX / 20f;
		}
		else if (cmx < 0)
		{
			cmtoX = 0;
		}
		else if (cmx > cmxLim)
		{
			cmtoX = cmxLim;
		}
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
		if (cmx != cmtoX)
		{
			cmvx = cmtoX - cmx << 2;
			cmdx += cmvx;
			cmx += cmdx >> 4;
			cmdx &= 15;
		}
	}

	public void updateKeyShowText()
	{
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		countShowText++;
		if (Canvas.isPointerDownText && Canvas.isPointer(xBegint + xTr, yBegint + yTr, wToucht, hToucht))
		{
			pyLastt = Canvas.pyLast;
			Canvas.isPointerDownText = false;
			timeDelayt = countShowText;
			pa = cmyText;
			transYShowText = true;
			vYT = 0f;
		}
		if (transYShowText)
		{
			long num = countShowText - timeDelayt;
			int num2 = pyLastt - Canvas.py;
			pyLastt = Canvas.py;
			if (Canvas.isPointerDown)
			{
				if (countShowText % 2 == 0)
				{
					dyTrant = Canvas.py;
					timePointYt = countShowText;
				}
				vYT = 0f;
				if (cmtoYText <= 0 || cmtoYText >= cmyLimText)
				{
					if (Canvas.beginMoveCmrY())
					{
						cmtoYText = pa + Canvas.dy() / 2;
					}
				}
				else if (Canvas.beginMoveCmrY())
				{
					cmtoYText = pa + num2;
					pa = cmtoYText;
				}
				cmyText = cmtoYText;
			}
			if (Canvas.isPointerRelease)
			{
				transYShowText = false;
				int num3 = (int)(countShowText - timePointYt);
				float num4 = dyTrant - Canvas.py;
				float num5 = dxTrant - Canvas.px;
				vYT = num4 / (float)num3 * 10f;
				timePointYt = -1L;
			}
		}
		moveCameraShowText();
	}

	public void moveCameraShowText()
	{
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		if (vYT != 0f)
		{
			if (cmyText < 0 || cmyText > cmyLimText)
			{
				if (vYT > 500f)
				{
					vYT = 500f;
				}
				else if (vYT < -500f)
				{
					vYT = -500f;
				}
				vYT -= vYT / 5f;
				if (Math.abs((int)(vYT / 10f)) <= 10)
				{
					vYT = 0f;
				}
			}
			cmyText += (int)(vYT / 15f);
			cmtoYText = cmyText;
			vYT -= vYT / 20f;
		}
		else if (cmyText < 0)
		{
			cmtoYText = 0;
		}
		else if (cmyText > cmyLimText)
		{
			cmtoYText = cmyLimText;
		}
		if (cmyText != cmtoYText)
		{
			cmvyText = cmtoYText - cmyText << 2;
			cmdyText += cmvyText;
			cmyText += cmdyText >> 4;
			cmdyText &= 15;
		}
	}
}
