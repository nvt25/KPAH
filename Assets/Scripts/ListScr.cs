using System;

public class ListScr : MyScreen
{
	public static ListScr me;

	public static sbyte FRIEND;

	public static sbyte CLAN = 1;

	public static sbyte MSG_CLAN = 2;

	public static sbyte STRONGER = 4;

	public static sbyte RIGHER = 3;

	public static sbyte TOP_CLAN = 5;

	public static sbyte MANAGER_LIST = 6;

	public static sbyte TOP = 7;

	public static sbyte TOP_CUC_BO = 8;

	public mVector freindList;

	public mVector list;

	private int w;

	private int h;

	private int height;

	private int type;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int selected;

	public static int xTr;

	public static int yTr;

	private string title;

	public sbyte page;

	private MyScreen lastScr;

	private Command cmd;

	private int pa;

	private bool trans;

	private int x0;

	private int dir0 = 1;

	private int x1;

	private int dir1 = 1;

	private int x2;

	private int dir2 = 1;

	private string[] nameManager;

	public bool transY;

	public bool canSelecet;

	public bool isTabIp;

	public bool isPaintFc;

	private long timePointY;

	private long count;

	private long timeOpen;

	private long timeDelay;

	private int pyLast;

	private int dyTran;

	private int dxTran;

	private int xBegin;

	private int yBegin;

	private int wTouch;

	private int hTouch;

	private int curentTabUpdate;

	private int timeHold;

	public float vY;

	public ListScr()
	{
		right = new Command("Đóng");
		ActionPerform action = delegate
		{
			lastScr.switchToMe();
			for (int i = 0; i < list.size(); i++)
			{
				object obj = list.elementAt(i);
				if (obj != null)
				{
					obj = null;
				}
			}
			list.removeAllElements();
			GC.Collect();
			lastScr = null;
		};
		right.action = action;
		cmd = new Command();
		ActionPerform action2 = delegate
		{
			doSelected(list.elementAt(selected));
		};
		cmd.action = action2;
		left = new Command("Menu");
		ActionPerform action3 = delegate
		{
			if (selected > -1)
			{
				doMenu();
			}
		};
		left.action = action3;
	}

	public static ListScr gI()
	{
		return (me != null) ? me : (me = new ListScr());
	}

	public override void switchToMe()
	{
		if (Canvas.currentScreen != this)
		{
			selected = -1;
			page = 0;
			cmy = (cmtoY = 0);
			if (lastScr == null)
			{
				lastScr = Canvas.gameScr;
			}
			base.switchToMe();
			init();
		}
	}

