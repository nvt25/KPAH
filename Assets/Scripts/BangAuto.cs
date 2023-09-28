using System;

public class BangAuto : MyScreen
{
	public static int bomHp = 50;

	public static int bomMp = 50;

	public static int tgDelay = 1;

	public int seleted;

	public int index;

	public int focus;

	private bool isChangeTab;

	private int countL;

	private int countR;

	public static string[] name = new string[3]
	{
		"Trị",
		"Đánh",
		"Nhặt"
	};

	public TField tfHp;

	public TField tfMp;

	public TField tfDelay;

	public bool isAutoParty;

	public bool isAutoPotion;

	public bool isAutoItem;

	public bool isAutoGemItem;

	public bool isNhatHet;

	public bool isOptionFocus;

	public bool isAutoFire;

	public bool isAutoMHP;

	public bool isAll;

	private Command cmdCheck;

	private Command cmdBatTat;

	private Command cmdSelectSkill;

	public static int cmtoX;

	public static int cmx;

	public static int cmdx;

	public static int cmvx;

	public static int cmxLim;

	public static bool isAutoComeHome;

	private Command cmdComeHome;

	private int wT;

	private int hT;

	public bool trans;

	public int pa;

	private string[] optionFC = new string[5]
	{
		"Chế độ thường",
		"Đánh quái ",
		"Chọn NPC",
		"Chế độ chiếm thành",
		"Chế độ quốc chiến"
	};

	private string[] optionDetail = new string[5]
	{
		"Chọn toàn bộ",
		"Chỉ chọn quái, người trong chế độ đồ sát và khác quốc gia ",
		"Chỉ chọn NPC",
		"Chỉ chọn người khác bang",
		"Chỉ người khác nước"
	};

	private string[] info;

	public sbyte currentIndex;

	private int xC;

	private int yC;

	private Scroll mScroll = new Scroll();

	private int[] IDSkillBuff = new int[3]
	{
		-1,
		-1,
		-1
	};

	private int[] IDSkillAuto = new int[3]
	{
		-1,
		-1,
		-1
	};

	private int[] vitri = new int[3]
	{
		Canvas.hw - 110,
		Canvas.hw - 10,
		Canvas.hw + 90
	};

	private int xxx;

	public BangAuto()
	{
		tfHp = new TField();
		tfHp.width = 30;
		tfHp.height = 20;
		tfHp.isFocus = false;
		tfHp.setIputType(TField.INPUT_TYPE_NUMERIC);
		tfHp.setText(bomHp + string.Empty);
		tfMp = new TField();
		tfMp.width = 30;
		tfMp.height = 20;
		tfMp.isFocus = false;
		tfMp.setIputType(TField.INPUT_TYPE_NUMERIC);
		tfMp.setText(string.Empty + bomMp);
		tfDelay = new TField();
		tfDelay.width = 30;
		tfDelay.height = 20;
		tfDelay.isFocus = false;
		tfDelay.setIputType(TField.INPUT_TYPE_NUMERIC);
		tfDelay.setText(string.Empty + tgDelay);
		cmdBatTat = new Command(string.Empty);
		cmdBatTat.action = delegate
		{
			if (Tilemap.lv == 0 || Tilemap.lv == 201 || Tilemap.lv == 70 || Tilemap.lv == 80)
			{
				Canvas.startOKDlg("Không thể bật auto ở đây.");
			}
			else
			{
				doAuto();
			}
		};
		center = cmdBatTat;
		cmdCheck = new Command(string.Empty);
		cmdCheck.action = delegate
		{
			doCheck();
		};
		cmdSelectSkill = new Command(string.Empty);
		cmdSelectSkill.action = delegate
		{
			doSelectedSkillAuto();
		};
		cmdComeHome = new Command(string.Empty);
		cmdComeHome.action = delegate
		{
			isAutoComeHome = !isAutoComeHome;
		};
		left = new Command("Đóng");
		left.action = delegate
		{
			mScroll.clear();
			dosetNumbeMpHp();
			Canvas.gameScr.switchToMe();
		};
		right = null;
	}

	public override void switchToMe()
	{
		init();
		center.caption = "Chọn";
		center = cmdBatTat;
		isOptionFocus = false;
		base.switchToMe();
	}

