public class ScreenItemTim : MyScreen
{
	public const sbyte TYPE2 = 0;

	public const sbyte TYPE4 = 1;

	public const sbyte TypeXayBot = 5;

	public const sbyte TYPE_ANIMAL = 2;

	public const sbyte TYPE_LOCK_ITEM = 3;

	public const sbyte TYPE_EP_ITEM_TIM = 6;

	public static ScreenItemTim me;

	public static int hImg = 80;

	public static int wImg = 40;

	public static int wCell;

	public static int hCell;

	public static int xDr;

	public static int yDr;

	public static mVector vnguyenLieu = new mVector();

	public Scroll mScrollItemInventory = new Scroll();

	public Scroll mScrollShowText = new Scroll();

	public Scroll mScrollNguyenLieu = new Scroll();

	public int index = -1;

	public int xSh;

	public int ySh;

	public int wSh;

	public int hSh;

	public int wTab = 28;

	public int selectItemInventory;

	public int lastIndex1;

	public int h0;

	public int indexTabNguyenLieu;

	public int lastIndex2;

	public MyScreen last;

	public string[] arrShowText = new string[1]
	{
		string.Empty
	};

	public string tile = "Cộng thuộc tính";

	public mVector mShot = new mVector();

	public bool isShowText;

	public sbyte type;

	public sbyte frame;

	public sbyte selectMenuItem;

	public bool createBot;

	public bool isdestroyitem;

	public bool isXayBot;

	public bool isShot;

	public bool isDap;

	public int xto;

	public int yto;

	public int hclip;

	public int hclip1;

	public int size = 22;

	private Command cmdClose;

	private Command cmdErr;

	private Command cmdView;

	private Command cmdContinue;

	private Command cmdXay;

	private Command cmdWaiting;

	private Command cmdDapItemTim;

	public mVector ListTtem = new mVector();

	public bool[] CheckHaveItemCell = new bool[6];

	public bool[] CheckPaintItem = new bool[6];

	public static sbyte COLOR_WHITE = 0;

	public static sbyte COLOR_GREEN = 1;

	public static sbyte COLOR_RED = 2;

	public static sbyte COLOR_BLUE = 3;

	public static sbyte COLOR_MAGENTA = 4;

	public static sbyte COLOR_YELLOW = 5;

	public mVector LisItemSelect = new mVector();

	public mVector mEffect = new mVector();

	public mVector lazer = new mVector();

	public static mVector listItem = new mVector();

	private int[] xItem;

	private int[] yItem;

	private int[] xTo;

	private int[] yTo;

	private bool isEp;

	private bool isShowPopup;

	private int xPopup;

	private int yPopup;

	private string infoPoup = "Thong bao";

	private bool DropItem;

	public sbyte currentRow;

	public sbyte timeDelay;

	public sbyte currentCell = 5;

	private int cout;

	private int selectItem;

	private static ItemInInventory itemSelect;

	public ItemInInventory selecItemNL1;

	public ItemInInventory selecItemNL3;

	public ItemInInventory selecItemNL4;

	public ItemInInventory selecItemNL6;

	private static GemTemplate selectGem = null;

	private static GemTemplate selectGemBH = null;

	private static GemTemplate selectGemMM = null;

	private static GemTemplate selecItemNL2 = null;

	public static bool LKDLock;

	public static bool MMLock;

	public static bool BHLock;

	public static bool isFinishImbue = true;

	public static short idLkd = -1;

	public static short idMM = -1;

	public static short idBH = -1;

	public static short itemID;

	private mVector mDestroy = new mVector();

	public int timeDlay = 15;

	public int dem = -1;

	public int tick;

	public short id_bot;

	public sbyte typeResult;

	public sbyte soluong = 1;

