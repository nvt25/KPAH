using System;
using UnityEngine;

public class ShopOnline : MyScreen
{
	public Scroll scl;

	public Scroll cmrShowTxt;

	public static mVector ALL_ITEM = new mVector();

	public static string[] tile = new string[6]
	{
		"Chợ",
		"Tìm",
		"Đang bán",
		"Hành trang",
		"Kho",
		"Bid"
	};

	public static short[] nPage = new short[6];

	public static short[] indexPage = new short[6];

	public static string[][] tileFind = new string[3][]
	{
		new string[5]
		{
			"Loại:",
			"Level:",
			"Phẩm:",
			"Màu:",
			"Cộng:"
		},
		new string[1]
		{
			"N.vật"
		},
		new string[0]
	};

	public static string[] nameItem = new string[19]
	{
		"áo",
		"Quần",
		"Nón",
		"Kiếm",
		"Đao",
		"Bút",
		"Búa",
		"Cung",
		"Nhẫn",
		"Dây chuyền",
		"Giày",
		"Găng tay",
		"Ngọc bội",
		"Giáp linh thú",
		"Hộ uyển",
		"Nón linh thú",
		"Bàn đạp",
		"Yên cương",
		"Phi phong"
	};

	public static sbyte[] ID_TYPE_ITEM = new sbyte[19]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9,
		10,
		11,
		12,
		14,
		15,
		16,
		17,
		18,
		19
	};

	public static string[] Pham = new string[5]
	{
		"Nhất phẩm",
		"Nhị phẩm",
		"Tam phẩm",
		"Tứ phẩm",
		"Khác"
	};

	public static string[] Color = new string[4]
	{
		"Trắng",
		"Xanh",
		"Đỏ",
		"Hoàn mỹ"
	};

	public static short level;

	public static short wStr;

	public static string pham = string.Empty;

	public static string mau = string.Empty;

	public int select;

	public int selectTxt;

	public int x;

	public int y;

	public int w0;

	public int h0;

	public int xShowTxt;

	public int yShowTxt;

	public int wShowTxt;

	public int hShowTxt;

	private int countL;

	private int indexMainTile;

	private int idType;

	private int idLevel = 1;

	private int idPham;

	private int idColor;

	private int idPlus;

	public Command cmdDoNothing;

	public Command cmdSell;

	public Command cmdBuy;

	public Command cmdMenu;

	public Command cmdFind;

	public Command cmdLastLeft;

	public Command cmdLastCenter;

	public Command cmdShowText;

	public MyScreen lastScreen;

	private bool isSelectTypeFind = true;

	private bool isFocusMainTab;

	private sbyte typeSearch;

	public string[] arrInfo = new string[1]
	{
		string.Empty
	};

	public string nameChar = string.Empty;

	public bool isShowText;

	private int xRunL;

	private int xRunR;

	private Image img;

	private sbyte[] arrayKhamNgoc;

	public int wShowLv = 110;

	public string price = "10.000.000.000";

	public string strLv = string.Empty;

	public static long money = 0L;

	public ShopOnline()
	{
		cmdDoNothing = new Command(string.Empty);
		cmdDoNothing.action = delegate
		{
		};
		ALL_ITEM.addElement(new mVector());
		ALL_ITEM.addElement(new mVector());
		ALL_ITEM.addElement(new mVector());
		ALL_ITEM.addElement(new mVector());
		ALL_ITEM.addElement(new mVector());
		ALL_ITEM.addElement(new mVector());
	}

	public void reset()
	{
		select = -1;
		selectTxt = 0;
		level = 0;
		pham = string.Empty;
		mau = string.Empty;
		indexMainTile = 1;
		isSelectTypeFind = true;
		isFocusMainTab = ((!Canvas.isSmartPhone) ? true : false);
		idColor = (idPham = (idType = 0));
		idLevel = 1;
		isShowText = false;
		arrInfo = new string[1]
		{
			string.Empty
		};
		scl.clear();
		cmrShowTxt.clear();
		setCmdLeft();
	}

	public void setShowTxt(string[] str)
	{
		arrInfo = new string[1]
		{
			string.Empty
		};
		arrInfo = str;
		isShowText = true;
	}

	public void paintNameItemSelect(MyGraphics g, int x, int y, string str, MFont f, int id)
	{
		int num = 100;
		g.drawImage(Res.imgBar, x + num + ((select == id) ? countL : 0), y + 7, 3);
		g.drawRegion(Res.imgBar, 0, 0, 11, 7, 2, x - ((select == id) ? countL : 0), y + 7, 3);
		f.drawString(g, str, x + num / 2, y, 2);
	}

	public override void switchToMe()
	{
		init();
		base.switchToMe();
	}

	public override void switchToMe(MyScreen scr)
	{
		lastScreen = scr;
		init();
		base.switchToMe(scr);
	}

	public override void init()
	{
		if (Canvas.isSmartPhone)
		{
			tileFind[1][0] = "Nhân vật";
		}
		if (img == null)
		{
			try
			{
				img = Image.createImage(Main.res + "/02");
			}
			catch (Exception)
			{
			}
		}
		int num = Canvas.w - 6;
		int num2 = Canvas.h - 30;
		if (num > 320)
		{
			num = 320;
		}
		if (num2 > 240)
		{
			num2 = 240;
		}
		w0 = num;
		h0 = num2;
		x = Canvas.w / 2 - w0 / 2;
		y = Canvas.h / 2 - h0 / 2 - 10;
		if (y < 8)
		{
			y = 8;
		}
		wShowTxt = Canvas.w - 40;
		if (wShowTxt > 200)
		{
			wShowTxt = 200;
		}
		hShowTxt = Canvas.h - 80;
		if (hShowTxt > 180)
		{
			hShowTxt = 180;
		}
		xShowTxt = Canvas.w / 2 - wShowTxt / 2;
		yShowTxt = Canvas.h / 2 - hShowTxt / 2;
		if (yShowTxt < 5)
		{
			yShowTxt = 5;
		}
		for (int i = 0; i < tileFind[0].Length; i++)
		{
			if (wStr < MFont.normalFont[0].getWidth(tileFind[0][i]))
			{
				wStr = (short)MFont.normalFont[0].getWidth(tileFind[0][i]);
			}
		}
		wStr += 5;
		select = -1;
		isFocusMainTab = ((!Canvas.isSmartPhone) ? true : false);
		isShowText = false;
		idColor = (idPham = (idType = 0));
		idLevel = 1;
		center = new Command((!Canvas.isSmartPhone) ? "Chọn" : string.Empty);
		center.action = delegate
		{
			doselect();
		};
		cmdFind = new Command("Tìm");
		cmdFind.action = delegate
		{
			doFind();
			left = cmdMenu;
		};
		right = new Command("Đóng");
		right.action = delegate
		{
			if (isShowText)
			{
				isShowText = false;
				setCmdLeft();
			}
			else
			{
				lastScreen.switchToMe();
				reset();
			}
		};
		cmdBuy = new Command(string.Empty);
		cmdBuy.action = delegate
		{
		};
		cmdSell = new Command("Menu");
		cmdSell.action = delegate
		{
			mVector mVector2 = new mVector();
			doCmdSell(mVector2);
			Canvas.menu.startAt(mVector2, 0);
		};
		cmdMenu = new Command("Menu");
		cmdMenu.action = delegate
		{
			isShowText = false;
			mVector mVector = new mVector();
			Command command = new Command("Mua")
			{
				action = delegate
				{
					doAcceptBuy(1, (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select));
				}
			};
			command = new Command("Tìm")
			{
				action = delegate
				{
					reset();
					typeSearch = 0;
					left = cmdFind;
				}
			};
			command = new Command("Tìm theo người bán")
			{
				action = delegate
				{
					reset();
					typeSearch = 1;
					left = cmdFind;
				}
			};
			if (((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0)
			{
				command = new Command("Kết quả");
			}
			command.action = delegate
			{
				isSelectTypeFind = false;
				select = -1;
			};
			mVector.addElement(command);
			Canvas.menu.startAt(mVector, 0);
		};
		cmdShowText = new Command("Thông tin ");
		cmdShowText.action = delegate
		{
			doView();
		};
		cmdLastCenter = (cmdLastLeft = cmdDoNothing);
		scl = new Scroll();
		scl.clear();
		cmrShowTxt = new Scroll();
		cmrShowTxt.clear();
		setCmdLeft();
		base.init();
		if (Canvas.isSmartPhone)
		{
			setCmdLeft();
			h0 -= 10;
		}
	}

	public void doCmdSell(mVector menu)
	{
		if (!isFocusMainTab)
		{
			isShowText = false;
			Command command = new Command("Bán");
			int price;
			ItemInInventory item;
			command.action = delegate
			{
				ActionPerform ok = delegate
				{
					try
					{
						string text = Canvas.inputDlg.tfInput.getText();
						price = int.Parse(text);
						Canvas.endDlg();
						if (price < 0)
						{
							Canvas.startOKDlg("Không thể bán với giá này");
						}
						else
						{
							item = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
							if (ItemInInventory.isModelClothe(item.getTemplate().attb[9]) || item.dayUse > 0)
							{
								Canvas.startOKDlg("Không thể bán vật phẩm này");
							}
							else
							{
								ActionPerform yesAction = delegate
								{
									GameService.gI().doRequestSelItem(0, item.itemID, price, 0);
									Canvas.startOKDlg("Đã gửi thông tin bán ");
								};
								Canvas.startYesNoDlg("Bạn có muốn đặt bán vật phẩm này với giá " + price + "  không?", yesAction);
							}
						}
					}
					catch (Exception)
					{
						Canvas.endDlg();
						Canvas.startOKDlg("Nhập sai,vui lòng chỉ nhập số");
					}
				};
				Canvas.inputDlg.setInfo("Nhập giá bán", ok, TField.INPUT_ALPHA_NUMBER_ONLY, 10, isMaxW: true);
				Canvas.inputDlg.show();
			};
			menu.addElement(command);
			ActionPerform action = delegate
			{
				doSell();
			};
			Command command2 = new Command("Bán đấu giá");
			command2.action = action;
			menu.addElement(command2);
		}
	}

	public void doAcceptBuy(int new_search, ItemInInventory item)
	{
		if (item.nameCharSell.Equals(Canvas.gameScr.mainChar.name))
		{
			Canvas.startOKDlg("Không thể mua vật phẩm do mình đăng bán");
			return;
		}
		ActionPerform yesAction = delegate
		{
			GameService.gI().doBuyItemShopOnline(select, new_search);
			Canvas.endDlg();
			Canvas.startOKDlg("Xin chờ");
		};
		Canvas.startYesNoDlg("Bạn có muốn mua vật phẩm này không ?", yesAction);
	}

	protected void doSort()
	{
		mVector mVector = new mVector();
		ActionPerform action = delegate
		{
			doSortBuyPrice();
		};
		Command command = new Command("Theo giá ");
		command.action = action;
		mVector.addElement(command);
		ActionPerform action2 = delegate
		{
			doSortBuyLevel();
		};
		command = new Command("Theo level");
		command.action = action2;
	}

	protected void doSortBuyLevel()
	{
	}

	protected void doSortBuyPrice()
	{
	}

	protected void doView()
	{
		mVector mVector = (mVector)ALL_ITEM.elementAt(indexMainTile);
		if ((isFocusMainTab && !Canvas.isSmartPhone) || mVector.size() == 0)
		{
			return;
		}
		selectTxt = 0;
		ItemInInventory itemInInventory = null;
		if (select >= 0 && select < mVector.size())
		{
			itemInInventory = (ItemInInventory)mVector.elementAt(select);
			if (!itemInInventory.isEnoughData)
			{
				itemInInventory.isEnoughData = true;
				GameService.gI().requestItemInfo(itemInInventory.itemID, Canvas.gameScr.mainChar.ID);
			}
		}
		string[] showTxt = new string[1]
		{
			string.Empty
		};
		if (itemInInventory != null)
		{
			if (itemInInventory.totalKham > 0)
			{
				arrayKhamNgoc = new sbyte[itemInInventory.totalKham];
				for (int i = 0; i < itemInInventory.totalKham; i++)
				{
					arrayKhamNgoc[i] = -1;
				}
				sbyte b = 0;
				for (int j = 0; j < itemInInventory.allAttribute.size(); j++)
				{
					InfoAttributeItem infoAttributeItem = (InfoAttributeItem)itemInInventory.allAttribute.elementAt(j);
					if (infoAttributeItem.getColorPaint(kick: false) == 3)
					{
						for (int k = 0; k < itemInInventory.numKham; k++)
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
			showTxt = MFont.normalFont[0].splitFontBStrInLine(itemInInventory.getDescription(showResellPrice: false), wShowTxt - 10);
		}
		setShowTxt(showTxt);
	}

	protected void doSell()
	{
		mVector mVector = (mVector)ALL_ITEM.elementAt(indexMainTile);
		if (select >= 0 && select < mVector.size())
		{
			ItemInInventory itemInInventory = (ItemInInventory)mVector.elementAt(select);
			if (ItemInInventory.isModelClothe(itemInInventory.getTemplate().attb[9]) || itemInInventory.dayUse > 0)
			{
				Canvas.startOKDlg("Không thể bán vật phẩm này");
			}
			else
			{
				popupBuyItem(itemInInventory);
			}
		}
	}

	public void doAcceptSell()
	{
	}

	public void paintFillLine(MyGraphics g, int x, int y1, int y2)
	{
		g.setColor(9605778);
		g.fillRect(x, y1, w0 + 2, 1);
	}

	public override void paint(MyGraphics g)
	{
		if (lastScreen != null)
		{
			lastScreen.paint(g);
		}
		Canvas.resetTrans(g);
		Res.paintDlgDragonFull(g, x, y, w0, h0);
		g.setColor(7961465);
		g.fillRect(Canvas.hw - 51, y + 7, 102, 22);
		g.setColor(isFocusMainTab ? 30611 : 2368548);
		g.fillRect(Canvas.hw - 50, y + 8, 100, 20);
		MFont.normalFont[0].drawString(g, tile[indexMainTile], Canvas.w / 2, y + 10, 2);
		g.drawImage(Res.imgBar, Canvas.hw - 40 + xRunL, y + 17, 3);
		g.drawRegion(Res.imgBar, 0, 0, 11, 7, 2, Canvas.hw + 40 + xRunR, y + 17, 3);
		MFont.smallFontColor[0].drawString(g, money + "$", x + w0 - 2, y + h0 - 12, MFont.RIGHT);
		int num = MyScreen.ITEM_HEIGHT + 10;
		int num2 = 0;
		if (indexMainTile == 1)
		{
			num = MyScreen.ITEM_HEIGHT + 10;
			num2 = y + 40;
			if (isSelectTypeFind)
			{
				scl.setStyle(tileFind[0].Length, num, x + 6, y + 40, w0, h0 - 40, styleUPDOWN: true, 0);
				scl.setClip(g, x + 6, y + 40, w0 - 12, h0 - 55);
				for (int i = 0; i < tileFind[typeSearch].Length; i++)
				{
					MFont.normalFont[0].drawString(g, tileFind[typeSearch][i], x + 6, num2 + i * num, 0);
				}
				string[][] array = new string[2][]
				{
					new string[5]
					{
						nameItem[idType],
						idLevel + string.Empty,
						Pham[idPham],
						Color[idColor],
						idPlus + string.Empty
					},
					new string[1]
					{
						(!nameChar.Equals(string.Empty)) ? nameChar : "Nhập tên"
					}
				};
				int num3 = idColor;
				if (idColor == 1)
				{
					num3 = 3;
				}
				else if (idColor == 3)
				{
					num3 = 1;
				}
				for (int j = 0; j < array[typeSearch].Length; j++)
				{
					paintNameItemSelect(g, (Canvas.w / 2 - 40 > x + 6 + wStr) ? (Canvas.w / 2 - 40) : (x + 6 + wStr), num2 + j * num, array[typeSearch][j], MFont.normalFont[(j == 3) ? num3 : 0], j);
				}
			}
			else
			{
				paintItem(g, (mVector)ALL_ITEM.elementAt(1), isShopBuy: true);
			}
		}
		else
		{
			paintItem(g, (mVector)ALL_ITEM.elementAt(indexMainTile), isShopBuy: false);
		}
		if (isShowText)
		{
			paintShowTxt(g);
		}
		base.paint(g);
	}

	public void paintItem(MyGraphics g, mVector vt, bool isShopBuy)
	{
		int num = MyScreen.ITEM_HEIGHT * 3 + 10;
		scl.setStyle(vt.size(), num, x + 6, y + 40, w0, h0 - 40, styleUPDOWN: true, 0);
		scl.setClip(g, x + 6, y + 40, w0 - 12, h0 - 55);
		ItemTemplate itemTemplate = null;
		ItemInInventory itemInInventory = null;
		bool flag = false;
		for (int i = 0; i < vt.size(); i++)
		{
			itemInInventory = (ItemInInventory)vt.elementAt(i);
			int num2 = y + 40 + i * num;
			itemTemplate = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (num2 + num - scl.cmy < y + 30 || num2 - scl.cmy > y + h0)
			{
				continue;
			}
			if (select == i)
			{
				g.setColor(34949);
				g.fillRect(x - 1, num2 - 5, w0 - 2, num);
				flag = true;
			}
			if (itemInInventory.prizeBet > 0)
			{
				g.drawImage(img, x + 12, num2 + 20, 0);
			}
			paintFillLine(g, x, num2 - 5, num2);
			g.drawImage(Res.imgGrid, x + 6, num2, 0);
			string[] name = itemInInventory.getName();
			for (int j = 0; j < name.Length; j++)
			{
				sbyte b = (sbyte)(name[j][0] - 48);
				sbyte b2 = 1;
				if (!WindowInfoScr.isDegit(name[j][0]))
				{
					b = 0;
					b2 = 0;
				}
				MFont.normalFont[(b < 5) ? b : 0].drawString(g, name[j].Substring(b2), 30 + x, num2 + j * MyScreen.ITEM_HEIGHT + 2, 0);
			}
			GameData.paintIcon(g, itemTemplate.idIcon, 16 + x, num2 + 8);
			if (select == i && i > 1)
			{
				paintLevelAndPrice(g, x + 10, num2 - 5 - (num + 5), isShopBuy, isBuy: true, itemInInventory);
			}
		}
		paintFillLine(g, x, y + 40 + vt.size() * num - 5, 1);
		if (flag && (select == 0 || select == 1))
		{
			Canvas.resetTrans(g);
			itemInInventory = (ItemInInventory)vt.elementAt(select);
			paintLevelAndPrice(g, x + 10, y + 32 - num + select * num, isShopBuy, isBuy: true, itemInInventory);
		}
	}

	public void paintShowTxt(MyGraphics g)
	{
		Canvas.resetTrans(g);
		g.setColor(16774720);
		g.fillRect(xShowTxt - 1, yShowTxt - 1, wShowTxt + 2, hShowTxt + 2);
		g.setColor(25695);
		g.fillRect(xShowTxt, yShowTxt, wShowTxt, hShowTxt);
		cmrShowTxt.setStyle(arrInfo.Length, MyScreen.ITEM_HEIGHT + 2, xShowTxt, yShowTxt, wShowTxt, hShowTxt, styleUPDOWN: true, 0);
		cmrShowTxt.setClip(g, xShowTxt, yShowTxt, wShowTxt, hShowTxt);
		int num = 0;
		for (int i = 0; i < arrInfo.Length; i++)
		{
			if (i == 1 && arrayKhamNgoc != null && arrayKhamNgoc.Length > 0)
			{
				for (int j = 0; j < arrayKhamNgoc.Length; j++)
				{
					g.drawImage(Res.imgKham, xShowTxt + 12 + j * 20, yShowTxt + 12 + num, 3);
					if (arrayKhamNgoc[j] != -1)
					{
					}
				}
				num += 18;
			}
			if (!arrInfo[i].Equals(string.Empty))
			{
				sbyte b = (sbyte)(arrInfo[i][0] - 48);
				sbyte b2 = 1;
				if (!WindowInfoScr.isDegit(arrInfo[i][0]))
				{
					b = 0;
					b2 = 0;
				}
				MFont.normalFont[(b < 5) ? b : 0].drawString(g, arrInfo[i].Substring(b2), xShowTxt + 4, yShowTxt + 4 + i * (MyScreen.ITEM_HEIGHT + 2) + num, 0);
			}
		}
	}

	public override void update()
	{
		if (lastScreen != null)
		{
			lastScreen.update();
		}
		if (countL > 0)
		{
			countL--;
		}
		if (countL <= 0)
		{
			countL = 5;
		}
		if (xRunL < 0)
		{
			xRunL++;
		}
		if (xRunR > 0)
		{
			xRunR--;
		}
		if (Canvas.currentDialog == null && !Canvas.menu.showMenu)
		{
			if (isShowText)
			{
				ScrollResult scrollResult = cmrShowTxt.updateKey();
				if (scrollResult.isDowning || scrollResult.isFinish)
				{
					selectTxt = scrollResult.selected;
				}
				cmrShowTxt.updatecm();
			}
			else
			{
				ScrollResult scrollResult2 = scl.updateKey();
				if (scrollResult2.isDowning || scrollResult2.isFinish)
				{
					select = scrollResult2.selected;
				}
				if (Canvas.isPointer(x, y + 30, w0, h0 - 30) && Canvas.isPointerClick)
				{
					Canvas.isPointerClick = false;
					if (scrollResult2.selected != -1 && center != null)
					{
						center.perform();
					}
				}
				scl.updatecm();
			}
		}
		base.update();
	}

	public void updatePoint()
	{
		switch (indexMainTile)
		{
		case 0:
		{
			if (!Canvas.isPointerClick || !Canvas.isPointer((Canvas.w / 2 - 40 > x + 6 + wStr) ? (Canvas.w / 2 - 40) : (x + 6 + wStr), y + 30, 100, 4 * (MyScreen.ITEM_HEIGHT + 10)))
			{
				break;
			}
			int num = -1;
			num = (Canvas.py - (y + 30)) / (MyScreen.ITEM_HEIGHT + 10);
			Canvas.isPointerClick = false;
			setCmdLeft();
			if (num >= 0 && num <= 3)
			{
				select = num;
				if (center != null)
				{
					center.perform();
				}
			}
			break;
		}
		}
		if (!Canvas.isPointerClick)
		{
			return;
		}
		isFocusMainTab = false;
		Canvas.isPointerClick = false;
		if (Canvas.py >= y && Canvas.py <= y + 25)
		{
			if (Canvas.px > x && Canvas.px < Canvas.w / 2)
			{
				indexMainTile--;
				if (indexMainTile < 0)
				{
					indexMainTile = tile.Length - 1;
				}
				xRunL = -5;
				scl.clear();
				select = -1;
				setCmdLeft();
			}
			else if (Canvas.px < Canvas.w / 2 + w0 / 2 && Canvas.px > Canvas.w / 2)
			{
				indexMainTile++;
				if (indexMainTile > tile.Length - 1)
				{
					indexMainTile = 0;
				}
				xRunR = 5;
				scl.clear();
				left = cmdLastLeft;
				select = -1;
				setCmdLeft();
			}
		}
		if (((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0 && select == -1)
		{
			select = 0;
		}
		setCmdLeft();
	}

	public override void updateKey()
	{
		if (isFocusMainTab)
		{
			if (Canvas.keyPressed[4])
			{
				Canvas.keyPressed[4] = false;
				indexMainTile--;
				if (indexMainTile < 0)
				{
					indexMainTile = tile.Length - 1;
				}
				xRunL = -5;
				scl.clear();
				left = cmdLastLeft;
				select = -1;
				setCmdLeft();
			}
			else if (Canvas.keyPressed[6])
			{
				Canvas.keyPressed[6] = false;
				indexMainTile++;
				if (indexMainTile > tile.Length - 1)
				{
					indexMainTile = 0;
				}
				xRunR = 5;
				scl.clear();
				left = cmdLastLeft;
				select = -1;
				setCmdLeft();
			}
			if (Canvas.keyPressed[8])
			{
				Canvas.keyPressed[8] = false;
				select = 0;
				isFocusMainTab = false;
				setCmdLeft();
			}
		}
		else
		{
			mVector mVector = (mVector)ALL_ITEM.elementAt(indexMainTile);
			int num = mVector.size();
			if (isSelectTypeFind && indexMainTile == 1)
			{
				if (Canvas.keyPressed[2])
				{
					Canvas.keyPressed[2] = false;
					select--;
					if (select <= -1)
					{
						select = -1;
						isFocusMainTab = true;
						setCmdLeft();
					}
					scl.moveTo(select * scl.ITEM_SIZE);
				}
				else if (Canvas.keyPressed[8])
				{
					Canvas.keyPressed[8] = false;
					select++;
					if (select > tileFind[typeSearch].Length - 1)
					{
						select = 0;
					}
					scl.moveTo(select * scl.ITEM_SIZE);
				}
			}
			else if (!isFocusMainTab)
			{
				if (Canvas.keyPressed[2])
				{
					Canvas.keyPressed[2] = false;
					if (isShowText)
					{
						selectTxt--;
						if (selectTxt < 0)
						{
							selectTxt = arrInfo.Length - 1;
						}
						cmrShowTxt.moveTo(selectTxt * cmrShowTxt.ITEM_SIZE);
					}
					else
					{
						select--;
						if (select <= -1)
						{
							select = -1;
							isFocusMainTab = true;
						}
						setCmdLeft();
						scl.moveTo(select * scl.ITEM_SIZE);
					}
				}
				else if (Canvas.keyPressed[8])
				{
					Canvas.keyPressed[8] = false;
					if (isShowText)
					{
						selectTxt++;
						if (selectTxt > arrInfo.Length - 1)
						{
							selectTxt = 0;
						}
						cmrShowTxt.moveTo(selectTxt * cmrShowTxt.ITEM_SIZE);
					}
					else
					{
						select++;
						if (select > num - 1)
						{
							select = 0;
						}
						setCmdLeft();
						scl.moveTo(select * scl.ITEM_SIZE);
					}
				}
			}
		}
		base.updateKey();
		if (Canvas.currentDialog == null && !Canvas.menu.showMenu && !isShowText)
		{
			updatePoint();
		}
	}

	public void paintLevelAndPrice(MyGraphics g, int x, int y, bool isShopBuy, bool isBuy, ItemInInventory item)
	{
	}

	public void doFind()
	{
		isSelectTypeFind = false;
		select = -1;
		if (typeSearch == 0)
		{
			GameService.gI().doSearchItemSell(idLevel, ID_TYPE_ITEM[idType], idColor, idPham + 1, idPlus);
		}
		else if (typeSearch == 1)
		{
			GameService.gI().doSearchByName(nameChar);
		}
	}

	public void doselect()
	{
		if (Canvas.currentScreen == PageScr.gI())
		{
			return;
		}
		if (indexMainTile == 1)
		{
			if (isSelectTypeFind)
			{
				mVector mVector = new mVector();
				Command command = null;
				if (typeSearch == 0)
				{
					switch (select)
					{
					case 0:
						for (int j = 0; j < nameItem.Length; j++)
						{
							command = new Command(nameItem[j]);
							command.action = delegate
							{
								idType = Canvas.menu.selected;
							};
							mVector.addElement(command);
						}
						Canvas.menu.startAt(mVector, 2);
						break;
					case 1:
					{
						ActionPerform ok = delegate
						{
							try
							{
								string text = Canvas.inputDlg.tfInput.getText();
								idLevel = int.Parse(text);
								Canvas.endDlg();
								if (idLevel < 0)
								{
									Canvas.startOKDlg("Nhập sai,vui lòng chỉ nhập số lớn hơn 0 ");
									idLevel = 0;
								}
							}
							catch (Exception)
							{
								Canvas.endDlg();
								Canvas.startOKDlg("Nhập sai,vui lòng chỉ nhập số");
							}
						};
						Canvas.inputDlg.setInfo("Nhập số", ok, TField.INPUT_ALPHA_NUMBER_ONLY, 3, isMaxW: true);
						Canvas.inputDlg.show();
						break;
					}
					case 2:
						for (int k = 0; k < Pham.Length; k++)
						{
							command = new Command(Pham[k]);
							command.action = delegate
							{
								idPham = Canvas.menu.selected;
							};
							mVector.addElement(command);
						}
						Canvas.menu.startAt(mVector, 2);
						break;
					case 3:
						for (int l = 0; l < Color.Length; l++)
						{
							command = new Command(Color[l]);
							command.action = delegate
							{
								idColor = Canvas.menu.selected;
							};
							mVector.addElement(command);
						}
						Canvas.menu.startAt(mVector, 2);
						break;
					case 4:
						for (int i = 0; i < 16; i++)
						{
							command = new Command("Cộng " + i);
							command.action = delegate
							{
								idPlus = Canvas.menu.selected;
							};
							mVector.addElement(command);
						}
						Canvas.menu.startAt(mVector, 2);
						break;
					}
				}
				else if (typeSearch == 1 && select > -1)
				{
					ActionPerform ok2 = delegate
					{
						try
						{
							nameChar = Canvas.inputDlg.tfInput.getText();
							Canvas.endDlg();
							if (nameChar.Equals(string.Empty))
							{
								Canvas.startOKDlg("Tên không hợp lệ");
							}
						}
						catch (Exception)
						{
						}
					};
					Canvas.inputDlg.setInfo("Nhập tên", ok2, TField.INPUT_TYPE_ANY, 25, isMaxW: true);
					Canvas.inputDlg.show();
				}
			}
			else if (Canvas.isSmartPhone)
			{
				mVector mVector2 = new mVector();
				mVector2.addElement(cmdShowText);
				Canvas.menu.startAt(mVector2, 2);
			}
			else
			{
				doView();
			}
		}
		else if (Canvas.isSmartPhone)
		{
			mVector mVector3 = new mVector();
			mVector3.addElement(cmdShowText);
			Canvas.menu.startAt(mVector3, 2);
		}
		else
		{
			doView();
		}
	}

	public void setItemInventory()
	{
		ALL_ITEM.setElementAt(ItemInInventory.getAllItemCanSell(), 3);
	}

	public bool canBid()
	{
		if (indexMainTile == 0)
		{
			if (((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0 && !isFocusMainTab && select < ((mVector)ALL_ITEM.elementAt(indexMainTile)).size())
			{
				if (select < 0)
				{
					return false;
				}
				ItemInInventory itemInInventory = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
				if (itemInInventory.prizeBet > 0)
				{
					return true;
				}
			}
		}
		else if (indexMainTile == 1 && !isSelectTypeFind && ((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0 && !isFocusMainTab && select < ((mVector)ALL_ITEM.elementAt(indexMainTile)).size())
		{
			if (select < 0)
			{
				return false;
			}
			ItemInInventory itemInInventory2 = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
			if (itemInInventory2.prizeBet > 0)
			{
				return true;
			}
		}
		return false;
	}

	public void setCmdLeft()
	{
		if (indexMainTile == 3)
		{
			setItemInventory();
		}
		if (indexMainTile == 0)
		{
			if (!canBid())
			{
				if (isFocusMainTab)
				{
					left = new Command(string.Empty);
					left.action = delegate
					{
					};
					return;
				}
				if (((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0)
				{
					left = new Command("Mua");
					left.action = delegate
					{
						if (select >= 0)
						{
							ItemInInventory item4 = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
							doAcceptBuy(0, item4);
						}
					};
				}
			}
			else
			{
				left = new Command("Menu");
				int price3;
				left.action = delegate
				{
					isShowText = false;
					mVector mVector4 = new mVector();
					mVector4.addElement(new Command("Mua")
					{
						action = delegate
						{
							if (select >= 0)
							{
								doAcceptBuy(0, (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select));
							}
						}
					});
					mVector4.addElement(new Command("Bid")
					{
						action = delegate
						{
							ShopOnline shopOnline3 = this;
							if (select >= 0)
							{
								ItemInInventory item3 = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
								ActionPerform ok3 = delegate
								{
									try
									{
										string text3 = Canvas.inputDlg.tfInput.getText();
										price3 = int.Parse(text3);
										Canvas.endDlg();
										if (price3 < 0 || price3 <= item3.prizeBet || price3 >= item3.prize)
										{
											Canvas.startOKDlg("Giá bid phải lớn hơn " + item3.prizeBet + " và nhỏ hơn " + item3.prize);
										}
										else
										{
											ActionPerform yesAction4 = delegate
											{
												if (shopOnline3.select >= 0)
												{
													GameService.gI().doBid(shopOnline3.select, 0, price3);
													Canvas.endDlg();
												}
											};
											Canvas.startYesNoDlg("Bạn có muốn đặt bid cho " + item3.getTemplate().name + " với giá " + price3 + " không?", yesAction4);
										}
									}
									catch (Exception)
									{
										Canvas.endDlg();
										Canvas.startOKDlg("Nhập sai,vui lòng chỉ nhập số");
									}
								};
								Canvas.inputDlg.setInfo("Nhập giá", ok3, TField.INPUT_ALPHA_NUMBER_ONLY, 10, isMaxW: true);
								Canvas.inputDlg.show();
							}
						}
					});
					Canvas.menu.startAt(mVector4, 0);
				};
			}
		}
		else if (indexMainTile == 1)
		{
			left = new Command("Menu");
			int price2;
			left.action = delegate
			{
				isShowText = false;
				mVector mVector3 = new mVector();
				if (!isFocusMainTab && ((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0 && select > -1)
				{
					ShopOnline shopOnline2 = this;
					if (select < 0)
					{
						return;
					}
					ItemInInventory item2 = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
					if (!item2.isMyItem())
					{
						mVector3.addElement(new Command("Mua")
						{
							action = delegate
							{
								ActionPerform yesAction3 = delegate
								{
									if (shopOnline2.select >= 0)
									{
										shopOnline2.doAcceptBuy(1, (ItemInInventory)((mVector)ALL_ITEM.elementAt(shopOnline2.indexMainTile)).elementAt(shopOnline2.select));
									}
								};
								Canvas.startYesNoDlg("Bạn có muốn mua " + item2.getTemplate().name + " với giá " + item2.prize + " không?", yesAction3);
							}
						});
						if (canBid())
						{
							mVector3.addElement(new Command("Bid")
							{
								action = delegate
								{
									ActionPerform ok2 = delegate
									{
										try
										{
											string text2 = Canvas.inputDlg.tfInput.getText();
											price2 = int.Parse(text2);
											Canvas.endDlg();
											if (price2 < 0 || price2 <= item2.prizeBet || price2 >= item2.prize)
											{
												Canvas.startOKDlg("Giá bid phải lớn hơn " + item2.prizeBet + " và nhỏ hơn " + item2.prize);
											}
											else
											{
												ActionPerform yesAction2 = delegate
												{
													if (shopOnline2.select >= 0)
													{
														GameService.gI().doBid(shopOnline2.select, 1, price2);
														Canvas.endDlg();
													}
												};
												Canvas.startYesNoDlg("Bạn có muốn đặt bid cho " + item2.getTemplate().name + " với giá " + price2 + " không?", yesAction2);
											}
										}
										catch (Exception)
										{
											Canvas.endDlg();
											Canvas.startOKDlg("Nhập sai,vui lòng chỉ nhập số");
										}
									};
									Canvas.inputDlg.setInfo("Nhập giá", ok2, TField.INPUT_ALPHA_NUMBER_ONLY, 10, isMaxW: true);
									Canvas.inputDlg.show();
								}
							});
						}
					}
				}
				if (isSelectTypeFind)
				{
					mVector3.addElement(new Command("Tìm")
					{
						action = delegate
						{
							doFind();
						}
					});
				}
				if (typeSearch != 0)
				{
					mVector3.addElement(new Command("Tìm theo loại")
					{
						action = delegate
						{
							reset();
							typeSearch = 0;
						}
					});
				}
				if (typeSearch != 1)
				{
					mVector3.addElement(new Command("Tìm theo người bán")
					{
						action = delegate
						{
							reset();
							typeSearch = 1;
						}
					});
				}
				if (((mVector)ALL_ITEM.elementAt(indexMainTile)).size() > 0)
				{
					mVector3.addElement(new Command("Kết quả")
					{
						action = delegate
						{
							isSelectTypeFind = false;
							select = -1;
							setCmdLeft();
						}
					});
				}
				if (nPage[indexMainTile] > 0)
				{
					if (indexPage[indexMainTile] < nPage[indexMainTile] - 1)
					{
						mVector3.addElement(new Command("Trang sau")
						{
							action = delegate
							{
								indexPage[indexMainTile]++;
							}
						});
					}
					if (indexPage[indexMainTile] > 0)
					{
						mVector3.addElement(new Command("Trang trước")
						{
							action = delegate
							{
								indexPage[indexMainTile]--;
							}
						});
					}
				}
				Canvas.menu.startAt(mVector3, 0);
			};
		}
		else if (indexMainTile == 2)
		{
			left = cmdDoNothing;
		}
		else if (indexMainTile == 3)
		{
			left = cmdSell;
		}
		else if (indexMainTile == 4)
		{
			mVector v = (mVector)ALL_ITEM.elementAt(indexMainTile);
			if (v.size() > 0 || money > 0)
			{
				left = new Command("Menu");
				left.action = delegate
				{
					isShowText = false;
					mVector mVector2 = new mVector();
					if (money > 0)
					{
						mVector2.addElement(new Command("Rút tiền")
						{
							action = delegate
							{
								GameService.gI().doGetMoneySellInventory();
							}
						});
					}
					if (v.size() > 0 && select >= 0)
					{
						mVector2.addElement(new Command("Bỏ vào hành trang")
						{
							action = delegate
							{
								GameService.gI().doGetItemBackInventory(select);
							}
						});
					}
					Canvas.menu.startAt(mVector2, 2);
				};
			}
			else
			{
				left = new Command(string.Empty);
				left.action = delegate
				{
				};
			}
		}
		else if (indexMainTile == 5)
		{
			if (((mVector)ALL_ITEM.elementAt(indexMainTile)).size() == 0 || isFocusMainTab)
			{
				left = new Command(string.Empty);
				left.action = delegate
				{
				};
			}
			else
			{
				left = new Command("Menu");
				int price;
				left.action = delegate
				{
					isShowText = false;
					mVector mVector = new mVector();
					mVector.addElement(new Command("Mua")
					{
						action = delegate
						{
							doAcceptBuy(2, (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select));
						}
					});
					mVector.addElement(new Command("Đặt bid")
					{
						action = delegate
						{
							ShopOnline shopOnline = this;
							ItemInInventory item = (ItemInInventory)((mVector)ALL_ITEM.elementAt(indexMainTile)).elementAt(select);
							ActionPerform ok = delegate
							{
								try
								{
									string text = Canvas.inputDlg.tfInput.getText();
									price = int.Parse(text);
									Canvas.endDlg();
									if (price < 0 || price <= item.prizeBet || price >= item.prize)
									{
										Canvas.startOKDlg("Giá bid phải lớn hơn " + item.prizeBet + " và nhỏ hơn " + item.prize);
									}
									else
									{
										ActionPerform yesAction = delegate
										{
											GameService.gI().doBid(shopOnline.select, 2, price);
											Canvas.endDlg();
										};
										Canvas.startYesNoDlg("Bạn có muốn đặt bid cho " + item.getTemplate().name + " với giá " + price + " không?", yesAction);
									}
								}
								catch (Exception)
								{
									Canvas.endDlg();
									Canvas.startOKDlg("Nhập sai,vui lòng chỉ nhập số");
								}
							};
							Canvas.inputDlg.setInfo("Nhập giá", ok, TField.INPUT_ALPHA_NUMBER_ONLY, 10, isMaxW: true);
							Canvas.inputDlg.show();
						}
					});
					Canvas.menu.startAt(mVector, 0);
				};
			}
		}
		UnityEngine.Debug.LogError("xong---------ee---------------------");
	}

	public static void popupBuyItem(ItemInInventory item)
	{
		TField tfSeri = new TField(Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 120, 140, MyScreen.ITEM_HEIGHT + 2);
		tfSeri.setIputType(TField.INPUT_ALPHA_NUMBER_ONLY);
		tfSeri.isFocus = true;
		tfSeri.setText("100000");
		PageScr.gI().right = tfSeri.cmdClear;
		TField tfMaso = new TField(Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 60, 140, MyScreen.ITEM_HEIGHT + 2);
		tfMaso.setIputType(TField.INPUT_ALPHA_NUMBER_ONLY);
		tfMaso.setText("10000");
		Command command = new Command("Bán");
		command.action = delegate
		{
			int num = 0;
			int num2 = 0;
			try
			{
				num = int.Parse(tfSeri.getText().Trim());
				num2 = int.Parse(tfMaso.getText().Trim());
			}
			catch (Exception)
			{
				Canvas.startOKDlg("Giá bán không hợp lệ");
				return;
				IL_0054:;
			}
			if (num < num2)
			{
				Canvas.startOKDlg("Giá bid phải nhỏ hơn giá bán");
			}
			else
			{
				int p = num;
				int pb = num2;
				ActionPerform yesAction = delegate
				{
					GameService.gI().doRequestSelItem(0, item.itemID, p, pb);
					PageScr.gI().left.perform();
					Canvas.startOKDlg("Đã gửi thông tin bán ");
				};
				Canvas.startYesNoDlg("Bạn có muốn đặt bán vật phẩm này với giá " + tfSeri.getText().Trim() + "  không?", yesAction);
			}
		};
		PageScr.gI().setInfo(Canvas.hw - 90, Canvas.h - MyScreen.ITEM_HEIGHT - 170, 180, 140, "NHẬP GIÁ BÁN", command);
		Layer layer = new Layer();
		layer.isUpdate = delegate
		{
			tfSeri.update();
			tfMaso.update();
		};
		layer.isKeyCode = delegate(int keyCode)
		{
			if (tfSeri.isFocus)
			{
				tfSeri.keyPressed(keyCode);
			}
			if (tfMaso.isFocus)
			{
				tfMaso.keyPressed(keyCode);
			}
		};
		layer.isPaint = delegate(MyGraphics g, int x, int y)
		{
			MFont.borderFont.drawString(g, "Giá bán", Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 140, 0);
			MFont.borderFont.drawString(g, "Giá bid", Canvas.hw - 70, Canvas.h - MyScreen.ITEM_HEIGHT - 80, 0);
			tfSeri.paint(g);
			g.setClip(0, 0, Canvas.w, Canvas.h);
			tfMaso.paint(g);
			g.setClip(0, 0, Canvas.w, Canvas.h);
		};
		PageScr.gI().layer = layer;
		PageScr.gI().switchToMe(Canvas.shop);
	}

	public void onItemInfo()
	{
		if (isShowText)
		{
			doView();
		}
	}
}