	public override void init()
	{
		wT = Canvas.w;
		if (wT > 480)
		{
			wT = 480;
		}
		hT = Canvas.h;
		if (hT > 320)
		{
			hT = 320;
		}
		tfMp.x = (tfHp.x = Canvas.hw + 30);
		tfHp.y = Canvas.hh - 55;
		tfMp.y = Canvas.hh - 30;
		seleted = 0;
		index = 0;
		tfHp.isFocus = false;
		tfMp.isFocus = false;
		isChangeTab = true;
		xC = tfHp.x + 5;
		yC = Canvas.hh + 18;
		base.init();
	}

	public void dosetNumbeMpHp()
	{
		try
		{
			bomHp = int.Parse(tfHp.getText());
			bomMp = int.Parse(tfMp.getText());
		}
		catch (Exception)
		{
		}
	}

	public void doAuto()
	{
		try
		{
			if (tfHp.getText().Equals(string.Empty) || tfMp.getText().Equals(string.Empty))
			{
				Canvas.startOKDlg("HP, Mp không được bỏ trống.");
			}
			else if (int.Parse(tfHp.getText()) > 100 || int.Parse(tfMp.getText()) > 100)
			{
				Canvas.startOKDlg("Giá trị không hợp lệ.");
			}
			else
			{
				mVector mVector = new mVector();
				string[] array = new string[3]
				{
					"Auto đánh",
					"Auto bơm máu",
					"Auto đánh, bơm máu"
				};
				if (GameScr.autoFight || GameScr.autoBomHMP)
				{
					array = new string[4]
					{
						"Auto đánh",
						"Auto bơm máu",
						"Auto đánh, bơm máu",
						"Tắt auto"
					};
				}
				for (int i = 0; i < array.Length; i++)
				{
					int o = i;
					Command command = new Command(array[i]);
					command.action = delegate
					{
						setOptionAuto(o);
					};
					mVector.addElement(command);
				}
				Canvas.menu.startAt(mVector, 2);
			}
		}
		catch (Exception)
		{
			Canvas.startOKDlg("Vui lòng chỉ nhập số.");
		}
	}

	public void setOptionAuto(int i)
	{
		isAutoFire = false;
		isAll = false;
		isAutoMHP = false;
		switch (i)
		{
		case 0:
			isAutoFire = true;
			GameScr.autoFight = true;
			GameScr.autoBomHMP = false;
			break;
		case 1:
			isAutoMHP = true;
			GameScr.autoFight = false;
			GameScr.autoBomHMP = true;
			break;
		case 2:
			isAll = true;
			GameScr.autoFight = true;
			GameScr.autoBomHMP = true;
			break;
		default:
			GameScr.autoFight = false;
			GameScr.autoBomHMP = false;
			break;
		}
		GameScr.saveAutoFight = GameScr.autoFight;
		bomHp = int.Parse(tfHp.getText());
		bomMp = int.Parse(tfMp.getText());
		tgDelay = (int)(mSystem.currentTimeMillis() / 100) + 10;
		GameScr.timeDelayHpMp = (int)(mSystem.currentTimeMillis() / 1000) + 1;
		Canvas.gameScr.switchToMe();
		if (GameScr.autoFight)
		{
			Canvas.gameScr.mainChar.lastXAuto = Canvas.gameScr.mainChar.x;
			Canvas.gameScr.mainChar.lastYAuto = Canvas.gameScr.mainChar.y;
		}
	}

	private void doCheck()
	{
		if (index == 0)
		{
			isAutoParty = !isAutoParty;
		}
		else
		{
			if (index != 2)
			{
				return;
			}
			switch (seleted)
			{
			case 1:
				isAutoPotion = !isAutoPotion;
				break;
			case 2:
				isAutoItem = !isAutoItem;
				break;
			case 3:
				isAutoGemItem = !isAutoGemItem;
				break;
			case 4:
				isNhatHet = !isNhatHet;
				if (isNhatHet)
				{
					isAutoGemItem = (isAutoItem = (isAutoPotion = true));
				}
				else
				{
					isAutoGemItem = (isAutoItem = (isAutoPotion = false));
				}
				break;
			}
			if (isAutoPotion && isAutoItem && isAutoGemItem)
			{
				isNhatHet = true;
			}
			else
			{
				isNhatHet = false;
			}
		}
	}

	private void setLim()
	{
		cmxLim = Canvas.gameScr.mainChar.getnSkill() * 23 - 114;
		if (cmxLim < 0)
		{
			cmxLim = 0;
		}
	}

