using System;
using System.IO;
using UnityEngine;

public class Canvas
{
	public static Canvas instance;

	public static bool bRun;

	public static bool isLoadTileServer;

	public static bool[] keyPressed = new bool[29];

	public static bool[] keyReleased = new bool[29];

	public static bool[] keyHold = new bool[29];

	public static bool isPointerDown;

	public static bool isPointerClick;

	public static bool isPointerDrange;

	public static bool isMove;

	public static bool isPointerRelease;

	public static bool isPointerDownItem;

	public static bool isPointerDrange1;

	public static bool isPointerDownText;

	public static int px;

	public static int py;

	public static int isCheat;

	public static int gameTick;

	public static int w;

	public static int h;

	public static int hw;

	public static int hh;

	public static int w23;

	public static int h23;

	public static int w14;

	public static int h14;

	public static int w13;

	public static int h13;

	public static int w15;

	public static MyScreen currentScreen;

	public static bool isSmallScreen;

	public static GameScr gameScr;

	public static MyRandom r = new MyRandom();

	public static Menu menu = new Menu();

	public static LoginScr loginScr;

	public static Dialog currentDialog;

	public static MsgDlg msgdlg = new MsgDlg();

	public static int zoom = 2;

	public static InputDlg inputDlg;

	public static bool isLoad = false;

	public static bool isWifi = false;

	public static Image imgLogo;

	public static int count0;

	public static int hCommand = 25;

	public static int pyLast;

	public static int pxLast;

	public static bool isVirHorizontal;

	public static string captionCloseDlg = string.Empty;

	private static bool isStart = false;

	public static Command closeDlg;

	public long timeRemove;

	public static ShopOnline shop;

	public static string IMEI;

	public static BangAuto autoTab;

	public static string[] nameTile = new string[2]
	{
		"t_hang",
		"t_thanh"
	};

	public static bool isSmartPhone;

	public static Command cmdNgatKetNoi;

	public static bool isBeginAutoLogin = false;

	public static bool isConnectFail = false;

	public static bool isConnectOk = false;

	public static int keyAsciiPress;

	public static int timePutKey = 1;

	public static string infoDisConnect = string.Empty;

	public static int xInfoDisConnect;

	private static MsgDlg timeoutDlg = new MsgDlg();

	private static int timeout = 0;

	public static Position[] posCmd = new Position[3];

	public static bool isPointerDown1;

	public static bool isPointerClick1;

	public static int px1;

	public static int py1;

	public static bool isPointerJustRelease;

	public static bool isPointerDownNj;

	public Canvas()
	{
		isLoad = true;
		instance = this;
		IMEI = SystemInfo.deviceUniqueIdentifier;
		loadSize();
		isSmartPhone = true;
		if (w < 200)
		{
			isSmallScreen = true;
		}
	}

	public bool hasPointerEvents()
	{
		return true;
	}

	public void getTileFromRMS()
	{
		sbyte[] array = RMS.loadRMS(nameTile[0]);
		if (array == null)
		{
			isLoadTileServer = true;
		}
	}

	public bool canPutKey()
	{
		if (Math.abs(px - pxLast) <= 10 && Math.abs(py - pyLast) <= 10)
		{
			return true;
		}
		return false;
	}

	public static bool canNotPutKey()
	{
		if (Math.abs(px - pxLast) > 10 || Math.abs(py - pyLast) > 10)
		{
			return true;
		}
		return false;
	}

	public static void showtest()
	{
		string[] strinfo = new string[10]
		{
			"1",
			"1",
			"1",
			"1",
			"1",
			"1",
			"1",
			"1",
			"1",
			"1"
		};
		ActionPerform ok = delegate
		{
		};
		inputDlg.setInfo(strinfo, "Tên bang hội của bạn", ok, TField.INPUT_TYPE_ANY, 25, isMaxW: true);
		inputDlg.show();
		UnityEngine.Debug.LogWarning("vao ne ");
	}

	public static Image getLogo()
	{
		Image result = null;
		try
		{
			string filename = Main.res + "/png/logo";
			if (!GameMidlet.isKPAH)
			{
				filename = Main.res + "/png/vtclogo";
			}
			result = Image.createImage(filename);
			return result;
		}
		catch (IOException ex)
		{
			UnityEngine.Debug.Log(ex.Message);
			return result;
		}
	}

