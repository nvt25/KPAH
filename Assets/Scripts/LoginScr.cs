using System;

public class LoginScr : MyScreen
{
	public TField tfUser;

	public TField tfPass;

	private int focus;

	private int xC;

	private int wC;

	private int yL;

	private int defYL;

	public bool isRememPass;

	private Command cmdRemem;

	private Command cmdLogin;

	public static string nameServer = string.Empty;

	public static string userAuto = string.Empty;

	public static string passAuTo = string.Empty;

	private ActionPerform acRemen;

	private int xTo;

	private int yTo;

	private int centerX = 160;

	private int centerY = 160;

	private int radius = 128;

	private int goc;

	private int index;

	private int tick;

	public LoginScr()
	{
		wC = 160;
		xC = (Canvas.w - wC >> 1) + 45;
		tfUser = new TField();
		tfUser.height = MyScreen.ITEM_HEIGHT + 2;
		tfUser.x = xC;
		tfUser.y = Canvas.h / 2 - 90;
		tfUser.width = wC;
		tfUser.setText(string.Empty);
		tfUser.isFocus = true;
		tfUser.showSubTextField = false;
		tfUser.setIputType(TField.INPUT_ALPHA_NUMBER_ONLY);
		tfPass = new TField();
		tfPass.y = Canvas.h / 2 - 45;
		tfPass.height = MyScreen.ITEM_HEIGHT + 2;
		tfPass.isFocus = false;
		tfPass.setText(string.Empty);
		tfPass.x = xC;
		tfPass.width = wC;
		tfPass.showSubTextField = false;
		tfPass.setIputType(TField.INPUT_TYPE_PASSWORD);
		loadPass();
		cmdLogin = new Command("Đăng Nhập");
		ActionPerform action = delegate
		{
			doLogin();
		};
		cmdLogin.action = action;
		center = cmdLogin;
		cmdRemem = new Command("Nhớ");
		ActionPerform action2 = acRemen = delegate
		{
			isRememPass = !isRememPass;
		};
		left = new Command("Máy chủ");
		ActionPerform action3 = delegate
		{
			ServerListScr.me.switchToMe();
			Session_ME.connected = false;
			Session_ME.connecting = false;
		};
		left.action = action3;
		right = new Command("Đăng ký");
		cmdRemem.action = action2;
		ActionPerform action4 = delegate
		{
			doRegister();
		};
		right.action = action4;
		GameMidlet.numberSupport = loadnumber();
	}

	public override void init()
	{
	}

	private string loadnumber()
	{
		string text = RMS.loadRMSString("numbersupport");
		if (text == null)
		{
			return GameMidlet.numberSupport;
		}
		return text;
	}

	public void doLogin()
	{
		string text = tfUser.getText().ToLower().Trim();
		string text2 = tfPass.getText();
		userAuto = string.Empty;
		passAuTo = string.Empty;
		if (!text.Equals(string.Empty))
		{
			if (text2.Equals(string.Empty))
			{
				focus = 1;
				tfUser.isFocus = false;
				tfPass.isFocus = true;
				return;
			}
			userAuto = text.ToLower();
			passAuTo = text2;
			Canvas.startWaitDlg("Đang kết nối", isIcon: true);
			Canvas.connect();
			GameService.gI().setClientType();
			GameService.gI().login(text.ToLower(), text2, GameMidlet.version);
			GameScr.saveAutoFight = false;
			GameScr.reSetQuest();
		}
	}

	public void reloadData()
	{
		tfUser.y = Canvas.hh - 5;
		tfPass.y = Canvas.hh + 33;
	}

	protected void doRegister()
	{
		string text = tfUser.getText().ToLower().Trim();
		string text2 = tfPass.getText();
		if (text.Equals(string.Empty))
		{
			Canvas.startOKDlg("Vui lòng nhập Game ID muốn đăng ký vào ô trên.");
		}
		else if (text2.Equals(string.Empty))
		{
			Command command = new Command("OK");
			ActionPerform actionPerform = command.action = delegate
			{
				focus = 1;
				tfUser.isFocus = false;
				tfPass.isFocus = true;
				Canvas.endDlg();
			};
			Canvas.msgdlg.setInfo("Bạn phải nhập password đăng ký.", null, command, null);
			Canvas.msgdlg.show();
		}
		else
		{
			Canvas.msgdlg.isIcon = false;
			Command command2 = new Command("Có");
			ActionPerform actionPerform2 = command2.action = delegate
			{
				doSendRegisterInfo();
			};
			Command command3 = new Command("Không");
			ActionPerform actionPerform3 = command3.action = delegate
			{
				Canvas.endDlg();
			};
			Canvas.msgdlg.setInfo("Bạn có muốn đăng ký tài khoản: " + text + " không?", command2, null, command3);
			Canvas.currentDialog = Canvas.msgdlg;
		}
	}

	protected void doSendRegisterInfo()
	{
		if (!Session_ME.connected)
		{
			Canvas.startWaitDlg("Vui lòng thoát game và chờ trong ít phút", isIcon: true);
			Canvas.connect();
		}
		else
		{
			Canvas.startWaitDlg("Vui lòng thoát game và chờ trong ít phút", isIcon: true);
		}
		GameService.gI().requestRegister(tfUser.getText().ToLower(), tfPass.getText());
	}