	public override void update()
	{
		Canvas.gameScr.update();
		if (!isOptionFocus)
		{
			if (cmx != cmtoX)
			{
				cmvx = cmtoX - cmx << 2;
				cmdx += cmvx;
				cmx += cmdx >> 4;
				cmdx &= 15;
			}
			if (Math.abs(cmtoX - cmx) < 15 && cmx < 0)
			{
				cmtoX = 0;
			}
			if (Math.abs(cmtoX - cmx) < 10 && cmx > cmxLim)
			{
				cmtoX = cmxLim;
			}
			tfHp.update();
			tfMp.update();
		}
		base.update();
	}

	public override void updateKey()
	{
		if (isOptionFocus)
		{
			bool flag = false;
			bool flag2 = false;
			if (Canvas.isPointer(Canvas.w / 2 - 75, Canvas.h / 2 - 80, 75, 30))
			{
				flag = true;
			}
			else if (Canvas.isPointer(Canvas.w / 2, Canvas.h / 2 - 80, 75, 30))
			{
				flag2 = true;
			}
			if (Canvas.isPointerClick)
			{
				if (flag)
				{
					Canvas.keyPressed[4] = true;
					Canvas.isPointerClick = false;
				}
				else if (flag2)
				{
					Canvas.keyPressed[6] = true;
					Canvas.isPointerClick = false;
				}
			}
			if (Canvas.keyPressed[4])
			{
				Canvas.keyPressed[4] = false;
				GameScr.typeOptionFocus--;
				if (GameScr.typeOptionFocus < 0)
				{
					GameScr.typeOptionFocus = (sbyte)(optionFC.Length - 1);
				}
				setInfo();
				countL = 5;
			}
			else if (Canvas.keyPressed[6])
			{
				Canvas.keyPressed[6] = false;
				GameScr.typeOptionFocus++;
				if (GameScr.typeOptionFocus > optionFC.Length - 1)
				{
					GameScr.typeOptionFocus = 0;
				}
				setInfo();
				countR = 5;
			}
		}
		else
		{
			ScrollResult scrollResult = mScroll.updateKey();
			focus = scrollResult.selected;
			mScroll.updatecm();
			if (Canvas.isPointerClick && Canvas.isPointer(Canvas.hw - 150, Canvas.hh - 120, 300, 23))
			{
				mScroll.clear();
				index = (Canvas.px - (Canvas.hw - 150)) / 100;
				if (index > 1)
				{
					index = 1;
				}
				Canvas.isPointerClick = false;
			}
			switch (index)
			{
			case 0:
				if (Canvas.isPointerClick && Canvas.isPointer(xC, yC, 20, 20))
				{
					seleted = 3;
					isAutoParty = !isAutoParty;
					Canvas.isPointerClick = false;
				}
				else if (Canvas.isPointerClick && Canvas.isPointer(xC, yC + 25, 20, 20))
				{
					seleted = 4;
					isAutoComeHome = !isAutoComeHome;
					Canvas.isPointerClick = false;
				}
				break;
			case 1:
				if (Canvas.isPointerClick && Canvas.isPointer(Canvas.hw - 150, Canvas.hh + 53, 300, 30))
				{
					Canvas.isPointerClick = false;
					Out.println("click   " + focus);
					if (focus != -1)
					{
						doSelectedSkillAuto();
					}
				}
				break;
			case 2:
				if (Canvas.isPointerClick && Canvas.isPointer(Canvas.hw + 20, Canvas.hh - 45, 40, 100))
				{
					seleted = (Canvas.py - (Canvas.hh - 40)) / 25 + 1;
					if (seleted > 4)
					{
						seleted = 4;
					}
					doCheck();
				}
				break;
			}
		}
		base.updateKey();
	}

	public override bool keyPress(int keyCode)
	{
		if (tfHp.isFocus)
		{
			if (tfHp.keyPressed(keyCode))
			{
				return true;
			}
		}
		else if (tfMp.isFocus)
		{
			if (tfMp.keyPressed(keyCode))
			{
				return true;
			}
		}
		else if (tfDelay.isFocus && tfDelay.keyPressed(keyCode))
		{
			return true;
		}
		return base.keyPress(keyCode);
	}

	public void setInfo()
	{
		info = MFont.normalFont[0].splitFontBStrInLine(optionDetail[GameScr.typeOptionFocus], 135);
		center = new Command("Chọn");
		center.action = delegate
		{
			Canvas.gameScr.switchToMe();
		};
		right = new Command("Đóng");
		right.action = delegate
		{
			GameScr.typeOptionFocus = currentIndex;
			Canvas.gameScr.switchToMe();
		};
		left = new Command(string.Empty);
		left.action = delegate
		{
		};
	}