	public static void connect()
	{
		UnityEngine.Debug.Log("Connect: " + ServerListScr.address[ServerListScr.index] + "     " + ServerListScr.port[ServerListScr.index] + " name Server  " + ServerListScr.nameServer[ServerListScr.index]);
		string text = ServerListScr.address[ServerListScr.index];
		string host = text;
		short port = ServerListScr.port[ServerListScr.index];
		Session_ME.gI().connect(host, port);
	}

	public static void connectAuTo()
	{
		UnityEngine.Debug.Log("Connect: " + ServerListScr.addressAuTo + "     " + ServerListScr.portAuTo + " name Server auto " + ServerListScr.nameSvAuto);
		string addressAuTo = ServerListScr.addressAuTo;
		string host = addressAuTo;
		short portAuTo = ServerListScr.portAuTo;
		Session_ME.gI().connect(host, portAuTo);
	}

	public void update()
	{
		if (xInfoDisConnect != w / 2)
		{
			if (w / 2 - xInfoDisConnect >> 1 == 0)
			{
				xInfoDisConnect = w / 2;
			}
			else
			{
				xInfoDisConnect += w / 2 - xInfoDisConnect >> 1;
			}
		}
		if (xInfoDisConnect == w / 2)
		{
			if (timeRemove == -1)
			{
				timeRemove = mSystem.getCurrentTimeMillis() / 1000 + 3;
			}
			if (timeRemove - mSystem.getCurrentTimeMillis() / 1000 <= 0)
			{
				infoDisConnect = string.Empty;
			}
		}
		run();
	}

	public void init()
	{
		gameScr = new GameScr();
		loginScr = new LoginScr();
		inputDlg = new InputDlg();
		autoTab = new BangAuto();
		shop = new ShopOnline();
		cmdNgatKetNoi = new Command();
		GameData.loadbg();
		ActionPerform action = delegate
		{
			endDlg();
			instance.init();
			Session_ME.gI().close();
			Tilemap.loadMap(0, null);
			ServerListScr.gI().switchToMe();
		};
		cmdNgatKetNoi.action = action;
	}

	public void beginAutoLogin()
	{
		if (Main.isPC)
		{
			if (currentScreen != loginScr)
			{
				Command command = new Command("OK");
				command.action = delegate
				{
					endDlg();
					instance.init();
					Session_ME.gI().close();
					Tilemap.loadMap(0, null);
					ServerListScr.gI().switchToMe();
				};
				msgdlg.setInfo("Bị ngắt kết nối.", null, command, null);
				currentDialog = msgdlg;
			}
			return;
		}
		instance.timeRemove = -1L;
		infoDisConnect = "Bị ngắt kết nối.";
		xInfoDisConnect = w;
		Main.isDisConnect = true;
		ServerListScr.loadIPAuTo();
		Main.isStartSaveIp = false;
		bool isOfflineMap = Tilemap.isOfflineMap;
		endDlg();
		instance.init();
		Session_ME.gI().close();
		Tilemap.loadMap(0, null);
		menu.showMenu = false;
		if (isOfflineMap)
		{
			ServerListScr.gI().switchToMe();
		}
		else if (!ServerListScr.addressAuTo.Equals(string.Empty) && !ServerListScr.nameSvAuto.Equals(string.Empty) && ServerListScr.portAuTo != -1)
		{
			ServerListScr.doLoginAuTo();
			loginScr.doLoginAuTo();
		}
		else
		{
			ServerListScr.gI().switchToMe();
		}
	}

	public static void loadSize()
	{
		w = (int)ScaleGUI.WIDTH;
		h = (int)ScaleGUI.HEIGHT;
		hh = h / 2;
		hw = w / 2;
		w23 = w * 2 / 3;
		h23 = h * 2 / 3;
		w14 = w / 4;
		h14 = h / 4;
		w13 = w / 3;
		h13 = h / 3;
		w15 = w / 5;
		GameMidlet.hDrawStringCmd = h - 30;
	}

