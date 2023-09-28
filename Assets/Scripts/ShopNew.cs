using System;

public class ShopNew : MyScreen
{
	public static ShopNew me;

	public static string text = string.Empty;

	public short typeshop;

	public int x;

	public int y;

	public int w;

	public int h;

	public int selected;

	public int numW = 7;

	public int numH;

	public int xShow;

	public int yShow;

	public int wShow;

	public int hShow;

	public int wSmall;

	public int hSmall;

	public int x0;

	public int y0;

	public int idFrame;

	public int selectedGD;

	public int countFrame;

	public int[][] arrFrame = new int[2][]
	{
		new int[3]
		{
			0,
			1,
			2
		},
		new int[2]
		{
			0,
			1
		}
	};

	public static string[] infoMainCharServer;

	private string[] title = new string[33]
	{
		"Hành trang",
		"Trang bị",
		"Tiềm năng",
		"Kỹ năng",
		"Thông tin",
		"Nhiệm vụ",
		"Học kỹ năng",
		"Trao đổi",
		"Nhóm",
		"Gian hàng",
		"Gian hàng",
		"Áo",
		"Quần",
		"Nón",
		"Nhẫn",
		"Dây chuyền",
		"Giày",
		"Găng tay",
		"Ngọc bội",
		"Gian hàng",
		"Gian hàng",
		"Luyện đồ",
		"Kho đồ",
		"Gian hàng",
		"Gian hàng",
		"Khảm",
		"Hợp thành",
		"Nhiệm vụ",
		"Chế đồ",
		"Kỹ năng bang hội",
		"Kỹ năng cá nhân",
		"Trang bị thú",
		"Hợp đồ thú"
	};

	private string[] tabName = new string[8]
	{
		"Áo",
		"Quần",
		"Nón",
		"Nhẫn",
		"D.chuyền",
		"Giày",
		"Găng tay",
		"Ngọc bội"
	};

	private string[] showText;

	public string name = string.Empty;

	public string firName = string.Empty;

	public mVector list = new mVector();

	public mVector newSkill;

	public mVector readyBuy = new mVector();

	public mVector ItemShopNew = new mVector();

	public bool isShowText;

	public bool isSell;

	public bool isChangeTab;

	public bool isPaintMoney;

	public bool isTextArr;

	private bool trans;

	private int pb;

	private int pa;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int cmtoYText;

	public static int cmyText;

	public static int cmdyText;

	public static int cmvyText;

	public static int cmyLimText;

	public static int cmtoX;

	public static int cmx;

	public static int cmdx;

	public static int cmvx;

	public static int cmxLim;

	public static int focusTab;

	private int focusTabChinh;

	private int cmtoXTab;

	private int cmxTab;

	private int cmdxTab;

	private int cmvxTab;

	private int cmxLimTab;

	public static int cmtoXName;

	public static int cmxname;

	public static int dir = 1;

	public static sbyte[] index;

	private mVector questInfo;

	public int idClass;

	public int countPop;

	public short idCharSell;

	public mVector sellItem = new mVector();

	public mVector listTemp = new mVector();

	public mVector listEp;

	public mVector listCheDo;

	public mVector listItemAnimal = new mVector();

	private ItemInInventory[] itemEpdothu = new ItemInInventory[5];

	private short[][] posEpNgoc;

	public static sbyte idMonsterClanQuest = -1;

	public static sbyte countR;

	public static sbyte countL;

	public static sbyte countBL;

	public static sbyte countBR;

	public static sbyte idColor;

	public static sbyte lvThu;

	public static sbyte slNLThu;

	public static sbyte magicAnimal;

	public static short numberQuestGet = 0;

	public static short numberQuestAll;

	public static short idTemp;

	public static Char charWearing;

	public sbyte[] arrayKhamNgoc;

	public sbyte[] arrSell;

	public static bool isKham = false;

	public bool isLoad;

	public bool isSelectCheDo;

	public bool isPaintfc;

	public static bool isWindowInfo;

	private int limMyBag;

	private int excess;

	private int maxSize;

	private int countTabMyitem;

	public static sbyte khoaCheDo;

	public static sbyte khoaDoThu;

	public static sbyte khoaImbue;

	public static sbyte khoaKham;

	private int wCell = 32;

	private int hCell = 32;

	private sbyte idTrade;

	public static int saveFocusTab;

	public static int addY;

	private bool isLastScreenMenuWindow;

	public static int yTr;

	public static int xTr;

	private int wKhung;

	private int hKhung;

	public Command cmdShop;

	private bool is29;

	private int numCell;

	private int hView;

	private int xKhung;

	private int yKhung;

	private int addHclip;

	private int xCus = -20;

	public static sbyte optionCreateItem = 0;

	private Image imgCharWear;

	public int idSeller;

	public int shopIdSell;

	private bool isFcStore;

	public int prizeImbue;

	private int idImbue = -1;

	private int idfcsetSelectedImbue;

	private bool first;

	private string[] charInfo;

	private bool isCmyTab3;

	private bool isshowInfo;

	private bool isTab3;

	private int saveSelect = -1;

	private int countClick;

	private int cmyKeep;

	private int newZise = 42;

	private int smallS = 34;

	private bool checkPaint;

	private int tdx;

	private int transX;

	private int dirX = 1;

	public static string nameshop = string.Empty;

	private bool isDefault;

	private string[] mau = new string[4]
	{
		"Trắng",
		"Hoàn mỹ",
		"Đỏ",
		"Xanh"
	};

	public bool isNguyenLieu;

