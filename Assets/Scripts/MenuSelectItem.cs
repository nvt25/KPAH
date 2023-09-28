public class MenuSelectItem : MyScreen
{
	public int width;

	public int height;

	public int x1;

	public int y1;

	public int x2;

	public int y2;

	public static Image imgIChat;

	public static Image imgIChange;

	public static Image imgINapxu;

	public static Image imgIDosat;

	public static Image imgIXuongngua;

	public static Image imgIDangxuat;

	public static Image imgIThoat;

	public static Image imgWap36;

	public static Image imgWap;

	public static MenuSelectItem me;

	private int xB = 20;

	private int ww;

	private int wT;

	private Command cmdChat;

	private int selected;

	public static bool isClose;

	public MenuSelectItem()
	{
		ActionPerform action = delegate
		{
			Canvas.gameScr.switchToMe();
		};
		right = new Command();
		right.action = action;
		if (imgWap == null)
		{
			imgWap = Image.createImage(Main.res + "/wap");
			imgWap36 = Image.createImage(Main.res + "/wap36");
		}
	}

	public static MenuSelectItem gI()
	{
		return (me != null) ? me : (me = new MenuSelectItem());
	}

	public override void switchToMe()
	{
		base.switchToMe();
		init();
	}

	public override void init()
	{
		width = (height = 40);
		y1 = Canvas.h - 160;
		y2 = Canvas.h - 50;
		cmdChat = new Command();
		ActionChat actionChat = delegate(string str)
		{
			Canvas.gameScr.doChatFromMe(str);
		};
		cmdChat.actionChat = actionChat;
		ww = imgIChange.getWidth();
		wT = 8 * ww + 7 * (ww / 2);
	}

	public override void update()
	{
		Canvas.gameScr.update();
		y1 += 4;
		if (y1 > Canvas.h - 130)
		{
			y1 = Canvas.h - 130;
		}
		y2 -= 4;
		if (y2 < Canvas.h - 80)
		{
			y2 = Canvas.h - 80;
		}
		if (Canvas.currentDialog != null)
		{
			return;
		}
		if (Canvas.isPointer(xB + (ww + ww / 2), Canvas.h - 130, wT, 90))
		{
			int num = selected = (Canvas.px - (xB + (ww + ww / 2))) / (ww + ww / 2);
			if (Canvas.isPointerClick && Math.abs(Canvas.pxLast - Canvas.px) < 10 && Math.abs(Canvas.pyLast - Canvas.py) < 10)
			{
				Canvas.isPointerClick = false;
				switch (selected)
				{
				case 0:
				{
					if (!Main.isPC)
					{
						ipKeyboard.openKeyBoard("chat", ipKeyboard.TEXT, string.Empty, cmdChat);
						Canvas.gameScr.switchToMe();
						break;
					}
					Canvas.gameScr.switchToMe();
					Canvas.gameScr.chatMode = true;
					Canvas.endDlg();
					ActionPerform ok = delegate
					{
						Canvas.gameScr.doChatFromMe(Canvas.inputDlg.tfInput.getText());
						Canvas.inputDlg.tfInput.setText(string.Empty);
					};
					Canvas.inputDlg.setInfo("Nội dung Chat", ok, TField.INPUT_TYPE_ANY, 100, isMaxW: false);
					Canvas.inputDlg.show();
					break;
				}
				case 1:
					GameService.gI().setConfig(6);
					Canvas.endDlg();
					Canvas.gameScr.mainChar.posTransRoad = null;
					break;
				case 2:
					Canvas.gameScr.doNapXu();
					Canvas.gameScr.switchToMe();
					break;
				case 3:
					Canvas.gameScr.gameService.requestKiller();
					Canvas.gameScr.switchToMe();
					break;
				case 4:
					Canvas.gameScr.unRideHorse();
					Canvas.gameScr.mainChar.posTransRoad = null;
					break;
				case 5:
					if (Tilemap.lv == 0 || Tilemap.lv == 201 || Tilemap.lv == 70 || Tilemap.lv == 80)
					{
						Canvas.startOKDlg("Không thể bật auto ở đây.");
						break;
					}
					Canvas.autoTab.switchToMe();
					Canvas.clearKeyHold();
					Canvas.clearKeyPressed();
					return;
				case 6:
				{
					ActionPerform yesAction = delegate
					{
						Canvas.instance.init();
						Session_ME.gI().close();
						Tilemap.loadMap(0, null);
						ServerListScr.gI().switchToMe();
						Main.isStartSaveIp = false;
						Canvas.endDlg();
					};
					ActionPerform noAction = delegate
					{
						Canvas.gameScr.switchToMe();
						Canvas.endDlg();
					};
					Canvas.startYesNoDlg("Bạn có muốn chọn lại máy chủ không ?", yesAction, noAction);
					break;
				}
				case 7:
					if (GameMidlet.url != string.Empty)
					{
						GameMidlet.requestLink(GameMidlet.url);
					}
					break;
				}
			}
		}
		else if (Canvas.isPointerClick)
		{
			if (Main.canvas.canPutKey())
			{
				right.perform();
				isClose = true;
			}
			Canvas.isPointerClick = false;
		}
		base.update();
	}

	public override void paint(MyGraphics g)
	{
		Canvas.gameScr.paint(g);
		Image[] array = new Image[8]
		{
			imgIChat,
			imgIChange,
			imgINapxu,
			imgIDosat,
			imgIXuongngua,
			Res.icon_automode,
			imgIDangxuat,
			imgWap
		};
		for (int i = 0; i < 8; i++)
		{
			g.drawImage(array[i], xB + (i + 1) * (ww + ww / 2), y1, 0);
		}
		base.paint(g);
	}
}
