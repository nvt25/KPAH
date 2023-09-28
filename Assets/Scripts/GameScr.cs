using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class GameScr : MyScreen
{
	public class Ticker
	{
		private int x;

		private int y;

		private int y1;

		public bool end;

		public string info = string.Empty;

		public Ticker(string info, int x, int y)
		{
			this.info = info;
			this.x = x;
			this.y = y;
		}

		public void paint(MyGraphics g)
		{
			g.setColor(0, 0.5f);
			g.fillRect(Canvas.w15 - 10, Canvas.h / 4 + 15 - MFont.borderFont.getHeight() / 2, Canvas.w - (2 * Canvas.w15 - 20), MFont.normalFont[0].getHeight() + 6);
			g.setClip(Canvas.w15, 0, Canvas.w - 2 * Canvas.w15, Canvas.h);
			MFont.borderFont.drawString(g, info, x, y + 2, 0);
		}

		public void update()
		{
			if (x + MFont.normalFont[0].getWidth(info) < 60)
			{
				end = true;
			}
			x -= 2;
		}
	}

	public const sbyte STATE_FINISH = 1;

	public const sbyte STATE_WORKING = 2;

	public const sbyte STATE_UN_RECEIVE = 0;

	public static string nameMap = string.Empty;

	public static readonly sbyte KILL_MOSTER = 0;

	public static readonly sbyte GET_ITEM = 2;

	public static readonly sbyte TRANSPORT = 1;

	public int gssx;

	public int gssy;

	public int gssw;

	public int gssh;

	public int gssxe;

	public int gssye;

	private int[] CMVIBRATEX = new int[4] { -1, 2, 1, -2 };

	private int[] CMVIBRATEY = new int[4] { -3, 2, -1, 1 };

	private int currentCmVibrate = -1;

	public static int cmtoX;

	public static int cmtoY;

	public static int cmvx;

	public static int cmvy;

	public static int cmdx;

	public static int cmdy;

	public static int cmx;

	public static int cmy;

	public static int cmxLim;

	public static int cmyLim;

	public static bool lockcmx;

	public static bool lockcmy;

	public mVector actors = new mVector();

	public mVector npc_limit = new mVector();

	public mVector npc_Limit = new mVector();

	public static mVector arrowsUp = new mVector();

	public mVector arrowsDown = new mVector();

	public static Actor objcountDown;

	public int hideGUI;

	public MainChar mainChar = new MainChar();

	public Actor focusedActor;

	public bool readyGetGameLogic = true;

	public bool onoffInvite;

	public bool lockPosition = true;

	public bool isFillScr;

	public static bool isFight;

	public mVector shop = new mVector();

	public mVector shopSpecial = new mVector();

	public static mVector infoNewSkill = new mVector();

	public Position posBoss;

	public int timerung;

	private bool changeSinceLastUpdate;

	public static int gsw;

	public static int gsh;

	public static int gscmdBarY;

	public static int gshw;

	public static int gshh;

	public static int gswd3;

	public static int gshd3;

	public static int gsw2d3;

	public static int gsh2d3;

	public static int gsw3d4;

	public static int gsh3d4;

	public static int gswd6;

	public static int gshd6;

	public static mVector serverInfo = new mVector();

	public GameService gameService = GameService.gI();

	public string[] flyTextString;

	public int[] flyTextX;

	public int[] flyTextY;

	public int[] flyTextDx;

	public int[] flyTextDy;

	public int[] flyTextState;

	public int[] flyTextColor;

	public short saveIDViewInfoAnimal = -1;

	public bool chatMode;

	public bool isBuffAuto;

	public TField tfChat = new TField();

	private mVector chatHistory = new mVector();

	public static int tempIDActorParty = -1;

	public short questID = 1;

	public short current_npc_talk = -1;

	public int indexContent = -1;

	public short idNpcReceive = 5;

	public static sbyte idItemClanquest = -1;

	public static Position posNpcReceiveClan;

	public bool receiveQuest;

	public string[] content_quest;

	public static string infoQuest = "Giết 10 con nhím, sau đó quay về nói chuyện với  NPC";

	public static string info_gif_quest = null;

	public static string titleQuest = string.Empty;

	public static Image imgInfo;

	public static Image imgHpMonster;

	public static Image img12plus;

	public static Image petShadow;

	public static Image[] imgCong;

	public static Image[] imghealth;

	public Position posNpcRequest;

	private int yMsgChat;

	private int toYchat = -18;

	private int startMsg;

	public static mVector aeo = new mVector();

	public int indexBuff = -1;

	public static long timeBuff = -1L;

	public static int indexTabSlot = 0;

	public static int xSlot = 0;

	public static int idMapPK = -1;

	public static int iTaskAuto = 0;

	public static Actor congThanh;

	public static sbyte xArena;

	public static sbyte yArena;

	public static sbyte wArena;

	public static sbyte hArena;

	public static long[] timeChiemThanh;

	public static long[] curTimeCT;

	public static short[] idChiemThanh;

	public static string[] nameChiemThanh;

	public static string[] nameClan;

	private static bool isFindChar = false;

	private static bool isActorMove = false;

	private static bool isFindMonster = false;

	public static mVector effAnimate = new mVector();

	public static mVector effManager;

	public static mVector savemsgWorld = new mVector();

	public static mVector msgWorld = new mVector();

	public static string[] nameCountry = new string[2] { "Thanh Long", "Hắc Hổ" };

	public static sbyte typeOptionFocus = 0;

	public static bool[] isPaintFcBt = new bool[9];

	public static bool[] isPaintFcBtMHP = new bool[2];

	public static long timeMove = mSystem.currentTimeMillis();

	public static short dtmove = 250;

	public static MyRandom r = new MyRandom();

	private int HPBARW;

	private int HPBARW_MONSTER;

	private Position posMiniMap;

	public static int wMiniMap;

	public static int hMiniMap;

	private Position[] posQuickSlot;

	public long lastTimePing;

	public long pingDelay;

	private int pingNextIn = 10;

	public int[] DELTACAMERAX = new int[4] { 0, 0, -20, 20 };

	public int[] DELTACAMERAY = new int[4] { 20, -20, 0, 0 };

	private int ccc;

	public static long timeStandWhenAuto;

	private int[] xChange = new int[3] { 4, 0, -4 };

	private int countChang;

	private int xMsgServer;

	private static readonly int[][] C = new int[4][]
	{
		new int[4] { -90, 90, -90, 90 },
		new int[4] { -90, 90, -90, 90 },
		new int[4] { -90, 90, -90, 90 },
		new int[4] { -90, 90, -90, 90 }
	};

	public mVector nearActors = new mVector();

	private static readonly sbyte[][] DX = new sbyte[4][]
	{
		new sbyte[4] { 0, 0, -48, 48 },
		new sbyte[4] { 0, 0, -32, 32 },
		new sbyte[4] { 0, 0, -16, 16 },
		new sbyte[4]
	};

	private static readonly sbyte[][] DY = new sbyte[4][]
	{
		new sbyte[4] { 48, -48, 0, 0 },
		new sbyte[4] { 32, -32, 0, 0 },
		new sbyte[4] { 16, -16, 0, 0 },
		new sbyte[4]
	};

	private static readonly sbyte DELAY_BETWEEN_PING = 30;

	public static readonly sbyte MAX_INVENTORY = 42;

	private sbyte lastDir;

	private sbyte dir;

	private sbyte countStep;

	private short moveToX;

	private short moveToY;

	private int c;

	public int[] QUICKSLOT_KEY = new int[5] { 1, 3, 5, 7, 9 };

	private bool finishQuest;

	private int dem = 1;

	private int t = (int)(mSystem.getCurrentTimeMillis() / 1000);

	public static bool autoFight = false;

	public static bool saveAutoFight;

	public static bool isBeginAutoBuff;

	public static bool isAutoBomHp;

	public static bool isAutoBomMp;

	public static bool autoBomHMP;

	public bool isAutoRangeWhenAuto;

	public static long timeDelayHpMp;

	public static Quest currQuest = null;

	private long timeTaskAuto;

	public static int timeDelayTask = 50;

	private sbyte[] X_FOWARD = new sbyte[4] { 0, 0, -17, 17 };

	private sbyte[] Y_FOWARD = new sbyte[4] { 17, -17, 0, 0 };

	private Position posTo;

	public static bool cheat = false;

	private int[] SLOTINDEXOFKEY = new int[10] { 0, 0, 0, 1, 0, 2, 0, 3, 0, 4 };

	private bool first;

	public static int timeRemovePos;

	private Target tg = new Target();

	public int a;

	public int b;

	public int coutChangeFocusWhenDoing;

	private int[] colorPaint = new int[4] { 16520709, 16499718, 396543, 1101907 };

	private static int[] colorMini = new int[3] { 6898216, 11897430, 14469298 };

	public bool isBatMiniMap;

	private static int xF;

	private static int yF;

	private static int yTouchBar;

	private static int gH;

	private static int cmdBarH;

	private static int xU;

	private static int xD;

	private static int xL;

	private static int xR;

	private static int yU;

	private static int yD;

	private static int yR;

	private static int yL;

	private static int xMp;

	private static int yMp;

	private static int xHp;

	private static int yHp;

	private static int xOne;

	private static int yOne;

	private static int xThree;

	private static int yThree;

	private static int xFire;

	private static int yFire;

	private static int xCenTer;

	private static int yCenter;

	private static int xChatTouch;

	private static int yChatTouch;

	private static int xSelectFc;

	private static int ySelectFc;

	private static int xChangeTab;

	private static int yChangeTab;

	private static int xChangeFocus;

	private static int yChangeFocus;

	private static int xChangeClothes;

	private static int yChangeClothes;

	private sbyte idInfo;

	private sbyte xInfo;

	private sbyte yInfo;

	public Ticker tk;

	private bool isCloseChat;

	private bool isPaintQuest;

	private static int[] colorSlot = new int[5] { 3158321, 88080384, 2122, 2037000, 256 };

	public short map = -1;

	public bool isNewVersionAvailable;

	public static short[] idArrMap;

	public static short[][] mapID;

	private static short[] offMapID = new short[43]
	{
		90, 91, 92, 93, 94, 95, 96, 97, 98, 99,
		100, 102, 103, 104, 108, 109, 260, 261, 262, 263,
		264, 265, 266, 267, 268, 269, 270, 271, 29, 30,
		31, 30, 31, 72, 73, 74, 78, 79, 82, 83,
		84, 88, 89
	};

	private static int oldMap = -1;

	public short xBeginFrame;

	public short yBeginFrame;

	public short xTheendFrame;

	public short yTheendFrame;

	public static int paintCay = 0;

	public static int paintChar = 1;

	public mVector decriptNap = new mVector();

	public mVector syntaxNap = new mVector();

	public mVector centerNap = new mVector();

	public static int pTicket = 1000;

	public static int cmtoYmini;

	public static int cmyMini;

	public static int cmdyMini;

	public static int cmvyMini;

	public static int cmtoXMini;

	public static int cmxMini;

	public static int cmdxMini;

	public static int cmvxMini;

	public static long timeTranMini;

	private Position posCam;

	public static short timePutKeyMP;

	public static short timePutKeyHP;

	private bool isNhanPhim;

	public static sbyte[][] mapFind;

	public static sbyte xStart;

	public static sbyte yStart;

	public static bool isFixBugAutoQuest;

	public int iTaskAutoLast;

	public static sbyte weather = -1;

	public mVector objDynamic = new mVector();

	private mVector listMSGServer = new mVector();

	public SkillClan[] skillClan;

	public SkillClan[] skillClanPrivate;

	private static Scroll scrInfo = new Scroll();

	public static Scroll scrMain = new Scroll();

	public static sbyte STATE_DONE = 3;

	public static Quest mainQuest;

	public static Quest subQuest;

	public static Quest clanQuest;

	public static mVector allQuestCanReceive = new mVector();

	public static mVector PosNPCQuest = new mVector();

	public static CharCountDown charcountdonw;

	public mVector VecTime = new mVector();

	public static sbyte[][] TYPE_MP_HP = new sbyte[2][];

	public static int[][] VALUE_MP_HP = new int[2][];

	public GameScr()
	{
		tfChat = new TField();
		tfChat.height = MyScreen.ITEM_HEIGHT + 2;
		tfChat.isFocus = true;
		tfChat.setMaxTextLenght(80);
		init();
		isBuffAuto = false;
		loadFlyText();
		setPosMiniMap();
		HPBARW = 45;
		HPBARW_MONSTER = 50;
		if (HPBARW_MONSTER < 30)
		{
			HPBARW_MONSTER = 30;
		}
		isPaintQuest = true;
		xMsgServer = Canvas.w - 20;
		if (!Main.isPC)
		{
			return;
		}
		left = new Command(string.Empty);
		left.action = delegate
		{
			if (mainChar.hp > 0 && !isCloseChat)
			{
				MenuWindows.gI().switchToMe();
				mainChar.posTransRoad = null;
				Canvas.isPointerClick = (Canvas.isPointerDown = false);
				Canvas.clearKeyPressed();
			}
			isCloseChat = false;
		};
		right = new Command(string.Empty);
		right.action = delegate
		{
			changeToNextFocusActor(isBack: false);
		};
	}

	public override void switchToMe()
	{
		Canvas.keyHold[2] = false;
		base.switchToMe();
		init();
		if (mainChar != null)
		{
			Canvas.gameScr.mainChar.posTransRoad = null;
		}
	}

	public void addChat(ChatInfo ci)
	{
		if (chatHistory.size() > 50)
		{
			chatHistory.removeElementAt(0);
			yMsgChat -= 18;
			toYchat -= 18;
		}
		chatHistory.addElement(ci);
		toYchat += 18;
	}

	public bool canPaintIsShowMenu()
	{
		if (Main.isPC)
		{
			return true;
		}
		if (Canvas.menu.showMenu && !Tilemap.isOfflineMap && Canvas.menu.menuItems.size() >= 5)
		{
			return false;
		}
		return true;
	}

	public void loadFlyText()
	{
		flyTextX = new int[15];
		flyTextY = new int[15];
		flyTextDx = new int[15];
		flyTextDy = new int[15];
		flyTextState = new int[15];
		flyTextColor = new int[15];
		flyTextString = new string[15];
		for (int i = 0; i < 15; i++)
		{
			flyTextState[i] = -1;
		}
	}

	public bool checkParseString(string str)
	{
		char[] array = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		char c = 'w';
		if (str.Length > 0)
		{
			c = str[0];
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			if (c == array[i])
			{
				return true;
			}
		}
		return false;
	}

	public string cutStringFromString(string data)
	{
		char[] array = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		string text = string.Empty;
		sbyte b = (sbyte)data.Length;
		short num = (short)array.Length;
		for (int i = 0; i < b; i++)
		{
			for (int j = 0; j < num; j++)
			{
				char c = data[i];
				char c2 = array[j];
				if (c == c2)
				{
					text += c;
					break;
				}
			}
		}
		return text;
	}

	public void startFlyText(string flyString, int flyColor, int x, int y, int dx, int dy)
	{
		string text = cutStringFromString(flyString);
		if (checkParseString(text.Substring(0)))
		{
			int num = 0;
			num = int.Parse(text.Substring(0));
			if (num == 2000000)
			{
				return;
			}
		}
		int num2 = -1;
		for (int i = 0; i < 15; i++)
		{
			if (flyTextState[i] == -1)
			{
				num2 = i;
				break;
			}
		}
		if (num2 != -1)
		{
			flyTextString[num2] = flyString.ToLower();
			flyTextX[num2] = x;
			flyTextY[num2] = y;
			flyTextDx[num2] = dx * ((r.nextInt(2) != 1) ? 1 : (-1));
			flyTextDy[num2] = dy;
			flyTextState[num2] = 0;
			flyTextColor[num2] = flyColor;
		}
	}

	public void updateFlyText()
	{
		for (int i = 0; i < 15; i++)
		{
			if (flyTextState[i] != -1)
			{
				flyTextState[i] += Util.abs(flyTextDy[i]);
				if (flyTextState[i] > 30)
				{
					flyTextState[i] = -1;
				}
				flyTextX[i] += flyTextDx[i];
				flyTextY[i] += flyTextDy[i];
			}
		}
	}

	public void paintFlyText(MyGraphics g)
	{
		if (!canPaintIsShowMenu())
		{
			return;
		}
		for (int i = 0; i < 15; i++)
		{
			if (flyTextState[i] != -1)
			{
				if (flyTextColor[i] != 0)
				{
					MFont.smallFontColor[flyTextColor[i]].drawString(g, flyTextString[i], flyTextX[i], flyTextY[i], 0);
				}
				else
				{
					MFont.smallFontYellow.paintFontBitMap(g, flyTextString[i], flyTextX[i], flyTextY[i], 0);
				}
			}
		}
	}

	public override void init()
	{
		tfChat.x = 2;
		tfChat.y = Canvas.h - 40;
		tfChat.width = Canvas.w - 4;
		if (posQuickSlot == null)
		{
			posQuickSlot = new Position[5];
			for (int i = 0; i < 5; i++)
			{
				posQuickSlot[i] = new Position();
			}
		}
		posQuickSlot[0].x = Canvas.hw - 47;
		posQuickSlot[0].y = Canvas.h - 19;
		posQuickSlot[1].x = Canvas.hw - 28;
		posQuickSlot[1].y = Canvas.h - 19;
		posQuickSlot[2].x = Canvas.hw - 8;
		posQuickSlot[2].y = Canvas.h - 20;
		posQuickSlot[3].x = Canvas.hw + 12;
		posQuickSlot[3].y = Canvas.h - 19;
		posQuickSlot[4].x = Canvas.hw + 31;
		posQuickSlot[4].y = Canvas.h - 19;
		setPosMiniMap();
		loadCamera();
	}

	public void setPosMiniMap()
	{
		if (Tilemap.imgMap == null)
		{
			return;
		}
		hMiniMap = Canvas.h / 5;
		if (hMiniMap > 100)
		{
			hMiniMap = 100;
		}
		posMiniMap = new Position(Canvas.hw + 50, 0);
		wMiniMap = Canvas.w - posMiniMap.x - 1;
		if (wMiniMap > 100)
		{
			wMiniMap = 100;
		}
		if (Tilemap.imgMap != null)
		{
			if (wMiniMap > Tilemap.imgMap.getWidth())
			{
				wMiniMap = Tilemap.imgMap.getWidth();
			}
			if (hMiniMap > Tilemap.imgMap.getHeight())
			{
				hMiniMap = Tilemap.imgMap.getHeight();
			}
		}
		posMiniMap.x = Canvas.w - wMiniMap - 1;
		posMiniMap.y = 0;
	}

	public void loadCamera()
	{
		gsw = Canvas.w;
		gsh = Canvas.h;
		gshw = gsw >> 1;
		gshh = gsh >> 1;
		gswd3 = gsw / 3;
		gshd3 = gsh / 3;
		gsw2d3 = 2 * gsw / 3;
		gsh2d3 = 2 * gsh / 3;
		gsw3d4 = 3 * gsw / 4;
		gsh3d4 = 3 * gsh / 4;
		gswd6 = gsw / 6;
		gshd6 = gsh / 6;
		gssw = (gsw >> 4) + 2;
		gssh = (gsh >> 4) + 2;
		if (gsw % 24 != 0)
		{
			gssw++;
		}
		cmxLim = (Tilemap.w << 4) - gsw - 10;
		cmyLim = (Tilemap.h << 4) - gsh - 30;
		if (mainChar != null)
		{
			cmx = (cmtoX = mainChar.x - gshw);
			cmy = (cmtoY = mainChar.y - gshh);
		}
		if (cmx < 0)
		{
			cmx = 0;
		}
		if (cmx > cmxLim)
		{
			cmx = cmxLim;
		}
		if (cmy < 0)
		{
			cmy = 0;
		}
		if (cmy > cmyLim)
		{
			cmy = cmyLim;
		}
		gssx = (cmx >> 4) - 1;
		if (gssx < 0)
		{
			gssx = 0;
		}
		gssy = cmy >> 4;
		gssxe = gssx + gssw;
		gssye = gssy + gssh;
		if (gssy < 0)
		{
			gssy = 0;
		}
		if (gssye > Tilemap.h - 1)
		{
			gssye = Tilemap.h - 1;
		}
		lockcmx = (lockcmy = false);
		if (Tilemap.pxw < gsw + 32)
		{
			lockcmx = true;
			cmx = -(gsw - Tilemap.pxw) >> 1;
		}
		if (Tilemap.pxh < gsh)
		{
			lockcmy = true;
			cmy = -(gsh - Tilemap.pxh) >> 1;
		}
		setDataForButton();
	}

	public void updateCamera()
	{
		if (cmx != cmtoX && !lockcmx)
		{
			cmvx = cmtoX - cmx << 2;
			cmdx += cmvx;
			cmx += cmdx >> 4;
			cmdx &= 15;
			if (cmx < 0)
			{
				cmx = 0;
			}
			if (cmx > cmxLim)
			{
				cmx = cmxLim;
			}
		}
		if (cmy != cmtoY && !lockcmy)
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
		if (currentCmVibrate >= 0)
		{
			cmx += CMVIBRATEX[currentCmVibrate];
			cmy += CMVIBRATEY[currentCmVibrate];
			currentCmVibrate++;
			if (currentCmVibrate == 4)
			{
				currentCmVibrate = -1;
			}
			if (cmx < 0)
			{
				cmx = 0;
			}
			if (cmx > cmxLim)
			{
				cmx = cmxLim;
			}
			if (cmy < 0)
			{
				cmy = 0;
			}
			if (cmy > cmyLim)
			{
				cmy = cmyLim;
			}
		}
		gssx = (cmx >> 4) - 1;
		if (gssx < 0)
		{
			gssx = 0;
		}
		gssy = cmy >> 4;
		gssxe = gssx + gssw;
		if (gssxe > Tilemap.w)
		{
			gssxe = Tilemap.w;
		}
		if (gssye > Tilemap.h)
		{
			gssye = Tilemap.h;
		}
		gssye = gssy + gssh;
		if (gssy < 0)
		{
			gssy = 0;
		}
		if (gssye > Tilemap.h - 1)
		{
			gssye = Tilemap.h - 1;
		}
		scrMain.updatecm();
		scrInfo.updatecm();
	}

	public void updateMainCharWhenAuto()
	{
		if (!autoFight)
		{
			isAutoRangeWhenAuto = false;
		}
		else if (timeStandWhenAuto - mSystem.getCurrentTimeMillis() / 1000 <= 0)
		{
			gameService.moveChar(mainChar.x, mainChar.y);
			timeStandWhenAuto = mSystem.getCurrentTimeMillis() / 1000 + 10;
		}
	}

	public void updateTime()
	{
		for (int i = 0; i < VecTime.size(); i++)
		{
			TimecountDown timecountDown = (TimecountDown)VecTime.elementAt(i);
			if (timecountDown != null)
			{
				timecountDown.update();
				if (timecountDown.wantdestroy)
				{
					VecTime.removeElement(timecountDown);
				}
			}
		}
	}

	public override void update()
	{
		timeRemovePos--;
		if (timeRemovePos < 0)
		{
			timeRemovePos = 0;
		}
		int num = aeo.size();
		for (int i = 0; i < num; i++)
		{
			((Effect)aeo.elementAt(i))?.update();
		}
		updateTime();
		if (charcountdonw != null)
		{
			charcountdonw.update();
			if (charcountdonw.WantDestroy)
			{
				charcountdonw = null;
				objcountDown = null;
			}
		}
		if (tk != null)
		{
			tk.update();
			if (tk.end)
			{
				tk = null;
			}
		}
		if (tg != null && mainChar.posTransRoad != null)
		{
			if (posCam != null)
			{
				tg.update();
				tg.x = (short)posCam.x;
				tg.y = (short)posCam.y;
			}
			else
			{
				tg.index = 0;
			}
		}
		updateCamera();
		cmtoX = mainChar.x - gshw + DELTACAMERAX[mainChar.dir];
		cmtoY = mainChar.y - gshh + DELTACAMERAY[mainChar.dir] - 20;
		updateCmMini();
		for (int num2 = arrowsUp.size() - 1; num2 >= 0; num2--)
		{
			((IArrow)arrowsUp.elementAt(num2))?.update();
		}
		for (int num3 = arrowsDown.size() - 1; num3 >= 0; num3--)
		{
			((IArrow)arrowsDown.elementAt(num3))?.update();
		}
		int num4 = npc_Limit.size();
		for (int j = 0; j < num4; j++)
		{
			((Actor)npc_Limit.elementAt(j))?.update();
		}
		PosNPCQuest.removeAllElements();
		mVector mVector2 = new mVector();
		for (int k = 0; k < actors.size(); k++)
		{
			Actor actor = (Actor)actors.elementAt(k);
			if (actor.isNPC())
			{
				getAllPosNPCMInimap(actor);
			}
			if (actor.ispetTool() && actor.wantDestroy)
			{
				mVector2.addElement(actor);
			}
			if (actor == null)
			{
				continue;
			}
			if (actor.catagory == 2 || actor.catagory == Actor.CAT_MY_GROUND || actor.catagory == Actor.CAT_MY_TREE || actor.catagory == Actor.CAT_MY_PET)
			{
				actor.update();
				continue;
			}
			actor.update();
			if (!Util.inDataRange(actor, mainChar) && actor != congThanh && actor.catagory != Actor.CAT_CAN_NOT_FOCUS && actor.catagory != Actor.CAT_PLAYER && actor.timeLive == -1)
			{
				actor.wantDestroy = true;
			}
			if (!actor.wantDestroy || actor.timeLive != -1)
			{
				continue;
			}
			if (focusedActor == actor)
			{
				focusedActor = null;
			}
			if (!isFindChar && !isActorMove && !isFindMonster && actor.catagory != 100)
			{
				if (actor.catagory == 0)
				{
					actor.isDie = true;
				}
				mVector2.addElement(actor);
			}
		}
		int num5 = Tilemap.pointPop.size();
		for (int l = 0; l < num5; l++)
		{
			((PopupName)Tilemap.pointPop.elementAt(l))?.update();
		}
		if (congThanh != null)
		{
			congThanh.update();
		}
		Util.quickSort(actors);
		if (Canvas.gameTick % 10 == 0)
		{
			focusedActor = findFocusActor();
		}
		if (focusedActor != null && focusedActor.catagory == 100)
		{
			focusedActor = null;
		}
		EffectManager.lowEffects.updateAll();
		EffectManager.hiEffects.updateAll();
		updateFlyText();
		if (pingNextIn > 0)
		{
			pingNextIn--;
			if (pingNextIn == 0)
			{
				lastTimePing = mSystem.getCurrentTimeMillis();
				gameService.ping();
			}
		}
		if (chatMode && tfChat != null)
		{
			tfChat.update();
		}
		if (indexBuff != -1 && timeBuff != -1 && mSystem.getCurrentTimeMillis() > timeBuff)
		{
			indexBuff = -1;
			timeBuff = -1L;
		}
		if (xSlot > 0)
		{
			xSlot -= Res.wKhung / 10;
			if (xSlot < 0)
			{
				xSlot = 0;
			}
		}
		if ((Tilemap.w >= wMiniMap || Tilemap.h >= hMiniMap) && mSystem.getCurrentTimeMillis() / 100 - timeTranMini > 20)
		{
			updateminiMap();
		}
		try
		{
			if (posNpcRequest != null && iTaskAuto == 2)
			{
				updateTask();
				Canvas.endDlg();
			}
		}
		catch (Exception)
		{
			mainChar.posTransRoad = null;
			mainChar.countRoad = 0;
		}
		if (effAnimate.size() > 0)
		{
			AnimateEffect.updateWind();
			int num6 = effAnimate.size();
			for (int m = 0; m < num6; m++)
			{
				((AnimateEffect)effAnimate.elementAt(m))?.update();
			}
		}
		if (effManager != null)
		{
			int num7 = effManager.size();
			for (int n = 0; n < num7; n++)
			{
				((EffectServerManager)effManager.elementAt(n))?.update();
			}
		}
		for (int num8 = 0; num8 < mVector2.size(); num8++)
		{
			actors.removeElement(mVector2.elementAt(num8));
		}
		updateMsgServer();
		setRemoveIconImg();
		if (skillClan != null)
		{
			for (int num9 = 0; num9 < 1; num9++)
			{
				if (num9 < skillClan.Length && skillClan[num9] != null && skillClan[num9].time > 0)
				{
					skillClan[num9].updateTime();
				}
			}
		}
		if (timerung > 0)
		{
			timerung--;
		}
		else
		{
			timerung = 0;
		}
		if (Tilemap.isOfflineMap && map == 29)
		{
			if (mainChar.x >= xBeginFrame - 16 && mainChar.x <= xTheendFrame + 40 && mainChar.y >= yBeginFrame - 16 && mainChar.y <= yTheendFrame + 40)
			{
				focusedActor = isFocusMyGround(mainChar);
			}
			else
			{
				int num10 = actors.size();
				for (int num11 = 0; num11 < num10; num11++)
				{
					Actor actor2 = (Actor)actors.elementAt(num11);
					if (actor2 != null && actor2.catagory == Actor.CAT_MY_GROUND)
					{
						actor2.isFocus = false;
					}
				}
			}
		}
		if (msgWorld.size() > 0)
		{
			((MsgInfo)msgWorld.elementAt(0))?.update();
		}
		if (savemsgWorld.size() > 30)
		{
			savemsgWorld.removeElementAt(0);
		}
		for (int num12 = 0; num12 < num; num12++)
		{
			Effect effect = (Effect)aeo.elementAt(num12);
			if (effect != null && effect.wantDetroy)
			{
				effect = null;
				aeo.removeElementAt(num12);
			}
		}
		for (int num13 = arrowsUp.size() - 1; num13 >= 0; num13--)
		{
			IArrow arrow = (IArrow)arrowsUp.elementAt(num13);
			if (arrow != null && arrow.wantDestroy)
			{
				arrow = null;
				arrowsUp.removeElementAt(num13);
			}
		}
		if (mainChar.state != 3 && autoFight && Canvas.currentScreen is GameScr && Canvas.currentDialog != null && !mainChar.isDie && Tilemap.lv != 0 && Tilemap.lv != 201 && Tilemap.lv != 70 && Tilemap.lv != 80)
		{
			Canvas.currentDialog = null;
		}
		updateMainCharWhenAuto();
		if (Tilemap.lv == 0 || Tilemap.lv == 70 || Tilemap.lv == 80)
		{
			autoFight = false;
		}
		if (Canvas.gameTick % 200 == 0)
		{
			Char.SetRemove();
		}
		if (isFixBugAutoQuest)
		{
			isFixBugAutoQuest = false;
			mainChar.xTo = mainChar.x;
			mainChar.yTo = mainChar.y;
			mainChar.xBegin = mainChar.x;
			mainChar.yBegin = mainChar.y;
			countChang++;
			if (countChang > xChange.Length - 1)
			{
				countChang = 0;
			}
			int xTo = Tilemap.w / 2 + xChange[countChang];
			int yTo = Tilemap.h / 2 + xChange[countChang];
			mainChar.posTransRoad = updateFindRoad(mainChar.x / 16, mainChar.y / 16, xTo, yTo);
			mainChar.countRoad = 0;
			iTaskAuto = iTaskAutoLast;
		}
	}

	public Actor isFocusMyGround(LiveActor ac)
	{
		Actor result = null;
		if (Tilemap.isOfflineMap)
		{
			int num = actors.size();
			for (int i = 0; i < num; i++)
			{
				Actor actor = (Actor)actors.elementAt(i);
				if (actor != null && actor.catagory == Actor.CAT_MY_GROUND)
				{
					if (ac.x >= actor.x + 2 && ac.x <= actor.x + 30 && ac.y >= actor.y && ac.y + 2 <= actor.y + 30)
					{
						actor.isFocus = true;
						result = actor;
					}
					else
					{
						actor.isFocus = false;
					}
				}
			}
		}
		return result;
	}

	private void updateMsgServer()
	{
		if (listMSGServer != null && listMSGServer.size() > 0)
		{
			xMsgServer -= 5;
			string s = (string)listMSGServer.elementAt(0);
			if (xMsgServer + MFont.arialFont.getWidth(s) < 20)
			{
				listMSGServer.removeElementAt(0);
				xMsgServer = Canvas.w - 20;
				isPaintQuest = false;
			}
		}
	}

	private void setRemoveIconImg()
	{
		if (GameData.listImgIcon.size() <= 100)
		{
			return;
		}
		IDictionaryEnumerator enumerator = GameData.listImgIcon.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string k = enumerator.Key.ToString();
			ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(k);
			if (!imageIcon.isLoad && mSystem.getCurrentTimeMillis() / 1000 - imageIcon.timeRemove > 120)
			{
				GameData.listImgIcon.remove(k);
			}
		}
	}

	public void onLoadCloth(sbyte[] arr, sbyte type, sbyte id)
	{
		MyHashTable myHashTable = (MyHashTable)Res.quanao.elementAt(type);
		((CharPartInfo)myHashTable.get(id + string.Empty))?.load(arr, type, id);
	}

	private void setRemoveClothes()
	{
		for (int i = 0; i < Res.quanao.size(); i++)
		{
			MyHashTable myHashTable = (MyHashTable)Res.quanao.elementAt(i);
			IDictionaryEnumerator enumerator = GameData.listImgIcon.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = (string)enumerator.Value;
				CharPartInfo charPartInfo = (CharPartInfo)myHashTable.get(k);
				if (mSystem.getCurrentTimeMillis() / 1000 - charPartInfo.timeRemove > 60)
				{
					myHashTable.remove(k);
				}
			}
		}
	}

	private void updateCmMini()
	{
		if (Tilemap.w >= wMiniMap || Tilemap.h >= hMiniMap)
		{
			if (cmyMini != cmtoYmini)
			{
				cmvyMini = cmtoYmini - cmyMini << 2;
				cmdyMini += cmvyMini;
				cmyMini += cmdyMini >> 4;
				cmdyMini &= 15;
			}
			if (cmxMini != cmtoXMini)
			{
				cmvxMini = cmtoXMini - cmxMini << 2;
				cmdxMini += cmvxMini;
				cmxMini += cmdxMini >> 4;
				cmdxMini &= 15;
			}
		}
	}

	public Actor findFocusActor()
	{
		int num = mainChar.x + C[mainChar.dir][0];
		int num2 = mainChar.x + C[mainChar.dir][1];
		int num3 = mainChar.y + C[mainChar.dir][2];
		int num4 = mainChar.y + C[mainChar.dir][3];
		int num5 = 10000;
		int num6 = -1;
		nearActors.removeAllElements();
		int num7 = actors.size();
		Actor actor = null;
		for (int i = 0; i < num7; i++)
		{
			actor = (Actor)actors.elementAt(i);
			if (actor.x <= num || actor.x >= num2 || actor.y <= num3 || actor.y >= num4)
			{
				continue;
			}
			if (actor.catagory == Actor.CAT_CAN_NOT_FOCUS || !actor.canfocus || (actor.catagory == 0 && actor.ID == mainChar.ID) || actor.catagory == Actor.CAT_MY_GROUND || actor.catagory == Actor.CAT_MY_TREE || actor.catagory == Actor.CAT_MY_PET || (autoFight && !Canvas.autoTab.isAutoFire && Tilemap.lv != 0 && Tilemap.lv != 201 && Tilemap.lv != 70 && Tilemap.lv != 80 && !Tilemap.isOfflineMap && (actor.isItemCanGet() || actor.catagory == Actor.CAT_EXPLOTION || actor.catagory == Actor.CAT_NPC || actor.catagory == Actor.CAT_PLAYER)))
			{
				if ((autoFight || autoBomHMP) && actor.catagory == Actor.CAT_NPC)
				{
					addChat(mainChar, "Bạn hãy tắt auto trước khi focus", 100);
				}
			}
			else
			{
				if ((actor.catagory == Actor.CAT_MONSTER && actor.state == 8) || (autoFight && (actor.state == 3 || actor.isDropItem())))
				{
					continue;
				}
				if (typeOptionFocus == 1)
				{
					bool flag = false;
					if ((actor.catagory == Actor.CAT_PLAYER && (!actor.iskiller || actor.isNPC())) || (actor.catagory != Actor.CAT_MONSTER && actor.catagory == Actor.CAT_PLAYER && !actor.iskiller))
					{
						continue;
					}
				}
				else if (typeOptionFocus == 2)
				{
					if (!actor.isNPC())
					{
						continue;
					}
				}
				else if (typeOptionFocus == 3)
				{
					if ((actor.catagory == Actor.CAT_PLAYER && actor.idClan == mainChar.idClan) || actor.isNPC())
					{
						continue;
					}
				}
				else if (typeOptionFocus == 4 && ((actor.catagory == Actor.CAT_PLAYER && actor.nationID == mainChar.nationID) || actor.isNPC()))
				{
					continue;
				}
				nearActors.addElement(actor);
				int num8 = Util.abs(mainChar.x - actor.x) + Util.abs(mainChar.y - actor.y);
				if (actor.catagory == 3 || actor.catagory == 4)
				{
					num8 <<= 1;
				}
				if (num8 < num5)
				{
					num5 = num8;
					num6 = i;
				}
			}
		}
		if (num6 == -1)
		{
			return null;
		}
		if (autoFight && Canvas.autoTab.isAutoFire)
		{
			for (int j = 0; j < nearActors.size(); j++)
			{
				Actor actor2 = (Actor)nearActors.elementAt(j);
				if (actor2 != null && actor2.iskiller)
				{
					return actor2;
				}
			}
		}
		if (focusedActor == null && num6 < actors.size())
		{
			return (Actor)actors.elementAt(num6);
		}
		if (!Canvas.instance.hasPointerEvents() && num6 < actors.size())
		{
			if (nearActors.conTains(focusedActor))
			{
				return focusedActor;
			}
			return (Actor)actors.elementAt(num6);
		}
		if (Util.distance(mainChar.x, mainChar.y, focusedActor.x, focusedActor.y) > Canvas.w / 2)
		{
			focusedActor = null;
		}
		return focusedActor;
	}

	public void onStarDialLucky(int type)
	{
		DialLuckyScr.gI().switchToMe();
		DialLuckyScr.gI().lastScr = this;
	}

	public Actor getActor(int id)
	{
		for (int i = 0; i < actors.size(); i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == Actor.CAT_PLAYER && actor.ID == id)
			{
				return actor;
			}
		}
		return null;
	}

	public void changeToNextFocusActor(bool isBack)
	{
		if (focusedActor == null)
		{
			focusedActor = findFocusActor();
			if (focusedActor != null && focusedActor.catagory == 100)
			{
				focusedActor = null;
			}
			return;
		}
		if (isBack && !focusedActor.iskiller && autoFight && typeOptionFocus == 1)
		{
			focusedActor = findFocusActor();
			if (focusedActor != null && focusedActor.iskiller)
			{
				return;
			}
		}
		int num = nearActors.indexOf(focusedActor);
		int num2 = num + 1;
		if (num2 >= nearActors.size() || num2 < 0)
		{
			num2 = 0;
		}
		if (nearActors.size() > 0)
		{
			focusedActor = (Actor)nearActors.elementAt(num2);
		}
		if (focusedActor != null && focusedActor.catagory == 100)
		{
			focusedActor = null;
		}
	}

	public static void addChat(Actor ac, string str, int time)
	{
		ac.chat = new ChatPopup(time, str, 1);
		ac.chat.setPos(ac.x, ac.y - ac.height);
	}

	private bool doTalkWithNPCQuest()
	{
		if (mainChar.receiveQuest && mainChar.typeQuest == TRANSPORT && receiveQuest)
		{
			updateWhenTalkPhuOng();
			if (Canvas.isKeyPressed(5))
			{
				Canvas.keyPressed[5] = false;
				indexContent++;
				if (indexContent <= mainChar.info_npc_quest.Length - 1)
				{
					mainChar.chat = null;
					focusedActor.chat = null;
					if (mainChar.info_npc_quest[indexContent].StartsWith("1"))
					{
						addChat(focusedActor, mainChar.info_npc_quest[indexContent].Substring(1), 500);
					}
					else
					{
						addChat(mainChar, mainChar.info_npc_quest[indexContent].Substring(1), 500);
					}
				}
				else
				{
					receiveQuest = false;
					mainChar.nextNpc++;
					if (mainChar.nextNpc >= mainChar.npc_quest.Length)
					{
						gameService.talk_npc(mainChar.npc_quest[mainChar.nextNpc - 1], 1, questID);
						dellPotionQuest();
					}
				}
			}
			return true;
		}
		return false;
	}

	private bool doTalkWithNPCResponse()
	{
		if (finishQuest && mainChar.finishQuest && mainChar.nextNpc < mainChar.npc_response.Length)
		{
			updateWhenTalkPhuOng();
			if (Canvas.isKeyPressed(5))
			{
				Canvas.keyPressed[5] = false;
				indexContent++;
				if (indexContent <= mainChar.info_response[mainChar.nextNpc].Length - 1)
				{
					mainChar.chat = null;
					focusedActor.chat = null;
					if (mainChar.info_response[mainChar.nextNpc][indexContent].StartsWith("1"))
					{
						addChat(focusedActor, mainChar.info_response[mainChar.nextNpc][indexContent].Substring(1), 500);
					}
					else
					{
						addChat(mainChar, mainChar.info_response[mainChar.nextNpc][indexContent].Substring(1), 500);
					}
				}
				else
				{
					indexContent = 0;
					mainChar.nextNpc++;
					if (mainChar.nextNpc < mainChar.npc_response.Length)
					{
						mainChar.chat = null;
						focusedActor.chat = null;
						finishQuest = false;
						set_npc_request(mainChar.npc_response[mainChar.nextNpc]);
					}
					else
					{
						gameService.talk_npc_response_quest(mainChar.npc_response[mainChar.nextNpc - 1], 1, questID);
						finishQuest = false;
					}
				}
			}
			return true;
		}
		return false;
	}

	public void set_npc_request(short type)
	{
		if (idNpcReceive != -1)
		{
			type = idNpcReceive;
		}
		else
		{
			current_npc_talk = type;
		}
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor is NPC && ((NPC)actor).type == type)
			{
				posNpcRequest = new Position(actor.x, actor.y);
				break;
			}
		}
	}

	public void paintPosNPCQuest(MyGraphics g)
	{
		for (int i = 0; i < PosNPCQuest.size(); i++)
		{
			Position position = (Position)PosNPCQuest.elementAt(i);
			paintPoint(g, position, position.indexColor);
		}
	}

	private bool doReceiveQuest()
	{
		if (receiveQuest)
		{
			updateWhenTalkPhuOng();
			if (Canvas.isKeyPressed(5))
			{
				Canvas.keyPressed[5] = false;
				indexContent++;
				if (indexContent <= content_quest.Length - 1)
				{
					mainChar.chat = null;
					focusedActor.chat = null;
					if (content_quest[indexContent].StartsWith("1"))
					{
						addChat(focusedActor, content_quest[indexContent].Substring(1), 500);
					}
					else
					{
						addChat(mainChar, content_quest[indexContent].Substring(1), 500);
					}
					if (indexContent == content_quest.Length - 1)
					{
						mVector mVector2 = new mVector();
						Command command = new Command("Đồng ý");
						ActionPerform action = delegate
						{
							GameService.gI().receiveQuest(idNpcReceive, questID, 1);
							Canvas.startWaitDlg();
							receiveQuest = false;
						};
						command.action = action;
						mVector2.addElement(command);
						if (mainChar.typeQuest != 3)
						{
							Command command2 = new Command("Không");
							ActionPerform action2 = delegate
							{
								receiveQuest = false;
								GameService.gI().receiveQuest(idNpcReceive, questID, 2);
							};
							command2.action = action2;
							mVector2.addElement(command2);
						}
						Canvas.menu.startAt(mVector2, 3);
					}
				}
			}
			return true;
		}
		return false;
	}

	private bool doIntro()
	{
		if (Tilemap.lv == 105)
		{
			string[] array = new string[15]
			{
				"1Cháu của ta", "1Nay con đã lớn", "1đã đến lúc con phải được học hỏi nhiều hơn", "1phải trải nghiệm nhiều hơn từ quê hương đất nước", "1và có nhiều điều để con phải học hỏi nơi biết bao đấng anh hào, ẩn sỹ.", "1Năm xưa ta có người anh em kết nghĩa là Hai Minh", "1ông ấy giờ đang là trưởng làng của làng này.", "1con hãy đi xuống phương Nam và tìm gặp người này", "1ông ấy sẽ giúp con gia nhập làng nghĩa sỹ Sơn Nam", "1Con hãy cố gắng để trưởng thành, để có thể giúp được quê hương",
				"1để có được sự nghiệp riêng và để tìm được nguồn gốc và cha mẹ của con…", "1Hãy lên đường đi", "1..nơi đây ta luôn dõi theo bước chân của con", "0Vâng! thưa nội con đi", "1Uhm, chúc con lên đường bình an."
			};
			if ((focusedActor == null || !(focusedActor is NPC)) && Canvas.currentDialog == null)
			{
				Canvas.keyHold[2] = true;
				indexContent = -1;
				doActorMove();
			}
			else
			{
				Canvas.keyHold[2] = false;
				if (focusedActor == null)
				{
					return false;
				}
				if (Util.abs(mainChar.y - focusedActor.y) <= 32)
				{
					if (indexContent == -1)
					{
						Canvas.keyPressed[5] = true;
					}
					if (Canvas.isPointerClick)
					{
						Canvas.isPointerClick = false;
						int num = cmx + Canvas.px;
						int num2 = cmy + Canvas.py;
						if (Util.abs(focusedActor.x - num) < 20 && Util.abs(focusedActor.y - 20 - num2) < 40)
						{
							Canvas.keyPressed[5] = true;
						}
					}
					if (Canvas.isKeyPressed(5) && indexContent < array.Length)
					{
						indexContent++;
						if (indexContent >= array.Length)
						{
							mainChar.state = 0;
							MyRandom myRandom = new MyRandom();
							int toX = 13 + myRandom.nextInt() % 5;
							int toY = 11 + myRandom.nextInt() % 5;
							GameService.gI().changeMap(0, toX, toY);
							Canvas.keyHold[2] = false;
							Canvas.startWaitDlg("Chuyển màn..", isIcon: true);
						}
						else
						{
							mainChar.chat = null;
							focusedActor.chat = null;
							if (array[indexContent].StartsWith("1"))
							{
								addChat(focusedActor, array[indexContent].Substring(1), 500);
							}
							else
							{
								addChat(mainChar, array[indexContent].Substring(1), 700);
							}
						}
					}
					return true;
				}
				Canvas.keyHold[2] = true;
				indexContent = -1;
				doActorMove();
			}
		}
		return false;
	}

	public void setFinishQuest()
	{
		if (posNpcRequest != null && iTaskAuto == 2)
		{
			posNpcRequest = null;
			GameService.gI().receiveQuest(21, 8, 1);
			Canvas.startWaitDlg();
			receiveQuest = false;
		}
	}

	private void doActorMove()
	{
		bool flag = false;
		if (Canvas.isKeyPressed(2) || Canvas.isKeyPressed(KeyConst.W))
		{
			flag = true;
			dir = 1;
		}
		if (Canvas.isKeyPressed(4) || Canvas.isKeyPressed(KeyConst.A))
		{
			flag = true;
			dir = 2;
		}
		if (Canvas.isKeyPressed(6) || Canvas.isKeyPressed(KeyConst.D))
		{
			flag = true;
			dir = 3;
		}
		if (Canvas.isKeyPressed(8) || Canvas.isKeyPressed(KeyConst.S))
		{
			flag = true;
			dir = 4;
		}
		bool flag2 = false;
		bool flag3 = false;
		int x = mainChar.x;
		int y = mainChar.y;
		int num = mainChar.dir;
		int num2 = 0;
		int num3 = 0;
		int speed = mainChar.speed;
		if (Canvas.keyHold[2] || Canvas.keyHold[KeyConst.W])
		{
			mainChar.stop = false;
			autoFight = false;
			removeFocusWhenPutKey();
			autoFight = false;
			mainChar.posTransRoad = null;
			setFinishQuest();
			num3 = -16;
			if (congThanh == null || mainChar.y > congThanh.y + 40)
			{
				flag3 = (flag2 = true);
			}
			else
			{
				flag = false;
			}
			mainChar.dir = Char.UP;
			moveToX = mainChar.x;
			moveToY = (short)(mainChar.y - speed);
			try
			{
				if (Tilemap.tileTypeAtPixel(moveToX, moveToY, 2) || checkMoveLimit(moveToX, moveToY))
				{
					moveToY = mainChar.y;
					if (mainChar.setWay(0, -8))
					{
						changeSinceLastUpdate = true;
						mainChar.comeHome = false;
						return;
					}
					flag = false;
					flag2 = false;
				}
			}
			catch (Exception ex)
			{
				flag = false;
				moveToY = mainChar.y;
				Out.println(ex.StackTrace + "move actor key");
			}
		}
		else if (Canvas.keyHold[8] || Canvas.keyHold[KeyConst.S])
		{
			mainChar.stop = false;
			autoFight = false;
			removeFocusWhenPutKey();
			autoFight = false;
			mainChar.posTransRoad = null;
			setFinishQuest();
			num3 = 16;
			flag3 = (flag2 = true);
			mainChar.dir = Char.DOWN;
			moveToX = mainChar.x;
			moveToY = (short)(mainChar.y + speed);
			try
			{
				if (Tilemap.tileTypeAtPixel(moveToX, moveToY, 2) || checkMoveLimit(moveToX, moveToY))
				{
					moveToY = mainChar.y;
					if (mainChar.setWay(0, 8))
					{
						changeSinceLastUpdate = true;
						mainChar.comeHome = false;
						return;
					}
					flag = false;
					flag2 = false;
				}
			}
			catch (Exception ex2)
			{
				flag = false;
				moveToY = mainChar.y;
				Out.println(ex2.StackTrace + "move actor key");
			}
		}
		else if (Canvas.keyHold[4] || Canvas.keyHold[KeyConst.A])
		{
			mainChar.stop = false;
			autoFight = false;
			removeFocusWhenPutKey();
			autoFight = false;
			mainChar.posTransRoad = null;
			setFinishQuest();
			num2 = -16;
			flag3 = (flag2 = true);
			mainChar.dir = Char.LEFT;
			moveToX = (short)(mainChar.x - speed);
			moveToY = mainChar.y;
			try
			{
				if (Tilemap.tileTypeAtPixel(moveToX, moveToY, 2) || checkMoveLimit(moveToX, moveToY))
				{
					moveToX = mainChar.x;
					if (mainChar.setWay(-8, 0))
					{
						changeSinceLastUpdate = true;
						mainChar.comeHome = false;
						return;
					}
					flag = false;
					flag2 = false;
				}
			}
			catch (Exception ex3)
			{
				flag = false;
				moveToX = mainChar.x;
				Out.println(ex3.StackTrace + "move actor key");
			}
		}
		else if (Canvas.keyHold[6] || Canvas.keyHold[KeyConst.D])
		{
			mainChar.stop = false;
			autoFight = false;
			removeFocusWhenPutKey();
			autoFight = false;
			mainChar.posTransRoad = null;
			setFinishQuest();
			num2 = 16;
			flag3 = (flag2 = true);
			mainChar.dir = Char.RIGHT;
			moveToY = mainChar.y;
			moveToX = (short)(mainChar.x + speed);
			try
			{
				if (Tilemap.tileTypeAtPixel(moveToX, moveToY, 2) || checkMoveLimit(moveToX, moveToY))
				{
					moveToX = mainChar.x;
					if (mainChar.setWay(8, 0))
					{
						changeSinceLastUpdate = true;
						mainChar.comeHome = false;
						return;
					}
					flag = false;
					flag2 = false;
				}
			}
			catch (Exception ex4)
			{
				flag = false;
				moveToX = mainChar.x;
				Out.println(ex4.StackTrace + "move actor key");
			}
		}
		if (!mainChar.FuntioncanMove() || (flag3 && checkCanChangeMap(x + num2, y + num3, num)))
		{
			return;
		}
		if (flag2)
		{
			if (moveToX < 0)
			{
				moveToX = mainChar.x;
			}
			if (moveToY < 0)
			{
				moveToY = mainChar.y;
			}
			if (moveToX > Tilemap.w * 16)
			{
				moveToX = mainChar.x;
			}
			if (moveToY > Tilemap.h * 16)
			{
				moveToX = mainChar.y;
			}
			mainChar.moveTo(moveToX, moveToY);
			if (saveAutoFight && typeOptionFocus == 1)
			{
				Canvas.gameScr.mainChar.lastXAuto = Canvas.gameScr.mainChar.xTo;
				Canvas.gameScr.mainChar.lastYAuto = Canvas.gameScr.mainChar.yTo;
			}
			changeSinceLastUpdate = true;
			mainChar.comeHome = false;
			countStep++;
		}
		if (mSystem.currentTimeMillis() - timeMove >= 0 && !mainChar.stop)
		{
			timeMove = mSystem.currentTimeMillis() + dtmove;
			gameService.moveChar(moveToX, moveToY);
		}
	}

	public void updateWhenTalkPhuOng()
	{
		if (iTaskAuto == 2 || focusedActor == null || !Canvas.isPointerClick)
		{
			return;
		}
		int num = cmx + Canvas.px;
		int num2 = cmy + Canvas.py;
		if (focusedActor.catagory == Actor.CAT_MY_GROUND)
		{
			return;
		}
		for (int i = 0; i < actors.size(); i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (Util.abs(actor.x - num) >= 20 || Util.abs(actor.y - 20 - num2) >= 40)
			{
				continue;
			}
			Canvas.isPointerClick = false;
			if (focusedActor.ID == actor.ID)
			{
				if (actor is Char && (mainChar.pk <= 0 || map / 100 == 3))
				{
					focusedActor = null;
					return;
				}
				if (focusedActor.catagory != 2 || actor.catagory != 2)
				{
					return;
				}
				if (((NPC)focusedActor).type == ((NPC)actor).type)
				{
					if (((NPC)actor).type != 4)
					{
						Canvas.keyPressed[5] = true;
						return;
					}
					if (((NPC)focusedActor).idLinhGac == ((NPC)actor).idLinhGac)
					{
						focusedActor = null;
						return;
					}
					if (actor.ID != mainChar.ID)
					{
						focusedActor = null;
						if (map == 29)
						{
							findRoad(num, num2);
						}
						return;
					}
				}
			}
			if (actor.ID != mainChar.ID)
			{
				focusedActor = null;
				if (map == 29)
				{
					findRoad(num, num2);
				}
			}
			return;
		}
		focusedActor = null;
	}

	public void removeFocusWhenPutKey()
	{
		if (map == 17 && mainChar.isDoing)
		{
			focusedActor = null;
			coutChangeFocusWhenDoing = 0;
		}
	}

	public override void updateKey()
	{
		if (chatMode && Canvas.currentDialog == null && Canvas.isPointerClick)
		{
			switch (Canvas.collisionCmdBar())
			{
			case 0:
				Canvas.clearKeyHold();
				Canvas.clearKeyPressed();
				chatMode = false;
				Canvas.isPointerClick = false;
				return;
			case 1:
			{
				string text = tfChat.getText();
				Out.println("THONG TIN CHAT  " + text);
				tfChat.setText(string.Empty);
				doChatFromMe(text);
				Canvas.isPointerClick = false;
				return;
			}
			case 2:
				tfChat.clear();
				Canvas.isPointerClick = false;
				return;
			}
		}
		if (Canvas.keyPressed[11])
		{
			cheat = !cheat;
		}
		if (doIntro() || chatMode)
		{
			return;
		}
		if (currQuest != null && currQuest.isShow)
		{
			currQuest.update(mainChar, focusedActor);
		}
		else
		{
			if (doTalkWithNPCQuest() || doTalkWithNPCResponse() || doReceiveQuest())
			{
				return;
			}
			int num = 0;
			if (idChiemThanh != null)
			{
				for (int i = 0; i < idChiemThanh.Length; i++)
				{
					if (idChiemThanh[i] == mainChar.ID && timeChiemThanh[i] - (mSystem.getCurrentTimeMillis() / 1000 - curTimeCT[i]) >= 0)
					{
						num = 1;
					}
				}
			}
			if (num == 0)
			{
				updateTouchMHP();
				updatePoint();
			}
			base.updateKey();
			if (mainChar.justStopFromRun)
			{
				mainChar.justStopFromRun = false;
				changeSinceLastUpdate = true;
				changeSinceLastUpdate = false;
				mainChar.stop = false;
				sendActorMove(mainChar.x, mainChar.y);
			}
			if (Canvas.isKeyPressed((!Main.isPC) ? 10 : 21))
			{
				if (Main.isPC)
				{
					if (Canvas.currentDialog == null)
					{
						doParty();
						Canvas.clearKeyHold();
					}
				}
				else
				{
					doParty();
					Canvas.clearKeyHold();
				}
				return;
			}
			if (Main.isPC && Canvas.currentDialog == null)
			{
				if (Canvas.isKeyPressed(KeyConst.Y))
				{
					Canvas.gameScr.chatMode = true;
					Canvas.endDlg();
					ActionPerform ok = delegate
					{
						doChatFromMe(Canvas.inputDlg.tfInput.getText());
						Canvas.inputDlg.tfInput.setText(string.Empty);
					};
					Canvas.inputDlg.setInfo("Nội dung Chat", ok, TField.INPUT_TYPE_ANY, 100, isMaxW: false);
					Canvas.inputDlg.show();
					return;
				}
				if (Canvas.isKeyPressed(KeyConst.U))
				{
					GameService.gI().setConfig(6);
					Canvas.endDlg();
					return;
				}
				if (Canvas.isKeyPressed(KeyConst.I))
				{
					if (indexTabSlot == 0)
					{
						indexTabSlot = 1;
					}
					else
					{
						indexTabSlot = 0;
					}
					xSlot = Res.wKhung;
					return;
				}
			}
			if (autoFight)
			{
				if (indexBuff != -1 && timeBuff - mSystem.getCurrentTimeMillis() / 1000 > 0)
				{
					isBeginAutoBuff = true;
				}
				else
				{
					isBeginAutoBuff = false;
				}
			}
			if (mainChar.state != 3 && (autoFight || autoBomHMP) && !mainChar.isDie && Tilemap.lv != 0 && Tilemap.lv != 201 && Tilemap.lv != 70 && Tilemap.lv != 80 && !Tilemap.isOfflineMap)
			{
				if (autoBomHMP && (Canvas.autoTab.isAutoMHP || Canvas.autoTab.isAll) && timeDelayHpMp - mSystem.currentTimeMillis() / 1000 <= 0)
				{
					int num2 = mainChar.hp * 100 / mainChar.maxhp;
					int num3 = mainChar.mp * 100 / mainChar.maxmp;
					if (num2 < BangAuto.bomHp && mainChar.hp < mainChar.maxhp)
					{
						isAutoBomHp = true;
					}
					if (num3 < BangAuto.bomMp && mainChar.mp < mainChar.maxmp)
					{
						isAutoBomMp = true;
					}
					if (num2 >= BangAuto.bomHp)
					{
						isAutoBomHp = false;
					}
					if (num3 >= BangAuto.bomMp)
					{
						isAutoBomMp = false;
					}
					if (isAutoBomHp && !mainChar.beStune)
					{
						doFire(7, indexTabSlot);
					}
					if (isAutoBomMp && !mainChar.beStune)
					{
						doFire(9, indexTabSlot);
					}
					timeDelayHpMp = mSystem.currentTimeMillis() / 1000 + 1;
				}
				if (autoFight && (Canvas.autoTab.isAutoFire || Canvas.autoTab.isAll) && BangAuto.tgDelay - mSystem.currentTimeMillis() / 100 <= 0)
				{
					if (mainChar.isDoing)
					{
						if (focusedActor != null && focusedActor.catagory != Actor.CAT_NPC && focusedActor.catagory != Actor.CAT_PLAYER && focusedActor.catagory != Actor.CAT_EXPLOTION)
						{
							Canvas.keyPressed[5] = true;
						}
						else
						{
							changeToNextFocusActor(isBack: false);
						}
					}
					else
					{
						if (focusedActor != null && focusedActor.catagory != Actor.CAT_NPC && focusedActor.catagory != Actor.CAT_EXPLOTION)
						{
							bool flag = false;
							if (focusedActor.catagory == Actor.CAT_PLAYER && !focusedActor.iskiller)
							{
								changeToNextFocusActor(isBack: false);
								flag = true;
							}
							if (!flag)
							{
								Canvas.keyPressed[dem] = true;
								dem += 2;
								if (dem > 5)
								{
									dem = 1;
								}
							}
						}
						else
						{
							changeToNextFocusActor(isBack: false);
						}
						if (!isBeginAutoBuff)
						{
							if (mainChar.clazz != 2)
							{
								doFire(1, 1);
								doFire(3, 1);
								doFire(5, 1);
							}
							else if (!isBuffHoisinh())
							{
								doFire(1, 1);
								doFire(3, 1);
								doFire(5, 1);
							}
						}
					}
					BangAuto.tgDelay = (int)(mSystem.currentTimeMillis() / 100 + 10);
				}
				if (Canvas.keyPressed[7])
				{
					Canvas.keyPressed[7] = false;
					doFire(7, indexTabSlot);
				}
				if (Canvas.keyPressed[9])
				{
					Canvas.keyPressed[9] = false;
					doFire(9, indexTabSlot);
				}
			}
			for (int j = 0; j < QUICKSLOT_KEY.Length; j++)
			{
				if (Canvas.isKeyPressed(QUICKSLOT_KEY[j]))
				{
					if (!mainChar.beStune)
					{
						doFire(QUICKSLOT_KEY[j], indexTabSlot);
					}
					break;
				}
			}
			if (Canvas.menu.showMenu)
			{
				Canvas.keyPressed[5] = false;
			}
			else if ((Canvas.isKeyPressed(2) || Canvas.isKeyPressed(4) || Canvas.isKeyPressed(6) || Canvas.isKeyPressed(8)) && mainChar.state == 3)
			{
				mainChar.stop = false;
			}
			else if ((mainChar.state == 1 || mainChar.state == 0 || mainChar.state == 4) && num == 0)
			{
				doActorMove();
			}
		}
	}

	public bool isBuffHoisinh()
	{
		sbyte[] array = new sbyte[3] { 1, 3, 5 };
		for (int i = 0; i < array.Length; i++)
		{
			QuickSlot quickSlot = MainChar.quickSlot[1][SLOTINDEXOFKEY[array[i]]];
			if (mainChar.clazz == 2 && quickSlot.getSkillType() == 6)
			{
				return true;
			}
		}
		return false;
	}

	private void updateTask()
	{
		if (mainChar.posTransRoad != null)
		{
			return;
		}
		if (Char.skillLevelLearnt[0] == 0)
		{
			if (posNpcRequest != null && posNpcRequest.x / 16 == 6 && posNpcRequest.y / 16 == 7)
			{
				posNpcRequest.x = 160;
			}
			if (Util.distance(mainChar.x, mainChar.y, posNpcRequest.x, posNpcRequest.y) > 32)
			{
				mainChar.posTransRoad = updateFindRoad(mainChar.x / 16, mainChar.y / 16, posNpcRequest.x / 16, posNpcRequest.y / 16 + 2);
				mainChar.countRoad = 0;
				return;
			}
			mainChar.dir = 1;
			if (mSystem.getCurrentTimeMillis() / 100 - timeTaskAuto <= timeDelayTask)
			{
				return;
			}
			timeDelayTask = 3;
			int num = actors.size();
			for (int i = 0; i < num; i++)
			{
				Actor actor = (Actor)actors.elementAt(i);
				if (actor != null && actor is NPC && ((NPC)actor).type == idNpcReceive)
				{
					focusedActor = actor;
					break;
				}
			}
			timeTaskAuto = mSystem.getCurrentTimeMillis() / 100;
			if (Canvas.menu.showMenu)
			{
				Canvas.menu.selected = 0;
				Canvas.menu.center.perform();
				Canvas.menu.showMenu = false;
			}
			else
			{
				Canvas.keyPressed[5] = true;
			}
		}
		else
		{
			iTaskAuto = 0;
		}
	}

	public bool checkCanChangeMap(int x, int y, int dir)
	{
		CMLocation cMLocation = Tilemap.toOtherMapAt(x + X_FOWARD[dir], y + Y_FOWARD[dir]);
		if (cMLocation != null)
		{
			ChangScr.gI().setMap(map, cMLocation.toX, cMLocation.toY);
			mainChar.state = 0;
			if (!Tilemap.isOfflineMap)
			{
				if (!isOffLineMap(cMLocation.toM))
				{
					int indexArrMap = getIndexArrMap();
					string[] name = Res.getNameMap(indexArrMap, cMLocation.toM);
					short[] local = Res.getLocation(indexArrMap, cMLocation.toM);
					mVector mVector2 = new mVector();
					int num = name.Length;
					for (int j = 0; j < num; j++)
					{
						int i = j;
						if (name[j].Equals(string.Empty))
						{
							continue;
						}
						Command command = new Command(name[j]);
						ActionPerform action = delegate
						{
							int toX = local[i * 3 + 1];
							int toY = local[i * 3 + 2];
							GameService.gI().changeMap(local[i * 3], toX, toY);
							ChangScr.gI().switchToMe();
							int num2 = objDynamic.size();
							for (int k = 0; k < num2; k++)
							{
								DynamicObj dynamicObj = (DynamicObj)objDynamic.elementAt(k);
								if (dynamicObj != null)
								{
									dynamicObj = null;
									objDynamic.removeElementAt(k);
								}
							}
							Res.removeMonsterTemplet();
							nameMap = name[i];
						};
						command.action = action;
						mVector2.addElement(command);
					}
					Canvas.menu.startAt(mVector2, 3);
					Canvas.menu.setIndex();
				}
				else
				{
					oldMap = map;
					GameService.gI().changeMap(cMLocation.toM, cMLocation.toX, cMLocation.toY);
					ChangScr.gI().switchToMe();
					Res.removeMonsterTemplet();
				}
			}
			else
			{
				GameService.gI().changeMap(oldMap, cMLocation.toX, cMLocation.toY);
				ChangScr.gI().switchToMe();
				Res.removeMonsterTemplet();
			}
			return true;
		}
		return false;
	}

	private void doFire(int key, int index)
	{
		if (mainChar.state == 3)
		{
			Canvas.msgdlg.isIcon = false;
			indexBuff = -1;
			timeBuff = 0L;
			mainChar.resetBuff();
			if (saveAutoFight)
			{
				autoFight = saveAutoFight;
			}
			if (BangAuto.isAutoComeHome && autoFight)
			{
				GameService.gI().comeHomeWhenDie();
				ChangScr.gI().switchToMe();
				ChangScr.gI().setMap(map, 0, 0);
				autoFight = (saveAutoFight = false);
				return;
			}
			Command command = new Command("Về làng");
			Command command2 = new Command("Hồi sinh");
			command.action = delegate
			{
				GameService.gI().comeHomeWhenDie();
				ChangScr.gI().switchToMe();
				ChangScr.gI().setMap(map, 0, 0);
				autoFight = (saveAutoFight = false);
			};
			command2.action = delegate
			{
				GameService.gI().doCustomPopup(mainChar.ID, -1, string.Empty, 1);
				Canvas.currentDialog = null;
			};
			Command command3 = new Command("Đóng");
			command3.action = delegate
			{
				Canvas.currentDialog = null;
			};
			Canvas.msgdlg.setInfo("Quay về làng.", command, command2, command3);
			Canvas.currentDialog = Canvas.msgdlg;
		}
		else
		{
			if (Main.isPC && Canvas.currentDialog != null)
			{
				return;
			}
			mainChar.stand = mSystem.getCurrentTimeMillis();
			if (mainChar.state == 3)
			{
				Canvas.msgdlg.isIcon = false;
				indexBuff = -1;
				timeBuff = 0L;
				mainChar.resetBuff();
				if (BangAuto.isAutoComeHome && autoFight)
				{
					GameService.gI().comeHomeWhenDie();
					ChangScr.gI().switchToMe();
					ChangScr.gI().setMap(map, 0, 0);
					autoFight = (saveAutoFight = false);
					return;
				}
				Command command4 = new Command("Về làng");
				ActionPerform action = delegate
				{
					GameService.gI().comeHomeWhenDie();
					ChangScr.gI().switchToMe();
					ChangScr.gI().setMap(map, 0, 0);
					autoFight = (saveAutoFight = false);
				};
				command4.action = action;
				Command command5 = new Command("Chờ");
				ActionPerform action2 = delegate
				{
					Canvas.currentDialog = null;
				};
				command5.action = action2;
				Canvas.msgdlg.setInfo("Quay về làng.", null, command4, command5);
				Canvas.currentDialog = Canvas.msgdlg;
				return;
			}
			if (focusedActor != null && focusedActor.isNpcChar())
			{
				mVector allQuestNpc = getAllQuestNpc(focusedActor.getTypeNpc());
				if (allQuestNpc.size() > 0 && focusedActor.isNpcChar())
				{
					mVector mVector2 = allQuestNpc;
					Command command6 = new Command("Nói chuyện");
					command6.action = delegate
					{
						GameService.gI().requestNPCInfo(((Char)focusedActor).idBoss);
					};
					mVector2.addElement(command6);
					Canvas.menu.startAt(mVector2, 3);
				}
				else
				{
					GameService.gI().requestNPCInfo(((Char)focusedActor).idBoss);
				}
				return;
			}
			QuickSlot quickSlot = MainChar.quickSlot[index][SLOTINDEXOFKEY[key]];
			if (quickSlot.quickslotType != QuickSlot.TYPE_POTION)
			{
				if (quickSlot.isBuff && !(focusedActor is NPC))
				{
					sbyte b = Char.skillLevelLearnt[quickSlot.getSkillType()];
					if (b <= 0)
					{
						return;
					}
					int num = SkillManager.EFF_BUFF_SKILL[Canvas.gameScr.mainChar.clazz][quickSlot.getSkillType() - 4];
					int skillMP = SkillManager.getSkillMP(quickSlot.getSkillType(), Char.skillLevelLearnt[quickSlot.getSkillType() - 4], Canvas.gameScr.mainChar.clazz);
					if (skillMP > Canvas.gameScr.mainChar.mp)
					{
						if (!first)
						{
							addChat(new ChatInfo(string.Empty, "Không đủ MP", 0));
							first = true;
						}
						return;
					}
					first = false;
					if (focusedActor != null && focusedActor.catagory == Actor.CAT_PLAYER)
					{
						if (quickSlot.getSkillType() == 6)
						{
							GameService.gI().useBuff(focusedActor.ID, 0, (sbyte)num, 0);
							mainChar.mp -= skillMP;
						}
						else
						{
							mainChar.mp -= skillMP;
							indexBuff = quickSlot.getSkillType();
							WindowInfoScr.gI().doCastBuffToActor(mainChar, focusedActor, num, SkillManager.SKILL_CAN_BUFF_TO_USER[mainChar.clazz][quickSlot.getSkillType() - 4] == 1);
						}
					}
					else if (quickSlot.getSkillType() != 6)
					{
						mainChar.mp -= skillMP;
						if (quickSlot.isBuff && (Canvas.gameScr.indexBuff == -1 || Canvas.gameScr.indexBuff == quickSlot.getSkillType()))
						{
							Canvas.gameScr.indexBuff = quickSlot.getSkillType();
						}
						long num2 = mSystem.getCurrentTimeMillis() - mainChar.timeLastUseSkills[quickSlot.getSkillType()];
						if (autoFight && num2 <= Canvas.gameScr.mainChar.coolDownSkill[quickSlot.getSkillType()] && timeBuff - mSystem.getCurrentTimeMillis() / 1000 < 0 && isBuffAuto)
						{
							num2 = Canvas.gameScr.mainChar.coolDownSkill[quickSlot.getSkillType()] + 1;
							isBuffAuto = false;
							Out.println("Kiem tra auto buff ================================");
						}
						if (num2 > Canvas.gameScr.mainChar.coolDownSkill[quickSlot.getSkillType()])
						{
							GameService.gI().useBuff(Canvas.gameScr.mainChar.ID, 0, (sbyte)num, 0);
							mainChar.coolDownSkill[quickSlot.getSkillType()] = SkillManager.getSkillCooldown(quickSlot.getSkillType(), mainChar.clazz, Char.skillLevelLearnt[quickSlot.getSkillType()]);
							mainChar.timeLastUseSkills[quickSlot.getSkillType()] = mSystem.getCurrentTimeMillis();
						}
					}
					else
					{
						Canvas.startOKDlg("Chỉ có thể hồi sinh cho người đã hết HP.");
					}
					return;
				}
				if (focusedActor != null && focusedActor.catagory == Actor.CAT_NPC && Char.skillLevelLearnt[quickSlot.getSkillType()] >= 0)
				{
					doUseSkillToFocusActor(quickSlot.getSkillType());
				}
				if (focusedActor != null)
				{
					long num3 = mSystem.getCurrentTimeMillis() - mainChar.timeLastUseSkills[quickSlot.getSkillType()];
					if (focusedActor.catagory != 2 && num3 > Canvas.gameScr.mainChar.coolDownSkill[quickSlot.getSkillType()] && (Char.skillLevelLearnt[quickSlot.getSkillType()] > 0 || focusedActor.catagory == Actor.CAT_MY_GROUND))
					{
						doUseSkillToFocusActor(quickSlot.getSkillType());
					}
				}
			}
			else if (quickSlot.quickslotType == QuickSlot.TYPE_POTION)
			{
				doUsePotion(quickSlot.getPotionType());
			}
		}
	}

	public void doUsePotion(int potionType)
	{
		if (potionType >= Canvas.gameScr.mainChar.potions.Length)
		{
			return;
		}
		if (Canvas.gameScr.mainChar.potions[potionType] <= 0)
		{
			int num = MainChar.quickSlot[indexTabSlot].Length;
			int[] array = new int[7] { 94, 93, 22, 21, 3, 2, 1 };
			int[] array2 = new int[7] { 96, 95, 24, 23, 6, 5, 4 };
			for (int i = 0; i < num; i++)
			{
				if (MainChar.quickSlot[indexTabSlot][i].quickslotType != QuickSlot.TYPE_POTION || MainChar.quickSlot[indexTabSlot][i].getPotionType() != potionType)
				{
					continue;
				}
				MainChar.quickSlot[indexTabSlot][i].setIsNothing();
				if (potionType == 1 || potionType == 2 || potionType == 3 || potionType == 21 || potionType == 22 || potionType == 93 || potionType == 94)
				{
					bool flag = false;
					for (int j = 1; j <= 3; j++)
					{
						if (j != potionType && Canvas.gameScr.mainChar.potions[j] > 0)
						{
							MainChar.quickSlot[indexTabSlot][i].setIsPotion(j);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						for (int k = 0; k < array.Length; k++)
						{
							if (Canvas.gameScr.mainChar.potions[array[k]] > 0)
							{
								MainChar.quickSlot[indexTabSlot][i].setIsPotion(array[k]);
								break;
							}
						}
					}
				}
				if (potionType != 4 && potionType != 5 && potionType != 6 && potionType != 23 && potionType != 24 && potionType != 95 && potionType != 96)
				{
					continue;
				}
				bool flag2 = false;
				for (int l = 4; l <= 6; l++)
				{
					if (l != potionType && Canvas.gameScr.mainChar.potions[l] > 0)
					{
						MainChar.quickSlot[indexTabSlot][i].setIsPotion(l);
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				for (int m = 0; m < array2.Length; m++)
				{
					if (Canvas.gameScr.mainChar.potions[array2[m]] > 0)
					{
						MainChar.quickSlot[indexTabSlot][i].setIsPotion(array2[m]);
						break;
					}
				}
			}
			RMS.saveQuickSlot();
			return;
		}
		long currentTimeMillis = mSystem.getCurrentTimeMillis();
		if (currentTimeMillis - mainChar.potionLastTimeUse[potionType] < MainChar.listPotion[potionType].delay || (mainChar.hp >= mainChar.maxhp && (potionType == 1 || potionType == 2 || potionType == 3 || potionType == 21 || potionType == 22 || potionType == 93 || potionType == 94)) || (mainChar.mp >= mainChar.maxmp && (potionType == 4 || potionType == 5 || potionType == 6 || potionType == 23 || potionType == 24 || potionType == 95 || potionType == 96)))
		{
			return;
		}
		if (potionType == 19)
		{
			if (map == 0)
			{
				Canvas.startOKDlg("Không thể sử dụng trong làng.");
				return;
			}
			Canvas.gameScr.mainChar.timeComeHome = mSystem.getCurrentTimeMillis();
			Canvas.gameScr.mainChar.comeHome = true;
			Canvas.gameScr.mainChar.state = 4;
		}
		if (potionType < 10 || potionType > 20)
		{
			mainChar.potions[potionType]--;
			mainChar.potionLastTimeUse[potionType] = currentTimeMillis;
		}
		if (mainChar.state != 3 && autoFight && !mainChar.isDie && Tilemap.lv != 0 && Tilemap.lv != 201 && Tilemap.lv != 70 && Tilemap.lv != 80 && !Tilemap.isOfflineMap)
		{
			mainChar.hp += getMpHpPutKey(0, potionType);
			mainChar.mp += getMpHpPutKey(1, potionType);
			if (mainChar.hp >= mainChar.maxhp)
			{
				mainChar.hp = mainChar.maxhp;
			}
			if (mainChar.mp >= mainChar.maxmp)
			{
				mainChar.mp = mainChar.maxmp;
			}
		}
		GameService.gI().usePotion(potionType);
	}

	public int getMpHpPutKey(int type, int idPotion)
	{
		for (int i = 0; i < TYPE_MP_HP[type].Length; i++)
		{
			if (TYPE_MP_HP[type][i] == idPotion)
			{
				return VALUE_MP_HP[type][i];
			}
		}
		return 0;
	}

	public void doParty()
	{
		if (focusedActor != null)
		{
			if (focusedActor.catagory == Actor.CAT_PLAYER)
			{
				mVector mVector2 = new mVector();
				Command command = new Command("Mời party");
				ActionPerform action = delegate
				{
					if (((Char)focusedActor).pk > 0 || ((Char)focusedActor).iskiller)
					{
						Canvas.startOKDlg("Không thể mời người trong trạng thái đánh nhau hoặc phạm tội");
					}
					else if (mainChar.IDParty == -1)
					{
						gameService.requestCreateParty(mainChar.ID);
						tempIDActorParty = focusedActor.ID;
					}
					else
					{
						gameService.invite2Party(focusedActor.ID);
					}
				};
				command.action = action;
				mVector2.addElement(command);
				if (map != 0)
				{
				}
				Command command2 = new Command("Trao đổi");
				ActionPerform action2 = delegate
				{
					if (!mainChar.isTrade)
					{
						gameService.trade(focusedActor.ID);
					}
				};
				command2.action = action2;
				mVector2.addElement(command2);
				Command command3 = new Command("Mời đám cưới");
				ActionPerform action3 = delegate
				{
					gameService.invite2Party(focusedActor.ID, 3);
				};
				command3.action = action3;
				mVector2.addElement(command3);
				if (focusedActor is Char)
				{
					Command command4 = new Command("Nhắn tin");
					ActionPerform action4 = delegate
					{
						MessageScr.gI().addTab(string.Empty, ((Char)focusedActor).name, 0);
						MessageScr.gI().setFocusTab(((Char)focusedActor).name);
						MessageScr.gI().switchToMe();
					};
					command4.action = action4;
					mVector2.addElement(command4);
				}
				Command command5 = new Command("Kết bạn");
				ActionPerform action5 = delegate
				{
					gameService.sendInfoAddFriend(((Char)focusedActor).ID, 0);
				};
				command5.action = action5;
				mVector2.addElement(command5);
				if ((Canvas.gameScr.mainChar.isMaster == 0 || Canvas.gameScr.mainChar.isMaster == 1 || Canvas.gameScr.mainChar.isMaster == 2) && ((Char)focusedActor).idClan == -1)
				{
					Command command6 = new Command("Mời vào bang hội");
					ActionPerform action6 = delegate
					{
						gameService.sendRequestAddClan(focusedActor.ID, 0, iss: false);
					};
					command6.action = action6;
					mVector2.addElement(command6);
				}
				if (((Char)focusedActor).idClan != -1)
				{
					Command command7 = new Command("Xem thông tin bang hội");
					ActionPerform action7 = delegate
					{
						gameService.requestClanInfo(((Char)focusedActor).idClan);
					};
					command7.action = action7;
					mVector2.addElement(command7);
				}
				Command command8 = new Command("Xem thông tin");
				ActionPerform action8 = delegate
				{
					Canvas.startWaitDlg();
					if (focusedActor != null)
					{
						saveIDViewInfoAnimal = focusedActor.ID;
						gameService.requestSomeOneInfo(focusedActor.ID, 0);
					}
					else
					{
						Canvas.startOKDlg("Không tìm thấy thông tin");
					}
				};
				command8.action = action8;
				mVector2.addElement(command8);
				Command command9 = new Command("Xuống ngựa");
				ActionPerform action9 = delegate
				{
					unRideHorse();
				};
				command9.action = action9;
				mVector2.addElement(command9);
				Canvas.menu.startAt(mVector2, 2);
			}
			else
			{
				Canvas.keyPressed[5] = false;
			}
		}
		else
		{
			unRideHorse();
		}
	}

	public void unRideHorse()
	{
		if (mainChar.useHorse != -1 || mainChar.idhorse > -1)
		{
			ActionPerform yesAction = delegate
			{
				gameService.unRideHorse(0);
				Canvas.currentDialog = null;
			};
			Canvas.startYesNoDlg("Ngựa sẽ bị mất nếu rương đồ không còn chỗ. Bạn có muốn xuống ngựa không ?", yesAction);
		}
	}

	protected mVector getNearMonster(Actor mt, int distance)
	{
		mVector mVector2 = new mVector();
		mVector2.addElement(mt);
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == Actor.CAT_MONSTER && actor.state != 8 && actor.ID != mt.ID && abs(actor.x - mt.x) <= distance && abs(actor.y - mt.y) <= distance)
			{
				mVector2.addElement(actor);
				if (mVector2.size() > 10)
				{
					break;
				}
			}
		}
		return mVector2;
	}

	private bool isMapPK()
	{
		if (Tilemap.lv == 112 || Tilemap.lv == 2541 || Tilemap.lv == 2542 || Tilemap.lv == 2543 || Tilemap.lv == 2544)
		{
			return true;
		}
		return false;
	}

	private bool isChiemThanh()
	{
		if (((mainChar.x > xArena * 16 && mainChar.y > yArena * 16 && mainChar.x < wArena * 16 && mainChar.y < hArena * 16) || isFight) && focusedActor.catagory != Actor.CAT_NPC && Tilemap.lv == 201)
		{
			return true;
		}
		return false;
	}

	private bool isFocusKiller()
	{
		Char @char = (Char)focusedActor;
		if (@char != null && @char.iskiller)
		{
			return true;
		}
		return false;
	}

	public static void addviewInfo(Actor ac, string str, int time)
	{
		if (ac != null)
		{
			ac.chat = new ChatPopup(time, str, 0);
			ac.chat.setPos(ac.x, ac.y);
		}
	}

	public void doViewInfoGround(string text, Actor obj)
	{
		obj.chat = null;
		addviewInfo(obj, text, 50);
	}

	public void addMsgWorld(string info)
	{
		MsgInfo o = new MsgInfo(info);
		msgWorld.addElement(o);
		savemsgWorld.addElement(o);
	}

	public void sendActorMove(int x, int y)
	{
		mainChar.stop = false;
		if (mSystem.currentTimeMillis() - timeMove >= 0)
		{
			timeMove = mSystem.currentTimeMillis() + dtmove;
			gameService.moveChar(x, y);
		}
	}

	public void doUseSkillToFocusActor(sbyte skillType)
	{
		sbyte skillIDFromType = mainChar.getSkillIDFromType(skillType);
		try
		{
			if (focusedActor == null || (autoFight && (focusedActor.isNPC() || focusedActor.isNpcChar())))
			{
				return;
			}
			if (iTaskAuto != 2 && timeRemovePos <= 0)
			{
				mainChar.posTransRoad = null;
				tg.x = (tg.y = -1);
			}
			if (focusedActor.isMonster() || (mainChar.nationID != focusedActor.nationID && focusedActor.isPlayer()) || (focusedActor.isPlayer() && ((idMapPK == Tilemap.lv && mainChar.idClan != ((Char)focusedActor).idClan) || (focusedActor.pk > 0 && mainChar.pk > 0 && focusedActor.pk != mainChar.pk))) || (mainChar.iskiller && focusedActor.isPlayer()) || (focusedActor.isPlayer() && (isChiemThanh() || isMapPK() || isFocusKiller())) || (focusedActor.isPlayer() && ((Char)focusedActor).isAnimal) || (mainChar.isAnimal && (focusedActor.isMonster() || focusedActor.isPlayer())))
			{
				int num = 0;
				if (focusedActor.isMonster() && ((Monster)focusedActor).isMineral())
				{
					num = 1;
					skillIDFromType = mainChar.getSkillIDFromType(0);
					skillType = 0;
				}
				if (!focusedActor.isPlayer() || !focusedActor.isNPC())
				{
					int skillMP = SkillManager.getSkillMP(skillType, Char.skillLevelLearnt[skillType], mainChar.clazz);
					if (skillMP > mainChar.mp)
					{
						if (!first)
						{
							addChat(new ChatInfo(string.Empty, "Không đủ MP", 0));
							first = true;
						}
						return;
					}
					if (autoFight)
					{
						mainChar.idMonster = focusedActor.ID;
						mainChar.autoFight = true;
					}
					first = false;
					LiveActor liveActor = (LiveActor)focusedActor;
					if ((liveActor.realHP <= 0 || liveActor.hp <= 0) && liveActor.catagory == Actor.CAT_PLAYER)
					{
						return;
					}
					int num2 = SkillManager.getSkillRange(skillType, mainChar.clazz);
					if (num == 1)
					{
						num2 = 30;
					}
					if (Util.distance(mainChar.x, mainChar.y, liveActor.x, liveActor.y) > num2)
					{
						coutChangeFocusWhenDoing++;
						moveToRange(liveActor, num2);
					}
					else
					{
						isAutoRangeWhenAuto = false;
						coutChangeFocusWhenDoing = 0;
						if ((mainChar.iskiller && focusedActor.catagory == Actor.CAT_PLAYER && ((Char)focusedActor).level < 10 && mainChar.nationID == focusedActor.nationID) || (focusedActor.catagory == Actor.CAT_MONSTER && ((Monster)focusedActor).state == 5))
						{
							return;
						}
						long currentTimeMillis = mSystem.getCurrentTimeMillis();
						if (currentTimeMillis - mainChar.timeLastUseSkills[skillType] > mainChar.coolDownSkill[skillType])
						{
							mainChar.dir = Util.findDirection(mainChar, liveActor);
							AttackResult attackResult = new AttackResult();
							attackResult.dam = 2000000;
							mainChar.mp -= skillMP;
							mainChar.startAttack(liveActor, attackResult, skillType, Char.skillLevelLearnt[skillType]);
							bool flag = SkillManager.isSkillAeo(mainChar.clazz, skillType);
							mVector mVector2 = new mVector();
							if (flag)
							{
								if (liveActor.catagory == Actor.CAT_MONSTER)
								{
									mainChar.currentSkillAnimate.setMonster(mVector2 = getNearMonster(liveActor, SkillManager.getRangeSkillAeo(mainChar.clazz, skillType)));
								}
								else if (liveActor.catagory == Actor.CAT_PLAYER)
								{
									mVector2.addElement(liveActor);
									mainChar.currentSkillAnimate.setMonster(mVector2);
								}
							}
							changeSinceLastUpdate = false;
							switch (liveActor.catagory)
							{
							case 0:
								gameService.attackOtherPlayer(liveActor.ID, skillType, attackResult.effect, attackResult.dam, 0, attackResult.buffEffect);
								mainChar.downDurableWeapone();
								break;
							case 1:
								if (!flag)
								{
									gameService.attackMonster(liveActor.ID, skillType, attackResult.effect, attackResult.dam, 0, attackResult.buffEffect);
								}
								else
								{
									gameService.attackMultiMonster(liveActor.ID, skillType, attackResult.effect, attackResult.dam, 0, attackResult.buffEffect, mVector2);
								}
								mainChar.downDurableWeapone();
								break;
							}
							return;
						}
					}
				}
			}
			if (focusedActor != null && focusedActor.isItemCanGet())
			{
				Dropable dropable = (Dropable)focusedActor;
				if (dropable.isSendGet)
				{
					return;
				}
				if (Util.distance(mainChar.x, mainChar.y, dropable.x, dropable.y) <= 35)
				{
					bool flag2 = true;
					string content = string.Empty;
					if (dropable.catagory == Actor.CAT_POTION)
					{
						if (dropable.item_template_id == 0 && mainChar.charXu > 100000000)
						{
							flag2 = false;
							content = "Quá nhiều tiền";
						}
					}
					else if (dropable.catagory == 3 && Canvas.gameScr.mainChar.isFullInventory())
					{
						content = "Hành trang đã đầy";
						flag2 = false;
					}
					if (!flag2)
					{
						addChat(new ChatInfo(string.Empty, content, 0));
						changeToNextFocusActor(isBack: false);
						return;
					}
					mainChar.dir = Util.findDirection(mainChar, dropable);
					sendActorMove(mainChar.x, mainChar.y);
					changeSinceLastUpdate = false;
					gameService.getDropableFromGround(dropable.catagory, dropable.ID);
					return;
				}
				moveToRange(dropable, 35);
			}
			if (focusedActor.isNPC())
			{
				if (focusedActor.getNpcType() == 1)
				{
					GameService.gI().requestNPCInfo(focusedActor.getTypeNpc());
					return;
				}
				if (!Tilemap.isOfflineMap)
				{
					mVector allQuestNpc = getAllQuestNpc(focusedActor.getTypeNpc());
					if (allQuestNpc.size() > 0 && !focusedActor.isNpcChar())
					{
						mVector mVector3 = allQuestNpc;
						if (posNpcReceiveClan != null && ((NPC)focusedActor).type == posNpcReceiveClan.index)
						{
							Command command = new Command("Nhiệm vụ bang hội");
							command.action = delegate
							{
								gameService.questClan(3);
								posNpcReceiveClan = null;
								Canvas.startWaitDlg();
							};
							mVector3.addElement(command);
						}
						Command command2 = new Command("Nói chuyện");
						command2.action = delegate
						{
							mainChar.chat = null;
							focusedActor.chat = null;
							if (!focusedActor.isNpcChar() && focusedActor.getTypeNpc() != 7 && focusedActor.getTypeNpc() != 10 && focusedActor.getTypeNpc() != 22 && focusedActor.getTypeNpc() != 31 && focusedActor.getTypeNpc() != 21 && focusedActor.getTypeNpc() != 25)
							{
								addChat(focusedActor, Res.getDefaultChat(focusedActor.getTypeNpc()), 500);
							}
							else if (!focusedActor.isNpcChar())
							{
								showNpcMenu(focusedActor.getTypeNpc(), new mVector());
							}
						};
						mVector3.addElement(command2);
						Canvas.menu.startAt(mVector3, 3);
						return;
					}
					focusedActor.chat = null;
					if (!focusedActor.isNpcChar() && focusedActor.getTypeNpc() != 7 && focusedActor.getTypeNpc() != 10 && focusedActor.getTypeNpc() != 22 && focusedActor.getTypeNpc() != 31 && focusedActor.getTypeNpc() != 21 && focusedActor.getTypeNpc() != 25)
					{
						addChat(focusedActor, Res.getDefaultChat(focusedActor.getTypeNpc()), 500);
					}
					else if (!focusedActor.isNpcChar())
					{
						showNpcMenu(focusedActor.getTypeNpc(), new mVector());
					}
				}
				else if (focusedActor.getTypeNpc() == 2 || (focusedActor.getTypeNpc() > 10 && focusedActor.getTypeNpc() != 29 && focusedActor.getTypeNpc() != 24 && focusedActor.getTypeNpc() != 26 && focusedActor.getTypeNpc() != 30) || focusedActor.getTypeNpc() == 3 || focusedActor.getTypeNpc() == 27 || focusedActor.getTypeNpc() == 28)
				{
					showNpcMenu(focusedActor.getTypeNpc(), new mVector());
				}
				else
				{
					GameService.gI().requestNPCInfo(focusedActor.getTypeNpc());
				}
			}
			if (focusedActor.catagory != Actor.CAT_MY_GROUND)
			{
				return;
			}
			mVector mVector4 = new mVector();
			if (focusedActor != null)
			{
				Ground ground = (Ground)focusedActor;
				if (ground.isBuyOk)
				{
					Command command3 = new Command("Xem thông tin");
					ActionPerform action = delegate
					{
						doViewInfoGround(focusedActor.infoGround, focusedActor);
					};
					command3.action = action;
					mVector4.addElement(command3);
					Command command4 = new Command("Nâng cấp đất");
					ActionPerform action2 = delegate
					{
						if (focusedActor != null)
						{
							Ground ground5 = (Ground)focusedActor;
							gameService.doPlant(4, (sbyte)ground5.ID);
						}
					};
					command4.action = action2;
					mVector4.addElement(command4);
					Command command5 = new Command("Trồng cây");
					ActionPerform action3 = delegate
					{
						if (focusedActor != null)
						{
							Ground ground4 = (Ground)focusedActor;
							gameService.doPlant(0, (sbyte)ground4.ID);
						}
					};
					command5.action = action3;
					mVector4.addElement(command5);
					Command command6 = new Command("Thu hoạch");
					ActionPerform action4 = delegate
					{
						if (focusedActor != null)
						{
							Ground ground3 = (Ground)focusedActor;
							gameService.doPlant(1, (sbyte)ground3.ID);
						}
					};
					command6.action = action4;
					mVector4.addElement(command6);
					Command command7 = new Command("Nhổ bỏ");
					ActionPerform action5 = delegate
					{
						if (focusedActor != null)
						{
							Ground gr40 = (Ground)focusedActor;
							if (gr40.myTree != null)
							{
								ActionPerform yesAction = delegate
								{
									gameService.doPlant(3, (sbyte)gr40.ID);
									Canvas.endDlg();
								};
								Canvas.startYesNoDlg("Bạn có muốn nhổ bỏ cây này không? ", yesAction);
							}
						}
					};
					command7.action = action5;
					mVector4.addElement(command7);
				}
				else
				{
					Command command8 = new Command("Mua đất");
					ActionPerform action6 = delegate
					{
						if (focusedActor != null)
						{
							Ground ground2 = (Ground)focusedActor;
							gameService.doPlant(2, (sbyte)ground2.ID);
						}
					};
					command8.action = action6;
					mVector4.addElement(command8);
				}
			}
			Canvas.menu.startAt(mVector4, 3);
		}
		catch (Exception)
		{
		}
	}

	private void moveToRange(Actor attackedLiveActor, int maxRange)
	{
		if ((autoFight && typeOptionFocus == 1 && mainChar.posTransRoad != null) || mainChar.posTransRoad != null || (isFight && map == 201))
		{
			return;
		}
		int num = Util.angle(attackedLiveActor.x - mainChar.x, -(attackedLiveActor.y - mainChar.y));
		int num2 = Util.distance(mainChar.x, mainChar.y, attackedLiveActor.x, attackedLiveActor.y);
		int num3 = (num2 - maxRange) * Util.Cos(num) >> 10;
		int num4 = -((num2 - maxRange) * Util.Sin(num)) >> 10;
		bool flag = false;
		if (num3 > 0)
		{
			if (num3 > 50)
			{
				num3 = 50;
			}
		}
		else if (num3 < 0 && num3 < -50)
		{
			num3 = -50;
		}
		if (num4 > 0)
		{
			if (num4 > 50)
			{
				num4 = 50;
			}
		}
		else if (num4 < 0 && num4 < -50)
		{
			num4 = -50;
		}
		if (autoFight && typeOptionFocus == 1 && focusedActor != null && focusedActor.iskiller)
		{
			flag = true;
		}
		if (map == 17)
		{
			if (autoFight && mainChar.isDoing && coutChangeFocusWhenDoing > 10)
			{
				changeToNextFocusActor(isBack: false);
				coutChangeFocusWhenDoing = 0;
			}
		}
		else if (autoFight && !flag)
		{
			num3 = (num4 = 0);
			changeToNextFocusActor(isBack: false);
		}
		if (flag && timeRemovePos <= 0 && (Math.abs(mainChar.x - mainChar.lastXAuto) > 120 || Math.abs(mainChar.y - mainChar.lastYAuto) > 120))
		{
			num3 = (num4 = 0);
			changeToNextFocusActor(isBack: true);
			mainChar.timeGoToLastXY = mSystem.currentTimeMillis() - 1;
			findRoad2(mainChar.lastXAuto, mainChar.lastYAuto);
		}
		mainChar.moveTo((short)(mainChar.x + num3), (short)(mainChar.y + num4));
		if (!autoFight || flag)
		{
			sendActorMove((short)(mainChar.x + num3), (short)(mainChar.y + num4));
		}
	}

	private void showNpcMenu(int type, mVector menu)
	{
		if (type == 3 || type == 27)
		{
			int num = Res.nameClazz.Length;
			for (int i = 0; i < num; i++)
			{
				int ii = i;
				Command command = new Command(Res.nameClazz[i]);
				ActionPerform action = delegate
				{
					GameService.gI().requestNPCInfo((short)type, ii);
					WindowInfoScr.gI().idClass = ii;
				};
				command.action = action;
				menu.addElement(command);
			}
			Canvas.menu.startAt(menu, 3);
		}
		else if (type == 2 || type == 28)
		{
			Command command2 = new Command("Mua bán");
			ActionPerform action2 = delegate
			{
				GameService.gI().requestNPCInfo((short)type);
			};
			command2.action = action2;
			if (iTaskAuto != 2)
			{
				menu.addElement(command2);
			}
			Command command3 = new Command("Nghiền bột");
			ActionPerform action3 = delegate
			{
				ScreenItemTim screenItemTim = new ScreenItemTim();
				screenItemTim.setSizeCell(5, isContinue: false);
				screenItemTim.switchToMe(this);
			};
			command3.action = action3;
			menu.addElement(command3);
			Command command4 = new Command("Thêm dòng");
			ActionPerform action4 = delegate
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(4, isContinue: false);
				ScreenDapDo.gI().tile = "Thêm dòng";
			};
			command4.action = action4;
			menu.addElement(command4);
			Command command5 = new Command("Luyện đồ");
			ActionPerform action5 = delegate
			{
				if (mainChar.haveItemImbue())
				{
					gameService.requestImbue(0);
				}
				else
				{
					Canvas.startOKDlg("Bạn chưa có nguyên tố để luyện, hãy đến nhà lão Địa chủ mua rồi quay lại đây.");
				}
			};
			command5.action = action5;
			menu.addElement(command5);
			Command command6 = new Command("Luyện đồ tự động");
			ScreenDapDo.gI().tile = "Luyện đồ tự động";
			command6.action = delegate
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(1, isContinue: false);
			};
			menu.addElement(command6);
			Command command7 = new Command("Cộng thuộc tính");
			ScreenDapDo.gI().tile = "Cộng thuộc tính";
			command7.action = delegate
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(0, isContinue: false);
			};
			menu.addElement(command7);
			Command command8 = new Command("Khóa đồ thú");
			command8.action = delegate
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(2, isContinue: false);
				ScreenDapDo.gI().tile = "Khóa đồ thú";
			};
			menu.addElement(command8);
			Command command9 = new Command("Khóa trang bị");
			command9.action = delegate
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(3, isContinue: false);
				ScreenDapDo.gI().tile = "Khóa trang bị";
			};
			menu.addElement(command9);
			Command command10 = new Command("Sửa đồ");
			ActionPerform action6 = delegate
			{
				mVector mVector3 = new mVector();
				Command command28 = new Command("Vũ khí");
				ActionPerform action24 = delegate
				{
					if (mainChar.charXu < mainChar.getPriceRepair(1))
					{
						Canvas.startOKDlg("Hết tiền");
					}
					else
					{
						ActionPerform yesAction3 = delegate
						{
							mainChar.charXu -= mainChar.getPriceRepair(1);
							gameService.repairItem(0);
							Canvas.startWaitDlg();
						};
						ActionPerform noAction3 = delegate
						{
							Canvas.currentDialog = null;
						};
						Canvas.startYesNoDlg("Phí sửa chữa là " + mainChar.getPriceRepair(1) + " " + Res.stMoney, yesAction3, noAction3);
					}
				};
				command28.action = action24;
				mVector3.addElement(command28);
				Command command29 = new Command("Quần áo");
				ActionPerform action25 = delegate
				{
					if (mainChar.charXu < mainChar.getPriceRepair(0))
					{
						Canvas.startOKDlg("Hết tiền");
					}
					else
					{
						ActionPerform yesAction2 = delegate
						{
							mainChar.charXu -= mainChar.getPriceRepair(0);
							gameService.repairItem(1);
							Canvas.startWaitDlg();
						};
						ActionPerform noAction2 = delegate
						{
							Canvas.currentDialog = null;
						};
						Canvas.startYesNoDlg("Phí sửa chữa là " + mainChar.getPriceRepair(0) + " " + Res.stMoney, yesAction2, noAction2);
					}
				};
				command29.action = action25;
				mVector3.addElement(command29);
				Command command30 = new Command("Tất cả");
				ActionPerform action26 = delegate
				{
					if (mainChar.charXu < mainChar.getPriceRepair(2))
					{
						Canvas.startOKDlg("Hết tiền");
					}
					else
					{
						ActionPerform yesAction = delegate
						{
							mainChar.charXu -= mainChar.getPriceRepair(2);
							gameService.repairItem(2);
							Canvas.startWaitDlg();
						};
						ActionPerform noAction = delegate
						{
							Canvas.currentDialog = null;
						};
						Canvas.startYesNoDlg("Phí sửa chữa là " + mainChar.getPriceRepair(2) + " " + Res.stMoney, yesAction, noAction);
					}
				};
				command30.action = action26;
				mVector3.addElement(command30);
				Canvas.menu.startAt(mVector3, 3);
			};
			command10.action = action6;
			menu.addElement(command10);
			Command command11 = new Command("Đục lỗ");
			ActionPerform action7 = delegate
			{
				gameService.requestKham(0);
				WindowInfoScr.gI().name = "Đục lỗ";
				WindowInfoScr.isKham = false;
			};
			command11.action = action7;
			menu.addElement(command11);
			Command command12 = new Command("Khảm");
			ActionPerform action8 = delegate
			{
				gameService.requestKham(0);
				WindowInfoScr.isKham = true;
				WindowInfoScr.gI().name = "Khảm";
			};
			command12.action = action8;
			menu.addElement(command12);
			Command command13 = new Command("Hợp thành");
			ActionPerform action9 = delegate
			{
				GameService.gI().epNgoc(0, null);
				Canvas.startWaitDlg();
			};
			command13.action = action9;
			menu.addElement(command13);
		}
		else if (type == 7)
		{
			Command command14 = new Command("Đi đến");
			ActionPerform action10 = delegate
			{
				XaphuTemplate xp = Res.getXaphu();
				if (xp != null)
				{
					mVector mVector2 = new mVector();
					int num2 = xp.mapID.Length;
					for (int j = 0; j < num2; j++)
					{
						int aa = j;
						int idm = xp.mapID[aa];
						Command command27 = new Command(Res.nameBigMap[xp.mapID[aa]]);
						ActionPerform action23 = delegate
						{
							if (xp.price[aa] > mainChar.charXu)
							{
								Canvas.startOKDlg("Không còn đủ tiền");
							}
							else
							{
								doUseXaPhu(idm, aa);
							}
						};
						command27.action = action23;
						command27.idMap = xp.mapID[aa];
						mVector2.addElement(command27);
					}
					Canvas.menu.startAt(mVector2, 3);
				}
			};
			command14.action = action10;
			menu.addElement(command14);
			Command command15 = new Command("Giao tiếp");
			ActionPerform action11 = delegate
			{
				addChat(focusedActor, Res.getDefaultChat(type), 500);
			};
			command15.action = action11;
			menu.addElement(command15);
		}
		else if (type == 10)
		{
			Command command16 = new Command("Hoa tiêu");
			ActionPerform action12 = delegate
			{
				if (mainChar.potions[20] <= 0)
				{
					Canvas.startOKDlg("Chưa có vé");
				}
				else
				{
					gameService.moveUpBoard();
					Canvas.startWaitDlg();
				}
			};
			command16.action = action12;
			menu.addElement(command16);
			Command command17 = new Command("Mua vé (" + pTicket + " xu)");
			ActionPerform action13 = delegate
			{
				gameService.buyTicket();
				Canvas.startOKDlg("xin chờ", isIcon: true);
			};
			command17.action = action13;
			menu.addElement(command17);
			Command command18 = new Command("Nói chuyện");
			ActionPerform action14 = delegate
			{
				addChat(focusedActor, Res.getDefaultChat(type), 500);
			};
			command18.action = action14;
			menu.addElement(command18);
		}
		else if (type == 22 || type == 31)
		{
			Command command19 = new Command("Nạp xu");
			ActionPerform action15 = delegate
			{
				doNapXu();
			};
			command19.action = action15;
			menu.addElement(command19);
			Command command20 = new Command("Nói chuyện");
			ActionPerform action16 = delegate
			{
				addChat(focusedActor, Res.getDefaultChat(type), 500);
			};
			command20.action = action16;
			menu.addElement(command20);
		}
		else if (type == 25)
		{
			Command command21 = new Command("Giao tiếp");
			ActionPerform action17 = delegate
			{
				addChat(focusedActor, Res.getDefaultChat(type), 500);
			};
			command21.action = action17;
			menu.addElement(command21);
			Command command22 = new Command("Chuyển thẻ");
			ActionPerform action18 = delegate
			{
				gameService.giveCard2NPC(focusedActor.x / 16, focusedActor.y / 16);
			};
			command22.action = action18;
			menu.addElement(command22);
		}
		else if (type == 21)
		{
			Command command23 = new Command("Học kỹ năng");
			ActionPerform action19 = delegate
			{
				showWindow(0, isSell: true, new sbyte[1] { 7 });
			};
			command23.action = action19;
			menu.addElement(command23);
			Command command24 = new Command("Nói chuyện");
			ActionPerform action20 = delegate
			{
				addChat(focusedActor, Res.getDefaultChat(type), 500);
			};
			command24.action = action20;
			menu.addElement(command24);
		}
		else if (type > 10 && type != 30)
		{
			Command command25 = new Command("Bán");
			ActionPerform action21 = delegate
			{
				gameService.requestNPCInfo(type, 0);
				Canvas.startWaitDlg();
			};
			command25.action = action21;
			menu.addElement(command25);
			Command command26 = new Command("Mua");
			ActionPerform action22 = delegate
			{
				gameService.requestNPCInfo(type, 1);
				Canvas.startWaitDlg();
			};
			command26.action = action22;
			menu.addElement(command26);
		}
		Canvas.menu.startAt(menu, 3);
	}

	public void doUseXaPhu(int mapID, int idXphu)
	{
		int indexArrMap = getIndexArrMap(mapID);
		string[] name = Res.namMap[indexArrMap];
		short[] local = Res.localXaphu[indexArrMap];
		mVector mVector2 = new mVector();
		int num = name.Length;
		for (int j = 0; j < num; j++)
		{
			int i = j;
			Command command = new Command(name[j]);
			ActionPerform action = delegate
			{
				gameService.doMove2Map((sbyte)idXphu, local[i * 3]);
				ChangScr.gI().switchToMe();
				ChangScr.gI().setMap(map, 0, 0);
				Res.removeMonsterTemplet();
				nameMap = name[i];
			};
			command.action = action;
			mVector2.addElement(command);
		}
		Canvas.menu.startAt(mVector2, 3);
		Canvas.menu.setIndex();
	}

	public void doNapXu()
	{
		if (decriptNap.size() == 0)
		{
			Canvas.startOKDlg("Chức năng này hiện đang tạm khóa");
			return;
		}
		mVector mVector2 = new mVector();
		int num = decriptNap.size();
		for (int i = 0; i < num; i++)
		{
			string syn = (string)syntaxNap.elementAt(i);
			string center = (string)centerNap.elementAt(i);
			string decription = (string)decriptNap.elementAt(i);
			if (center.Length >= 4)
			{
				Command command = new Command((string)decriptNap.elementAt(i));
				ActionPerform action = delegate
				{
					ActionPerform successAction = delegate
					{
						Canvas.startOKDlg("Đã gửi tin. Xin chờ trong chốc lát để nhận tin nhắn phản hồi.");
					};
					ActionPerform failAction = delegate
					{
						Canvas.startOKDlg("Có lỗi khi gửi tin nhắn nạp. Xin hãy thử lại");
					};
					GameMidlet.sendSMS(syn, "sms://" + center, successAction, failAction);
				};
				command.action = action;
				mVector2.addElement(command);
				continue;
			}
			Command command2 = new Command((string)decriptNap.elementAt(i));
			ActionPerform action2 = delegate
			{
				if (!syn.Equals("-1"))
				{
					ActionPerform yesAction = delegate
					{
						GameMidlet.requestLink(syn);
					};
					ActionPerform noAction = delegate
					{
						Canvas.currentDialog = null;
					};
					Canvas.startYesNoDlg("Game sẽ tự động thoát. Vui lòng đăng nhập lại sau ít phút sau khi nạp.", yesAction, noAction);
				}
				else
				{
					doNapMoney(decription);
				}
			};
			command2.action = action2;
			mVector2.addElement(command2);
		}
		Canvas.menu.startAt(mVector2, 3);
	}

	public bool checkMoveLimit(int xTo, int yTo)
	{
		if (npc_Limit.size() == 0)
		{
			return false;
		}
		int num = npc_Limit.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)npc_Limit.elementAt(i);
			if (actor != null)
			{
				Npc_Server npc_Server = (Npc_Server)actor;
				if (xTo >= npc_Server.getLimxL() && xTo <= npc_Server.getLimxR() && yTo >= npc_Server.getLimyU() && yTo <= npc_Server.getLimyD())
				{
					return true;
				}
			}
		}
		return false;
	}

	private void popupNapTien(int index, string decription, string title)
	{
		TField tfSeri = new TField(Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 120, 140, MyScreen.ITEM_HEIGHT + 2);
		tfSeri.isFocus = true;
		TField tfMaso = new TField(Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 60, 140, MyScreen.ITEM_HEIGHT + 2);
		tfMaso.setIputType(TField.INPUT_ALPHA_NUMBER_ONLY);
		Command command = new Command("Nạp");
		ActionPerform action = delegate
		{
			gameService.onSendNapSMS(index, decription, tfSeri.getText().Trim(), tfMaso.getText().Trim());
			Canvas.startOKDlg("Đã gửi thông tin nạp");
		};
		command.action = action;
		PageScr.gI().setInfo(Canvas.hw - 90, Canvas.h - MyScreen.ITEM_HEIGHT - 170, 180, 140, title, command);
		Command command2 = new Command("Đóng");
		ActionPerform action2 = delegate
		{
			Canvas.gameScr.switchToMe();
		};
		command2.action = action2;
		PageScr.gI().left = command2;
		Layer layer = new Layer();
		ActionPerform isUpdate = delegate
		{
			tfSeri.update();
			tfMaso.update();
		};
		ActionPaintCmd isPaint = delegate(MyGraphics g, int x, int y)
		{
			MFont.borderFont.drawString(g, "Seri", Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 140, 0);
			MFont.borderFont.drawString(g, "Mã thẻ", Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 80, 0);
			tfSeri.paint(g);
			g.setClip(0, 0, Canvas.w, Canvas.h);
			tfMaso.paint(g);
			g.setClip(0, 0, Canvas.w, Canvas.h);
		};
		ActionKey isKeyCode = delegate(int keycode)
		{
			if (tfSeri.isFocus)
			{
				tfSeri.keyPressed(keycode);
			}
			if (tfMaso.isFocus)
			{
				tfMaso.keyPressed(keycode);
			}
		};
		layer.isUpdate = isUpdate;
		layer.isPaint = isPaint;
		layer.isKeyCode = isKeyCode;
		PageScr.gI().layer = layer;
		PageScr.gI().switchToMe();
	}

	public void doNapMoney(string decription)
	{
		mVector mVector2 = new mVector();
		Command command = new Command("Nạp lượng");
		ActionPerform action = delegate
		{
			popupNapTien(0, decription, "NẠP LƯỢNG");
		};
		command.action = action;
		mVector2.addElement(command);
		Command command2 = new Command("Nạp xu");
		ActionPerform action2 = delegate
		{
			popupNapTien(1, decription, "NẠP XU");
		};
		command2.action = action2;
		mVector2.addElement(command2);
		Canvas.menu.startAt(mVector2, 3);
	}

	private void paintPoint(MyGraphics g, Position pos, int index)
	{
		if (pos != null)
		{
			int num = pos.x / 16;
			int num2 = pos.y / 16;
			if (num - 4 <= cmxMini)
			{
				num = cmxMini + 4;
			}
			else if (num + 6 > cmxMini + wMiniMap)
			{
				num = cmxMini + 60 - 6;
			}
			if (num2 - 4 <= cmyMini)
			{
				num2 = cmyMini + 4;
			}
			else if (num2 + 6 > cmyMini + hMiniMap)
			{
				num2 = cmyMini + 50 - 6;
			}
			g.setColor(colorPaint[index]);
			g.fillRect(num, num2, 3, 3);
			g.setColor(16777215);
			g.drawRect(num - 1, num2 - 1, 4, 4);
		}
	}

	public void paintMiniMap(MyGraphics g)
	{
		if (!canPaintIsShowMenu())
		{
			return;
		}
		int num = 0;
		if (Tilemap.w < Canvas.w / 16 && Tilemap.h < Canvas.h / 16)
		{
			return;
		}
		Canvas.resetTrans(g);
		if ((listMSGServer.size() > 0 && msgWorld.size() == 0) || (listMSGServer.size() == 0 && msgWorld.size() > 0))
		{
			g.translate(-g.getTranslateX(), 20);
			num = 20;
		}
		else if (listMSGServer.size() > 0 && msgWorld.size() > 0)
		{
			g.translate(-g.getTranslateX(), 40);
			num = 40;
		}
		if (posMiniMap.x < Canvas.w - 62)
		{
			g.translate(Canvas.w - 62, 0);
		}
		else
		{
			g.translate(posMiniMap.x, 0);
		}
		int num2 = mainChar.x / 16;
		int num3 = mainChar.y / 16;
		for (int i = 0; i < 3; i++)
		{
			g.setColor(colorMini[i]);
			g.fillRect(i, i, (posMiniMap.x >= Canvas.w - 62) ? (wMiniMap - i * 2) : (60 - i * 2), hMiniMap - i * 2);
		}
		g.setClip(3, 3, ((wMiniMap <= 60) ? wMiniMap : 60) - 5, hMiniMap - 5);
		g.translate(-cmxMini, -cmyMini);
		if (Tilemap.imgMap != null)
		{
			g.drawImage(Tilemap.imgMap, 0, 0, 0);
		}
		g.setColor(16777215);
		g.fillRect(num2, num3 - 2, 5, 5);
		g.setColor(255);
		g.fillRect(num2 + 1, num3 - 1, 3, 3);
		paintPosNPCQuest(g);
		paintPoint(g, posNpcReceiveClan, 1);
		paintPoint(g, posBoss, 2);
		g.setColor(16516117);
		int num4 = Char.party.size();
		for (int j = 0; j < num4; j++)
		{
			PartyInfo partyInfo = (PartyInfo)Char.party.elementAt(j);
			if (partyInfo != null)
			{
				Actor actor = findCharByID((short)partyInfo.id);
				if (actor != null)
				{
					g.fillRect(actor.x / 16, actor.y / 16, 2, 2);
				}
			}
		}
		g.setColor(16317005);
		int num5 = Tilemap.pointPop.size();
		for (int k = 0; k < num5; k++)
		{
			PopupName popupName = (PopupName)Tilemap.pointPop.elementAt(k);
			int num6 = 0;
			int num7 = 0;
			if (popupName != null)
			{
				if (popupName.x / 16 >= wMiniMap - 3)
				{
					num6 = -3;
				}
				if (popupName.x / 16 <= 3)
				{
					num6 = 3;
				}
				if (popupName.y / 16 <= 3)
				{
					num7 = 3;
				}
				if (popupName.y >= hMiniMap - 3)
				{
					num7 = -3;
				}
				g.fillRect(popupName.x / 16 + num6, popupName.y / 16 + num7, 3, 3);
			}
		}
		Canvas.resetTrans(g);
		MFont.smallFont.drawString(g, mainChar.x / 16 + "." + mainChar.y / 16, Canvas.w - 5, hMiniMap - 7 + num, 1);
	}

	public bool canPaintGameScr()
	{
		if (Canvas.currentScreen == this || Canvas.currentScreen == MenuSelectItem.gI() || Canvas.currentScreen == PageScr.gI() || Canvas.currentScreen == DialLuckyScr.gI())
		{
			return true;
		}
		return false;
	}

	public override void paint(MyGraphics g)
	{
		if (!readyGetGameLogic)
		{
			return;
		}
		Canvas.resetTrans(g);
		if (canPaintGameScr() && isFillScr)
		{
			g.setColor(16777215);
			g.fillRect(0, 0, Canvas.w, Canvas.h);
			g.setColor(0, 0.5f);
			g.fillRect(Canvas.hw - 50, Canvas.hh + 20, 100, 27);
			MFont.normalFont[0].drawString(g, "Time: " + Skill_Kham.t, Canvas.hw, Canvas.hh + 25, 2);
			return;
		}
		if (lockcmx || lockcmy)
		{
			g.setColor(0);
			g.fillRect(0, 0, Canvas.w, Canvas.h);
		}
		int num = 0;
		if (timerung > 0)
		{
			num = r.nextInt(2);
		}
		g.translate(-cmx + num, -cmy - num);
		g.setColor(0);
		g.fillRect(cmx - 5, cmy - 5, Canvas.w + 10, Canvas.h + 10);
		Tilemap.paintTile(g);
		if (mainChar.posTransRoad != null && posCam != null)
		{
			tg.paint(g);
		}
		if (canPaintGameScr() || canPaintIsShowMenu())
		{
			EffectManager.lowEffects.paintAll(g);
			int num2 = aeo.size();
			for (int i = 0; i < num2; i++)
			{
				((Effect)aeo.elementAt(i))?.paint(g);
			}
		}
		if (canPaintGameScr() || canPaintIsShowMenu())
		{
			int num3 = arrowsDown.size();
			for (int j = 0; j < num3; j++)
			{
				((IArrow)arrowsDown.elementAt(j))?.paint(g);
			}
		}
		int k = 0;
		int num4 = 0;
		int l = 0;
		try
		{
			if (Tilemap.trees != null)
			{
				for (int m = gssy; m < gssye + 5; m++)
				{
					if (paintCay == 1)
					{
						for (int num5 = Tilemap.trees.size(); k < num5 && (Tree)Tilemap.trees.elementAt(k) != null; k++)
						{
							Tree tree = (Tree)Tilemap.trees.elementAt(k);
							if (tree.y == m)
							{
								if (tree.x - tree.getW() / 32 <= gssxe && tree.x + tree.getW() / 32 >= gssx)
								{
									tree.paint(g);
								}
							}
							else if (tree.y > m)
							{
								break;
							}
						}
					}
					for (; l < npc_limit.size(); l++)
					{
						Actor actor = (Actor)npc_limit.elementAt(l);
						if (actor != null && actor.typeLimit == 1 && canPaintNPC_SV(actor))
						{
							actor.paint(g);
						}
					}
					while (num4 < actors.size())
					{
						Actor actor2 = (Actor)actors.elementAt(num4);
						if (actor2.catagory != 2)
						{
							if (actor2.y >> 4 > m)
							{
								break;
							}
							if (((((actor2.catagory == Actor.CAT_PLAYER && paintChar == 1) || actor2.ID == mainChar.ID || actor2.catagory != Actor.CAT_PLAYER) && actor2.y >> 4 == m && actor2.y <= gssye * 16 && actor2.y >= gssy * 16) || actor2.allwayPaint()) && !(actor2 is CongThanh))
							{
								actor2.paint(g);
							}
						}
						else if (actor2.catagory == 2 && actor2.typeLimit != 1 && canPaintNPC_SV(actor2))
						{
							actor2.paint(g);
						}
						num4++;
						if (actor2 != focusedActor || focusedActor.catagory == Actor.CAT_MY_GROUND || focusedActor.catagory == Actor.CAT_MY_TREE || focusedActor.catagory == Actor.CAT_MY_PET)
						{
							continue;
						}
						if (focusedActor.catagory == Actor.CAT_NPC)
						{
							if (posNpcRequest != null && actor2.x / 16 == posNpcRequest.x / 16 && actor2.y / 16 == posNpcRequest.y / 16)
							{
								continue;
							}
						}
						else if (false)
						{
							continue;
						}
						if (!isAutoRangeWhenAuto)
						{
							g.drawImage(Res.imgSelect, actor2.x, actor2.y - actor2.height, MyGraphics.HCENTER | MyGraphics.BOTTOM);
						}
					}
				}
				Tilemap.paintTileTop(g);
			}
		}
		catch (Exception)
		{
		}
		if (canPaintGameScr() && congThanh != null)
		{
			congThanh.paint(g);
		}
		if (canPaintGameScr())
		{
			int num6 = arrowsUp.size();
			for (int n = 0; n < num6; n++)
			{
				IArrow arrow = (IArrow)arrowsUp.elementAt(n);
				if (arrow != null && canPaintIsShowMenu())
				{
					arrow.paint(g);
				}
			}
		}
		Actor actor3 = null;
		if (canPaintGameScr())
		{
			int num7 = actors.size();
			for (int num8 = 0; num8 < num7; num8++)
			{
				actor3 = (Actor)actors.elementAt(num8);
				if (actor3 != null && canPaintIsShowMenu())
				{
					actor3.paintName(g);
				}
			}
		}
		if (canPaintGameScr())
		{
			EffectManager.hiEffects.paintAll(g);
			paintFlyText(g);
		}
		if (canPaintGameScr())
		{
			int num9 = Tilemap.pointPop.size();
			for (int num10 = 0; num10 < num9; num10++)
			{
				PopupName popupName = (PopupName)Tilemap.pointPop.elementAt(num10);
				if (popupName != null)
				{
					if (Tilemap.isOfflineMap)
					{
						popupName.name = "thoát";
					}
					else
					{
						popupName.name = "vào";
					}
					popupName.paint(g);
				}
			}
		}
		if (canPaintGameScr() && effAnimate.size() > 0 && !Tilemap.isOfflineMap && effAnimate.size() > 0)
		{
			int num11 = effAnimate.size();
			for (int num12 = 0; num12 < num11; num12++)
			{
				((AnimateEffect)effAnimate.elementAt(num12))?.paint(g);
			}
		}
		if (charcountdonw != null)
		{
			charcountdonw.paint(g, objcountDown.x - 30, objcountDown.y - 40 - objcountDown.getyHorse());
		}
		try
		{
			if (canPaintGameScr())
			{
				paintFocusActorInfo(g);
			}
			paintMainCharInfo(g);
		}
		catch (Exception)
		{
		}
		try
		{
			if (this == Canvas.currentScreen)
			{
				if (isBatMiniMap)
				{
					paintMiniMap(g);
				}
				if (hideGUI == 0)
				{
					if (mainChar.nationID > -1)
					{
						MFont.borderFont.drawString(g, nameCountry[mainChar.inCountry], 4, Canvas.h - 34 - (Main.isPC ? 12 : 0), 0);
					}
					MFont.borderFont.drawString(g, nameMap, 4, Canvas.h - 18 - (Main.isPC ? 12 : 0), 0);
				}
				if (!chatMode && hideGUI == 0 && Canvas.currentDialog == null && !Canvas.menu.showMenu)
				{
					paintButton(g);
					if (!Main.isPC)
					{
						paintQuickSlot(g);
					}
					else
					{
						paintQuickSlotPc(g);
					}
					paintIndexBuff(g);
				}
				paintServerInfo(g);
				if (Main.isPC)
				{
					paintSkillClanPc(g);
				}
				else
				{
					paintSkillClan(g);
				}
			}
		}
		catch (Exception)
		{
		}
		if (!canPaintIsShowMenu())
		{
			Canvas.resetTrans(g);
			g.setColor(3815994, 0.5f);
			g.fillRect(0, 0, Canvas.w, Canvas.h);
		}
		if (Main.isPC && (Canvas.menu.showMenu || (Canvas.currentScreen != this && Main.isPC && Canvas.currentScreen != DialLuckyScr.gI() && Canvas.currentScreen != ItemQsScreen.gI())))
		{
			Canvas.resetTrans(g);
			g.setColor(3815994, 0.5f);
			g.fillRect(0, 0, Canvas.w, Canvas.h);
		}
		base.paint(g);
		if (canPaintGameScr() && Tilemap.lv == 201 && timeChiemThanh != null)
		{
			paintChiemThanh(g);
		}
		if (this == Canvas.currentScreen)
		{
			paintChat(g);
		}
		if (listMSGServer != null && listMSGServer.size() > 0)
		{
			paintMsgServer(g);
		}
		Canvas.resetTrans(g);
		if (MessageScr.nMSG > 0 && imgInfo != null)
		{
			g.drawImage(Res.imgMSG, 3, imgInfo.getHeight(), 0);
		}
		paintTime(g);
		if (msgWorld.size() > 0 && msgWorld.size() > 0)
		{
			MsgInfo msgInfo = (MsgInfo)msgWorld.elementAt(0);
			g.setColor(0, 0.5f);
			if (listMSGServer.size() > 0)
			{
				g.translate(-g.getTranslateX(), 20);
			}
			g.fillRect(0, 0, Canvas.w, msgInfo.arr.Length * 21);
			msgInfo.paint(g);
		}
		if (Main.isDisConnect)
		{
			Canvas.resetTrans(g);
			g.setColor(0);
			g.fillRect(0, 0, Canvas.w, Canvas.h);
		}
	}

	public void paintTime(MyGraphics g)
	{
		for (int i = 0; i < VecTime.size(); i++)
		{
			((TimecountDown)VecTime.elementAt(i))?.paint(g, Canvas.w - 10, hMiniMap + i * 18 + 16);
		}
	}

	public void paintSkillClanPc(MyGraphics g)
	{
		Canvas.resetTrans(g);
		int num = 0;
		if (skillClan != null)
		{
			for (int i = 0; i < skillClan.Length; i++)
			{
				if (skillClan[i].time > 0)
				{
					GameData.paintIcon(g, (short)(skillClan[i].idIcon + 2600), Canvas.w - 19, Canvas.hh - 83 + 16 * num);
					MFont.smallFontColor[3].drawString(g, skillClan[i].lv + string.Empty, Canvas.w - 19 + 10, Canvas.hh - 85 + 16 * num - 1, 0);
					num++;
				}
			}
		}
		num = 0;
		if (skillClanPrivate == null)
		{
			return;
		}
		for (int j = 0; j < skillClanPrivate.Length; j++)
		{
			if (skillClanPrivate[j].time > 0)
			{
				GameData.paintIcon(g, (short)(skillClanPrivate[j].idIcon + 2600), Canvas.w - 47, Canvas.hh - 83 + 16 * num);
				MFont.smallFontColor[0].drawString(g, skillClanPrivate[j].lv + string.Empty, Canvas.w - 37, Canvas.hh - 85 + 16 * num - 1, 0);
				num++;
			}
		}
	}

	private void paintSkillClan(MyGraphics g)
	{
		int num = 0;
		if (skillClan != null)
		{
			int num2 = skillClan.Length;
			for (int i = 0; i < num2; i++)
			{
				if (skillClan[i] != null && skillClan[i].time > 0)
				{
					GameData.paintIcon(g, (short)(skillClan[i].idIcon + 2600), Canvas.hw - 25 + 16 * num, Canvas.h - 10);
					MFont.normalFont[4].drawString(g, skillClan[i].lv + string.Empty, Canvas.hw - 25 + 16 * num + 4, Canvas.h - 10, 2);
					num++;
				}
			}
		}
		num = 0;
		if (skillClanPrivate == null)
		{
			return;
		}
		int num3 = skillClanPrivate.Length;
		for (int j = 0; j < num3; j++)
		{
			if (skillClanPrivate[j] != null && skillClanPrivate[j].time > 0)
			{
				GameData.paintIcon(g, (short)(skillClanPrivate[j].idIcon + 2600), Canvas.hw - 25 + 16 * num, Canvas.h - 30);
				MFont.normalFont[0].drawString(g, skillClanPrivate[j].lv + string.Empty, Canvas.hw - 25 + 16 * num + 4, Canvas.h - 30, 2);
				num++;
			}
		}
	}

	public bool canPaintNPC_SV(Actor npc)
	{
		if (npc.x + npc.width / 2 < cmx || npc.x - npc.width / 2 > cmx + Canvas.w || npc.y - npc.height > cmy + Canvas.h || npc.y < cmy)
		{
			return false;
		}
		return true;
	}

	private void paintIndexBuff(MyGraphics g)
	{
		if (!Main.isPC && indexBuff != -1 && timeBuff - mSystem.getCurrentTimeMillis() / 1000 > 0)
		{
			GameData.imgSkillIcon.drawFrame(indexBuff, Canvas.w - 160, Canvas.h - MyScreen.deltaY - 3, 0, MyGraphics.BOTTOM | MyGraphics.RIGHT, g);
			MFont.normalFont[0].drawString(g, (timeBuff - mSystem.getCurrentTimeMillis()) / 1000 + string.Empty, Canvas.w - 170, Canvas.h - MyScreen.deltaY - 8, 2);
		}
	}

	public static void setDataForButton()
	{
		xCenTer = 20;
		yCenter = Canvas.h - Res.imgNewBt[0].getHeight() - 20;
		xU = 20 + Res.imgNewBt[0].getWidth() / 2 - Res.imgNewBt[4].getWidth() / 2;
		yU = Canvas.h - Res.imgNewBt[0].getHeight() - 20 - 8;
		xD = 20 + Res.imgNewBt[0].getWidth() / 2 - Res.imgNewBt[4].getWidth() / 2;
		yD = Canvas.h - Res.imgNewBt[0].getHeight() - 20 - 8 + Res.imgNewBt[0].getHeight() - Res.imgNewBt[4].getHeight() + 20;
		xL = 0;
		yL = Canvas.h - Res.imgNewBt[0].getHeight() - 20 + Res.imgNewBt[0].getHeight() / 2 - Res.imgNewBt[4].getHeight() / 2;
		xR = 20 + Res.imgNewBt[0].getWidth() - Res.imgNewBt[4].getWidth() + 18;
		yR = Canvas.h - Res.imgNewBt[0].getHeight() - 20 + Res.imgNewBt[0].getHeight() / 2 - Res.imgNewBt[4].getHeight() / 2;
		xFire = Canvas.w - Res.imgNewBt[1].getWidth();
		yFire = Canvas.h - Res.imgNewBt[1].getHeight() / 2 - 20;
		xMp = Canvas.w - Res.imgNewBt[1].getWidth();
		yMp = Canvas.h - Res.imgNewBt[1].getHeight() / 2 - 20 - Res.imgNewBt[2].getHeight() / 2 + 15;
		xHp = Canvas.w - Res.imgNewBt[1].getWidth() - Res.imgNewBt[2].getWidth() + 15;
		yHp = Canvas.h - Res.imgNewBt[1].getHeight() / 2 - 20 - Res.imgNewBt[2].getHeight() / 4 + 5;
		xThree = Canvas.w - Res.imgNewBt[1].getWidth() - Res.imgNewBt[2].getWidth() + 5;
		yThree = Canvas.h - Res.imgNewBt[1].getHeight() / 2 - 20 + Res.imgNewBt[2].getHeight() / 4;
		xOne = Canvas.w - Res.imgNewBt[1].getWidth() - 20;
		yOne = Canvas.h - Res.imgNewBt[1].getHeight() / 2 - 20 + Res.imgNewBt[2].getHeight() / 2 + 10;
		if (!Main.isPC)
		{
			xChangeTab = Canvas.w - Res.imgSwapQuickSlot.getWidth() - 5 - Res.imgSwapQuickSlot.getWidth() / 2 + 3;
			yChangeTab = Canvas.hh - 35 - Res.imgSwapQuickSlot.getHeight() / 2 - 5;
			xChangeFocus = Canvas.w - Res.imgFocusActor.getWidth() - 5 - Res.imgFocusActor.getWidth() / 2 + 4;
			yChangeFocus = Canvas.hh - 80 - Res.imgFocusActor.getHeight() / 2;
			xChangeClothes = Canvas.w - Res.imgSwapClothes.getWidth() * 2 - 30 - Res.imgSwapClothes.getWidth() / 2 + 3;
			yChangeClothes = Canvas.hh - 50 - Res.imgSwapClothes.getHeight() / 2 - 5;
		}
		else
		{
			xChangeTab = 10;
			yChangeTab = Canvas.h - 60 - Res.imgSwapQuickSlot.getHeight();
			xChangeFocus = 10;
			yChangeFocus = Canvas.h - 60 - Res.imgSwapQuickSlot.getHeight() - 5 - Res.imgFocusActor.getHeight() - 20;
			xChangeClothes = 10;
			yChangeClothes = Canvas.h - 60 - Res.imgSwapQuickSlot.getHeight() - 5 - Res.imgFocusActor.getHeight() - Res.imgSwapClothes.getHeight() - 40;
			xChatTouch = 10;
			yChatTouch = Canvas.h - 60 - Res.imgSwapQuickSlot.getHeight() - 5 - Res.imgFocusActor.getHeight() - Res.imgSwapClothes.getHeight() - Res.imgChatTouch.getHeight() - 60;
			xSelectFc = 10;
			ySelectFc = Canvas.h - 60 - Res.imgSwapQuickSlot.getHeight() - 5 - Res.imgFocusActor.getHeight() - Res.imgSwapClothes.getHeight() - Res.imgChatTouch.getHeight() - Res.imgSelectFc.getHeight() - 80;
		}
	}

	private void paintButton(MyGraphics g)
	{
		if (!Main.isPC)
		{
			g.drawImage(Res.imgNewBt[0], xCenTer, yCenter, MyGraphics.TOP | MyGraphics.LEFT);
			paintFocus(g);
			g.drawRegion(Res.imgNewBt[1], 0, 0, Res.imgNewBt[1].getWidth(), Res.imgNewBt[1].getHeight() / 2, 0, xFire, yFire, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawRegion(Res.imgNewBt[2], 0, 0, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xOne, yOne, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawRegion(Res.imgNewBt[2], 0, 0, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xThree, yThree, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawRegion(Res.imgNewBt[2], 0, 0, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xHp, yHp, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawRegion(Res.imgNewBt[2], 0, 0, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xMp, yMp, MyGraphics.TOP | MyGraphics.LEFT);
		}
		int num = 0;
		if ((listMSGServer.size() > 0 && msgWorld.size() == 0) || (listMSGServer.size() == 0 && msgWorld.size() > 0))
		{
			num = 20;
		}
		else if (listMSGServer.size() > 0 && msgWorld.size() > 0)
		{
			num = 40;
		}
		if (isBatMiniMap)
		{
			g.drawImage(Res.imgChat, Canvas.w - Res.imgChat.getWidth() * 2 - 30, Res.imgChat.getWidth() / 2 + 2 + num, MyGraphics.VCENTER | MyGraphics.HCENTER);
			g.drawImage(Res.imgMapMini, Canvas.w - Res.imgChat.getWidth() * 2 - 30, Res.imgChat.getWidth() * 2 + 2 + num, 3);
		}
		else
		{
			g.drawImage(Res.imgChat, Canvas.w - Res.imgChat.getWidth() * 2 - 20, Res.imgChat.getWidth() / 2 + 2, 3);
			g.drawImage(Res.imgMapMini, Canvas.w - Res.imgChat.getWidth() - 10, Res.imgChat.getWidth() / 2 + 2, 3);
		}
		if (!Tilemap.isOfflineMap)
		{
			g.drawImage(Res.imgSwapQuickSlot, xChangeTab, yChangeTab, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawImage(Res.imgFocusActor, xChangeFocus, yChangeFocus, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawImage(Res.imgSwapClothes, xChangeClothes, yChangeClothes, MyGraphics.TOP | MyGraphics.LEFT);
		}
		if (Main.isPC && !Tilemap.isOfflineMap)
		{
			g.drawImage(Res.imgChatTouch, xChatTouch, yChatTouch, MyGraphics.TOP | MyGraphics.LEFT);
			g.drawImage(Res.imgSelectFc, xSelectFc, ySelectFc, MyGraphics.TOP | MyGraphics.LEFT);
			MFont.normalFont[0].drawString(g, "I", xChangeTab + Res.imgSwapQuickSlot.getWidth() + 2, yChangeTab + 1, 0);
			MFont.normalFont[0].drawString(g, "F2", xChangeFocus + Res.imgFocusActor.getWidth() + 2, yChangeFocus + 1, 0);
			MFont.normalFont[0].drawString(g, "U", xChangeClothes + Res.imgFocusActor.getWidth() + 2, yChangeClothes + 1, 0);
			MFont.normalFont[0].drawString(g, "Y", xChatTouch + Res.imgChatTouch.getWidth() + 2, yChatTouch + 1, 0);
			MFont.normalFont[0].drawString(g, "O", xSelectFc + Res.imgSelectFc.getWidth() + 2, ySelectFc + 1, 0);
		}
	}

	public bool canTouchScreen(int px, int py)
	{
		if (Main.isPC)
		{
			if ((px >= 0 && px <= 50 && py >= 0 && py <= 80) || (px >= Canvas.w - 100 && px <= Canvas.w && py >= 0 && py <= Canvas.hh / 2) || (px < xChatTouch + Res.imgChatTouch.getWidth() && py >= ySelectFc))
			{
				return false;
			}
		}
		else if ((px >= 0 && px <= xR + 30 && py >= yU && py <= Canvas.h) || (px >= 0 && px <= 50 && py >= 0 && py <= 80) || (px >= xThree && px <= Canvas.w && py >= yMp && py <= Canvas.h) || (px >= xChangeClothes && px <= Canvas.w && py >= yChangeFocus && py <= yChangeClothes + Res.imgSwapClothes.getHeight()))
		{
			return false;
		}
		return true;
	}

	private void paintFocus(MyGraphics g)
	{
		if (!Main.isPC)
		{
			if (isPaintFcBt[0])
			{
				g.drawImage(Res.imgNewBt[4], xU, yU, MyGraphics.TOP | MyGraphics.LEFT);
			}
			if (isPaintFcBt[1])
			{
				g.drawRegion(Res.imgNewBt[4], 0, 0, Res.imgNewBt[4].getWidth(), Res.imgNewBt[4].getHeight(), 6, xL, yL, MyGraphics.TOP | MyGraphics.LEFT);
			}
			if (isPaintFcBt[2])
			{
				g.drawRegion(Res.imgNewBt[4], 0, 0, Res.imgNewBt[4].getWidth(), Res.imgNewBt[4].getHeight(), 5, xR, yR, MyGraphics.TOP | MyGraphics.LEFT);
			}
			if (isPaintFcBt[3])
			{
				g.drawRegion(Res.imgNewBt[4], 0, 0, Res.imgNewBt[4].getWidth(), Res.imgNewBt[4].getHeight(), 3, xD, yD, MyGraphics.TOP | MyGraphics.LEFT);
			}
		}
		if (isPaintFcBt[4])
		{
			g.drawRegion(Res.imgNewBt[2], 0, Res.imgNewBt[2].getHeight() / 2, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xOne, yOne, MyGraphics.TOP | MyGraphics.LEFT);
		}
		if (isPaintFcBt[5])
		{
			g.drawRegion(Res.imgNewBt[2], 0, Res.imgNewBt[2].getHeight() / 2, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xThree, yThree, MyGraphics.TOP | MyGraphics.LEFT);
		}
		if (isPaintFcBt[6])
		{
			g.drawRegion(Res.imgNewBt[1], 0, Res.imgNewBt[1].getHeight() / 2, Res.imgNewBt[1].getWidth(), Res.imgNewBt[1].getHeight() / 2, 0, xFire, yFire + 10, MyGraphics.TOP | MyGraphics.LEFT);
		}
		if (isPaintFcBt[7] || isPaintFcBtMHP[0])
		{
			g.drawRegion(Res.imgNewBt[2], 0, Res.imgNewBt[2].getHeight() / 2, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xHp, yHp, MyGraphics.TOP | MyGraphics.LEFT);
		}
		if (isPaintFcBt[8] || isPaintFcBtMHP[1])
		{
			g.drawRegion(Res.imgNewBt[2], 0, Res.imgNewBt[2].getHeight() / 2, Res.imgNewBt[2].getWidth(), Res.imgNewBt[2].getHeight() / 2, 0, xMp, yMp, MyGraphics.TOP | MyGraphics.LEFT);
		}
	}

	private void paintMsgServer(MyGraphics g)
	{
		Canvas.resetTrans(g);
		g.setColor(0, 0.5f);
		int w = Canvas.w15;
		g.fillRect(0, 0, Canvas.w, 21);
		g.drawImage(Res.imgCmdBar, 0, Canvas.h + 3, MyGraphics.LEFT | MyGraphics.BOTTOM);
		string st = (string)listMSGServer.elementAt(0);
		MFont.borderFont.drawString(g, st, xMsgServer, 1, 0);
		g.setClip(0, 0, Canvas.h, Canvas.w);
	}

	private void paintChiemThanh(MyGraphics g)
	{
		int num = 38;
		int num2 = timeChiemThanh.Length;
		g.setColor(0, 0.5f);
		g.fillRect(Canvas.hw - 80, num - 5, 160, 70);
		for (int i = 0; i < num2; i++)
		{
			if (timeChiemThanh[i] - (mSystem.getCurrentTimeMillis() / 1000 - curTimeCT[i]) > 0)
			{
				MFont.arialFontW.drawString(g, i + 1 + ": " + nameChiemThanh[i] + " (" + (timeChiemThanh[i] - (mSystem.getCurrentTimeMillis() / 1000 - curTimeCT[i])) + ")", Canvas.hw + 2, num + 1, 3);
				num += 20;
			}
			else if (!nameClan[i].Equals(string.Empty))
			{
				MFont.arialFont.drawString(g, i + 1 + ": " + nameClan[i], Canvas.hw, num, 3);
				num += 20;
			}
		}
	}

	public void paintServerInfo(MyGraphics g)
	{
		int num = serverInfo.size();
		if (num > 0 && tk == null)
		{
			tk = new Ticker((string)serverInfo.elementAt(0), Canvas.w - 50, Canvas.h / 4 + 15 - MFont.borderFont.getHeight() / 2);
			serverInfo.removeElementAt(0);
		}
		if (tk != null)
		{
			tk.paint(g);
		}
	}

	public override bool keyPress(int keyCode)
	{
		if (chatMode)
		{
			tfChat.keyPressed(keyCode);
			if (keyCode == KeyConst.SOFT_RIGHT)
			{
				tfChat.clear();
			}
			if (keyCode == KeyConst.SOFT_LEFT)
			{
				isCloseChat = true;
				Canvas.clearKeyHold();
				Canvas.clearKeyPressed();
				chatMode = false;
			}
			if (keyCode == KeyConst.FIRE)
			{
				string text = tfChat.getText();
				tfChat.setText(string.Empty);
				doChatFromMe(text);
			}
			return true;
		}
		return false;
	}

	public void doChatFromMe(string text)
	{
		mainChar.chat = null;
		addChat(mainChar, text, 200);
		MessageScr.gI().addTab(mainChar.name + ": " + text, null, 0);
		GameService.gI().chat(text);
	}

	private void paintChat(MyGraphics g)
	{
		if ((hideGUI == 2 && !chatMode) || Canvas.menu.showMenu)
		{
			return;
		}
		if (hideGUI == 0)
		{
			g.translate(-g.getTranslateX(), -g.getTranslateY());
			if (Canvas.currentDialog != null || this != Canvas.currentScreen)
			{
				return;
			}
			if ((focusedActor != null && focusedActor.catagory != 2) || focusedActor == null)
			{
				int num = MFont.borderFont.getWidth("Ðóng") + 10;
				g.setClip(num, Canvas.h - 16, Canvas.w - num - 13, 20);
				if (yMsgChat < toYchat)
				{
					yMsgChat++;
				}
				if (listMSGServer != null && listMSGServer.size() > 0 && Canvas.gameScr.mainChar.receiveQuest && isPaintQuest)
				{
					g.setColor(0, 0.5f);
					g.setClip(0, 0, Canvas.w, Canvas.h);
					g.fillRect(Canvas.w15 - 10, Canvas.h / 4 + 40 - MFont.normalFont[0].getHeight() / 2 - 1, Canvas.w - (Canvas.w15 * 2 - 20), 21);
					g.setClip(Canvas.w15, 0, Canvas.w - Canvas.w15 * 2, Canvas.h);
					string text = string.Empty;
					int num2 = chatHistory.size();
					for (int i = 0; i < num2; i++)
					{
						ChatInfo chatInfo = (ChatInfo)chatHistory.elementAt(i);
						if (!chatInfo.name.Equals(string.Empty))
						{
							text = text + chatInfo.name + ": ";
						}
						text += chatInfo.content;
					}
					MFont.normalFont[0].drawString(g, text, xMsgServer, Canvas.h / 4 + 41 - MFont.normalFont[0].getHeight() / 2, 0);
					g.setClip(0, 0, Canvas.w, Canvas.h);
				}
			}
		}
		if (chatMode)
		{
			g.setClip(0, 0, Canvas.w, Canvas.h);
			tfChat.paint(g);
			g.setClip(0, 0, Canvas.w, Canvas.h);
			MFont.borderFont.drawString(g, "Ðóng", 5, Canvas.h - MyScreen.deltaY, 0);
			MFont.borderFont.drawString(g, "Xóa", Canvas.w - 5, Canvas.h - MyScreen.deltaY, 1);
		}
	}

	private void paintMainCharInfo(MyGraphics g)
	{
		if (hideGUI == 2)
		{
			return;
		}
		Canvas.resetTrans(g);
		int num = 0;
		if ((listMSGServer.size() > 0 && msgWorld.size() == 0) || (listMSGServer.size() == 0 && msgWorld.size() > 0))
		{
			g.translate(-g.getTranslateX(), 15);
			num = 20;
		}
		else if (listMSGServer.size() > 0 && msgWorld.size() > 0)
		{
			g.translate(-g.getTranslateX(), 30);
			num = 40;
		}
		g.drawImage(imgInfo, 0, -1, MyGraphics.TOP | MyGraphics.LEFT);
		Res.getCharPartInfo(2, mainChar.currentHead).paintStatic(g, 28, 33, 0, mainChar.frame);
		MFont.normalFontColor.drawString(g, "Lv " + mainChar.level + "+" + mainChar.getPercent(), 55, 5, MFont.LEFT);
		if (mainChar.killer > 0)
		{
			MFont.smallFont.drawString(g, mainChar.killer + string.Empty, 48, imgInfo.getHeight() - 11, MFont.LEFT);
		}
		if (mainChar.delay >= 0)
		{
			long[] time = mainChar.getTime();
			MFont.normalFont[0].drawString(g, time[0] + " : " + time[1], 5, imgInfo.getHeight() + 10, MFont.LEFT);
		}
		string goldTime = mainChar.getGoldTime();
		if (!goldTime.Equals(string.Empty))
		{
			MFont.normalFont[0].drawString(g, goldTime, 5, imgInfo.getHeight() + 20, MFont.LEFT);
			MFont.smallFontColor[0].drawString(g, Char.goldTime, 5, imgInfo.getHeight() + 36, MFont.LEFT);
		}
		int num2 = mainChar.hp * HPBARW / mainChar.maxhp;
		int num3 = mainChar.mp * HPBARW / mainChar.maxmp;
		g.setColor(0);
		g.fillRect(58 + num2, 23, HPBARW - num2 - 1, 5);
		g.setColor(0);
		g.fillRect(53 + num3, 32, HPBARW - num3 - 1, 5);
		if (Canvas.gameTick % 10 > 3)
		{
			if (mainChar.basePointLeft > 0)
			{
				g.drawImage(imgCong[0], Canvas.w - 2, imgInfo.getHeight() + 15, MyGraphics.RIGHT | MyGraphics.TOP);
			}
			if (mainChar.skillPointLeft > 0)
			{
				g.drawImage(imgCong[1], Canvas.w - 2, imgInfo.getHeight() + 26, MyGraphics.RIGHT | MyGraphics.TOP);
			}
		}
	}

	private void paintQuickSlotPc(MyGraphics g)
	{
		if (hideGUI == 2 || Canvas.currentDialog != null || chatMode)
		{
			return;
		}
		if (focusedActor != null && focusedActor.catagory == 2)
		{
			MFont.borderFont.drawString(g, "Giao tiếp", Canvas.hw, Canvas.h - MyScreen.deltaY, MFont.CENTER);
			return;
		}
		Canvas.resetTrans(g);
		int num = 15;
		int width = Res.imgPanel.getWidth();
		int height = Res.imgPanel.getHeight();
		g.setColor(colorSlot[mainChar.clazz]);
		g.fillRect(Canvas.hw - width / 2 + 3, Canvas.h - 12 - height + xSlot + num, width - 3, height - 5);
		for (int i = 0; i < 5; i++)
		{
			if (MainChar.quickSlot[indexTabSlot][i] != null)
			{
				MainChar.quickSlot[indexTabSlot][i].paint(g, Canvas.hw - width / 2 + i * Res.wKhung + Res.wKhung / 2 - 7, Canvas.h - 16 - 6 + Res.wKhung / 2 - height + xSlot - ((i == 2) ? 1 : 0) + num);
			}
			string[] array = new string[5] { "G", "H", "J", "K", "L" };
			MFont.borderFont.drawString(g, array[i], Canvas.hw - width / 2 + i * Res.wKhung + Res.wKhung / 2 + Res.wKhung / 2 - 14, Canvas.h - 27 - height + xSlot - ((i == 2) ? 2 : 0) + num - 3, 2);
		}
		if (Main.isPC && indexBuff != -1 && timeBuff - mSystem.getCurrentTimeMillis() / 1000 > 0)
		{
			GameData.imgSkillIcon.drawFrame(indexBuff, Canvas.hw + width / 2 + 23, Canvas.h - 2, 0, MyGraphics.BOTTOM | MyGraphics.LEFT, g);
			MFont.normalFont[0].drawString(g, (timeBuff - mSystem.getCurrentTimeMillis()) / 1000 + string.Empty, Canvas.hw + width / 2 + 43, Canvas.h - MFont.normalFont[0].getHeight() - 2, 0);
		}
		g.drawImage(Res.imgPanel, Canvas.hw - width / 2, Canvas.h - 16 - height + xSlot + num, 0);
		if (Canvas.currentScreen == this && !chatMode)
		{
			paintSoftIcon(g);
		}
		g.setColor(9043835);
		g.fillRect(Canvas.hw - 50, Canvas.h - MyScreen.deltaY + num, mainChar.lvpercent / 10, 1);
		g.setColor(1422592);
		g.fillRect(Canvas.hw - 50, Canvas.h - MyScreen.deltaY + num, mainChar.lvpercent / 10, 1);
	}

	private void paintQuickSlot(MyGraphics g)
	{
		if (hideGUI == 2 || Canvas.currentDialog != null || chatMode)
		{
			return;
		}
		Canvas.resetTrans(g);
		int width = Res.imgPanel.getWidth();
		int height = Res.imgPanel.getHeight();
		int num = Res.imgNewBt[2].getWidth() / 2;
		int num2 = Res.imgNewBt[2].getHeight() / 4;
		for (int i = 0; i < 5; i++)
		{
			if (MainChar.quickSlot[indexTabSlot][i] != null)
			{
				switch (i)
				{
				case 0:
					MainChar.quickSlot[indexTabSlot][i].paint(g, xOne + num, yOne + num2);
					break;
				case 1:
					MainChar.quickSlot[indexTabSlot][i].paint(g, xThree + num, yThree + num2);
					break;
				case 2:
					MainChar.quickSlot[indexTabSlot][i].paint(g, xFire + Res.imgNewBt[1].getWidth() / 2 + 1, yFire + Res.imgNewBt[1].getHeight() / 4 + 1);
					break;
				case 3:
					MainChar.quickSlot[indexTabSlot][i].paint(g, xHp + num, yHp + num2);
					break;
				case 4:
					MainChar.quickSlot[indexTabSlot][i].paint(g, xMp + num, yMp + num2);
					break;
				}
			}
		}
	}

	private void paintSoftIcon(MyGraphics g)
	{
		g.drawImage(Res.imgSoft[0], 2, Canvas.h - 13, 0);
		g.drawImage(Res.imgSoft[1], Canvas.w - 15, Canvas.h - 13, 0);
	}

	private void paintFocusActorInfo(MyGraphics g)
	{
		if (hideGUI == 2)
		{
			return;
		}
		Canvas.resetTrans(g);
		if (isAutoRangeWhenAuto)
		{
			return;
		}
		int num = 0;
		if ((listMSGServer.size() > 0 && msgWorld.size() == 0) || (listMSGServer.size() == 0 && msgWorld.size() > 0))
		{
			num = 20;
		}
		else if (listMSGServer.size() > 0 && msgWorld.size() > 0)
		{
			num = 40;
		}
		if (focusedActor == null)
		{
			return;
		}
		if (focusedActor.catagory != Actor.CAT_MY_GROUND && focusedActor.catagory != Actor.CAT_MY_TREE)
		{
			MFont.normalFontColor.drawString(g, focusedActor.getDisplayName(), Canvas.hw + 60 - 30, num, MFont.RIGHT);
			focusedActor.paintCorner(g, Canvas.hw + 60 - 15, 20 + num);
		}
		if (focusedActor.catagory != 0 && focusedActor.catagory != 1)
		{
			return;
		}
		LiveActor liveActor = (LiveActor)focusedActor;
		if (liveActor != null && liveActor.maxhp != 0 && liveActor.idBoss == -1)
		{
			Canvas.resetTrans(g);
			g.drawImage(imgHpMonster, Canvas.hw + 60 - 80, 14 + num, 20);
			long num2 = focusedActor.hp;
			int num3 = (int)(num2 * HPBARW_MONSTER / focusedActor.maxhp);
			if (liveActor.hp <= 0)
			{
				num3 = 0;
			}
			g.setColor(2368805);
			g.fillRect(Canvas.hw + 60 - 79, 15 + num, HPBARW_MONSTER - num3, 3);
			MFont.smallFont.drawString(g, ((liveActor.hp <= 0) ? 1 : liveActor.hp) + "/" + liveActor.maxhp, Canvas.hw + 60 - 10 - (HPBARW_MONSTER >> 1), 22 + num, MFont.RIGHT);
			MFont.smallFontColor[0].drawString(g, "lv" + liveActor.level, Canvas.hw + 50, 22 + num, MFont.LEFT);
		}
	}

	public void startSkill_Noel(int x, int y, int yBg, mVector list)
	{
		for (int i = 0; i < list.size(); i++)
		{
			LiveActor liveActor = (LiveActor)list.elementAt(i);
			Skill_Noel ef = new Skill_Noel(x, y, liveActor.x, liveActor.y, liveActor);
			EffectManager.addLowEffect(ef);
		}
	}

	public void startSkill_BossHalloween(int x, int y, int yBg, mVector list)
	{
		for (int i = 0; i < list.size(); i++)
		{
			LiveActor target = (LiveActor)list.elementAt(i);
			Skill_Boss_Halloween ef = new Skill_Boss_Halloween(x, y, target);
			EffectManager.addLowEffect(ef);
		}
	}

	public void startSkill_Cau_Lua(int xTo, int yTo, int yBg, mVector list)
	{
		Skill_Da_Roi skill_Da_Roi = new Skill_Da_Roi(xTo, yTo, xTo, yBg, 0);
		skill_Da_Roi.type = 1;
		skill_Da_Roi.list = list;
		EffectManager.hiEffects.addElement(skill_Da_Roi);
	}

	public void startWeapsMango(LiveActor acFr, LiveActor acTo, int vangle)
	{
		if (acFr != null && acTo != null)
		{
			WeaponsMango o = new WeaponsMango(acFr, acTo, vangle);
			arrowsUp.addElement(o);
		}
	}

	public void startWeapsAngleBoss(int angle, int power, LiveActor acFr, LiveActor acTo, int type, bool isUpDown, int addw, int addh, int xbg, int ybg, bool lastActo)
	{
		if (isUpDown)
		{
			if (acFr != null && acTo != null)
			{
				WeaponsAngleBoss o = new WeaponsAngleBoss(angle, power, acFr, acTo, type, addw, addh, xbg, ybg, lastActo);
				arrowsUp.addElement(o);
			}
		}
		else
		{
			WeaponsAngleBoss o2 = new WeaponsAngleBoss(angle, power, acFr, acTo, type, addw, addh, xbg, ybg, lastActo);
			arrowsDown.addElement(o2);
		}
	}

	public void SkillofBoss_Snake(LiveActor acFr, LiveActor acTo, int w, int h)
	{
		for (int i = 0; i < 12; i++)
		{
			startWeapsAngleBoss(i * 30, 10, acFr, acTo, 0, isUpDown: true, w, h, 0, 0, i == 11);
		}
		timerung = 20;
	}

	public void startWeaponsLazer(LiveActor acFrom, LiveActor acTo, int xadd, int yadd, int dir, int power, int idColor)
	{
		if (acFrom != null && acTo != null)
		{
			WeaponsLazer o = new WeaponsLazer(acFrom, acTo, xadd, yadd, power, idColor);
			if (dir == 1)
			{
				arrowsDown.addElement(o);
			}
			else
			{
				arrowsUp.addElement(o);
			}
		}
	}

	public void startNewMagicBeam(int type, LiveActor from, LiveActor to, int x, int y, int power, sbyte effect)
	{
		IArrow arrow = new MagicBeam();
		arrow.set(type, x, y, power, effect, from, to);
		arrowsUp.addElement(arrow);
	}

	public void startNewMagicBeam(int type, LiveActor from, LiveActor to, int x, int y, int power, sbyte effect, int angle)
	{
		IArrow arrow = new MagicBeam();
		arrow.set(type, x, y, power, effect, from, to);
		arrow.setAngle(angle);
		arrowsUp.addElement(arrow);
	}

	public void startNewArrow(int type, LiveActor from, LiveActor to, int x, int y, int power, sbyte effect, int imgIndex)
	{
		Arrow arrow = new Arrow(imgIndex);
		arrow.set(type, x, y, power, effect, from, to);
		arrowsUp.addElement(arrow);
	}

	public void creatWeaponFire(LiveActor live_From, LiveActor live_To, int type)
	{
		WeaponsFire o = new WeaponsFire(live_From, live_To, type);
		if (live_From.dir != 1)
		{
			arrowsUp.addElement(o);
		}
		else
		{
			arrowsDown.addElement(o);
		}
	}

	public void onActorMove(sbyte actorCatagory, short type, short actorID, short x2, short y2, sbyte pk, int charid, sbyte isnewmonster, sbyte isThanthu, bool canfocus)
	{
		if (!readyGetGameLogic)
		{
			return;
		}
		isActorMove = true;
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor == null || actorCatagory != actor.catagory || actor.ID != actorID)
			{
				continue;
			}
			actor.setPosTo(x2, y2);
			actor.canfocus = canfocus;
			if (actor.catagory == 0)
			{
				actor.pk = pk;
				if (actor.getHp() <= 0 || actor.getRealHp() <= 0)
				{
					actor.setState(3);
				}
			}
			isActorMove = false;
			return;
		}
		isActorMove = false;
		Actor actor2 = CreateActor(actorCatagory, type, actorID, x2, y2, isnewmonster, isThanthu);
		actor2.canfocus = canfocus;
		if (!Util.inDataRange(mainChar, actor2))
		{
			return;
		}
		actors.addElement(actor2);
		if (actors.size() >= 200)
		{
			return;
		}
		switch (actorCatagory)
		{
		case 0:
			if (isThanthu == -1)
			{
				((Char)actor2).stand = mSystem.currentTimeMillis();
				((Char)actor2).pk = pk;
			}
			gameService.requestCharInfo(actorID);
			break;
		case 1:
			((Monster)actor2).idChar = charid;
			gameService.requestMonsterInfo(actorID);
			break;
		}
	}

	public void onCharInfo(Char cha)
	{
		if (cha == null)
		{
			return;
		}
		if (cha.idBoss != -1)
		{
			cha.dir = 0;
		}
		if (idChiemThanh != null)
		{
			int num = idChiemThanh.Length;
			for (int i = 0; i < num; i++)
			{
				if (idChiemThanh[i] == cha.ID)
				{
					if (cha != null)
					{
						cha.EffFace = null;
					}
					if (cha != null && timeChiemThanh[i] > 0)
					{
						cha.EffFace = new WayPoint(cha.x, cha.y - 5, 1, 1, isWay: false);
					}
				}
			}
		}
		if (cha.defend > 0 || cha.defend_magic > 0)
		{
			int num2 = 0;
			cha.effPhap = new Effect(type: (cha.defend <= cha.defend_magic) ? 36 : 21, x: cha.x, y: cha.y);
		}
	}

	public void onPlayerAttackPlayer(short attacker, short attacked, sbyte skillID, int hpLost, int hpLeft, sbyte effect, sbyte x2, sbyte buffAttack, sbyte level)
	{
		if (!readyGetGameLogic)
		{
			return;
		}
		if (attacker == mainChar.ID)
		{
			Char @char = (Char)findCharByID(attacked);
			if (@char == null)
			{
				return;
			}
			if (mainChar.attkPower == 0)
			{
				mainChar.attkPower = hpLost;
			}
			if (@char != null)
			{
				@char.setRealHP(hpLeft);
				if (@char.hp <= 0 || @char.realHP <= 0)
				{
					@char.state = 3;
				}
				AttackResult.startEff(effect, @char.x, @char.y - 25);
				if (buffAttack == 0)
				{
					AttackResult.startEff(effect, @char.x, @char.y + 35);
				}
			}
			if (hpLost > 0)
			{
				for (int i = 0; i < x2; i++)
				{
					Canvas.gameScr.startFlyText("-" + hpLost / x2, 0, @char.x + ((i % 2 != 0) ? (-20) : 0), @char.y - ((i % 2 != 0) ? 30 : 20), 1, -2);
				}
			}
			return;
		}
		if (attacked == mainChar.ID)
		{
			Char char2 = (Char)findCharByID(attacker);
			if (char2 != null)
			{
				char2.dir = Util.findDirection(char2, mainChar);
				char2.startAttack(mainChar, new AttackResult(hpLost, effect), skillID, Char.skillLevelLearnt[skillID]);
				if (SkillManager.isSkillAeo(mainChar.clazz, skillID / 10))
				{
					mVector mVector2 = new mVector();
					mVector2.addElement(mainChar);
					char2.currentSkillAnimate.setActorter(mVector2);
				}
				if (buffAttack == 0)
				{
					Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[3], 0, char2.x, char2.y - 35, 1, -2);
				}
			}
			mainChar.downDuarable();
			mainChar.setRealHP(hpLeft);
			int num = actors.size();
			for (int j = 0; j < num; j++)
			{
				Actor actor = (Actor)actors.elementAt(j);
				if (actor.ID == attacker)
				{
					break;
				}
			}
			return;
		}
		Char char3 = (Char)findCharByID(attacked);
		if (char3 != null)
		{
			char3.setRealHP(hpLeft);
			if (hpLeft == 0)
			{
				char3.state = 3;
			}
			if (buffAttack == 0)
			{
				Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[3], 0, char3.x, char3.y - 35, 1, -2);
			}
		}
		Char char4 = (Char)findCharByID(attacker);
		if (char4 != null)
		{
			char4.dir = Util.findDirection(char4, char3);
			char4.startAttack(char3, new AttackResult(hpLost, effect), skillID, level);
		}
	}

	public void onAttackMultiTarget(Message msg)
	{
		short num = msg.reader().readShort();
		sbyte skillID = msg.reader().readByte();
		int num2 = msg.reader().readInt();
		sbyte b = msg.reader().readByte();
		sbyte level = msg.reader().readByte();
		sbyte b2 = msg.reader().readByte();
		Char @char = (Char)findCharByID(num);
		int num3 = msg.reader().readByte();
		mVector mVector2 = new mVector();
		for (int i = 0; i < num3; i++)
		{
			Monster monster = findMonsterByID(msg.reader().readShort());
			int num4 = msg.reader().readInt();
			if (monster == null)
			{
				continue;
			}
			mVector2.addElement(monster);
			int num5 = monster.hp - num4;
			monster.setRealHP(num4);
			if (num4 <= 0)
			{
				int num6 = 0;
				int num7 = 0;
				if (@char != null)
				{
					num6 = (monster.x - @char.x) * 2;
					num7 = (monster.y - @char.y) * 2;
					while (num6 > 10 || num7 > 10 || num6 < -10 || num7 < -10)
					{
						num6 >>= 1;
						num7 >>= 1;
					}
				}
				monster.startDeadFly(num6, num7);
			}
			AttackResult.startEff(b, monster.x, monster.y - 25);
			if (num2 > 0)
			{
				Canvas.gameScr.startFlyText("-" + num2, 0, monster.x, monster.y - 15, 1, -2);
			}
			if (b2 == 0)
			{
				Canvas.gameScr.startFlyText(AttackResult.EFF_NAME[3], 0, monster.x, monster.y - 35, 1, -2);
			}
		}
		if (mainChar.ID == num)
		{
			if (mainChar.attkPower == 0)
			{
				mainChar.attkPower = num2;
			}
			if (num2 > 0)
			{
				Canvas.gameScr.startFlyText("-" + num2, 0, ((Monster)mVector2.elementAt(0)).x, ((Monster)mVector2.elementAt(0)).y - 15, 1, -2);
			}
		}
		else if (@char != null && @char.currentSkillAnimate != null)
		{
			@char.startAttack((Monster)mVector2.elementAt(0), new AttackResult(num2, b), skillID, level);
			@char.currentSkillAnimate.setMonster(mVector2);
		}
	}

	public void onPlayerAttackMonster(short attacker, short attacked, sbyte skillID, int hpLost, int hpLeft, sbyte effect, sbyte x2, sbyte buffAttack, sbyte level)
	{
		if (!readyGetGameLogic)
		{
			return;
		}
		LiveActor liveActor = findMonsterByID(attacked);
		int num = 0;
		if (liveActor != null)
		{
			num = liveActor.hp - hpLeft;
			liveActor.setRealHP(hpLeft);
		}
		if (mainChar.ID == attacker)
		{
			if (mainChar.attkPower == 0)
			{
				mainChar.attkPower = hpLost;
			}
			AttackResult.startEff(effect, liveActor.x, liveActor.y - 25);
			if (buffAttack == 0)
			{
				AttackResult.startEff(3, liveActor.x, liveActor.y + 35);
			}
			if (hpLost > 0)
			{
				for (int i = 0; i < x2; i++)
				{
					Canvas.gameScr.startFlyText("-" + hpLost, 0, liveActor.x + ((i % 2 != 0) ? (-20) : 0), liveActor.y - ((i % 2 != 0) ? 30 : 20), 1, -2);
				}
			}
			return;
		}
		Char @char = (Char)findCharByID(attacker);
		if (@char != null && liveActor != null)
		{
			@char.dir = Util.findDirection(@char, liveActor);
			@char.startAttack(liveActor, new AttackResult(hpLost, effect), skillID, level);
			if (buffAttack == 0)
			{
				AttackResult.startEff(3, liveActor.x, liveActor.y + 35);
			}
		}
	}

	public void onDropList(ItemDropInfo[] info)
	{
		try
		{
			if (info == null)
			{
				return;
			}
			int num = info.Length;
			for (int i = 0; i < num; i++)
			{
				Dropable dropable = (Dropable)CreateActor(info[i].itemCatagory, info[i].itemTemplateID, info[i].itemID, info[i].x, info[i].y, 0, -1);
				if (dropable != null)
				{
					dropable.startDropFrom(info[i].x, info[i].y, dropable.x, dropable.y);
					actors.addElement(dropable);
				}
			}
		}
		catch (Exception)
		{
			Debug.Log("LOI TRONG MONSTER DIE 111");
		}
	}

	public void startDeadFly(Monster m, int attacker)
	{
		Char @char = (Char)findCharByID((short)attacker);
		if (m == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		if (@char != null)
		{
			num = (m.x - @char.x) * 2;
			num2 = (m.y - @char.y) * 2;
			while (num > 10 || num2 > 10 || num < -10 || num2 < -10)
			{
				num >>= 1;
				num2 >>= 1;
			}
		}
		m.startDeadFly(num, num2);
	}

	public void onMonsterDie(MonsterDieInfo mdi)
	{
		if (!readyGetGameLogic || mdi == null)
		{
			return;
		}
		Monster monster = findMonsterByID(mdi.attacked);
		if (monster == null)
		{
			return;
		}
		startDeadFly(monster, mdi.attacker);
		if (focusedActor == monster)
		{
			focusedActor = null;
		}
		if (mdi.itemDrop != null)
		{
			int num = mdi.itemDrop.Length;
			for (int i = 0; i < num; i++)
			{
				Dropable dropable = (Dropable)CreateActor(mdi.itemDrop[i].itemCatagory, mdi.itemDrop[i].itemTemplateID, mdi.itemDrop[i].itemID, mdi.itemDrop[i].x, mdi.itemDrop[i].y, 0, -1);
				if (dropable != null)
				{
					dropable.startDropFrom(monster.x, monster.y, dropable.x, dropable.y);
					actors.addElement(dropable);
				}
			}
		}
		if (mainChar.ID == mdi.attacker)
		{
			AttackResult.startEff(mdi.effect, monster.x, monster.y - 25);
			if (mdi.hpLost <= 0)
			{
				return;
			}
			if (mainQuest != null && mainQuest.isWorking())
			{
				if (mainQuest.isKillMons())
				{
					mainQuest.killMonster(monster.monster_type, monster.getDisplayName());
				}
				else if (mainQuest.isKillMonsByLv())
				{
					mainQuest.killMonsterByLv(abs(mainChar.level - monster.level));
				}
			}
			if (subQuest != null && subQuest.isWorking())
			{
				if (subQuest.isKillMons())
				{
					subQuest.killMonster(monster.monster_type, monster.getDisplayName());
				}
				else if (subQuest.isKillMonsByLv())
				{
					subQuest.killMonsterByLv(abs(mainChar.level - monster.level));
				}
			}
			if (clanQuest != null && clanQuest.isWorking())
			{
				if (clanQuest.isKillMons())
				{
					clanQuest.killMonster(monster.monster_type, monster.getDisplayName());
				}
				else if (clanQuest.isKillMonsByLv())
				{
					clanQuest.killMonsterByLv(abs(mainChar.level - monster.level));
				}
			}
			if (mainChar.attkPower == 0)
			{
				mainChar.attkPower = mdi.hpLost;
			}
			if (mainChar.kilAllMonsterQuest(monster.monster_type))
			{
				addChat(new ChatInfo(string.Empty, "Giết " + mainChar.infoQuest + " " + monster.getDisplayName(), 0));
				if (WindowInfoScr.idMonsterClanQuest != -1)
				{
					if (WindowInfoScr.numberQuestGet + 1 >= WindowInfoScr.numberQuestAll)
					{
						WindowInfoScr.idMonsterClanQuest = -1;
						addChat(new ChatInfo(string.Empty, "Hoàn thành nhiệm vụ", 0));
					}
					else
					{
						addChat(new ChatInfo(string.Empty, "Giết được " + ++WindowInfoScr.numberQuestGet + "/" + WindowInfoScr.numberQuestAll, 0));
					}
				}
			}
			if (mdi.hpLost > 0)
			{
				for (int j = 0; j < mdi.x2; j++)
				{
					Canvas.gameScr.startFlyText("-" + mdi.hpLost, 0, monster.x + ((j % 2 != 0) ? (-20) : 0), monster.y - ((j % 2 != 0) ? 30 : 20), 1, -2);
				}
			}
			return;
		}
		mdi.hpLost = (short)(mdi.hpLost / mdi.x2);
		Char @char = (Char)findCharByID(mdi.attacker);
		if (@char != null && monster != null)
		{
			@char.dir = Util.findDirection(@char, monster);
			if (!SkillManager.isSkillAeo(@char.clazz, mdi.skillID / 10))
			{
				@char.startAttack(monster, new AttackResult(mdi.hpLost, mdi.effect), mdi.skillID, mdi.level);
			}
		}
	}

	public void startExplosionAt(short x, short y)
	{
		actors.addElement(new Explosion(x, y));
	}

	public Actor findCharByID(short id)
	{
		isFindChar = true;
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == 0 && actor.ID == id)
			{
				isFindChar = false;
				return actor;
			}
		}
		isFindChar = false;
		return null;
	}

	private Monster findMonsterByID(short id)
	{
		isFindMonster = true;
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == 1 && actor.ID == id)
			{
				isFindMonster = false;
				return (Monster)actor;
			}
		}
		isFindMonster = false;
		return null;
	}

	public Actor findActorByID(short id)
	{
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.ID == id)
			{
				return actor;
			}
		}
		return null;
	}

	private DropItem findItemByID(short id)
	{
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == 3 && actor.ID == id)
			{
				return (DropItem)actor;
			}
		}
		return null;
	}

	private Dropable findPotionByID(short id, int catagory)
	{
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == catagory && actor.ID == id)
			{
				return (Dropable)actor;
			}
		}
		return null;
	}

	public void onMainCharInfo()
	{
		GameData.gI().getImage();
		mainChar.timeDelayRequestCharInfo = mSystem.getCurrentTimeMillis();
		if (mainChar.gender <= 0)
		{
			mainChar.gender = Char.GENDER_OF_CLAZZ[mainChar.clazz];
		}
		if (mainChar.level == 1 && mainChar.lvpercent == 0 && !mainChar.first)
		{
			first = true;
			mainChar.isFirstTimeGetItem = (mainChar.isFirstTimeGetMoney = (mainChar.isFirstTimeGetPotion = true));
		}
		if (mainChar.defend > 0 || mainChar.defend_magic > 0)
		{
			int num = 0;
			num = ((mainChar.defend <= mainChar.defend_magic) ? 36 : 21);
			mainChar.effPhap = new Effect(mainChar.x, mainChar.y, num);
		}
		mainChar.loadQuickSlot();
		PauseMenu.gI().initName();
		MenuWindows.gI().initName();
	}

	public void onMonsterInfo(MonsterInfo monsterInfo)
	{
		if (readyGetGameLogic && monsterInfo != null)
		{
			findMonsterByID(monsterInfo.id)?.setInfo(monsterInfo);
		}
	}

	public void charOutGame(short charID)
	{
		if (!readyGetGameLogic)
		{
			return;
		}
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == 0 && actor.ID == charID)
			{
				actor.wantDestroy = true;
				break;
			}
		}
	}

	public void onBossAttackPlayer(Message msg)
	{
		short id = msg.reader().readShort();
		sbyte skillID = msg.reader().readByte();
		Monster monster = findMonsterByID(id);
		if (monster == null)
		{
			return;
		}
		sbyte b = msg.reader().readByte();
		mVector mVector2 = new mVector();
		for (int i = 0; i < b; i++)
		{
			short num = msg.reader().readShort();
			LiveActor liveActor = (LiveActor)findActorByID(num);
			if (liveActor != null)
			{
				liveActor.damAttack = msg.reader().readInt();
				int hp = msg.reader().readInt();
				if (mainChar.ID == num)
				{
					if (mainChar.comeHome)
					{
						mainChar.state = 0;
						mainChar.comeHome = false;
					}
					mainChar.realHP = (mainChar.hp = hp);
					monster.dir = Util.findDirection(monster, mainChar);
					if (focusedActor == null)
					{
						focusedActor = monster;
					}
					mVector2.addElement(mainChar);
					continue;
				}
				if (monster.monster_type == 90 || monster.monster_type == 82)
				{
				}
				if (liveActor != null)
				{
					liveActor.realHP = (liveActor.hp = hp);
					if (liveActor.hp <= 0)
					{
						((Char)liveActor).state = 3;
					}
					monster.dir = Util.findDirection(monster, liveActor);
				}
				mVector2.addElement(liveActor);
			}
			else
			{
				int num2 = msg.reader().readInt();
				int num3 = msg.reader().readInt();
			}
		}
		monster.startAttack(mVector2, skillID);
		try
		{
			int idSkill = msg.reader().readUnsignedByte();
			monster.setIdSkill(idSkill);
			int byMap = msg.reader().readUnsignedByte();
			monster.setByMap(byMap);
		}
		catch (Exception)
		{
		}
	}

	public void onMonsterAttackPlayer(short attacker, short attacked, int hpLost, int hpLeft)
	{
		if (!readyGetGameLogic)
		{
			return;
		}
		Monster monster = findMonsterByID(attacker);
		if (monster == null)
		{
			return;
		}
		if (attacked == 32001)
		{
			monster.setRemoveTarget();
			return;
		}
		if (monster.monster_type != 84)
		{
			monster.startAttack();
		}
		if (mainChar.ID == attacked)
		{
			monster.setTarget(mainChar);
			if (mainChar.comeHome)
			{
				mainChar.state = 0;
				mainChar.comeHome = false;
			}
			mainChar.realHP = (mainChar.hp = hpLeft);
			if (monster.monster_type == 90)
			{
				startFlyText((hpLost == 0) ? "MISS" : ("-" + hpLost), (hpLost != 0) ? 4 : 0, mainChar.x, mainChar.y - 40, 0, -1);
				monster.startAttack(mainChar, hpLost, 8, 4);
				if (mainChar.hp <= 0)
				{
					mainChar.state = 3;
				}
				return;
			}
			monster.dir = Util.findDirection(monster, mainChar);
			if (focusedActor == null)
			{
				focusedActor = monster;
			}
			int num = Util.abs(mainChar.x - monster.x) + Util.abs(mainChar.y - monster.y);
			if (num < 48)
			{
				mainChar.smalljump();
				startFlyText((hpLost == 0) ? "MISS" : ("-" + hpLost), (hpLost != 0) ? 4 : 0, mainChar.x, mainChar.y - 40, 0, -1);
				if (monster.monster_type != 90)
				{
					EffectManager.addHiEffect(mainChar.x, mainChar.y - 10, 9);
				}
				if (mainChar.hp <= 0)
				{
					mainChar.state = 3;
				}
			}
			else if (monster.monster_type != 90)
			{
				startNewMagicBeam(20, monster, mainChar, monster.x, monster.y, hpLost, 0);
			}
			mainChar.downDuarable();
			if (monster.monster_type == 84)
			{
				mVector mVector2 = new mVector();
				mVector2.addElement(mainChar);
				monster.startAttack(mVector2, 0);
			}
			return;
		}
		Char @char = (Char)findCharByID(attacked);
		if (@char == null)
		{
			return;
		}
		monster.setTarget(@char);
		@char.realHP = (@char.hp = hpLeft);
		if (@char.hp <= 0)
		{
			@char.state = 3;
		}
		monster.dir = Util.findDirection(monster, @char);
		@char.smalljump();
		startFlyText((hpLost == 0) ? "MISS" : ("-" + hpLost), (hpLost != 0) ? 4 : 0, @char.x, @char.y - 40, 0, -1);
		if (monster.monster_type == 90)
		{
			monster.startAttack(@char, hpLost, 8, 4);
			return;
		}
		EffectManager.hiEffects.addElement(new Effect(@char.x, @char.y - 10, 9));
		if (monster.monster_type == 84)
		{
			mVector mVector3 = new mVector();
			mVector3.addElement(@char);
			monster.startAttack(mVector3, 0);
		}
	}

	public void onPingBack()
	{
		pingDelay = mSystem.getCurrentTimeMillis() - lastTimePing;
		pingNextIn = DELAY_BETWEEN_PING;
	}

	public void onLoginSuccess()
	{
	}

	public void onConnectOK()
	{
		Canvas.isConnectOk = true;
	}

	public void onConnectFail()
	{
		Canvas.isConnectFail = true;
	}

	public void onLoginFail(string reason)
	{
		if (reason.StartsWith("1"))
		{
			if (!Main.isDisConnect)
			{
				ActionPerform action = delegate
				{
					Canvas.currentDialog = null;
					ServerListScr.gI().switchToMe();
					Session_ME.gI().close();
				};
				Canvas.startOKDlg(reason.Substring(1), action);
				return;
			}
			Command command = new Command("OK");
			ActionPerform action2 = delegate
			{
				Canvas.endDlg();
				Canvas.instance.init();
				Session_ME.gI().close();
				Tilemap.loadMap(0, null);
				ServerListScr.gI().switchToMe();
			};
			command.action = action2;
			Canvas.msgdlg.setInfo(reason.Substring(1), null, command, null);
			Canvas.currentDialog = Canvas.msgdlg;
		}
		else if (!Main.isDisConnect)
		{
			Canvas.startOKDlg(reason);
		}
		else if (Main.isDisConnect)
		{
			Command command2 = new Command("OK");
			ActionPerform action3 = delegate
			{
				Canvas.endDlg();
				Canvas.instance.init();
				Session_ME.gI().close();
				Tilemap.loadMap(0, null);
				ServerListScr.gI().switchToMe();
			};
			command2.action = action3;
			Canvas.msgdlg.setInfo(reason, null, command2, null);
			Canvas.currentDialog = Canvas.msgdlg;
		}
	}

	public void onDisconnect()
	{
		autoFight = false;
		Canvas.isBeginAutoLogin = true;
	}

	public bool isOffLineMap(int mapID)
	{
		int num = offMapID.Length;
		for (int i = 0; i < num; i++)
		{
			if (mapID == offMapID[i])
			{
				return true;
			}
		}
		return false;
	}

	public short getIndexArrMap()
	{
		int num = mapID.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < mapID[i].Length; j++)
			{
				if (map == mapID[i][j])
				{
					return idArrMap[i];
				}
			}
		}
		return -1;
	}

	public short getIndexArrMap(int idm)
	{
		int num = mapID.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < mapID[i].Length; j++)
			{
				if (idm == mapID[i][j])
				{
					return idArrMap[i];
				}
			}
		}
		return -1;
	}

	public short getMapLoad(int mapid)
	{
		int num = mapID.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < mapID[i].Length; j++)
			{
				if (mapid == mapID[i][j])
				{
					return mapID[i][0];
				}
			}
		}
		return -1;
	}

	public void onMap(short map, short toX, short toY, short mapLoad, string mapName, sbyte[] sbyteMap)
	{
		btnFocus = 0;
		Canvas.endDlg();
		mainChar.posTransRoad = null;
		mainChar.EffFace = null;
		objcountDown = null;
		focusedActor = null;
		VecTime.removeAllElements();
		charcountdonw = null;
		int num = nearActors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)nearActors.elementAt(i);
			if (actor != null)
			{
				actor = null;
			}
		}
		nearActors.removeAllElements();
		if (effManager != null)
		{
			int num2 = effManager.size();
			for (int j = 0; j < num2; j++)
			{
				EffectServerManager effectServerManager = (EffectServerManager)effManager.elementAt(j);
				if (effectServerManager != null)
				{
					effectServerManager = null;
				}
			}
			effManager.removeAllElements();
		}
		congThanh = null;
		short num3 = mapLoad;
		if (num3 == -1)
		{
			num3 = map;
		}
		if (toX != -1 && toY != -1)
		{
			mainChar.x = (mainChar.xTo = (short)(toX * 16 + 8));
			mainChar.y = (mainChar.yTo = (short)(toY * 16 + 8));
			if (mainChar.x / 16 <= 1)
			{
				mainChar.x += 32;
			}
			if (mainChar.y / 16 <= 1)
			{
				mainChar.y += 32;
			}
			mainChar.xTo = mainChar.x;
			mainChar.yTo = mainChar.y;
			if (mainChar.myPet != null)
			{
				setInfoCharPet(mainChar.myPet, mainChar);
			}
		}
		int num4 = 0;
		int num5 = actors.size();
		for (int k = 0; k < num5; k++)
		{
			Actor actor2 = (Actor)actors.elementAt(k);
			if (actor2 != null && mainChar != null && actor2.ID != mainChar.ID)
			{
				actor2 = null;
			}
		}
		actors.removeAllElements();
		if (mainChar != null)
		{
			actors.addElement(mainChar);
		}
		if (this.map != map)
		{
			num4 = 1;
			this.map = map;
			ActionPerform ia = delegate
			{
				Canvas.gameScr.loadCamera();
				posNpcRequest = null;
				if (current_npc_talk != -1 || idNpcReceive != -1)
				{
					set_npc_request(current_npc_talk);
				}
				Canvas.gameScr.switchToMe();
				gameService.changeMapOK(-500, 0, 0);
				try
				{
					setAutoTask();
					setObjDynamicType();
					Out.println("auto 1 >> onmap ");
				}
				catch (Exception ex2)
				{
					Out.Log("ERROR ONMAP" + ex2.StackTrace);
				}
			};
			Res.load.loadMap(num3, ia, sbyteMap);
		}
		switch (num3)
		{
		case 107:
			mainChar.delay = 1L;
			mainChar.realTime = 1L;
			mainChar.timeWait2Board = mSystem.getCurrentTimeMillis();
			break;
		case 10:
			mainChar.delay = -1L;
			mainChar.realTime = -1L;
			if (mainChar.potions[20] > 0)
			{
				mainChar.potions[20]--;
			}
			break;
		}
		if (num3 != 201)
		{
			timeChiemThanh = null;
		}
		readyGetGameLogic = true;
		mainChar.state = 0;
		mainChar.comeHome = false;
		try
		{
			if (Canvas.loginScr != null)
			{
				Canvas.loginScr = null;
				CharSelectScr.me = null;
				Canvas.imgLogo = null;
				ServerListScr.close();
			}
			Canvas.currentDialog = null;
			Canvas.clearKeyHold();
			Canvas.clearKeyPressed();
			Tilemap.setNameMap(num3);
			nameMap = mapName;
			if (num4 == 0)
			{
				Canvas.gameScr.switchToMe();
				setAutoTask();
				setObjDynamicType();
				Out.println("auto 2 >>> onmap ");
			}
		}
		catch (Exception ex)
		{
			Out.println("ERROR ONMAP" + ex.StackTrace);
		}
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	public void setObjDynamicType()
	{
		int num = objDynamic.size();
		for (int i = 0; i < num; i++)
		{
			DynamicObj dynamicObj = (DynamicObj)objDynamic.elementAt(i);
			if (actors.conTains(dynamicObj))
			{
				continue;
			}
			actors.addElement(dynamicObj);
			for (int j = 0; j < dynamicObj.w / 2; j++)
			{
				int num2 = dynamicObj.y / 16 * Tilemap.w + (dynamicObj.x / 16 - j);
				if (num2 < Tilemap.type.Length)
				{
					Tilemap.type[num2] = 2;
				}
				int num3 = dynamicObj.y / 16 * Tilemap.w + (dynamicObj.x / 16 + j);
				if (num3 < Tilemap.type.Length)
				{
					Tilemap.type[num3] = 2;
				}
				for (int k = 0; k < dynamicObj.h / 2; k++)
				{
					int num4 = (dynamicObj.y / 16 - k) * Tilemap.w + (dynamicObj.x / 16 - j);
					if (num4 < Tilemap.type.Length)
					{
						Tilemap.type[num4] = 2;
					}
					int num5 = (dynamicObj.y / 16 - k) * Tilemap.w + (dynamicObj.x / 16 + j);
					if (num5 < Tilemap.type.Length)
					{
						Tilemap.type[num5] = 2;
					}
				}
			}
		}
		for (int l = 0; l < num; l++)
		{
			DynamicObj dynamicObj2 = (DynamicObj)objDynamic.elementAt(l);
			if (dynamicObj2 != null)
			{
				dynamicObj2 = null;
				objDynamic.removeElementAt(l);
			}
		}
	}

	private void setAutoTask()
	{
		if (Char.skillLevelLearnt[0] != 0 || (Tilemap.lv == 0 && Tilemap.lv == 101) || Tilemap.lv == 105 || iTaskAuto != 0)
		{
			return;
		}
		iTaskAuto = 1;
		ActionPerform yesAction = delegate
		{
			Canvas.startWaitDlg();
			mapFind = new sbyte[Tilemap.w][];
			int num = mapFind.Length;
			for (int i = 0; i < num; i++)
			{
				mapFind[i] = new sbyte[Tilemap.h];
			}
			iTaskAuto = 2;
			Canvas.endDlg();
		};
		ActionPerform noAction = delegate
		{
			iTaskAuto = 1;
			Canvas.endDlg();
			addChat(new ChatInfo(string.Empty, "Hãy đi gặp các tiền bối trong làng để học võ công.", 0));
		};
		Canvas.startYesNoDlg("Bạn có muốn hệ thống tự động làm nhiệm vụ cho bạn hay không ?", yesAction, noAction);
	}

	public int getPosNameMap(int idm)
	{
		int num = mapID.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < mapID[i].Length; j++)
			{
				if (idm == mapID[i][j])
				{
					return j;
				}
			}
		}
		return -1;
	}

	public void listServer(string reason, string[] ip, short[] port, string[] name)
	{
		Canvas.endDlg();
		ActionPerform action = delegate
		{
			Debug.Log("CHUAN BI CAP NHAT ");
			Canvas.currentDialog = null;
			ServerListScr.gI().switchToMe();
			ServerListScr.address = ip;
			ServerListScr.port = port;
			ServerListScr.nameServer = name;
			RMS.saveRMSStringIp(ip, port, name);
			Session_ME.gI().close();
		};
		Canvas.startOKDlg(reason, action);
	}

	public void onCharList(MainChar[] charInfos)
	{
		if (Session_ME.connected)
		{
			Canvas.loginScr.savePass();
			if (!isNewVersionAvailable)
			{
				Canvas.endDlg();
			}
			CharSelectScr.gI().setCharList(charInfos);
			CharSelectScr.gI().switchToMe();
		}
	}

	public void onCharWearingInfo(short charID, mVector items, sbyte idFashion, sbyte typePet, string petInfo, AnimalMove myPet, short[] idModel0, sbyte idIconAnimal)
	{
		if (charID == mainChar.ID)
		{
			mainChar.idFashion = idFashion;
			mainChar.setWearingInfo(items);
			mainChar.idAnimal = typePet;
			mainChar.infoAnimal = petInfo;
			mainChar.idModel = idModel0;
			mainChar.idPaintIconAnimal = idIconAnimal;
			if (myPet != null)
			{
				myPet.idSameMyOwnerID = mainChar.ID;
				setCharPet(myPet, mainChar);
			}
			else if (mainChar.myPet != null)
			{
				mainChar.myPet.status = 3;
				mainChar.myPet.timeMagic = 20;
			}
			return;
		}
		Char @char = (Char)findCharByID(charID);
		if (@char != null)
		{
			@char.idFashion = idFashion;
			@char.setWearingInfo(items);
			@char.idAnimal = typePet;
			@char.infoAnimal = petInfo;
			@char.idModel = idModel0;
			@char.idPaintIconAnimal = idIconAnimal;
			if (myPet != null)
			{
				myPet.idSameMyOwnerID = @char.ID;
				setCharPet(myPet, @char);
			}
			else if (@char.myPet != null)
			{
				@char.myPet.status = 3;
				@char.myPet.timeMagic = 20;
			}
		}
	}

	public void setCharPet(AnimalMove pet, Char myOwner0)
	{
		if (pet.type == 5)
		{
			clearCharPet(myOwner0.ID);
			Pet o = new Pet(myOwner0, pet.imgID);
			setInfoCharPet(pet, myOwner0);
			actors.addElement(o);
			return;
		}
		clearCharPet(myOwner0.ID);
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == pet.catagory && !actor.ispetTool())
			{
				AnimalMove animalMove = (AnimalMove)actor;
				if (animalMove.idSameMyOwnerID == pet.idSameMyOwnerID)
				{
					animalMove.type = pet.type;
					animalMove.imgID = pet.imgID;
					animalMove.sumFrame = pet.sumFrame;
					animalMove.infoPet = pet.infoPet;
					animalMove.totalTime = pet.totalTime;
					animalMove.timeStart = pet.timeStart;
					setInfoCharPet(animalMove, myOwner0);
					return;
				}
			}
		}
		pet.setFrameType4();
		setInfoCharPet(pet, myOwner0);
		actors.addElement(pet);
	}

	public void onPetAttack(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			if (b == 0)
			{
				short idSkill = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				int[] array = new int[b2];
				int[] array2 = new int[b2];
				mVector mVector2 = new mVector();
				Actor actor = Canvas.gameScr.findActorByID_Cat(id, Actor.CAT_MY_PET);
				if (actor != null)
				{
					for (int i = 0; i < b2; i++)
					{
						sbyte cat = msg.reader().readByte();
						short id2 = msg.reader().readShort();
						Actor actor2 = Canvas.gameScr.findActorByID_Cat(id2, cat);
						if (actor2 != null)
						{
							mVector2.addElement(actor2);
						}
						array[i] = msg.reader().readInt();
						array2[i] = msg.reader().readInt();
					}
					actor.petAttack(mVector2, b, idSkill, array, array2);
				}
			}
			if (b == 1)
			{
				Actor actor3 = Canvas.gameScr.findActorByID(id);
				short id3 = msg.reader().readShort();
				long timelive = msg.reader().readLong();
				actor3?.addEffbuff(id3, actor3.x, actor3.y, timelive);
			}
		}
		catch (Exception)
		{
		}
	}

	public Actor findActorByID_Cat(short id, sbyte cat)
	{
		Actor actor = null;
		for (int num = actors.size() - 1; num >= 0; num--)
		{
			actor = (Actor)actors.elementAt(num);
			if (actor.ID == id && actor.catagory == cat)
			{
				return actor;
			}
		}
		return null;
	}

	public void clearCharPet(short id)
	{
		for (int i = 0; i < actors.size(); i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == Actor.CAT_MY_PET && actor.ID == id && actor.ispetTool())
			{
				actors.removeElement(actor);
			}
		}
	}

	public void setInfoCharPet(AnimalMove pp, Char myOwner0)
	{
		pp.hImg = 1;
		pp.wImg = 1;
		pp.myOwner = myOwner0;
		myOwner0.myPet = pp;
		pp.x = (pp.xTo = ((myOwner0.dir != Char.LEFT && myOwner0.dir != Char.UP) ? ((short)(myOwner0.x - 20)) : ((short)(myOwner0.x + 20))));
		pp.y = (pp.yTo = myOwner0.y);
		if (pp.type != 1)
		{
			pp.addY = (short)(-myOwner0.height + 15);
		}
		else
		{
			pp.addY = 0;
		}
		pp.v = (sbyte)myOwner0.speed;
		pp.status = 0;
		pp.count = (pp.idFrame = 0);
	}

	public void onViewAnimalInfo(Char ch)
	{
		WindowInfoScr.gI().setInfo(0, isSell: false, new sbyte[1] { 31 });
		WindowInfoScr.charWearing = ch;
		WindowInfoScr.gI().switchToMe();
		WindowInfoScr.gI().name = "Trang bị thú";
		Canvas.endDlg();
	}

	public void onAnimalWearingInfo(short charID, mVector items, Image imgAnimal0, sbyte numFrame0, int wimg0, int himg0, sbyte timeChangeFrame0)
	{
		if (charID == mainChar.ID)
		{
			mainChar.imgAnimal = imgAnimal0;
			mainChar.numFrame = numFrame0;
			mainChar.wimg = wimg0;
			mainChar.himg = himg0;
			mainChar.timeChangeFrame = timeChangeFrame0;
			mainChar.setAnimalWearingInfo(items);
			return;
		}
		Char @char = (Char)findCharByID(charID);
		if (@char != null)
		{
			@char.imgAnimal = imgAnimal0;
			@char.numFrame = numFrame0;
			@char.wimg = wimg0;
			@char.himg = himg0;
			@char.timeChangeFrame = timeChangeFrame0;
			@char.setAnimalWearingInfo(items);
			onViewAnimalInfo(@char);
		}
	}

	public void onCharInventory(long charXu, int[] potions, mVector items, mVector animals, int type)
	{
		mainChar.setInventory(charXu, potions, items, animals, type);
		cancelTrade();
		if (Canvas.currentScreen == WindowInfoScr.gI() && WindowInfoScr.index[WindowInfoScr.focusTab] == 0)
		{
			WindowInfoScr.gI().isLoad = true;
			MenuWindows.gI().isLoad = true;
			PauseMenu.gI().showMe(0);
			WindowInfoScr.gI().isLoad = false;
			MenuWindows.gI().isLoad = false;
		}
		if (Canvas.currentScreen == MenuWindows.gI() && MenuWindows.gI().focusTabChinh == 2)
		{
			MenuWindows.gI().isLoad = true;
			MenuWindows.gI().setCurTab();
			MenuWindows.gI().isLoad = false;
		}
	}

	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	public void onGetItemFromGround(short whoGet, ItemInInventory cii)
	{
		DropItem dropItem = findItemByID(cii.itemOldID);
		if (dropItem != null)
		{
			Char @char = (Char)findCharByID(whoGet);
			if (@char != null)
			{
				if (@char == mainChar)
				{
					addChat(new ChatInfo(string.Empty, "Nhặt được " + dropItem.getDisplayName(), 1));
				}
				dropItem.startFlyTo(@char.x, @char.y);
			}
			dropItem.wantDestroy = true;
		}
		if (whoGet == mainChar.ID)
		{
			Char.inventory.addElement(cii);
			if (mainChar.isFirstTimeGetItem)
			{
				Canvas.startOKDlg("Bạn vừa nhặt được một món đồ.", isIcon: false, 10);
				mainChar.isFirstTimeGetItem = false;
			}
		}
	}

	public void onGetPotionFromGround(short whoGet, short potionID, short potionType, short potionQuantity)
	{
		DropPotion dropPotion = (DropPotion)findPotionByID(potionID, 4);
		if (dropPotion != null)
		{
			Char @char = (Char)findCharByID(whoGet);
			if (@char != null)
			{
				if (@char == mainChar)
				{
					startFlyText("+" + potionQuantity + string.Empty + dropPotion.getDisplayName2().ToLower(), 2, mainChar.x - 10, mainChar.y - 30, 1, -1);
					if (mainChar.getItemQuest(dropPotion.item_template_id))
					{
						addChat(new ChatInfo(string.Empty, "Nhặt " + mainChar.infoQuest + " " + dropPotion.getDisplayName2(), 0));
					}
				}
				dropPotion.startFlyTo(@char.x, @char.y);
			}
			else
			{
				dropPotion.wantDestroy = true;
			}
		}
		if (whoGet != mainChar.ID)
		{
			return;
		}
		if (potionType == 0)
		{
			mainChar.charXu += potionQuantity;
		}
		else
		{
			mainChar.potions[potionType] += potionQuantity;
		}
		if (potionType == 0)
		{
			if (mainChar.isFirstTimeGetMoney)
			{
				Canvas.startOKDlg("Bạn vừa nhặt được xu Bạn có thể dùng xu để mua HP, MP và đồ dùng khác.", isIcon: false, 1);
				mainChar.isFirstTimeGetMoney = false;
			}
			return;
		}
		if (idItemClanquest != -1 && idItemClanquest == potionType)
		{
			WindowInfoScr.numberQuestGet++;
			if (WindowInfoScr.numberQuestGet >= WindowInfoScr.numberQuestAll)
			{
				idItemClanquest = -1;
				addChat(new ChatInfo(string.Empty, "Hoàn thành nhiệm vụ.", 0));
			}
			else
			{
				addChat(new ChatInfo(string.Empty, "Nhặt được: " + WindowInfoScr.numberQuestGet + "/" + WindowInfoScr.numberQuestAll, 0));
			}
		}
		if (mainChar.isFirstTimeGetPotion)
		{
			Canvas.startOKDlg("Bạn vừa nhặt được một vật phẩm dùng được. Xin vào mục hành trang để xem.", isIcon: false, 1);
			mainChar.isFirstTimeGetPotion = false;
		}
	}

	public void onGetGemFromGround(short whoGet3, short gemID, sbyte catagory)
	{
		DropGemItem dropGemItem = (DropGemItem)findPotionByID(gemID, catagory);
		if (dropGemItem != null)
		{
			Char @char = (Char)findCharByID(whoGet3);
			if (@char != null)
			{
				dropGemItem.startFlyTo(@char.x, @char.y);
			}
			else
			{
				dropGemItem.wantDestroy = true;
			}
		}
	}

	public void onGetItemQuestFromGround(short whoGet3, short gemID, sbyte itemQuestType)
	{
		ItemQuest itemQuest = (ItemQuest)findPotionByID(gemID, 14);
		if (itemQuest == null)
		{
			return;
		}
		Char @char = (Char)findCharByID(whoGet3);
		if (@char != null)
		{
			itemQuest.startFlyTo(@char.x, @char.y);
		}
		else
		{
			itemQuest.wantDestroy = true;
		}
		if (mainChar.ID == whoGet3)
		{
			if (mainQuest != null && mainQuest.isWorking())
			{
				mainQuest.getItemQuest(itemQuestType);
			}
			if (subQuest != null && subQuest.isWorking())
			{
				subQuest.getItemQuest(itemQuestType);
			}
			if (clanQuest != null && clanQuest.isWorking())
			{
				clanQuest.getItemQuest(itemQuestType);
			}
		}
	}

	public void dellPotionQuest()
	{
		for (int i = 10; i < 14; i++)
		{
			mainChar.potions[i] = 0;
		}
	}

	private void setItemInfo(mVector list, ItemInInventory itemMoreInfo)
	{
		if (list == null || itemMoreInfo == null)
		{
			return;
		}
		ItemInInventory itemByID = getItemByID(list, itemMoreInfo.itemID);
		if (itemByID != null)
		{
			itemByID.isEnoughData = true;
			itemByID.clazz = itemMoreInfo.clazz;
			itemByID.dayUse = itemMoreInfo.dayUse;
			itemByID.property = itemMoreInfo.property;
			itemByID.allAttribute = itemMoreInfo.allAttribute;
			itemByID.itemAttribute = itemMoreInfo.itemAttribute;
			itemByID.durable = itemMoreInfo.durable;
			itemByID.lastTime = mSystem.getCurrentTimeMillis();
			itemByID.islock = itemMoreInfo.islock;
			if (itemMoreInfo.plusTemplate > -1)
			{
				itemByID.plusTemplate = itemMoreInfo.plusTemplate;
			}
		}
	}

	public void onItemInfo(ItemInInventory itemMoreInfo)
	{
		Out.println("onItemInfo");
		if (itemMoreInfo == null)
		{
			return;
		}
		setItemInfo(Char.inventory, itemMoreInfo);
		if (MenuWindows.charWearing != null)
		{
			setItemInfo(MenuWindows.charWearing.wearingItems, itemMoreInfo);
			if ((MenuWindows.charWearing.useHorse != -1 || MenuWindows.charWearing.idhorse > -1) && MenuWindows.charWearing.wearingAnimal != null && MenuWindows.charWearing.wearingAnimal.size() > 0)
			{
				setItemInfo(MenuWindows.charWearing.wearingAnimal, itemMoreInfo);
			}
		}
		if (WindowInfoScr.charWearing != null)
		{
			setItemInfo(WindowInfoScr.charWearing.wearingItems, itemMoreInfo);
			if ((WindowInfoScr.charWearing.useHorse != -1 || WindowInfoScr.charWearing.idhorse > -1) && WindowInfoScr.charWearing.wearingAnimal != null && WindowInfoScr.charWearing.wearingAnimal.size() > 0)
			{
				setItemInfo(WindowInfoScr.charWearing.wearingAnimal, itemMoreInfo);
			}
		}
		setItemInfo(mainChar.tItems, itemMoreInfo);
		setItemInfo(mainChar.rItems, itemMoreInfo);
		setItemInfo(Char.itembag, itemMoreInfo);
		setItemInfo(WindowInfoScr.gI().sellItem, itemMoreInfo);
		if (WindowInfoScr.gI().listItemAnimal != null && WindowInfoScr.gI().listItemAnimal.size() > 0)
		{
			setItemInfo(WindowInfoScr.gI().listItemAnimal, itemMoreInfo);
		}
		if (Canvas.currentScreen == WindowInfoScr.gI())
		{
			WindowInfoScr.gI().closeText();
			if (WindowInfoScr.index[WindowInfoScr.focusTab] == 21 || WindowInfoScr.index[WindowInfoScr.focusTab] == 25)
			{
				WindowInfoScr.gI().doShowItemInfoImbue();
			}
			else if (WindowInfoScr.index[WindowInfoScr.focusTab] == 32)
			{
				WindowInfoScr.gI().doshowInfoEpdothu();
			}
			else
			{
				WindowInfoScr.gI().center.perform();
			}
		}
		if (Canvas.currentScreen == MenuWindows.gI())
		{
			MenuWindows.gI().closeText();
			if (MenuWindows.index[MenuWindows.focusTab] != 21 && MenuWindows.index[MenuWindows.focusTab] != 32)
			{
				MenuWindows.gI().center.perform();
			}
		}
		else if (Canvas.currentScreen == ScreenDapDo.gI())
		{
			ScreenDapDo.gI().setInfoItem(itemMoreInfo.itemID);
		}
		else if (Canvas.currentScreen == Canvas.shop)
		{
			Canvas.shop.onItemInfo();
		}
	}

	public void onUseItemPK(short charID, int use, int potionType)
	{
		Char @char = (Char)findCharByID(charID);
		if (@char != null)
		{
			if (use == 1)
			{
				@char.pk = (sbyte)potionType;
			}
			else
			{
				@char.pk = 0;
			}
		}
	}

	public void onUsePotion(short userId, sbyte potionType, short valueAdd, int valueNew, int isHP)
	{
		Char @char = (Char)findCharByID(userId);
		if (@char == null)
		{
			return;
		}
		if (valueNew <= 0)
		{
			@char.hp = 0;
			@char.realHP = 0;
			@char.state = 3;
			if (userId != mainChar.ID)
			{
			}
			return;
		}
		switch (potionType)
		{
		case 1:
		case 2:
		case 3:
		case 21:
		case 22:
			if (@char.hp < valueNew)
			{
				@char.hp = (@char.realHP = valueNew);
			}
			startFlyText((valueAdd <= 0) ? ("hp" + valueAdd) : "hp+", 4, @char.x - 10, @char.y - 30, 0, -1);
			if (userId != mainChar.ID)
			{
			}
			break;
		case 4:
		case 5:
		case 6:
		case 23:
		case 34:
		case 82:
		case 85:
			if (isHP == 1)
			{
				if (@char.hp < valueNew)
				{
					@char.hp = (@char.realHP = valueNew);
				}
				startFlyText((valueAdd <= 0) ? ("hp" + valueAdd) : "hp+", 4, @char.x - 10, @char.y - 30, 0, -1);
			}
			else
			{
				if (@char.mp < valueNew)
				{
					@char.mp = valueNew;
				}
				startFlyText((valueAdd <= 0) ? ("mp" + valueAdd) : "mp+", 3, @char.x - 10, @char.y - 40, 0, -1);
			}
			break;
		case 24:
			if (@char.mp < valueNew)
			{
				@char.mp = valueNew;
			}
			startFlyText((valueAdd <= 0) ? ("mp" + valueAdd) : "mp+", 3, @char.x - 10, @char.y - 40, 0, -1);
			if (isHP == 1)
			{
				@char.hp = (@char.realHP = valueNew);
				startFlyText((valueAdd <= 0) ? ("hp" + valueAdd) : "hp+", 4, @char.x - 10, @char.y - 30, 0, -1);
			}
			else
			{
				@char.mp = valueNew;
				startFlyText((valueAdd <= 0) ? ("mp" + valueAdd) : "mp+", 3, @char.x - 10, @char.y - 30, 0, -1);
			}
			break;
		}
	}

	private ItemInInventory getItemByID(mVector list, short id)
	{
		int num = list.size();
		for (int i = 0; i < num; i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)list.elementAt(i);
			if (itemInInventory != null && itemInInventory.itemID == id)
			{
				return itemInInventory;
			}
		}
		return null;
	}

	public void onEffData(Message msg)
	{
		try
		{
			if (msg.reader().readByte() == 0)
			{
				sbyte cat = msg.reader().readByte();
				short id = msg.reader().readShort();
				short id2 = msg.reader().readShort();
				int num = msg.reader().readInt();
				bool canmove = msg.reader().readBoolean();
				bool canpaint = msg.reader().readBoolean();
				Actor actor = findActorByID_Cat(id, cat);
				long timelive = 0L;
				if (num > 0)
				{
					timelive = num + mSystem.currentTimeMillis();
				}
				sbyte dyhorse = 0;
				try
				{
					dyhorse = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				actor?.addEffectSkillTime(id2, actor.x, actor.y, timelive, canmove, canpaint, canfight: true, 0, (sbyte)Res.random(1, 8), dyhorse);
			}
		}
		catch (Exception)
		{
		}
	}

	public void onPutItem2Bag(short itemID)
	{
		ItemInInventory itemByID = getItemByID(Char.inventory, itemID);
		if (itemByID != null)
		{
			Char.inventory.removeElement(itemByID);
			if (mainChar.isExistInvector(Char.itembag, itemByID) == -1)
			{
				Char.itembag.addElement(itemByID);
			}
		}
		else if (WindowInfoScr.gI() == Canvas.currentScreen && WindowInfoScr.index[WindowInfoScr.focusTab] == 22)
		{
			WindowInfoScr.gI().setSizeKeepItem(0);
		}
	}

	public void onGetItemFromBag(short itemID)
	{
		ItemInInventory itemByID = getItemByID(Char.itembag, itemID);
		if (itemByID != null)
		{
			Char.itembag.removeElement(itemByID);
			if (mainChar.isExistInvector(Char.inventory, itemByID) == -1)
			{
				Char.inventory.addElement(itemByID);
			}
		}
	}

	public void onNPCKeepItem(mVector itemBag)
	{
		Char.itembag = itemBag;
		showWindow(0, isSell: true, new sbyte[1] { 22 });
	}

	public void onNPCSellPotion(sbyte[] potionsSell)
	{
		shop.removeAllElements();
		int num = potionsSell.Length;
		for (int i = 0; i < num; i++)
		{
			ItemInInventory itemInInventory = new ItemInInventory();
			if (itemInInventory != null)
			{
				itemInInventory.catagory = 4;
				if (i < potionsSell.Length)
				{
					itemInInventory.potionType = potionsSell[i];
					itemInInventory.isEnoughData = true;
					itemInInventory.isShopItem = true;
					shop.addElement(itemInInventory);
				}
			}
		}
		showWindow(1, isSell: true, new sbyte[2] { 0, 19 });
	}

	public void onShopSpecial(mVector v)
	{
		shopSpecial = Res.shopTemplate;
		shopSpecial.removeAllElements();
		if (Res.shopTemplate == null)
		{
			return;
		}
		int num = Res.shopTemplate.size();
		for (int i = 0; i < num; i++)
		{
			GemTemp gemTemp = (GemTemp)Res.shopTemplate.elementAt(i);
			if (gemTemp != null && gemTemp.isSell)
			{
				shopSpecial.addElement(gemTemp);
			}
		}
	}

	public void onNPCSellGemItem(mVector gem)
	{
		shop.removeAllElements();
		int num = Res.gemTemplate.size();
		for (int i = 0; i < num; i++)
		{
			GemTemp gemTemp = (GemTemp)Res.gemTemplate.elementAt(i);
			if (gemTemp != null && gemTemp.isSell)
			{
				shop.addElement(gemTemp);
			}
		}
		showWindow(1, isSell: true, new sbyte[2] { 0, 10 });
	}

	public void onNPCSellItem(mVector itemsSell)
	{
		shop = itemsSell;
		ItemInInventory itemInInventory = (ItemInInventory)itemsSell.elementAt(0);
		if (itemInInventory == null)
		{
			return;
		}
		ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
		if (item != null)
		{
			if ((item.type > 2 && item.type < 8) || (item.type >= 14 && item.type <= 18))
			{
				WindowInfoScr.gI().setInfo(1, isSell: true, new sbyte[2] { 0, 9 });
			}
			else
			{
				WindowInfoScr.gI().setInfo(0, isSell: true, new sbyte[9] { 11, 12, 13, 14, 15, 16, 17, 18, 0 });
			}
			WindowInfoScr.gI().switchToMe();
		}
	}

	public void onChat(short chatFromID, string text)
	{
		Actor actor = findActorByID(chatFromID);
		if (actor == null)
		{
			return;
		}
		actor.chat = null;
		if (actor is Char)
		{
			if (((Char)actor).idBoss != -1)
			{
				addChat(actor, text, 500);
				return;
			}
			addChat(actor, text, 50);
			MessageScr.gI().addTab(((Char)actor).name + ": " + text, null, 0);
		}
		else
		{
			addChat(actor, text, 50);
		}
	}

	public void onSellItem(short itemID)
	{
		ItemInInventory itemByID = getItemByID(Char.inventory, itemID);
		if (itemByID != null)
		{
			Char.inventory.removeElement(itemByID);
			ItemTemplate item = Res.getItem(itemByID.charClazz, itemByID.idTemplate);
			mainChar.charXu += item.price / 5;
			Canvas.startOKDlg("Ðã bán thành công.", isIcon: false);
		}
	}

	public void onSellGemItem(short itemID)
	{
		GemTemplate gemByRealID = GemTemplate.getGemByRealID(itemID);
		if (gemByRealID != null)
		{
			gemByRealID.number--;
			if (gemByRealID.number <= 0)
			{
				MainChar.gemItem.removeElement(gemByRealID);
				GemTemp gemByID = Res.getGemByID(gemByRealID.id);
				mainChar.charXu += gemByID.price / 5;
				Canvas.startOKDlg("Ðã bán thành công.");
			}
		}
	}

	public void onGiveItemToGround(short charID, short itemID, ItemDropInfo mdi)
	{
		ItemInInventory itemByID = getItemByID(Char.inventory, itemID);
		if (itemByID != null)
		{
			Char.inventory.removeElement(itemByID);
			Dropable dropable = (Dropable)CreateActor(mdi.itemCatagory, mdi.itemTemplateID, mdi.itemID, mdi.x, mdi.y, 0, -1);
			dropable.startDropFrom(mainChar.x, mainChar.y, dropable.x, dropable.y);
			actors.addElement(dropable);
			if (mainChar.ID == charID)
			{
				Canvas.startOKDlg("Đã bỏ vật phẩm ra đất.");
			}
		}
		else
		{
			Dropable dropable2 = (Dropable)CreateActor(mdi.itemCatagory, mdi.itemTemplateID, mdi.itemID, mdi.x, mdi.y, 0, -1);
			if (dropable2 != null)
			{
				dropable2.startDropFrom(mainChar.x, mainChar.y, dropable2.x, dropable2.y);
				actors.addElement(dropable2);
			}
		}
	}

	public void onSetXP(short whoSetXP, short newpercent, int dxp)
	{
		Char @char = (Char)findCharByID(whoSetXP);
		if (@char != null)
		{
			@char.lvpercent = newpercent;
			startFlyText("+" + dxp + "xp", 2, @char.x, @char.y - 30, -1, -1);
		}
	}

	public void onCharProperties(short id, Property[] ps)
	{
		Char @char = (Char)findCharByID(id);
		if (@char != null)
		{
			int num = ps.Length;
			for (int i = 0; i < num; i++)
			{
				@char.setProperty(ps[i]);
			}
		}
	}

	public void onLevelUp(short idc, sbyte newlevel, int maxHP, int maxMP)
	{
		Char @char = (Char)findCharByID(idc);
		if (@char == null)
		{
			return;
		}
		@char.level = newlevel;
		@char.lockUpdate = 30;
		@char.dir = 0;
		@char.maxhp = maxHP;
		@char.maxmp = maxMP;
		@char.hp = maxHP;
		@char.mp = maxMP;
		@char.realHP = @char.hp;
		startFlyText("level-up", 3, @char.x, @char.y - 30, -1, 1);
		startFlyText("level-up", 3, @char.x, @char.y - 30, 1, -1);
		startFlyText("level-up", 3, @char.x, @char.y - 30, -1, -1);
		startFlyText("level-up", 3, @char.x, @char.y - 30, 1, 1);
		if (@char != null)
		{
			EffectManager.addHiEffect(@char.x, @char.y - 30, 18);
		}
		if (@char == mainChar)
		{
			addChat(new ChatInfo(string.Empty, "Đạt được level " + newlevel, 1));
			if (newlevel == 2)
			{
				Canvas.startOKDlg("Xin chúc mừng! Bạn vừa lên cấp. Chọn menu, nhân vật để tăng điểm tiềm năng và kỹ năng", isIcon: false, 20);
			}
		}
	}

	public void onRemoveActor(short actorID, sbyte cat)
	{
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == cat && actor.ID == actorID)
			{
				actors.removeElement(actor);
				break;
			}
		}
	}

	public void onCreadtePTOK(short idParty)
	{
		mainChar.IDParty = idParty;
		mainChar.IDMasterParty = mainChar.ID;
		if (tempIDActorParty != -1)
		{
			gameService.invite2Party(tempIDActorParty);
			tempIDActorParty = -1;
		}
	}

	public void onAdd2Party(Message m)
	{
		try
		{
			sbyte b = m.reader().readByte();
			short idInvite;
			string charName;
			int charLV;
			if (b == 0)
			{
				short partyID = m.reader().readShort();
				idInvite = m.reader().readShort();
				charName = m.reader().readUTF();
				charLV = m.reader().readByte();
				int num = m.reader().readShort();
				Message msg = new Message((sbyte)49);
				if (autoFight && Canvas.autoTab.isAutoParty && !onoffInvite)
				{
					try
					{
						msg.writer().writeByte(1);
						msg.writer().writeShort(idInvite);
						gameService.session.sendMessage(msg);
						msg.cleanup();
						PartyInfo info = new PartyInfo(idInvite, charName, charLV, m.reader().readByte());
						mainChar.add2Party(info);
						mainChar.IDMasterParty = idInvite;
						mainChar.IDParty = partyID;
						while (m.reader().available() > 0)
						{
							PartyInfo info2 = new PartyInfo(m.reader().readShort(), m.reader().readUTF(), m.reader().readByte(), m.reader().readByte());
							mainChar.add2Party(info2);
						}
						addChat(new ChatInfo(string.Empty, "Đã tham gia nhóm", 0));
					}
					catch (Exception)
					{
						Out.println(" loi tai onaddpart2");
					}
					Canvas.currentDialog = null;
					return;
				}
				ActionPerform yesAction = delegate
				{
					try
					{
						msg.writer().writeByte(1);
						msg.writer().writeShort(idInvite);
						gameService.session.sendMessage(msg);
						msg.cleanup();
						PartyInfo info4 = new PartyInfo(idInvite, charName, charLV, m.reader().readByte());
						mainChar.add2Party(info4);
						mainChar.IDMasterParty = idInvite;
						mainChar.IDParty = partyID;
						while (m.reader().available() > 0)
						{
							PartyInfo info5 = new PartyInfo(m.reader().readShort(), m.reader().readUTF(), m.reader().readByte(), m.reader().readByte());
							mainChar.add2Party(info5);
						}
						addChat(new ChatInfo(string.Empty, "Đã tham gia nhóm", 0));
					}
					catch (Exception)
					{
						Out.println("LOI KHI GUI OK VAO PARTY LEN SERVER");
					}
					Canvas.currentDialog = null;
				};
				ActionPerform noAction = delegate
				{
					try
					{
						msg.writer().writeByte(2);
						msg.writer().writeShort(idInvite);
						gameService.session.sendMessage(msg);
						msg.cleanup();
					}
					catch (Exception)
					{
					}
					Canvas.currentDialog = null;
				};
				Canvas.startYesNoDlg(charName + " mời bạn tham gia nhóm.", yesAction, noAction);
			}
			else if (b == 1)
			{
				idInvite = m.reader().readShort();
				charName = m.reader().readUTF();
				charLV = m.reader().readByte();
				if (Char.party.size() <= 0)
				{
					mainChar.IDMasterParty = mainChar.ID;
				}
				PartyInfo info3 = new PartyInfo(idInvite, charName, charLV, m.reader().readByte());
				mainChar.add2Party(info3);
				addChat(new ChatInfo(string.Empty, charName + " đã tham gia nhóm.", 0));
			}
			else if (b == 2)
			{
				Canvas.startOKDlg(m.reader().readUTF() + " từ chối vào nhóm.");
			}
			else if (b == 3)
			{
				while (m.reader().available() > 0)
				{
					PartyInfo partyInfo = new PartyInfo(m.reader().readShort(), m.reader().readUTF(), m.reader().readByte(), m.reader().readByte());
					addChat(new ChatInfo(string.Empty, partyInfo.name + " đã vào nhóm.", 0));
					mainChar.add2Party(partyInfo);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void onKickOutParty(Message m)
	{
		sbyte b = m.reader().readByte();
		string empty = string.Empty;
		if (b == 0 || b == 2)
		{
			short num = m.reader().readShort();
			if (num == mainChar.ID)
			{
				mainChar.IDParty = -1;
				mainChar.IDMasterParty = -1;
				Char.party.removeAllElements();
				if (b == 0)
				{
					addChat(new ChatInfo(string.Empty, "Bị đuổi khỏi nhóm", 0));
				}
				else
				{
					addChat(new ChatInfo(string.Empty, "Rời khỏi nhóm", 0));
				}
				return;
			}
			empty = mainChar.removeUserParty(num);
			if (!empty.Equals(string.Empty))
			{
				if (b == 0)
				{
					addChat(new ChatInfo(string.Empty, empty + " b? du?i kh?i nhóm", 0));
				}
				else
				{
					addChat(new ChatInfo(string.Empty, empty + " rời khỏi nhóm", 0));
				}
			}
			if (Char.party.size() <= 0)
			{
				Char.party.removeAllElements();
				mainChar.IDParty = -1;
				mainChar.IDMasterParty = -1;
				addChat(new ChatInfo(string.Empty, "Nhóm đã bị giải tán", 0));
			}
		}
		else if (b == 1)
		{
			mainChar.IDParty = -1;
			mainChar.IDMasterParty = -1;
			Char.party.removeAllElements();
			addChat(new ChatInfo(string.Empty, "Nhóm đã bị giải tán", 0));
		}
	}

	public void onCharUseBuff(Message m)
	{
		int num = m.reader().readByte();
		int num2 = m.reader().readShort();
		if (num == 2)
		{
			int num3 = actors.size();
			for (int i = 0; i < num3; i++)
			{
				Actor actor = (Actor)actors.elementAt(i);
				if (actor != null && actor.catagory == 0 && actor.ID == num2)
				{
					for (int j = 0; j < ((Char)actor).buffType.Length; j++)
					{
						((Char)actor).buffType[j] = m.reader().readByte();
					}
					for (int k = 0; k < ((Char)actor).buffType.Length; k++)
					{
						((Char)actor).countDown[k] = m.reader().readShort();
					}
					((Char)actor).setBuff(((Char)actor).buffType, ((Char)actor).countDown);
					for (int l = 0; l < ((Char)actor).lvBuff.Length; l++)
					{
						((Char)actor).lvBuff[l] = m.reader().readByte();
					}
					break;
				}
			}
			return;
		}
		int num4 = m.reader().readByte();
		int timeLive = m.reader().readShort();
		switch (num)
		{
		case 1:
		{
			int num6 = m.reader().readByte();
			int num7;
			for (num7 = 0; num7 < Char.BUFFTYPE.Length && Char.BUFFTYPE[num7] != num4; num7++)
			{
			}
			if (num2 == mainChar.ID)
			{
				if (!mainChar.isExistBuff(num4))
				{
					CharBuff charBuff = new CharBuff(mainChar.x, mainChar.y, num4);
					charBuff.setTimeLive(timeLive);
					timeBuff = charBuff.tick;
					isBuffAuto = true;
					mainChar.lvBuff[num7] = (sbyte)num6;
					mainChar.buffType[num7] = (sbyte)num4;
					mainChar.buff.addElement(charBuff);
				}
				break;
			}
			int num8 = actors.size();
			for (int num9 = 0; num9 < num8; num9++)
			{
				Actor actor3 = (Actor)actors.elementAt(num9);
				if (actor3.catagory == 0 && actor3.ID == num2)
				{
					if (!((Char)actor3).isExistBuff(num4))
					{
						CharBuff charBuff2 = new CharBuff(actor3.x, actor3.y, num4);
						charBuff2.setTimeLive(timeLive);
						((Char)actor3).lvBuff[num7] = (sbyte)num6;
						((Char)actor3).buffType[num7] = (sbyte)num4;
						((Char)actor3).buff.addElement(charBuff2);
					}
					break;
				}
			}
			break;
		}
		case 0:
		{
			int num5 = actors.size();
			for (int n = 0; n < num5; n++)
			{
				Actor actor2 = (Actor)actors.elementAt(n);
				if (actor2 != null && actor2.catagory == 0 && actor2.ID == num2)
				{
					((Char)actor2).removeBuff(num4);
					break;
				}
			}
			break;
		}
		}
	}

	public void onInfoQuestLogin(Message m)
	{
	}

	public void onInfoGiftQuest(string str)
	{
		addChat(new ChatInfo(string.Empty, str, 0));
	}

	public void isreceiveQuest(Message m)
	{
		Canvas.endDlg();
	}

	public void onFinishQuest(Message m)
	{
	}

	public void onNewHPMP(Message msg)
	{
		try
		{
			int num = msg.reader().readShort();
			int maxhp = msg.reader().readInt();
			int maxmp = msg.reader().readInt();
			short defend = msg.reader().readShort();
			int num2 = msg.reader().readInt();
			if (num == mainChar.ID)
			{
				mainChar.maxhp = maxhp;
				mainChar.maxmp = maxmp;
				mainChar.defend = defend;
				mainChar.hp = num2;
				mainChar.realHP = num2;
				if (mainChar.state == 3 && mainChar.hp > 0)
				{
					mainChar.state = 0;
					addChat(new ChatInfo(string.Empty, "Đã được hồi sinh.", 0));
				}
				return;
			}
			int num3 = actors.size();
			for (int i = 0; i < num3; i++)
			{
				Actor actor = (Actor)actors.elementAt(i);
				if (actor.catagory == Actor.CAT_PLAYER && actor.ID == num)
				{
					((Char)actor).hp = num2;
					((Char)actor).realHP = num2;
					((Char)actor).maxhp = maxhp;
					((Char)actor).maxmp = maxmp;
					((Char)actor).defend = defend;
					if (((Char)actor).state == 3 && mainChar.hp > 0)
					{
						((Char)actor).state = 0;
						addChat(new ChatInfo(string.Empty, ((Char)actor).name + " đã được hồi sinh.", 0));
					}
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void onKiller(int idChar, int check, short pkPoint)
	{
		if (mainChar.ID == idChar)
		{
			mainChar.iskiller = check == 1;
			mainChar.killer = pkPoint;
			return;
		}
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor.catagory == Actor.CAT_PLAYER && actor.ID == idChar)
			{
				((Char)actor).iskiller = check == 1;
				actor.killer = pkPoint;
				break;
			}
		}
	}

	public void onRequestTrade(short userid)
	{
		Char @char = (Char)findCharByID(userid);
		if (@char != null)
		{
			ActionPerform yesAction = delegate
			{
				gameService.sendOk_notOkInviteTrafe(userid, 1);
				Canvas.currentDialog = null;
			};
			ActionPerform noAction = delegate
			{
				gameService.sendOk_notOkInviteTrafe(userid, -1);
				Canvas.currentDialog = null;
			};
			Canvas.startYesNoDlg(@char.name + " đề nghị giao dịch với bạn.", yesAction, noAction);
		}
	}

	public void onOkTrade(short userID)
	{
		Char @char = (Char)findCharByID(userID);
		string content = "Bắt đầu giao dịch";
		if (userID != mainChar.ID && @char != null)
		{
			content = @char.name + " đồng ý giao dịch";
		}
		addChat(new ChatInfo(string.Empty, content, 0));
		cancelTrade();
		WindowInfoScr.gI().setInfo(0, isSell: true, new sbyte[1] { 8 });
		WindowInfoScr.gI().setSize(108, 90, 6, 6, 18, 18);
		WindowInfoScr.gI().switchToMe();
	}

	public void onDeniedTrade(short userid)
	{
		Char @char = (Char)findCharByID(userid);
		string text = string.Empty;
		if (@char != null)
		{
			text = @char.name;
		}
		addChat(new ChatInfo(string.Empty, text + " không đồng ý giao dịch", 0));
		cancelTrade();
	}

	public void onItemTrade(short userIdTrade, Message msg, sbyte type)
	{
		try
		{
			if (type == 0)
			{
				ItemInInventory itemInInventory = new ItemInInventory();
				itemInInventory.charClazz = (itemInInventory.clazz = msg.reader().readByte());
				itemInInventory.itemID = msg.reader().readShort();
				itemInInventory.itemOldID = itemInInventory.itemID;
				itemInInventory.idTemplate = msg.reader().readShort();
				itemInInventory.plusTemplate = msg.reader().readByte();
				itemInInventory.level = msg.reader().readByte();
				itemInInventory.durable = msg.reader().readShort();
				itemInInventory.mDurable = msg.reader().readShort();
				sbyte b = msg.reader().readByte();
				for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
				{
					InfoAttributeItem o = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
					itemInInventory.allAttribute.addElement(o);
				}
				itemInInventory.colorName = msg.reader().readByte();
				itemInInventory.heItem = msg.reader().readByte();
				itemInInventory.hangItem = msg.reader().readByte();
				itemInInventory.magic_physic = msg.reader().readByte();
				itemInInventory.isEnoughData = true;
				int num = -1;
				if (userIdTrade == mainChar.ID)
				{
					num = mainChar.isExistInvector(mainChar.tItems, itemInInventory);
					if (num == -1)
					{
						mainChar.tItems.addElement(itemInInventory);
					}
					else
					{
						mainChar.tItems.removeElementAt(num);
					}
					return;
				}
				Char @char = (Char)findCharByID(userIdTrade);
				if (@char != null)
				{
					num = mainChar.isExistInvector(mainChar.rItems, itemInInventory);
					if (num == -1)
					{
						mainChar.rItems.addElement(itemInInventory);
					}
					else
					{
						mainChar.rItems.removeElementAt(num);
					}
				}
			}
			else if (type == 1)
			{
				Potion potion = new Potion();
				potion.id = msg.reader().readUnsignedByte();
				potion.index = MainChar.listPotion[potion.id].index;
				potion.number = msg.reader().readShort();
				if (userIdTrade == mainChar.ID)
				{
					MainChar.listPotion[potion.id].numTrade += potion.number;
					addPotionTrade(mainChar.tItems, potion);
				}
				else
				{
					addPotionTrade(mainChar.rItems, potion);
				}
			}
			else if (type == 2)
			{
				int num2 = msg.reader().readUnsignedByte();
				if (userIdTrade == mainChar.ID)
				{
					MainChar.listPotion[num2].numTrade = 0;
					removePotionTrade(mainChar.tItems, num2);
				}
				else
				{
					removePotionTrade(mainChar.rItems, num2);
				}
			}
		}
		catch (Exception ex)
		{
			Out.Log(ex.Message);
		}
	}

	private void addPotionTrade(mVector list, Potion pa)
	{
		int num = list.size();
		for (int i = 0; i < num; i++)
		{
			if (list.elementAt(i) != null && list.elementAt(i) is Potion)
			{
				Potion potion = (Potion)list.elementAt(i);
				if (potion != null && potion.index == MainChar.listPotion[pa.id].index)
				{
					potion.number += pa.number;
					return;
				}
			}
		}
		list.addElement(pa);
	}

	private void removePotionTrade(mVector list, int id)
	{
		int num = list.size();
		for (int i = 0; i < num; i++)
		{
			if (list.elementAt(i) != null && list.elementAt(i) is Potion)
			{
				Potion potion = (Potion)list.elementAt(i);
				if (potion != null && potion.index == MainChar.listPotion[id].index)
				{
					list.removeElement(potion);
					break;
				}
			}
		}
	}

	public void onConfirmTrade()
	{
		if (WindowInfoScr.index[WindowInfoScr.focusTab] != 8)
		{
			return;
		}
		ActionPerform action = delegate
		{
			ActionPerform yesAction = delegate
			{
				GameService.gI().sendConfirmTrade();
				Canvas.gameScr.mainChar.isTrade = false;
				Canvas.endDlg();
				Command command = new Command(string.Empty);
				ActionPerform action2 = delegate
				{
				};
				command.action = action2;
				WindowInfoScr.gI().left = command;
				WindowInfoScr.gI().center = new Command("Xin chờ");
				WindowInfoScr.gI().center.action = delegate
				{
				};
			};
			ActionPerform noAction = delegate
			{
				Canvas.endDlg();
			};
			Canvas.startYesNoDlg("Bạn thật sự muốn trao đổi", yesAction, noAction);
		};
		WindowInfoScr.gI().left = new Command("Chuyển");
		WindowInfoScr.gI().left.action = action;
	}

	public void onFinishTrade()
	{
		cancelTrade();
		Canvas.startOKDlg("Giao dịch hoàn thành", isIcon: false);
	}

	public void oncancelTrade()
	{
		cancelTrade();
		Canvas.startOKDlg("Giao dịch bị hủy.");
	}

	private void cancelTrade()
	{
		mainChar.isTrade = false;
		mainChar.tItems.removeAllElements();
		mainChar.rItems.removeAllElements();
		int num = 0;
		if (MainChar.listPotion != null)
		{
			num = MainChar.listPotion.Length;
		}
		for (int i = 0; i < num; i++)
		{
			MainChar.listPotion[i].numTrade = 0;
		}
		if (Canvas.currentScreen == WindowInfoScr.gI() && WindowInfoScr.index[WindowInfoScr.focusTab] == 8)
		{
			switchToMe();
		}
	}

	public static mVector setListGemInbue(mVector listGem)
	{
		mVector mVector2 = new mVector();
		for (int i = 0; i < listGem.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)listGem.elementAt(i);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			if (gemByID.type == 0)
			{
				GemTemplate gemTemplate2 = new GemTemplate(gemTemplate.id);
				GemTemplate.copyData(gemTemplate, gemTemplate2);
				mVector2.addElement(gemTemplate2);
			}
		}
		return mVector2;
	}

	public void onImbue(short priceImbue, sbyte khoa)
	{
		WindowInfoScr.gI().prizeImbue = priceImbue;
		mVector mVector2 = new mVector();
		WindowInfoScr.khoaImbue = khoa;
		if (khoa == 0)
		{
			mVector2 = setListGemInbue(MainChar.gemItem);
		}
		else if (khoa == 1)
		{
			mVector2 = setListGemInbue(MainChar.gemItemKhoa);
		}
		else
		{
			int num = MainChar.gemItem.size();
			int num2 = MainChar.gemItemKhoa.size();
			for (int i = 0; i < num; i++)
			{
				GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(i);
				GemTemp gemByID = Res.getGemByID(gemTemplate.id);
				if (gemByID.type == 0)
				{
					GemTemplate gemTemplate2 = new GemTemplate(gemTemplate.id);
					GemTemplate.copyData(gemTemplate, gemTemplate2);
					mVector2.addElement(gemTemplate2);
				}
			}
			for (int j = 0; j < num2; j++)
			{
				GemTemplate gemTemplate3 = (GemTemplate)MainChar.gemItemKhoa.elementAt(j);
				bool flag = false;
				for (int k = 0; k < mVector2.size(); k++)
				{
					GemTemplate gemTemplate4 = (GemTemplate)mVector2.elementAt(k);
					if (gemTemplate4.id == gemTemplate3.id)
					{
						gemTemplate4.number += gemTemplate3.number;
						flag = true;
					}
				}
				if (!flag)
				{
					GemTemp gemByID2 = Res.getGemByID(gemTemplate3.id);
					if (gemByID2.type == 0)
					{
						GemTemplate gemTemplate5 = new GemTemplate(gemTemplate3.id);
						GemTemplate.copyData(gemTemplate3, gemTemplate5);
						mVector2.addElement(gemTemplate5);
					}
				}
			}
		}
		GemTemplate gemTemplate6 = null;
		for (int l = 0; l < mVector2.size(); l++)
		{
			gemTemplate6 = (GemTemplate)mVector2.elementAt(l);
			WindowInfoScr.gI().listTemp.addElement(gemTemplate6);
		}
		showWindow(0, isSell: false, new sbyte[1] { 21 });
		WindowInfoScr.gI().name = "Luyện đồ";
	}

	public void onKham(short price1, sbyte khoa)
	{
		WindowInfoScr.gI().prizeImbue = price1;
		mVector mVector2 = new mVector();
		WindowInfoScr.khoaKham = khoa;
		if (khoa == 0)
		{
			mVector2 = MainChar.gemItem;
		}
		else if (khoa == 1)
		{
			mVector2 = MainChar.gemItemKhoa;
		}
		else
		{
			int num = MainChar.gemItem.size();
			int num2 = MainChar.gemItemKhoa.size();
			for (int i = 0; i < num; i++)
			{
				GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(i);
				GemTemplate gemTemplate2 = new GemTemplate(gemTemplate.id);
				GemTemplate.copyData(gemTemplate, gemTemplate2);
				mVector2.addElement(gemTemplate2);
			}
			for (int j = 0; j < num2; j++)
			{
				GemTemplate gemTemplate3 = (GemTemplate)MainChar.gemItemKhoa.elementAt(j);
				bool flag = false;
				for (int k = 0; k < mVector2.size(); k++)
				{
					GemTemplate gemTemplate4 = (GemTemplate)mVector2.elementAt(k);
					if (gemTemplate4.id == gemTemplate3.id)
					{
						gemTemplate4.number += gemTemplate3.number;
						flag = true;
					}
				}
				if (!flag)
				{
					GemTemplate gemTemplate5 = new GemTemplate(gemTemplate3.id);
					GemTemplate.copyData(gemTemplate3, gemTemplate5);
					mVector2.addElement(gemTemplate5);
				}
			}
		}
		int num3 = mVector2.size();
		GemTemplate gemTemplate6 = null;
		for (int l = 0; l < num3; l++)
		{
			gemTemplate6 = (GemTemplate)mVector2.elementAt(l);
			WindowInfoScr.gI().listTemp.addElement(gemTemplate6);
		}
		showWindow(0, isSell: false, new sbyte[1] { 25 });
	}

	public void onEpDothu(short price, sbyte idColor, sbyte lv, short startIDNL, sbyte slNguyenLieu, sbyte magic, sbyte khoa)
	{
		WindowInfoScr.gI().listTemp.removeAllElements();
		WindowInfoScr.gI().prizeImbue = price;
		WindowInfoScr.idColor = idColor;
		WindowInfoScr.lvThu = lv;
		WindowInfoScr.slNLThu = slNguyenLieu;
		WindowInfoScr.magicAnimal = magic;
		mVector mVector2 = new mVector();
		WindowInfoScr.khoaDoThu = khoa;
		if (khoa == 0)
		{
			mVector2 = MainChar.gemItem;
		}
		else if (khoa == 1)
		{
			mVector2 = MainChar.gemItemKhoa;
		}
		else
		{
			int num = MainChar.gemItem.size();
			int num2 = MainChar.gemItemKhoa.size();
			for (int i = 0; i < num; i++)
			{
				GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(i);
				GemTemplate gemTemplate2 = new GemTemplate(gemTemplate.id);
				GemTemplate.copyData(gemTemplate, gemTemplate2);
				mVector2.addElement(gemTemplate2);
			}
			for (int j = 0; j < num2; j++)
			{
				GemTemplate gemTemplate3 = (GemTemplate)MainChar.gemItemKhoa.elementAt(j);
				bool flag = false;
				for (int k = 0; k < mVector2.size(); k++)
				{
					GemTemplate gemTemplate4 = (GemTemplate)mVector2.elementAt(k);
					if (gemTemplate4.id == gemTemplate3.id)
					{
						gemTemplate4.number += gemTemplate3.number;
						flag = true;
					}
				}
				if (!flag)
				{
					GemTemplate gemTemplate5 = new GemTemplate(gemTemplate3.id);
					GemTemplate.copyData(gemTemplate3, gemTemplate5);
					mVector2.addElement(gemTemplate5);
				}
			}
		}
		int num3 = mVector2.size();
		GemTemplate gemTemplate6 = null;
		for (int l = 0; l < num3; l++)
		{
			gemTemplate6 = (GemTemplate)mVector2.elementAt(l);
			if (gemTemplate6.id >= startIDNL && gemTemplate6.id <= startIDNL + 5)
			{
				WindowInfoScr.gI().listTemp.addElement(gemTemplate6);
			}
		}
		if (WindowInfoScr.gI().listTemp.size() == 0)
		{
			Canvas.startOKDlg("Không có nguyên liệu.");
			return;
		}
		showWindow(0, isSell: false, new sbyte[1] { 32 });
		WindowInfoScr.gI().name = "Đồ " + ((magic != 0) ? "vật" : "ma") + " " + lv;
		Canvas.endDlg();
	}

	public void onEpNgoc(short price)
	{
		WindowInfoScr.gI().prizeImbue = price;
		showWindow(0, isSell: false, new sbyte[1] { 26 });
		WindowInfoScr.gI().name = "Hợp thành";
		Canvas.endDlg();
	}

	public void onSpecialItem(Message msg)
	{
		MainChar.shopItem.removeAllElements();
		try
		{
			int num = msg.reader().readByte();
			for (int i = 0; i < num; i++)
			{
				GemTemplate gemTemplate = new GemTemplate();
				if (gemTemplate != null)
				{
					gemTemplate.rID = msg.reader().readShort();
					gemTemplate.id = msg.reader().readByte();
					gemTemplate.number = msg.reader().readShort();
					MainChar.shopItem.addElement(gemTemplate);
				}
			}
		}
		catch (Exception)
		{
			Debug.Log("LOI NHAN SPECIAL_ITEM");
		}
		WindowInfoScr.gI().setCurTab();
		MenuWindows.gI().setCurTab();
	}

	public void onGemItem(Message msg)
	{
		try
		{
			mVector mVector2 = new mVector();
			mVector2.removeAllElements();
			int num = msg.reader().readShort();
			for (int i = 0; i < num; i++)
			{
				GemTemplate gemTemplate = new GemTemplate();
				gemTemplate.rID = msg.reader().readShort();
				gemTemplate.id = msg.reader().readShort();
				gemTemplate.number = msg.reader().readShort();
				mVector2.addElement(gemTemplate);
			}
			sbyte b = 0;
			try
			{
				b = msg.reader().readByte();
			}
			catch (Exception)
			{
			}
			if (b == 0)
			{
				MainChar.gemItem = mVector2;
			}
			else
			{
				MainChar.gemItemKhoa = mVector2;
			}
			if (Canvas.currentScreen == WindowInfoScr.gI())
			{
				if (WindowInfoScr.index[WindowInfoScr.focusTab] == 26)
				{
					WindowInfoScr.gI().setListImbue(isEp: true, 1, b);
				}
				if (WindowInfoScr.index[WindowInfoScr.focusTab] == 0)
				{
					PauseMenu.gI().showMe(0);
				}
			}
			if (Canvas.currentScreen == MenuWindows.gI() && MenuWindows.gI().focusTabChinh == 2)
			{
				MenuWindows.gI().setCurTab();
			}
		}
		catch (Exception)
		{
		}
	}

	public void onAddItemImbue(short id)
	{
		mainChar.itemImbue = null;
		int num = Char.inventory.size();
		for (int i = 0; i < num; i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			if (itemInInventory != null)
			{
				ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				if (item != null && item.id == id)
				{
					mainChar.itemImbue = itemInInventory;
					break;
				}
			}
		}
	}

	public void onImbueOK(string info)
	{
		Canvas.startOKDlg(info, isIcon: false);
		WindowInfoScr.gI().resetImbue();
	}

	public void onActorDie(Message msg)
	{
		int num = msg.reader().readShort();
		int num2 = msg.reader().readByte();
		int num3 = actors.size();
		for (int i = 0; i < num3; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor == null || actor.ID != num)
			{
				continue;
			}
			if (num2 == Actor.CAT_MONSTER)
			{
				int num4 = 0;
				int num5 = 0;
				num4 = (actor.x - 5) * 2;
				num5 = (actor.y - 5) * 2;
				while (num4 > 10 || num5 > 10 || num4 < -10 || num5 < -10)
				{
					num4 >>= 1;
					num5 >>= 1;
				}
				((Monster)actor).startDeadFly(num4, num5);
				actor.die = true;
			}
			else if (num2 == Actor.CAT_PLAYER)
			{
				actor.actorDie();
				if (actor.ID == mainChar.ID && BangAuto.isAutoComeHome && autoFight)
				{
					Canvas.currentDialog = null;
					doFire(0, 0);
				}
			}
			break;
		}
	}

	public void onBuffAttack(Message m)
	{
		try
		{
			int num = m.reader().readShort();
			int num2 = m.reader().readByte();
			int num3 = m.reader().readByte();
			int num4 = m.reader().readShort();
			int num5 = m.reader().readByte();
			int num6 = m.reader().readByte();
			int num7 = -1;
			try
			{
				num7 = m.reader().readByte();
			}
			catch (Exception)
			{
			}
			int num8 = actors.size();
			for (int i = 0; i < num8; i++)
			{
				Actor actor = (Actor)actors.elementAt(i);
				if (actor == null || actor.ID != num)
				{
					continue;
				}
				switch (num6)
				{
				case -1:
					startFlyText("-" + num4, 1, actor.x, actor.y - 40, 0, -1);
					if (num2 == Actor.CAT_MONSTER)
					{
						((Monster)actor).setHp(num4);
						if (((Monster)actor).hp <= 0)
						{
							((Monster)actor).wantDestroy = true;
						}
					}
					else
					{
						((Char)actor).hp -= num4;
						if (((Char)actor).hp <= 0)
						{
							((Char)actor).state = 3;
						}
					}
					break;
				case 0:
					break;
				case 1:
					break;
				case 2:
					if (num5 == 7 && num4 > 0)
					{
						startFlyText("-" + num4, 3, actor.x, actor.y - 40, 0, -1);
						((Char)actor).mp -= num4;
						if (((Char)actor).mp <= 0)
						{
							((Char)actor).mp = 0;
						}
					}
					break;
				case 3:
					if (num5 == 4)
					{
						actor.beStune = true;
						actor.timeBeStune = mSystem.currentTimeMillis() + ((num7 <= 0) ? 3000 : (num7 * 1000));
						CharBuff charBuff2 = new CharBuff(actor.x, actor.y, 19);
						charBuff2.setTimeLive((num7 <= 0) ? 3 : num7);
						actor.addBuff(charBuff2);
					}
					break;
				case 4:
					if (num5 == 4)
					{
						CharBuff charBuff = new CharBuff(actor.x, actor.y, 22);
						charBuff.setTimeLive((num7 <= 0) ? 36 : num7);
						actor.addBuff(charBuff);
						actor.timeOutPoinson = mSystem.currentTimeMillis();
						actor.poinson = (short)num4;
						actor.tDelay = (short)num3;
					}
					break;
				}
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public void onListShopOfNPC(sbyte[] idShop)
	{
		Canvas.currentDialog = null;
		mVector mVector2 = new mVector();
		for (int i = 0; i < 3; i++)
		{
			int ii = i;
			Command command = new Command("Gian hàng " + (i + 1));
			ActionPerform action = delegate
			{
				doActionShop(ii, idShop[idShop.Length - 1], idShop[idShop.Length - 2]);
			};
			command.action = action;
			mVector2.addElement(command);
		}
		Canvas.menu.startAt(mVector2, 3);
	}

	public void doActionShop(int shopID, int type, int ncpType)
	{
		switch (type)
		{
		case 0:
			WindowInfoScr.gI().idSeller = ncpType;
			WindowInfoScr.gI().shopIdSell = shopID;
			Canvas.startWaitDlg();
			gameService.requestGetListItem(ncpType, shopID, mainChar.ID);
			break;
		case 1:
			gameService.requestGetListUser(ncpType, shopID);
			Canvas.startWaitDlg();
			break;
		}
	}

	public void onFriendList(Message msg, int type, string title)
	{
		mVector mVector2 = new mVector();
		short num = msg.reader().readShort();
		for (int i = 0; i < num; i++)
		{
			Char @char = new Char();
			@char.name = msg.reader().readUTF();
			@char.currentHead = msg.reader().readByte();
			@char.dir = 0;
			@char.level = msg.reader().readByte();
			@char.weapon_frame = 0;
			sbyte b = msg.reader().readByte();
			mVector mVector3 = new mVector();
			for (int j = 0; j < b; j++)
			{
				ItemInInventory itemInInventory = new ItemInInventory();
				@char.clazz = (itemInInventory.charClazz = msg.reader().readByte());
				itemInInventory.idTemplate = msg.reader().readShort();
				itemInInventory.level = msg.reader().readByte();
				itemInInventory.plusTemplate = msg.reader().readByte();
				mVector3.addElement(itemInInventory);
			}
			@char.idClan = msg.reader().readShort();
			@char.isMaster = msg.reader().readByte();
			if (type == 3 || type == 4 || type == 7 || type == 8)
			{
				@char.charXu = msg.reader().readLong();
				@char.luong = msg.reader().readInt();
				@char.nationID = msg.reader().readByte();
				if (type == 7)
				{
					@char.congTrang = msg.reader().readInt();
					@char.lienTram = msg.reader().readInt();
				}
			}
			@char.setWearingInfo(mVector3);
			mVector2.addElement(@char);
		}
		if (mVector2.size() > 0)
		{
			switch (type)
			{
			case 0:
				ListScr.gI().freindList = mVector2;
				break;
			case 1:
			case 3:
			case 4:
			case 6:
			case 7:
			case 8:
				ListScr.gI().setInfo(mVector2, type, title);
				ListScr.gI().switchToMe();
				Canvas.endDlg();
				break;
			}
		}
	}

	public void onListInfoDepositeItem(Message msg)
	{
		try
		{
			mVector mVector2 = new mVector();
			int num = msg.reader().readByte();
			int npc = msg.reader().readByte();
			int shopID = msg.reader().readByte();
			switch (num)
			{
			case 0:
			{
				int num4 = msg.reader().readByte();
				for (int l = 0; l < num4; l++)
				{
					string caption = msg.reader().readUTF();
					short charID = msg.reader().readShort();
					if (charID != mainChar.ID)
					{
						Command command = new Command(caption);
						ActionPerform action = delegate
						{
							gameService.requestGetListItem(npc, shopID, charID);
							Canvas.startWaitDlg();
						};
						command.action = action;
						mVector2.addElement(command);
					}
				}
				Canvas.currentDialog = null;
				if (mVector2.size() > 0)
				{
					Canvas.menu.startAt(mVector2, 3);
				}
				break;
			}
			case 1:
			{
				Canvas.currentDialog = null;
				WindowInfoScr.gI().sellItem.removeAllElements();
				int num2 = msg.reader().readByte();
				short num3 = msg.reader().readShort();
				for (int i = 0; i < num2; i++)
				{
					ItemInInventory itemInInventory = new ItemInInventory();
					itemInInventory.clazz = (itemInInventory.charClazz = msg.reader().readByte());
					itemInInventory.itemID = msg.reader().readShort();
					itemInInventory.idTemplate = msg.reader().readShort();
					itemInInventory.plusTemplate = msg.reader().readByte();
					itemInInventory.prize = msg.reader().readInt();
					itemInInventory.level = msg.reader().readByte();
					itemInInventory.durable = msg.reader().readShort();
					itemInInventory.numKham = msg.reader().readByte();
					itemInInventory.totalKham = msg.reader().readByte();
					itemInInventory.allAttribute.removeAllElements();
					sbyte b = msg.reader().readByte();
					for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
					{
						InfoAttributeItem o = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
						itemInInventory.allAttribute.addElement(o);
					}
					itemInInventory.colorName = msg.reader().readByte();
					itemInInventory.heItem = msg.reader().readByte();
					itemInInventory.beKicked = msg.reader().readByte();
					itemInInventory.hangItem = msg.reader().readByte();
					itemInInventory.magic_physic = msg.reader().readByte();
					itemInInventory.islock = msg.reader().readByte();
					itemInInventory.nameCharSeal = msg.reader().readUTF();
					if (mainChar.ID == num3)
					{
						for (int j = 0; j < Char.inventory.size(); j++)
						{
							ItemInInventory itemInInventory2 = (ItemInInventory)Char.inventory.elementAt(j);
							if (itemInInventory2.itemID == itemInInventory.itemID)
							{
								itemInInventory2.prize = itemInInventory.prize;
								itemInInventory2.isSelling = true;
								WindowInfoScr.gI().sellItem.addElement(itemInInventory2);
							}
						}
					}
					else
					{
						WindowInfoScr.gI().sellItem.addElement(itemInInventory);
					}
				}
				sbyte b3 = msg.reader().readByte();
				for (int k = 0; k < b3; k++)
				{
					RealID realID = new RealID();
					realID.realID = msg.reader().readShort();
					realID.ID = msg.reader().readShort();
					realID.price = msg.reader().readInt();
					WindowInfoScr.gI().sellItem.addElement(realID);
				}
				WindowInfoScr.gI().idSeller = npc;
				WindowInfoScr.gI().shopIdSell = shopID;
				if (mainChar.ID == num3)
				{
					showWindow(0, isSell: true, new sbyte[1] { 23 });
				}
				else if (WindowInfoScr.gI().sellItem.size() > 0)
				{
					WindowInfoScr.gI().idCharSell = num3;
					showWindow(0, isSell: true, new sbyte[1] { 24 });
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			Out.LogError(ex.StackTrace + " loi tai onListInfoDepositeItem");
		}
	}

	public void showWindow(int focus, bool isSell, sbyte[] index)
	{
		WindowInfoScr.gI().setInfo(focus, isSell, index);
		WindowInfoScr.gI().switchToMe();
	}

	public void onUserSellItem(Message msg)
	{
		try
		{
			bool flag = msg.reader().readBoolean();
			short num = msg.reader().readShort();
			int num2 = 0;
			if (flag)
			{
				num2 = msg.reader().readInt();
			}
			sbyte b = msg.reader().readByte();
			if (b == 0)
			{
				ItemInInventory itemByID = getItemByID(Char.inventory, num);
				if (itemByID != null)
				{
					itemByID.isSelling = flag;
					if (flag)
					{
						itemByID.prize = num2;
						WindowInfoScr.gI().sellItem.addElement(itemByID);
						Canvas.startOKDlg("Đã bỏ vào gian hàng.");
					}
					else
					{
						itemByID.prize = 0;
						WindowInfoScr.gI().sellItem.removeElement(itemByID);
						Canvas.startOKDlg("Đã lấy vật phẩm khỏi gian hàng.");
					}
				}
				return;
			}
			short iD = msg.reader().readShort();
			if (flag)
			{
				GemTemplate gemByRealID = GemTemplate.getGemByRealID(num);
				if (gemByRealID != null)
				{
					gemByRealID.number--;
					if (gemByRealID.number <= 0)
					{
						MainChar.gemItem.removeElement(gemByRealID);
					}
					RealID realID = new RealID(gemByRealID.rID);
					realID.ID = iD;
					realID.price = num2;
					WindowInfoScr.gI().sellItem.addElement(realID);
				}
			}
			else
			{
				int num3 = WindowInfoScr.gI().sellItem.size();
				for (int i = 0; i < num3; i++)
				{
					RealID realID2 = (RealID)WindowInfoScr.gI().sellItem.elementAt(i);
					if (realID2 != null && realID2.realID == num)
					{
						WindowInfoScr.gI().sellItem.removeElement(realID2);
						GemTemplate gemByID = GemTemplate.getGemByID(realID2.ID);
						if (gemByID != null)
						{
							gemByID.number++;
							break;
						}
						GemTemplate gemTemplate = new GemTemplate();
						gemTemplate.rID = realID2.realID;
						gemTemplate.id = realID2.ID;
						gemTemplate.number = 1;
						MainChar.gemItem.addElement(gemTemplate);
						break;
					}
				}
			}
			Canvas.endDlg();
		}
		catch (Exception)
		{
			Out.LogError("LOI HAM ON_USER_SELL_ITEM");
		}
	}

	public void onBuyItemOfUser(short itemID, short charID, sbyte type)
	{
		if (mainChar.ID == charID)
		{
			Canvas.startOKDlg("Món đồ đã ở trong hành trang.");
		}
		int num = WindowInfoScr.gI().sellItem.size();
		for (int i = 0; i < num; i++)
		{
			if (type == 0 && WindowInfoScr.gI().sellItem.elementAt(i) is ItemInInventory)
			{
				ItemInInventory itemInInventory = (ItemInInventory)WindowInfoScr.gI().sellItem.elementAt(i);
				if (itemInInventory != null && itemInInventory.itemID == itemID)
				{
					WindowInfoScr.gI().sellItem.removeElementAt(i);
					if (WindowInfoScr.gI() == Canvas.currentScreen && WindowInfoScr.index[WindowInfoScr.focusTab] == 24)
					{
						WindowInfoScr.gI().setInfo(WindowInfoScr.gI().getListBuyItem());
					}
					break;
				}
			}
			else
			{
				if (!(WindowInfoScr.gI().sellItem.elementAt(i) is RealID))
				{
					continue;
				}
				RealID realID = (RealID)WindowInfoScr.gI().sellItem.elementAt(i);
				if (realID != null && realID.realID == itemID)
				{
					WindowInfoScr.gI().sellItem.removeElementAt(i);
					if (WindowInfoScr.gI() == Canvas.currentScreen && WindowInfoScr.index[WindowInfoScr.focusTab] == 24)
					{
						WindowInfoScr.gI().setInfo(WindowInfoScr.gI().getListBuyItem());
					}
					break;
				}
			}
		}
	}

	public void onInfoFriend(Message msg)
	{
		try
		{
			int num = msg.reader().readByte();
			string text = msg.reader().readUTF();
			int charID = msg.reader().readShort();
			switch (num)
			{
			case 0:
			{
				ActionPerform yesAction = delegate
				{
					gameService.sendInfoAddFriend(charID, 1);
					Canvas.currentDialog = null;
				};
				ActionPerform noAction = delegate
				{
					gameService.sendInfoAddFriend(charID, -1);
					Canvas.currentDialog = null;
				};
				Canvas.startYesNoDlg(text + " muốn kết bạn với bạn", yesAction, noAction);
				break;
			}
			case 1:
				break;
			case -1:
				break;
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	public void onSMSStruct(Message msg)
	{
		try
		{
			int num = msg.reader().readByte();
			for (int i = 0; i < num; i++)
			{
				string text = msg.reader().readUTF();
				string o = msg.reader().readUTF();
				string o2 = msg.reader().readUTF();
				if (Main.isPC)
				{
					if (!text.Contains("sms"))
					{
						decriptNap.addElement(text);
					}
				}
				else
				{
					decriptNap.addElement(text);
				}
				syntaxNap.addElement(o);
				centerNap.addElement(o2);
			}
		}
		catch (IOException)
		{
		}
	}

	public static void loadConfig(int type)
	{
		switch (type)
		{
		case 0:
			paintCay = 0;
			paintChar = 1;
			if (Tilemap.trees != null)
			{
				int num2 = Tilemap.trees.size();
				for (int j = 0; j < num2; j++)
				{
					((Tree)Tilemap.trees.elementAt(j))?.removeImage();
				}
			}
			break;
		case 1:
		case 2:
			paintCay = 1;
			paintChar = 1;
			break;
		case 3:
			paintCay = 0;
			paintChar = 0;
			if (Tilemap.trees != null)
			{
				int num = Tilemap.trees.size();
				for (int i = 0; i < num; i++)
				{
					((Tree)Tilemap.trees.elementAt(i))?.removeImage();
				}
			}
			break;
		}
	}

	public void showConfig()
	{
		mVector mVector2 = new mVector();
		string[] array = new string[4] { "Thấp", "Vừa", "Cao", "Rất thấp" };
		for (int i = 0; i < 4; i++)
		{
			int ii = i;
			Command command = new Command(array[i]);
			ActionPerform action = delegate
			{
				gameService.setConfig(ii);
			};
			command.action = action;
			mVector2.addElement(command);
		}
		Canvas.menu.startAt(mVector2, 3);
	}

	public void onRegClan(short[] arrayIndex)
	{
		mVector mVector2 = new mVector();
		int num = arrayIndex.Length;
		for (int i = 0; i < num; i++)
		{
			int ii = i;
			Command command = new Command();
			ActionPerform action = delegate
			{
				ActionPerform ok = delegate
				{
					if (!Canvas.inputDlg.tfInput.getText().Equals(string.Empty))
					{
						Canvas.startWaitDlg();
						gameService.chooseIconClan(arrayIndex[ii], Canvas.inputDlg.tfInput.getText());
						PaintPopup.gI().right.perform();
					}
				};
				Canvas.inputDlg.setInfo("Tên bang hội của bạn", ok, TField.INPUT_TYPE_ANY, 25, isMaxW: true);
				Canvas.inputDlg.show();
			};
			ActionPaintCmd actionPaint = delegate(MyGraphics g, int x, int y)
			{
				GameData.paintIcon(g, (short)(arrayIndex[ii] + 1000), x, y);
			};
			command.action = action;
			command.actionPaint = actionPaint;
			mVector2.addElement(command);
		}
		PaintPopup.gI().setPos(20, 20, Canvas.w - 40, Canvas.h - 40 - MyScreen.deltaY, (Canvas.w - 40) / 20);
		PaintPopup.gI().setInfo(mVector2, "ICON");
		PaintPopup.gI().switchToMe();
	}

	public void showClanInfo(ClanInfo clan)
	{
		ViewInfoScr.gI().setInfo(clan);
		ViewInfoScr.gI().switchToMe();
		Canvas.endDlg();
	}

	public void onViewCharInfo(Char ch)
	{
		WindowInfoScr.gI().setInfo(0, isSell: false, new sbyte[1] { 1 });
		WindowInfoScr.charWearing = ch;
		WindowInfoScr.gI().switchToMe();
		WindowInfoScr.gI().name = "Trang bị";
		Canvas.endDlg();
	}

	public void setNPC_server_limit(string name0, short ID0, short idImg0, short x0, short y0, short wimg0, short himg0, sbyte nFrame0, sbyte typeLimit)
	{
		if (typeLimit != 1)
		{
			return;
		}
		int num = npc_Limit.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)npc_Limit.elementAt(i);
			if (actor == null || actor.catagory != 2)
			{
				continue;
			}
			NPC nPC = (NPC)actor;
			if (nPC.npcType == 1)
			{
				Npc_Server npc_Server = (Npc_Server)nPC;
				if (npc_Server.ID == ID0)
				{
					npc_Server.name = name0;
					npc_Server.type = (npc_Server.ID = ID0);
					npc_Server.idImg = idImg0;
					npc_Server.x = x0;
					npc_Server.y = y0;
					npc_Server.width = wimg0;
					npc_Server.height = himg0;
					npc_Server.nFrame = nFrame0;
					nPC.typeLimit = typeLimit;
					return;
				}
			}
		}
		Npc_Server npc_Server2 = new Npc_Server();
		npc_Server2.name = name0;
		npc_Server2.type = (npc_Server2.ID = ID0);
		npc_Server2.idImg = idImg0;
		npc_Server2.x = x0;
		npc_Server2.y = y0;
		npc_Server2.width = wimg0;
		npc_Server2.height = himg0;
		npc_Server2.nFrame = nFrame0;
		npc_Server2.typeLimit = typeLimit;
		npc_Limit.addElement(npc_Server2);
	}

	public void setNPC_server(string name0, short ID0, short idImg0, short x0, short y0, short wimg0, short himg0, sbyte nFrame0, sbyte typeLimit)
	{
		setNPC_server_limit(name0, ID0, idImg0, x0, y0, wimg0, himg0, nFrame0, typeLimit);
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor == null || actor.catagory != 2)
			{
				continue;
			}
			NPC nPC = (NPC)actor;
			if (nPC.npcType == 1)
			{
				Npc_Server npc_Server = (Npc_Server)nPC;
				if (npc_Server.ID == ID0)
				{
					npc_Server.name = name0;
					npc_Server.type = (npc_Server.ID = ID0);
					npc_Server.idImg = idImg0;
					npc_Server.x = x0;
					npc_Server.y = y0;
					npc_Server.width = wimg0;
					npc_Server.height = himg0;
					npc_Server.nFrame = nFrame0;
					npc_Server.typeLimit = typeLimit;
					return;
				}
			}
		}
		Npc_Server npc_Server2 = new Npc_Server();
		npc_Server2.name = name0;
		npc_Server2.type = (npc_Server2.ID = ID0);
		npc_Server2.idImg = idImg0;
		npc_Server2.x = x0;
		npc_Server2.y = y0;
		npc_Server2.width = wimg0;
		npc_Server2.height = himg0;
		npc_Server2.nFrame = nFrame0;
		npc_Server2.typeLimit = typeLimit;
		actors.addElement(npc_Server2);
	}

	public void setMyFarm(int idFarm, int id, int x, int y, string info, string name, int idImgTree, int timeLive, bool isBuyOk, sbyte addy, sbyte colorString)
	{
		int num = actors.size();
		for (int i = 0; i < num; i++)
		{
			Actor actor = (Actor)actors.elementAt(i);
			if (actor != null && actor.catagory == Actor.CAT_MY_GROUND)
			{
				Ground ground = (Ground)actor;
				if (ground.ID == idFarm)
				{
					ground.setInfo(idFarm, id, x, y, info, name, idImgTree, timeLive, isBuyOk, addy, colorString);
					return;
				}
			}
		}
		actors.addElement(new Ground(idFarm, id, x, y, info, name, idImgTree, timeLive, isBuyOk, addy, colorString));
	}

	public static Actor CreateActor(sbyte catagory, short type, short id, short x, short y, sbyte isnewmonster, sbyte isThanthu)
	{
		Actor actor = null;
		switch (catagory)
		{
		case 0:
			if (isThanthu > -1)
			{
				actor = new ThanThu();
				actor.setIdThanThu(isThanthu);
			}
			else
			{
				actor = new Char();
			}
			break;
		case 1:
			switch (type)
			{
			case 91:
			case 92:
				actor = new Boss_Snake();
				break;
			case 93:
				actor = new Boss_Eyes();
				break;
			case 94:
				actor = new Boss_Xuong();
				break;
			case 46:
				actor = new Boss_TuongQuan();
				break;
			case 43:
				actor = new TruTranThanh(0);
				break;
			case 36:
				actor = new TruTranThanh(1);
				break;
			case 37:
				actor = new TruTranThanh(2);
				break;
			case 38:
				actor = new BossTL();
				break;
			case 39:
				actor = new BossThanLan();
				break;
			case 82:
				actor = new Boss_Eagle();
				break;
			case 83:
				actor = (congThanh = new CongThanh());
				break;
			case 84:
				actor = new CuongThi();
				break;
			case 113:
				actor = new MonsterNew(113);
				break;
			case 115:
				actor = new MonsterNew(115);
				break;
			case 116:
				actor = new MonsterNew(116);
				break;
			case 117:
				actor = new MonsterNew(117);
				break;
			case 95:
			case 96:
			case 97:
			case 98:
			case 99:
			case 100:
			case 101:
			case 102:
			case 103:
			case 104:
			case 105:
			case 106:
			case 107:
			case 108:
			case 109:
			case 110:
			case 111:
			case 112:
				actor = new MonsterNew(type);
				break;
			default:
				actor = ((isnewmonster != 1) ? new Monster() : new MonsterNew(type));
				break;
			}
			break;
		case 3:
			actor = new DropItem();
			break;
		case 4:
			actor = new DropPotion();
			break;
		case 6:
		case 7:
			actor = new DropGemItem();
			break;
		case 14:
			actor = new ItemQuest();
			break;
		}
		actor.setNewMonster(isnewmonster);
		if (type >= 85 && type <= 89 && catagory == 1)
		{
			((Monster)actor).isMineralC = true;
		}
		actor.x = x;
		actor.y = y;
		actor.catagory = catagory;
		actor.ID = id;
		actor.xFirst = x;
		actor.yFirst = y;
		actor.setType(type);
		return actor;
	}

	public void onCapCha(sbyte[] arrayImg)
	{
		Image img = Image.createImage(arrayImg, 0, arrayImg.Length);
		int w = img.getWidth() + 35;
		int num = img.getHeight() + 60;
		TField tfText = new TField(5, num - 26, w - 10, 20);
		tfText.isFocus = true;
		Command command = new Command("OK");
		ActionPerform action = delegate
		{
			gameService.doCapCha(tfText.getText());
			Canvas.gameScr.switchToMe();
		};
		command.action = action;
		PageScr.gI().setInfo(Canvas.hw - w / 2, Canvas.hh - num / 2 - MyScreen.deltaY, w, num, "NHẬP CHỮ", null);
		PageScr.gI().left = command;
		PageScr.gI().right = tfText.cmdClear;
		Layer layer = new Layer();
		ActionPerform isUpdate = delegate
		{
			tfText.update();
		};
		ActionPaintCmd isPaint = delegate(MyGraphics g, int x, int y)
		{
			g.drawImage(img, w / 2, 30, MyGraphics.TOP | MyGraphics.HCENTER);
			tfText.paint(g);
		};
		ActionKey isKeyCode = delegate(int keyCode)
		{
			tfText.keyPressed(keyCode);
		};
		layer.isUpdate = isUpdate;
		layer.isPaint = isPaint;
		layer.isKeyCode = isKeyCode;
		PageScr.gI().layer = layer;
		PageScr.gI().switchToMe();
	}

	private void updateminiMap()
	{
		cmtoXMini = mainChar.x / 16;
		cmtoYmini = mainChar.y / 16;
		int num = 60;
		if (wMiniMap < 60)
		{
			num = wMiniMap;
		}
		if (cmtoXMini > Tilemap.w - num / 2)
		{
			cmtoXMini = Tilemap.w - num;
		}
		else if (cmtoXMini < wMiniMap / 2)
		{
			cmtoXMini = 0;
		}
		else
		{
			cmtoXMini -= wMiniMap / 2;
		}
		if (cmtoYmini < hMiniMap / 2)
		{
			cmtoYmini = 0;
		}
		else
		{
			cmtoYmini -= hMiniMap / 2;
		}
		if (cmtoYmini > Tilemap.h - hMiniMap)
		{
			cmtoYmini = Tilemap.h - hMiniMap;
		}
	}

	public void isOff()
	{
		if (isBatMiniMap)
		{
			if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() * 2 - 30, Res.imgChat.getWidth() * 2 + 2, 40, 30))
			{
				isBatMiniMap = !isBatMiniMap;
			}
			if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() * 2 - 30, Res.imgChat.getWidth() / 2 + 2, 40, 30))
			{
				MenuSelectItem.gI().switchToMe();
			}
			return;
		}
		int num = 0;
		int num2 = 0;
		if (Tilemap.imgMap != null)
		{
			num = Tilemap.imgMap.getWidth();
			num2 = Tilemap.imgMap.getHeight();
		}
		if (xacDinhToaDo(Canvas.px, Canvas.py, isBatMiniMap ? (Canvas.w - Res.imgChat.getWidth() - 20 - num) : (Canvas.w - Res.imgChat.getWidth() - 10), isBatMiniMap ? (num2 / 2) : (Res.imgChat.getWidth() / 2), 40, 30) && Canvas.isPointerClick)
		{
			isBatMiniMap = !isBatMiniMap;
			Canvas.isPointerClick = false;
		}
		if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() * 2 - 20, Res.imgChat.getWidth() / 2, 40, 30) && Canvas.isPointerClick)
		{
			MenuSelectItem.gI().switchToMe();
			Canvas.isPointerClick = false;
		}
	}

	public void updateTouchMHP()
	{
		if (hideGUI != 0)
		{
			return;
		}
		if (Canvas.isPointerMHP(Canvas.w - 141, Canvas.h - Canvas.hh / 2 - 82, 70, 70))
		{
			if (Canvas.isPointerClick1)
			{
				timePutKeyMP = 3;
				Canvas.keyPressed[7] = true;
				Canvas.isPointerClick1 = false;
			}
		}
		else if (Canvas.isPointerMHP(Canvas.w - 90, Canvas.h - Canvas.hh / 2 - 100, 70, 70) && Canvas.isPointerClick1)
		{
			timePutKeyHP = 3;
			Canvas.keyPressed[9] = true;
			Canvas.isPointerClick1 = false;
		}
	}

	private void updatePoint()
	{
		if (Canvas.currentDialog != null || Canvas.menu.showMenu)
		{
			return;
		}
		int num = 0;
		if ((listMSGServer.size() > 0 && msgWorld.size() == 0) || (listMSGServer.size() == 0 && msgWorld.size() > 0))
		{
			num = 20;
		}
		else if (listMSGServer.size() > 0 && msgWorld.size() > 0)
		{
			num = 40;
		}
		if (!Canvas.isPointer(0, 0, Canvas.w, Canvas.h))
		{
			return;
		}
		if (Canvas.isPointerClick)
		{
			if (isBatMiniMap)
			{
				if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() * 2 - 30, Res.imgChat.getWidth() * 2 + 2 + num, 40, 30))
				{
					isBatMiniMap = !isBatMiniMap;
					Canvas.isPointerClick = false;
					return;
				}
				if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() * 2 - 30, Res.imgChat.getWidth() / 2 + 2 + num, 40, 30))
				{
					MenuSelectItem.gI().switchToMe();
					Canvas.isPointerClick = false;
					return;
				}
			}
			else
			{
				if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() - 10, Res.imgChat.getWidth() / 2 + num, 40, 30))
				{
					isBatMiniMap = !isBatMiniMap;
					Canvas.isPointerClick = false;
					return;
				}
				if (xacDinhToaDo(Canvas.px, Canvas.py, Canvas.w - Res.imgChat.getWidth() * 2 - 20, Res.imgChat.getWidth() / 2 + num, 40, 30))
				{
					MenuSelectItem.gI().switchToMe();
					Canvas.isPointerClick = false;
					return;
				}
			}
		}
		if (Canvas.isPointerDown && hideGUI == 0)
		{
			Canvas.isPointerClick = false;
			pointer(Canvas.px, Canvas.py);
		}
		else if (Canvas.isPointerClick)
		{
			isNhanPhim = false;
			if (hideGUI == 0)
			{
				if (isTouchPre(xChangeTab, yChangeTab, Canvas.px, Canvas.py, Res.imgSwapQuickSlot.getWidth(), Res.imgSwapQuickSlot.getHeight()))
				{
					if (indexTabSlot == 0)
					{
						indexTabSlot = 1;
					}
					else
					{
						indexTabSlot = 0;
					}
					xSlot = Res.wKhung;
				}
				if (isTouchPre(xChangeFocus, yChangeFocus, Canvas.px, Canvas.py, Res.imgFocusActor.getWidth(), Res.imgFocusActor.getHeight()) && Canvas.isPointerClick)
				{
					Canvas.isPointerClick = false;
					changeToNextFocusActor(isBack: false);
				}
				if (isTouchPre(xChangeClothes, yChangeClothes, Canvas.px, Canvas.py, Res.imgSwapClothes.getWidth(), Res.imgSwapClothes.getHeight()) && Canvas.isPointerClick)
				{
					Canvas.isPointerClick = false;
					GameService.gI().setConfig(6);
					Canvas.endDlg();
				}
				if (isTouchPre(xSelectFc, ySelectFc, Canvas.px, Canvas.py, Res.imgSelectFc.getWidth(), Res.imgSelectFc.getHeight()) && Canvas.isPointerClick)
				{
					Canvas.isPointerClick = false;
					doParty();
				}
				if (isTouchPre(xChatTouch, yChatTouch, Canvas.px, Canvas.py, Res.imgChatTouch.getWidth(), Res.imgChatTouch.getHeight()))
				{
					Out.println("chat mode ");
					if (Canvas.isPointerClick && Main.isPC)
					{
						Canvas.gameScr.chatMode = true;
						Canvas.endDlg();
						ActionPerform ok = delegate
						{
							doChatFromMe(Canvas.inputDlg.tfInput.getText());
							Canvas.inputDlg.tfInput.setText(string.Empty);
						};
						Canvas.inputDlg.setInfo("Nội dung Chat", ok, TField.INPUT_TYPE_ANY, 100, isMaxW: false);
						Canvas.inputDlg.show();
					}
				}
			}
			if (Canvas.isPointer(xHp + 10, yHp + 10, 50, 50) && !Main.isPC)
			{
				resetFcBt();
				isPaintFcBt[7] = true;
				Canvas.keyPressed[7] = true;
				Canvas.keyHold[1] = (Canvas.keyHold[3] = false);
				Canvas.keyHold[9] = (Canvas.keyHold[5] = false);
				Canvas.isPointerClick = false;
			}
			if (Canvas.isPointer(xFire + 20, yFire + 20, 80, 80) && !Main.isPC)
			{
				resetFcBt();
				isPaintFcBt[3] = true;
				Canvas.keyPressed[5] = true;
				Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
				Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
				Canvas.keyHold[1] = (Canvas.keyHold[8] = false);
				Canvas.keyHold[7] = (Canvas.keyHold[9] = false);
				Canvas.isPointerClick = false;
			}
			else if (Canvas.isPointer(xOne + 10, yOne + 10, 50, 50) && !Main.isPC)
			{
				resetFcBt();
				isPaintFcBt[4] = true;
				Canvas.keyPressed[1] = true;
				Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
				Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
				Canvas.keyHold[8] = (Canvas.keyHold[5] = false);
				Canvas.keyHold[7] = (Canvas.keyHold[9] = false);
				Canvas.isPointerClick = false;
				Out.println("11111111111111 fire");
			}
			else if (Canvas.isPointer(xThree + 10, yThree + 10, 50, 50) && !Main.isPC)
			{
				resetFcBt();
				isPaintFcBt[5] = true;
				Canvas.keyPressed[3] = true;
				Canvas.keyHold[2] = (Canvas.keyHold[8] = false);
				Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
				Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
				Canvas.keyHold[7] = (Canvas.keyHold[9] = false);
				Canvas.isPointerClick = false;
				Out.println("3333333333333333 fire");
			}
			else if (Canvas.isPointer(xMp + 10, yMp + 10, 50, 50) && !Main.isPC)
			{
				resetFcBt();
				isPaintFcBt[8] = true;
				Canvas.keyPressed[9] = true;
				Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
				Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
				Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
				Canvas.keyHold[7] = (Canvas.keyHold[8] = false);
				Canvas.isPointerClick = false;
			}
			if (Canvas.isPointer(0, 0, 60, 50) && mainChar.hp > 0 && !Canvas.menu.showMenu)
			{
				MenuWindows.gI().switchToMe();
				mainChar.posTransRoad = null;
				Canvas.isPointerClick = (Canvas.isPointerDown = false);
				Canvas.clearKeyPressed();
			}
			if (MessageScr.nMSG > 0 && Canvas.isPointer(0, imgInfo.getHeight() + 3, 30, 30))
			{
				MessageScr.gI().switchToMe();
			}
			Canvas.clearKeyHold();
			btnFocus = 0;
		}
		if (!canTouchScreen(Canvas.px, Canvas.py) || !Canvas.isPointerClick || !Main.canvas.canPutKey())
		{
			return;
		}
		int num2 = cmx + Canvas.px;
		int num3 = cmy + Canvas.py;
		if (focusedActor != null)
		{
			if (focusedActor.catagory != Actor.CAT_MY_GROUND)
			{
				int num4 = actors.size();
				for (int i = 0; i < num4; i++)
				{
					Actor actor = (Actor)actors.elementAt(i);
					if (Util.abs(actor.x - num2) >= 20 || Util.abs(actor.y - 20 - num3) >= 40)
					{
						continue;
					}
					Canvas.isPointerClick = false;
					if (focusedActor.ID == actor.ID)
					{
						if (actor is Char && (mainChar.pk <= 0 || map / 100 == 3))
						{
							if (((Char)focusedActor).idBoss == -1)
							{
								doParty();
							}
							else
							{
								doFire(5, indexTabSlot);
							}
							return;
						}
						if (focusedActor.catagory != 2 || actor.catagory != 2)
						{
							doFire(5, indexTabSlot);
							return;
						}
						if (((NPC)focusedActor).type == ((NPC)actor).type)
						{
							if (((NPC)actor).type != 4)
							{
								doFire(5, indexTabSlot);
								return;
							}
							if (((NPC)focusedActor).idLinhGac == ((NPC)actor).idLinhGac)
							{
								doFire(5, indexTabSlot);
								return;
							}
							if (actor.ID != mainChar.ID)
							{
								focusedActor = actor;
								doFire(5, indexTabSlot);
								return;
							}
						}
					}
					if (actor.ID == mainChar.ID)
					{
						return;
					}
					bool flag = false;
					if (typeOptionFocus == 1)
					{
						if (actor.catagory == Actor.CAT_PLAYER && (!actor.iskiller || actor.isNPC()))
						{
							flag = true;
						}
						if (actor.catagory != Actor.CAT_MONSTER && actor.catagory == Actor.CAT_PLAYER && !actor.iskiller)
						{
							flag = true;
						}
					}
					else if (typeOptionFocus == 2)
					{
						if (!actor.isNPC())
						{
							flag = true;
						}
					}
					else if (typeOptionFocus == 3)
					{
						if ((actor.catagory == Actor.CAT_PLAYER && actor.idClan == mainChar.idClan) || actor.isNPC())
						{
							flag = true;
						}
					}
					else if (typeOptionFocus == 4 && ((actor.catagory == Actor.CAT_PLAYER && actor.nationID == mainChar.nationID) || actor.isNPC()))
					{
						flag = true;
					}
					if (!flag)
					{
						focusedActor = actor;
					}
					if (map == 29)
					{
						findRoad(num2, num3);
					}
					return;
				}
				focusedActor = null;
			}
			else
			{
				if (mainChar.x >= xBeginFrame && mainChar.x <= xTheendFrame + 32 && mainChar.y >= yBeginFrame && mainChar.y <= yTheendFrame + 32)
				{
					int num5 = actors.size();
					for (int j = 0; j < num5; j++)
					{
						Actor actor2 = (Actor)actors.elementAt(j);
						if (num2 < actor2.x + 2 || num2 > actor2.x + 30 || num3 < actor2.y || num3 > actor2.y + 30)
						{
							continue;
						}
						Canvas.isPointerClick = false;
						if (focusedActor.ID != -1 && focusedActor.ID == actor2.ID)
						{
							if (mainChar.state == 0)
							{
								doFire(5, indexTabSlot);
							}
						}
						else if (actor2.ID != mainChar.ID)
						{
							findRoad(num2, num3);
						}
						return;
					}
				}
				focusedActor = null;
			}
		}
		findRoad(num2, num3);
		if (MenuSelectItem.isClose)
		{
			MenuSelectItem.isClose = false;
			mainChar.posTransRoad = updateFindRoad(0, 0, 0, 0);
		}
	}

	public void resetFcBt()
	{
		for (int i = 0; i < isPaintFcBt.Length; i++)
		{
			isPaintFcBt[i] = false;
		}
	}

	private void pointer(int x11, int y11)
	{
		int width = Res.imgNewBt[4].getWidth();
		int height = Res.imgNewBt[4].getHeight();
		if (isTouchHold(xHp + 10, yHp + 10, x11, y11, 50, 50))
		{
			resetFcBt();
			isPaintFcBt[7] = true;
			Canvas.keyHold[1] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[9] = (Canvas.keyHold[5] = false);
		}
		if (isTouchHold(xU, yU, x11, y11, width, height))
		{
			resetFcBt();
			isPaintFcBt[0] = true;
			Canvas.keyHold[2] = true;
			Canvas.keyHold[8] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[9] = false;
			isNhanPhim = true;
			mainChar.posTransRoad = updateFindRoad(0, 0, 0, 0);
		}
		else if (isTouchHold(xD, yD, x11, y11, width, height))
		{
			resetFcBt();
			isPaintFcBt[3] = true;
			Canvas.keyHold[8] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[9] = false;
			isNhanPhim = true;
			mainChar.posTransRoad = updateFindRoad(0, 0, 0, 0);
		}
		else if (isTouchHold(xL, yL, x11, y11, width, height))
		{
			resetFcBt();
			isPaintFcBt[1] = true;
			Canvas.keyHold[4] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[8] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[9] = false;
			isNhanPhim = true;
			mainChar.posTransRoad = updateFindRoad(0, 0, 0, 0);
		}
		else if (isTouchHold(xR, yR, x11, y11, width, height))
		{
			resetFcBt();
			isPaintFcBt[2] = true;
			Canvas.keyHold[6] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[8] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[9] = false;
			isNhanPhim = true;
			mainChar.posTransRoad = updateFindRoad(0, 0, 0, 0);
		}
		else if (Canvas.isPointer(Canvas.w - 108, Canvas.h - Canvas.hh / 2 - 35, 120, 120))
		{
			resetFcBt();
			isPaintFcBt[6] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[8] = false);
			Canvas.keyHold[7] = (Canvas.keyHold[9] = false);
		}
		else if (isTouchHold(xMp + 10, yMp + 10, x11, y11, 50, 50))
		{
			resetFcBt();
			isPaintFcBt[8] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[7] = (Canvas.keyHold[8] = false);
		}
		if (isTouchHold(xOne + 10, yOne + 10, x11, y11, 50, 50))
		{
			resetFcBt();
			isPaintFcBt[4] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[3] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[8] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[7] = (Canvas.keyHold[9] = false);
		}
		else if (isTouchHold(xThree + 10, yThree + 10, x11, y11, 50, 50))
		{
			resetFcBt();
			isPaintFcBt[5] = true;
			Canvas.keyHold[2] = (Canvas.keyHold[8] = false);
			Canvas.keyHold[4] = (Canvas.keyHold[6] = false);
			Canvas.keyHold[1] = (Canvas.keyHold[5] = false);
			Canvas.keyHold[7] = (Canvas.keyHold[9] = false);
		}
	}

	public static bool xacDinhToaDo(int px, int py, int posx, int posy, int w, int h)
	{
		if (px > posx - w / 2 && px < posx + w / 2 && py > posy - h / 2 && py < posy + h / 2)
		{
			return true;
		}
		return false;
	}

	public static bool isTouchPre(int x, int y, int px, int py, int w, int h)
	{
		if (px >= x && px <= x + w && py >= y && py <= y + h)
		{
			return true;
		}
		return false;
	}

	public static bool isTouchHold(int x, int y, int px, int py, int w, int h)
	{
		if (Main.isPC)
		{
			return false;
		}
		if (px >= x && px <= x + w && py >= y && py <= y + h)
		{
			return true;
		}
		return false;
	}

	public void findRoad(int aa, int bb)
	{
		aa /= 16;
		bb /= 16;
		if (!Tilemap.tileTypeAtPixel(cmx + Canvas.px, cmy + Canvas.py, 2) && !checkMoveLimit(cmx + Canvas.px, cmy + Canvas.py))
		{
			if (posCam == null)
			{
				posCam = new Position(0, 0);
			}
			posCam.x = (short)aa;
			posCam.y = (short)bb;
			Canvas.isPointerClick = false;
			mainChar.xTo = mainChar.x;
			mainChar.yTo = mainChar.y;
			mainChar.xBegin = mainChar.x;
			mainChar.yBegin = mainChar.y;
			mainChar.posTransRoad = updateFindRoad(mainChar.x / 16, mainChar.y / 16, aa, bb);
			mainChar.countRoad = 0;
		}
	}

	public void findRoad2(int aa, int bb)
	{
		aa /= 16;
		bb /= 16;
		if (posCam == null)
		{
			posCam = new Position(0, 0);
		}
		posCam.x = (short)aa;
		posCam.y = (short)bb;
		mainChar.xTo = mainChar.x;
		mainChar.yTo = mainChar.y;
		tg.index = 8;
		mainChar.posTransRoad = updateFindRoad(mainChar.x / 16, mainChar.y / 16, aa, bb);
		mainChar.countRoad = 0;
		timeRemovePos = 100;
	}

	private int setDis(int x1, int y1, int x2, int y2)
	{
		return Util.abs(x1 - x2) + Util.abs(y1 - y2);
	}

	private short[] updateFindRoad(int xF, int yF, int xTo, int yTo)
	{
		if (Util.distance(xF * 16, yF * 16, xTo * 16, yTo * 16) <= 16)
		{
			return null;
		}
		if (checkMoveLimit(xTo, yTo))
		{
			return null;
		}
		xStart = (sbyte)cmxMini;
		yStart = (sbyte)cmyMini;
		xF -= xStart;
		yF -= yStart;
		xTo -= xStart;
		yTo -= yStart;
		int num = mapFind.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < mapFind[i].Length; j++)
			{
				int num2 = (yStart + j) * Tilemap.w + (xStart + i);
				if (num2 < Tilemap.type.Length - 1)
				{
					if (Tilemap.type[num2] == 2)
					{
						mapFind[i][j] = -1;
					}
					else
					{
						mapFind[i][j] = 0;
					}
				}
			}
		}
		short num3 = 0;
		int num4 = xF;
		int num5 = yF;
		short num6 = (short)num4;
		short num7 = (short)num5;
		if (num4 < 0 || num4 >= mapFind.Length)
		{
			return null;
		}
		if (num4 < mapFind.Length && num5 < mapFind[num4].Length)
		{
			mapFind[num4][num5] = 1;
		}
		num3 = 2;
		int num8 = mapFind.Length;
		int num9 = mapFind[0].Length;
		int num10 = 0;
		while (true)
		{
			num10++;
			if (num10 > 500)
			{
				if (iTaskAuto == 2)
				{
					iTaskAutoLast = iTaskAuto;
					isFixBugAutoQuest = true;
				}
				iTaskAuto = 1;
				return null;
			}
			int num11 = -1;
			int num12 = -1;
			if (num4 + 1 < num8 && mapFind[num4 + 1][num5] == 0)
			{
				mapFind[num4 + 1][num5] = (sbyte)num3;
				num11 = num4 + 1;
				num12 = num5;
			}
			if (num4 - 1 >= 0 && mapFind[num4 - 1][num5] == 0)
			{
				mapFind[num4 - 1][num5] = (sbyte)num3;
				if (num11 != -1)
				{
					if (setDis(num11, num12, xTo, yTo) > setDis(num4 - 1, num5, xTo, yTo))
					{
						num11 = num4 - 1;
						num12 = num5;
					}
				}
				else
				{
					num11 = num4 - 1;
					num12 = num5;
				}
			}
			if (num5 + 1 < num9 && mapFind[num4][num5 + 1] == 0)
			{
				mapFind[num4][num5 + 1] = (sbyte)num3;
				if (num11 != -1)
				{
					if (setDis(num11, num12, xTo, yTo) > setDis(num4, num5 + 1, xTo, yTo))
					{
						num11 = num4;
						num12 = num5 + 1;
					}
				}
				else
				{
					num11 = num4;
					num12 = num5 + 1;
				}
			}
			if (num5 - 1 >= 0 && mapFind[num4][num5 - 1] == 0)
			{
				mapFind[num4][num5 - 1] = (sbyte)num3;
				if (num11 != -1)
				{
					if (setDis(num11, num12, xTo, yTo) > setDis(num4, num5 - 1, xTo, yTo))
					{
						num11 = num4;
						num12 = num5 - 1;
					}
				}
				else
				{
					num11 = num4;
					num12 = num5 - 1;
				}
			}
			int num13 = -1;
			if (num11 != -1)
			{
				num13 = 0;
				num4 = num11;
				num5 = num12;
			}
			else
			{
				num4 = (num5 = 1000);
			}
			for (short num14 = 0; num14 < num8; num14 = (short)(num14 + 1))
			{
				for (short num15 = 0; num15 < num9; num15 = (short)(num15 + 1))
				{
					if (mapFind[num14][num15] > 1 && setContinue(num14, num15, mapFind) && mapFind[num14][num15] + setDis(num14, num15, xTo, yTo) < num3 + setDis(num4, num5, xTo, yTo))
					{
						num4 = num14;
						num5 = num15;
						num3 = mapFind[num14][num15];
						num13 = 0;
					}
				}
			}
			if (num4 == xTo && num5 == yTo)
			{
				break;
			}
			if (num13 == 0)
			{
				num3 = (short)(num3 + 1);
				continue;
			}
			return null;
		}
		if (num3 >= 127)
		{
			return null;
		}
		int num16 = 0;
		short[] array = new short[num3];
		while (true)
		{
			array[num16] = (short)((num4 << 8) + num5);
			if (num4 + 1 < num8 && mapFind[num4 + 1][num5] == mapFind[num4][num5] - 1)
			{
				num4 = (short)(num4 + 1);
			}
			else if (num4 - 1 >= 0 && mapFind[num4 - 1][num5] == mapFind[num4][num5] - 1)
			{
				num4 = (short)(num4 - 1);
			}
			else if (num5 + 1 < num9 && mapFind[num4][num5 + 1] == mapFind[num4][num5] - 1)
			{
				num5 = (short)(num5 + 1);
			}
			else if (num5 - 1 >= 0 && mapFind[num4][num5 - 1] == mapFind[num4][num5] - 1)
			{
				num5 = (short)(num5 - 1);
			}
			if (num4 == num6 && num5 == num7)
			{
				break;
			}
			num16++;
		}
		return array;
	}

	private bool setContinue(int i, int j, sbyte[][] mapFind)
	{
		if (i + 1 < mapFind.Length && mapFind[i + 1][j] == 0)
		{
			return true;
		}
		if (i - 1 >= 0 && mapFind[i - 1][j] == 0)
		{
			return true;
		}
		if (j + 1 < mapFind[i].Length && mapFind[i][j + 1] == 0)
		{
			return true;
		}
		if (j - 1 >= 0 && mapFind[i][j - 1] == 0)
		{
			return true;
		}
		return false;
	}

	public void onMenuOption(int userId1, sbyte idMenu, string[] listStr)
	{
		Out.println("may lan nho");
		if (Canvas.menu.showMenu)
		{
			Canvas.menu.showMenu = false;
		}
		mVector mVector2 = new mVector();
		int num = listStr.Length;
		for (int i = 0; i < num; i++)
		{
			int ii = i;
			Command command = new Command(listStr[i]);
			ActionPerform action = delegate
			{
				gameService.doMenuOption(userId1, idMenu, ii);
			};
			command.action = action;
			mVector2.addElement(command);
		}
		Canvas.menu.startAt(mVector2, 3);
		Canvas.currentDialog = null;
	}

	public void onTextBox(int userID, sbyte idMenu, string nameText, int typeInput)
	{
		ActionPerform ok = delegate
		{
			gameService.doTextBox(userID, idMenu, Canvas.inputDlg.tfInput.getText());
			Canvas.endDlg();
		};
		Canvas.inputDlg.setInfo(nameText, ok, typeInput, 40, isMaxW: true);
		Canvas.inputDlg.show();
	}

	public void onContentClanQuest(string content)
	{
		ActionPerform yesAction = delegate
		{
			gameService.questClan(1);
			Canvas.endDlg();
		};
		Canvas.startYesNoDlg(content, yesAction);
	}

	public static void onWeather(sbyte weather2, int number, int timeLimit)
	{
		if (weather2 != -1)
		{
			effAnimate.addElement(new AnimateEffect(weather2, isStart: true, number, timeLimit));
		}
		else
		{
			int num = effAnimate.size();
			for (int i = 0; i < num; i++)
			{
				AnimateEffect animateEffect = (AnimateEffect)effAnimate.elementAt(i);
				animateEffect.isStop = true;
			}
		}
		weather = weather2;
	}

	public void onSetCharKham(short idChar, sbyte[] idSkill, sbyte[] time)
	{
		LiveActor liveActor = (LiveActor)findActorByID(idChar);
		if (liveActor == null)
		{
			return;
		}
		int num = idSkill.Length;
		for (int i = 0; i < num; i++)
		{
			int num2 = 0;
			int num3 = liveActor.effSkill.size();
			for (int j = 0; j < num3; j++)
			{
				Skill_Kham skill_Kham = (Skill_Kham)liveActor.effSkill.elementAt(j);
				if (skill_Kham.type == idSkill[i])
				{
					skill_Kham.delay = time[i];
					num2 = 1;
					break;
				}
			}
			if (num2 == 0)
			{
				liveActor.effSkill.addElement(new Skill_Kham(idSkill[i], time[i], liveActor));
			}
		}
	}

	public void onDynamicObj(DynamicObj obj)
	{
		objDynamic.addElement(obj);
		actors.addElement(obj);
	}

	public void onEffect(EffectServerManager effObj)
	{
		if (effManager == null)
		{
			effManager = new mVector();
		}
		effManager.addElement(effObj);
	}

	public void onCheDo(string nameItem, short idItem, mVector listMineral, int type, int Khoa)
	{
		WindowInfoScr.gI().listTemp.removeAllElements();
		WindowInfoScr.gI().listCheDo = listMineral;
		WindowInfoScr.gI().listEp = new mVector();
		WindowInfoScr.idTemp = idItem;
		WindowInfoScr.optionCreateItem = (sbyte)type;
		if (listMineral.size() == 0)
		{
			Canvas.startOKDlg("Vật phẩm không thể thăng cấp");
			return;
		}
		WindowInfoScr.khoaCheDo = (sbyte)Khoa;
		mVector mVector2 = new mVector();
		switch (Khoa)
		{
		case 0:
			mVector2 = MainChar.gemItem;
			break;
		case 1:
			mVector2 = MainChar.gemItemKhoa;
			break;
		default:
		{
			int num = MainChar.gemItem.size();
			int num2 = MainChar.gemItemKhoa.size();
			for (int i = 0; i < num; i++)
			{
				GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(i);
				GemTemplate gemTemplate2 = new GemTemplate(gemTemplate.id);
				GemTemplate.copyData(gemTemplate, gemTemplate2);
				mVector2.addElement(gemTemplate2);
			}
			for (int j = 0; j < num2; j++)
			{
				GemTemplate gemTemplate3 = (GemTemplate)MainChar.gemItemKhoa.elementAt(j);
				bool flag = false;
				for (int k = 0; k < mVector2.size(); k++)
				{
					GemTemplate gemTemplate4 = (GemTemplate)mVector2.elementAt(k);
					if (gemTemplate4.id == gemTemplate3.id)
					{
						gemTemplate4.number += gemTemplate3.number;
						flag = true;
					}
				}
				if (!flag)
				{
					GemTemplate gemTemplate5 = new GemTemplate(gemTemplate3.id);
					GemTemplate.copyData(gemTemplate3, gemTemplate5);
					mVector2.addElement(gemTemplate5);
				}
			}
			break;
		}
		}
		int num3 = listMineral.size();
		Mineral mineral = null;
		for (int l = 0; l < num3; l++)
		{
			mineral = (Mineral)listMineral.elementAt(l);
			for (int m = 0; m < mVector2.size(); m++)
			{
				GemTemplate gemTemplate6 = (GemTemplate)mVector2.elementAt(m);
				if ((type <= 2 && (type != 2 || (type == 2 && l == 0))) || type > 2)
				{
					if (gemTemplate6.id >= mineral.idTemplate + ((type != 0) ? 3 : 0) && gemTemplate6.id <= mineral.idTemplate + 5)
					{
						WindowInfoScr.gI().listTemp.addElement(gemTemplate6);
					}
				}
				else if (gemTemplate6.id == mineral.idTemplate + 5)
				{
					WindowInfoScr.gI().listTemp.addElement(gemTemplate6);
				}
			}
		}
		if (WindowInfoScr.gI().listTemp.size() == 0)
		{
			Canvas.startOKDlg("Không có nguyên liệu.");
			return;
		}
		showWindow(0, isSell: false, new sbyte[1] { 28 });
		WindowInfoScr.gI().name = nameItem;
	}

	private void ktGem(GemTemplate g, mVector vTam)
	{
		for (int i = 0; i < vTam.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)vTam.elementAt(i);
			if (gemTemplate.id == g.id)
			{
				return;
			}
		}
		vTam.addElement(g);
	}

	public void onMSGServer(string readUTF)
	{
		if (listMSGServer == null)
		{
			listMSGServer = new mVector();
		}
		listMSGServer.addElement(readUTF);
		MessageScr.gI().addTab(readUTF, null, 0);
	}

	public void onDropItem2Ground(Message msg)
	{
		try
		{
			int num = msg.reader().readByte();
			for (int i = 0; i < num; i++)
			{
				Dropable dropable = (Dropable)CreateActor(msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), 0, -1);
				if (dropable != null)
				{
					dropable.startDropFrom(dropable.x, dropable.y, dropable.x, dropable.y);
					actors.addElement(dropable);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void onSkillClan(SkillClan[] skillclan, SkillClan[] skillClanPrivate)
	{
		skillClan = skillclan;
		this.skillClanPrivate = skillClanPrivate;
	}

	public void onLuckyDraw(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if (b == 0)
			{
				ItemQsScreen.gI().resetData();
				ItemQsScreen.allItemLucky.removeAllElements();
				ItemQsScreen.totalItemSelect = msg.reader().readByte();
				int num = msg.reader().readByte();
				for (sbyte b2 = 0; b2 < num; b2 = (sbyte)(b2 + 1))
				{
					ItemLuckyDraw itemLuckyDraw = new ItemLuckyDraw();
					itemLuckyDraw.cat = msg.reader().readByte();
					itemLuckyDraw.id = msg.reader().readShort();
					itemLuckyDraw.name = msg.reader().readUTF();
					itemLuckyDraw.decript = new string[msg.reader().readByte()];
					for (int i = 0; i < itemLuckyDraw.decript.Length; i++)
					{
						itemLuckyDraw.decript[i] = msg.reader().readUTF();
					}
					itemLuckyDraw.isSelect = msg.reader().readByte();
					ItemQsScreen.allItemLucky.addElement(itemLuckyDraw);
				}
				ItemQsScreen.total = (short)ItemQsScreen.allItemLucky.size();
				if (ItemQsScreen.total < 32)
				{
					ItemQsScreen.total = 32;
				}
				ItemQsScreen.gI().last = this;
				ItemQsScreen.gI().switchToMe();
			}
			else if (b == 1)
			{
				DialLuckyScr.gI().lastScr = this;
				DialLuckyScr.gI().switchToMe();
				sbyte b3 = msg.reader().readByte();
				DialLuckyScr.arrayIndex = new sbyte[b3];
				for (sbyte b4 = 0; b4 < b3; b4 = (sbyte)(b4 + 1))
				{
					DialLuckyScr.arrayIndex[b4] = msg.reader().readByte();
				}
				DialLuckyScr.gI().onStart();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void reSetQuest()
	{
		mainQuest = null;
		subQuest = null;
		clanQuest = null;
	}

	public static int isNpcQuest(int idNpc)
	{
		if (mainQuest != null)
		{
			if ((mainQuest.stateQuest == 1 || mainQuest.stateQuest == 2) && mainQuest.idNpcResponse == idNpc)
			{
				return 1;
			}
			if (mainQuest.stateQuest == 0)
			{
				return 0;
			}
		}
		if (subQuest != null)
		{
			if ((subQuest.stateQuest == 1 || subQuest.stateQuest == 2) && subQuest.idNpcResponse == idNpc)
			{
				return 3;
			}
			if (subQuest.stateQuest == 0)
			{
				return 2;
			}
		}
		if (clanQuest != null)
		{
			if ((clanQuest.stateQuest == 1 || clanQuest.stateQuest == 2) && clanQuest.idNpcResponse == idNpc)
			{
				return 3;
			}
			if (clanQuest.stateQuest == 0)
			{
				return 2;
			}
		}
		return -1;
	}

	public void getAllPosNPCMInimap(Actor npc)
	{
		if (mainQuest != null && (mainQuest.stateQuest == 1 || mainQuest.stateQuest == 2) && mainQuest.idNpcResponse == npc.getTypeNpc())
		{
			setPosNPC(npc.getTypeNpc(), (mainQuest.stateQuest == 1) ? 3 : 0, npc.x, npc.y);
			return;
		}
		if (subQuest != null && (subQuest.stateQuest == 1 || subQuest.stateQuest == 2) && subQuest.idNpcResponse == npc.getTypeNpc())
		{
			setPosNPC(npc.getTypeNpc(), (subQuest.stateQuest == 1) ? 3 : 0, npc.x, npc.y);
			return;
		}
		if (clanQuest != null && (clanQuest.stateQuest == 1 || clanQuest.stateQuest == 2) && clanQuest.idNpcResponse == npc.getTypeNpc())
		{
			setPosNPC(npc.getTypeNpc(), (clanQuest.stateQuest == 1) ? 3 : 0, npc.x, npc.y);
			return;
		}
		for (int i = 0; i < allQuestCanReceive.size(); i++)
		{
			Quest quest = (Quest)allQuestCanReceive.elementAt(i);
			if (quest.stateQuest == 0 && quest.idNpcReceive == npc.getTypeNpc())
			{
				setPosNPC(npc.getTypeNpc(), 0, npc.x, npc.y);
			}
		}
	}

	public static mVector getAllQuestNpc(int idNpc)
	{
		mVector mVector2 = new mVector();
		if (mainQuest != null && (mainQuest.stateQuest == 1 || mainQuest.stateQuest == 2) && mainQuest.idNpcResponse == idNpc)
		{
			Command command = new Command("Trả" + mainQuest.name);
			command.action = delegate
			{
				currQuest = mainQuest;
				currQuest.startTalk(Canvas.gameScr.mainChar, Canvas.gameScr.focusedActor, mainQuest.stateQuest);
			};
			mVector2.addElement(command);
		}
		if (subQuest != null && (subQuest.stateQuest == 1 || subQuest.stateQuest == 2) && subQuest.idNpcResponse == idNpc)
		{
			Command command2 = new Command("Trả " + subQuest.name);
			command2.action = delegate
			{
				currQuest = subQuest;
				currQuest.startTalk(Canvas.gameScr.mainChar, Canvas.gameScr.focusedActor, subQuest.stateQuest);
			};
			mVector2.addElement(command2);
		}
		if (clanQuest != null && (clanQuest.stateQuest == 1 || clanQuest.stateQuest == 2) && clanQuest.idNpcResponse == idNpc)
		{
			Command command3 = new Command("Trả " + clanQuest.name);
			command3.action = delegate
			{
				currQuest = clanQuest;
				currQuest.startTalk(Canvas.gameScr.mainChar, Canvas.gameScr.focusedActor, clanQuest.stateQuest);
			};
			mVector2.addElement(command3);
		}
		for (int i = 0; i < allQuestCanReceive.size(); i++)
		{
			Quest q = (Quest)allQuestCanReceive.elementAt(i);
			if (q.stateQuest == 0 && q.idNpcReceive == idNpc)
			{
				Command command4 = new Command(q.name);
				command4.action = delegate
				{
					currQuest = q;
					currQuest.startTalk(Canvas.gameScr.mainChar, Canvas.gameScr.focusedActor, q.stateQuest);
				};
				mVector2.addElement(command4);
			}
		}
		return mVector2;
	}

	public static Image getImgQuest(int idNpc)
	{
		if (mainQuest != null && (mainQuest.stateQuest == 1 || mainQuest.stateQuest == 2) && mainQuest.idNpcResponse == idNpc)
		{
			return Res.imgSelect2;
		}
		if (subQuest != null && (subQuest.stateQuest == 1 || subQuest.stateQuest == 2) && subQuest.idNpcResponse == idNpc)
		{
			return Res.imgSelect2;
		}
		if (clanQuest != null && (clanQuest.stateQuest == 1 || clanQuest.stateQuest == 2) && clanQuest.idNpcResponse == idNpc)
		{
			return Res.imgSelect2;
		}
		for (int i = 0; i < allQuestCanReceive.size(); i++)
		{
			Quest quest = (Quest)allQuestCanReceive.elementAt(i);
			if (quest.stateQuest == 0 && quest.idNpcReceive == idNpc)
			{
				if (quest.type == 3)
				{
					return Res.imgSelect2;
				}
				return Res.imgSelect1;
			}
		}
		return Res.imgSelect;
	}

	public void setPosNPC(int id, int indexColor, int x, int y)
	{
		for (int i = 0; i < PosNPCQuest.size(); i++)
		{
			Position position = (Position)PosNPCQuest.elementAt(i);
			if (position != null && position.id == id)
			{
				return;
			}
		}
		Position position2 = new Position();
		position2.id = id;
		position2.indexColor = (short)indexColor;
		position2.x = x;
		position2.y = y;
		PosNPCQuest.addElement(position2);
	}

	public void onQuest(Message m)
	{
		try
		{
			sbyte b = m.reader().readByte();
			sbyte b2 = m.reader().readByte();
			Out.println(b + " NHAN NHIEM VU MOI " + b2);
			if (b == 0)
			{
				allQuestCanReceive.removeAllElements();
			}
			for (int i = 0; i < b2; i++)
			{
				int id = m.reader().readShort();
				Quest quest = new Quest(id);
				quest.stateQuest = b;
				quest.main_sub = m.reader().readByte();
				quest.name = m.reader().readUTF();
				switch (b)
				{
				case 0:
				{
					quest.idNpcReceive = m.reader().readByte();
					string[] array = Util.split(m.reader().readUTF(), ">");
					for (int l = 0; l < array.Length; l++)
					{
						quest.content.addElement(array[l]);
					}
					quest.type = m.reader().readByte();
					quest.deltaLv = m.reader().readByte();
					break;
				}
				case 1:
				{
					quest.idNpcResponse = m.reader().readByte();
					string[] array = Util.split(m.reader().readUTF(), ">");
					for (int n = 0; n < array.Length; n++)
					{
						quest.rescontent.addElement(array[n]);
					}
					quest.decript = m.reader().readUTF();
					quest.infoGift = m.reader().readUTF();
					break;
				}
				case 2:
					quest.type = m.reader().readByte();
					quest.decript = m.reader().readUTF();
					quest.idNpcResponse = m.reader().readByte();
					quest.deltaLv = m.reader().readByte();
					quest.infoGift = m.reader().readUTF();
					if (quest.type == 2)
					{
						int num = m.reader().readByte();
						quest.idItemGet = new short[num];
						quest.totalItemGet = new short[num];
						quest.allItemGet = new short[num];
						for (int j = 0; j < num; j++)
						{
							short num2 = m.reader().readShort();
							short num3 = m.reader().readShort();
							short num4 = m.reader().readShort();
							quest.idItemGet[j] = num2;
							quest.allItemGet[j] = num3;
							quest.totalItemGet[j] = num4;
						}
					}
					else if (quest.type == 0)
					{
						int num5 = m.reader().readByte();
						quest.idMonsKill = new short[num5];
						quest.totalMonskill = new short[num5];
						quest.allMonsKilled = new short[num5];
						for (int k = 0; k < num5; k++)
						{
							short num6 = m.reader().readShort();
							short num7 = m.reader().readShort();
							short num8 = m.reader().readShort();
							quest.idMonsKill[k] = num6;
							quest.allMonsKilled[k] = num7;
							quest.totalMonskill[k] = num8;
						}
					}
					else if (quest.type == 4)
					{
						quest.totalMonskill = new short[1];
						quest.allMonsKilled = new short[1];
						quest.allMonsKilled[0] = m.reader().readShort();
						quest.totalMonskill[0] = m.reader().readShort();
					}
					break;
				}
				if (b == 0)
				{
					allQuestCanReceive.addElement(quest);
					if (quest.main_sub == 0 && Char.skillLevelLearnt[0] == 0)
					{
						idNpcReceive = quest.idNpcReceive;
						set_npc_request(idNpcReceive);
					}
				}
				else if (quest.main_sub == 0)
				{
					mainQuest = quest;
				}
				else if (quest.main_sub == 1)
				{
					subQuest = quest;
				}
				else if (quest.main_sub == 2)
				{
					clanQuest = quest;
				}
			}
		}
		catch (Exception ex)
		{
			Out.println("Loi tai onQuest" + ex.ToString());
		}
	}

	public void onFruit(Message msg)
	{
		try
		{
			Tree2014.gI().setInfoTree(msg);
		}
		catch (Exception)
		{
		}
	}

	public TimecountDown findTime(int id)
	{
		for (int i = 0; i < VecTime.size(); i++)
		{
			TimecountDown timecountDown = (TimecountDown)VecTime.elementAt(i);
			if (timecountDown != null && timecountDown.id == id)
			{
				return timecountDown;
			}
		}
		return null;
	}

	public void onShopNew(Message msg)
	{
		try
		{
			mVector mVector2 = new mVector();
			short typeshop = msg.reader().readShort();
			ShopNew.gI().typeshop = typeshop;
			int num = msg.reader().readShort();
			for (int i = 0; i < num; i++)
			{
				ItemInInventory itemInInventory = new ItemInInventory();
				itemInInventory.charClazz = msg.reader().readByte();
				itemInInventory.itemID = msg.reader().readShort();
				itemInInventory.idTemplate = msg.reader().readShort();
				itemInInventory.plusTemplate = msg.reader().readByte();
				itemInInventory.level = msg.reader().readByte();
				itemInInventory.mDurable = msg.reader().readShort();
				itemInInventory.durable = msg.reader().readShort();
				itemInInventory.clazz = msg.reader().readByte();
				itemInInventory.numKham = msg.reader().readByte();
				itemInInventory.totalKham = msg.reader().readByte();
				itemInInventory.colorName = msg.reader().readByte();
				itemInInventory.heItem = msg.reader().readByte();
				itemInInventory.beKicked = msg.reader().readByte();
				itemInInventory.hangItem = msg.reader().readByte();
				itemInInventory.magic_physic = msg.reader().readByte();
				itemInInventory.islock = msg.reader().readByte();
				itemInInventory.nameCharSeal = msg.reader().readUTF();
				itemInInventory.allAttribute.removeAllElements();
				itemInInventory.lastTime = mSystem.getCurrentTimeMillis();
				itemInInventory.dayUse = msg.reader().readUnsignedShort();
				sbyte b = msg.reader().readByte();
				for (sbyte b2 = 0; b2 < b; b2 = (sbyte)(b2 + 1))
				{
					InfoAttributeItem o = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
					itemInInventory.allAttribute.addElement(o);
				}
				itemInInventory.isItemDrop = msg.reader().readByte();
				itemInInventory.isEnoughData = true;
				mVector2.addElement(itemInInventory);
			}
			ShopNew.text = msg.reader().readUTF();
			ShopNew.nameshop = msg.reader().readUTF();
			ShopNew.gI().ItemShopNew = mVector2;
			PauseMenu.gI().showShopNew(0);
		}
		catch (Exception)
		{
		}
	}

	public void onCountDown(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			string tile = msg.reader().readUTF();
			int num = msg.reader().readInt();
			short num2 = -1;
			sbyte b2 = -1;
			try
			{
				num2 = msg.reader().readShort();
				b2 = msg.reader().readByte();
			}
			catch (Exception)
			{
				num2 = -1;
				b2 = -1;
			}
			long time = mSystem.currentTimeMillis() + num * 1000;
			if (b != -1)
			{
				if (num > 0)
				{
					Actor actor = findActorByID_Cat(id, b);
					if (actor != null)
					{
						objcountDown = actor;
					}
					charcountdonw = new CharCountDown(time, tile);
				}
				if (num == 0)
				{
					charcountdonw = null;
					objcountDown = null;
				}
			}
			if (b != -1 || num < 0)
			{
				return;
			}
			TimecountDown timecountDown = findTime(id);
			int num3 = num;
			if (timecountDown == null)
			{
				timecountDown = new TimecountDown(id, num2, num3, tile, b2);
				VecTime.addElement(timecountDown);
			}
			if (timecountDown != null)
			{
				timecountDown.tile = tile;
				timecountDown.idIcon = num2;
				timecountDown.setsecond(num3);
				if (b2 == -2)
				{
					timecountDown.wantdestroy = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void onTuBinh(Message msg)
	{
		TuBinhScr.gI().setData(msg);
	}

	public static void createNewSkill(LiveActor from, LiveActor to, int power, sbyte eff, int imgIndex)
	{
		Arrow arrow = new Arrow(imgIndex);
		arrow.set(0, from.x, from.y, power, eff, from, to);
		switch (imgIndex)
		{
		case 10:
			arrow.typeEffEnd = 46;
			break;
		case 11:
			arrow.typeEffEnd = 45;
			break;
		case 12:
			arrow.typeEffEnd = 30;
			break;
		}
		arrowsUp.addElement(arrow);
	}

	public static Effect creatEff(LiveActor ac, int x, int y, int type)
	{
		Effect effect = new Effect(x, y, type);
		if (ac != null)
		{
			effect.myChar = ac;
			if (ac.getHorse() != -1)
			{
				effect.yadd = -5;
			}
		}
		switch (type)
		{
		case 41:
			effect.loop = 2;
			effect.yadd = (sbyte)(effect.yadd - 6);
			break;
		case 42:
			effect.loop = 2;
			effect.yadd = (sbyte)(effect.yadd - 6);
			break;
		case 43:
			effect.loop = 3;
			effect.yadd = (sbyte)(effect.yadd - 6);
			break;
		case 44:
		case 47:
		case 57:
			effect.loop = 1;
			effect.y -= 6;
			effect.yadd = (sbyte)(effect.yadd - 6);
			break;
		}
		return effect;
	}

	public void onNewEffect(Message msg)
	{
		int[] array = new int[4] { 41, 42, 43, 56 };
		int[] array2 = new int[4] { 12, 10, 11, 15 };
		int[] array3 = new int[4] { 44, 44, 47, 57 };
		try
		{
			short id = msg.reader().readShort();
			LiveActor liveActor = (LiveActor)getActor(id);
			if (liveActor == null)
			{
				return;
			}
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			sbyte b3 = msg.reader().readByte();
			mVector mVector2 = new mVector();
			mVector mVector3 = new mVector();
			mVector mVector4 = new mVector();
			for (int i = 0; i < b3; i++)
			{
				short id2 = msg.reader().readShort();
				int num = msg.reader().readInt();
				int num2 = msg.reader().readInt();
				if (b == Actor.CAT_PLAYER)
				{
					Char @char = (Char)getActor(id2);
					if (@char != null)
					{
						mVector3.addElement(num + string.Empty);
						mVector2.addElement(@char);
						mVector4.addElement(num2 + string.Empty);
						for (int j = 0; j < 3; j++)
						{
							Char char2 = new Char();
							char2.x = (short)(@char.x + r.nextInt() % 10 * 16);
							char2.y = (short)(@char.y + r.nextInt() % 10 * 16);
							mVector2.addElement(char2);
							mVector3.addElement(num + string.Empty);
							mVector4.addElement(num2 + string.Empty);
						}
					}
				}
				else
				{
					if (b != Actor.CAT_MONSTER)
					{
						continue;
					}
					Monster monster = findMonsterByID(id2);
					if (monster != null)
					{
						mVector3.addElement(num + string.Empty);
						mVector2.addElement(monster);
						mVector4.addElement(num2 + string.Empty);
						for (int k = 0; k < 3; k++)
						{
							Monster monster2 = new Monster();
							monster2.x = (short)(monster.x + r.nextInt() % 10 * 16);
							monster2.y = (short)(monster.y + r.nextInt() % 10 * 16);
							mVector2.addElement(monster2);
							mVector3.addElement(num + string.Empty);
							mVector4.addElement(num2 + string.Empty);
						}
					}
				}
			}
			Effect effect = creatEff(liveActor, liveActor.x, liveActor.y, array[b2]);
			effect.subEff = new SubEff();
			effect.subEff.ac = liveActor;
			effect.subEff.target = mVector2;
			effect.subEff.idEff = array3[b2];
			effect.subEff.power = mVector3;
			effect.subEff.hp = mVector4;
			effect.subEff.eff = 0;
			effect.subEff.indeximg = array2[b2];
			EffectManager.hiEffects.addElement(effect);
		}
		catch (Exception)
		{
		}
	}

	public void onAutoImbue(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if (b == 0)
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(1, isContinue: false);
				return;
			}
			string infoPoup = msg.reader().readUTF();
			sbyte b2 = msg.reader().readByte();
			if (Canvas.currentScreen == ScreenDapDo.gI())
			{
				ScreenDapDo.gI().infoPoup = infoPoup;
				ScreenDapDo.gI().doFinishInbue();
				Canvas.endDlg();
			}
			if (b2 == 1)
			{
				ScreenDapDo.gI().resetSelect();
				ScreenDapDo.isFinishImbue = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void onTachNguyenLieu(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if (b == 0)
			{
				ScreenDapDo.gI().switchToMe(this);
				ScreenDapDo.gI().setSizeCell(0, isContinue: false);
			}
			else if (b == 4)
			{
				Canvas.currentScreen.startXayBot(msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte());
			}
		}
		catch (Exception)
		{
		}
	}

	public void onItemShopOnline(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if (b == -1)
			{
				Canvas.shop.switchToMe(Canvas.currentScreen);
				return;
			}
			sbyte b2 = b;
			if (b == 3)
			{
				b2 = 4;
			}
			else if (b == 4)
			{
				b2 = 5;
			}
			((mVector)ShopOnline.ALL_ITEM.elementAt(b2)).removeAllElements();
			sbyte b3 = msg.reader().readByte();
			for (int i = 0; i < b3; i++)
			{
				ItemInInventory itemInInventory = new ItemInInventory();
				itemInInventory.isEnoughData = true;
				itemInInventory.clazz = msg.reader().readByte();
				itemInInventory.idTemplate = msg.reader().readShort();
				itemInInventory.plusTemplate = msg.reader().readByte();
				itemInInventory.level = msg.reader().readByte();
				itemInInventory.mDurable = msg.reader().readShort();
				itemInInventory.durable = msg.reader().readShort();
				itemInInventory.numKham = msg.reader().readByte();
				itemInInventory.totalKham = msg.reader().readByte();
				itemInInventory.colorName = msg.reader().readByte();
				itemInInventory.heItem = msg.reader().readByte();
				itemInInventory.beKicked = msg.reader().readByte();
				itemInInventory.hangItem = msg.reader().readByte();
				itemInInventory.magic_physic = msg.reader().readByte();
				itemInInventory.islock = msg.reader().readByte();
				itemInInventory.nameCharSeal = msg.reader().readUTF();
				itemInInventory.nameCharSell = msg.reader().readUTF();
				itemInInventory.nameCharBet = msg.reader().readUTF();
				itemInInventory.prize = msg.reader().readInt();
				itemInInventory.prizeBet = msg.reader().readInt();
				itemInInventory.timeEnd = msg.reader().readLong();
				itemInInventory.daySell = msg.reader().readUTF();
				itemInInventory.allAttribute.removeAllElements();
				sbyte b4 = msg.reader().readByte();
				for (sbyte b5 = 0; b5 < b4; b5 = (sbyte)(b5 + 1))
				{
					InfoAttributeItem o = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
					itemInInventory.allAttribute.addElement(o);
				}
				((mVector)ShopOnline.ALL_ITEM.elementAt(b2)).addElement(itemInInventory);
			}
			if (b == 0)
			{
				Canvas.shop.setItemInventory();
			}
			if (b == 3)
			{
				ShopOnline.money = msg.reader().readLong();
			}
			ShopOnline.nPage[b2] = msg.reader().readShort();
			if (ShopOnline.indexPage[b2] >= ShopOnline.nPage[b2])
			{
				ShopOnline.indexPage[b2] = 0;
			}
		}
		catch (Exception)
		{
		}
	}

	public void onTemplateInfo(Message msg)
	{
		try
		{
			short num = msg.reader().readUnsignedByte();
			short num2 = msg.reader().readShort();
			if (num != 0)
			{
				return;
			}
			sbyte b = msg.reader().readByte();
			sbyte[] array = new sbyte[b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = msg.reader().readByte();
			}
			Res.loadMonster(num2, array);
			Res.monsterTemplates[num2].name = msg.reader().readUTF();
			Res.monsterTemplates[num2].he = msg.reader().readByte();
			Res.monsterTemplates[num2].maxhp = msg.reader().readInt();
			Res.monsterTemplates[num2].palate = msg.reader().readByte();
			Res.monsterTemplates[num2].spalate = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			Res.monsterTemplates[num2].isNewMonster = b2;
			if (b2 == 1)
			{
				sbyte[] array2 = new sbyte[msg.reader().readShort()];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = msg.reader().readByte();
				}
				Res.monsterTemplates[num2].doSetDataMonsterNew(array2);
			}
		}
		catch (Exception)
		{
		}
	}

	public void onDynamicEffect(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			short num = msg.reader().readShort();
			long timeExist = msg.reader().readLong();
			int num2 = msg.reader().readByte() * 16;
			int num3 = msg.reader().readByte() * 16;
			sbyte b2 = msg.reader().readByte();
			sbyte b3 = msg.reader().readByte();
			LiveActor liveActor = (LiveActor)((b2 != 0) ? findMonsterByID(num) : findCharByID(num));
			DynamicEffect dynamicEffect = new DynamicEffect(id);
			dynamicEffect.timeExist = timeExist;
			dynamicEffect.x = (short)num2;
			dynamicEffect.y = (short)num3;
			dynamicEffect.catagory = b2;
			dynamicEffect.stop = msg.reader().readByte();
			int add_remove = msg.reader().readByte();
			int num4 = 0;
			try
			{
				num4 = msg.reader().readInt();
				dynamicEffect.dam = num4;
			}
			catch (Exception)
			{
			}
			if (liveActor != null && b == 1)
			{
				if (b3 == 0)
				{
					liveActor.addDynamicEffBuffBottom(dynamicEffect, add_remove);
				}
				else
				{
					liveActor.addDynamicEffBuffTop(dynamicEffect, add_remove);
				}
			}
			else if (num > 32000 || b == 0)
			{
				if (liveActor != null)
				{
					dynamicEffect.x = liveActor.x;
					dynamicEffect.y = liveActor.y;
				}
				actors.addElement(dynamicEffect);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void paint12plus(MyGraphics g)
	{
		g.drawImage(img12plus, 0, (Canvas.currentScreen != Canvas.gameScr) ? 15 : 80);
	}

	public static void startSkillEffect(LiveActor c, int idSkill, long timeExist, int top_bottom, int power, int bymap)
	{
		DynamicEffect dynamicEffect = new DynamicEffect(idSkill);
		dynamicEffect.timeExist = timeExist;
		dynamicEffect.x = c.x;
		dynamicEffect.y = c.y;
		dynamicEffect.catagory = c.catagory;
		dynamicEffect.stop = 0;
		dynamicEffect.power = power;
		if (bymap == 0)
		{
			if (top_bottom == 0)
			{
				c.addDynamicEffBuffBottom(dynamicEffect, 0);
			}
			else
			{
				c.addDynamicEffBuffTop(dynamicEffect, 0);
			}
		}
		else
		{
			Canvas.gameScr.actors.addElement(dynamicEffect);
		}
	}
}
