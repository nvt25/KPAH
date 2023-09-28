public class CharSelectScr : MyScreen
{
	public static CharSelectScr me;

	public MainChar[] charInfos;

	private MainChar[] chars;

	public int selected;

	public Command cmdSelect;

	public Command cmdNew;

	public Command cmdDel;

	public Command cmdClose;

	public static Image imgBg;

	public static CharSelectScr gI()
	{
		return (me != null) ? me : (me = new CharSelectScr());
	}

	public override bool keyPress(int keyCode)
	{
		return base.keyPress(keyCode);
	}

	public override void paint(MyGraphics g)
	{
		ServerListScr.gI().paintBg(g);
		Canvas.resetTrans(g);
		MFont.borderFont.drawString(g, LoginScr.nameServer, 4, 2, 0);
		MFont.borderFont.drawString(g, "Chọn nhân vật:", Canvas.hw, Canvas.hh - 65, 2);
		int num = Canvas.hw - 100;
		int num2 = Canvas.hh - 30;
		int num3 = 0;
		int num4 = num;
		while (num3 < 3)
		{
			g.setColor(1379840);
			g.fillRect(num4 + 2, num2 - 11, 36, 86);
			if (num3 == selected)
			{
				g.setColor(15769344);
				if (num3 < charInfos.Length)
				{
					g.setColor((charInfos.Length <= 0) ? 15769344 : ((charInfos[num3].isusing != 1) ? 2205861 : 15769344));
				}
			}
			else
			{
				g.setColor(10644224);
				if (num3 < charInfos.Length)
				{
					g.setColor((charInfos.Length <= 0) ? 10644224 : ((charInfos[num3].isusing != 1) ? 34949 : 10644224));
				}
			}
			g.fillRect(num4 + 3, num2 - 10, 34, 84);
			if (num3 < chars.Length)
			{
				chars[num3].x = (short)(num4 + 20);
				chars[num3].y = (short)(num2 + 64);
				chars[num3].paintAvatar(g, chars[num3].x, chars[num3].y);
			}
			num3++;
			num4 += 83;
		}
		if (chars != null && charInfos != null && chars.Length > 0 && selected < chars.Length && charInfos.Length > 0)
		{
			short num5 = 0;
			num5 = (short)((charInfos[selected].lastLv <= 0) ? 1 : charInfos[selected].lastLv);
			MFont.borderFont.drawString(g, charInfos[selected].name + " lv: " + num5, Canvas.hw, Canvas.hh + 55, 2);
			if (charInfos[selected].isusing == 0)
			{
				MFont.borderFont.drawString(g, "Còn lại: " + charInfos[selected].day + " ngày", Canvas.hw, Canvas.hh + 58, 2);
			}
			if (charInfos[selected].nationID != -1)
			{
				int width = MFont.borderFont.getWidth(charInfos[selected].name + " lv: " + num5);
				g.drawRegion(Res.imgNation, 0, charInfos[selected].nationID * 11, 11, 11, 0, Canvas.hw - width / 2 - 15, Canvas.hh + 60, 20);
			}
		}
		base.paint(g);
	}

	public override void pointerPress(int dx, int dy)
	{
		base.pointerPress(dx, dy);
	}

	public override void switchToMe()
	{
		base.switchToMe();
	}

	public override void update()
	{
		Canvas.loginScr.updateCamera();
		for (int i = 0; i < chars.Length; i++)
		{
			chars[i].update();
		}
		bool flag = false;
		if (Canvas.isKeyPressed(4))
		{
			selected--;
			flag = true;
			if (selected < 0)
			{
				selected = 2;
			}
			if (charInfos.Length > 0)
			{
				if (selected < charInfos.Length)
				{
					if (charInfos[selected].isusing == 1)
					{
						cmdDel.caption = "Xóa";
					}
					else
					{
						cmdDel.caption = "Khôi phục";
					}
				}
				else
				{
					cmdDel.caption = string.Empty;
				}
			}
		}
		else if (Canvas.isKeyPressed(6))
		{
			selected++;
			flag = true;
			if (selected > 2)
			{
				selected = 0;
			}
			if (charInfos.Length > 0)
			{
				if (selected < charInfos.Length)
				{
					if (charInfos[selected].isusing == 1)
					{
						cmdDel.caption = "Xóa";
					}
					else
					{
						cmdDel.caption = "Khôi phục";
					}
				}
				else
				{
					cmdDel.caption = string.Empty;
				}
			}
		}
		int num = -1;
		if (Canvas.isPointer(Canvas.hw - 100, Canvas.hh - 40, 200, 84) && Canvas.isPointerClick)
		{
			Canvas.isPointerClick = false;
			int num2 = Canvas.hw - 100;
			flag = true;
			num = (Canvas.px - num2) / 60;
			if (num > 2)
			{
				num = 2;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (selected != num)
			{
				selected = num;
				if (charInfos.Length > 0)
				{
					if (selected < charInfos.Length)
					{
						if (charInfos[selected].isusing == 1)
						{
							cmdDel.caption = "Xóa";
						}
						else
						{
							cmdDel.caption = "Khôi phục";
						}
					}
					else
					{
						cmdDel.caption = string.Empty;
					}
				}
			}
			else
			{
				doSelectChar();
				flag = false;
			}
		}
		if (!Main.isPC)
		{
			if (flag)
			{
				if (selected < chars.Length)
				{
					center = cmdSelect;
					left = cmdDel;
				}
				else
				{
					CreateCharScr.gI().switchToMe();
					center = null;
					left = null;
				}
			}
		}
		else if (flag)
		{
			if (selected < chars.Length)
			{
				center = cmdSelect;
				left = cmdDel;
			}
			else
			{
				center = cmdNew;
				left = null;
			}
			if (num == selected)
			{
				center.perform();
			}
			if (num < 3 && num >= 0)
			{
				selected = num;
			}
		}
		base.update();
	}

	public void doSelectChar()
	{
		if (selected >= 0 && selected <= charInfos.Length - 1 && charInfos[selected].isusing != 0)
		{
			Canvas.startWaitDlg("Xin chờ..", isIcon: true);
			GameService.gI().selectChar(charInfos[selected].IDDB, 1);
			Canvas.gameScr.mainChar.imgWpa = chars[selected].imgWpa;
			Canvas.gameScr.mainChar.dxWear = chars[selected].dxWear;
			Canvas.gameScr.mainChar.dyWear = chars[selected].dyWear;
			ChangScr.gI().switchToMe();
			chars = null;
			me = null;
		}
	}

	public override void updateKey()
	{
		base.updateKey();
	}

	public void setCharList(MainChar[] charInfos)
	{
		if (!Session_ME.connected)
		{
			return;
		}
		if (Canvas.loginScr != null)
		{
			Canvas.loginScr.savePass();
		}
		if (!Canvas.gameScr.isNewVersionAvailable)
		{
			Canvas.endDlg();
		}
		this.charInfos = charInfos;
		chars = new MainChar[charInfos.Length];
		chars = charInfos;
		cmdSelect = new Command("Chọn");
		ActionPerform action = delegate
		{
			doSelectChar();
		};
		cmdSelect.action = action;
		cmdNew = new Command("Tạo mới");
		ActionPerform action2 = delegate
		{
			CreateCharScr.gI().switchToMe();
		};
		cmdNew.action = action2;
		cmdDel = new Command("Xóa");
		ActionPerform action3 = delegate
		{
			if (cmdDel.caption.Equals("Xóa"))
			{
				ActionPerform yesAction = delegate
				{
					Canvas.startWaitDlg("Xin chờ..", isIcon: true);
					GameService.gI().selectChar(this.charInfos[selected].IDDB, 2);
				};
				ActionPerform noAction = delegate
				{
					Canvas.currentDialog = null;
				};
				Canvas.startYesNoDlg("Bạn thật sự muốn xóa nhân vật này?", yesAction, noAction);
			}
			else if (cmdDel.caption.Equals("Khôi phục"))
			{
				ActionPerform yesAction2 = delegate
				{
					Canvas.startWaitDlg("Xin chờ..", isIcon: true);
					GameService.gI().selectChar(this.charInfos[selected].IDDB, 3);
				};
				ActionPerform noAction2 = delegate
				{
					Canvas.currentDialog = null;
				};
				Canvas.startYesNoDlg("Bạn muốn khôi phục nhân vật này?", yesAction2, noAction2);
			}
		};
		cmdDel.action = action3;
		ActionPerform action4 = delegate
		{
			Session_ME.gI().close();
			ServerListScr.gI().switchToMe();
			Main.isStartSaveIp = false;
		};
		cmdClose = new Command("Thoát");
		cmdClose.action = action4;
		if (selected < chars.Length)
		{
			center = cmdSelect;
			left = cmdDel;
		}
		else
		{
			center = cmdNew;
			left = null;
		}
		right = cmdClose;
		if (charInfos.Length <= 0)
		{
			return;
		}
		if (selected >= 0 && selected < charInfos.Length)
		{
			if (charInfos[selected].isusing == 1)
			{
				cmdDel.caption = "Xóa";
			}
			else
			{
				cmdDel.caption = "Khôi phục";
			}
		}
		else
		{
			selected = 0;
		}
	}
}