	public void onKeyPressed(int keyCode)
	{
		if ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 122) || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32 || keyCode == -8)
		{
			keyAsciiPress = keyCode;
		}
		if (currentScreen != null)
		{
			currentScreen.keyPress(keyCode);
		}
		if (currentDialog != null)
		{
			currentDialog.keyPress(keyCode);
		}
		mapKeyPress(keyCode);
	}

	public void onKeyReleased(int keyCode)
	{
		mapKeyRelease(keyCode);
	}

	public void sizeChanged(int w0, int h0)
	{
		loadSize();
		if (currentScreen != null)
		{
			if (currentScreen == loginScr)
			{
				loginScr.init();
			}
			gameScr.init();
			if (currentScreen == WindowInfoScr.me)
			{
				WindowInfoScr.gI().init();
			}
			if (currentScreen == MenuWindows.me)
			{
				MenuWindows.gI().init();
			}
			if (currentScreen == MenuSelectItem.me)
			{
				MenuSelectItem.gI().init();
			}
			if (currentScreen == ListScr.me)
			{
				ListScr.gI().init();
			}
			if (currentScreen == PauseMenu.me)
			{
				PauseMenu.gI().init();
			}
			if (currentScreen == MessageScr.me)
			{
				MessageScr.gI().init();
			}
			if (currentScreen == CreateCharScr.me)
			{
				CreateCharScr.gI().init();
			}
			currentScreen.init();
			if (currentDialog == inputDlg)
			{
				inputDlg.init();
			}
		}
	}

	public static int pointCmdBar()
	{
		int result = 0;
		if (isPointerDrange)
		{
			return result;
		}
		if (isPointer(0, h - MainJ2ME.hTab, Res.imgButtonBar.getWidth() + 4 * ScaleGUI.numScale, MainJ2ME.hTab))
		{
			return 1;
		}
		if (isPointer(w / 2 - Res.imgButtonBar.getWidth() / 2 - 4 * ScaleGUI.numScale, h - MainJ2ME.hTab, Res.imgButtonBar.getWidth() + 4 * ScaleGUI.numScale, MainJ2ME.hTab))
		{
			return 2;
		}
		if (isPointer(w - Res.imgButtonBar.getWidth() - 4 * ScaleGUI.numScale, h - MainJ2ME.hTab, Res.imgButtonBar.getWidth() + 4 * ScaleGUI.numScale, MainJ2ME.hTab))
		{
			return 3;
		}
		return result;
	}

	public void start()
	{
	}

	public void run()
	{
		gameTick++;
		if (gameTick > 10000)
		{
			gameTick = 0;
		}
		if (menu.showMenu)
		{
			menu.updateMenuKey();
			menu.updateMenu();
		}
		if (currentDialog != null)
		{
			currentDialog.update();
		}
		if (currentScreen != null)
		{
			currentScreen.update();
			currentScreen.updateKey();
			if (!menu.showMenu && currentDialog == null)
			{
				currentScreen.updateKey();
			}
		}
		if (timeout > 0)
		{
			timeout--;
			if (timeout == 0 && currentDialog == null)
			{
				timeoutDlg.show();
			}
		}
		clearKeyPressed();
		if (!isPointerDown)
		{
			for (int i = 0; i < GameScr.isPaintFcBt.Length; i++)
			{
				GameScr.isPaintFcBt[i] = false;
			}
		}
		if (GameScr.timePutKeyHP > 0)
		{
			GameScr.timePutKeyHP--;
			GameScr.isPaintFcBtMHP[1] = true;
		}
		else
		{
			GameScr.isPaintFcBtMHP[1] = false;
		}
		if (GameScr.timePutKeyMP > 0)
		{
			GameScr.timePutKeyMP--;
			GameScr.isPaintFcBtMHP[0] = true;
		}
		else
		{
			GameScr.isPaintFcBtMHP[0] = false;
		}
		if (isBeginAutoLogin)
		{
			beginAutoLogin();
			isBeginAutoLogin = false;
		}
		if (isConnectFail)
		{
			ActionPerform action = delegate
			{
				currentDialog = null;
				ServerListScr.gI().switchToMe();
				Session_ME.gI().close();
			};
			startOKDlg("Không thể kết nối. Vui lòng chọn server khác", action);
			Main.isDisConnect = false;
			isConnectFail = false;
		}
		if (isConnectOk)
		{
			startWaitDlg("Xin chờ..", isIcon: true);
			isConnectOk = false;
		}
	}

	public void keyPresse(int keyCode)
	{
	}

	public void keyPress(int keyCode)
	{
		if (!currentScreen.keyPress(keyCode))
		{
			mapKeyPress(keyCode);
		}
		if (currentDialog != null)
		{
			currentDialog.keyPress(keyCode);
		}
	}

	public void mapKeyPress(int keyCode)
	{
		switch (keyCode)
		{
		case 42:
			keyHold[10] = true;
			keyPressed[10] = true;
			break;
		case 35:
			keyHold[11] = true;
			keyPressed[11] = true;
			break;
		case -21:
		case -6:
			keyHold[12] = true;
			keyPressed[12] = true;
			break;
		case -22:
		case -7:
			keyHold[13] = true;
			keyPressed[13] = true;
			break;
		case -5:
		case 10:
			keyHold[5] = true;
			keyPressed[5] = true;
			break;
		case -38:
		case -1:
			keyHold[2] = true;
			keyPressed[2] = true;
			break;
		case -39:
		case -2:
			keyHold[8] = true;
			keyPressed[8] = true;
			break;
		case -3:
			keyHold[4] = true;
			keyPressed[4] = true;
			break;
		case -4:
			keyHold[6] = true;
			keyPressed[6] = true;
			break;
		case 119:
			keyHold[14] = true;
			keyPressed[14] = true;
			break;
		case 115:
			keyHold[16] = true;
			keyPressed[16] = true;
			break;
		case 97:
			keyHold[15] = true;
			keyPressed[15] = true;
			break;
		case 100:
			keyHold[17] = true;
			keyPressed[17] = true;
			break;
		case -23:
			keyHold[28] = true;
			keyPressed[28] = true;
			break;
		case 121:
			keyHold[18] = true;
			keyPressed[18] = true;
			break;
		case 117:
			keyHold[19] = true;
			keyPressed[19] = true;
			break;
		case 105:
			keyHold[20] = true;
			keyPressed[20] = true;
			break;
		case 111:
			keyHold[21] = true;
			keyPressed[21] = true;
			break;
		case 112:
			keyHold[22] = true;
			keyPressed[22] = true;
			break;
		case 103:
			keyHold[Main.isPC ? 1 : 23] = true;
			keyPressed[Main.isPC ? 1 : 23] = true;
			break;
		case 104:
			keyHold[(!Main.isPC) ? 24 : 3] = true;
			keyPressed[(!Main.isPC) ? 24 : 3] = true;
			break;
		case 106:
			keyHold[(!Main.isPC || currentDialog != null) ? 25 : ((currentScreen != gameScr || gameScr.chatMode) ? 25 : 5)] = true;
			keyPressed[(!Main.isPC || currentDialog != null) ? 25 : ((currentScreen != gameScr || gameScr.chatMode) ? 25 : 5)] = true;
			break;
		case 107:
			keyHold[(!Main.isPC) ? 26 : 7] = true;
			keyPressed[(!Main.isPC) ? 26 : 7] = true;
			break;
		case 108:
			keyHold[(!Main.isPC) ? 27 : 9] = true;
			keyPressed[(!Main.isPC) ? 27 : 9] = true;
			break;
		}
	}

	public void keyRelease(int keyCode)
	{
		mapKeyRelease(keyCode);
	}

	public void mapKeyRelease(int keyCode)
	{
		switch (keyCode)
		{
		case 42:
			keyHold[10] = false;
			keyReleased[10] = true;
			break;
		case 35:
			keyHold[11] = false;
			keyReleased[11] = true;
			break;
		case -21:
		case -6:
			keyHold[12] = false;
			keyReleased[12] = true;
			break;
		case -22:
		case -7:
			keyHold[13] = false;
			keyReleased[13] = true;
			break;
		case -5:
		case 10:
			keyHold[5] = false;
			keyReleased[5] = true;
			break;
		case -38:
		case -1:
			keyHold[2] = false;
			break;
		case -39:
		case -2:
			keyHold[8] = false;
			break;
		case -3:
			keyHold[4] = false;
			break;
		case -4:
			keyHold[6] = false;
			break;
		case 119:
			keyHold[14] = false;
			keyReleased[14] = true;
			break;
		case 115:
			keyHold[16] = false;
			keyReleased[16] = true;
			break;
		case 97:
			keyHold[15] = false;
			keyReleased[15] = true;
			break;
		case 100:
			keyHold[17] = false;
			keyReleased[17] = true;
			break;
		case -23:
			keyHold[28] = false;
			keyPressed[28] = true;
			break;
		case 121:
			keyHold[18] = false;
			keyReleased[18] = true;
			break;
		case 117:
			keyHold[19] = false;
			keyReleased[19] = true;
			break;
		case 105:
			keyHold[20] = false;
			keyReleased[20] = true;
			break;
		case 111:
			keyHold[21] = false;
			keyReleased[21] = true;
			break;
		case 112:
			keyHold[22] = false;
			keyReleased[22] = true;
			break;
		case 103:
			keyHold[Main.isPC ? 1 : 23] = false;
			keyReleased[Main.isPC ? 1 : 23] = true;
			break;
		case 104:
			keyHold[(!Main.isPC) ? 24 : 3] = false;
			keyReleased[(!Main.isPC) ? 24 : 3] = true;
			break;
		case 106:
			keyHold[(!Main.isPC) ? 25 : ((currentScreen != gameScr || gameScr.chatMode) ? 25 : 5)] = false;
			keyReleased[(!Main.isPC) ? 25 : ((currentScreen != gameScr || gameScr.chatMode) ? 25 : 5)] = true;
			break;
		case 107:
			keyHold[(!Main.isPC) ? 26 : 7] = false;
			keyReleased[(!Main.isPC) ? 26 : 7] = true;
			break;
		case 108:
			keyHold[(!Main.isPC) ? 27 : 9] = false;
			keyReleased[(!Main.isPC) ? 27 : 9] = true;
			break;
		}
	}

	public void pointerPressed1(int x, int y)
	{
		isPointerDrange1 = false;
		isPointerDown1 = true;
		px1 = x;
		py1 = y;
	}

	public void pointerDragged(int x, int y)
	{
		px = x;
		py = y;
		isPointerDrange = true;
		isMove = true;
		timePutKey = 0;
	}

	public void pointerDragged1(int x, int y)
	{
		px1 = x;
		py1 = y;
		isPointerDrange1 = true;
	}

	public void pointerPressed(int x, int y)
	{
		isPointerDrange = false;
		isPointerDown = true;
		isPointerDownItem = true;
		isPointerDownText = true;
		timePutKey++;
		isPointerDownNj = true;
		pxLast = x;
		pyLast = y;
		px = x;
		py = y;
	}

	public void pointerReleased1(int x, int y)
	{
		isPointerDown1 = false;
		isPointerDrange1 = false;
		isPointerClick1 = true;
		px1 = x;
		py1 = y;
	}

	public void pointerReleased(int x, int y)
	{
		isPointerDownItem = false;
		isPointerDownText = false;
		isPointerDown = false;
		isPointerDrange = false;
		isPointerRelease = true;
		isPointerDownNj = false;
		isPointerJustRelease = true;
		timePutKey = 0;
		if (!isMove)
		{
			isPointerClick = true;
		}
		else
		{
			isMove = false;
		}
		if (currentScreen != null)
		{
			currentScreen.btnFocus = 0;
		}
		px = x;
		py = y;
	}

	public static void clearKeyHold()
	{
		isPointerRelease = false;
		for (int i = 0; i < keyHold.Length; i++)
		{
			keyHold[i] = false;
		}
	}

	public static void clearKeyPressed()
	{
		isPointerClick = false;
		isPointerRelease = false;
		isPointerClick1 = false;
		isPointerJustRelease = false;
		for (int i = 0; i < keyPressed.Length; i++)
		{
			keyPressed[i] = false;
			if (!Main.isPC)
			{
				keyHold[i] = false;
			}
		}
	}

	public static void resetTrans(MyGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, w, h);
	}

	public void paint(MyGraphics g)
	{
		try
		{
			if (currentScreen != null)
			{
				currentScreen.paint(g);
			}
			if (currentDialog != null)
			{
				currentDialog.paint(g);
			}
			if (menu.showMenu)
			{
				menu.paintMenu(g);
			}
			if (isLoad)
			{
				resetTrans(g);
				g.setColor(0);
				g.fillRect(0, 0, w, h);
				g.drawImage(imgLogo, w / 2, h / 2, 3);
			}
			resetTrans(g);
			if (!infoDisConnect.Equals(string.Empty))
			{
				MFont.normalFont[0].drawString(g, infoDisConnect, xInfoDisConnect, 10, 2);
			}
		}
		catch (Exception ex)
		{
			Out.println(" Loi tai ham paint Can vas" + ex.ToString());
		}
	}

	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	public static void endDlg()
	{
		currentDialog = null;
	}

	public static void startYesNoDlgPutArr(string info, string[] arr, ActionPerform yesAction, ActionPerform noAction)
	{
		msgdlg.isIcon = false;
		Command command = new Command("Có");
		command.action = yesAction;
		Command command2 = new Command(string.Empty);
		command2.action = yesAction;
		Command command3 = new Command("Không");
		command3.action = noAction;
		msgdlg.setInfoArr(info, arr, command, command2, command3);
		msgdlg.show();
	}

	public static void startOKDlg(string info, bool isIcon)
	{
		msgdlg.isIcon = isIcon;
		Command command = new Command("OK");
		ActionPerform actionPerform = command.action = delegate
		{
			currentDialog = null;
		};
		msgdlg.setInfo(info, command, null, null);
		msgdlg.show();
	}

	public static void startOKDlg(string info)
	{
		startOKDlg(info, isIcon: false);
	}

	public static void startYesNoDlg(string info, ActionPerform yesAction, ActionPerform noAction)
	{
		msgdlg.isIcon = false;
		Command command = new Command("Có");
		command.action = yesAction;
		Command command2 = new Command(string.Empty);
		command2.action = yesAction;
		Command command3 = new Command("Không");
		command3.action = noAction;
		msgdlg.setInfo(info, command, command2, command3);
		msgdlg.show();
	}

	public static void startWaitDlg(string info, bool isIcon)
	{
		msgdlg.isIcon = isIcon;
		Command command = new Command("Cancel");
		ActionPerform actionPerform = command.action = delegate
		{
			currentDialog = null;
		};
		msgdlg.setInfo(info, null, command, null);
		msgdlg.show();
	}

	public static void startWaitDlg()
	{
		msgdlg.isIcon = false;
		Command command = new Command("Cancel");
		ActionPerform actionPerform = command.action = delegate
		{
			currentDialog = null;
		};
		msgdlg.setInfo("Xin chờ...", null, command, null);
		msgdlg.show();
	}

	public static void startOKDlg(string info, bool isIcon, int timeout)
	{
		Out.println(info);
		timeoutDlg.isIcon = isIcon;
		Command command = new Command("OK");
		ActionPerform actionPerform = command.action = delegate
		{
			currentDialog = null;
		};
		timeoutDlg.setInfo(info, null, command, null);
		Canvas.timeout = timeout;
	}

	public static void startOKDlg(string info, ActionPerform action)
	{
		msgdlg.isIcon = false;
		Command command = new Command("OK");
		command.action = action;
		msgdlg.setInfo(info, null, command, null);
		msgdlg.show();
	}

	public static void startOKDlg(string[] info)
	{
		startOKDlg(info, isIcon: false);
	}

	public static void startOKDlg(string[] info, bool isIcon)
	{
		msgdlg.isIcon = isIcon;
		Command command = new Command("OK");
		command.action = delegate
		{
			currentDialog = null;
		};
		msgdlg.setInfo(info, command, null, null);
		msgdlg.show();
	}

	public static void startYesNoDlg(string info, ActionPerform yesAction)
	{
		msgdlg.isIcon = false;
		Command command = new Command("Có");
		command.action = yesAction;
		Command command2 = new Command(string.Empty);
		command2.action = yesAction;
		Command command3 = new Command("Không");
		ActionPerform actionPerform = command3.action = delegate
		{
			currentDialog = null;
		};
		msgdlg.setInfo(info, command, command2, command3);
		msgdlg.show();
	}

	public static bool isKeyPressed(int index)
	{
		if (keyPressed[index])
		{
			keyPressed[index] = false;
			return true;
		}
		return false;
	}

	public static string getMoneys(long m)
	{
		string text = string.Empty;
		long num = m / 1000 + 1;
		for (int i = 0; i < num; i++)
		{
			if (m >= 1000)
			{
				long num2 = m % 1000;
				text = ((num2 != 0L) ? ((num2 >= 10) ? ((num2 >= 100) ? ("." + num2 + text) : (".0" + num2 + text)) : (".00" + num2 + text)) : (".000" + text));
				m /= 1000;
				continue;
			}
			text = m + text;
			break;
		}
		return text;
	}

	public static int collisionCmdBar()
	{
		if (isPointer(0, h - MyScreen.deltaY * 2, 100, MyScreen.deltaY * 2))
		{
			return 0;
		}
		if (isPointer(hw - 50, h - MyScreen.deltaY * 2, 100, MyScreen.deltaY * 2))
		{
			return 1;
		}
		if (isPointer(w - 100, h - MyScreen.deltaY * 2, 100, MyScreen.deltaY * 2))
		{
			return 2;
		}
		return -1;
	}

	public static bool isPointerMHP(int x, int y, int w, int h)
	{
		if (!isPointerDown1 && !isPointerClick1)
		{
			return false;
		}
		if (px1 >= x && px1 <= x + w && py1 >= y && py1 <= y + h)
		{
			return true;
		}
		return false;
	}

	public static bool isPointer(int x, int y, int w, int h)
	{
		if (!isPointerDown && !isPointerClick)
		{
			return false;
		}
		if (px >= x && px <= x + w && py >= y && py <= y + h)
		{
			return true;
		}
		return false;
	}

	public static string getPriceMoney(long xu, int gold)
	{
		string text = string.Empty;
		if (xu > 0)
		{
			text = text + getMoneys(xu) + "Xu";
		}
		if (gold > 0)
		{
			if (xu > 0)
			{
				text += " - ";
			}
			text = text + getMoneys(gold) + "Luong";
		}
		return text;
	}

	public static int dy()
	{
		return pyLast - py;
	}

	public static int dx()
	{
		return pxLast - px;
	}

	public static bool beginMoveCmrY()
	{
		if (Math.abs(py - pyLast) >= 10)
		{
			return true;
		}
		return false;
	}

	public static bool beginMoveCmrX()
	{
		if (Math.abs(px - pxLast) >= 10)
		{
			return true;
		}
		return false;
	}

	public static string formatNumberDotK(int number)
	{
		string text = string.Empty;
		string text2 = string.Empty + number;
		if (text2.Length <= 3)
		{
			return text2;
		}
		for (int num = text2.Length - 1; num >= 0; num--)
		{
			text = (((text2.Length - num) % 3 != 0 || num <= 0) ? (text + text2[num]) : (text + text2[num] + "."));
		}
		return text;
	}

	public static bool isPointerNj(int x, int y, int w, int h)
	{
		if (!isPointerDownNj && !isPointerJustRelease)
		{
			return false;
		}
		if (px >= x && px <= x + w && py >= y && py <= y + h)
		{
			return true;
		}
		return false;
	}

	public static bool isPointerHoldIn(int x, int y, int w, int h)
	{
		if (!isPointerDownNj && !isPointerJustRelease)
		{
			return false;
		}
		if (px >= x && px <= x + w && py >= y && py <= y + h)
		{
			return true;
		}
		return false;
	}

	public static int random(int a, int b)
	{
		return a + r.nextInt(b - a);
	}

	public static bool canTouch()
	{
		return Math.abs(px - pxLast) < 10 && Math.abs(py - pyLast) < 10;
	}
}