	private int wSkill = 30;

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
		51 + yTr,
		135 + yTr,
		91 + yTr,
		11 + yTr,
		11 + yTr,
		11 + yTr,
		11 + yTr,
		11 + yTr,
		96 + yTr,
		51 + yTr,
		175 + yTr,
		175 + yTr,
		11 + yTr,
		175 + yTr,
		51 + yTr,
		91 + yTr,
		135 + yTr,
		175 + yTr,
		11 + yTr,
		92 + yTr
	};

	private int www = 180;

	public mVector potionShop = new mVector();

	public Image imgWeaponAvatar;

	private static sbyte[] idWearChar = new sbyte[10]
	{
		12,
		-1,
		0,
		9,
		2,
		8,
		1,
		8,
		10,
		11
	};

	private static sbyte[] idWearAnimal = new sbyte[10]
	{
		18,
		19,
		14,
		20,
		15,
		21,
		16,
		22,
		17,
		23
	};

	private static sbyte[][] posWearChar = new sbyte[10][]
	{
		new sbyte[2]
		{
			10,
			11
		},
		new sbyte[2]
		{
			56,
			11
		},
		new sbyte[2]
		{
			10,
			32
		},
		new sbyte[2]
		{
			56,
			32
		},
		new sbyte[2]
		{
			10,
			52
		},
		new sbyte[2]
		{
			56,
			52
		},
		new sbyte[2]
		{
			10,
			73
		},
		new sbyte[2]
		{
			56,
			94
		},
		new sbyte[2]
		{
			10,
			94
		},
		new sbyte[2]
		{
			56,
			94
		}
	};

	public static short MAX_POTION = 999;

	public bool transY;

	public bool transXB;

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

	private int countPutKey;

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

	public ShopNew()
	{
		init();
		Command command = new Command("Đóng");
		ActionPerform actionPerform = command.action = delegate
		{
			if (isShowText)
			{
				closeText();
			}
			else
			{
				listTemp.removeAllElements();
				listEp = null;
				focusTab = saveFocusTab;
				doBuyItem();
				Canvas.gameScr.switchToMe();
				list.removeAllElements();
				charInfo = null;
				questInfo = null;
				imgCharWear = null;
				charWearing = null;
				transX = 0;
				dirX = 1;
				focusTabChinh = 0;
				focusTab = 0;
				isSell = false;
			}
		};
		right = command;
		focusTabChinh = 0;
		selected = 0;
		focusTab = 0;
		transX = 0;
		dirX = 1;
	}

	public static ShopNew gI()
	{
		return (me != null) ? me : (me = new ShopNew());
	}

	public override void switchToMe()
	{
		isLastScreenMenuWindow = false;
		if (Canvas.currentScreen == MenuWindows.gI())
		{
			isLastScreenMenuWindow = true;
		}
		else
		{
			isLastScreenMenuWindow = false;
		}
		base.switchToMe();
		init();
		isChangeTab = true;
		isSelectCheDo = false;
		isPaintfc = true;
	}

	public override void init()
	{
		isPaintFc = false;
		x = Canvas.hw - 64;
		y = Canvas.hh - 77;
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
		setLim();
		isWindowInfo = true;
		selected = 0;
		selectedGD = -1;
		xKhung = 10;
		yKhung = 20;
		cmtoX = (cmx = (cmxLimTab = (cmtoXTab = (cmxTab = 0))));
		cmxLimTab = tabName.Length * 70 - wKhung + 10;
		if (cmxLimTab < 0)
		{
			cmxLimTab = 0;
		}
		idTrade = 0;
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
			51 + yTr,
			135 + yTr,
			91 + yTr,
			11 + yTr,
			11 + yTr,
			11 + yTr,
			11 + yTr,
			11 + yTr,
			96 + yTr,
			51 + yTr,
			175 + yTr,
			175 + yTr,
			11 + yTr,
			175 + yTr,
			51 + yTr,
			91 + yTr,
			135 + yTr,
			175 + yTr,
			11 + yTr,
			180 + yTr
		};
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
		setLim();
		isChangeTab = true;
		setCmdCenter();
	}

	public static int getIndex()
	{
		return index[focusTab];
	}

	private void setLim()
	{
		if (!is29)
		{
			int num = newZise;
			cmxLim = numW * wSmall - w;
			if (index != null)
			{
				if (index[focusTab] == 21 || index[focusTab] == 25)
				{
					if (ItemShopNew != null && listTemp != null)
					{
						int num2 = ItemShopNew.size() + listTemp.size();
						cmxLim = num2 * newZise - w + 50;
						Out.println(num2 + " cmxlim  " + cmxLim);
					}
				}
				else if (index[focusTab] == 28)
				{
					cmx = (cmtoX = 0);
					int num3 = listTemp.size();
					cmxLim = num3 * newZise - 5 * newZise;
				}
				else if (index[focusTab] == 8)
				{
					int num4 = ItemShopNew.size() + MainChar.listPotion.Length - 2;
					cmxLim = num4 * smallS - (wKhung - 7 * newZise);
				}
				if (index[focusTab] == 22 || index[focusTab] == 23)
				{
					num = 34;
					h = hView - 50;
				}
			}
			cmyLim = numH * num - h;
			if (cmxLim < 0)
			{
				cmxLim = 0;
			}
			if (cmyLim < 0)
			{
				cmyLim = 0;
			}
		}
		else
		{
			cmxLim = numW * wSmall - w;
			cmyLim = numH * hSmall - h;
			if (cmxLim < 0)
			{
				cmxLim = 0;
			}
			if (cmyLim < 0)
			{
				cmyLim = 0;
			}
		}
	}

	public void setCurTab()
	{
		if (Canvas.currentScreen == gI() && focusTab == 0)
		{
			setSelectTab();
			isChangeTab = false;
		}
	}

	public void setInfo(int focus, bool isSell, sbyte[] inn)
	{
		this.isSell = isSell;
		if (isSell)
		{
			arrSell = inn;
		}
		if (isSell)
		{
			arrSell = inn;
		}
		index = inn;
		focusTab = 0;
		if (index != null)
		{
			if (index[focusTab] == 29)
			{
				is29 = true;
			}
			else
			{
				is29 = false;
			}
		}
		selected = 0;
		setCmdCenter();
		setSelectTab();
		numCell = ItemShopNew.size() + 1;
		if (numCell < 42)
		{
			numCell = 42;
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
		else if (index[focusTab] != 29)
		{
			cmx = (cmy = (cmtoX = (cmtoY = -10)));
		}
		else
		{
			cmx = (cmy = (cmtoX = (cmtoY = 0)));
		}
		if (isDefault)
		{
			cmx = (cmtoX = -10);
			cmy = (cmtoY = 0);
		}
	}

	public override void updateKey()
	{
		int num = 34;
		if (isShowText)
		{
			if (Canvas.keyHold[2])
			{
				if (hShow >= 100)
				{
					cmtoYText -= 10;
					if (cmtoYText < 0)
					{
						cmtoYText = 0;
					}
				}
				else
				{
					closeText();
				}
				Canvas.keyPressed[2] = false;
			}
			else if (Canvas.keyHold[8])
			{
				if (hShow >= 100)
				{
					cmtoYText += 10;
					if (cmtoYText > cmyLimText)
					{
						cmtoYText = cmyLimText;
					}
				}
				else
				{
					closeText();
				}
				Canvas.keyPressed[8] = false;
			}
			Canvas.isKeyPressed(2);
			Canvas.isKeyPressed(8);
			if (Canvas.currentDialog == null && isShowText)
			{
				xBegint = xShow;
				yBegint = y0;
				wToucht = wKhung - (x0 + 5 * (wCell + 12)) - 1;
				int num2 = Canvas.h;
				if (num2 > 320)
				{
					num2 = 320;
				}
				hToucht = num2 - 60;
			}
		}
		if (Canvas.isPointerClick && index[focusTab] == 0)
		{
			int num3 = Canvas.h;
			if (num3 > 320)
			{
				num3 = 320;
			}
			if (Canvas.isPointer(x0 - 5 + xTr, num3 - 70 + yTr, 50, 50))
			{
				if (Canvas.isPointerClick)
				{
					Canvas.isPointerClick = false;
					setSize(5 * wCell, 112, 7, 9, num, num);
					selected = 0;
					closeText();
				}
			}
			else if (Canvas.isPointer(x0 + 6 * wCell + xTr, num3 - 70 + yTr, 50, 50) && Canvas.isPointerClick)
			{
				Canvas.isPointerClick = false;
				setSize(5 * wCell, 112, 7, 9, num, num);
				selected = 0;
				closeText();
			}
		}
		if (isChangeTab && !Main.isPC)
		{
			if (Canvas.isKeyPressed(8))
			{
				isChangeTab = false;
				setCmdCenter();
				Canvas.keyHold[8] = false;
			}
			else if (Canvas.isKeyPressed(4))
			{
				if (index.Length > 1)
				{
					countL = 5;
					cmxname = 100;
					dir = 1;
				}
				setSelectTab();
				setCmdCenter();
			}
			else if (Canvas.isKeyPressed(6))
			{
				if (index.Length > 1)
				{
					countR = 5;
					dir = -1;
					cmxname = -100;
				}
				setSelectTab();
				setCmdCenter();
			}
		}
		else if (index[focusTab] != 26 && cmy == 0 && numW != 0 && selected / numW == 0 && Canvas.isKeyPressed(2) && index[focusTab] != 32)
		{
			isChangeTab = true;
			center = null;
		}
		updateKeyMain();
		if (left == null)
		{
			Out.println("null me no roi ");
		}
		base.updateKey();
	}

	public void getItemAnimalFromList()
	{
		listItemAnimal = new mVector();
		for (int i = 0; i < ItemShopNew.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(i);
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if ((item.type == 14 || item.type == 15 || item.type == 16 || item.type == 17 || item.type == 18) && itemInInventory.colorName == idColor)
			{
				listItemAnimal.addElement(itemInInventory);
			}
		}
	}

	public void setSelectTab()
	{
		Out.LogWarning(" WINDOWINFO TAI INDEX THU :  " + index[focusTab]);
		if (index[focusTab] != 0)
		{
			saveFocusTab = focusTab;
		}
		cmxname = 0;
		left = null;
		isPaintMoney = false;
		newSkill = null;
		posEpNgoc = null;
		list.removeAllElements();
		x0 = 1;
		y0 = 35;
		addHclip = -2;
		if (index.Length > 1)
		{
			firName = name;
			name = title[index[focusTab]];
		}
		int num = 34;
		countTabMyitem = 0;
		hView = hKhung - y0 + 20;
		switch (index[focusTab])
		{
		case 0:
		{
			isDefault = true;
			isPaintMoney = true;
			setInfo(getInventori());
			int hBig = 5 * wCell;
			if (isDefault)
			{
				hBig = 4 * wCell;
			}
			setSize(5 * wCell, hBig, 7, 7, num, num);
			hView = hKhung - y0 + 20;
			addHclip = -33;
			break;
		}
		case 1:
			xKhung = 10;
			yKhung = 20;
			x0 = xKhung + 15;
			y0 = yKhung + MainJ2ME.hTab;
			setSize(117, 104, 3, 5, 97, 21);
			break;
		case 4:
			center = null;
			isPaintMoney = true;
			x0 += -4;
			y0 += -2;
			setSize(134, 120, 1, 10, 50, 12);
			break;
		case 6:
			questInfo.removeAllElements();
			break;
		case 7:
			x0 += 5;
			y0 += 7;
			left = null;
			setCmdCenter();
			break;
		case 8:
		{
			ActionPerform action4 = delegate
			{
				doSelectedTrade(idTrade);
			};
			center = new Command();
			center.action = action4;
			setCmdLeftTrade();
			break;
		}
		case sbyte.MaxValue:
			isPaintMoney = true;
			setSize(126, 90, 1, 1, 18, 18);
			setListSellItem(Canvas.gameScr.shop, -1);
			setInfo(list);
			doSetLeftPetEat(-1);
			break;
		case 9:
		{
			isPaintMoney = true;
			int num3 = 34;
			setSize(7 * wCell, 4 * wCell, 1, 7, num3, num3);
			setListSellItem(Canvas.gameScr.shop, -1);
			setInfo(list);
			doSetLeftSellWeapon(-1);
			break;
		}
		case 10:
		{
			isPaintMoney = true;
			int num2 = 34;
			setSize(7 * wCell, 4 * wCell, 1, 1, num2, num2);
			setListSellGemItem(Canvas.gameScr.shop);
			setInfo(list);
			dosetLeftSellGemItem();
			break;
		}
		case 11:
		case 12:
		case 13:
		{
			isPaintMoney = true;
			int num12 = 34;
			setSize(7 * wCell, 4 * wCell, 1, 1, num12, num12);
			setListSellItem(Canvas.gameScr.shop, index[focusTab] - 11);
			setInfo(list);
			doSetLeftSellWeapon(index[focusTab] - 11);
			break;
		}
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		{
			isPaintMoney = true;
			int num11 = 34;
			setSize(7 * wCell, 4 * wCell, 1, 1, num11, num11);
			setListSellItem(Canvas.gameScr.shop, index[focusTab] - 6);
			setInfo(list);
			doSetLeftSellWeapon(index[focusTab] - 6);
			break;
		}
		case 19:
		{
			isPaintMoney = true;
			int num10 = 34;
			setSize(7 * wCell, 4 * wCell, 1, 1, num10, num10);
			setListPotion();
			setInfo(list);
			doSetLeftPotion();
			break;
		}
		case 20:
			isPaintMoney = true;
			setSize(126, 112, 1, 1, 18, 18);
			getShopTemplate();
			setInfo(list);
			doBuyShopSpecial();
			name = name + " " + (focusTab + 1);
			break;
		case 21:
			x0++;
			y0 += -6;
			setInfo(list);
			setSize(144, 110, 3, 5, 24, 24);
			setCmdCenter();
			doLeftImbue();
			break;
		case 22:
		{
			isPaintMoney = true;
			selected = 0;
			setSizeKeepItem(0);
			int num9 = 34;
			setSize(7 * wCell, 4 * wCell, 6, numH, num9, num9);
			setCmdCenter();
			setLeftKeepAndSellItem();
			break;
		}
		case 23:
		{
			isPaintMoney = true;
			selected = 0;
			setSizeKeepItem(0);
			int num8 = 34;
			setSize(7 * wCell, 4 * wCell, 6, numH, num8, num8);
			setCmdCenter();
			setLeftKeepAndSellItem();
			break;
		}
		case 24:
		{
			isPaintMoney = true;
			int num7 = 34;
			setSize(7 * wCell, 4 * wCell, 1, 1, num7, num7);
			setInfo(getListBuyItem());
			setLeftBuyItem();
			break;
		}
		case 25:
		{
			isChangeTab = false;
			x0++;
			y0 += -4;
			setInfo(list);
			setSize(144, 110, 3, 5, 24, 24);
			if (isKham)
			{
				setListImbue(isEp: false, 1, khoaKham);
			}
			else
			{
				name = "Đục lỗ";
				setListImbue(isEp: false, 2, khoaKham);
			}
			ActionPerform action7 = delegate
			{
				setSelectedImbue();
			};
			center = new Command(string.Empty);
			center.action = action7;
			doLeftImbue();
			break;
		}
		case 26:
		{
			x0++;
			y0 += -4;
			setSize(126, 108, 5, 1, 20, 18);
			posEpNgoc = new short[5][]
			{
				new short[2]
				{
					0,
					-10
				},
				new short[2]
				{
					(short)(5 * wCell),
					-10
				},
				new short[2]
				{
					(short)(2 * wCell + wCell / 2),
					(short)(2 * wCell - wCell / 2)
				},
				new short[2]
				{
					0,
					(short)(4 * wCell - 10)
				},
				new short[2]
				{
					(short)(5 * wCell),
					(short)(4 * wCell - 10)
				}
			};
			setListImbue(isEp: true, 1, 0);
			listEp = new mVector();
			ActionPerform action6 = delegate
			{
				doSelectedEpNgoc();
			};
			center = new Command();
			center.action = action6;
			doLeftEpNgoc();
			break;
		}
		case 27:
		{
			x0 += -4;
			y0 += -2;
			if (questInfo == null)
			{
				questInfo = new mVector();
			}
			setSize(134, 95, 1, questInfo.size(), 130, 15);
			ActionPerform action5 = delegate
			{
				GameService.gI().questClan(2);
				right.perform();
			};
			left = new Command("Hủy");
			left.action = action5;
			break;
		}
		case 28:
		{
			int num5 = listEp.size() / 2;
			if (num5 < 6)
			{
				num5 = 6;
			}
			int num6 = 34;
			setSize(7 * wCell, 4 * wCell, num5, 3, num6, num6);
			setLimitCheDo();
			ActionPerform action2 = delegate
			{
				doSelectedCheDo();
			};
			center = new Command("Chọn");
			center.action = action2;
			ActionPerform action3 = delegate
			{
				doLeftCheDo();
			};
			left = new Command("Xong");
			left.action = action3;
			break;
		}
		case 29:
			try
			{
				setInfo(setListGuildSkill());
				setSize(126, 100, 1, 6, 126, 20);
				int num4 = 0;
				for (int j = 0; j < Canvas.gameScr.skillClan.Length; j++)
				{
					if (Canvas.gameScr.skillClan[j].time > 0)
					{
						num4++;
					}
				}
				for (int k = 0; k < Canvas.gameScr.skillClanPrivate.Length; k++)
				{
					if (Canvas.gameScr.skillClanPrivate[k].time > 0)
					{
						num4++;
					}
				}
				if (num4 < 5)
				{
					num4 = 5;
				}
				isChangeTab = true;
			}
			catch (Exception)
			{
				Out.println("Loi goi skill ban hoi");
			}
			break;
		case 30:
			setInfo(setListGuildSkill());
			setSize(126, 100, 1, 6, 126, 20);
			isChangeTab = true;
			break;
		case 31:
			xKhung = 10;
			yKhung = 20;
			x0 = xKhung + 15;
			y0 = yKhung + MainJ2ME.hTab;
			setSize(117, 104, 3, 5, 97, 21);
			break;
		case 32:
		{
			x0++;
			y0 += -4;
			setSize(126, 108, 5, 1, 20, 18);
			posEpNgoc = new short[5][]
			{
				new short[2]
				{
					0,
					-10
				},
				new short[2]
				{
					(short)(5 * wCell),
					-10
				},
				new short[2]
				{
					(short)(2 * wCell + wCell / 2),
					(short)(2 * wCell - wCell / 2 - 10)
				},
				new short[2]
				{
					0,
					(short)(4 * wCell - 30)
				},
				new short[2]
				{
					(short)(5 * wCell),
					(short)(4 * wCell - 30)
				}
			};
			for (int i = 0; i < itemEpdothu.Length; i++)
			{
				itemEpdothu[i] = null;
			}
			getItemAnimalFromList();
			ActionPerform action = delegate
			{
				if (numW != 0)
				{
					int num13 = listItemAnimal.size() + listTemp.size() - 1;
					if (selected % numW >= 0 && selected % numW < num13)
					{
						doSelectedEpDothu();
					}
				}
			};
			listEp = new mVector();
			center = new Command();
			center.action = action;
			doLeftEpDothu();
			break;
		}
		}
		if (selected >= numH * numW - 1)
		{
			selected = 0;
		}
	}

	private mVector setListGuildSkill()
	{
		mVector mVector = new mVector();
		int aa = 0;
		try
		{
			for (int i = 0; i < Canvas.gameScr.skillClan.Length; i++)
			{
				int ii = i;
				if (Canvas.gameScr.skillClan[i].time > 0)
				{
					int ind = aa;
					Command command = new Command();
					ActionPerform action = delegate
					{
					};
					ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
					{
						GameData.paintIcon(g, (short)(ii + 1600), x - wSmall / 2 + 9, y);
						int num2 = 0;
						if (ind == selected && !isChangeTab)
						{
							int width2 = MFont.arialFont.getWidth(Canvas.gameScr.skillClan[ii].info);
							if (width2 > w - (wSmall / 2 + 16))
							{
								xCus += 2;
								if (xCus > width2 - (wSmall / 2 + 30))
								{
									xCus = -20;
								}
							}
							num2 = xCus;
							if (xCus < 0)
							{
								num2 = 0;
							}
						}
						MFont.normalFont[0].drawString(g, Canvas.gameScr.skillClan[ii].info, x - wSmall / 2 + 18 - aa, y - MFont.arialFont.getHeight() / 2, 0);
					};
					command.action = action;
					command.actionPaint = actionPaint;
					mVector.addElement(command);
					aa++;
				}
			}
			for (int j = 0; j < Canvas.gameScr.skillClanPrivate.Length; j++)
			{
				int ii2 = j;
				if (Canvas.gameScr.skillClanPrivate[j].time > 0)
				{
					int ind2 = aa;
					Command command2 = new Command();
					ActionPerform action2 = delegate
					{
					};
					ActionPaintCmd actionPaint2 = delegate(MyGraphics g, int x, int y)
					{
						GameData.paintIcon(g, (short)(ii2 + 1600), x - wSmall / 2 + 9, y);
						int num = 0;
						if (ind2 == selected && !isChangeTab)
						{
							int width = MFont.arialFont.getWidth(Canvas.gameScr.skillClan[ii2].info);
							if (width > w - (wSmall / 2 + 16))
							{
								xCus += 2;
								if (xCus > width - (wSmall / 2 + 30))
								{
									xCus = -20;
								}
							}
							num = xCus;
							if (xCus < 0)
							{
								num = 0;
							}
						}
						MFont.normalFont[0].drawString(g, Canvas.gameScr.skillClanPrivate[ii2].info, x - wSmall / 2 + 18 + aa, y - MFont.arialFont.getHeight() / 2, 0);
					};
					command2.action = action2;
					command2.actionPaint = actionPaint2;
					mVector.addElement(command2);
					aa++;
				}
			}
			return mVector;
		}
		catch (Exception)
		{
			Out.println("null skill bang hoi setListGuildSkill");
			return mVector;
		}
	}

	protected void doLeftCheDo()
	{
		if (listEp.size() == 0)
		{
			return;
		}
		sbyte[][] array = new sbyte[listCheDo.size()][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new sbyte[6];
		}
		for (int j = 0; j < listEp.size(); j++)
		{
			GemTemplate gemTemplate = (GemTemplate)listEp.elementAt(j);
			for (int k = 0; k < listCheDo.size(); k++)
			{
				Mineral mineral = (Mineral)listCheDo.elementAt(k);
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
			for (int num2 = listEp.size() - 1; num2 >= 0; num2--)
			{
				GemTemplate g = (GemTemplate)listEp.elementAt(num2);
				removeItemCheDo(g);
			}
			GameService.gI().doCheDo((short)listCheDo.size(), idTemp, ar);
			right.perform();
			Canvas.startWaitDlg();
		};
		Canvas.startYesNoDlg("Bạn có muốn hoàn thành không ?", yesAction);
	}

	private void removeItemCheDo(GemTemplate g)
	{
		g.number--;
		if (g.number <= 0)
		{
			listEp.removeElement(g);
		}
		bool flag = false;
		for (int i = 0; i < listTemp.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
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
			listTemp.addElement(g);
		}
	}

	protected void doSelectedCheDo()
	{
		try
		{
			GemTemplate gemTemplate = null;
			if (isSelectCheDo)
			{
				if (selected < listEp.size())
				{
					gemTemplate = (GemTemplate)listEp.elementAt(selected);
				}
			}
			else if (selected < listTemp.size())
			{
				gemTemplate = (GemTemplate)listTemp.elementAt(selected);
			}
			if (gemTemplate != null)
			{
				GemTemplate g = gemTemplate;
				int xx = selected * newZise + cmx;
				int yy = selected * newZise;
				short idTem = gemTemplate.id;
				mVector mVector = new mVector();
				Command command = new Command(isSelectCheDo ? "Lấy ra" : "Bỏ vào");
				ActionPerform actionPerform = command.action = delegate
				{
					if (isSelectCheDo)
					{
						removeItemCheDo(g);
					}
					else
					{
						int num = 0;
						for (int i = 0; i < listCheDo.size(); i++)
						{
							Mineral mineral = (Mineral)listCheDo.elementAt(i);
							if (g.id - mineral.idTemplate >= 0 && g.id - mineral.idTemplate <= 5)
							{
								for (int j = 0; j < listEp.size(); j++)
								{
									GemTemplate gemTemplate2 = (GemTemplate)listEp.elementAt(j);
									if (gemTemplate2.id - mineral.idTemplate >= 0 && gemTemplate2.id - mineral.idTemplate <= 5)
									{
										num += gemTemplate2.number;
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
						for (int k = 0; k < listEp.size(); k++)
						{
							GemTemplate gemTemplate3 = (GemTemplate)listEp.elementAt(k);
							if (gemTemplate3.id == g.id)
							{
								gemTemplate3.number++;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							GemTemplate gemTemplate4 = new GemTemplate(g.id);
							GemTemplate.copyData(g, gemTemplate4);
							gemTemplate4.number = 1;
							listEp.addElement(gemTemplate4);
						}
						g.number--;
						if (g.number <= 0)
						{
							listTemp.removeElement(g);
						}
					}
					setLimitCheDo();
				};
				mVector.addElement(command);
				Command command2 = new Command("Thông tin");
				ActionPerform actionPerform2 = command2.action = delegate
				{
					if (khoaCheDo == 0 || khoaCheDo == 2)
					{
						showGemItemInfo(idTem, xx, yy);
					}
					else
					{
						showGemItemKhoaInfo(idTem, xx, yy);
					}
				};
				command2.perform();
				Canvas.menu.startAt(mVector, 2);
			}
		}
		catch (Exception)
		{
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

	private void doSelectedEpNgoc()
	{
		try
		{
			mVector mVector = new mVector();
			if (numH != 1)
			{
				if (selected % numW < listTemp.size())
				{
					GemTemplate item = (GemTemplate)listTemp.elementAt(selected % numW);
					Command command = new Command("Bỏ vào");
					ActionPerform actionPerform = command.action = delegate
					{
						if (listEp.size() < 5)
						{
							item.number--;
							if (item.number <= 0)
							{
								listTemp.removeElement(item);
							}
							RealID o = new RealID(item.rID)
							{
								ID = item.id
							};
							listEp.addElement(o);
						}
					};
					mVector.addElement(command);
					mVector.addElement(addGemInfo(item, selected % numW * 20 + 4, 86));
				}
			}
			else if (selected < listEp.size())
			{
				Command command2 = new Command("Lấy ra");
				ActionPerform actionPerform2 = command2.action = delegate
				{
					RealID realID = null;
					GemTemplate gemTemplate = null;
					for (int i = 0; i < listEp.size(); i++)
					{
						realID = (RealID)listEp.elementAt(i);
						gemTemplate = GemTemplate.getGemByID(realID.ID);
						gemTemplate.number++;
						realID = null;
					}
					listEp.removeAllElements();
				};
				mVector.addElement(command2);
			}
			Canvas.menu.startAt(mVector, 2);
		}
		catch (Exception)
		{
		}
	}

	private Command addGemInfo(GemTemplate item, int xx, int yy)
	{
		Command command = new Command("Thông tin");
		ActionPerform actionPerform = command.action = delegate
		{
			if (khoaDoThu == 0 || khoaDoThu == 2)
			{
				showGemItemInfo(item.id, 145, -10);
			}
			else
			{
				showGemItemKhoaInfo(item.id, 145, -10);
			}
		};
		return command;
	}

	private void doLeftEpNgoc()
	{
		ActionPerform action = delegate
		{
			if (listEp.size() < 3)
			{
				Canvas.startOKDlg("Bạn phải ép ít nhất 3 vật phẩm.");
			}
			else
			{
				ActionPerform yesAction = delegate
				{
					GameService.gI().epNgoc(1, listEp);
					Canvas.startWaitDlg("Đang hợp..", isIcon: false);
					listEp.removeAllElements();
				};
				Canvas.startYesNoDlg("Bạn phải mất " + Canvas.getMoneys(prizeImbue) + "Xu để hợp.", yesAction);
			}
		};
		left = new Command("Hợp");
		left.action = action;
	}

	public void setLeftBuyItem()
	{
		ActionPerform action = delegate
		{
			if (selected < sellItem.size())
			{
				ActionPerform yesAction = delegate
				{
					if (sellItem.elementAt(selected) is ItemInInventory)
					{
						ItemInInventory itemInInventory = (ItemInInventory)sellItem.elementAt(selected);
						GameService.gI().requestBuyItemUser(idCharSell, idSeller, shopIdSell, itemInInventory.itemID, 0);
					}
					else
					{
						RealID realID = (RealID)sellItem.elementAt(selected);
						GameService.gI().requestBuyItemUser(idCharSell, idSeller, shopIdSell, realID.realID, 1);
					}
					Canvas.startWaitDlg();
				};
				Canvas.startYesNoDlg("Bạn có muốn mua không ?", yesAction);
			}
		};
		left = new Command("Mua");
		left.action = action;
	}

	public mVector getListBuyItem()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < sellItem.size(); i++)
		{
			int ii = i;
			Command command = new Command();
			ActionPerform action = delegate
			{
				if (sellItem.elementAt(ii) is ItemInInventory)
				{
					if (isDefault)
					{
						setShowTextNew(((ItemInInventory)sellItem.elementAt(ii)).getInfoItemUserSell(), ii % numW * wSmall, ii / numW * wSmall);
					}
					else if ((ItemInInventory)sellItem.elementAt(ii) != null)
					{
						setShowText(((ItemInInventory)sellItem.elementAt(ii)).getInfoItemUserSell(), ii % numW * wSmall, ii / numW * wSmall);
					}
				}
				else
				{
					showRealIDInfo((RealID)sellItem.elementAt(ii), ii % numW * wSmall, ii / numW * wSmall);
				}
			};
			ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
			{
				if (sellItem.elementAt(ii) is ItemInInventory)
				{
					ItemInInventory itemInInventory = (ItemInInventory)sellItem.elementAt(ii);
					if (itemInInventory.isSelling)
					{
						g.setColor(7706352);
						g.fillRect(x - 7, y - 7, 14, 14);
					}
					itemInInventory.paint(g, x, y);
				}
				else
				{
					Res.paintGem(g, Res.getGemByID(((RealID)sellItem.elementAt(ii)).ID).idImage, x, y);
				}
			};
			command.action = action;
			command.actionPaint = actionPaint;
			mVector.addElement(command);
		}
		return mVector;
	}

	private void setLeftKeepAndSellItem()
	{
		ActionPerform action = delegate
		{
			int num = selected / numW * 3 + selected % numW;
			ItemInInventory item = null;
			if (selected % numW < 3)
			{
				if (num < ItemShopNew.size())
				{
					item = (ItemInInventory)ItemShopNew.elementAt(num);
					if (index[focusTab] == 22)
					{
						Canvas.gameScr.gameService.putItem2Bag(item.itemID);
					}
					else if (index[focusTab] == 23)
					{
						if (item.isSelling)
						{
							Canvas.startOKDlg("Vật phẩm đang được bán.");
						}
						else
						{
							setLeftSellItem(item, -1);
						}
					}
				}
				else if (num < ItemShopNew.size() + MainChar.gemItem.size() && index[focusTab] == 23)
				{
					GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(num - ItemShopNew.size());
					setLeftSellItem(item, gemTemplate.rID);
				}
			}
			else
			{
				closeText();
				if (index[focusTab] == 22 && num - 3 < Char.itembag.size())
				{
					item = (ItemInInventory)Char.itembag.elementAt(num - 3);
					Canvas.gameScr.gameService.getItemFromBag(item.itemID);
				}
				else if (index[focusTab] == 23 && num - 3 < sellItem.size())
				{
					RealID realID = null;
					if (sellItem.elementAt(num - 3) is ItemInInventory)
					{
						item = (ItemInInventory)sellItem.elementAt(num - 3);
					}
					else
					{
						realID = (RealID)sellItem.elementAt(num - 3);
					}
					doRequestSellItem(item, realID?.realID ?? (-1), 0, sell: false);
				}
			}
		};
		left = new Command((index[focusTab] != 22) ? "Chọn" : "Chuyển");
		left.action = action;
	}

	protected void setLeftSellItem(ItemInInventory item, short gem)
	{
		closeText();
		ActionPerform ok = delegate
		{
			try
			{
				string text = Canvas.inputDlg.tfInput.getText();
				if (!text.Equals(string.Empty))
				{
					int num = int.Parse(text);
					if (num >= 0)
					{
						doRequestSellItem(item, gem, num, sell: true);
					}
				}
			}
			catch (Exception)
			{
				Canvas.startOKDlg("Vui lòng chỉ nhập số.");
			}
		};
		Canvas.inputDlg.setInfo("Nhập giá muốn bán: ", ok, TField.INPUT_TYPE_NUMERIC, 10, isMaxW: true);
		Canvas.inputDlg.show();
	}

	public void doRequestSellItem(ItemInInventory item, short gem, int prize, bool sell)
	{
		GameService.gI().requestSellItem(idSeller, shopIdSell, item, gem, prize, sell);
		Canvas.startWaitDlg();
	}

	private void setSelectedKeepAndSellItem()
	{
		ActionPerform action = delegate
		{
			isFcStore = false;
			int num = selected / numW * 3 + selected % numW;
			ItemInInventory itemInInventory = null;
			if (selected % numW < 3)
			{
				if (num < ItemShopNew.size())
				{
					itemInInventory = (ItemInInventory)ItemShopNew.elementAt(num);
					if (itemInInventory != null)
					{
						showItemInventoryInfo(itemInInventory, isSell, selected % numW * wSmall, selected / numW * hSmall - cmy);
						isFcStore = true;
					}
				}
				else if (num < ItemShopNew.size() + MainChar.gemItem.size())
				{
					GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(num - ItemShopNew.size());
					if (gemTemplate != null)
					{
						showGemItemInfo(gemTemplate.id, selected % numW * wSmall, selected / numW * hSmall - cmy);
						isFcStore = true;
					}
				}
			}
			else
			{
				mVector mVector = null;
				mVector = ((index[focusTab] != 22) ? sellItem : Char.itembag);
				if (num - 3 < mVector.size())
				{
					if (mVector.elementAt(num - 3) is ItemInInventory)
					{
						itemInInventory = (ItemInInventory)mVector.elementAt(num - 3);
						showItemInventoryInfo(itemInInventory, isSell, selected % numW * wSmall, selected / numW * hSmall - cmy);
					}
					else
					{
						showRealIDInfo((RealID)mVector.elementAt(num - 3), selected % numW * wSmall, selected / numW * hSmall - cmy);
					}
				}
			}
		};
		center = new Command();
		center.action = action;
	}

	public void setListImbue(bool isEp, int type, int khoa)
	{
		listTemp.removeAllElements();
		mVector mVector = (khoa != 0) ? MainChar.gemItemKhoa : MainChar.gemItem;
		for (int i = 0; i < mVector.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)mVector.elementAt(i);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			if (!isEp)
			{
				if (gemByID.type == type)
				{
					listTemp.addElement(gemTemplate);
				}
			}
			else if (gemByID.typeEp == type)
			{
				listTemp.addElement(gemTemplate);
			}
		}
		if (listTemp.size() == 0)
		{
			ActionPerform action = delegate
			{
				right.perform();
				Canvas.endDlg();
			};
			Canvas.startOKDlg("Không có nguyên liệu.", action);
		}
	}

	private void doLeftImbue()
	{
		ActionPerform action = delegate
		{
			if (Canvas.gameScr.mainChar.itemImbue != null)
			{
				if (Canvas.gameScr.mainChar.hadPutItemImbue())
				{
					ActionPerform yesAction = delegate
					{
						if (Canvas.gameScr.mainChar.charXu < prizeImbue)
						{
							Canvas.startOKDlg("Không đủ tiền");
						}
						else
						{
							Canvas.gameScr.mainChar.charXu -= prizeImbue;
							if (index[focusTab] == 21)
							{
								GameService.gI().doImbueItem(1);
							}
							else
							{
								GameService.gI().doKhamItem(1);
							}
							Canvas.startWaitDlg();
						}
					};
					ActionPerform noAction = delegate
					{
						Canvas.currentDialog = null;
					};
					Canvas.startYesNoDlg("Bạn phải mất " + prizeImbue + " xu để luyện.", yesAction, noAction);
				}
				else
				{
					Canvas.startOKDlg((index[focusTab] == 21) ? "Chưa đặt luyện kim dược." : "Chưa đặt ngọc");
				}
			}
		};
		left = new Command((index[focusTab] != 21) ? "Xong" : "Đập");
		left.action = action;
	}

	public void setSelectedImbue()
	{
		mVector mVector = new mVector();
		int index = selected / numW;
		int xx = selected % numW;
		int num = index * 2 + xx / 2;
		if ((index == 4 && (idImbue == -1 || xx >= ItemShopNew.size())) || (index != 4 && ((xx == 1 && idImbue != -1) || (xx != 1 && num < MainChar.gemitemImbue.size()))))
		{
			Command command = new Command((index == 4) ? "Bỏ vào" : "Lấy ra");
			ActionPerform actionPerform = command.action = delegate
			{
				if (index == 4)
				{
					if (xx < ItemShopNew.size())
					{
						ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(xx);
						if (itemInInventory.dayUse > 0)
						{
							Canvas.startOKDlg("Không được đập đồ thuê.");
							return;
						}
						if (Canvas.gameScr.mainChar.itemImbue == null && !itemInInventory.isSelling)
						{
							Canvas.gameScr.mainChar.itemImbue = itemInInventory;
							ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
							if (item.type < 3 || item.type > 7)
							{
								imgWeaponAvatar = GameData.getImgIcon(item.idIcon).img;
							}
							else if (item.type >= 3 && item.type < 8)
							{
								GameService.gI().doRequestWeapone(2, item.type, item.style, (sbyte)item.index);
								Canvas.startWaitDlg();
							}
						}
						idImbue = xx;
						GameService.gI().addItemImbue(itemInInventory.itemID);
					}
					else
					{
						try
						{
							if (MainChar.gemitemImbue.size() >= 8)
							{
								Canvas.startOKDlg("Không thể thêm");
								return;
							}
							int num2 = xx - ItemShopNew.size();
							GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(num2);
							RealID realID = new RealID(gemTemplate.rID)
							{
								ID = gemTemplate.id
							};
							bool flag = false;
							if (WindowInfoScr.index[focusTab] == 21 && MainChar.gemitemImbue.size() == 0 && (realID.ID <= 7 || realID.ID == 155 || realID.ID == 156))
							{
								flag = true;
							}
							if (!flag)
							{
								if (Canvas.gameScr.mainChar.countBaoHiem() >= 1 && gemTemplate.id < 5)
								{
									Canvas.startOKDlg("Chỉ có thể sử dụng 1 loại bảo hiểm cho 1 lần luyện.");
									return;
								}
								if (Canvas.gameScr.mainChar.countLKD() >= 1 && gemTemplate.id >= 8 && gemTemplate.id != 155 && gemTemplate.id != 156)
								{
									Canvas.startOKDlg("Không thể sử dụng 2 loại ngọc cho 1 lần luyện.");
									return;
								}
								MainChar.gemitemImbue.addElement(realID);
								gemTemplate.number--;
								if (gemTemplate.number == 0)
								{
									listTemp.removeElement(gemTemplate);
								}
								GameService.gI().addGemItemImbue(realID.realID, 0);
							}
							else
							{
								Canvas.startOKDlg("Phải đặt luyện kim dược trước.");
							}
						}
						catch (Exception)
						{
						}
					}
				}
				else if (xx == 1)
				{
					if (idImbue != -1)
					{
						ItemInInventory itemInInventory2 = (ItemInInventory)ItemShopNew.elementAt(idImbue);
						GameService.gI().addItemImbue(itemInInventory2.itemID);
						idImbue = -1;
						Canvas.gameScr.mainChar.itemImbue = null;
						imgWeaponAvatar = null;
					}
				}
				else
				{
					int num3 = index * 2 + xx / 2;
					if (num3 < MainChar.gemitemImbue.size())
					{
						RealID realID2 = (RealID)MainChar.gemitemImbue.elementAt(num3);
						MainChar.gemitemImbue.removeElement(realID2);
						int num4 = 0;
						for (int i = 0; i < listTemp.size(); i++)
						{
							GemTemplate gemTemplate2 = (GemTemplate)listTemp.elementAt(i);
							if (gemTemplate2.id == realID2.ID)
							{
								gemTemplate2.number++;
								num4 = 1;
								break;
							}
						}
						if (num4 == 0)
						{
							GemTemplate o = new GemTemplate(realID2.ID)
							{
								rID = realID2.realID
							};
							listTemp.addElement(o);
						}
						GameService.gI().addGemItemImbue(realID2.realID, 1);
					}
				}
				int num5 = selected % numW;
				int num6 = selected / numW;
				numW = ItemShopNew.size() + listTemp.size();
				if (numW < 6)
				{
					numW = 6;
				}
				if (num5 >= numW)
				{
					num5 = numW - 1;
				}
				selected = num6 * numW + num5;
				cmxLim = numW * wSmall - w + 6;
				if (cmxLim < 0)
				{
					cmxLim = 0;
				}
				if (cmx > cmxLim)
				{
					cmx = (cmtoX = cmxLim);
				}
			};
			mVector.addElement(command);
		}
		if (index == 4 || (xx != 1 && num < MainChar.gemitemImbue.size()) || (idImbue != -1 && xx == 1))
		{
			Command command2 = new Command("Thông tin");
			ActionPerform actionPerform2 = command2.action = delegate
			{
				doShowItemInfoImbue();
			};
			command2.perform();
		}
		Canvas.menu.startAt(mVector, 3);
		idfcsetSelectedImbue = xx;
	}

	public void doShowItemInfoImbue()
	{
		int num = selected / numW;
		int num2 = selected % numW;
		string empty = string.Empty;
		if (num == 4)
		{
			if (num2 < ItemShopNew.size())
			{
				ItemInInventory item = (ItemInInventory)ItemShopNew.elementAt(num2);
				showItemInventoryInfo(item, isSell, num2 * wSmall, 4 * wSmall);
				return;
			}
			for (int i = 0; i < listTemp.size(); i++)
			{
				if (i == num2 - ItemShopNew.size())
				{
					GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
					GemTemp gemByID = Res.getGemByID(gemTemplate.id);
					empty = ItemInInventory.setTemp(gemByID.name, "0");
					if ((khoaImbue == 1 && WindowInfoScr.index[focusTab] == 21) || (khoaKham == 1 && WindowInfoScr.index[focusTab] == 25))
					{
						empty += " - Đã khóa";
					}
					empty += ItemInInventory.setTemp(gemByID.decript, "0");
					setShowTextNew(empty, 145, -10);
				}
			}
		}
		else if (num2 == 1)
		{
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(idImbue);
			setShowTextNew(itemInInventory.getDescription(isSell), 145, -10);
		}
		else
		{
			int num3 = num * 2 + num2 / 2;
			RealID realID = (RealID)MainChar.gemitemImbue.elementAt(num3);
			GemTemp gemByID2 = Res.getGemByID(realID.ID);
			string str = ItemInInventory.setTemp(gemByID2.name, "0");
			if ((khoaImbue == 1 && WindowInfoScr.index[focusTab] == 21) || (khoaKham == 1 && WindowInfoScr.index[focusTab] == 25))
			{
				str += " - Đã khóa";
			}
			str += ItemInInventory.setTemp(gemByID2.decript, "0");
			setShowTextNew(str, 145, -10);
		}
	}

	public bool isBuffSkill()
	{
		sbyte[][] array = new sbyte[5][]
		{
			new sbyte[2]
			{
				4,
				5
			},
			new sbyte[2]
			{
				4,
				5
			},
			new sbyte[4]
			{
				4,
				5,
				6,
				7
			},
			new sbyte[2]
			{
				4,
				5
			},
			new sbyte[2]
			{
				4,
				5
			}
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
		mVector mVector = new mVector();
		bool flag = false;
		bool isBuff = isBuffSkill();
		if (isBuff)
		{
			flag = (SkillManager.SKILL_CAN_BUFF_TO_USER[Canvas.gameScr.mainChar.clazz][selected - 4] == -1);
		}
		if (isBuff && !flag)
		{
			Command command = new Command("Sử dụng");
			ActionPerform actionPerform = command.action = delegate
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
			mVector.addElement(command);
		}
		if (!flag)
		{
			Command command2 = new Command("Cho vào phím tắt");
			ActionPerform actionPerform2 = command2.action = delegate
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
			mVector.addElement(command2);
		}
		Command command3 = new Command("Cộng");
		ActionPerform actionPerform3 = command3.action = delegate
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
		mVector.addElement(command3);
		Canvas.menu.startAt(mVector, 2);
	}

	protected void doGiveSkillToQuickSlot(int skillType, bool isBuff)
	{
		mVector mVector = new mVector();
		for (int i = 0; i < 3; i++)
		{
			int ii = i;
			Command command = new Command("Phím số " + (1 + i * 2));
			ActionPerform actionPerform = command.action = delegate
			{
				MainChar.quickSlot[GameScr.indexTabSlot][ii].setIsSkill(skillType, Canvas.gameScr.mainChar.clazz, isBuff);
				RMS.saveQuickSlot();
			};
			mVector.addElement(command);
		}
		Canvas.menu.startAt(mVector, 2);
	}

	public void doCastBuffToActor(MainChar actor1, Actor actor2, int skillIdEff, bool buff2Friend)
	{
		if (actor1 != null && actor2 != null)
		{
			mVector mVector = new mVector();
			if (buff2Friend)
			{
				Command command = new Command("Cho mình");
				command.action = delegate
				{
					GameService.gI().useBuff(actor1.ID, 0, (sbyte)skillIdEff, 0);
				};
				Command command2 = new Command("Cho bạn");
				command2.action = delegate
				{
					GameService.gI().useBuff(actor2.ID, 0, (sbyte)skillIdEff, 0);
				};
				mVector.addElement(command);
				mVector.addElement(command2);
			}
			else
			{
				GameService.gI().useBuff(actor1.ID, 0, (sbyte)skillIdEff, 0);
			}
			Canvas.menu.startAt(mVector, 2);
		}
	}

	public void cmdCentertab2125()
	{
		Out.println("set cmd center   ..");
		switch (index[focusTab])
		{
		case 21:
		{
			center = null;
			center = new Command("Chọn");
			ActionPerform action3 = delegate
			{
				setSelectedImbue();
			};
			center.action = action3;
			break;
		}
		case 25:
		{
			center = new Command("Chọn");
			ActionPerform action2 = delegate
			{
				setSelectedImbue();
			};
			center.action = action2;
			break;
		}
		case 31:
		{
			center = new Command("Chọn");
			ActionPerform action = delegate
			{
				if (charWearing != null && (charWearing.useHorse != -1 || charWearing.idhorse > -1))
				{
					showInfoWearingAnimal();
				}
			};
			center.action = action;
			break;
		}
		}
	}

	public void setCmdCenter()
	{
		charInfo = null;
		if (index[focusTab] == 21 || index[focusTab] == 25 || index[focusTab] == 31)
		{
			cmdCentertab2125();
			return;
		}
		switch (index[focusTab])
		{
		case 8:
			break;
		case 26:
			break;
		case 27:
			break;
		case 29:
			break;
		case 30:
			break;
		case 32:
			break;
		case 1:
		{
			ActionPerform action10 = delegate
			{
				showCharWearingInfo();
			};
			center = new Command(string.Empty);
			center.action = action10;
			break;
		}
		case 2:
		{
			ActionPerform action8 = delegate
			{
				dofireBasePoint();
			};
			center = new Command(string.Empty);
			center.action = action8;
			ActionPerform action9 = delegate
			{
				dofireBasePoint();
			};
			left = new Command("Chọn");
			left.action = action9;
			break;
		}
		case 3:
		{
			cmyLim = (Canvas.gameScr.mainChar.getInfoSkill(selected).Length + 1) * 12 - 72;
			if (cmyLim < 0)
			{
				cmyLim = 0;
			}
			ActionPerform action5 = delegate
			{
				doSelectedSkill();
			};
			center = new Command(string.Empty);
			center.action = action5;
			ActionPerform action6 = delegate
			{
				doSelectedSkill();
			};
			left = new Command("Chọn");
			left.action = action6;
			break;
		}
		case 4:
			setTextCharInfo();
			break;
		case 5:
		{
			ActionPerform action3 = delegate
			{
				doSelectedParty();
			};
			center = new Command(string.Empty);
			center.action = action3;
			ActionPerform action4 = delegate
			{
				doSelectedParty();
			};
			left = new Command("Chọn");
			left.action = action4;
			break;
		}
		case 6:
		{
			ActionPerform action = delegate
			{
				doSelectedQuest();
			};
			center = new Command(string.Empty);
			center.action = action;
			ActionPerform action2 = delegate
			{
				doSelectedQuest();
			};
			left = new Command("Chọn");
			left.action = action2;
			break;
		}
		case 7:
		{
			newSkill = new mVector();
			mVector news = (mVector)GameScr.infoNewSkill.elementAt(Canvas.gameScr.mainChar.clazz);
			if (news == null)
			{
				break;
			}
			InfoSkillLearn infoSkillLearn = (InfoSkillLearn)news.elementAt(selected);
			if (infoSkillLearn != null)
			{
				sbyte b = Char.skillLevelLearnt[infoSkillLearn.idSkill];
				newSkill.addElement("`" + ((InfoSkillLearn)news.elementAt(selected)).name);
				if (b == -1)
				{
					newSkill.addElement("`Phí: " + ((InfoSkillLearn)news.elementAt(selected)).price + " xu");
				}
				string[] array = MFont.arialFont.splitFontBStrInLine(((InfoSkillLearn)news.elementAt(selected)).decript, 110);
				for (int i = 0; i < array.Length; i++)
				{
					newSkill.addElement(array[i]);
				}
				setSize(114, 30, news.size(), 2, 30, 20);
				cmyLim = newSkill.size() * 12 - 72;
				if (cmyLim < 0)
				{
					cmyLim = 0;
				}
				ActionPerform action7 = delegate
				{
					InfoSkillLearn infoSkillLearn2 = (InfoSkillLearn)news.elementAt(selected);
					ActionPerform yesAction = delegate
					{
						GameService.gI().learnSkill(Canvas.gameScr.mainChar.clazz, selected);
						Canvas.startWaitDlg();
					};
					Canvas.startYesNoDlg("Bạn muốn học kỹ năng " + infoSkillLearn2.name + " với giá " + infoSkillLearn2.price + "xu không? ", yesAction);
				};
				center = new Command(string.Empty);
				center.action = action7;
			}
			break;
		}
		case 22:
		case 23:
			setSelectedKeepAndSellItem();
			break;
		case 28:
			setLimitCheDo();
			break;
		default:
		{
			int num = selected + ((index[focusTab] == 0) ? (countTabMyitem * numCell) : 0);
			center = null;
			if (num < list.size())
			{
				center = (Command)list.elementAt(num);
			}
			break;
		}
		}
	}

	private void setLimitCheDo()
	{
		int num = selected % numW;
		if (selected / numW == 1)
		{
			int num2 = listEp.size() / 2;
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
			numW = listTemp.size();
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
		int num3 = listTemp.size();
		cmxLim = num3 * newZise - w;
		if (cmxLim <= 0)
		{
			cmxLim = 0;
		}
	}

	public void doViewInfoItemTradeup()
	{
		mVector mVector = new mVector();
		object obj = null;
		int num = selectedGD % 6;
		if (num <= 2)
		{
			int num2 = selectedGD / 6;
			int cc = num2 * 3 + num;
			mVector tItem = Canvas.gameScr.mainChar.tItems;
			if (cc < tItem.size())
			{
				object it2;
				obj = (it2 = tItem.elementAt(cc));
				Command command = new Command("Hủy");
				ActionPerform actionPerform = command.action = delegate
				{
					if (tItem.elementAt(cc) is ItemInInventory)
					{
						Canvas.gameScr.gameService.sendAddItemTrade(((ItemInInventory)it2).itemID, 0, 0);
					}
					else
					{
						Canvas.gameScr.gameService.sendAddItemTrade(((Potion)it2).id, 2, 0);
					}
				};
				mVector.addElement(command);
			}
		}
		else
		{
			int num3 = selectedGD / 6;
			int num4 = num3 * 3 + (num - 3);
			if (num4 < Canvas.gameScr.mainChar.rItems.size())
			{
				obj = Canvas.gameScr.mainChar.rItems.elementAt(num4);
			}
		}
		if (obj != null)
		{
			int x = num * 22;
			int y = selectedGD / 6 * 22;
			object it = obj;
			Command command2 = new Command("Thông tin");
			ActionPerform actionPerform2 = command2.action = delegate
			{
				if (it is ItemInInventory)
				{
					showItemInventoryInfo((ItemInInventory)it, isSell, x, y);
				}
				else
				{
					int num5 = 0;
					int num6 = 0;
					while (true)
					{
						if (num6 >= MainChar.listPotion.Length)
						{
							return;
						}
						if (MainChar.listPotion[num6].index == ((Potion)it).index)
						{
							break;
						}
						num6++;
					}
					setShowTextNew(getPotionInfo(num5), x, y);
					num5++;
				}
			};
			command2.perform();
		}
		Canvas.menu.startAt(mVector, 3);
	}

	public void doAdditemTrade()
	{
		mVector mVector = new mVector();
		if (selected < ItemShopNew.size())
		{
			bool flag = false;
			ItemInInventory item = (ItemInInventory)ItemShopNew.elementAt(selected);
			mVector tItems = Canvas.gameScr.mainChar.tItems;
			for (int i = 0; i < tItems.size(); i++)
			{
				if (tItems.elementAt(i) is ItemInInventory)
				{
					ItemInInventory itemInInventory = (ItemInInventory)tItems.elementAt(i);
					if (itemInInventory.itemID == item.itemID)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				Command command = new Command("Giao dịch");
				ActionPerform actionPerform = command.action = delegate
				{
					if (Canvas.gameScr.mainChar.tItems.size() >= 12)
					{
						Canvas.startOKDlg("Không thể thêm.");
					}
					else if (!item.isSelling)
					{
						Canvas.gameScr.gameService.sendAddItemTrade(item.itemID, 0, 0);
					}
				};
				mVector.addElement(command);
			}
			Command command2 = new Command("Thông tin");
			ActionPerform actionPerform2 = command2.action = delegate
			{
				if (!item.isEnoughData)
				{
					item.isEnoughData = true;
					GameService.gI().requestItemInfo(item.itemID, Canvas.gameScr.mainChar.ID);
				}
				else
				{
					setShowTextNew(item.getDescription(showResellPrice: false), selected * 18, h);
				}
			};
			command2.perform();
		}
		else
		{
			int num = selected - ItemShopNew.size();
			int num2 = 0;
			for (int j = 0; j < MainChar.listPotion.Length; j++)
			{
				int ii = j;
				if (MainChar.listPotion[j].number - MainChar.listPotion[j].numTrade > 0 && MainChar.listPotion[j].isTrade)
				{
					int bb = num2;
					if (num2 == num)
					{
						Command command3 = new Command("Giao dịch");
						ActionPerform actionPerform3 = command3.action = delegate
						{
							ActionPerform ok = delegate
							{
								try
								{
									int num3 = int.Parse(Canvas.inputDlg.tfInput.getText());
									if (num3 > 0 && num3 <= MainChar.listPotion[ii].number - MainChar.listPotion[ii].numTrade)
									{
										Canvas.gameScr.gameService.sendAddItemTrade((short)ii, 1, num3);
										Canvas.endDlg();
									}
								}
								catch (Exception)
								{
								}
							};
							Canvas.inputDlg.setInfo("Số lượng", ok, TField.INPUT_ALPHA_NUMBER_ONLY, 10, isMaxW: true);
							Canvas.inputDlg.show();
						};
						mVector.addElement(command3);
						Command command4 = new Command("Thông tin");
						ActionPerform actionPerform4 = command4.action = delegate
						{
							setShowTextNew(getPotionInfo(ii), bb % numW * 18, bb / numW * 18);
						};
						command4.perform();
						break;
					}
					num2++;
				}
			}
		}
		Canvas.menu.startAt(mVector, 3);
	}

	protected void doSelectedTrade(sbyte id)
	{
		if (id == 0)
		{
			doViewInfoItemTradeup();
		}
		else if (id == 1)
		{
			doAdditemTrade();
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

	protected void doBuyitemshopnew()
	{
		ActionPerform yesAction = delegate
		{
			GameService.gI().dobuyitemShopnew((sbyte)selected, typeshop);
		};
		Canvas.startYesNoDlg("Bạn có muốn " + text + " vật phẩm này không ?", yesAction);
	}

	protected void doSelectedParty()
	{
		try
		{
			if (Char.party.size() > 0)
			{
				MainChar mainChar = Canvas.gameScr.mainChar;
				mVector mVector = new mVector();
				if (mainChar.ID == mainChar.IDMasterParty)
				{
					Command command = new Command("Đuổi");
					ActionPerform actionPerform = command.action = delegate
					{
						Canvas.gameScr.gameService.kickOutParty(((PartyInfo)Char.party.elementAt(selected)).id, 0);
					};
					mVector.addElement(command);
					Command command2 = new Command("Giải tán");
					ActionPerform actionPerform2 = command2.action = delegate
					{
						Canvas.gameScr.gameService.kickOutParty(0, 1);
					};
					mVector.addElement(command2);
				}
				else
				{
					Command command3 = new Command("Rời nhóm");
					ActionPerform actionPerform3 = command3.action = delegate
					{
						Canvas.gameScr.gameService.kickOutParty(Canvas.gameScr.mainChar.ID, 2);
					};
					mVector.addElement(command3);
				}
				Canvas.menu.startAt(mVector, 2);
			}
		}
		catch (Exception)
		{
		}
	}

	private void setTextCharInfo()
	{
		charInfo = new string[15];
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
		numH = charInfo.Length + 1;
		setLim();
	}

	private void setCamEpDoThu()
	{
		if (!Canvas.isPointerClick)
		{
			return;
		}
		isPaintFc = false;
		for (int i = 0; i < posEpNgoc.Length; i++)
		{
			if (Canvas.isPointer(posEpNgoc[i][0] + 25 + xTr, posEpNgoc[i][1] + 65 + yTr, 34, 34))
			{
				Canvas.isPointerClick = false;
				selected = i;
				isSelectCheDo = true;
				if (numH != 1)
				{
					numH = 1;
					numW = 5;
					cmx = (cmy = (cmtoX = (cmtoY = 0)));
				}
				doSelectedEpDothu();
			}
		}
	}

	private void setCamEpNgoc()
	{
		if (!Canvas.isPointerClick)
		{
			return;
		}
		isPaintFc = false;
		for (int i = 0; i < posEpNgoc.Length; i++)
		{
			if (Canvas.isPointer(posEpNgoc[i][0] + 25 + xTr, posEpNgoc[i][1] + 65 + yTr, newZise, newZise))
			{
				Canvas.isPointerClick = false;
				selected = i;
				isSelectCheDo = true;
				if (numH != 1)
				{
					numH = 1;
					numW = 5;
					cmx = (cmy = (cmtoX = (cmtoY = 0)));
				}
				setCmdCenter();
				if (center != null)
				{
					center.perform();
				}
			}
		}
	}

	private void updateKeyMain()
	{
		if (Canvas.menu.showMenu || Canvas.currentDialog != null)
		{
			return;
		}
		bool flag = false;
		if (index[focusTab] != 28 && index[focusTab] != 21 && index[focusTab] != 25 && index[focusTab] != 26 && index[focusTab] != 32 && index[focusTab] != 7 && index[focusTab] != 8 && index[focusTab] != 22 && index[focusTab] != 23 && index[focusTab] != 1 && index[focusTab] != 31 && isDefault)
		{
			int num = (index[focusTab] == 0) ? 73 : 53;
			curentTabUpdate = index[focusTab];
			xBegin = 15 + xTr;
			yBegin = 55 + yTr;
			wTouch = 5 * (wCell + 12) + 10;
			hTouch = hView - num;
		}
		if (!Canvas.isPointerDown)
		{
			isshowInfo = false;
		}
		if (flag && !isDefault && index[focusTab] != 3)
		{
			cmtoY = selected / numW * hSmall - h / 2;
			if (cmtoY < 0)
			{
				cmtoY = 0;
			}
			if (cmtoY > cmyLim)
			{
				cmtoY = cmyLim;
			}
			if (index[focusTab] != 32)
			{
				cmtoX = selected % numW * wSmall - w / 2;
			}
			else if (selected > 4)
			{
				cmtoX = selected % numW * wSmall - w / 2;
			}
			if (cmtoX < 0)
			{
				cmtoX = 0;
			}
			if (cmtoX > cmxLim)
			{
				cmtoX = cmxLim;
			}
		}
	}

	private void setShowTextArr(string[] text, int x1, int y1)
	{
		isTextArr = true;
		isShowText = true;
		wShow = wKhung - (x0 - 2 + 7 * wCell);
		xShow = 7 * wCell + xTr;
		yShow = -10 + yTr;
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

	private void setUpdatePointerImbue(int bb, int aa)
	{
		if (bb > 0 && bb < 5)
		{
			selected = 1;
			return;
		}
		if (bb == 5)
		{
			bb = 2;
		}
		selected = aa * numW + bb;
	}

	private void setSizeEpNgoc(int i, bool isAn)
	{
		if (i == -1)
		{
			if (numH != 1)
			{
				numH = 1;
				selected = 4;
				numW = 5;
				cmx = (cmy = (cmtoX = (cmtoY = 0)));
			}
			else if (selected == 2)
			{
				selected = 0;
			}
			else if (selected == 3)
			{
				selected = 2;
			}
			else if (selected == 4)
			{
				selected = 1;
			}
		}
		else if (selected == 3 || selected == 4)
		{
			if (!isAn)
			{
				numW = listTemp.size();
				if (numW < 6)
				{
					numW = 6;
				}
				numH = 5;
			}
			else
			{
				resetEpdothu(-1);
			}
		}
		else if (selected == 2)
		{
			selected = 3;
		}
		else if (selected == 0)
		{
			selected = 2;
		}
		else if (selected == 1)
		{
			selected = 4;
		}
	}

	public bool setSizeKeepItem(int i)
	{
		int num = 34;
		int num2 = cmy;
		int num3 = 0;
		num3 = ((index[focusTab] != 22) ? sellItem.size() : Char.itembag.size());
		if (ItemShopNew.size() + MainChar.gemItem.size() < num3)
		{
			numH = num3 / 3 + 1;
		}
		else
		{
			numH = (ItemShopNew.size() + MainChar.gemItem.size()) / 3 + 1;
		}
		if (numH < 5)
		{
			numH = 5;
		}
		if ((selected % numW == 2 && i == 1) || (selected % numW == 3 && i == -1))
		{
			if (i == -1)
			{
				cmyLim = ((((ItemShopNew.size() + MainChar.gemItem.size()) / 3 + 1) * wSmall - index[focusTab] != 22) ? (h + num) : h);
			}
			else
			{
				cmyLim = (((num3 / 3 + 1) * -index[focusTab] != 22) ? (h + num) : h);
			}
			if (cmyLim < 0)
			{
				cmyLim = 0;
			}
			int num4 = selected / numW - cmy / num;
			cmy = (cmtoY = cmyKeep);
			selected = (cmy / num + num4) * numW + selected % numW;
			cmyKeep = num2;
			return true;
		}
		int num5 = (index[focusTab] != 22) ? (h + num) : h;
		cmyLim = numH * num - num5;
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		return false;
	}

	private void setSizeTrade(int dir)
	{
		int num = selected % numW - cmx / 22;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = selected / numW;
		if (selected / numW + 2 == numH && dir == 1)
		{
			int num3 = 0;
			for (int i = 0; i < MainChar.listPotion.Length; i++)
			{
				if (MainChar.listPotion[i].number - MainChar.listPotion[i].numTrade > 0 && MainChar.listPotion[i].isTrade)
				{
					num3++;
				}
			}
			numW = ItemShopNew.size() + num3;
			if (numW < 6)
			{
				numW = 6;
			}
			cmxLim = numW * 22 - w;
		}
		else
		{
			numW = 6;
			cmxLim = 0;
		}
		if (num >= numW)
		{
			num = numW - 1;
		}
		selected = num2 * numW + num;
	}

	private void setSizeImbue(int dir)
	{
		int num = selected % numW - cmx / newZise;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = selected / numW;
		if (num2 + 2 == 5 && dir == 1)
		{
			numW = ItemShopNew.size() + listTemp.size();
			if (numW < 6)
			{
				numW = 6;
			}
			cmxLim = numW * newZise - w + 6 - 90;
			if (cmxLim < 0)
			{
				cmxLim = 0;
			}
		}
		else
		{
			numW = 3;
			cmxLim = 0;
		}
		if (num >= numW)
		{
			num = numW - 1;
		}
		selected = num2 * numW + num;
		cmx = (cmy = (cmtoX = (cmtoY = 0)));
	}

	public void updatePoint()
	{
		if (cmx != cmtoX)
		{
			cmvx = cmtoX - cmx << 2;
			cmdx += cmvx;
			cmx += cmdx >> 4;
			cmdx &= 15;
		}
		if (Math.abs(cmtoY - cmy) < 15 && cmy < 0)
		{
			cmtoY = 0;
		}
		if (Math.abs(cmtoY - cmy) < 10 && cmy > cmyLim)
		{
			cmtoY = cmyLim;
		}
	}

	public override void update()
	{
		Canvas.gameScr.update();
		updateKeyShowText();
		if (index != null)
		{
			if (index[focusTab] != 22 && index[focusTab] != 23 && index[focusTab] != 8)
			{
				updateKeyDong();
				moveCamera();
			}
			else
			{
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
				if (Math.abs(cmtoY - cmy) < 15 && cmy < 0)
				{
					cmtoY = 0;
				}
				if (Math.abs(cmtoY - cmy) < 10 && cmy > cmyLim)
				{
					cmtoY = cmyLim;
				}
				if (Math.abs(cmtoX - cmx) < 15 && cmx < 0)
				{
					cmtoX = 0;
				}
				else if (Math.abs(cmtoX - cmx) < 15 && cmx > cmxLim)
				{
					cmtoX = cmxLim;
				}
			}
		}
		if (cmxTab != cmtoXTab)
		{
			cmvxTab = cmtoXTab - cmxTab << 2;
			cmdxTab += cmvxTab;
			cmxTab += cmdxTab >> 4;
			cmdxTab &= 15;
		}
		if (Math.abs(cmtoXTab - cmxTab) < 15 && cmxTab < 0)
		{
			cmtoXTab = 0;
		}
		else if (Math.abs(cmtoXTab - cmxTab) < 15 && cmxTab > cmxLimTab)
		{
			cmtoXTab = cmxLimTab;
		}
		if (cmtoXName != cmxname)
		{
			cmxname += (cmtoXName - cmxname) / 2;
			if (Util.abs(cmxname) <= 1)
			{
				cmxname = 0;
			}
		}
		if (index[focusTab] == 31 && charWearing != null && charWearing.imgAnimal != null)
		{
			if (Canvas.gameTick % charWearing.timeChangeFrame == 0)
			{
				countFrame++;
				if (countFrame > arrFrame[(charWearing.numFrame != 3) ? 1 : 0].Length - 1)
				{
					countFrame = 0;
				}
			}
			try
			{
				idFrame = arrFrame[(charWearing.numFrame != 3) ? 1 : 0][countFrame];
			}
			catch (Exception)
			{
			}
		}
		if (index[focusTab] == 0 && list != null && list.size() > 0)
		{
			limMyBag = Canvas.gameScr.mainChar.limItemBag - 1;
			if (limMyBag <= 0)
			{
				limMyBag = 0;
			}
			excess = list.size() % numCell;
			maxSize = list.size();
		}
		updateTab();
		if (index[focusTab] != 28 && index[focusTab] != 25 && index[focusTab] != 21 && index[focusTab] != 26 && index[focusTab] != 32 && !isDefault && index[focusTab] != 7 && index[focusTab] != 22 && index[focusTab] != 23 && index[focusTab] != 1 && index[focusTab] != 31 && index[focusTab] != 8 && index[focusTab] != 27 && index[focusTab] != 0)
		{
			checkPaint = true;
		}
		else
		{
			checkPaint = false;
		}
	}

	private void updateTab()
	{
		int num = Canvas.w;
		if (num > 480)
		{
			num = 480;
		}
		int num2 = Canvas.h;
		if (num2 > 320)
		{
			num2 = 320;
		}
		if (!Canvas.isPointer(xKhung + xTr, 0 + yTr, wKhung, MainJ2ME.hTab + 20) || Canvas.menu.showMenu || !isDefault)
		{
			return;
		}
		if (Canvas.isPointerDown)
		{
			if (!Canvas.isMove && !Canvas.isPointerClick)
			{
				trans = false;
			}
			if (!trans)
			{
				pa = cmxTab;
				trans = true;
				closeText();
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
		switch (index[focusTab])
		{
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
			if (!Canvas.isPointerClick)
			{
				return;
			}
			saveSelect = -1;
			isPaintFc = false;
			closeText();
			Canvas.isPointerClick = false;
			if (Math.abs(Canvas.pxLast - Canvas.px) < 10)
			{
				tdx = (cmtoXTab + Canvas.px - 24 - xTr) / 70;
				cmtoXTab = tdx * 70 - num / 2;
				if (cmtoXTab < 0)
				{
					cmtoXTab = 0;
				}
				if (cmtoXTab > cmxLimTab)
				{
					cmtoXTab = cmxLimTab;
				}
				selected = 0;
				focusTabChinh = 0;
				focusTab = 0;
				saveSelect = -1;
				setSelectTab();
				setCmdCenter();
			}
			return;
		}
		if (index[focusTab] != 24 && Canvas.isPointer(15 + xTr, 0 + yTr, num / 2 - 15, 50))
		{
			if (Canvas.isPointerClick)
			{
				Canvas.isPointerClick = false;
				closeText();
				focusTabChinh = 0;
				focusTab = 0;
				saveSelect = -1;
				setSelectTab();
				setCmdCenter();
				if (index != null)
				{
					curentTabUpdate = index[focusTab];
				}
				isPaintFc = false;
			}
		}
		else if (index[focusTab] != 24 && Canvas.isPointer(15 + num / 2 + xTr, 0 + yTr, num / 2 - 15, 50) && Canvas.isPointerClick)
		{
			Canvas.isPointerClick = false;
			closeText();
			focusTabChinh = 0;
			focusTab = 0;
			saveSelect = -1;
			setSelectTab();
			setCmdCenter();
			if (index != null)
			{
				curentTabUpdate = index[focusTab];
			}
			isPaintFc = false;
		}
	}

	public void paintKhungClan(MyGraphics g, int x, int y)
	{
		Canvas.resetTrans(g);
		int num = Canvas.w;
		if (num > 480)
		{
			num = 480;
		}
		int num2 = Canvas.h;
		if (num2 > 320)
		{
			num2 = 320;
		}
		Res.paintDlgFull(g, 10 + xTr, 10 + yTr, num - 20, num2 - 50);
		MFont.normalFont[0].drawString(g, name, Canvas.hw, 15 + yTr, MFont.CENTER);
		int num3 = 55;
		Command command = null;
		for (int i = 0; i < list.size(); i++)
		{
			if (isLoad)
			{
				break;
			}
			command = (Command)list.elementAt(i);
			command.paint(g, 80 + xTr, num3 + yTr);
			num3 += 25;
		}
	}

	public override void paint(MyGraphics g)
	{
		try
		{
			Canvas.gameScr.paint(g);
			Canvas.resetTrans(g);
			g.translate(x, y);
			if (checkPaint)
			{
				if (index[focusTab] != 29)
				{
					Res.paintDlgFull(g, -10, -10);
				}
				else
				{
					paintKhungClan(g, -10, -10);
				}
			}
			if (index[focusTab] != 27 && index[focusTab] != 29 && index[focusTab] != 0)
			{
				if (countL > 0)
				{
					countL--;
				}
				if (countR > 0)
				{
					countR--;
				}
				g.setColor(7961465);
				g.fillRect(21, 11, 88, 16);
				g.fillRect(20, 12, 90, 14);
				g.setColor((!isChangeTab) ? 2368548 : 30611);
				g.fillRect(21, 12, 88, 14);
				g.setClip(21, 11, 88, 16);
				g.translate(-cmxname, 0);
				int width = MFont.normalFont[0].getWidth(nameshop);
				if (width > 88)
				{
					transX -= dirX;
					if (Util.abs(transX) > (width - 88) / 2 + 5)
					{
						dirX *= -1;
					}
				}
			}
			g.translate(cmxname, 0);
			g.translate(x0, y0);
			g.setClip(-100, -100, 300, 300);
			int num = Canvas.w;
			if (num > 480)
			{
				num = 480;
			}
			int num2 = Canvas.h;
			if (num2 > 320)
			{
				num2 = 320;
			}
			try
			{
				isDefault = true;
				Canvas.resetTrans(g);
				paintBG(g, 10 + xTr, 10 + yTr, num - 20, num2 - 60);
				g.translate(25, 65);
				g.setColor(25695);
				int num3 = hView - 34;
				int num4 = 7 * wCell - 2;
				sbyte b = 24;
				g.fillRect(num4 + xTr, -11 + yTr, wKhung - (x0 - 2 + 7 * wCell + b), num3);
				num3--;
				g.setColor(16774720);
				g.drawRect(num4 + xTr, -11 + yTr, wKhung - (x0 - 2 + 7 * wCell + b) - 1, num3);
				int num5 = -24 + num3;
				if (isPaintMoney)
				{
					MFont.smallFontColor[0].drawString(g, Canvas.gameScr.mainChar.charXu + "$", num4 + (wKhung - (x0 - 2 + 7 * wCell + b)) - 4 + xTr, num5 + yTr, MFont.RIGHT);
					MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luong + "L", num4 + 2 + xTr, num5 + yTr, MFont.LEFT);
					if (Canvas.gameScr.mainChar.luongKhoa > -1)
					{
						MFont.smallFontColor[1].drawString(g, Canvas.gameScr.mainChar.luongKhoa + "LK", num4 + (wKhung - (x0 - 2 + 7 * wCell + b)) / 2 + xTr, num5 + yTr, MFont.CENTER);
					}
				}
				if (index[focusTab] == 0)
				{
					int num6 = num2 - 130;
				}
				g.setClip(-10 + xTr, -10 + yTr, numW * wSmall + 20, num3 + addHclip + 10);
				g.translate(0 + xTr, -cmy + yTr);
				int num7 = wKhung;
				int num8 = cmy / (hSmall + 10);
				if (num8 < 0)
				{
					num8 = 0;
				}
				int num9 = num8 + (num7 + 20) / (hSmall + 10);
				if (index[focusTab] == 0 && num9 > numCell)
				{
					num9 = numCell;
				}
				for (int i = num8; i < num9; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						paintGrid(g, j * (wSmall + 10) - 7, i * (hSmall + 10) - 10);
					}
				}
				if (selected != -1 && isPaintFc)
				{
					g.setColor(10595790, 0.5f);
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
				Canvas.resetTrans(g);
				switch (index[focusTab])
				{
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
					g.setClip(15 + xTr, 9 + yTr, num - 30, 33);
					g.translate(-cmxTab, 0);
					g.setColor(0, 0.5f);
					g.fillRect(17 + focusTabChinh * 69 + xTr, 12 + yTr, 69, 40);
					for (int k = 0; k < tabName.Length; k++)
					{
						MFont.normalFont[0].drawString(g, string.Empty + tabName[k], 48 + 70 * k + xTr, 20 + yTr, MFont.CENTER);
					}
					for (int l = 0; l < tabName.Length; l++)
					{
						g.drawImage(Res.imgK0, 17 + 69 * l + xTr, 12 + yTr, 0);
					}
					g.translate(cmxTab, 0);
					g.setClip(0, 0, Canvas.w, Canvas.h);
					break;
				default:
					if (index[focusTab] != 24)
					{
						g.setColor(0, 0.5f);
						g.fillRect(13 + focusTabChinh * (num / 2 - 13) + xTr, 13 + yTr, num / 2 - 12, 30);
						MFont.bigFont.drawString(g, nameshop, num / 4 + 10 + xTr, 18 + yTr, MFont.CENTER);
						g.setColor(10591392);
						g.fillRect(num / 2 + xTr, 13 + yTr, 2, 29);
					}
					else
					{
						MFont.bigFont.drawString(g, "Gian hàng", Canvas.hw, 69 + num5, MFont.CENTER);
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			if (isShowText)
			{
				Canvas.resetTrans(g);
				if (checkPaintText())
				{
					g.translate(25, 65);
					paintShowTextNew(g);
				}
				else
				{
					paintShowText(g);
				}
			}
			base.paint(g);
		}
		catch (Exception)
		{
		}
	}

	public bool checkPaintText()
	{
		if (index == null)
		{
			return false;
		}
		if (index[focusTab] == 28 || index[focusTab] == 21 || index[focusTab] == 25 || index[focusTab] == 26 || index[focusTab] == 32 || isDefault || index[focusTab] == 22 || index[focusTab] == 23 || index[focusTab] == 1 || index[focusTab] == 31 || index[focusTab] == 8 || index[focusTab] == 7)
		{
			return true;
		}
		return false;
	}

	private int canPutItem()
	{
		int num = -1;
		for (int i = 0; i < itemEpdothu.Length; i++)
		{
			if (itemEpdothu[i] == null)
			{
				num++;
			}
		}
		return num;
	}

	public void resetEpdothu(int saveIndex)
	{
		numW = listItemAnimal.size() + listTemp.size();
		if (numW < 6)
		{
			numW = 6;
		}
		numH = 5;
		if (saveIndex == -1)
		{
			selected = (numH - 1) * numW;
		}
		else
		{
			selected -= numH;
			if (selected > numH * numW - 1)
			{
				selected = numH * numW - 1;
			}
			if (selected < (numH - 1) * numW)
			{
				selected = (numH - 1) * numW;
			}
			cmtoX = selected % numW * wSmall - w / 2;
			if (cmtoX < 0)
			{
				cmtoX = 0;
			}
			if (cmtoX > cmxLim)
			{
				cmtoX = cmxLim;
			}
			cmx = cmtoX;
		}
		cmxLim = numW * 20 - (w - 8);
		if (cmxLim < 0)
		{
			cmxLim = 0;
		}
		if (saveIndex == -1)
		{
			cmx = (cmy = (cmtoX = (cmtoY = 0)));
		}
	}

	public void doshowInfoEpdothu()
	{
		ItemInInventory item = (ItemInInventory)listItemAnimal.elementAt(selected);
		showItemInventoryInfo(item, isSell: false, selected * 20 + 4, 86);
	}

	private void doSelectedEpDothu()
	{
		if (isShowText)
		{
			return;
		}
		mVector mVector = new mVector();
		if (numH != 1 && !isNguyenLieu)
		{
			if (selected >= 0 && selected < listItemAnimal.size())
			{
				ItemInInventory item2 = (ItemInInventory)listItemAnimal.elementAt(selected);
				Out.println(selected + "vi tri chon item ep   " + selected);
				if (canPutItem() > -1)
				{
					Command command = new Command("Bỏ vào");
					command.action = delegate
					{
						if (item2.level >= 30 && item2.level <= lvThu + 5 && item2.level >= lvThu - 5 && item2.colorName == idColor)
						{
							if (itemEpdothu[2] == null)
							{
								if (magicAnimal == item2.magic_physic)
								{
									itemEpdothu[2] = item2;
									listItemAnimal.removeElement(item2);
								}
							}
							else
							{
								for (int l = 0; l < itemEpdothu.Length; l++)
								{
									if (itemEpdothu[l] == null)
									{
										itemEpdothu[l] = item2;
										listItemAnimal.removeElement(item2);
										break;
									}
								}
							}
						}
						else
						{
							Canvas.startOKDlg("Đồ ép phải cùng màu và chênh lệch +-5 level.");
						}
						resetEpdothu(1);
					};
					mVector.addElement(command);
				}
				Command command2 = new Command("Thông tin");
				command2.action = delegate
				{
					doshowInfoEpdothu();
					Canvas.endDlg();
				};
				command2.perform();
			}
			else if (selected - listItemAnimal.size() >= 0 && selected - listItemAnimal.size() < listTemp.size())
			{
				GemTemplate item = (GemTemplate)listTemp.elementAt(selected - listItemAnimal.size());
				Command command3 = new Command("Bỏ vào");
				command3.action = delegate
				{
					if (listEp.size() < 6)
					{
						if (checkItem(isItem: false) >= slNLThu)
						{
							Canvas.startOKDlg("Nguyên liệu đã đủ số lượng.");
							return;
						}
						item.number--;
						if (item.number <= 0)
						{
							listTemp.removeElement(item);
						}
						GemTemplate o = new GemTemplate(item.rID)
						{
							id = item.id
						};
						listEp.addElement(o);
					}
					bool flag2 = false;
					int num2 = listEp.size();
					for (int j = 0; j < num2; j++)
					{
						GemTemplate gemTemplate3 = (GemTemplate)listEp.elementAt(j);
						if (gemTemplate3.id == item.id)
						{
							gemTemplate3.number++;
							flag2 = true;
							break;
						}
					}
					for (int k = 0; k < num2; k++)
					{
						GemTemplate gemTemplate4 = (GemTemplate)listEp.elementAt(k);
						if (gemTemplate4.number == 0)
						{
							listEp.removeElement(gemTemplate4);
						}
					}
					if (!flag2)
					{
						GemTemplate gemTemplate5 = new GemTemplate(item.id);
						GemTemplate.copyData(item, gemTemplate5);
						gemTemplate5.number = 1;
						listEp.addElement(gemTemplate5);
					}
				};
				mVector.addElement(command3);
				mVector.addElement(addGemInfo(item, selected * 20 + 4, 86));
			}
		}
		else if (isNguyenLieu)
		{
			if (selected >= 0 && selected < listEp.size())
			{
				GemTemplate g = (GemTemplate)listEp.elementAt(selected);
				if (g != null)
				{
					Command command4 = new Command("Lâ\u0301y ra");
					command4.action = delegate
					{
						g.number--;
						if (g.number <= 0)
						{
							listEp.removeElement(g);
						}
						bool flag = false;
						int num = listTemp.size();
						for (int i = 0; i < num; i++)
						{
							GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
							if (gemTemplate.id == g.id)
							{
								gemTemplate.number++;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							GemTemplate gemTemplate2 = new GemTemplate(g.id)
							{
								number = 1
							};
							listTemp.addElement(g);
						}
						resetEpdothu(-1);
					};
					mVector.addElement(command4);
				}
			}
		}
		else if (selected >= 0 && selected < itemEpdothu.Length)
		{
			ItemInInventory real = itemEpdothu[selected];
			if (real != null)
			{
				Command command5 = new Command("Lâ\u0301y ra");
				command5.action = delegate
				{
					listItemAnimal.addElement(real);
					itemEpdothu[selected] = null;
					resetEpdothu(-1);
				};
				mVector.addElement(command5);
			}
		}
		Canvas.menu.startAt(mVector, 2);
	}

	private int checkItem(bool isItem)
	{
		int num = 0;
		if (isItem)
		{
			for (int i = 0; i < itemEpdothu.Length; i++)
			{
				if (itemEpdothu[i] != null)
				{
					num++;
				}
			}
		}
		else
		{
			for (int j = 0; j < listEp.size(); j++)
			{
				GemTemplate gemTemplate = (GemTemplate)listEp.elementAt(j);
				num += gemTemplate.number;
			}
		}
		return num;
	}

	private void doLeftEpDothu()
	{
		ActionPerform action = delegate
		{
			if (checkItem(isItem: true) < 5)
			{
				Canvas.startOKDlg("Bạn phải sử dụng đủ 5 vật phẩm.");
			}
			else if (checkItem(isItem: false) < slNLThu)
			{
				Canvas.startOKDlg("Nguyên liệu không đủ. Cần " + slNLThu + " nguyên liệu.");
			}
			else
			{
				mVector mVector = new mVector();
				if (itemEpdothu[2] != null)
				{
					mVector.addElement(itemEpdothu[2]);
				}
				for (int i = 0; i < itemEpdothu.Length; i++)
				{
					if (i != 2 && itemEpdothu[i] != null)
					{
						mVector.addElement(itemEpdothu[i]);
					}
				}
				sbyte[] array = new sbyte[6];
				for (int j = 0; j < listEp.size(); j++)
				{
					GemTemplate gemTemplate = (GemTemplate)listEp.elementAt(j);
					GemTemp gemByID = Res.getGemByID(gemTemplate.id);
					string s = gemByID.name.Substring(gemByID.name.Length - 1);
					int num = int.Parse(s);
					array[num - 1] = (sbyte)gemTemplate.number;
				}
				GameService.gI().epDothu(mVector, array);
				Canvas.startWaitDlg("Đang hợp..", isIcon: false);
				for (int k = 0; k < itemEpdothu.Length; k++)
				{
					itemEpdothu[k] = null;
				}
				if (listEp != null)
				{
					listEp.removeAllElements();
				}
				right.perform();
			}
		};
		left = new Command("Hợp");
		left.action = action;
	}

	private void paintBG(MyGraphics g, int x, int y, int wd, int hd)
	{
		Res.paintDlgDragonFull(g, x, y, wd, hd + 5);
		g.setColor(Res.color[1]);
		g.fillRect(x + 1, y + MainJ2ME.hTab - 13, wd - 2, 2);
	}

	private void paintGrid(MyGraphics g, int x, int y)
	{
		int num = (!isDefault) ? 34 : 44;
		g.setColor(6513507);
		g.drawRect(x, y, num, num);
		g.setColor(8684162);
		g.drawRect(x + 1, y + 1, num - 2, num - 2);
	}

	private void paintGrid29(MyGraphics g, int x, int y)
	{
		g.drawImage(Res.imgCell[1], x, y, 0);
	}

	private void paintCheDo(MyGraphics g)
	{
		int num = 0;
		int num2 = 34;
		for (int i = 0; i < listCheDo.size(); i++)
		{
			Mineral mineral = (Mineral)listCheDo.elementAt(i);
			MFont.normalFont[0].drawString(g, mineral.name + ": " + mineral.number + " Cái.", 0 + xTr, i * 15 + 2 - 10 + yTr, 0);
		}
		int num3 = 0;
		int num4 = listEp.size() / 2;
		if (num4 < 6)
		{
			num4 = 6;
		}
		g.translate(0, 0);
		g.setColor(8092027, 0.5f);
		if (selected / numW < 2 && isSelectCheDo)
		{
			g.fillRect(selected % numW * num2 + xTr, listCheDo.size() * 13 + selected / numW * num2 + 13 - 10 + yTr, num2, num2);
		}
		int num5 = listEp.size();
		int num6 = listCheDo.size();
		for (int j = 0; j < num5; j++)
		{
			GemTemplate gemTemplate = (GemTemplate)listEp.elementAt(j);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, xTr + j % num4 * num2 + wSmall / 2 + 4, num6 * 13 + 13 + j / num4 * num2 + wSmall / 2 - ((!isLastScreenMenuWindow) ? 13 : 0) + yTr);
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, j % num4 * num2 + wSmall / 2 + 12 + xTr, num6 * 13 + 17 + j / num4 * num2 + wSmall / 2 - ((!isLastScreenMenuWindow) ? 10 : 0) + yTr, MFont.RIGHT);
			num3++;
		}
		for (int k = 0; k < 3; k++)
		{
			g.fillRect(0 + xTr, k * num2 + 27 + yTr, 6 * num2 + 2, 2);
		}
		g.setColor(8092027);
		for (int l = 0; l < 7; l++)
		{
			g.fillRect(l * num2 + xTr, 27 + yTr, 2, 2 * num2);
		}
		g.setColor(8092027, 0.5f);
		g.setClip(-10 + xTr, 3 * newZise + yTr, 5 * newZise + 20, 3 * newZise);
		g.translate(-cmx + 10 + xTr, yTr);
		paintGemItemCheDo(g, num, 4 * numCell - 10);
		num += listTemp.size();
	}

	private void paintSelected(MyGraphics g, int x, int y)
	{
		g.setColor(10595790);
		g.fillRect(x, y, 32, 32);
	}

	private void paintKeepItem(MyGraphics g)
	{
		int num = hView - 34;
		g.setClip(-10 + xTr, -10 + yTr, 7 * wCell, num + addHclip);
		int num2 = 0;
		int num3 = 0;
		int num4 = 34;
		if (selected % numW < 3)
		{
			g.translate(0, -cmy);
			if (!isChangeTab && isFcStore)
			{
				paintSelected(g, xTr + selected % numW * (num4 - 1) + 1, yTr + selected / numW * (num4 - 1) + 1);
			}
		}
		else
		{
			g.translate(0, -cmyKeep);
		}
		int num5 = ItemShopNew.size();
		g.setColor(7706352);
		for (int i = 0; i < num5; i++)
		{
			num2 = i % 3 * (num4 - 1);
			num3 = i / 3 * (num4 - 1);
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(i);
			if (itemInInventory.isSelling)
			{
				g.fillRect(num2 + xTr, num3 + yTr, num4, num4);
			}
			g.drawImage(Res.imgCell[0], num2 + xTr, num3 + yTr, 0);
			itemInInventory.paint(g, num2 + 17 + xTr, num3 + 17 + yTr);
		}
		int num6 = ItemShopNew.size();
		int num7 = MainChar.gemItem.size();
		for (int j = 0; j < num7; j++)
		{
			num2 = num6 % 3 * (num4 - 1);
			num3 = num6 / 3 * (num4 - 1);
			g.drawImage(Res.imgCell[0], num2 + xTr, num3 + yTr, 0);
			GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(j);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, num2 + 17 + xTr, num3 + 10 + yTr);
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, num2 + num4 + xTr, yTr + num3 + num4 - MFont.smallFont.getHeight() - 7, MFont.RIGHT);
			num6++;
		}
		if (selected % numW > 2)
		{
			g.translate(0, cmyKeep);
			g.translate(0, -cmy);
		}
		else
		{
			g.translate(0, cmy);
			g.translate(0, -cmyKeep);
		}
		for (int k = 0; k < numH; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				g.drawImage(Res.imgCell[2], l * (num4 - 1) + num4 * 3 - 3 + xTr, k * (num4 - 1) + yTr, 0);
				g.drawImage(Res.imgCell[0], l * (num4 - 1) + num4 * 3 - 3 + xTr, k * (num4 - 1) + yTr, 0);
			}
		}
		if (selected % numW > 2 && !isChangeTab)
		{
			paintSelected(g, selected % numW * (num4 - 1) + 1 + xTr, selected / numW * (num4 - 1) + 1 + yTr);
		}
		mVector mVector = null;
		mVector = ((index[focusTab] != 22) ? sellItem : Char.itembag);
		for (int m = 0; m < mVector.size(); m++)
		{
			if (mVector.elementAt(m) is ItemInInventory)
			{
				ItemInInventory itemInInventory2 = (ItemInInventory)mVector.elementAt(m);
				itemInInventory2.paint(g, m % 3 * num4 + (num4 - 1) * 3 + 14 + xTr, m / 3 * (num4 - 1) + 17 + yTr);
			}
			else
			{
				RealID realID = (RealID)mVector.elementAt(m);
				Res.paintGem(g, Res.getGemByID(realID.ID).idImage, m % 3 * (num4 - 1) + num4 * 3 + 14 + xTr, m / 3 * (num4 - 1) + 17 + yTr);
			}
		}
	}

	private void paintKeepAndSellItem(MyGraphics g)
	{
		g.setClip(0, 0, w, h);
		int num = 0;
		int num2 = 0;
		if (selected % numW < 3)
		{
			g.translate(0, -cmy);
			if (!isChangeTab)
			{
				paintSelected(g, selected % numW * 18 + 1, selected / numW * 18 + 1);
			}
		}
		else
		{
			g.translate(0, -cmyKeep);
		}
		for (int i = 0; i < numH; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				g.drawImage(Res.imgGrid, j * 18, i * 18, 0);
			}
		}
		for (int k = 0; k < ItemShopNew.size(); k++)
		{
			num = k % 3 * 18;
			num2 = k / 3 * 18;
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(k);
			if (itemInInventory.isSelling)
			{
				g.setColor(7706352);
				g.fillRect(num + 2, num2 + 2, 14, 14);
			}
			itemInInventory.paint(g, num + 9, num2 + 9);
		}
		int num3 = ItemShopNew.size();
		for (int l = 0; l < MainChar.gemItem.size(); l++)
		{
			num = num3 % 3 * 18;
			num2 = num3 / 3 * 18;
			GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(l);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, num + 9, num2 + 9);
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, num + 18, num2 + 18 - MFont.smallFont.getHeight(), MFont.RIGHT);
			num3++;
		}
		if (selected % numW > 2)
		{
			g.translate(0, cmyKeep);
			g.translate(0, -cmy);
		}
		else
		{
			g.translate(0, cmy);
			g.translate(0, -cmyKeep);
		}
		for (int m = 0; m < numH; m++)
		{
			for (int n = 0; n < 3; n++)
			{
				g.setColor(6568449);
				g.fillRect(n * 18 + 54, m * 18, 18, 18);
				g.drawImage(Res.imgGrid, n * 18 + 54, m * 18, 0);
			}
		}
		if (selected % numW > 2 && !isChangeTab)
		{
			paintSelected(g, selected % numW * 18 + 1, selected / numW * 18 + 1);
		}
		mVector mVector = null;
		mVector = ((index[focusTab] != 22) ? sellItem : Char.itembag);
		for (int num4 = 0; num4 < mVector.size(); num4++)
		{
			if (mVector.elementAt(num4) is ItemInInventory)
			{
				ItemInInventory itemInInventory2 = (ItemInInventory)mVector.elementAt(num4);
				itemInInventory2.paint(g, num4 % 3 * 18 + 54 + 9, num4 / 3 * 18 + 9);
			}
			else
			{
				RealID realID = (RealID)mVector.elementAt(num4);
				Res.paintGem(g, Res.getGemByID(realID.ID).idImage, num4 % 3 * 18 + 54 + 9, num4 / 3 * 18 + 9);
			}
		}
	}

	private void paintEpDothu(MyGraphics g)
	{
		for (int i = 0; i < 5; i++)
		{
			g.drawImage(Res.imgCell[0], posEpNgoc[i][0] + xTr, posEpNgoc[i][1] + yTr, 0);
		}
		g.setColor(10595790, 0.5f);
		if (numH == 1 && selected < 5)
		{
			g.fillRect(posEpNgoc[selected][0] + 2 + xTr, posEpNgoc[selected][1] + 2 + yTr, 30, 30);
		}
		for (int j = 0; j < itemEpdothu.Length; j++)
		{
			if (itemEpdothu[j] != null)
			{
				paintItemIcon(g, itemEpdothu[j], posEpNgoc[j][0] + 17 + xTr, posEpNgoc[j][1] + 21 + yTr);
			}
		}
		int num = 3;
		if (idColor == 3)
		{
			num = 2;
		}
		else if (idColor == 2)
		{
			num = 1;
		}
		MFont.normalFont[num].drawString(g, string.Empty + mau[num], posEpNgoc[2][0] + 16 + xTr, posEpNgoc[1][1] + yTr, MFont.CENTER);
		MFont.normalFont[0].drawString(g, "Số Đá: " + slNLThu, posEpNgoc[2][0] + 16 + xTr, posEpNgoc[3][1] + yTr + 16, MFont.CENTER);
		for (int k = 0; k < 6; k++)
		{
			g.drawImage(Res.imgCell[0], posEpNgoc[0][0] + xTr + k * 32, posEpNgoc[3][1] + yTr + 38, 0);
		}
		int num2 = listEp.size();
		for (int l = 0; l < num2; l++)
		{
			GemTemplate gemTemplate = (GemTemplate)listEp.elementAt(l);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			string s = gemByID.name.Substring(gemByID.name.Length - 1);
			int num3 = int.Parse(s);
			if (selected == l && isNguyenLieu)
			{
				g.fillRect(posEpNgoc[0][0] + xTr + l * 32 + 1, posEpNgoc[3][1] + yTr + 38 + 1, 31, 31);
			}
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, posEpNgoc[0][0] + xTr + l * 32 + 16, posEpNgoc[3][1] + yTr + 54);
			MFont.smallFont.drawString(g, num3 + string.Empty, posEpNgoc[0][0] + xTr + l * 32 + 32, posEpNgoc[3][1] + yTr + 38, MFont.RIGHT);
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, posEpNgoc[0][0] + xTr + l * 32 + 32, posEpNgoc[3][1] + yTr + 54, MFont.RIGHT);
		}
		g.setClip(-10 + xTr, 4 * newZise - 4 + yTr, 5 * newZise + 10, 52);
		g.translate(-cmx + xTr, yTr);
		int num4 = 0;
		paintListItemAnimal(g, num4);
		num4 += listItemAnimal.size();
	}

	public void paintListItemAnimal(MyGraphics g, int count)
	{
		int num = 4 * numCell + 8;
		for (int i = 0; i < listItemAnimal.size(); i++)
		{
			if (selected > -1 && selected == i && isPaintFc && !isNguyenLieu)
			{
				g.fillRect(i * 32 + 1, num - 2, 32, 32);
			}
			ItemInInventory itemInInventory = (ItemInInventory)listItemAnimal.elementAt(i);
			g.drawImage(Res.imgCell[0], count * 32, num - 3, 0);
			itemInInventory.paint(g, count * 32 + 16, num + 17);
			count++;
		}
		paintGemItemThu(g, count, num);
	}

	private void paintGemItemThu(MyGraphics g, int count, int yy)
	{
		int num = listTemp.size();
		for (int i = 0; i < num; i++)
		{
			if (khoaDoThu == 1)
			{
				g.setColor(3276851, 0.5f);
				g.fillRect(count * 32, yy - 3, 34, 34);
			}
			g.setColor(10595790, 0.5f);
			if (isPaintFc && selected > -1 && selected == count && !isNguyenLieu)
			{
				g.fillRect(count * 32 + 1, yy - 2, 32, 32);
			}
			g.drawImage(Res.imgCell[0], count * 32, yy - 3, 0);
			GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, count * 32 + 16, yy + 17);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			string s = gemByID.name.Substring(gemByID.name.Length - 1);
			try
			{
				int num2 = int.Parse(s);
				MFont.smallFont.drawString(g, num2 + string.Empty, count * 32 + 32, yy - 3, MFont.RIGHT);
			}
			catch (Exception)
			{
			}
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, count * 32 + 32, yy + 15, MFont.RIGHT);
			count++;
		}
	}

	private void paintEpNgoc(MyGraphics g)
	{
		for (int i = 0; i < 5; i++)
		{
			g.drawImage(Res.imgCell[1], posEpNgoc[i][0] + xTr, posEpNgoc[i][1] + yTr, 0);
		}
		g.setColor(10595790, 0.5f);
		if (numH == 1 && selected < 5 && isSelectCheDo)
		{
			g.fillRect(posEpNgoc[selected][0] + 1 + xTr, posEpNgoc[selected][1] + 1 + yTr, newZise, newZise);
		}
		for (int j = 0; j < listEp.size(); j++)
		{
			RealID realID = (RealID)listEp.elementAt(j);
			Res.paintGem(g, Res.getGemByID(realID.ID).idImage, posEpNgoc[j][0] + 21 + xTr, posEpNgoc[j][1] + 21 + yTr);
		}
		g.setClip(-10 + xTr, 4 * newZise - 4 + yTr, 5 * newZise + 20, 52);
		g.translate(-cmx + xTr, 0 + yTr);
		if (numH != 1)
		{
		}
		int num = 0;
		paintGemItemHopThanh(g, num, 4 * numCell - 4);
		num += listTemp.size();
	}

	private void paintGemItemCheDo(MyGraphics g, int count, int y)
	{
		int num = listTemp.size();
		for (int i = 0; i < num; i++)
		{
			if (khoaCheDo == 1)
			{
				g.setColor(3276851, 0.5f);
				g.fillRect(count * numCell - 21, y, numCell, numCell);
			}
			g.setColor(10595790, 0.5f);
			if (selected == i && isPaintFc)
			{
				g.fillRect(count * numCell - 21, y, numCell, numCell);
			}
			g.drawImage(Res.imgCell[1], count * numCell - 21, y, 0);
			GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, count * newZise, y + 17);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			string s = gemByID.name.Substring(gemByID.name.Length - 1);
			try
			{
				int num2 = int.Parse(s);
				MFont.smallFont.drawString(g, num2 + string.Empty, count * newZise + 5, y + 2, MFont.LEFT);
			}
			catch (Exception)
			{
			}
			MFont.smallFontColor[0].drawString(g, gemTemplate.number + string.Empty, count * newZise + 21, y + 28, MFont.RIGHT);
			count++;
		}
	}

	private void paintGemItemHopThanh(MyGraphics g, int count, int y)
	{
		for (int i = 0; i < listTemp.size(); i++)
		{
			if (selected == i && isPaintFc)
			{
				g.fillRect(count * numCell, y, 41, numCell);
			}
			g.drawImage(Res.imgCell[1], count * numCell, y, 0);
			GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
			Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, count * numCell + 21, y + 17);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			string s = gemByID.name.Substring(gemByID.name.Length - 1);
			try
			{
				int num = int.Parse(s);
				MFont.smallFont.drawString(g, num + string.Empty, count * numCell + numCell, y + 2, MFont.RIGHT);
			}
			catch (Exception)
			{
			}
			MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, count * numCell + numCell, y + 28, MFont.RIGHT);
			count++;
		}
	}

	private void paintGemItem(MyGraphics g, int count, int y)
	{
		for (int i = 0; i < listTemp.size(); i++)
		{
			if ((khoaImbue == 1 && index[focusTab] == 21) || (khoaKham == 1 && index[focusTab] == 25))
			{
				g.setColor(3276851, 0.5f);
				g.fillRect(count * numCell - 21 + xTr, y + yTr, numCell, numCell);
			}
			g.drawImage(Res.imgCell[1], count * numCell - 21 + xTr, y + yTr, 0);
			GemTemplate gemTemplate = (GemTemplate)listTemp.elementAt(i);
			if (gemTemplate != null)
			{
				Res.paintGem(g, Res.getGemByID(gemTemplate.id).idImage, count * numCell + xTr, y + 17 + yTr);
				if (index[focusTab] != 21)
				{
					GemTemp gemByID = Res.getGemByID(gemTemplate.id);
					string s = gemByID.name.Substring(gemByID.name.Length - 1);
					try
					{
						int num = int.Parse(s);
						MFont.smallFont.drawString(g, num + string.Empty, count * numCell + 5 + xTr, y + 2 + yTr, MFont.LEFT);
					}
					catch (Exception)
					{
					}
				}
				MFont.smallFont.drawString(g, gemTemplate.number + string.Empty, count * numCell + 21 + xTr, y + 22 + yTr, MFont.RIGHT);
			}
			count++;
		}
	}

	private void paintImbue(MyGraphics g)
	{
		paintDapBG(g, 0, 0);
		if (imgWeaponAvatar != null)
		{
			g.drawImage(imgWeaponAvatar, 106 + xTr, 4 * newZise / 2 - 5 + yTr, 3);
		}
		for (int i = 0; i < MainChar.gemitemImbue.size(); i++)
		{
			RealID realID = (RealID)MainChar.gemitemImbue.elementAt(i);
			Res.paintGem(g, Res.getGemByID(realID.ID).idImage, xTr + i % 2 * (5 * wCell) + wCell / 2 + 6, yTr + i / 2 * numCell + hSmall / 2 - 4);
		}
		g.setClip(-10 + xTr, 4 * newZise - 4 + yTr, 5 * newZise + 20, 52);
		g.translate(-cmx + 10, 0);
		int num = 0;
		g.setColor(10595790, 0.5f);
		if (isPaintFc)
		{
			g.fillRect(idfcsetSelectedImbue * numCell - 21 + xTr, 4 * numCell - 4 + yTr, numCell, numCell);
		}
		for (int j = 0; j < ItemShopNew.size(); j++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(j);
			g.drawImage(Res.imgCell[1], num * numCell - 21 + xTr, 4 * numCell - 4 + yTr, 0);
			itemInInventory.paint(g, num * numCell + xTr, 4 * numCell + 17 + yTr);
			num++;
		}
		paintGemItem(g, num, 4 * numCell - 4);
		num += listTemp.size();
	}

	private void paintDapBG(MyGraphics g, int x, int y)
	{
		if (!isChangeTab && Canvas.gameTick % 10 > 3 && selected / numW < 4 && isSelectCheDo)
		{
			g.setColor(10595790);
			if (selected % numW == 1 && selected / numW != 4)
			{
				g.fillRect(63 + xTr, -10 + yTr, 84, 4 * numCell);
			}
			else
			{
				int num = selected % numW;
				if (num > 1)
				{
					num = 1;
				}
				g.fillRect(num * (newZise * 4) - num * 6 + xTr, yTr + selected / numW * newZise - 9, newZise, newZise);
			}
		}
		for (int i = 0; i < 8; i++)
		{
			g.drawImage(Res.imgCell[1], i / 4 * (5 * wCell) + xTr, i % 4 * numCell - 10 + yTr, 0);
		}
		g.setColor(10595790);
		g.drawRect(63 + xTr, -10 + yTr, 84, 168);
	}

	private void paintNewCell(MyGraphics g, int x, int y, int wSmall)
	{
		g.setColor(6513507);
		g.drawRect(x, y, wSmall, wSmall);
		g.setColor(8684162);
		g.drawRect(x + 1, y + 1, wSmall - 2, wSmall - 2);
	}

	private void paintTrade(MyGraphics g)
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				if (j > 2)
				{
					g.drawImage(Res.imgCell[2], j * 33 - 17 + xTr, i * 32 - 8 + yTr, 0);
				}
				if (selectedGD == i * 6 + j && selectedGD != -1 && Canvas.gameTick % 10 == 0)
				{
					g.fillRect(j * 33 - 17 + xTr, i * 32 - 8 + yTr, 34, 34);
				}
				g.drawImage(Res.imgCell[0], j * 33 - 17 + xTr, i * 32 - 8 + yTr, 0);
			}
		}
		mVector tItems = Canvas.gameScr.mainChar.tItems;
		mVector rItems = Canvas.gameScr.mainChar.rItems;
		for (int k = 0; k < tItems.size(); k++)
		{
			paintItemTrade(g, tItems.elementAt(k), k % 3 * 34 - 12 + xTr, k / 3 * 34 + yTr);
		}
		for (int l = 0; l < rItems.size(); l++)
		{
			paintItemTrade(g, rItems.elementAt(l), 102 + l % 3 * 34 - 12 + xTr, l / 3 * 34 + yTr);
		}
		g.setClip(-15 + xTr, 3 * newZise + yTr, 5 * newZise + 10, 3 * newZise);
		g.translate(-cmx, 0);
		int num = -12;
		h = 4 * newZise;
		g.setColor(10595790);
		g.setColor(10595790, 0.5f);
		if (!isPaintfc)
		{
			g.fillRect(selected * smallS + num + xTr, h + yTr + 1, 31, 31);
		}
		g.setColor(10595790);
		for (int m = 0; m < ItemShopNew.size(); m++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(m);
			if (itemInInventory == null)
			{
				continue;
			}
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (item != null)
			{
				g.drawRect(num + xTr - 1, h + yTr, 32, 32);
				if (itemInInventory.isSelling)
				{
					g.setColor(7706352);
					g.fillRect(num + xTr - 1, h + yTr, 32, 32);
				}
				GameData.paintIcon(g, item.idIcon, 20 + (num - 4) + xTr, h + smallS / 2 - 3 + yTr);
				num += smallS;
			}
		}
		for (int n = 0; n < MainChar.listPotion.Length; n++)
		{
			if (MainChar.listPotion[n].number - MainChar.listPotion[n].numTrade > 0 && MainChar.listPotion[n].isTrade)
			{
				g.drawRect(num + xTr - 1, h + yTr, 32, 32);
				GameData.paintIcon(g, (short)(MainChar.listPotion[n].index + 5500), num - 4 + 20 + xTr, h + smallS / 2 - 3 + yTr);
				MFont.smallFont.drawString(g, MainChar.listPotion[n].number - MainChar.listPotion[n].numTrade + string.Empty, num + 22 + xTr, h + smallS / 2 - 2 + yTr, MFont.RIGHT);
				num += smallS;
			}
		}
	}

	public int checktotalItemTrade()
	{
		int num = 0;
		for (int i = 0; i < ItemShopNew.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)ItemShopNew.elementAt(i);
			if (itemInInventory != null)
			{
				ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				if (item != null)
				{
					num++;
				}
			}
		}
		for (int j = 0; j < MainChar.listPotion.Length; j++)
		{
			if (MainChar.listPotion[j].number - MainChar.listPotion[j].numTrade > 0 && MainChar.listPotion[j].isTrade)
			{
				num++;
			}
		}
		return num;
	}

	private void paintItemTrade(MyGraphics g, object item, int x, int y)
	{
		if (item is ItemInInventory)
		{
			((ItemInInventory)item).paint(g, x + 9, y + 9);
			return;
		}
		Potion potion = (Potion)item;
		GameData.paintIcon(g, (short)(potion.index + 5500), x + 9, y + 9);
		MFont.smallFont.drawString(g, potion.number + string.Empty, x + 17, y + 9, MFont.RIGHT);
	}

	private void paintNewSkillLearn(MyGraphics g)
	{
		string[] array = new string[5]
		{
			"Kiếm sỹ",
			"Chiến binh",
			"Pháp sư",
			"Đấu sỹ",
			"Cung thủ"
		};
		MFont.normalFont[0].drawString(g, array[Canvas.gameScr.mainChar.clazz], 7 * wCell / 2 + xTr, -16 + yTr, MFont.CENTER);
		g.setColor(11908533);
		g.fillRect(-4 + xTr, yTr, 7 * wCell, 1);
		int num = 20;
		for (int i = 0; i < numW; i++)
		{
			InfoSkillLearn infoSkillLearn = (InfoSkillLearn)((mVector)GameScr.infoNewSkill.elementAt(Canvas.gameScr.mainChar.clazz)).elementAt(i);
			if (infoSkillLearn != null)
			{
				if (i < 5)
				{
					paintFc(g, i * newZise + 3 + num + xTr, h / 2 + num + yTr, newZise, newZise, i, selected);
					GameData.imgSkillIcon.drawFrame(infoSkillLearn.idSkill, i * newZise + 3 + num + xTr, h / 2 + num + yTr, 0, 3, g);
					g.drawImage(Res.imgCell[1], i * newZise + 3 + num + xTr, h / 2 + num + yTr, 3);
				}
				else if (i >= 5 && i < 10)
				{
					paintFc(g, (i - 5) * newZise + 3 + num + xTr, h / 2 + newZise + num + yTr, newZise, newZise, i, selected);
					GameData.imgSkillIcon.drawFrame(i, (i - 5) * newZise + 3 + num + xTr, h / 2 + newZise + num + yTr, 0, 3, g);
					g.drawImage(Res.imgCell[1], (i - 5) * newZise + 3 + num + xTr, h / 2 + newZise + num + yTr, 3);
				}
				else if (i >= 10)
				{
					paintFc(g, (i - 10) * newZise + 3 + num + xTr, h / 2 + newZise * 2 + num + yTr, newZise, newZise, i, selected);
					GameData.imgSkillIcon.drawFrame(i, (i - 10) * newZise + 3 + num + xTr, h / 2 + newZise * 2 + num + yTr, 0, 3, g);
					g.drawImage(Res.imgCell[1], (i - 10) * newZise + 3 + num + xTr, h / 2 + newZise * 2 + num + yTr, 3);
				}
			}
		}
	}

	public void paintFc(MyGraphics g, int x, int y, int w, int h, int i, int selected)
	{
		if (selected == i && Canvas.gameTick % 10 > 3 && !isPaintfc)
		{
			g.setColor(6513507, 0.5f);
			g.fillRect(x - w / 2, y - h / 2, w, h);
		}
	}

	private void paintKhung(MyGraphics g)
	{
		int num = h + 26;
		if (index[focusTab] == 4)
		{
			num = h;
		}
		g.setColor(11908533);
		g.drawRect(0, -10, w, num);
		g.setClip(0, -10, w, num);
		g.translate(0, 1 - cmy);
	}

	private void paintQuestClan(MyGraphics g)
	{
		Canvas.resetTrans(g);
		Res.paintDlgFull(g, 10, 10, Canvas.w - 20, Canvas.h - 50);
		MFont.normalFont[0].drawString(g, "Nhiệm vụ bang hội", Canvas.hw, 15, MFont.CENTER);
		int num = 45;
		g.setClip(0, num - 1, Canvas.w, h - 32);
		g.translate(0, num);
		for (int i = 0; i < questInfo.size(); i++)
		{
			string st = (string)questInfo.elementAt(i);
			MFont.arialFontW.drawString(g, st, 15, i * 15, 0);
		}
	}

	private void paintSkillClan(MyGraphics g)
	{
		Canvas.resetTrans(g);
		int num = 170;
		int num2 = 130;
		int num3 = (Canvas.w - num) / 2;
		int num4 = (Canvas.h - num2) / 2;
		Res.paintDlgDragonFull(g, num3 - 5, num4 - 10, num + 10, num2 + 20);
		g.setColor(11908533);
		g.drawRect(num3 + 2, num4 + 15, num - 4, num2 - 30);
		MFont.normalFont[0].drawString(g, "Kỹ năng bang hội", num3 + (num + 10) / 2, num4 - 5, MFont.CENTER);
		g.setClip(num3 + 2, num4 + 15, num - 4, num2 - 30);
		g.translate(num3 + 5, num4 + 20);
		g.translate(0, -cmy);
		int num5 = 2;
		for (int i = 0; i < questInfo.size(); i++)
		{
			string text = (string)questInfo.elementAt(i);
			if (text.Length >= 2 && text.Substring(0, 1).Equals("`"))
			{
				string text2 = text.Substring(1, text.Length - 1);
				text = text2;
				MFont.normalFont[0].drawString(g, text, 5, i * 15 + num5, 0);
			}
			else
			{
				MFont.arialFontW.drawString(g, text, 5, i * 15 + num5, 0);
			}
		}
		Canvas.resetTrans(g);
		MFont.smallFontColor[0].drawString(g, Canvas.gameScr.mainChar.charXu + "$", num3 + num - 10, num4 + num2 - 10, 1);
		MFont.smallFontColor[0].drawString(g, Canvas.gameScr.mainChar.luong + "L", num3 + 10, num4 + num2 - 10, 0);
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
		if (infoQuestPaint.Equals(string.Empty) && infoQuestPaint2.Equals(string.Empty))
		{
			MFont.arialFontW.drawString(g, "Chưa nhận nhiệm vụ", 8 + xTr, -7 + yTr, 0);
			return;
		}
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
			MFont.normalFont[0].drawString(g, array[0], 4, num * 15 - 8 + yTr, 0);
			for (int j = 1; j < array.Length; j++)
			{
				MFont.arialFontW.drawString(g, array[j], 4, j * 15 - 8 + yTr, 0);
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
			MFont.normalFont[0].drawString(g, array[0], 4, num * 15 - 8 + yTr, 0);
			for (int l = 1; l < array.Length; l++)
			{
				MFont.arialFontW.drawString(g, array[l], 4, (l + num) * 15 - 8 + yTr, 0);
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
			MFont.normalFont[0].drawString(g, array[0], 4, num * 15 - 8 + yTr, 0);
			for (int n = 1; n < array.Length; n++)
			{
				MFont.arialFontW.drawString(g, array[n], 4, (n + num) * 15 - 8 + yTr, 0);
			}
			num = array.Length;
		}
	}

	private void paintParty(MyGraphics g)
	{
		paintKhung(g);
		int num = Char.party.size();
		if (num > 0)
		{
			g.setColor(6448384);
			g.fillRect(2, selected * 32, 131, 32);
			for (int i = 0; i < num; i++)
			{
				PartyInfo partyInfo = (PartyInfo)Char.party.elementAt(i);
				MFont.arialFontW.drawString(g, "NV:" + partyInfo.name, 8, i * 33, 0);
				MFont.arialFontW.drawString(g, "LV: " + partyInfo.lv, 8, (i * 2 + 1) * 16, 0);
				g.setColor(65535);
				g.fillRect(2, (i * 2 + 1) * 16 + 15, 131, 1);
			}
		}
		else
		{
			MFont.arialFontW.drawString(g, "Chưa có nhóm", 8, -3, 0);
		}
	}

	private void paintCharInfo(MyGraphics g)
	{
		paintKhung(g);
		if (charInfo != null)
		{
			for (int i = 0; i < charInfo.Length; i++)
			{
				MFont.arialFontW.drawString(g, charInfo[i], 4, 5 + i * 12 - 8, 0);
			}
		}
	}

	private void paintSkill(MyGraphics g)
	{
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.skillPointLeft + string.Empty, 105, -16, MFont.CENTER);
		MFont.normalFont[0].drawString(g, "Điểm kỹ năng: ", 60, -22, MFont.CENTER);
		g.setColor(11908533);
		g.fillRect(-8, -8, 133, 1);
		g.fillRect(-8, 26, 133, 1);
		g.setClip(-8, -8, w + 20, h + 8);
		g.translate(-cmx, 0);
		if (!isChangeTab && Canvas.gameTick % 10 > 3)
		{
			g.setColor(589295);
			g.fillRect(selected * wSmall + 3, 5 - h / 4, wSmall - 6, hSmall + h / 4 - 3);
		}
		for (int i = 0; i < numW; i++)
		{
			GameData.imgSkillIcon.drawFrame(i, i * wSkill + wSmall / 2, h / 2 - h / 4 + 2, 0, 3, g);
			g.drawImage(Res.imgKhung, i * wSkill + wSmall / 2, h / 2 - h / 4 + 2, 3);
			MFont.smallFontColor[1].drawString(g, Char.skillLevelLearnt[i] + string.Empty, i * wSkill + wSmall - 4, h / 2 - 1, MFont.RIGHT);
		}
		if (!isChangeTab)
		{
			if (selected < 0)
			{
				selected = 0;
			}
			else if (selected > SkillManager.SKILL_NAME[Canvas.gameScr.mainChar.clazz].Length - 1)
			{
				selected = SkillManager.SKILL_NAME[Canvas.gameScr.mainChar.clazz].Length - 1;
			}
			g.translate(cmx, 0);
			g.setClip(-11, 28, 138, 72);
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
			MFont.normalFont[0].drawString(g, text, -5, 30, 0);
			int num = 40;
			for (int j = 0; j < infoSkill.Length; j++)
			{
				MFont.arialFontW.drawString(g, infoSkill[j], -5, num, 0);
				num += 12;
			}
		}
	}

	private void paintFeatures(MyGraphics g)
	{
		if (!isChangeTab)
		{
			if (selected > 4)
			{
				selected = 4;
			}
			g.setColor(7278866);
			g.fillRect(3, selected * 19, 121, 18);
		}
		g.drawImage(Res.imgBGTiemNang, 0, -20, 0);
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.basePointLeft + string.Empty, 107, -11, MFont.CENTER);
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.strength + string.Empty, 107, 8, MFont.CENTER);
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.agility + string.Empty, 107, 27, MFont.CENTER);
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.spirit + string.Empty, 107, 46, MFont.CENTER);
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.health + string.Empty, 107, 65, MFont.CENTER);
		MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.luck + string.Empty, 107, 84, MFont.CENTER);
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
		charWearing.paintAvatar(g, (short)(90 + xTr), (short)(110 + yTr));
		if (imgCharWear != null && Canvas.gameTick % 16 >= 8)
		{
			g.drawImage(imgCharWear, w / 2 + 5 + xTr, -5 + yTr, MyGraphics.TOP | MyGraphics.HCENTER);
		}
		g.setColor(14605278);
		g.drawRect(39 + xTr, -10 + yTr, 104, 208);
		g.fillRect(43 + xTr, -10 + yTr + 175, 30, 30);
		g.fillRect(110 + xTr, -10 + yTr + 175, 30, 30);
		for (int i = 0; i < 5; i++)
		{
			g.fillRect(-3 + xTr, -10 + i * numCell + yTr, 40, 40);
			g.fillRect(147 + xTr, -10 + i * numCell + yTr, 40, 40);
		}
		g.setColor(4802889);
		g.fillRect(44 + xTr, -10 + yTr + 176, 28, 28);
		g.fillRect(111 + xTr, -10 + yTr + 176, 28, 28);
		for (int j = 0; j < 5; j++)
		{
			g.fillRect(-2 + xTr, -9 + j * numCell + yTr, 38, 38);
			g.fillRect(148 + xTr, -9 + j * numCell + yTr, 38, 38);
		}
		if (Canvas.gameTick % 10 > 3 && isPaintFc)
		{
			g.setColor(10595790, 0.5f);
			if (selected % 3 != 1)
			{
				int num = 0;
				if (selected == 2 || selected == 5 || selected == 8 || selected == 11 || selected == 14)
				{
					num = 1;
				}
				g.fillRect(-2 + num * 150 + xTr, selected / numW * numCell - 9 + yTr, 38, 38);
			}
			else if (selected != 4)
			{
				g.fillRect(111 + xTr, -10 + yTr + 176, 28, 28);
			}
			else
			{
				g.fillRect(44 + xTr, -10 + yTr + 176, 28, 28);
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
			GameData.paintIcon(g, (short)(charWearing.idPaintIconAnimal + 7500), 125 + xTr, 180 + yTr);
		}
	}

	private void paintAnimalWearing(MyGraphics g)
	{
		if (charWearing != null && (charWearing.imgAnimal != null || charWearing.idhorse > -1) && (charWearing.useHorse != -1 || charWearing.idhorse > -1))
		{
			g.drawRegion(charWearing.imgAnimal, 0, charWearing.himg * idFrame, charWearing.wimg, charWearing.himg, 0, Res.imgInfoWindow[0].getWidth() / 2 + xTr, Res.imgInfoWindow[0].getHeight() / 2 - 5 + yTr, 3);
		}
		g.drawImage(Res.imgInfoWindowt, -3 + xTr, -10 + yTr, 0);
		g.setColor(14605278);
		for (int i = 0; i < 5; i++)
		{
			g.fillRect(-3 + xTr, -10 + i * numCell + yTr, 40, 40);
			g.fillRect(147 + xTr, -10 + i * numCell + yTr, 40, 40);
		}
		g.setColor(4802889);
		for (int j = 0; j < 5; j++)
		{
			g.fillRect(-2 + xTr, -9 + j * numCell + yTr, 38, 38);
			g.fillRect(148 + xTr, -9 + j * numCell + yTr, 38, 38);
		}
		if (Canvas.gameTick % 10 > 3 && isPaintFc)
		{
			g.setColor(10595790, 0.5f);
			if (selected % 2 == 0)
			{
				g.fillRect(-2 + xTr, selected / 2 * numCell - 9 + yTr, 38, 38);
			}
			else
			{
				g.fillRect(148 + xTr, selected / 2 * numCell - 9 + yTr, 38, 38);
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

	private void paintShowText(MyGraphics g)
	{
		g.setColor(25695);
		g.fillRect(xShow, yShow, wShow, hShow + countPop * 15);
		g.setColor(16774720);
		g.drawRect(xShow, yShow, wShow - 1, hShow - 1 + countPop * 15);
		int num = 0;
		g.setClip(xShow, yShow, wShow, hShow + countPop * 15 - 2);
		g.translate(0, -cmyText);
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
	}

	public static bool isDegit(char c)
	{
		return c >= '0' && c <= '9';
	}

	private void paintBag(MyGraphics g)
	{
		try
		{
			int num = cmy / (hSmall + 10) * 5;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num + 45;
			if (num2 > numCell)
			{
				num2 = numCell;
			}
			if (countTabMyitem * numCell + numCell > maxSize)
			{
				num2 = excess;
			}
			for (int i = num; i < num2; i++)
			{
				if (isLoad)
				{
					break;
				}
				int num3 = i + countTabMyitem * numCell;
				if (num3 < list.size())
				{
					((Command)list.elementAt(num3))?.paint(g, i % 5 * (wSmall + 10) + (wSmall + 10) / 2 - 7, i / 5 * (hSmall + 10) + (hSmall + 10) / 2 - 10);
				}
			}
		}
		catch (Exception ex)
		{
			Out.println("ERROR hanh trang " + ex.ToString());
		}
	}

	private void paintProduct(MyGraphics g)
	{
	}

	private void getShopTemplate()
	{
	}

	public void closeText()
	{
		isShowText = false;
		arrayKhamNgoc = null;
	}

	private void setShowText(string text, int x1, int y1)
	{
		setShowTextNew(text, x1, y1);
	}

	public void doBuyShopSpecial()
	{
		ActionPerform action = delegate
		{
			if (selected < Res.shopTemplate.size())
			{
				if (Canvas.gameScr.mainChar.isFullInventory())
				{
					Canvas.startOKDlg("Hành trang đã đầy.");
				}
				else
				{
					int num = 0;
					int num2 = 0;
					while (true)
					{
						if (num2 >= Res.shopTemplate.size())
						{
							return;
						}
						GemTemp gemTemp = (GemTemp)Res.shopTemplate.elementAt(num2);
						if (gemTemp.shopType == focusTab && gemTemp.isSell)
						{
							if (num == selected)
							{
								break;
							}
							num++;
						}
						num2++;
					}
					GemTemp item = (GemTemp)Res.shopTemplate.elementAt(num2);
					ActionPerform yesAction = delegate
					{
						GameService.gI().buyItemShopSpecial(item.id);
						Canvas.startWaitDlg();
					};
					Canvas.startYesNoDlg("Bạn có muốn mua vật phẩm này không ?", yesAction);
				}
			}
		};
		cmdShop = new Command();
		cmdShop.action = action;
	}

	public int getCountPotion(int i)
	{
		return 0;
	}

	public mVector getInventori()
	{
		mVector mVector = new mVector();
		int num = 0;
		try
		{
			for (int i = 0; i < ItemShopNew.size(); i++)
			{
				int ii = num;
				ItemInInventory item = (ItemInInventory)ItemShopNew.elementAt(i);
				Command command = new Command();
				ActionPerform action = delegate
				{
					showItemInventoryInfo(item, isSell, ii % numW * 18, ii / numW * 18);
				};
				ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
				{
					if (item.isSelling)
					{
						g.setColor(7706352);
						g.fillRect(x - 8, y - 8, 16, 16);
					}
					item.paint(g, x, y);
				};
				command.action = action;
				command.actionPaint = actionPaint;
				mVector.addElement(command);
				num++;
			}
			return mVector;
		}
		catch (Exception)
		{
			return mVector;
		}
	}

	protected void showGemItemInfo(short id, int xx, int yy)
	{
		GemTemp gemByID = Res.getGemByID(id);
		string str = ItemInInventory.setTemp(gemByID.name, "0");
		str += ItemInInventory.setTemp(gemByID.decript, "0");
		if (isSell)
		{
			str += ItemInInventory.setTemp("Giá bán lại: " + gemByID.price / 5, "0");
		}
		if (index[focusTab] == 28 || index[focusTab] == 26 || isDefault || index[focusTab] == 22 || index[focusTab] == 23)
		{
			setShowTextNew(str, xx, yy);
		}
		else
		{
			setShowText(str, xx, yy);
		}
	}

	protected void showGemItemKhoaInfo(short id, int xx, int yy)
	{
		GemTemp gemByID = Res.getGemByID(id);
		string str = ItemInInventory.setTemp(gemByID.name, "0");
		str += "- Đã khóa";
		str += ItemInInventory.setTemp(gemByID.decript, "0");
		if (isSell)
		{
			str += ItemInInventory.setTemp("Giá bán lại: " + gemByID.price / 5, "0");
		}
		if (index[focusTab] == 28 || index[focusTab] == 26 || isDefault || index[focusTab] == 22 || index[focusTab] == 23)
		{
			setShowTextNew(str, xx, yy);
		}
		else
		{
			setShowText(str, xx, yy);
		}
	}

	protected void showRealIDInfo(RealID real, int xx, int yy)
	{
		GemTemp gemByID = Res.getGemByID(real.ID);
		string str = ItemInInventory.setTemp(gemByID.name, "0");
		str += ItemInInventory.setTemp(gemByID.decript, "0");
		if (isSell)
		{
			str += ItemInInventory.setTemp("Giá bán : " + real.price, "0");
		}
		if (isDefault)
		{
			setShowTextNew(str, xx, yy);
		}
		else
		{
			setShowText(str, xx, yy);
		}
	}

	protected void showShopItemInfo(short id, int count)
	{
		GemTemp shopByID = Res.getShopByID(id);
		string str = ItemInInventory.setTemp(shopByID.name, "0");
		str += ItemInInventory.setTemp(shopByID.decript, "0");
		if (isSell)
		{
			str += ItemInInventory.setTemp("Giá bán lại: " + Canvas.getMoneys(shopByID.price / 5), "0");
		}
		if (isDefault)
		{
			setShowTextNew(str, count % numW * 18, count / numW * 18);
		}
		else
		{
			setShowText(str, count % numW * 18, count / numW * 18);
		}
	}

	public string getInfoItemQuest(int id)
	{
		string arg = "0" + ItemQuest.NAME_ITEM[id];
		return arg + "\nSố lượng: " + MainChar.itemQuest[id];
	}

	private string getPotionInfo(int aa)
	{
		return string.Empty;
	}

	public void doSelectedInventori()
	{
		int element = selected + ((index[focusTab] == 0) ? (countTabMyitem * numCell) : 0);
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
			GemTemplate shop = (GemTemplate)MainChar.shopItem.elementAt(num);
			mVector mVector = new mVector();
			Command command = new Command("Sử dụng");
			ActionPerform actionPerform = command.action = delegate
			{
				GameService.gI().doUseSpecialItem(shop.rID);
			};
			mVector.addElement(command);
			mVector.addElement(cmdDelItem(shop, 1, MainChar.shopItem, 0));
			Canvas.menu.startAt(mVector, 2);
			return;
		}
		num -= MainChar.shopItem.size();
		if (num < MainChar.gemItemKhoa.size())
		{
			GemTemplate item = (GemTemplate)MainChar.gemItemKhoa.elementAt(num);
			if (isSell)
			{
				GemTemp gemByID = Res.getGemByID(item.id);
				ActionPerform yesAction = delegate
				{
					GameService.gI().sellGemItem(item.rID, 1);
					Canvas.startWaitDlg("Đang bán..", isIcon: true);
					list.removeElementAt(element);
				};
				Canvas.startYesNoDlg("Bạn có muốn bán vật phẩm này với giá " + gemByID.price / 5 + "$ không?", yesAction);
				return;
			}
			mVector mVector2 = new mVector();
			GemTemp gemByID2 = Res.getGemByID(item.id);
			if (gemByID2 != null && gemByID2.type == 4)
			{
				Command command2 = new Command("Sử dụng");
				command2.action = delegate
				{
					GameService.gI().douseGemItem(item.id, 1);
				};
				mVector2.addElement(command2);
			}
			mVector2.addElement(cmdDelItem(item, 0, MainChar.gemItemKhoa, 1));
			Canvas.menu.startAt(mVector2, 2);
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
			mVector mVector3 = new mVector();
			GemTemp gemByID4 = Res.getGemByID(item2.id);
			if (gemByID4 != null && gemByID4.type == 4)
			{
				Command command3 = new Command("Sử dụng");
				command3.action = delegate
				{
					GameService.gI().douseGemItem(item2.id, 0);
				};
				mVector3.addElement(command3);
			}
			mVector3.addElement(cmdDelItem(item2, 0, MainChar.gemItem, 0));
			Canvas.menu.startAt(mVector3, 2);
			return;
		}
		num -= MainChar.gemItem.size();
		if (num < Char.animal.size())
		{
			AnimalInfo shop2 = (AnimalInfo)Char.animal.elementAt(num);
			mVector mVector4 = new mVector();
			Command command4 = new Command("Sử dụng");
			ActionPerform actionPerform2 = command4.action = delegate
			{
				if ((Canvas.gameScr.mainChar.useHorse > -1 || Canvas.gameScr.mainChar.idhorse > -1) && shop2.typeAnimal == 0)
				{
					Canvas.startOKDlg("Không thể cưỡi.");
				}
				else
				{
					GameService.gI().doRideAnimal(shop2.id, shop2.typeAnimal);
				}
			};
			mVector4.addElement(command4);
			Canvas.menu.startAt(mVector4, 2);
			return;
		}
		num -= Char.animal.size();
		if (num >= ItemShopNew.size())
		{
			return;
		}
		ItemInInventory item3 = (ItemInInventory)ItemShopNew.elementAt(num);
		if (!isSell)
		{
			mVector mVector5 = new mVector();
			Command command5 = new Command("Sử dụng");
			ActionPerform actionPerform3 = command5.action = delegate
			{
				doUseItem(item3);
			};
			mVector5.addElement(command5);
			if (item3.colorName == 1 && item3.level >= 50 && !ItemInInventory.isAnimalArmor(item3.getTemplate().type))
			{
				Command command6 = new Command("Tách trang bị");
				command6.action = delegate
				{
					ActionPerform yesAction5 = delegate
					{
						GameService.gI().doRequestTachNguyenLIeu(item3.itemID, 0, -1, 0);
						Canvas.endDlg();
					};
					Canvas.startYesNoDlg("Bạn có muốn tách nguyên liệu từ vật phẩm này không?", yesAction5);
				};
				mVector5.addElement(command6);
			}
			Command command7 = new Command("Bỏ ra đất");
			ActionPerform actionPerform4 = command7.action = delegate
			{
				ActionPerform yesAction4 = delegate
				{
					GameService.gI().giveItemToGround(item3.itemID);
					Canvas.endDlg();
					list.removeElementAt(element);
				};
				Canvas.startYesNoDlg("Vật phẩm sẽ mất khi bạn bỏ ra đất. Bạn có muốn tiếp tục không?", yesAction4);
			};
			mVector5.addElement(command7);
			if (item3.colorName != 0 && item3.colorName != 4)
			{
				if (item3.colorName == 1)
				{
					Command command8 = new Command("Sử dụng");
					ActionPerform actionPerform5 = command8.action = delegate
					{
						GameService.gI().doRequestActionCheDo(10, item3.itemID);
					};
					mVector5.addElement(command8);
					Command command9 = new Command("Thăng cấp thuộc tính ");
					ActionPerform actionPerform6 = command9.action = delegate
					{
						GameService.gI().doRequestActionCheDo(11, item3.itemID);
					};
					mVector5.addElement(command9);
				}
				if (item3.nameCharSeal.Equals(string.Empty))
				{
					Command command10 = new Command("Đóng dấu");
					ActionPerform actionPerform7 = command10.action = delegate
					{
						GameService.gI().doRequestActionCheDo(14, item3.itemID);
					};
					mVector5.addElement(command10);
				}
				if (!item3.nameCharSeal.ToLower().Equals(Canvas.gameScr.mainChar.name.ToLower()))
				{
					Command command11 = new Command(" ");
					ActionPerform actionPerform8 = command11.action = delegate
					{
						GameService.gI().doRequestActionCheDo(14, item3.itemID);
					};
					mVector5.addElement(command11);
				}
				else
				{
					ItemTemplate item4 = Res.getItem(item3.charClazz, item3.idTemplate);
					if ((item4.type >= 3 && item4.type <= 7) || item4.type == 8 || item4.type == 9)
					{
						Command command12 = new Command("Sửa thuộc tính kỹ năng");
						ActionPerform actionPerform9 = command12.action = delegate
						{
							GameService.gI().doRequestActionCheDo(15, item3.itemID);
						};
						mVector5.addElement(command12);
					}
				}
				if (item3.islock == 0)
				{
					Command command13 = new Command("Khoá");
					ActionPerform actionPerform10 = command13.action = delegate
					{
						GameService.gI().doRequestActionCheDo(12, item3.itemID);
					};
					mVector5.addElement(command13);
				}
				if (item3.islock == 1)
				{
					Command command14 = new Command("Khoá lại");
					ActionPerform actionPerform11 = command14.action = delegate
					{
						GameService.gI().doRequestActionCheDo(12, item3.itemID);
					};
					mVector5.addElement(command14);
				}
				Command command15 = new Command(" ");
				ActionPerform actionPerform12 = command15.action = delegate
				{
					GameService.gI().doRequestActionCheDo(13, item3.itemID);
				};
				mVector5.addElement(command15);
			}
			Canvas.menu.startAt(mVector5, 2);
		}
		else
		{
			ItemTemplate item5 = Res.getItem(item3.charClazz, item3.idTemplate);
			ActionPerform yesAction3 = delegate
			{
				GameService.gI().sellItem(item3.itemID);
				Canvas.startWaitDlg("Đang bán..", isIcon: true);
				list.removeElementAt(element);
			};
			Canvas.startYesNoDlg("Bạn có muốn bán vật phẩm này với giá " + (item5.price / 5 + item5.plus * 1000) + "$ không?", yesAction3);
		}
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

	protected void doSellItem()
	{
	}

	private Command cmdDelItem(GemTemplate item, int index, mVector lit, sbyte khoa)
	{
		Command command = new Command("Bỏ ra đất");
		ActionPerform actionPerform = command.action = delegate
		{
			ActionPerform yesAction = delegate
			{
				GameService.gI().dellGemItem(item.id, index, khoa);
				Canvas.endDlg();
			};
			Canvas.startYesNoDlg("Bạn có muốn bỏ hết vật phẩm này không ?", yesAction);
		};
		return command;
	}

	private void showMenuForPotion(int potionType)
	{
	}

	private bool isWeapone(int type)
	{
		return type >= 3 && type <= 7;
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
					if (selected != 4)
					{
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
					}
				}
				else if (index.Length == 1)
				{
					if (selected != 4)
					{
						mVector mVector = new mVector();
						Command command = new Command("Thông tin");
						ActionPerform actionPerform = command.action = delegate
						{
							setShowTextNew(charWearing.infoAnimal, 100, 120);
							Canvas.endDlg();
						};
						command.perform();
						Command command2 = new Command("Trang bị linh thú");
						ActionPerform actionPerform2 = command2.action = delegate
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
						mVector.addElement(command2);
						Canvas.menu.startAt(mVector, 3);
					}
					else
					{
						int num3 = charWearing.wearingItems.size();
						int num4 = 0;
						ItemInInventory itemInInventory2;
						while (true)
						{
							if (num4 >= num3)
							{
								return;
							}
							itemInInventory2 = (ItemInInventory)charWearing.wearingItems.elementAt(num4);
							ItemTemplate item2 = Res.getItem(itemInInventory2.charClazz, itemInInventory2.idTemplate);
							if (item2.type == 19)
							{
								break;
							}
							num4++;
						}
						showItemInventoryInfo(itemInInventory2, isSell: false, posWearChar[9][0] + 5, posWearChar[9][1] - 2);
					}
				}
				else if (selected != 4)
				{
					mVector mVector2 = new mVector();
					Command command3 = new Command("Linh thú");
					ActionPerform actionPerform3 = command3.action = delegate
					{
						if (!charWearing.infoAnimal.Equals(string.Empty))
						{
							setShowText(charWearing.infoAnimal, 80, 120);
						}
					};
					mVector2.addElement(command3);
					Command command4 = new Command("Thú cưng");
					ActionPerform actionPerform4 = command4.action = delegate
					{
						if (charWearing.myPet != null)
						{
							setShowText(ItemInInventory.setTemp(charWearing.myPet.infoPet, "0") + ItemInInventory.setTemp("Còn lại: " + (charWearing.myPet.totalTime - (mSystem.getCurrentTimeMillis() - charWearing.myPet.timeStart) / 60000) + " phút", "0"), 80, 120);
						}
					};
					mVector2.addElement(command4);
					Canvas.menu.startAt(mVector2, 3);
				}
				else
				{
					int num5 = charWearing.wearingItems.size();
					int num6 = 0;
					ItemInInventory itemInInventory3;
					while (true)
					{
						if (num6 >= num5)
						{
							return;
						}
						itemInInventory3 = (ItemInInventory)charWearing.wearingItems.elementAt(num6);
						ItemTemplate item3 = Res.getItem(itemInInventory3.charClazz, itemInInventory3.idTemplate);
						if (item3.type == 19)
						{
							break;
						}
						num6++;
					}
					showItemInventoryInfo(itemInInventory3, isSell: false, posWearChar[9][0] + 5, posWearChar[9][1] - 2);
				}
			}
			else
			{
				num2 = selected / 3 * 2 + (selected % 3 - ((selected % 3 > 0) ? 1 : 0));
				int num7 = 0;
				ItemInInventory itemInInventory4;
				while (true)
				{
					if (num7 >= charWearing.wearingItems.size())
					{
						return;
					}
					itemInInventory4 = (ItemInInventory)charWearing.wearingItems.elementAt(num7);
					ItemTemplate item4 = Res.getItem(itemInInventory4.charClazz, itemInInventory4.idTemplate);
					if (item4.type == idWearChar[num2] || (idWearChar[num2] == -1 && item4.type > 2 && item4.type < 8))
					{
						num++;
						if (num2 != 7 || num != 1)
						{
							break;
						}
					}
					num7++;
				}
				showItemInventoryInfo(itemInInventory4, isSell: false, posWearChar[num2][0] + 5, posWearChar[num2][1] - 2);
			}
		}
		catch (Exception)
		{
			Out.println("Ngoai mang");
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

	private void showInfoWearingAnimal()
	{
		try
		{
			int num = 0;
			int num2 = 0;
			if (charWearing.wearingAnimal != null && charWearing.wearingAnimal.size() > 0)
			{
				int num3 = 0;
				ItemInInventory itemInInventory;
				while (true)
				{
					if (num3 >= charWearing.wearingAnimal.size())
					{
						return;
					}
					itemInInventory = (ItemInInventory)charWearing.wearingAnimal.elementAt(num3);
					ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
					if (item.type == idWearAnimal[selected])
					{
						break;
					}
					num3++;
				}
				num++;
				showItemInventoryAnimalInfo(itemInInventory, isSell: false, posWearChar[num2][0] + 5, posWearChar[num2][1] - 2);
			}
		}
		catch (Exception)
		{
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
						sbyte[] array = arrayKhamNgoc;
						sbyte num = b;
						b = (sbyte)(num + 1);
						array[num] = Res.idNgocKham[infoAttributeItem.getID() - 10];
					}
					break;
				}
			}
		}
		if (index[focusTab] == 21 || index[focusTab] == 25 || index[focusTab] == 32 || isDefault || index[focusTab] == 22 || index[focusTab] == 23 || index[focusTab] == 1 || index[focusTab] == 31 || index[focusTab] == 8)
		{
			setShowTextNew(item.getDescription(isSell), 145, -10);
		}
		else
		{
			setShowText(item.getDescription(isSell), x, y);
		}
		if (!item.isEnoughData)
		{
			item.isEnoughData = true;
			GameService.gI().requestItemInfo(item.itemID, (charWearing != null) ? charWearing.ID : Canvas.gameScr.mainChar.ID);
		}
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
			if (!text.Equals(string.Empty))
			{
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
			}
		};
		Canvas.inputDlg.setInfo("Nhập số", ok, TField.INPUT_TYPE_NUMERIC, 10, isMaxW: true);
		Canvas.inputDlg.show();
	}

	public void setCmdLeftTrade()
	{
		ActionPerform action = delegate
		{
			closeText();
			Canvas.gameScr.gameService.sendOkTrade(Canvas.gameScr.mainChar.ID);
			left = new Command("Xin chờ");
			ActionPerform action2 = delegate
			{
				Canvas.gameScr.gameService.sendCancelTrade(Canvas.gameScr.mainChar.ID);
				Canvas.gameScr.mainChar.isTrade = false;
				Canvas.currentDialog = null;
			};
			left.action = action2;
		};
		left = new Command("Xong");
		left.action = action;
	}

	public void setListSellItem(mVector itemsSell, int type)
	{
		list.removeAllElements();
		int num = 0;
		for (int i = 0; i < itemsSell.size(); i++)
		{
			ItemInInventory item = (ItemInInventory)Canvas.gameScr.shop.elementAt(i);
			ItemTemplate item2 = Res.getItem(item.charClazz, item.idTemplate);
			if (item2.type == type || type == -1)
			{
				int co = num;
				num++;
				Command command = new Command();
				ActionPerform action = delegate
				{
					if (isDefault || index[focusTab] == 22 || index[focusTab] == 23)
					{
						setShowTextNew(item.getTemplateDescription(), co % numW * 18, co / numW * 18);
					}
					else
					{
						setShowText(item.getTemplateDescription(), co % numW * 18, co / numW * 18);
					}
				};
				ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
				{
					item.paint(g, x, y);
				};
				command.action = action;
				command.actionPaint = actionPaint;
				list.addElement(command);
			}
		}
	}

	private bool setMaxxreadyBuy()
	{
		if (readyBuy.size() >= 100)
		{
			Canvas.startOKDlg("Bạn chỉ được mua 100 vật phẩm một lần.");
			return true;
		}
		return false;
	}

	private void doSetLeftSellWeapon(int type)
	{
		cmdShop = new Command();
		cmdShop.action = delegate
		{
			if (!setMaxxreadyBuy())
			{
				ItemInInventory itemInInventory = null;
				int num = 0;
				if (type != -1)
				{
					for (int i = 0; i < Canvas.gameScr.shop.size(); i++)
					{
						ItemInInventory itemInInventory2 = (ItemInInventory)Canvas.gameScr.shop.elementAt(i);
						ItemTemplate item2 = Res.getItem(itemInInventory2.charClazz, itemInInventory2.idTemplate);
						if (item2.type == type)
						{
							if (num == selected)
							{
								itemInInventory = itemInInventory2;
								break;
							}
							num++;
						}
					}
				}
				else
				{
					itemInInventory = (ItemInInventory)Canvas.gameScr.shop.elementAt(selected);
				}
				ItemInInventory item = itemInInventory;
				if (Canvas.gameScr.mainChar.FullInventory() >= GameScr.MAX_INVENTORY * Canvas.gameScr.mainChar.limItemBag)
				{
					setShowText("Hành trang đã đầy", selected % numW * 18, selected / numW * 18);
				}
				else
				{
					ItemTemplate itt = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
					if (itt.price > Canvas.gameScr.mainChar.charXu)
					{
						Canvas.startOKDlg("Hết tiền");
					}
					else
					{
						string empty = string.Empty;
						empty = ((itt.ndayLoan != 0) ? ("Bạn có muốn thuê " + itt.name + ", Giá: " + itt.price + "Lượng không?") : ("Bạn có muốn mua " + itt.name + ", Giá: " + itt.price + "$ không?"));
						ActionPerform yesAction = delegate
						{
							Canvas.gameScr.mainChar.charXu -= itt.price;
							readyBuy.addElement(item);
							Canvas.startOKDlg("Đã mua. Món đồ đang ở trong hành trang.", isIcon: false);
						};
						Canvas.startYesNoDlg(empty, yesAction);
					}
				}
			}
		};
	}

	private void dosetLeftSellGemItem()
	{
		int number;
		ActionPerform action = delegate
		{
			ShopNew shopNew = this;
			if (!setMaxxreadyBuy())
			{
				GemTemp selectedGemItem = (GemTemp)Canvas.gameScr.shop.elementAt(selected);
				bool flag = false;
				int num = 0;
				GemTemplate gemByID = GemTemplate.getGemByID(selectedGemItem.id);
				if (gemByID != null)
				{
					num = gemByID.number;
					flag = true;
				}
				if (!flag && Canvas.gameScr.mainChar.isFullInventory())
				{
					setShowText("Hành trang đã đầy", selected % numW * 18, selected / numW * 18);
				}
				else
				{
					GemTemp g = Res.getGemByID(selectedGemItem.id);
					int numm = num;
					ActionPerform ok = delegate
					{
						try
						{
							number = int.Parse(Canvas.inputDlg.tfInput.getText());
							if (number >= 0)
							{
								if ((g.typeMoney == 0 && g.price * number > Canvas.gameScr.mainChar.charXu) || (g.typeMoney == 1 && g.price * number > Canvas.gameScr.mainChar.luong))
								{
									shopNew.setShowText("Hết tiền", shopNew.selected % shopNew.numW * 18, shopNew.selected / shopNew.numW * 18);
								}
								else
								{
									ActionPerform yesAction = delegate
									{
										int num2 = 0;
										for (int i = 0; i < shopNew.readyBuy.size(); i++)
										{
											GemTemp gemTemp = (GemTemp)shopNew.readyBuy.elementAt(i);
											if (gemTemp.id == selectedGemItem.id)
											{
												if (numm + gemTemp.number + number <= 300)
												{
													gemTemp.number += (short)number;
													num2 = 1;
													break;
												}
												Canvas.startOKDlg("Không được mua nhiều hơn 300 cái.");
												return;
											}
										}
										if (num2 == 0)
										{
											GemTemp o = new GemTemp
											{
												id = selectedGemItem.id,
												number = (short)number
											};
											shopNew.readyBuy.addElement(o);
										}
										if (g.typeMoney == 0)
										{
											Canvas.gameScr.mainChar.charXu -= g.price * number;
										}
										else
										{
											Canvas.gameScr.mainChar.luong -= g.price * number;
										}
										Canvas.startOKDlg("Đã mua. Món đồ đang ở trong hành trang.");
									};
									Canvas.startYesNoDlg("Bạn có muốn mua " + number + " " + g.name + ", Giá: " + g.price * number + ((g.typeMoney != 0) ? "lượng" : "$") + " không?", yesAction);
								}
							}
						}
						catch (Exception)
						{
							Canvas.startOKDlg("Chỉ được nhập số.");
						}
					};
					Canvas.inputDlg.setInfo("Số lượng: ", ok, TField.INPUT_TYPE_NUMERIC, 4, isMaxW: true);
					Canvas.inputDlg.show();
				}
			}
		};
		cmdShop = new Command();
		cmdShop.action = action;
	}

	private void setListSellGemItem(mVector shop)
	{
		list.removeAllElements();
		for (int i = 0; i < shop.size(); i++)
		{
			GemTemp gem = (GemTemp)shop.elementAt(i);
			int ii = i;
			if (gem.isSell)
			{
				Command command = new Command();
				ActionPerform action = delegate
				{
					string text = ItemInInventory.setTemp(gem.name, "0") + ItemInInventory.setTemp(gem.decript, "0") + ItemInInventory.setTemp("Giá: " + gem.price + ((gem.typeMoney != 0) ? " lượng" : " xu"), "0");
					if (isDefault || index[focusTab] == 22 || index[focusTab] == 23)
					{
						setShowTextNew(text, ii % numW * 18, ii / numW * 18);
					}
					else
					{
						setShowText(text, ii % numW * 18, ii / numW * 18);
					}
				};
				ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
				{
					Res.paintGem(g, gem.idImage, x, y);
				};
				command.action = action;
				command.actionPaint = actionPaint;
				list.addElement(command);
			}
		}
	}

	private void setListPotion()
	{
		list.removeAllElements();
		for (int i = 0; i < Canvas.gameScr.shop.size(); i++)
		{
			ItemInInventory item = (ItemInInventory)Canvas.gameScr.shop.elementAt(i);
			Command command = new Command();
			ActionPerform action = delegate
			{
				setShowTextNew(item.getTemplateDescription(), selected % numW * 18, selected / numW * 18);
			};
			ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
			{
				GameData.paintIcon(g, (short)(MainChar.listPotion[item.potionType].index + 5500), x, y);
			};
			command.action = action;
			command.actionPaint = actionPaint;
			list.addElement(command);
		}
	}

	private void doSetLeftPotion()
	{
	}

	public void doBuyItem()
	{
		if (readyBuy.size() > 0)
		{
			Canvas.startWaitDlg("Xin chờ", isIcon: true);
			if (index[focusTab] == 10)
			{
				GameService.gI().buyGemItem(readyBuy);
			}
			else if (index[focusTab] == 19)
			{
				GameService.gI().buyPotion(readyBuy);
			}
			else
			{
				GameService.gI().buyItem(readyBuy);
			}
			readyBuy.removeAllElements();
		}
		if (index[focusTab] == 21 || index[focusTab] == 25)
		{
			if (index[focusTab] == 21)
			{
				GameService.gI().doImbueItem(-1);
			}
			else
			{
				GameService.gI().doKhamItem(-1);
			}
			for (int i = 0; i < MainChar.gemitemImbue.size(); i++)
			{
				RealID realID = (RealID)MainChar.gemitemImbue.elementAt(i);
				GemTemplate gemByID = GemTemplate.getGemByID(realID.ID);
				if (gemByID != null)
				{
					gemByID.number++;
					break;
				}
			}
			MainChar.gemitemImbue.removeAllElements();
			Canvas.gameScr.mainChar.itemImbue = null;
			imgWeaponAvatar = null;
			idImbue = -1;
		}
		else if (index[focusTab] == 22)
		{
			Canvas.gameScr.gameService.finishPutItem2Bag();
		}
		else if (index[focusTab] == 8)
		{
			Canvas.gameScr.gameService.sendCancelTrade(Canvas.gameScr.mainChar.ID);
			Canvas.gameScr.mainChar.isTrade = false;
		}
	}

	public void resetImbue()
	{
		MainChar.gemitemImbue.removeAllElements();
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

	public void questClan(string text1, sbyte finishQ)
	{
		questInfo = new mVector();
		string[] array = MFont.normalFont[0].splitFontBStrInLine(text1, Canvas.w - 100);
		for (int i = 0; i < array.Length; i++)
		{
			questInfo.addElement(array[i]);
		}
		short num = (short)(Canvas.h - 90 - MyScreen.deltaY);
		cmy = (cmtoY = (cmyLim = 0));
		cmyLim = questInfo.size() * 13 - (num - 35);
		Canvas.endDlg();
	}

	private void paintShowTextNew(MyGraphics g)
	{
		int num = 0;
		g.setClip(xShow, yShow + 1, wShow, hView - 50);
		g.translate(0, -cmyText);
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
			num += MainJ2ME.CHAR_HEIGHT;
		}
		if (countPop < 0)
		{
			countPop++;
		}
	}

	private void setShowTextNew(string text, int x1, int y1)
	{
		isTextArr = false;
		isShowText = true;
		wShow = wKhung - (x0 - 2 + 7 * wCell);
		xShow = 7 * wCell + xTr;
		yShow = -10 + yTr;
		showText = MFont.arialFontW.splitFontBStrInLine(text, www);
		hShow = hView;
		if (countPop == 0)
		{
			countPop = -(showText.Length - 1);
		}
		cmyText = (cmtoYText = (cmyLimText = 0));
		cmyLimText = showText.Length * 20 - hShow;
		if (cmyLimText < 0)
		{
			cmyLimText = 0;
		}
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
			default:
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
				if (saveSelect != selected)
				{
					saveSelect = selected;
				}
				else
				{
					doBuyitemshopnew();
				}
				center.perform();
				if (countClick >= 2)
				{
					if (curentTabUpdate != 0 && cmdShop != null && index[focusTab] != 24)
					{
						cmdShop.perform();
					}
					countClick = 0;
				}
				break;
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 21:
			case 22:
			case 23:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
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
				countPutKey = 0;
				closeText();
				isPaintFc = false;
				isSelectCheDo = false;
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
		if (Canvas.beginMoveCmrX())
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
				countPutKey++;
			}
		}
		else if (timeHold >= 5)
		{
			timeHold = 0;
			timeOpen = 5L;
			canSelecet = true;
			checkSelect();
			countPutKey++;
		}
		transXB = false;
	}

	public void checkSelect()
	{
		switch (curentTabUpdate)
		{
		case 1:
			return;
		case 2:
			return;
		case 3:
			return;
		case 4:
			return;
		case 5:
			return;
		case 6:
			return;
		case 7:
			return;
		case 8:
			return;
		case 21:
		case 25:
			return;
		case 22:
			return;
		case 23:
			return;
		case 26:
		case 32:
			return;
		case 27:
			return;
		case 29:
			return;
		case 30:
			return;
		case 31:
			return;
		case 28:
			isSelectCheDo = false;
			xCus = -20;
			isChangeTab = false;
			selected = (cmtoX + Canvas.px - 15 - xTr) / newZise;
			if (selected < 0)
			{
				selected = 0;
			}
			return;
		}
		cmtoX = 0;
		int num = Canvas.pyLast - Canvas.py;
		int num2 = Canvas.pxLast - Canvas.px;
		int num3 = 35;
		int num4 = 65;
		int num5 = (cmtoY + Canvas.py - (num4 - 10) - yTr) / (hSmall + 10);
		int num6 = (cmtoX + Canvas.px - (num3 - 10) - xTr) / numCell;
		selected = num5 * 5 + num6;
		if (selected < 0)
		{
			selected = 0;
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
		else if (curentTabUpdate != 32 && curentTabUpdate != 26)
		{
			if (cmx < 0)
			{
				cmtoX = 0;
			}
			else if (cmx > cmxLim)
			{
				cmtoX = cmxLim;
			}
		}
		else if (cmx <= 0)
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
		if (Canvas.isPointerDownText && Canvas.isPointer(xBegint, yBegint + yTr, wToucht, hToucht))
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

	private void doSetLeftPetEat(int type)
	{
		ActionPerform action = delegate
		{
			closeText();
			if (!setMaxxreadyBuy())
			{
				ItemInInventory itemInInventory = null;
				int num = 0;
				if (type != -1)
				{
					int num2 = Canvas.gameScr.shop.size();
					for (int i = 0; i < num2; i++)
					{
						ItemInInventory itemInInventory2 = (ItemInInventory)Canvas.gameScr.shop.elementAt(i);
						ItemTemplate item2 = Res.getItem(itemInInventory2.charClazz, itemInInventory2.idTemplate);
						if (item2.type == type)
						{
							if (num == selected)
							{
								itemInInventory = itemInInventory2;
								break;
							}
							num++;
						}
					}
				}
				else
				{
					itemInInventory = (ItemInInventory)Canvas.gameScr.shop.elementAt(selected);
				}
				ItemInInventory item = itemInInventory;
				ItemTemplate itt = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				string empty = string.Empty;
				empty = "Bạn có muốn cho thú cưng ăn vật phẩm này không?";
				ActionPerform yesAction = delegate
				{
					Canvas.gameScr.mainChar.charXu -= itt.price;
					readyBuy.addElement(item);
					Canvas.startOKDlg("Đã chọn vật phẩm cho thú cưng ăn.", isIcon: false);
				};
				Canvas.startYesNoDlg(empty, yesAction);
			}
		};
		left = new Command("Mua");
		left.action = action;
	}
}