	public void paintTabAuto(MyGraphics g)
	{
		int num = Canvas.hw - 150;
		int num2 = Canvas.hh - 120;
		int w = 300;
		int h = 210;
		Res.paintDlgFull(g, num, num2, w, h);
		int[] array = new int[3]
		{
			Canvas.hw - 100,
			Canvas.hw,
			Canvas.hw + 100
		};
		g.setColor(9755120, 0.5f);
		int num3 = (index != 1) ? 3 : 0;
		g.fillRect(index * 100 + num + num3, num2 + 3, 100 - num3, 22);
		for (int i = 0; i < name.Length; i++)
		{
			if (i == index)
			{
				MFont.normalFont[0].drawString(g, name[i], array[i], num2 + 5, MFont.CENTER);
			}
			else
			{
				MFont.arialFontW.drawString(g, name[i], array[i], num2 + 5, MFont.CENTER);
			}
			g.setColor(10591392);
			if (i > 0)
			{
				g.fillRect(i * 100 + num, num2 + 3, 2, 22);
			}
		}
		switch (index)
		{
		case 0:
			MFont.normalFont[0].drawString(g, "MP : ", Canvas.hw - 60, tfMp.y, MFont.LEFT);
			MFont.normalFont[0].drawString(g, "HP : ", Canvas.hw - 60, tfHp.y, MFont.LEFT);
			MFont.normalFont[0].drawString(g, "%", tfHp.x + 55, tfHp.y, MFont.RIGHT);
			MFont.normalFont[0].drawString(g, "%", tfMp.x + 55, tfMp.y + 2, MFont.RIGHT);
			g.setColor(16777215);
			g.fillRect(Canvas.hw - 65, Canvas.hh + 5, 135, 1);
			MFont.normalFont[0].drawString(g, "Tự vào nhóm :", Canvas.hw - 60, Canvas.hh + 15, 0);
			g.drawRegion(Res.imgCheck, 0, (seleted == 3) ? 1 : 0, 18, 11, 0, xC, yC, MyGraphics.TOP | MyGraphics.LEFT);
			if (isAutoParty)
			{
				g.drawRegion(Res.imgCheck, 0, 22, 18, 11, 0, xC, yC, MyGraphics.TOP | MyGraphics.LEFT);
			}
			MFont.normalFont[0].drawString(g, "Tự về làng :", Canvas.hw - 60, Canvas.hh + 40, 0);
			g.drawRegion(Res.imgCheck, 0, (seleted == 4) ? 1 : 0, 18, 11, 0, xC, yC + 25, MyGraphics.TOP | MyGraphics.LEFT);
			if (isAutoComeHome)
			{
				g.drawRegion(Res.imgCheck, 0, 22, 18, 11, 0, xC, yC + 25, MyGraphics.TOP | MyGraphics.LEFT);
			}
			tfHp.paint(g);
			Canvas.resetTrans(g);
			tfMp.paint(g);
			break;
		case 1:
			MFont.normalFont[0].drawString(g, "Đánh:", Canvas.hw, Canvas.hh - 80, MFont.CENTER);
			g.setColor(16777215);
			g.drawRect(array[0] - 16, Canvas.hh - 60, 32, 32);
			g.drawRect(Canvas.hw - 16, Canvas.hh - 60, 32, 32);
			g.drawRect(array[2] - 16, Canvas.hh - 60, 32, 32);
			MFont.normalFont[0].drawString(g, "Hổ trợ:", Canvas.hw - 15, Canvas.hh - 20, MFont.LEFT);
			g.drawRect(array[0] - 16, Canvas.hh - 3, 32, 32);
			g.drawRect(Canvas.hw - 16, Canvas.hh - 3, 32, 32);
			g.drawRect(array[2] - 16, Canvas.hh - 3, 32, 32);
			g.fillRect(Canvas.hw - 140, Canvas.hh + 43, 280, 1);
			paintSkillAuto(g, array[0] - 32, Canvas.hh + 68);
			break;
		}
	}

	public override void paint(MyGraphics g)
	{
		Canvas.gameScr.paint(g);
		if (countL > 0)
		{
			countL--;
		}
		if (countR > 0)
		{
			countR--;
		}
		if (isOptionFocus)
		{
			Res.paintDlgFull(g, Canvas.w / 2 - 80, Canvas.h / 2 - 80, 160, 160);
			g.drawImage(Res.imgBar, Canvas.w / 2 - 65 - countL, Canvas.h / 2 - 66, 3);
			g.drawRegion(Res.imgBar, 0, 0, 11, 7, 2, Canvas.w / 2 + 65 + countR, Canvas.h / 2 - 66, 3);
			MFont.normalFont[0].drawString(g, optionFC[GameScr.typeOptionFocus], Canvas.w / 2, Canvas.h / 2 - 73, MFont.CENTER);
			for (int i = 0; i < info.Length; i++)
			{
				MFont.normalFont[0].drawString(g, info[i], Canvas.w / 2 - 72, Canvas.h / 2 - 50 + i * MyScreen.ITEM_HEIGHT, 0);
			}
			base.paint(g);
		}
		else
		{
			paintTabAuto(g);
			base.paint(g);
		}
	}