	public ScreenItemTim()
	{
		wCell = Canvas.w - 10;
		hCell = Canvas.h - MyScreen.ITEM_HEIGHT - 10;
		if (wCell > 176)
		{
			wCell = 176;
		}
		if (hCell > 220)
		{
			hCell = 220;
		}
		if (Canvas.w >= 320 && Canvas.isSmartPhone)
		{
			wCell = 300;
		}
		xDr = Canvas.w / 2 - wCell / 2;
		yDr = (Canvas.h - MyScreen.ITEM_HEIGHT) / 2 - hCell / 2;
		if (yDr < 5)
		{
			yDr = 5;
		}
		if (xDr < 5)
		{
			xDr = 5;
		}
		wSh = wCell;
		if (Canvas.isSmartPhone && wCell == 300)
		{
			xSh = xDr + wCell / 2;
			ySh = yDr + 55;
			wSh = wCell / 2 - 8;
			hSh = hCell - 54;
		}
		h0 = hCell - 54;
		cmdDapItemTim = new Command("Đập");
		cmdDapItemTim.action = delegate
		{
			if (!CheckHaveItemcell())
			{
				Canvas.startOKDlg("Bạn chưa bỏ nguyên liệu vào ô!");
			}
			else if (CheckHaveItemcell() && !isDap)
			{
				addlazeEpItemTim();
				isShot = true;
				isDap = true;
			}
		};
		cmdWaiting = new Command("Xin chờ");
		cmdWaiting.action = delegate
		{
		};
		cmdXay = new Command("Nghiền");
		cmdXay.action = delegate
		{
			if (itemSelect == null)
			{
				Canvas.startOKDlg("Bạn chưa bỏ trang bị vào");
			}
			else if (!isXayBot)
			{
				Out.LogWarning("vao day ne cha");
				GameService.gI().doRequestTachNguyenLIeu(itemSelect.itemID, 4, 0, 0);
				Canvas.startOKDlg("Xin chờ");
			}
		};
		cmdClose = new Command("Đóng");
		cmdClose.action = delegate
		{
			if (isShowText)
			{
				isShowText = false;
				center = cmdView;
				mScrollShowText.clear();
				arrShowText = new string[1]
				{
					string.Empty
				};
				if (isEp)
				{
					left = cmdContinue;
				}
				else if (type == 5)
				{
					left = cmdXay;
				}
				else if (type == 6)
				{
					left = cmdDapItemTim;
				}
			}
			else
			{
				resetData();
				last.switchToMe();
			}
		};
		cmdView = new Command((!Canvas.isSmartPhone) ? string.Empty : string.Empty);
		cmdView.action = delegate
		{
			mVector mVector = new mVector();
			mVector.addElement(new Command("Bỏ vào")
			{
				action = delegate
				{
					if (type == 5 && isXayBot)
					{
						Canvas.startOKDlg("Không thể chọn trong quá trình luyện");
					}
					else if (type == 6 && isDap)
					{
						Canvas.startOKDlg("Không thể chọn trong quá trình luyện");
					}
					else
					{
						if (type == 6 && listItem.size() > 0)
						{
							if (currentCell == 1)
							{
								selecItemNL1 = (ItemInInventory)listItem.elementAt(selectItemInventory);
								if (checKselecitem(selecItemNL1))
								{
									Canvas.startOKDlg("Item Da duoc chon");
									selecItemNL1 = null;
								}
							}
							if (currentCell == 2 && selecItemNL2 != null)
							{
								CheckPaintItem[1] = true;
							}
							if (currentCell == 3)
							{
								selecItemNL3 = (ItemInInventory)listItem.elementAt(selectItemInventory);
								if (checKselecitem(selecItemNL3))
								{
									Canvas.startOKDlg("Item Da duoc chon");
									selecItemNL3 = null;
								}
							}
							if (currentCell == 4)
							{
								selecItemNL4 = (ItemInInventory)listItem.elementAt(selectItemInventory);
								if (checKselecitem(selecItemNL4))
								{
									Canvas.startOKDlg("Item Da duoc chon");
									selecItemNL4 = null;
								}
							}
							if (currentCell == 5)
							{
								itemSelect = (ItemInInventory)listItem.elementAt(selectItemInventory);
								if (checKselecitem(itemSelect))
								{
									Canvas.startOKDlg("Item Da duoc chon");
									itemSelect = null;
								}
							}
							if (currentCell == 6)
							{
								selecItemNL6 = (ItemInInventory)listItem.elementAt(selectItemInventory);
								if (checKselecitem(selecItemNL6))
								{
									Canvas.startOKDlg("Item Da duoc chon", isIcon: false);
									selecItemNL6 = null;
								}
							}
						}
						if (type == 5)
						{
							if (createBot)
							{
								createBot = false;
							}
							if (hclip <= 0)
							{
								hclip = size;
							}
							if (hclip1 > 0)
							{
								hclip1 = 0;
							}
						}
						if (Canvas.isSmartPhone)
						{
							timeDelay = 5;
						}
						if (currentRow == 1 && type != 6 && listItem.size() > 0 && selectItemInventory != -1 && selectItemInventory <= listItem.size() - 1 && !isDap)
						{
							if (type == 1 && !isFinishImbue)
							{
								Canvas.startOKDlg("Không thể chọn khi đang trong quá trình luyện tự động.");
							}
							else
							{
								itemSelect = (ItemInInventory)listItem.elementAt(selectItemInventory);
							}
						}
					}
				}
			});
			if (!Canvas.isSmartPhone)
			{
				mVector.addElement(new Command("Thông tin")
				{
					action = delegate
					{
						if (Canvas.isSmartPhone)
						{
							timeDelay = 5;
						}
						if (listItem.size() > 0 && currentRow == 1 && type != 6)
						{
							doView();
						}
						else if (listItem.size() > 0 && type == 6)
						{
							doView();
						}
					}
				});
			}
			Canvas.menu.startAt(mVector, 3);
			Canvas.currentDialog = null;
		};
		right = cmdClose;
		center = cmdView;
		if (!Canvas.isSmartPhone)
		{
			index = 0;
		}
		setData(null);
		lastIndex1 = 0;
		if (Canvas.isSmartPhone)
		{
			lastIndex1 = -1;
			currentRow = -1;
			lastIndex2 = -1;
		}
		lastIndex2 = 0;
		if (Canvas.isSmartPhone)
		{
			lastIndex2 = -1;
		}
	}

	public static ScreenItemTim gI()
	{
		return (me != null) ? me : (me = new ScreenItemTim());
	}

	public void setData(Message msg)
	{
	}

	public override void startXayBot(int idbot, int type, int sl)
	{
		Canvas.endDlg();
		id_bot = (short)idbot;
		typeResult = (sbyte)type;
		soluong = (sbyte)sl;
		addlazer();
		isXayBot = true;
	}

	public void resetData()
	{
		mScrollItemInventory.clear();
		LisItemSelect.removeAllElements();
		mScrollNguyenLieu.clear();
		mScrollShowText.clear();
		mEffect.removeAllElements();
		lazer.removeAllElements();
		mShot.removeAllElements();
		vnguyenLieu.removeAllElements();
		index = (Canvas.isSmartPhone ? (-1) : 0);
		selectItemInventory = 0;
		indexTabNguyenLieu = 0;
		isShowPopup = false;
		createBot = false;
		currentRow = 0;
		lastIndex1 = 0;
		lastIndex2 = 0;
		if (Canvas.isSmartPhone)
		{
			currentRow = -1;
			lastIndex1 = -1;
			lastIndex2 = -1;
		}
		lastIndex2 = 0;
		if (Canvas.isSmartPhone)
		{
			lastIndex2 = -1;
		}
	}

	private void addlazeEpItemTim()
	{
		WeaponsLazer weaponsLazer = null;
		weaponsLazer = new WeaponsLazer(xItem[6] + size / 2, yItem[6], xItem[1] + size / 2, yItem[1], 100, 3, 3);
		lazer.addElement(weaponsLazer);
		weaponsLazer = null;
		for (int i = 1; i < xItem.Length - 1; i++)
		{
			weaponsLazer = new WeaponsLazer(xItem[i] + size / 2, yItem[i], xItem[i + 1] + size / 2, yItem[i + 1], 100, 3, 6 + i * 2);
			lazer.addElement(weaponsLazer);
			weaponsLazer = null;
			dem = 6 + i * 2;
		}
	}