	public override void init()
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
		w = num - 41;
		h = num2 - 56;
		if (Canvas.w * Canvas.h > 153600)
		{
			xTr = (Canvas.w - num) / 2;
			yTr = (Canvas.h - num2) / 2;
		}
		cmyLim = list.size() * height - (h - 42);
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
	}

	protected void doMenu()
	{
		mVector mVector = new mVector();
		if (type == STRONGER || type == RIGHER || type == TOP_CLAN || type == CLAN)
		{
			if (type == TOP_CLAN)
			{
				Command command = new Command("Danh sách quản lý bang.");
				ActionPerform actionPerform = command.action = delegate
				{
					GameService.gI().requestQuanLyBang(((ClanInfo)list.elementAt(selected)).id);
				};
				mVector.addElement(command);
			}
			Command command2 = new Command("Xem thêm");
			ActionPerform actionPerform2 = command2.action = delegate
			{
				Canvas.startWaitDlg();
				if (type == CLAN)
				{
					GameService.gI().requestClanList(((Char)list.elementAt(selected)).idClan, ++page);
				}
				else
				{
					GameService.gI().requestTopStronger_Righer(type, ++page);
				}
			};
			mVector.addElement(command2);
		}
		if (type == FRIEND)
		{
			Command command3 = new Command("Xóa bạn");
			ActionPerform actionPerform3 = command3.action = delegate
			{
				if (freindList.size() == 0)
				{
					Canvas.startOKDlg("Danh sách trống");
				}
				else
				{
					ActionPerform yesAction2 = delegate
					{
						GameService.gI().removeFriend(((Char)list.elementAt(selected)).name);
						list.removeElementAt(selected);
						freindList.removeElementAt(selected);
						selected--;
						if (selected < 0)
						{
							selected = 0;
						}
						setPos();
						cmyLim = list.size() * height - (h - 32);
						if (cmyLim < 0)
						{
							cmyLim = 0;
						}
						Canvas.startOKDlg("Đã xóa bạn");
					};
					Canvas.startYesNoDlg("Bạn có muốn xóa người này không ?", yesAction2);
				}
			};
			mVector.addElement(command3);
		}
		if (type == CLAN)
		{
			if (((Char)list.elementAt(0)).idClan == Canvas.gameScr.mainChar.idClan)
			{
				Command command4 = new Command("Nhắn tin toàn bang");
				ActionPerform actionPerform4 = command4.action = delegate
				{
					ActionPerform ok = delegate
					{
						string text = Canvas.inputDlg.tfInput.getText();
						if (!text.Equals(string.Empty))
						{
							Canvas.startOKDlg("Đã gửi tin");
							GameService.gI().msgClanAll(text, 0, 0);
						}
					};
					Canvas.inputDlg.setInfo("Nội dung", ok, TField.INPUT_TYPE_ANY, 100, isMaxW: false);
					Canvas.inputDlg.show();
				};
				mVector.addElement(command4);
			}
			if (((Char)list.elementAt(selected)).idClan == Canvas.gameScr.mainChar.idClan && (Canvas.gameScr.mainChar.isMaster == 0 || Canvas.gameScr.mainChar.isMaster == 1) && !((Char)list.elementAt(selected)).name.Equals(Canvas.gameScr.mainChar.name))
			{
				Command command5 = new Command("Mời khỏi bang");
				ActionPerform actionPerform5 = command5.action = delegate
				{
					ActionPerform yesAction = delegate
					{
						GameService.gI().requestEvictionClan(((Char)list.elementAt(selected)).name);
						list.removeElementAt(selected);
						selected--;
						Canvas.endDlg();
						setPos();
					};
					Canvas.startYesNoDlg("Bạn có chắc muốn mời " + ((Char)list.elementAt(selected)).name + " khỏi bang không ?", yesAction);
				};
				mVector.addElement(command5);
			}
		}
		else if (type == MSG_CLAN && Canvas.gameScr.mainChar.isMaster == 0)
		{
			Command command6 = new Command("Xóa tin nhắn");
			ActionPerform actionPerform6 = command6.action = delegate
			{
				GameService.gI().msgClanAll(null, 2, ((ChatInfo)list.elementAt(selected)).ID);
				list.removeElementAt(selected);
				selected--;
				if (selected < 0)
				{
					selected = 0;
				}
			};
			mVector.addElement(command6);
		}
		if (mVector.size() > 0)
		{
			Canvas.menu.startAt(mVector, 0);
		}
	}

	public void doSelected(object ch)
	{
		if (type == MSG_CLAN)
		{
			ViewTextDlg.gI().setInfo(((ChatInfo)ch).content, "TIN NHẮN");
			return;
		}
		if (type == TOP_CLAN)
		{
			GameService.gI().requestClanInfo(((ClanInfo)ch).id);
			return;
		}
		ActionPerform ok = delegate
		{
			GameService.gI().sendMsgPrivate(((Char)ch).name, Canvas.inputDlg.tfInput.getText());
			Canvas.endDlg();
		};
		Canvas.inputDlg.setInfo("Nội dung tin nhắn", ok, TField.INPUT_TYPE_ANY, 100, isMaxW: false);
		Canvas.inputDlg.show();
	}

	public void setInfo(mVector list, int type, string title)
	{
		selected = -1;
		if (list.size() == 0)
		{
			page = -1;
		}
		else
		{
			this.list = list;
		}
		this.type = type;
		if (type == MSG_CLAN)
		{
			height = 30;
		}
		else
		{
			height = 40;
		}
		this.title = title;
		setPos();
		if (this.list != null)
		{
			cmyLim = this.list.size() * height - (h - 32);
		}
		if (cmyLim < 0)
		{
			cmyLim = 0;
		}
		if (type == MANAGER_LIST && nameManager == null)
		{
			nameManager = new string[3]
			{
				"Bang chủ",
				"Phó bang",
				"Trưởng lão"
			};
		}
	}

	private void setPos()
	{
		if (type != MSG_CLAN && type != TOP_CLAN)
		{
			for (int i = 0; i < list.size(); i++)
			{
				Char @char = (Char)list.elementAt(i);
				@char.x = 25;
				@char.y = (short)(i * height + height / 2 + @char.height / 2 - 5);
			}
		}
	}

	public override void update()
	{
		updateKeyDong();
		if (lastScr != null)
		{
			lastScr.update();
		}
	}

	public override void updateKey()
	{
		xBegin = 20 + xTr;
		yBegin = 46 + yTr;
		wTouch = w;
		hTouch = h - 24;
		base.updateKey();
	}

	public override void paint(MyGraphics g)
	{
		if (lastScr != null)
		{
			lastScr.paint(g);
		}
		Canvas.resetTrans(g);
		Res.paintDlgFull(g, 20 + xTr, 10 + yTr, w, h);
		MFont.bigFont.drawString(g, title, 20 + w / 2 + xTr, 15 + yTr, 2);
		g.translate(20, 37);
		g.setClip(4 + xTr, yTr, w - 8, h - 41);
		g.translate(0 + xTr, -cmy + yTr);
		if (selected > -1)
		{
			Res.paintSelected(g, 4, selected * height, w - 9, height);
		}
		if (type == TOP_CLAN)
		{
			paintTopClan(g);
		}
		else if (type == MSG_CLAN)
		{
			paintMsgClan(g);
		}
		else
		{
			paintChar(g);
		}
		base.paint(g);
	}

	private void paintTopClan(MyGraphics g)
	{
		int num = cmy / height;
		if (num <= 0)
		{
			num = 0;
		}
		int num2 = num + h / height + 1;
		if (num2 >= list.size())
		{
			num2 = list.size();
		}
		for (int i = num; i < num2; i++)
		{
			ClanInfo clanInfo = (ClanInfo)list.elementAt(i);
			if (clanInfo == null)
			{
				continue;
			}
			int num3 = 0;
			if (clanInfo.id != -1 && GameData.getImgIcon(clanInfo.id) != null)
			{
				num3 = 12;
				GameData.paintIcon(g, (short)(clanInfo.id + 1000), 16, i * height + 13);
			}
			string empty = string.Empty;
			empty = clanInfo.name + " - Cấp độ: " + ((clanInfo.level <= -1) ? "?" : (clanInfo.level + string.Empty));
			MFont.normalFont[0].drawString(g, empty, 11 + num3, i * height + 4, 0);
			int width = MFont.normalFont[0].getWidth(empty);
			if (clanInfo.nationID > -1)
			{
				g.drawRegion(Res.imgNation, 0, clanInfo.nationID * 11, 11, 11, 0, 11 + num3 + 25 + width, i * height + 4, 0);
			}
			string text = "Bang chủ: " + clanInfo.master + " - Tiền: " + clanInfo.money + "xu - Thành viên: " + clanInfo.members;
			if (i == selected)
			{
				int width2 = MFont.arialFontW.getWidth(text);
				if (width2 > w - 10 && selected == i)
				{
					if (dir1 == 1)
					{
						x1--;
						if (x1 < w - 20 - width2)
						{
							dir1 = -1;
						}
					}
					else
					{
						x1++;
						if (x1 > 5)
						{
							dir1 = 1;
						}
					}
				}
			}
			MFont.arialFontW.drawString(g, text, 11 + ((i == selected) ? x1 : 0), i * height + 20, 0);
		}
	}

	private void paintMsgClan(MyGraphics g)
	{
		string empty = string.Empty;
		int num = cmy / height;
		if (num <= 0)
		{
			num = 0;
		}
		int num2 = num + h / height + 1;
		if (num2 >= list.size())
		{
			num2 = list.size();
		}
		for (int num3 = num2 - 1; num3 >= num; num3--)
		{
			ChatInfo chatInfo = (ChatInfo)list.elementAt(num3);
			if (chatInfo != null)
			{
				MFont.borderFont.drawString(g, chatInfo.name, 7, num3 * height, 0);
				empty = ((MFont.arialFont.getWidth(chatInfo.content) <= w - 10) ? chatInfo.content : (MFont.arialFont.splitFontBStrInLine(chatInfo.content, w - 10)[0] + "..."));
				MFont.arialFont.drawString(g, empty, 7, num3 * height + 15, 0);
			}
		}
	}

	public void getInfoCharString()
	{
		int num = cmy / height;
		int num2 = num + h / height + 1;
		if (num2 >= list.size())
		{
			num2 = list.size();
		}
		Char @char = null;
		ItemInInventory itemInInventory = null;
		ItemTemplate itemTemplate = null;
		for (int i = num; i < num2; i++)
		{
			@char = (Char)list.elementAt(i);
			string text = "Cấp độ: " + @char.level;
			int num3 = @char.wearingItems.size();
			for (int j = 0; j < num3; j++)
			{
				itemInInventory = (ItemInInventory)@char.wearingItems.elementAt(j);
				if (itemInInventory != null)
				{
					itemTemplate = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
					if (itemTemplate != null)
					{
					}
					string text2 = text;
					text = text2 + " - " + ItemTemplate.nameItem[itemTemplate.type] + ": " + itemInInventory.level;
					if (itemInInventory.plusTemplate > 0)
					{
						text = text + "+" + itemInInventory.plusTemplate;
					}
				}
			}
		}
	}

	private void paintChar(MyGraphics g)
	{
		int num = cmy / height;
		if (num <= 0)
		{
			num = 0;
		}
		int num2 = num + h / height + 1;
		if (num2 >= list.size())
		{
			num2 = list.size();
		}
		Char @char = null;
		ItemInInventory itemInInventory = null;
		ItemTemplate itemTemplate = null;
		for (int i = num; i < num2; i++)
		{
			@char = (Char)list.elementAt(i);
			if (@char == null)
			{
				continue;
			}
			@char.paintAvatar(g);
			string text = "Cấp độ: " + ((@char.level <= -1) ? "?" : (@char.level + string.Empty));
			int num3 = @char.wearingItems.size();
			for (int j = 0; j < num3; j++)
			{
				itemInInventory = (ItemInInventory)@char.wearingItems.elementAt(j);
				if (itemInInventory != null)
				{
					itemTemplate = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
					if (itemTemplate != null)
					{
					}
					string text2 = text;
					text = text2 + " - " + ItemTemplate.nameItem[itemTemplate.type] + ": " + itemInInventory.level;
					if (itemInInventory.plusTemplate > 0)
					{
						text = text + "+" + itemInInventory.plusTemplate;
					}
				}
			}
			int num4 = 0;
			if (@char.idClan != -1 && GameData.getImgIcon(@char.idClan) != null)
			{
				num4 = 8;
				GameData.paintIcon(g, (short)(@char.idClan + 1000), 45, i * height + 12);
			}
			string text3 = Canvas.getPriceMoney(@char.charXu, @char.luong);
			string text4 = " - CT: " + @char.congTrang + " - LT: " + @char.lienTram;
			if (!text3.Equals(string.Empty))
			{
				text3 = " (" + text3 + ")";
			}
			int num5 = MFont.arialFontW.getWidth(@char.name + text3 + text4) + 30;
			if (num5 > w - 55 && selected == i)
			{
				if (dir2 == 1)
				{
					x2--;
					if (x2 < w - 65 - num5)
					{
						dir2 = -1;
					}
				}
				else
				{
					x2++;
					if (x2 > 5)
					{
						dir2 = 1;
					}
				}
			}
			g.setClip(45, cmy, w - 49, h - 41);
			MFont.normalFont[0].drawString(g, @char.name + text3 + ((type != MANAGER_LIST || @char.isMaster >= 3) ? string.Empty : (" - " + nameManager[@char.isMaster])) + text4, 45 + num4 + ((i == selected) ? x2 : 0), i * height + 5, 0);
			int num6 = 0;
			num6 = MFont.normalFont[0].getWidth(@char.name + text3 + ((type != MANAGER_LIST || @char.isMaster >= 3) ? string.Empty : (" - " + nameManager[@char.isMaster])) + text4);
			if (@char.nationID > -1)
			{
				g.drawRegion(Res.imgNation, 0, @char.nationID * 11, 11, 11, 0, 45 + num4 + ((i == selected) ? x2 : 0) + num6 + 5, i * height + 9, 0);
			}
			int width = MFont.arialFontW.getWidth(text);
			if (width > w - 45 && selected == i)
			{
				if (dir0 == 1)
				{
					x0--;
					if (x0 < w - 55 - width)
					{
						dir0 = -1;
					}
				}
				else
				{
					x0++;
					if (x0 > 5)
					{
						dir0 = 1;
					}
				}
			}
			MFont.arialFontW.drawString(g, text, 45 + ((i == selected) ? x0 : 0), i * height + 20, 0);
			g.setClip(0, cmy, w - 4, h - 31);
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
			if (selected > -1)
			{
				if (cmd != null)
				{
					cmd.perform();
				}
				else if (left != null)
				{
					left.perform();
				}
			}
			x0 = 0;
			canSelecet = false;
			return;
		}
		if (Canvas.isPointerDownItem && Canvas.isPointer(xBegin, yBegin, wTouch, hTouch))
		{
			pyLast = Canvas.pyLast;
			Canvas.isPointerDownItem = false;
			timeDelay = count;
			pa = cmy;
			transY = true;
			vY = 0f;
		}
		if (transY)
		{
			long num = count - timeDelay;
			int num2 = pyLast - Canvas.py;
			pyLast = Canvas.py;
			if (Canvas.isPointerDown)
			{
				if (count % 2 == 0L)
				{
					dyTran = Canvas.py;
					dxTran = Canvas.px;
					timePointY = count;
				}
				vY = 0f;
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
				cmy = cmtoY;
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
					isPaintFc = false;
				}
			}
			if (Canvas.isPointerRelease)
			{
				transY = false;
				int num3 = (int)(count - timePointY);
				float num4 = dyTran - Canvas.py;
				float num5 = dxTran - Canvas.px;
				if (Canvas.beginMoveCmrY())
				{
					vY = num4 / (float)num3 * 10f;
				}
				timePointY = -1L;
				if (Main.canvas.canPutKey() && timeHold != 5)
				{
					if (num <= 4)
					{
						timeHold = 0;
						timeOpen = 5L;
						canSelecet = true;
						checkSelect();
					}
				}
				else if (timeHold >= 5)
				{
					timeHold = 0;
					timeOpen = 5L;
					canSelecet = true;
					checkSelect();
				}
			}
		}
		moveCamera();
	}

	public void checkSelect()
	{
		int num = 36;
		int num2 = selected = (cmtoY + Canvas.py - num - yTr) / height;
		if (selected < 0)
		{
			selected = 0;
		}
		if (selected > list.size() - 1)
		{
			selected = list.size() - 1;
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
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
	}
}