	private void paintSkillAuto(MyGraphics g, int x, int y)
	{
		Canvas.resetTrans(g);
		mScroll.setStyle(Canvas.gameScr.mainChar.getnSkill(), 30, x, y - 15, 290, 30, styleUPDOWN: false, 1);
		mScroll.setClip(g, Canvas.hw - 145, y - 17, 290, 50);
		for (int i = 0; i < Canvas.gameScr.mainChar.getnSkill(); i++)
		{
			GameData.imgSkillIcon.drawFrame(i, i * 30 + x, y - 15, 0, 0, g);
			g.drawImage(Res.imgKhung, i * 30 + x, y - 15, 0);
			MFont.smallFontColor[1].drawString(g, Char.skillLevelLearnt[i] + string.Empty, i * 30 + x + 15, y + 5, MFont.RIGHT);
			if (focus == i && Canvas.gameTick % 10 > 3)
			{
				g.setColor(16388369);
				g.drawRect(i * 30 + x - 2, y - 17, 24, 24);
			}
		}
		Canvas.resetTrans(g);
		if (IDSkillAuto != null)
		{
			for (int j = 0; j < IDSkillAuto.Length; j++)
			{
				if (IDSkillAuto[j] != -1)
				{
					GameData.imgSkillIcon.drawFrame(IDSkillAuto[j], vitri[j], Canvas.hh - 54, 0, 0, g);
				}
			}
		}
		if (IDSkillBuff == null)
		{
			return;
		}
		for (int k = 0; k < IDSkillBuff.Length; k++)
		{
			if (IDSkillBuff[k] != -1)
			{
				GameData.imgSkillIcon.drawFrame(IDSkillBuff[k], vitri[k], Canvas.hh + 4, 0, 0, g);
			}
		}
	}

	public bool isBuffSkillAuto()
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
			if (focus == array[Canvas.gameScr.mainChar.clazz][i])
			{
				return true;
			}
		}
		return false;
	}

	private void doSelectedSkillAuto()
	{
		if (Char.skillLevelLearnt[focus] == -1)
		{
			Canvas.startOKDlg("Xin gặp Lâm tướng quân để học kỹ năng này");
			return;
		}
		bool flag = false;
		bool flag2 = isBuffSkillAuto();
		if (flag2)
		{
			flag = (SkillManager.SKILL_CAN_BUFF_TO_USER[Canvas.gameScr.mainChar.clazz][focus - 4] == -1);
		}
		if (flag)
		{
			return;
		}
		if (Char.skillLevelLearnt[focus] > 0)
		{
			if (Canvas.gameScr.mainChar.clazz != 2)
			{
				doGiveSkillToQuickSlotAuto(focus, flag2);
			}
			else if (focus == 6)
			{
				Canvas.startOKDlg("Không thể dùng skill này");
			}
			else
			{
				doGiveSkillToQuickSlotAuto(focus, flag2);
			}
		}
		else
		{
			Canvas.startOKDlg("Chưa học kỹ năng này");
		}
	}

	private void doGiveSkillToQuickSlotAuto(int skillType, bool isBuff)
	{
		mVector mVector = new mVector();
		for (int i = 0; i < 3; i++)
		{
			int ii = i;
			Command command = new Command("Phím số " + (1 + i * 2));
			command.action = delegate
			{
				if (isBuff)
				{
					GameScr.indexTabSlot = 1;
					IDSkillBuff[ii] = skillType;
				}
				else
				{
					GameScr.indexTabSlot = 0;
					IDSkillAuto[ii] = skillType;
				}
				MainChar.quickSlot[GameScr.indexTabSlot][ii].setIsSkill(skillType, Canvas.gameScr.mainChar.clazz, isBuff);
				RMS.saveQuickSlot();
				GameScr.indexTabSlot = 0;
			};
			mVector.addElement(command);
		}
		Canvas.menu.startAt(mVector, 2);
	}

	public override void pointerPress(int dx, int dy)
	{
		base.pointerPress(dx, dy);
	}
}