	private void addNguyenlieu()
	{
		for (int i = 0; i < vnguyenLieu.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)vnguyenLieu.elementAt(i);
			if (gemTemplate != null)
			{
			}
		}
	}

	private bool CheckHaveItemcell()
	{
		for (int i = 0; i < CheckHaveItemCell.Length; i++)
		{
			if (!CheckHaveItemCell[i])
			{
				return false;
			}
		}
		return true;
	}

	private void resetCheck()
	{
		selectGem = null;
		cmdDapItemTim.caption = "Đập";
		center = cmdView;
		isShot = false;
		tick = 0;
		selecItemNL1 = null;
		selecItemNL2 = null;
		selecItemNL3 = null;
		selecItemNL4 = null;
		selecItemNL6 = null;
		LisItemSelect.removeAllElements();
		for (int i = 0; i < CheckHaveItemCell.Length; i++)
		{
			CheckHaveItemCell[i] = false;
			CheckPaintItem[i] = false;
		}
		itemSelect = null;
		getListGem(getItem: true, recheck: false);
	}

	public void resetSelect()
	{
		if (type == 5)
		{
			center = cmdView;
		}
		isShot = false;
		tick = 0;
		isDap = false;
		resetCheck();
		currentCell = 5;
		isXayBot = false;
		selectGemBH = null;
		selectGemMM = null;
		itemSelect = null;
		getListGem(getItem: true, recheck: false);
	}

	public void getListGem(bool getItem, bool recheck)
	{
		vnguyenLieu.removeAllElements();
		vnguyenLieu.removeAllElements();
		if (getItem)
		{
			listItem.removeAllElements();
		}
		mVector gemItem = MainChar.gemItem;
		int num = gemItem.size();
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < num; i++)
		{
			GemTemplate gemTemplate = (GemTemplate)gemItem.elementAt(i);
			GemTemp gemByID = Res.getGemByID(gemTemplate.id);
			if (type == 0)
			{
				if (gemByID.type == 6)
				{
					if (selectGem != null && selectGem.id == gemTemplate.id && !selectGem.ilock)
					{
						selectGem = gemTemplate;
						num2 = 1;
					}
					vnguyenLieu.addElement(gemTemplate);
				}
			}
			else if (type == 2)
			{
				if (gemByID.type == GemTemp.TYPE_LOCK_ANIMAL)
				{
					if (selectGem != null && selectGem.id == gemTemplate.id && !selectGem.ilock)
					{
						selectGem = gemTemplate;
						num5 = 1;
					}
					vnguyenLieu.addElement(gemTemplate);
				}
			}
			else if (type == 3)
			{
				if (gemByID.type == GemTemp.TYPE_LOCK_ITEM)
				{
					if (selectGem != null && selectGem.id == gemTemplate.id && !selectGem.ilock)
					{
						selectGem = gemTemplate;
						num5 = 1;
					}
					vnguyenLieu.addElement(gemTemplate);
				}
			}
			else if (gemByID.type == 0)
			{
				if (selectGem != null && selectGem.id == gemTemplate.id && !selectGem.ilock)
				{
					selectGem = gemTemplate;
					num2 = 1;
				}
				else if (selectGem == null && recheck && idLkd == gemTemplate.id && !LKDLock)
				{
					selectGem = gemTemplate;
					num2 = 1;
				}
				if (selectGemBH != null && selectGemBH.id == gemTemplate.id && !selectGemBH.ilock)
				{
					selectGemBH = gemTemplate;
					num3 = 1;
				}
				else if (selectGemBH == null && recheck && idBH == gemTemplate.id && !BHLock)
				{
					selectGemBH = gemTemplate;
					num3 = 1;
				}
				if (selectGemMM != null && selectGemMM.id == gemTemplate.id && !selectGemMM.ilock)
				{
					selectGemMM = gemTemplate;
					num4 = 1;
				}
				else if (selectGemMM == null && recheck && idMM == gemTemplate.id && !MMLock)
				{
					selectGemMM = gemTemplate;
					num4 = 1;
				}
				vnguyenLieu.addElement(gemTemplate);
			}
		}
		gemItem = MainChar.gemItemKhoa;
		num = gemItem.size();
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		for (int j = 0; j < num; j++)
		{
			GemTemplate gemTemplate2 = (GemTemplate)gemItem.elementAt(j);
			GemTemp gemByID2 = Res.getGemByID(gemTemplate2.id);
			if (type == 0)
			{
				if (gemByID2.type == 6)
				{
					if (selectGem != null && selectGem.id == gemTemplate2.id && selectGem.ilock)
					{
						selectGem = gemTemplate2;
						num6 = 1;
					}
					vnguyenLieu.addElement(gemTemplate2);
					gemTemplate2.ilock = true;
				}
			}
			else if (type == 2)
			{
				if (gemByID2.type == GemTemp.TYPE_LOCK_ANIMAL)
				{
					if (selectGem != null && selectGem.id == gemTemplate2.id && selectGem.ilock)
					{
						selectGem = gemTemplate2;
						num9 = 1;
					}
					vnguyenLieu.addElement(gemTemplate2);
					gemTemplate2.ilock = true;
				}
			}
			else if (type == 3)
			{
				if (gemByID2.type == GemTemp.TYPE_LOCK_ITEM)
				{
					if (selectGem != null && selectGem.id == gemTemplate2.id && selectGem.ilock)
					{
						selectGem = gemTemplate2;
						num9 = 1;
					}
					vnguyenLieu.addElement(gemTemplate2);
					gemTemplate2.ilock = true;
				}
			}
			else if (gemByID2.type == 0)
			{
				if (selectGem != null && selectGem.id == gemTemplate2.id && selectGem.ilock)
				{
					selectGem = gemTemplate2;
					num6 = 1;
				}
				else if (selectGem == null && recheck && idLkd == gemTemplate2.id && LKDLock)
				{
					selectGem = gemTemplate2;
					num6 = 1;
				}
				if (selectGemBH != null && selectGemBH.id == gemTemplate2.id && selectGemBH.ilock)
				{
					selectGemBH = gemTemplate2;
					num7 = 1;
				}
				else if (selectGemBH == null && recheck && idBH == gemTemplate2.id && BHLock)
				{
					selectGemBH = gemTemplate2;
					num7 = 1;
				}
				if (selectGemMM != null && selectGemMM.id == gemTemplate2.id && selectGemMM.ilock)
				{
					selectGemMM = gemTemplate2;
					num8 = 1;
				}
				else if (selectGemMM == null && recheck && idMM == gemTemplate2.id && MMLock)
				{
					selectGemMM = gemTemplate2;
					num8 = 1;
				}
				if (type == 6)
				{
					selecItemNL2 = gemTemplate2;
				}
				vnguyenLieu.addElement(gemTemplate2);
				gemTemplate2.ilock = true;
			}
		}
		getItem = true;
		if (type == 0)
		{
			if (num2 == 0 && num6 == 0)
			{
				selectGem = null;
			}
			if (num3 == 0 && num7 == 0)
			{
				selectGemBH = null;
			}
			if (num4 == 0 && num8 == 0)
			{
				selectGemMM = null;
			}
		}
		if (getItem)
		{
			if (type == 0)
			{
				listItem = ItemInInventory.getAllItem(COLOR_GREEN);
			}
			else if (type == 2)
			{
				listItem = ItemInInventory.getAllItemAnimal(COLOR_GREEN, 1);
			}
			else if (type == 3)
			{
				listItem = ItemInInventory.getAllItemCharExcepColor(COLOR_WHITE);
			}
			else
			{
				listItem = ItemInInventory.getAllItemCharDrop();
			}
		}
		int num10 = 0;
		ItemInInventory itemInInventory;
		while (true)
		{
			if (num10 < listItem.size())
			{
				itemInInventory = (ItemInInventory)listItem.elementAt(num10);
				if (itemID == itemInInventory.itemID)
				{
					break;
				}
				num10++;
				continue;
			}
			return;
		}
		itemSelect = itemInInventory;
	}

	public void setSizeCell(sbyte type, bool isContinue)
	{
		int num = 44;
		this.type = type;
		int num2 = xDr + wCell / 2 - num;
		int num3 = yDr + hCell / 2 - 35;
		if (Canvas.isSmartPhone)
		{
			num2 = xDr + wCell / 4 - num;
		}
		if (type == 6)
		{
			currentRow = 1;
			cmdDapItemTim.caption = "Đập";
			tile = "Đập đồ tím";
			int num4 = yDr + 27 + (h0 - 28) / 2;
			int num5 = hCell / 4;
			int num6 = 30;
			xItem = new int[7];
			yItem = new int[7];
			xItem[0] = num2 + num - 10;
			yItem[0] = num4 - size / 2 + 20;
			currentRow = -1;
			for (int i = 1; i < 7; i++)
			{
				xItem[i] = Util.Cos(num6) * num5 / 1024 + xItem[0];
				yItem[i] = Util.Sin(num6) * num5 / 1024 + yItem[0];
				num6 += 60;
			}
		}
		else if (type == 5)
		{
			int num7 = yDr + 27 + (h0 - 28) / 2;
			cmdXay.caption = "Nghiền";
			tile = "Nghiền Bột";
			currentRow = 1;
			xItem = new int[5];
			xTo = new int[4];
			yTo = new int[4];
			yItem = new int[5];
			xItem[0] = num2 + num - 11;
			xItem[1] = xItem[0] - 48;
			xItem[3] = xItem[0] + 48;
			xItem[2] = xItem[0];
			yItem[0] = num7 - size / 2 + 3;
			if (yItem[0] - 2 * size < yDr + 27)
			{
				yItem[0] = yDr + 27 + 2 * size;
			}
			yItem[2] = yItem[0] - 2 * size;
			yItem[1] = yItem[0] + 28;
			yItem[3] = yItem[0] + 28;
			xTo[0] = xItem[0];
			xTo[1] = xItem[1];
			xTo[2] = xItem[2];
			xTo[3] = xItem[3];
			yTo[0] = yItem[0];
			yTo[1] = yItem[1];
			yTo[2] = yItem[2];
			yTo[3] = yItem[3];
			xPopup = num2 + num - 1;
			yPopup = num3 + 40;
			if (Canvas.isSmallScreen)
			{
				yItem[2] = yItem[0] - 2 * size + 4;
				xItem[4] = xItem[0];
				yItem[4] = yItem[0] + 40;
			}
			else
			{
				xItem[4] = xItem[0];
				yItem[4] = yItem[0] + 50;
			}
			xto = xTo[0];
			yto = yTo[0];
			hclip = size;
			hclip1 = 0;
		}
		Out.println("TYPE SCREENDAPDO " + type);
		cout = 0;
		if (type == 5)
		{
			if (isContinue)
			{
				currentRow = 0;
				if (Canvas.isSmartPhone)
				{
					currentRow = -1;
				}
				left = cmdXay;
				isShowText = false;
				mScrollShowText.clear();
				isEp = false;
			}
			else
			{
				isEp = false;
				left = cmdXay;
			}
		}
		else if (type == 6)
		{
			if (isContinue)
			{
				currentRow = 0;
				if (Canvas.isSmartPhone)
				{
					currentRow = -1;
				}
				left = cmdDapItemTim;
				isShowText = false;
				mScrollShowText.clear();
				isEp = false;
			}
			else
			{
				isEp = false;
				left = cmdDapItemTim;
			}
		}
		resetSelect();
		getListGem(getItem: true, recheck: false);
		if (type == 6)
		{
			addNguyenlieu();
		}
	}

	private void updatelazer()
	{
		int num = Arrow.ARROWSIZE[0][10] / 2;
		for (int i = 0; i < lazer.size(); i++)
		{
			WeaponsLazer weaponsLazer = (WeaponsLazer)lazer.elementAt(i);
			if (weaponsLazer != null && type == 5)
			{
				if (hclip > 4)
				{
					addEffectBot();
				}
				if (Canvas.gameTick % 2 == 0)
				{
					Effect o = new Effect(xItem[2] + num - 4, yto + size / 2 - 10, 54);
					mEffect.addElement(o);
				}
			}
			weaponsLazer.update2();
			if (Canvas.gameTick % 2 == 0)
			{
				Effect o2 = new Effect(weaponsLazer.xlim, weaponsLazer.ylim, 54);
				mEffect.addElement(o2);
			}
			if (weaponsLazer.wantDestroy)
			{
				lazer.removeElement(weaponsLazer);
				isdestroyitem = true;
				isShot = true;
			}
		}
	}

	private void paintListItem(MyGraphics g)
	{
		Res.paintDlgFull(g, xDr, yDr, wCell, hCell, 25, tile, isDD: false, h0 - 28);
		Canvas.resetTrans(g);
		if (currentCell != 2)
		{
			mScrollItemInventory.setStyle(listItem.size(), wTab, xDr, yDr + 28 + h0, wCell - 2, 27, styleUPDOWN: false, 0);
			mScrollItemInventory.setClip(g, xDr + 2, yDr + 23 + h0, wCell - 4, 31);
			for (int i = 0; i < listItem.size(); i++)
			{
				if (selectItemInventory == i && currentRow == 1)
				{
					g.setColor(6513507);
					g.fillRect(xDr + wTab * i, yDr + 23 + h0, wTab, 28);
				}
				ItemInInventory itemInInventory = (ItemInInventory)listItem.elementAt(i);
				itemInInventory.paint(g, xDr + wTab * i + wTab / 2, yDr + 36 + h0);
				g.setColor(14527502);
				g.fillRect(xDr + wTab * i, yDr + 22 + h0, 1, 29);
			}
			g.setColor(14527502);
			g.fillRect(xDr + wTab * listItem.size(), yDr + 22 + h0, 1, 29);
		}
		if (selecItemNL2 != null && currentCell == 2)
		{
			g.setColor(6513507);
			g.fillRect(xDr + 3, yDr + 23 + h0, wTab - 3, 28);
			Res.paintGem(g, Res.getGemByID(selecItemNL2.id).idImage, xDr + wTab / 2, yDr + 36 + h0);
			MFont.smallFontColor[3].drawString(g, selecItemNL2.number + string.Empty, xDr + wTab / 2 + size / 2, yDr + 50 + h0 - MFont.smallFontColor[3].getHeight(), MFont.RIGHT);
			g.setColor(14527502);
			g.fillRect(xDr + wTab, yDr + 22 + h0, 1, 29);
		}
		Canvas.resetTrans(g);
		g.setColor(15338765);
		g.fillRect(xItem[currentCell] - 1, yItem[currentCell] - 11, size + 3, size + 2);
	}

	private void paintResult(MyGraphics g)
	{
		g.setClip(xItem[4] + 4, yItem[4] - 8 + hclip, size, size);
		if (typeResult == 0)
		{
			Res.paintPotion(g, MainChar.listPotion[id_bot].index, xItem[4] + 4, yItem[4] - 6, 0);
			return;
		}
		GameData.paintIcon(g, (short)(id_bot + 6500), xItem[4] + 12, yItem[4] + 2, 3);
		MFont.smallFontColor[3].drawString(g, soluong + string.Empty, xItem[4] + 18, yItem[4] + 2, MFont.RIGHT);
	}

	private void addEffectBot()
	{
		int num = Arrow.ARROWSIZE[0][10] / 2;
		for (int i = 0; i < 2; i++)
		{
			Effect_XayBot o = new Effect_XayBot(xItem[2] + num - 4, yto + size / 2 - 10, 2 * i, yItem[4] + size / 2 - 10, 0);
			mEffect.addElement(o);
			o = null;
		}
	}

	private void paintlazer(MyGraphics g)
	{
		for (int i = 0; i < lazer.size(); i++)
		{
			WeaponsLazer weaponsLazer = (WeaponsLazer)lazer.elementAt(i);
			weaponsLazer.paint(g);
		}
	}

	public void addlazer()
	{
		int num = Arrow.ARROWSIZE[0][10] / 2;
		center = cmdWaiting;
		cmdXay.caption = string.Empty;
		Effect o = new Effect(xItem[2] + num - 4, yto + size / 2 - 10, 54);
		mEffect.addElement(o);
		WeaponsLazer weaponsLazer = null;
		for (int i = 0; i < xItem.Length; i++)
		{
			if (i % 4 != 0)
			{
				weaponsLazer = new WeaponsLazer(xItem[i] + num - 2, yItem[i] + num - 10, xItem[2] + num - 2, yto + size / 2 - 10, 40, 2);
				lazer.addElement(weaponsLazer);
				weaponsLazer = null;
			}
		}
	}

	private void updateEffect()
	{
		for (int i = 0; i < mEffect.size(); i++)
		{
			Effect effect = (Effect)mEffect.elementAt(i);
			effect?.update();
			if (effect.wantDetroy && effect.type == -1)
			{
				createBot = true;
				mEffect.removeElement(effect);
			}
			if (effect.wantDetroy)
			{
				mEffect.removeElement(effect);
			}
		}
	}

	protected void doView()
	{
		if (type == 6)
		{
			if (Char.inventory.size() == 0 || selectItemInventory < 0 || selectItemInventory > listItem.size() - 1)
			{
				return;
			}
			if (currentCell == 2)
			{
				if (selecItemNL2 == null)
				{
					return;
				}
				GemTemp gemByID = Res.getGemByID(selecItemNL2.id);
				string str = ItemInInventory.setTemp(gemByID.name, "0");
				str += ItemInInventory.setTemp(gemByID.decript, "0");
				arrShowText = MFont.normalFont[0].splitFontBStrInLine(str, wSh - 10);
			}
			if (currentCell != 2)
			{
				ItemInInventory itemInInventory = (ItemInInventory)listItem.elementAt(selectItemInventory);
				if (!itemInInventory.isEnoughData)
				{
					itemInInventory.isEnoughData = true;
					GameService.gI().requestItemInfo(itemInInventory.itemID, Canvas.gameScr.mainChar.ID);
				}
				arrShowText = MFont.normalFont[0].splitFontBStrInLine(itemInInventory.getDescription(showResellPrice: false), wSh - 10);
			}
		}
		if (type == 5 && listItem.size() > 0)
		{
			if (Char.inventory.size() == 0 || selectItemInventory < 0 || selectItemInventory > listItem.size() - 1)
			{
				return;
			}
			ItemInInventory itemInInventory2 = (ItemInInventory)listItem.elementAt(selectItemInventory);
			if (!itemInInventory2.isEnoughData)
			{
				itemInInventory2.isEnoughData = true;
				GameService.gI().requestItemInfo(itemInInventory2.itemID, Canvas.gameScr.mainChar.ID);
			}
			arrShowText = MFont.normalFont[0].splitFontBStrInLine(itemInInventory2.getDescription(showResellPrice: false), wSh - 10);
		}
		if (!Canvas.isSmartPhone && listItem.size() > 0)
		{
			if (arrShowText.Length == 1)
			{
				hSh = 35;
				ySh = Canvas.h / 2 - MFont.normalFont[0].getHeight() / 2;
			}
			else
			{
				hSh = arrShowText.Length * MyScreen.ITEM_HEIGHT + 8;
				ySh = Canvas.h / 2 - arrShowText.Length * (MyScreen.ITEM_HEIGHT - 3) / 2;
			}
			if (ySh < yDr)
			{
				ySh = yDr;
			}
			if (hSh > 150)
			{
				hSh = 150;
			}
			xSh = xDr;
		}
		if (!Canvas.isSmartPhone)
		{
			isShowText = true;
			center = cmdErr;
			left = cmdErr;
		}
	}

	public void paintCell(MyGraphics g)
	{
		g.setColor(25695);
		int num = (!Canvas.isSmartPhone) ? 10 : (-27);
		g.fillRect(xSh + 2, ySh + num, wSh, hSh - 8);
		g.setColor(16774720);
		g.drawRect(xSh + 2, ySh + num, wSh, hSh - 8);
	}

	public void paintShowText(MyGraphics g)
	{
		Canvas.resetTrans(g);
		if (wCell >= 300)
		{
			paintCell(g);
			if (!isShowText && !Canvas.isSmartPhone)
			{
				return;
			}
		}
		else
		{
			if (!isShowText && !Canvas.isSmartPhone)
			{
				return;
			}
			paintCell(g);
		}
		int num = Canvas.isSmartPhone ? 24 : 0;
		mScrollShowText.setStyle(arrShowText.Length, MyScreen.ITEM_HEIGHT - 2, xSh, ySh - num, wSh - 2, hSh - 10, styleUPDOWN: true, 0);
		mScrollShowText.setClip(g, xSh, ySh + ((!Canvas.isSmartPhone) ? 10 : 2) - num, wSh - 2, hSh - 15);
		for (int i = 0; i < arrShowText.Length; i++)
		{
			if (!arrShowText[i].Equals(string.Empty))
			{
				int num2 = (sbyte)(arrShowText[i][0] - 48);
				int startIndex = 1;
				if (!WindowInfoScr.isDegit(arrShowText[i][0]))
				{
					num2 = 0;
					startIndex = 0;
				}
				int num3 = (num2 < 5) ? num2 : 0;
				MFont.normalFont[num3].drawString(g, arrShowText[i].Substring(startIndex), xSh + 8, ySh + i * (MyScreen.ITEM_HEIGHT - 3) + ((!Canvas.isSmartPhone) ? 14 : 6) - (num + (Canvas.isSmartPhone ? 2 : 0)), 0);
			}
		}
	}

	private void paintScreenXayBot(MyGraphics g)
	{
		Res.paintDlgFull(g, xDr, yDr, wCell, hCell, 25, tile, isDD: false, h0 - 28);
		Canvas.resetTrans(g);
		mScrollItemInventory.setStyle(listItem.size(), wTab, xDr, yDr + 28 + h0, wCell - 2, 27, styleUPDOWN: false, 0);
		mScrollItemInventory.setClip(g, xDr + 2, yDr + 23 + h0, wCell - 4, 31);
		for (int i = 0; i < listItem.size(); i++)
		{
			if (selectItemInventory == i && currentRow == 1)
			{
				g.setColor(6513507);
				g.fillRect(xDr + wTab * i, yDr + 23 + h0, wTab, 28);
			}
			ItemInInventory itemInInventory = (ItemInInventory)listItem.elementAt(i);
			itemInInventory.paint(g, xDr + wTab * i + wTab / 2, yDr + 36 + h0);
			g.setColor(14527502);
			g.fillRect(xDr + wTab * i, yDr + 22 + h0, 1, 29);
			if (itemSelect != null && itemSelect.itemID == itemInInventory.itemID)
			{
				g.setColor(3268607);
				g.drawRect(xDr + wTab * i + 1, yDr + 23 + h0, wTab - 2, 28);
				g.drawRect(xDr + wTab * i + 2, yDr + 24 + h0, wTab - 4, 26);
			}
		}
		g.setColor(14527502);
		g.fillRect(xDr + wTab * listItem.size(), yDr + 22 + h0, 1, 29);
		Canvas.resetTrans(g);
	}

	private void paintEffect(MyGraphics g)
	{
		Canvas.resetTrans(g);
		for (int i = 0; i < mEffect.size(); i++)
		{
			Effect effect = (Effect)mEffect.elementAt(i);
			effect.paint(g);
		}
	}

	public override void paint(MyGraphics g)
	{
		if (last != null)
		{
			last.paint(g);
		}
		if (type == 5)
		{
			paintScreenXayBot(g);
		}
		else if (type == 6)
		{
			paintListItem(g);
		}
		Canvas.resetTrans(g);
		paintItemEp(g);
		paintlazer(g);
		paintEffect(g);
		if (type == 5)
		{
			paintlazer(g);
			paintResult(g);
		}
		for (int i = 0; i < mShot.size(); i++)
		{
			Effect effect = (Effect)mShot.elementAt(i);
			effect.paint(g);
		}
		paintShowText(g);
		base.paint(g);
	}

	public void paintItemEp(MyGraphics g)
	{
		if (type == 5)
		{
			for (int i = 0; i < xItem.Length; i++)
			{
				if (i % 4 == 0)
				{
					g.setColor(16777215);
					g.fillRect(xItem[i], yItem[i] - 10, size, size);
					g.setColor(6513507);
					g.fillRect(xItem[i] + 1, yItem[i] - 9, size - 2, size - 2);
				}
				else
				{
					g.drawRegion(Res.getImgArrow(10), 0, frame * Arrow.ARROWSIZE[1][10], Arrow.ARROWSIZE[0][10], Arrow.ARROWSIZE[1][10], 0, xItem[i] - 3, yItem[i] - 10, 0);
				}
			}
		}
		else if (type == 6)
		{
			for (int j = 0; j < xItem.Length; j++)
			{
				g.setColor(16777215);
				g.fillRect(xItem[j], yItem[j] - 10, size, size);
				g.setColor(6513507);
				g.fillRect(xItem[j] + 1, yItem[j] - 9, size - 2, size - 2);
			}
		}
		if (type != 1)
		{
			if (itemSelect != null && type != 5 && type != 6)
			{
				itemSelect.paint(g, xItem[0] + 10, yItem[0]);
			}
			if (type == 6)
			{
				if (itemSelect != null)
				{
					itemSelect.paint(g, xItem[5] + size / 2, yItem[5] + 1);
					CheckHaveItemCell[5] = true;
				}
				if (selecItemNL1 != null)
				{
					selecItemNL1.paint(g, xItem[1] + size / 2, yItem[1] + 1);
					CheckHaveItemCell[0] = true;
				}
				if (CheckPaintItem[1])
				{
					Res.paintGem(g, Res.getGemByID(selecItemNL2.id).idImage, xItem[2] + size / 2, yItem[2]);
					CheckHaveItemCell[1] = true;
				}
				if (selecItemNL3 != null)
				{
					selecItemNL3.paint(g, xItem[3] + size / 2, yItem[3] + 1);
					CheckHaveItemCell[2] = true;
				}
				if (selecItemNL4 != null)
				{
					selecItemNL4.paint(g, xItem[4] + size / 2, yItem[4] + 1);
					CheckHaveItemCell[3] = true;
				}
				if (selecItemNL6 != null)
				{
					selecItemNL6.paint(g, xItem[6] + size / 2, yItem[6] + 1);
					CheckHaveItemCell[4] = true;
				}
			}
			if (itemSelect != null && type == 5)
			{
				Canvas.resetTrans(g);
				g.setClip(xItem[0], yItem[0] - size / 4 + hclip1 - 5, size, size);
				itemSelect.paint(g, xItem[0] + 11, yItem[0] + 1);
			}
		}
		if (type != 0 && isShowPopup && !infoPoup.Equals(string.Empty))
		{
			int num = yDr + h0 - 24;
			g.setColor(16777215);
			g.fillRect(xPopup - 60, num - 3, 120, 20);
			g.setColor(3222312);
			g.fillRect(xPopup - 59, num - 2, 118, 18);
			MFont.normalFont[0].drawString(g, infoPoup, xPopup, num, 2);
			paintlazer(g);
		}
	}

	private void updateResult()
	{
		if (createBot && Canvas.gameTick % 2 == 0 && hclip > 0)
		{
			hclip--;
			hclip1++;
		}
	}

	public override void update()
	{
		updateResult();
		updatelazer();
		for (int i = 0; i < mEffect.size(); i++)
		{
			Effect effect = (Effect)mEffect.elementAt(i);
			effect?.update();
			if (effect.wantDetroy && effect.type == -1)
			{
				createBot = true;
				mEffect.removeElement(effect);
			}
			if (effect.wantDetroy)
			{
				mEffect.removeElement(effect);
			}
		}
		if (Canvas.isSmartPhone && listItem.size() > 0)
		{
			doView();
		}
		if (type == 6 && isDap)
		{
			center = cmdWaiting;
			cmdDapItemTim.caption = string.Empty;
			if (timeDlay >= 0)
			{
				timeDlay--;
			}
			if (timeDlay < 0 && lazer.size() <= 0)
			{
				timeDlay = 15;
				resetCheck();
				isDap = false;
			}
		}
		if (dem >= 0)
		{
			dem--;
		}
		if (dem < 0 && isShot && Canvas.gameTick % 15 == 0 && tick < 3 && type == 6)
		{
			EffectDapDoTim effectDapDoTim = null;
			for (int j = 1; j < xItem.Length; j++)
			{
				effectDapDoTim = new EffectDapDoTim(xItem[j] + size / 2, yItem[j], xItem[0] + size / 2, yItem[0]);
				mShot.addElement(effectDapDoTim);
				effectDapDoTim = null;
			}
			tick++;
		}
		for (int k = 0; k < mShot.size(); k++)
		{
			Effect effect2 = (Effect)mShot.elementAt(k);
			effect2.update();
			if (effect2.wantDetroy)
			{
				Effect_XayBot effect_XayBot = null;
				Effect effect3 = null;
				for (int l = 0; l < 10; l++)
				{
					effect_XayBot = new Effect_XayBot(xItem[0] + size / 2, yItem[0], 0, yItem[0] + 80, -1);
					mEffect.addElement(effect_XayBot);
					effect_XayBot = null;
				}
				effect3 = new Effect(xItem[0] + size / 2, yItem[0], 50);
				mEffect.addElement(effect3);
				effect3 = null;
				mDestroy.addElement(effect2);
			}
		}
		for (int m = 0; m < mDestroy.size(); m++)
		{
			mShot.removeElement(mDestroy.elementAt(m));
		}
		mDestroy.removeAllElements();
		if (type == 5 || type == 6)
		{
			currentRow = 1;
		}
		frame++;
		if (frame >= 3)
		{
			frame = 0;
		}
		if (isdestroyitem && mEffect.size() <= 0 && type == 5)
		{
			if (timeDlay >= 0)
			{
				timeDlay--;
			}
			if (timeDlay < 0)
			{
				itemSelect = null;
				isdestroyitem = false;
				isXayBot = false;
				timeDlay = 15;
				cmdXay.caption = "Nghiền";
				center = cmdView;
				resetSelect();
			}
		}
		if (last != null)
		{
			last.update();
		}
		if (timeDelay > 0)
		{
			timeDelay--;
		}
		if (timeDelay <= 0)
		{
			timeDelay = 0;
		}
		bool flag = false;
		bool flag2 = false;
		if (Canvas.currentDialog == null)
		{
			if (Canvas.isSmartPhone)
			{
				if (mScrollShowText.FocusNew)
				{
					mScrollItemInventory.FocusNew = false;
					mScrollNguyenLieu.FocusNew = false;
				}
				else if (mScrollItemInventory.FocusNew)
				{
					mScrollShowText.FocusNew = false;
					mScrollNguyenLieu.FocusNew = false;
				}
				else if (mScrollNguyenLieu.FocusNew)
				{
					mScrollItemInventory.FocusNew = false;
					mScrollShowText.FocusNew = false;
				}
				if (mScrollItemInventory.FocusNew && !Canvas.menu.showMenu && timeDelay == 0)
				{
					currentRow = 1;
					ScrollResult scrollResult = mScrollItemInventory.updateKey();
					if (scrollResult.isDowning || scrollResult.isFinish)
					{
						selectItemInventory = scrollResult.selected;
						lastIndex1 = scrollResult.selected;
						flag = true;
						if (right != null && isShowText && Canvas.canTouch())
						{
							right.perform();
						}
					}
				}
				mScrollItemInventory.updatecm();
				if (mScrollNguyenLieu.FocusNew && !Canvas.menu.showMenu && timeDelay == 0)
				{
					currentRow = 0;
					ScrollResult scrollResult2 = mScrollNguyenLieu.updateKey();
					if (scrollResult2.isDowning || scrollResult2.isFinish)
					{
						indexTabNguyenLieu = scrollResult2.selected;
						lastIndex2 = scrollResult2.selected;
						flag2 = true;
						if (right != null && isShowText && Canvas.canTouch())
						{
							right.perform();
						}
					}
				}
				mScrollNguyenLieu.updatecm();
				ScrollResult scrollResult3 = null;
				if (mScrollShowText.FocusNew && !Canvas.menu.showMenu)
				{
					scrollResult3 = mScrollShowText.updateKey();
				}
				mScrollShowText.updatecm();
				if (!Canvas.isPointerDown)
				{
					if (mScrollItemInventory.FocusNew && flag)
					{
						if (selectItemInventory > -1 && selectItemInventory <= listItem.size() - 1)
						{
							if (lastIndex1 != -1)
							{
								selectItemInventory = lastIndex1;
							}
							cmdView.perform();
						}
					}
					else if (mScrollNguyenLieu.FocusNew && flag2 && indexTabNguyenLieu > -1 && indexTabNguyenLieu <= vnguyenLieu.size() - 1)
					{
						if (lastIndex2 != -1)
						{
							indexTabNguyenLieu = lastIndex2;
						}
						cmdView.perform();
					}
					mScrollShowText.FocusNew = false;
					mScrollItemInventory.FocusNew = false;
					mScrollNguyenLieu.FocusNew = false;
				}
			}
			else if (!isShowText)
			{
				ScrollResult scrollResult4 = mScrollItemInventory.updateKey();
				if (scrollResult4.isDowning || scrollResult4.isFinish)
				{
					selectItemInventory = scrollResult4.selected;
					mScrollItemInventory.moveTo(selectItemInventory * (wTab + 2));
				}
				mScrollItemInventory.updatecm();
				ScrollResult scrollResult5 = mScrollNguyenLieu.updateKey();
				if (scrollResult5.isDowning || scrollResult5.isFinish)
				{
					indexTabNguyenLieu = scrollResult5.selected;
					mScrollNguyenLieu.moveTo(indexTabNguyenLieu * (wTab + 2));
				}
				mScrollNguyenLieu.updatecm();
			}
			else
			{
				ScrollResult scrollResult6 = mScrollShowText.updateKey();
				mScrollShowText.updatecm();
			}
		}
		if (Canvas.isPointerDownItem && type == 6)
		{
			for (int n = 1; n < xItem.Length; n++)
			{
				if (Canvas.px >= xItem[n] && Canvas.px <= xItem[n] + size && Canvas.py >= yItem[n] - 10 && Canvas.py <= yItem[n] - 10 + size)
				{
					currentCell = (sbyte)n;
					selectItemInventory = 0;
					mScrollItemInventory.moveTo(wTab);
				}
			}
			Canvas.isPointerDownItem = false;
		}
		base.update();
	}

	private bool checKselecitem(ItemInInventory item)
	{
		switch (currentCell)
		{
		case 1:
			if ((itemSelect != null && itemSelect.itemID == item.itemID) || (selecItemNL3 != null && selecItemNL3.itemID == item.itemID) || (selecItemNL4 != null && selecItemNL4.itemID == item.itemID) || (selecItemNL6 != null && selecItemNL6.itemID == item.itemID))
			{
				return true;
			}
			break;
		case 3:
			if ((itemSelect != null && itemSelect.itemID == item.itemID) || (selecItemNL1 != null && selecItemNL1.itemID == item.itemID) || (selecItemNL4 != null && selecItemNL4.itemID == item.itemID) || (selecItemNL6 != null && selecItemNL6.itemID == item.itemID))
			{
				return true;
			}
			break;
		case 4:
			if ((itemSelect != null && itemSelect.itemID == item.itemID) || (selecItemNL3 != null && selecItemNL3.itemID == item.itemID) || (selecItemNL1 != null && selecItemNL1.itemID == item.itemID) || (selecItemNL6 != null && selecItemNL6.itemID == item.itemID))
			{
				return true;
			}
			break;
		case 5:
			if ((selecItemNL1 != null && selecItemNL1.itemID == item.itemID) || (selecItemNL3 != null && selecItemNL3.itemID == item.itemID) || (selecItemNL4 != null && selecItemNL4.itemID == item.itemID) || (selecItemNL6 != null && selecItemNL6.itemID == item.itemID))
			{
				return true;
			}
			break;
		case 6:
			if ((itemSelect != null && itemSelect.itemID == item.itemID) || (selecItemNL3 != null && selecItemNL3.itemID == item.itemID) || (selecItemNL4 != null && selecItemNL4.itemID == item.itemID) || (selecItemNL1 != null && selecItemNL1.itemID == item.itemID))
			{
				return true;
			}
			break;
		}
		return false;
	}

	public static bool isPointer(int x, int y, int w, int h)
	{
		if (Canvas.isPointerDown)
		{
			if (Canvas.px >= x && Canvas.px <= x + w && Canvas.py >= y && Canvas.py <= y + h)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override void updateKey()
	{
		if (isShowText)
		{
			if (Canvas.keyPressed[2] && type != 5)
			{
				Canvas.keyPressed[2] = false;
				mScrollShowText.cmtoY -= 50;
				if (mScrollShowText.cmtoY < 0)
				{
					mScrollShowText.cmtoY = 0;
				}
			}
			else if (Canvas.keyPressed[8])
			{
				Canvas.keyPressed[8] = false;
				mScrollShowText.cmtoY += 50;
				if (mScrollShowText.cmtoY > mScrollShowText.cmyLim)
				{
					mScrollShowText.cmtoY = mScrollShowText.cmyLim;
				}
			}
		}
		else
		{
			if (Canvas.keyPressed[2] && type != 5)
			{
				Canvas.keyPressed[2] = false;
				currentCell--;
				if (selecItemNL1 != null)
				{
					LisItemSelect.addElement(selecItemNL1);
				}
				if (selecItemNL3 != null)
				{
					LisItemSelect.addElement(selecItemNL3);
				}
				if (selecItemNL4 != null)
				{
					LisItemSelect.addElement(selecItemNL4);
				}
				if (itemSelect != null)
				{
					LisItemSelect.addElement(itemSelect);
				}
				if (selecItemNL6 != null)
				{
					LisItemSelect.addElement(selecItemNL6);
				}
				DropItem = false;
				if (currentCell < 1)
				{
					currentCell = 6;
				}
				if (type == 6)
				{
					selectItemInventory = 0;
					mScrollItemInventory.moveTo(wTab);
				}
			}
			else if (Canvas.keyPressed[8])
			{
				Canvas.keyPressed[8] = false;
				DropItem = false;
				if (selecItemNL1 != null)
				{
					LisItemSelect.addElement(selecItemNL1);
				}
				if (selecItemNL3 != null)
				{
					LisItemSelect.addElement(selecItemNL3);
				}
				if (selecItemNL4 != null)
				{
					LisItemSelect.addElement(selecItemNL4);
				}
				if (itemSelect != null)
				{
					LisItemSelect.addElement(itemSelect);
				}
				if (selecItemNL6 != null)
				{
					LisItemSelect.addElement(selecItemNL6);
				}
				currentCell++;
				if (currentCell > 6)
				{
					currentCell = 1;
				}
				if (type == 6)
				{
					selectItemInventory = 0;
					mScrollItemInventory.moveTo(wTab);
				}
			}
			if (Canvas.keyPressed[4])
			{
				Canvas.keyPressed[4] = false;
				selectItemInventory--;
				if (selectItemInventory < 0)
				{
					selectItemInventory = listItem.size() - 1;
				}
				mScrollItemInventory.moveTo(selectItemInventory * wTab);
			}
			else if (Canvas.keyPressed[6])
			{
				Canvas.keyPressed[6] = false;
				selectItemInventory++;
				if (selectItemInventory > listItem.size() - 1)
				{
					selectItemInventory = 0;
				}
				mScrollItemInventory.moveTo(selectItemInventory * wTab);
			}
		}
		base.updateKey();
	}

	public static bool isBH(int id)
	{
		return id >= 0 && id <= 4;
	}

	public static bool isDaMayMan(int id)
	{
		return (id >= 5 && id <= 7) || id == 155 || id == 156;
	}

	public static bool isLKD(int id)
	{
		return (id >= 8 && id <= 11) || id == 66 || id == 245 || id == 157 || id == 158;
	}

	public void setInfoItem(int itemid)
	{
		if (selectItemInventory < listItem.size())
		{
			ItemInInventory itemInInventory = (ItemInInventory)listItem.elementAt(selectItemInventory);
			if (itemInInventory != null && itemInInventory.itemID == itemid)
			{
				arrShowText = MFont.normalFont[0].splitFontBStrInLine(itemInInventory.getDescription(showResellPrice: false), wSh - 10);
			}
		}
	}

	public void doFinishInbue()
	{
		getListGem(getItem: false, recheck: true);
		isShowPopup = true;
	}

	public override void switchToMe()
	{
		base.switchToMe();
	}

	public override void switchToMe(MyScreen lastSCR)
	{
		last = lastSCR;
		base.switchToMe(lastSCR);
	}
}
