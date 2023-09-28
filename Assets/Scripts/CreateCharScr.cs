public class CreateCharScr : MyScreen
{
	public static CreateCharScr me;

	public static CharClassInfo[][] clazz = new CharClassInfo[5][]
	{
		new CharClassInfo[2]
		{
			new CharClassInfo(0, "Kiếm Khách", "Nam", "Kiếm", "Mien Bac", "Kim", 3, 0),
			new CharClassInfo(0, "Kiếm Khách", "Nữ", "Kiếm", "Mien Bac", "Kim", 3, 0)
		},
		new CharClassInfo[2]
		{
			new CharClassInfo(1, "Chiến Binh", "Nam", "Đại Đao", "Mien Bac", "Hỏa", 4, 0),
			new CharClassInfo(1, "Chiến Binh", "Nữ", "Đại Đao", "Mien Bac", "Hỏa", 4, 0)
		},
		new CharClassInfo[2]
		{
			new CharClassInfo(2, "Pháp Sư", "Nam", "Đũa thần", "Mien Nam", "Thủy", 5, 0),
			new CharClassInfo(2, "Pháp Sư", "Nữ", "Đũa thần", "Mien Nam", "Thủy", 5, 0)
		},
		new CharClassInfo[2]
		{
			new CharClassInfo(3, "Đấu sĩ", "Nam", "Rìu", "Mien Nam", "Thổ", 6, 0),
			new CharClassInfo(3, "Đấu sĩ", "Nữ", "Rìu", "Mien Nam", "Thổ", 6, 0)
		},
		new CharClassInfo[2]
		{
			new CharClassInfo(4, "Cung Thủ", "Nam", "Cung", "Mien Bac", "Mộc", 7, 0),
			new CharClassInfo(4, "Cung Thủ", "Nữ", "Cung", "Mien Bac", "Mộc", 7, 0)
		}
	};

	public static string[] hairName = new string[6]
	{
		"Đầu đinh",
		"Tóc búi",
		"Tóc cột cao",
		"Tóc chéo",
		"Tóc xù",
		"Tóc ngang vai"
	};

	private static string[] gender = new string[2]
	{
		"Nam",
		"Nữ"
	};

	public static int selectGender = 0;

	public static int selectNation = 0;

	public TField tfChat;

	private Command cmdClear;

	public MainChar ch = new MainChar();

	private int currentClazz;

	private int selected;

	private int xL;

	private int xR;

	public CreateCharScr()
	{
		tfChat = new TField(this);
		tfChat.width = 125;
		tfChat.height = 21;
		tfChat.isFocus = true;
		tfChat.setIputType(TField.INPUT_ALPHA_NUMBER_ONLY);
		ch.state = 0;
		currentClazz = 0;
		ch.hatStyle = -1;
		ch.currentHead = clazz[currentClazz][selectGender].headID;
		ch.bodyStyle = clazz[currentClazz][selectGender].bodyID;
		ch.legStyle = clazz[currentClazz][selectGender].legID;
		ch.weaponType = clazz[currentClazz][selectGender].weaponType;
		ch.weaponStyle = clazz[currentClazz][selectGender].weaponImageID;
		left = new Command("Đóng");
		ActionPerform action = delegate
		{
			CharSelectScr.gI().switchToMe();
			me = null;
		};
		left.action = action;
		cmdClear = new Command("Xóa");
		ActionPerform action2 = delegate
		{
			tfChat.clear();
		};
		cmdClear.action = action2;
		center = new Command("Tạo");
		ActionPerform action3 = delegate
		{
			if (tfChat.getText().Length < 4 || tfChat.getText().Length > 15)
			{
				Canvas.startOKDlg("Tên nhân vật phải từ 4 đến 15 ký tự");
			}
			else
			{
				GameService.gI().createChar(tfChat.getText(), currentClazz, clazz[currentClazz][selectGender].headID, selectGender, selectNation);
				Canvas.startWaitDlg("Xin chờ", isIcon: true);
			}
		};
		center.action = action3;
		init();
	}

	public static CreateCharScr gI()
	{
		return (me != null) ? me : (me = new CreateCharScr());
	}

	public override void switchToMe()
	{
		loadImg();
		base.switchToMe();
		selectNation = 0;
	}

	public override void init()
	{
		tfChat.x = Canvas.hw - 155;
		tfChat.y = Canvas.hh + 25;
	}

	private void changChar()
	{
		ch.currentHead = clazz[currentClazz][selectGender].headID;
		ch.bodyStyle = clazz[currentClazz][selectGender].bodyID;
		ch.legStyle = clazz[currentClazz][selectGender].legID;
		ch.weaponType = clazz[currentClazz][selectGender].weaponType;
		ch.weaponStyle = clazz[currentClazz][selectGender].weaponImageID;
	}

	private void loadImg()
	{
		GameService.gI().doRequestWeapone(0, ch.weaponType, ch.weaponStyle, ch.weaponIndex);
	}

	public override bool keyPress(int keyCode)
	{
		bool flag = false;
		tfChat.keyPressed(keyCode);
		return base.keyPress(keyCode);
	}

	public void updateKeyPT()
	{
		bool flag = false;
		if (Canvas.isPointer(Canvas.hw, Canvas.hh - 90, 180, 170) && Canvas.isPointerClick)
		{
			Canvas.isPointerClick = false;
			int num = (Canvas.py - (Canvas.hh - 90)) / 30;
			if (num > 3)
			{
				num = 3;
			}
			if (selected != num)
			{
				selected = num;
			}
			if (Canvas.px >= Canvas.hw && Canvas.px <= Canvas.hw + 80)
			{
				xL = 5;
				if (selected == 0)
				{
					currentClazz++;
					if (currentClazz >= 5)
					{
						currentClazz = 0;
					}
					flag = true;
				}
				else if (selected == 1)
				{
					selectGender = ((selectGender != 1) ? 1 : 0);
					changChar();
				}
				else if (selected == 2)
				{
					clazz[currentClazz][selectGender].headID -= 2;
					if (clazz[currentClazz][selectGender].headID < 0)
					{
						clazz[currentClazz][selectGender].headID = (byte)(4 + clazz[currentClazz][selectGender].headID);
					}
					flag = true;
				}
				else if (selected == 3)
				{
					selectNation--;
					if (selectNation < 0)
					{
						selectNation = 1;
					}
				}
			}
			else if (Canvas.px <= Canvas.hw + 180 && Canvas.px >= Canvas.hw + 90)
			{
				xR = 5;
				if (selected == 0)
				{
					currentClazz--;
					if (currentClazz < 0)
					{
						currentClazz = 4;
					}
					flag = true;
				}
				else if (selected == 1)
				{
					selectGender = ((selectGender == 0) ? 1 : 0);
					changChar();
				}
				else if (selected == 2)
				{
					clazz[currentClazz][selectGender].headID += 2;
					if (clazz[currentClazz][selectGender].headID > 5)
					{
						clazz[currentClazz][selectGender].headID = (sbyte)(clazz[currentClazz][selectGender].headID % 2);
					}
					flag = true;
				}
				else if (selected == 3)
				{
					selectNation++;
					if (selectNation > 1)
					{
						selectNation = 0;
					}
				}
			}
		}
		if (flag)
		{
			ch.bodyStyle = clazz[currentClazz][selectGender].bodyID;
			ch.legStyle = clazz[currentClazz][selectGender].legID;
			ch.currentHead = clazz[currentClazz][selectGender].headID;
			ch.weaponType = clazz[currentClazz][selectGender].weaponType;
			ch.weaponStyle = clazz[currentClazz][selectGender].weaponImageID;
			loadImg();
		}
	}

	public override void pointerPress(int dx, int dy)
	{
		base.pointerPress(dx, dy);
	}

	public override void paint(MyGraphics g)
	{
		ServerListScr.gI().paintBg(g);
		Canvas.resetTrans(g);
		int num = Canvas.hw + 35;
		int num2 = Canvas.hh - 70;
		Res.paintDlgDragonFull(g, Canvas.hw - 190, Canvas.hh - 90, 380, 170);
		int num3 = Canvas.hw - 1;
		int num4 = Canvas.hh - 89;
		for (int i = 0; i < 3; i++)
		{
			g.setColor(Res.color[i]);
			g.fillRect(num3 + i, num4 + i, 1, 168);
		}
		g.drawImage(Res.imgBar, num - 25 - xL, num2 + selected * 30 + 7, 3);
		g.drawRegion(Res.imgBar, 0, 0, 11, 7, 2, Canvas.hw + 175 + xR, num2 + selected * 30 + 7, 3);
		MFont.normalFont[0].drawString(g, "Tên:", tfChat.x, Canvas.hh + 10, 0);
		MFont.normalFont[0].drawString(g, "Dòng: " + clazz[currentClazz][selectGender].name, num - 5, num2, 0);
		num2 += 30;
		MFont.normalFont[0].drawString(g, "Giới tính: " + gender[selectGender], num - 5, num2, 0);
		num2 += 30;
		MFont.normalFont[0].drawString(g, "Tóc: " + hairName[clazz[currentClazz][selectGender].headID], num - 5, num2, 0);
		num2 += 30;
		MFont.normalFont[0].drawString(g, "Lãnh thổ: " + GameScr.nameCountry[selectNation], num - 5, num2, 0);
		num2 += 30;
		MFont.normalFont[0].drawString(g, "Ngũ hành: " + clazz[currentClazz][selectGender].element, num - 5, num2, 0);
		ch.paintAvatar(g, (short)(Canvas.hw - 85), (short)(Canvas.hh + 10));
		if (ch.weaponType != -1 && ch.weaponStyle != -1 && ch.imgWpa != null)
		{
			int num5 = (ch.frame == 1) ? 1 : 0;
			g.drawImage(ch.imgWpa, Canvas.hw - 85 + ch.dxWear, Canvas.hh + 10 + ch.dyWear + num5, 0);
		}
		tfChat.paint(g);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		base.paint(g);
	}

	public override void update()
	{
		tfChat.update();
		ch.update();
		base.update();
		updateKeyPT();
		if (Canvas.gameTick % 4 == 0)
		{
			if (xL > 0)
			{
				xL--;
			}
			else
			{
				xL = 0;
			}
			if (xR > 0)
			{
				xR--;
			}
			else
			{
				xR = 0;
			}
		}
	}
}