	public override bool keyPress(int keyCode)
	{
		if (tfUser.isFocus)
		{
			if (tfUser.keyPressed(keyCode))
			{
				return true;
			}
		}
		else if (tfPass.isFocus && tfPass.keyPressed(keyCode))
		{
			return true;
		}
		return base.keyPress(keyCode);
	}

	public override void paint(MyGraphics g)
	{
		ServerListScr.gI().paintBg(g);
		Canvas.resetTrans(g);
		MFont.borderFont.drawString(g, nameServer, 4, 2, 0);
		paintPanel(g);
	}

	private void paintPanel(MyGraphics g)
	{
		Res.paintDlgDragonFull(g, Canvas.w / 2 - 150, Canvas.h / 2 - 120, 300, 190);
		MFont.normalFont[0].drawString(g, "Game ID:", tfUser.x - 85, tfUser.y + 5, 0);
		MFont.normalFont[0].drawString(g, "Password:", tfPass.x - 85, tfPass.y + 5, 0);
		tfUser.paint(g);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		tfPass.paint(g);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		g.drawRegion(Res.imgCheck, 0, ((focus == 2) ? 1 : 0) * 11, 18, 11, 0, tfUser.x + 6, Canvas.hh + 19, 27);
		if (isRememPass)
		{
			g.drawRegion(Res.imgCheck, 0, 22, 18, 11, 0, tfUser.x + 6, Canvas.hh + 19, 27);
		}
		MFont.normalFont[0].drawString(g, "Nhớ mật khẩu", tfUser.x + 10, Canvas.h / 2 + 12, 0);
		MFont.borderFont.drawString(g, "Hotline: " + GameMidlet.numberSupport, Canvas.hw, Canvas.hh + 50, 2);
		base.paint(g);
	}

	public override void switchToMe()
	{
		base.switchToMe();
		init();
	}

	public override void update()
	{
		updatePoinTer();
		tfUser.update();
		tfPass.update();
		if (tick < 20)
		{
			tick++;
			if (tick == 20)
			{
				Canvas.gameScr.tfChat.x = 2;
				Canvas.gameScr.tfChat.y = Canvas.h - 40;
			}
		}
		if (Canvas.keyPressed[2])
		{
			index++;
			if (index >= 52)
			{
				index = 0;
			}
		}
		bool flag = false;
		if (Canvas.isKeyPressed(2) || Canvas.isKeyPressed(28))
		{
			focus--;
			if (focus < 0)
			{
				focus = 2;
			}
			flag = true;
		}
		else if (Canvas.isKeyPressed(8) || Canvas.isKeyPressed(28))
		{
			focus++;
			if (focus > 2)
			{
				focus = 0;
			}
			flag = true;
		}
		if (flag)
		{
			if (focus == 1)
			{
				tfUser.isFocus = false;
				tfPass.isFocus = true;
				center = cmdLogin;
			}
			else if (focus == 0)
			{
				tfUser.isFocus = true;
				tfPass.isFocus = false;
				center = cmdLogin;
			}
			else
			{
				tfUser.isFocus = false;
				tfPass.isFocus = false;
				center = cmdRemem;
			}
		}
		updateCamera();
		base.update();
	}

	public void updatePoinTer()
	{
		if (Canvas.isPointerClick)
		{
			int num = 0;
			if (Canvas.w > 200)
			{
				num = 10;
			}
			if (Canvas.isPointer(xC - 30 + num, Canvas.hh + 11, 100, 60))
			{
				isRememPass = !isRememPass;
			}
		}
	}

	public void updateCamera()
	{
		goc++;
		if (goc > 360)
		{
			goc = 0;
		}
		xTo = Util.Cos(goc) * radius >> 10;
		yTo = Util.Sin(goc) * radius >> 10;
		GameScr.cmtoX = xTo + centerX;
		GameScr.cmtoY = yTo + centerY;
		Canvas.gameScr.updateCamera();
	}

	public void savePass()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeBoolean(isRememPass);
			if (isRememPass)
			{
				dataOutputStream.writeUTF(tfUser.getText());
				dataOutputStream.writeUTF(tfPass.getText());
			}
			RMS.saveRMS("nqshlogin", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Out.println(ex.StackTrace);
		}
	}

	public void doLoginAuTo()
	{
		if (!ServerListScr.addressAuTo.Equals(string.Empty) && !ServerListScr.nameSvAuto.Equals(string.Empty) && ServerListScr.portAuTo != -1)
		{
			string text = userAuto.ToLower().Trim();
			string text2 = passAuTo;
			Out.println("user : " + text + "  pass " + text2);
			if (!text.Equals(string.Empty) && !text2.Equals(string.Empty))
			{
				Canvas.startWaitDlg("Đang kết nối", isIcon: true);
				Canvas.connectAuTo();
				GameService.gI().setClientType();
				GameService.gI().login(text.ToLower(), text2, GameMidlet.version);
			}
		}
	}

	private void loadPass()
	{
		sbyte[] array = RMS.loadRMS("nqshlogin");
		if (array != null)
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			try
			{
				isRememPass = dataInputStream.readBoolean();
				if (isRememPass)
				{
					tfUser.setText(dataInputStream.readUTF());
					tfUser.setOffset();
					tfPass.setText(dataInputStream.readUTF());
					tfPass.setOffset();
					userAuto = tfUser.getText();
					passAuTo = tfPass.getText();
				}
				dataInputStream.close();
			}
			catch (Exception ex)
			{
				Out.println(ex.StackTrace);
			}
		}
	}
}
