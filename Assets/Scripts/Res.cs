using System;
using System.IO;
using UnityEngine;

public class Res
{
	public const int MAX_DAM = 2000000;

	public const string xu = "xu";

	public const string luong = "lượng";

	public const int COLLECT_ITEM_RANGE = 35;

	public const string doYouWantSell = "Muốn nhờ ta bán gì nào";

	public const short MAX_MONSTER_TEMPLATE = 115;

	public const sbyte LEG = 0;

	public const sbyte BODY = 1;

	public const sbyte HEAD = 2;

	public const sbyte HAT = 3;

	public const sbyte COAT = 4;

	public const sbyte WP = 5;

	public const string doYouWantBuyIten = "Bạn có muốn mua vật phẩm này không ?";

	public const string talk = "Nói chuyện";

	public const string buy = "Bán";

	public const string shell = "Mua";

	public const string SELECT = "Chọn";

	public const string CLOSE = "Đóng";

	public static string PORTION_ITEM_NAME = string.Empty;

	public static string PORTION_ITEM_NAME_CLAN = string.Empty;

	public static string PORTION_ITEM_NAME2 = string.Empty;

	public static mVector itemTemplates = new mVector();

	public static mVector gemTemplate = new mVector();

	public static mVector shopTemplate = new mVector();

	public static XaphuTemplate[] XAPHU;

	public static Res me;

	public static int hString = 16;

	public static sbyte mauTile;

	public static LoadData load;

	public static readonly string[][] NPC_DEFAULT_CHAT = new string[32][]
	{
		new string[1]
		{
			"Vào trong đi cậu. Đủ loại HP từ lớn đến bé!"
		},
		new string[3]
		{
			"Hò ơ… mua gì cũng có, hỏi gì cũng biết",
			"Gánh hàng nhỏ nhưng món gì cũng có đây",
			"Mua gì đây, nói ta nghe"
		},
		new string[3]
		{
			"Vũ khí ở đây rất lợi hại, vào trong tôi cho cậu xem!",
			"Ngươi muốn sửa chữa đồ?",
			"Ngươi muốn luyện đồ?"
		},
		new string[3]
		{
			"Mua giáp hộ thân nào …",
			"Mua giáp của ta, ngươi sẽ luôn được bảo vệ an toàn",
			"Đến với ta, ta sẽ nói cho ngươi biết tại sao người ta gọi ta là Thiết Bì"
		},
		new string[1]
		{
			"Trách nhiệm của ta là bảo vệ ngôi làng này."
		},
		new string[3]
		{
			"Cố gắng lên con, hãy hoàn thành các nhiệm vụ đi nhé",
			"Anh hùng xuất thiếu niên..anh hùng xuất thiếu niên",
			"Con là thành viên của làng Nghĩa Sĩ này ! Hãy nhớ lấy điều đó"
		},
		new string[3]
		{
			"Chào chàng trai trẻ",
			"Muốn mua ngọc thì vào nhà",
			"Ngươi muốn mua vật phẩm để luyện đồ?"
		},
		new string[3]
		{
			"Đường xa vạn lý, không làm nản lòng xa phu ta đây",
			"Đi lâu thành lối, lối thành đường đi.",
			"Nói ta nghe ngươi muốn đi đâu?"
		},
		new string[1]
		{
			string.Empty
		},
		new string[3]
		{
			"Gửi đồ chỗ ta là an toàn nhất đó",
			"Ngươi muốn nhờ ta giữ đồ?",
			"Ngươi có nhiều đồ muốn gửi àh?"
		},
		new string[1]
		{
			"Bạn phải có vé mới được lên tàu."
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[1]
		{
			"Muốn nhờ ta bán gì nào"
		},
		new string[3]
		{
			"Tập luyện nào, tập luyện nào ..",
			"Sức khỏe trước đã, tập luyện nào …",
			"Cho ta xem khả năng của các ngươi nào !!"
		},
		new string[3]
		{
			"Giao tiền ta giữ nào, yên tâm nhé",
			"Ngươi muốn đổi tiền à, nói ta nghe",
			"Ta lấy chữ Tín làm đầu, yên tâm nào"
		},
		new string[1]
		{
			"Chà, lâu rồi mới có người đi qua."
		},
		new string[1]
		{
			"Ngươi muốn thuê gì?"
		},
		new string[1]
		{
			"Hãy quản lý bang của ngươi thật tốt vào."
		},
		new string[3]
		{
			"Hò ơ… mua gì cũng có, hỏi gì cũng biết",
			"Gánh hàng nhỏ nhưng món gì cũng có đây",
			"Mua gì đây, nói ta nghe"
		},
		new string[3]
		{
			"Mua giáp hộ thân nào …",
			"Mua giáp của ta, ngươi sẽ luôn được bảo vệ an toàn",
			"Đến với ta, ta sẽ nói cho ngươi biết tại sao người ta gọi ta là Giáp Sư"
		},
		new string[3]
		{
			"Vũ khí ở đây rất lợi hại, vào trong tôi cho cậu xem!",
			"Ngươi muốn sửa chữa đồ?",
			"Ngươi muốn luyện đồ?"
		},
		new string[3]
		{
			"Chào chàng trai trẻ",
			"Muốn mua ngọc thì vào nhà",
			"Ngươi muốn mua vật phẩm để luyện đồ?"
		},
		new string[3]
		{
			"Gửi đồ chỗ ta là an toàn nhất đó",
			"Ngươi muốn nhờ ta giữ đồ?",
			"Ngươi có nhiều đồ muốn gửi àh?"
		},
		new string[3]
		{
			"Giao tiền ta giữ nào, yên tâm nhé",
			"Ngươi muốn đổi tiền à, nói ta nghe",
			"Ta lấy chữ Tín làm đầu, yên tâm nào"
		}
	};

	public static string[] newNameAtbItem = new string[9]
	{
		"Tăng Hp ",
		"Tăng Mp ",
		"Sức mạnh +",
		"Nhanh nhẹn +",
		"Tinh thần +",
		"Sức khoẻ +",
		string.Empty,
		"Chí mạng tăng ",
		"Tăng st chí mạng "
	};

	public static string[] nameAtbItemLock = new string[3]
	{
		"Tăng công ",
		"Tăng thủ ma ",
		"Tăng thủ vật "
	};

	private static MyRandom rd = new MyRandom();

	public static readonly string[] GENDERNAME = new string[3]
	{
		"bất kỳ",
		"nam",
		"nữ"
	};

	public static Image[] imgSoft;

	public static Image imgPlus;

	public static Image imgShadow;

	public static Image imgSelect;

	public static Image imgSelect1;

	public static Image imgSelect2;

	public static Image imgPanel;

	public static Image imgShadowPet;

	public static Image imgSelectFc;

	public static Image[] imgEffect = new Image[63];

	public static Image imgExplosion;

	public static Image imgGrid;

	public static Image imgDie;

	public static Image imgEye;

	public static Image imgEffNew;

	public static Image[] imgGround = new Image[3];

	public static Image[] imgArrow = new Image[20];

	public static Image[] imgInfoWindow;

	public static Image[] imgNewBt = new Image[5];

	public static Image imgWaitIcon;

	public static Image imgNguHanh;

	public static Image[] imgLeg;

	public static Image[] imgInv;

	public static Image[] imgBox = new Image[2];

	public static Image[] imgCell = new Image[3];

	public static Image imgBar;

	public static Image imgCmdBar;

	public static Image imgMSG;

	public static Image imgInfoWindowt;

	public static FrameImage imgSmoke;

	public static FrameImage backSmoke;

	public static FrameImage imgNo;

	public static Image imgtileSmall;

	public static Image imgWayPoint;

	public static Image imgKham;

	public static Image imgKc;

	public static Image imgKhung;

	public static Image icon_automode;

	public static Image imgNation;

	public static Image imgBgPopup;

	public static Image imgBGTiemNang;

	public static Image imgBgTrangBi;

	public static Image imgPopupNgoc;

	public static Image imgPopupGoc;

	public static Image imgIconSkillKiem;

	public static Image imgIconSkillDao;

	public static Image imgIconSkillPs;

	public static Image imgIconSkillBua;

	public static Image imgIconSkillCung;

	public static Image imgButtonBar;

	public static Image imgChat;

	public static Image imgMapMini;

	public static Image imgSwapQuickSlot;

	public static Image imgFocusActor;

	public static Image imgChatTouch;

	public static Image imgSwapClothes;

	public static Image imgTG;

	public static Image imgIce;

	public static Image imgStone;

	public static Image imgInv3;

	public static Image imgButtonBar1;

	public static Image imgCheck;

	public static Image imgK0;

	public static int wKhung;

	public static int wTrangbi;

	public static int wimgBgPopup;

	public static mVector allImageMain = new mVector();

	public static sbyte[] effSh;

	public static mVector quanao = new mVector();

	public static WPSplashInfo[][] wpSplashInfos = new WPSplashInfo[5][];

	public static sbyte[] percent = new sbyte[5]
	{
		20,
		50,
		10,
		70,
		20
	};

	public static MyHashTable allMonterData = new MyHashTable();

	public static MonsterTemplate[] monsterTemplates = new MonsterTemplate[115];

	private bool isLocal;

	public static CharPartInfo defaultBody;

	public static CharPartInfo defaultLeg;

	public static CharPartInfo defaultHead;

	public static MyHashTable treeInfos = new MyHashTable();

	public static PotionTemplate[] potionTemplates = new PotionTemplate[Char.CHAR_POTION];

	public static int[] color = new int[7]
	{
		8346120,
		15852810,
		14527502,
		14595691,
		11241794,
		4858880,
		2181450
	};

	private static int wh = 6;

	private static int num;

	public static string stMoney = "xu";

	public static string stVND = "lượng";

	private static MyRandom r = new MyRandom();

	public static short[][] localXaphu;

	public static string[][] namMap;

	public static string[][][] nameMap;

	public static short[][][] locationMap;

	public static string[] khamProperty;

	public static sbyte[] idNgocKham;

	public static readonly string[] nameBigMap = new string[17]
	{
		"Làng Sơn Nam",
		"Giao Châu",
		"Tiên Du",
		"Phù Liệt",
		"Kỳ Bố",
		"Hàm Tử",
		"Thạch Giang",
		"Đông Sơn",
		"Tử Quan",
		"Trường Giang",
		"Lộc Trĩ",
		"Sơn Lâm",
		"Hang động",
		"Hang mãng xà",
		"Hang thằn lằn",
		"Đấu trường",
		"Khu vực 1"
	};

	public static readonly string[] nameClazz = new string[6]
	{
		"Kiếm khách",
		"Chiến binh",
		"Pháp sư",
		"Đấu sĩ",
		"Cung thủ",
		string.Empty
	};

	public static Res gI()
	{
		return (me != null) ? me : (me = new Res());
	}

	public static bool isDestroy(int x1, int xw1, int x2, int xw2, int y1, int yh1, int y2, int yh2)
	{
		if (x1 > xw2 || xw1 < x2 || y1 > yh2 || yh1 < y2)
		{
			return false;
		}
		return true;
	}

	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	public static int random(int a)
	{
		return r.nextInt(a);
	}

	public static int random_Am_0(int a)
	{
		int num;
		for (num = 0; num == 0; num = r.nextInt() % a)
		{
		}
		return num;
	}

	public static string getDefaultChat(int type)
	{
		string result = string.Empty;
		try
		{
			result = NPC_DEFAULT_CHAT[type][GameScr.abs(rd.nextInt(NPC_DEFAULT_CHAT[type].Length))];
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public static void loadRes()
	{
		for (int i = 0; i < 5; i++)
		{
			Char.imgWeapone[i] = new WeaponInfo[15][];
			for (int j = 0; j < Char.imgWeapone[i].Length; j++)
			{
				Char.imgWeapone[i][j] = new WeaponInfo[7];
			}
		}
		for (int k = 0; k < 5; k++)
		{
			wpSplashInfos[k] = new WPSplashInfo[3];
		}
		FilePack.init(FilePack.main);
		imgNo = new FrameImage(FilePack.getImg("no"), 10, 10);
		imgKham = FilePack.getImg("kham");
		imgMSG = FilePack.getImg("msg0");
		imgWaitIcon = FilePack.getImg("wicon");
		imgBar = FilePack.getImg("bar");
		imgKc = FilePack.getImg("kc");
		PopupName.imgArrow = FrameImage.init("arF", 11, 9);
		imgFocusActor = Image.createImage(Main.res + "/fc");
		imgChatTouch = Image.createImage(Main.res + "/imgChat");
		imgSelectFc = Image.createImage(Main.res + "/selectfc");
		imgInv = new Image[3];
		for (int l = 0; l < 3; l++)
		{
			imgInv[l] = FilePack.getImg("inv" + l);
		}
		imgPanel = FilePack.getImg("panel150x36");
		wKhung = 30;
		imgKhung = FilePack.getImg("sk31");
		imgDie = FilePack.getImg("die");
		imgEye = FilePack.getImg("eye");
		imgPlus = FilePack.getImg("plus");
		imgShadow = FilePack.getImg("shadow");
		imgGrid = FilePack.getImg("grid");
		ChatPopup.getImg();
		imgSmoke = new FrameImage(FilePack.getImg("smoke"), 14, 15);
		FilePack.reset();
		FilePack.init(FilePack.eff);
		imgExplosion = FilePack.getImg("explosion");
		FilePack.reset();
		FilePack.init(FilePack.ground);
		imgGround[0] = FilePack.getImg("g0");
		imgGround[1] = FilePack.getImg("g1");
		imgGround[2] = FilePack.getImg("g2");
		FilePack.reset();
		FilePack.init(FilePack.ground);
		imgGround[0] = FilePack.getImg("g0");
		imgGround[1] = FilePack.getImg("g1");
		imgGround[2] = FilePack.getImg("g2");
		FilePack.reset();
		FilePack.init(FilePack.nation);
		imgNation = FilePack.getImg("icon");
		FilePack.reset();
		FilePack.init(Main.res + "/other");
		imgBgPopup = FilePack.getImg("bg_popup");
		wimgBgPopup = imgBgPopup.getWidth();
		imgBGTiemNang = FilePack.getImg("inv_1");
		imgBgTrangBi = FilePack.getImg("inv_0");
		imgPopupNgoc = FilePack.getImg("inv1");
		imgPopupGoc = FilePack.getImg("inv0");
		imgIconSkillKiem = FilePack.getImg("icon_sk_kiem");
		imgIconSkillDao = FilePack.getImg("icon_sk_dao");
		imgIconSkillPs = FilePack.getImg("icon_sk_ps");
		imgIconSkillBua = FilePack.getImg("icon_sk_bua");
		imgIconSkillCung = FilePack.getImg("icon_sk_cung");
		imgChat = FilePack.getImg("chat");
		imgMapMini = FilePack.getImg("map_mini");
		imgSwapQuickSlot = FilePack.getImg("swap");
		imgMSG = FilePack.getImg("msg0");
		FilePack.reset();
		FilePack.init(Main.res + "/items");
		MenuSelectItem.imgIChat = FilePack.getImg("chat");
		MenuSelectItem.imgIChange = FilePack.getImg("change");
		MenuSelectItem.imgINapxu = FilePack.getImg("napxu");
		MenuSelectItem.imgIDosat = FilePack.getImg("dosat");
		MenuSelectItem.imgIXuongngua = FilePack.getImg("xuongngua");
		MenuSelectItem.imgIDangxuat = FilePack.getImg("dangxuat");
		MenuSelectItem.imgIThoat = FilePack.getImg("exit");
		FilePack.reset();
		FilePack.init(FilePack.box);
		imgBox[0] = FilePack.getImg("b0");
		imgBox[1] = FilePack.getImg("b1");
		FilePack.reset();
		try
		{
			Boss_Dragon.loadDragon();
			Skill_Kiem_Down.load();
			if (imgShadowPet == null)
			{
				imgShadowPet = Image.createImage(Main.res + "/m/imgshadow");
			}
			imgSwapClothes = Image.createImage(Main.res + "/swapclothes");
			imgTG = Image.createImage(Main.res + "/tg");
			if (imgIce == null)
			{
				imgIce = Image.createImage(Main.res + "/skill_ice");
			}
			if (imgStone == null)
			{
				imgStone = Image.createImage(Main.res + "/skill_da");
			}
			if (imgButtonBar == null)
			{
				imgButtonBar = Image.createImage(Main.res + "/bar");
			}
			if (imgButtonBar1 == null)
			{
				imgButtonBar1 = Image.createImage(Main.res + "/bar1");
			}
			if (imgInv3 == null)
			{
				imgInv3 = Image.createImage(Main.res + "/inv3");
			}
			imgInfoWindow = new Image[2];
			imgInfoWindow[0] = Image.createImage(Main.res + "/inv_0");
			imgInfoWindow[1] = Image.createImage(Main.res + "/inv_1");
			imgInfoWindowt = Image.createImage(Main.res + "/inv_5");
			wTrangbi = imgInfoWindow[0].getWidth();
			imgCheck = Image.createImage(Main.res + "/check");
			imgCell[0] = Image.createImage(Main.res + "/c0");
			imgCell[1] = Image.createImage(Main.res + "/c1");
			imgCell[2] = Image.createImage(Main.res + "/c2");
			imgK0 = Image.createImage(Main.res + "/k0");
			imgNewBt[0] = Image.createImage(Main.res + "/b0");
			imgNewBt[1] = Image.createImage(Main.res + "/b1");
			imgNewBt[2] = Image.createImage(Main.res + "/b2");
			imgNewBt[4] = Image.createImage(Main.res + "/b4");
			GameScr.img12plus = Image.createImage(Main.res + "/plus12");
			GameScr.petShadow = Image.createImage(Main.res + "/shadow");
			QuickSlot.img = Image.createImage(Main.res + "/b3");
			icon_automode = Image.createImage(Main.res + "/icon_automode");
			GameScr.imghealth = new Image[2];
			GameScr.imghealth[0] = Image.createImage(Main.res + "/m1");
			GameScr.imghealth[1] = Image.createImage(Main.res + "/m2");
			try
			{
				imgEffNew = Image.createImage(Main.res + "/sword skill/h0");
			}
			catch (Exception)
			{
			}
			initQuanAoHt();
		}
		catch (Exception ex2)
		{
			Out.println(ex2.StackTrace);
		}
	}

	public static void setEffSh(sbyte[] arr)
	{
		effSh = arr;
		FilePack.initByArray(arr);
		imgExplosion = FilePack.getImg("explosion");
		FilePack.reset();
	}

	public static void loadPart2()
	{
		if (imgSelect == null)
		{
			FilePack.init(FilePack.main);
			imgSelect = FilePack.getImg("select");
			imgSelect1 = FilePack.getImg("select1");
			imgSelect2 = FilePack.getImg("select3");
			GameScr.imgCong = new Image[2];
			for (int i = 0; i < 2; i++)
			{
				GameScr.imgCong[i] = FilePack.getImg("cong" + (i + 1));
			}
			if (GameScr.imgHpMonster == null)
			{
				GameScr.imgHpMonster = FilePack.getImg("mauquai");
			}
			MagicBeam.imgFire = FilePack.getImg("fire");
			Char.imgFlgPk = FilePack.getImg("flg");
			Char.imgLight = FilePack.getImg("light");
			imgSoft = new Image[2];
			for (int j = 0; j < 2; j++)
			{
				imgSoft[j] = FilePack.getImg("soft" + j);
			}
			imgNguHanh = FilePack.getImg("nguhanh");
			if (imgLeg == null)
			{
				imgLeg = new Image[2];
			}
			for (int k = 0; k < 2; k++)
			{
				imgLeg[k] = FilePack.getImg("ch" + k);
			}
			FilePack.reset();
			FilePack.init(Main.res + "/other");
			if (GameScr.imgInfo == null)
			{
				GameScr.imgInfo = FilePack.getImg("info");
			}
			FilePack.reset();
		}
	}

	public static int random(int a, int b)
	{
		return a + r.nextInt(b - a);
	}

	public static GemTemp getGemByID(short id)
	{
		for (int i = 0; i < gemTemplate.size(); i++)
		{
			GemTemp gemTemp = (GemTemp)gemTemplate.elementAt(i);
			if (gemTemp != null && gemTemp.id == id)
			{
				return gemTemp;
			}
		}
		return null;
	}

	public static void initQuanAoHt()
	{
		quanao.addElement(new MyHashTable());
		quanao.addElement(new MyHashTable());
		quanao.addElement(new MyHashTable());
		quanao.addElement(new MyHashTable());
		quanao.addElement(new MyHashTable());
	}

	public static int[] getAttributeItem(int charClass, int idTemplate, int type)
	{
		int[] array = new int[10];
		ItemTemplate itemTemplate = ((ItemTemplate[])itemTemplates.elementAt(0))[idTemplate];
		array[0] = itemTemplate.attb[0];
		for (int i = 1; i < 4; i++)
		{
			array[i] = (short)(itemTemplate.attb[i] + ((!ItemInInventory.isAnimalArmor(type)) ? (itemTemplate.attb[i] * percent[charClass] / 100) : 0));
		}
		for (int j = 4; j < 10; j++)
		{
			array[j] = itemTemplate.attb[j];
		}
		return array;
	}

	public static ItemTemplate getItem(int clazz, int id)
	{
		ItemTemplate[] array = (ItemTemplate[])itemTemplates.elementAt(0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null && array[i].id == id)
			{
				return array[i];
			}
		}
		return null;
	}

	public static GemTemp getShopByID(short id)
	{
		for (int i = 0; i < shopTemplate.size(); i++)
		{
			GemTemp gemTemp = (GemTemp)shopTemplate.elementAt(i);
			if (gemTemp != null && gemTemp.id == id)
			{
				return gemTemp;
			}
		}
		return null;
	}

	public static XaphuTemplate getXaphu()
	{
		return (Tilemap.idXaphu < 0) ? null : XAPHU[Tilemap.idXaphu];
	}

	public static Image getImgeffect(int id)
	{
		return imgEffect[id];
	}

	public static void arraycopy(sbyte[] scr, int scrPos, ref sbyte[] dest, int destPos, int lenght)
	{
		if (scr != null && dest != null && destPos + lenght <= dest.Length)
		{
			for (int i = scrPos; i < lenght; i++)
			{
				dest[destPos + i - scrPos] = scr[i];
			}
		}
	}

	public static Image createImgByHeader(sbyte[] header, sbyte[] data)
	{
		sbyte[] dest = new sbyte[header.Length + data.Length];
		arraycopy(header, 0, ref dest, 0, header.Length);
		arraycopy(data, 0, ref dest, header.Length, data.Length);
		return Image.createImage(dest, 0, dest.Length);
	}

	public static void removeWeaPone()
	{
		for (int i = 0; i < Char.imgWeapone.Length; i++)
		{
			for (int j = 0; j < Char.imgWeapone[i].Length; j++)
			{
				for (int k = 0; k < Char.imgWeapone[i][j].Length; k++)
				{
					Char.imgWeapone[i][j][k] = null;
				}
			}
		}
		for (int l = 0; l < 5; l++)
		{
			for (int m = 0; m < 3; m++)
			{
				wpSplashInfos[l][m] = null;
			}
		}
	}

	public static WeaponInfo loadImgWeaPone(int i, int j, int index)
	{
		if (Char.imgWeapone[i][j][index] == null)
		{
			load.loadImgWeaPone(i, j, index);
		}
		return Char.imgWeapone[i][j][index];
	}

	public static WPSplashInfo loadWpsPlash(int i, int j)
	{
		if (wpSplashInfos[i][j] == null)
		{
			load.loadWpsPlash(i, j);
		}
		return wpSplashInfos[i][j];
	}

	public static Image getImgArrow(int i)
	{
		if (imgArrow[i] == null && load.indexArrow == -1)
		{
			load.indexArrow = i;
		}
		return imgArrow[i];
	}

	public static void loadImgArrow(int i)
	{
		FilePack.init(FilePack.arrow);
		try
		{
			switch (i)
			{
			case 7:
				imgArrow[i] = Image.createImage(Main.res + "/sword skill/kiem");
				break;
			case 8:
				imgArrow[i] = Image.createImage(Main.res + "/sword skill/skillboss");
				break;
			case 9:
				imgArrow[i] = Image.createImage(Main.res + "/sword skill/nut");
				break;
			case 10:
				imgArrow[10] = Image.createImage(Main.res + "/newEf/46");
				break;
			case 11:
				imgArrow[11] = Image.createImage(Main.res + "/newEf/47");
				break;
			case 12:
				imgArrow[12] = Image.createImage(Main.res + "/newEf/48");
				break;
			case 13:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/54");
				break;
			case 14:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/56");
				break;
			case 15:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/62");
				break;
			case 16:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/65");
				break;
			case 17:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/68");
				break;
			case 18:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/69");
				break;
			case 19:
				imgArrow[i] = Image.createImage(Main.res + "/newEf/70");
				break;
			default:
				imgArrow[i] = FilePack.getImg("arrow" + i);
				break;
			}
		}
		catch (Exception)
		{
		}
		FilePack.reset();
	}

	public static void paintImgEff(MyGraphics g, int type, int x0, int y0, int w, int h, int x, int y, int anthor)
	{
		if (type < imgEffect.Length && imgEffect[type] == null)
		{
			load.loadImgEffect(type);
		}
		else if (type < imgEffect.Length)
		{
			g.drawRegion(imgEffect[type], x0, y0, w, h, 0, x, y, anthor);
		}
	}

	public static Image loadImgEff(int index)
	{
		if (imgEffect[index] == null)
		{
			load.loadImgEffect(index);
		}
		return imgEffect[index];
	}

	public static void getImgEffect(int index)
	{
		FilePack.init(FilePack.eff);
		if (index < 25 || index > 33)
		{
			imgEffect[index] = FilePack.getImg("g" + index);
		}
		if (imgEffect[26] == null)
		{
			imgEffect[25] = FilePack.getImg("g25");
			imgEffect[26] = FilePack.getImg("g26");
			imgEffect[27] = Image.creatImageByImage(imgEffect[25]);
			imgEffect[28] = FilePack.getImg("g27");
			imgEffect[29] = FilePack.getImg("g28");
			imgEffect[30] = FilePack.getImg("g29");
			imgEffect[31] = FilePack.getImg("g30");
			imgEffect[32] = FilePack.getImg("g31");
			imgEffect[33] = FilePack.getImg("g32");
			imgEffect[41] = Image.createImage(Main.res + "/newEf/42");
			imgEffect[42] = Image.createImage(Main.res + "/newEf/43");
			imgEffect[43] = Image.createImage(Main.res + "/newEf/44");
			imgEffect[44] = Image.createImage(Main.res + "/newEf/45");
			imgEffect[45] = Image.createImage(Main.res + "/newEf/49");
			imgEffect[46] = Image.createImage(Main.res + "/newEf/50");
			imgEffect[47] = Image.createImage(Main.res + "/newEf/51");
			imgEffect[48] = Image.createImage(Main.res + "/newEf/52");
			imgEffect[49] = Image.createImage(Main.res + "/newEf/53");
			imgEffect[50] = Image.createImage(Main.res + "/newEf/55");
			imgEffect[51] = Image.createImage(Main.res + "/newEf/57");
			imgEffect[52] = Image.createImage(Main.res + "/newEf/58");
			imgEffect[53] = Image.createImage(Main.res + "/newEf/59");
			imgEffect[54] = Image.createImage(Main.res + "/newEf/60");
			imgEffect[55] = Image.createImage(Main.res + "/newEf/61");
			backSmoke = new FrameImage(imgEffect[32], 12, 13);
		}
		if (imgEffect[41] == null)
		{
			imgEffect[41] = Image.createImage(Main.res + "/newEf/42");
			imgEffect[42] = Image.createImage(Main.res + "/newEf/43");
			imgEffect[43] = Image.createImage(Main.res + "/newEf/44");
			imgEffect[44] = Image.createImage(Main.res + "/newEf/45");
			imgEffect[45] = Image.createImage(Main.res + "/newEf/49");
			imgEffect[46] = Image.createImage(Main.res + "/newEf/50");
			imgEffect[47] = Image.createImage(Main.res + "/newEf/51");
			imgEffect[48] = Image.createImage(Main.res + "/newEf/52");
			imgEffect[49] = Image.createImage(Main.res + "/newEf/53");
			imgEffect[50] = Image.createImage(Main.res + "/newEf/55");
			imgEffect[51] = Image.createImage(Main.res + "/newEf/57");
			imgEffect[52] = Image.createImage(Main.res + "/newEf/58");
			imgEffect[53] = Image.createImage(Main.res + "/newEf/59");
			imgEffect[54] = Image.createImage(Main.res + "/newEf/60");
			imgEffect[55] = Image.createImage(Main.res + "/newEf/61");
			imgEffect[56] = Image.createImage(Main.res + "/newEf/63");
			if (imgArrow[15] != null)
			{
				imgEffect[57] = imgArrow[15];
			}
			else
			{
				imgEffect[57] = Image.createImage(Main.res + "/newEf/62");
			}
			imgEffect[58] = Image.createImage(Main.res + "/newEf/64");
			imgEffect[59] = Image.createImage(Main.res + "/newEf/66");
			imgEffect[60] = Image.createImage(Main.res + "/newEf/67");
			imgEffect[61] = Image.createImage(Main.res + "/newEf/71");
			imgEffect[62] = Image.createImage(Main.res + "/newEf/72");
			backSmoke = new FrameImage(imgEffect[32], 12, 13);
		}
		FilePack.reset();
	}

	public static void getImgWeaPone(int i, int j, int index)
	{
		string[] array = new string[5]
		{
			"kiem",
			"daidao",
			"phapsu",
			"bua",
			"cung"
		};
		FilePack.init(FilePack.wps + array[i] + "/" + j);
		Char.imgWeapone[i][j][index] = new WeaponInfo();
		try
		{
			if (j >= 5)
			{
				if (index < 5)
				{
					sbyte[] header = FilePack.instance.loadFile(index + "_h");
					sbyte[] data = FilePack.instance.loadFile("data");
					Char.imgWeapone[i][j][index].img = createImgByHeader(header, data);
				}
			}
			else
			{
				sbyte[] header2 = FilePack.instance.loadFile(index + "_h");
				sbyte[] data2 = FilePack.instance.loadFile("data");
				Char.imgWeapone[i][j][index].img = createImgByHeader(header2, data2);
			}
		}
		catch (Exception ex)
		{
			Out.LogError(" loi tai getimgweapone " + ex.StackTrace);
		}
		FilePack.reset();
	}

	public static WPSplashInfo GetWPSplashInfo(int i, int j)
	{
		try
		{
			wpSplashInfos[i][j] = new WPSplashInfo();
			int num = j;
			if (i == 3 || i == 4 || (i == 2 && num == 1))
			{
				num = 0;
			}
			else if ((i == 0 || i == 1) && num == 2)
			{
				num = 1;
			}
			FilePack filePack = new FilePack(FilePack.wps + i, null);
			wpSplashInfos[i][j].image = filePack.loadImage(string.Empty + num + ".png");
			DataInputStream dataInputStream = new DataInputStream(filePack.loadData(num + ".d"));
			if (dataInputStream != null)
			{
				for (int k = 0; k < 4; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						wpSplashInfos[i][j].P0_X[k][l] = dataInputStream.read();
						wpSplashInfos[i][j].P0_Y[k][l] = dataInputStream.read();
						wpSplashInfos[i][j].PF_X[k][l] = readSignByte(dataInputStream);
						wpSplashInfos[i][j].PF_Y[k][l] = readSignByte(dataInputStream);
						wpSplashInfos[i][j].PF_W[k][l] = dataInputStream.read();
						wpSplashInfos[i][j].PF_H[k][l] = dataInputStream.read();
					}
				}
			}
			FilePack.reset();
		}
		catch (IOException)
		{
			wpSplashInfos[i][j] = null;
		}
		return wpSplashInfos[i][j];
	}

	public static void removeImgEffect()
	{
		for (int i = 0; i < 25; i++)
		{
			if (i != 8)
			{
				imgEffect[i] = null;
			}
		}
		imgWayPoint = null;
		GC.Collect();
	}

	public static void loadMonster(int type, sbyte[] info)
	{
		monsterTemplates[type].setInfo(type, string.Empty, "m" + type, info[0], info[1], info[2], info[3], info[4], info[5], info[6], info[7], info[8]);
	}

	public static void resetImgMonsTemp()
	{
		if (monsterTemplates == null)
		{
			return;
		}
		for (int i = 0; i < monsterTemplates.Length; i++)
		{
			if (monsterTemplates[i] != null)
			{
				monsterTemplates[i].image = null;
				monsterTemplates[i].imageObj = null;
			}
		}
	}

	public static void removeMonsterTemplet()
	{
		resetImgMonsTemp();
		treeInfos.clear();
	}

	public static void loadMonster()
	{
	}

	public static CharPartInfo getCharPartInfo(int type, int id)
	{
		CharPartInfo charPartInfo = null;
		MyHashTable myHashTable = (MyHashTable)quanao.elementAt(type);
		charPartInfo = (CharPartInfo)myHashTable.get(id + string.Empty);
		if (charPartInfo == null)
		{
			charPartInfo = new CharPartInfo(type, id);
			charPartInfo.time = (int)(mSystem.currentTimeMillis() / 1000);
			if (charPartInfo.image == null)
			{
				GameService.gI().getTreeImage(-1, type, id);
			}
			myHashTable.put(id + string.Empty, charPartInfo);
		}
		if (charPartInfo.image == null && mSystem.currentTimeMillis() / 1000 - charPartInfo.time == 15)
		{
			GameService.gI().getTreeImage(-1, type, id);
			charPartInfo.time = (int)(mSystem.currentTimeMillis() / 1000);
		}
		charPartInfo.timeRemove = (int)(mSystem.getCurrentTimeMillis() / 1000);
		return charPartInfo;
	}

	public static void paintDefault(MyGraphics g, int xp, int yp, int dir, int frame, int type)
	{
		if (type == 1 && defaultBody != null)
		{
			defaultBody.paint(g, xp, type, dir, frame);
		}
		if (type == 0 && defaultLeg != null)
		{
			defaultLeg.paint(g, xp, type, dir, frame);
		}
		if (type == 2 && defaultHead != null)
		{
			defaultHead.paint(g, xp, type, dir, frame);
		}
	}

	public static void resetTrangBi()
	{
		if (defaultBody == null)
		{
			defaultBody = getCharPartInfo(1, 54);
		}
		if (defaultLeg == null)
		{
			defaultLeg = getCharPartInfo(0, 54);
		}
		if (defaultHead == null)
		{
			defaultHead = getCharPartInfo(2, 27);
		}
	}

	public static TreeInfo getTree(int index)
	{
		TreeInfo treeInfo = (TreeInfo)treeInfos.get(string.Empty + index);
		if (treeInfo == null)
		{
			treeInfo = new TreeInfo();
			treeInfo.id = (short)index;
			treeInfos.put(string.Empty + index, treeInfo);
		}
		return treeInfo;
	}

	public static int getHeightTree(int index)
	{
		return getTree(index)?.getHeight() ?? 0;
	}

	public static int getwidthTree(int index)
	{
		return getTree(index)?.getWidth() ?? 0;
	}

	public static int getDxTree(int index)
	{
		return getTree(index)?.dx ?? 0;
	}

	public static int getDyTree(int index)
	{
		return getTree(index)?.dy ?? 0;
	}

	public static void loadTreeImage()
	{
	}

	public static void removeTreeImage(int i)
	{
	}

	public static int readSignByte(DataInputStream iss)
	{
		sbyte[] array = new sbyte[1];
		try
		{
			int num = array.Length;
			if (num > 1)
			{
				num = 1;
			}
			for (int i = 0; i < 1; i++)
			{
				array[i] = iss.readByte();
			}
		}
		catch (IOException ex)
		{
			Out.println(ex.StackTrace + " loi readSingsbytes");
		}
		return array[0];
	}

	public static void loadImgMap()
	{
		Image image = null;
		Image image2 = null;
		Image image3 = null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (image == null)
		{
			image = Image.createImage(Main.res + "/pngtile/t_thanh");
		}
		if (image2 == null)
		{
			image2 = Image.createImage(Main.res + "/pngtile/t");
		}
		if (image3 == null)
		{
			image3 = Image.createImage(Main.res + "/pngtile/t_hang");
		}
		num = image.getHeight() / 16;
		num2 = image2.getHeight() / 16;
		num3 = image3.getHeight() / 16;
		Tilemap.img[0] = new Image[num];
		Tilemap.img[1] = new Image[num2];
		Tilemap.img[2] = new Image[num3];
		for (int i = 0; i < num; i++)
		{
			Tilemap.img[0][i] = Image.createImage(image, 0, i * 16, 16, 16, 0);
		}
		for (int j = 0; j < num2; j++)
		{
			Tilemap.img[1][j] = Image.createImage(image2, 0, j * 16, 16, 16, 0);
		}
		for (int k = 0; k < num3; k++)
		{
			Tilemap.img[2][k] = Image.createImage(image3, 0, k * 16, 16, 16, 0);
		}
		image.texture = null;
		image = null;
		image2.texture = null;
		image2 = null;
		image3.texture = null;
		image3 = null;
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	public static void loadTileImage(int lv)
	{
		Tilemap.typeTile = 0;
		try
		{
			DataInputStream dataInputStream = null;
			if (lv > 200)
			{
				Tilemap.typeTile = 0;
				dataInputStream = DataInputStream.getResourceAsStream(Main.res + "/t_thanh");
				mauTile = 0;
				imgtileSmall = Image.createImage(Main.res + "/pngtile/t_thanh_s");
			}
			else if (lv < 110)
			{
				Tilemap.typeTile = 1;
				dataInputStream = DataInputStream.getResourceAsStream(Main.res + "/t");
				imgtileSmall = Image.createImage(Main.res + "/pngtile/t_small");
				mauTile = 1;
			}
			else
			{
				Tilemap.typeTile = 2;
				dataInputStream = DataInputStream.getResourceAsStream(Main.res + "/t_hang");
				imgtileSmall = Image.createImage(Main.res + "/pngtile/t_hang_s");
				mauTile = 2;
			}
			try
			{
				Tilemap.typeOfTile = null;
				Tilemap.typeOfTile = new int[dataInputStream.available()];
				for (int i = 0; i < Tilemap.typeOfTile.Length; i++)
				{
					Tilemap.typeOfTile[i] = dataInputStream.readUnsignedByte();
				}
			}
			catch (Exception)
			{
				Out.LogWarning("Error Load Back Tile");
			}
		}
		catch (Exception ex2)
		{
			Out.LogError(ex2.StackTrace + "  load tile loi");
		}
	}

	public static void paintDlgFull(MyGraphics g, int x, int y)
	{
		x -= 10;
		int num = y + 14;
		g.drawImage(imgInv[2], x + 15, num, 20);
		g.drawImage(imgInv[2], x + 85, num, 20);
		g.drawImage(imgInv[2], x + 15, num + 46, 20);
		g.drawImage(imgInv[2], x + 85, num + 46, 20);
		g.drawImage(imgInv[2], x + 15, num + 92, 20);
		g.drawImage(imgInv[2], x + 85, num + 92, 20);
		int num2 = x + 12;
		int num3 = y + 11;
		int num4 = 144;
		int num5 = 144;
		for (int i = 0; i < 3; i++)
		{
			g.setColor(color[i]);
			g.drawRect(num2 + i, num3 + i, num4 - i * 2, num5 - i * 2);
		}
		g.drawImage(imgInv[0], x + 10, y + 9, 20);
		g.drawRegion(imgInv[0], 0, 0, 18, 19, 2, x + 159, y + 9, 24);
		g.drawRegion(imgInv3, 0, 0, 18, 19, 2, x + 10, y + 158, 36);
		g.drawImage(imgInv3, x + 159, y + 158, 40);
	}

	public static void paintSelected(MyGraphics g, int x, int y, int w, int h)
	{
		g.setColor(34949);
		g.fillRect(x, y, w, h);
		g.setColor(11908790);
		g.drawRect(x, y, w, h);
	}

	public static void paintDlgDragonFull(MyGraphics g, int x, int y, int w, int h)
	{
		int num = w / 70 + 1;
		int num2 = h / 47 + 1;
		g.setClip(x, y, w, h);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				g.drawImage(imgInv[2], x + i * 70, y + j * 47, 0);
			}
		}
		g.setClip(0, 0, Canvas.w, Canvas.h);
		for (int k = 0; k < 3; k++)
		{
			g.setColor(color[k]);
			g.drawRect(x + k, y + k, w - k * 2, h - k * 2);
		}
		g.drawImage(imgInv[0], x - 2, y - 2, 0);
		g.drawRegion(imgInv[0], 0, 0, 18, 19, 2, x + w - 15, y - 2, 0);
		g.drawRegion(imgInv3, 0, 0, 18, 19, 2, x - 2, y + h - 15, 0);
		g.drawImage(imgInv3, x + w - 15, y + h - 16, 0);
		g.drawImage(imgInv[1], x + w / 2, y - 4, 3);
	}

	public static void paintRectColor(MyGraphics g, int x, int y, int w, int h, int count, int color1, int color2)
	{
		g.setColor(color1);
		g.drawRect(x, y, w, h);
		g.setColor(color2);
		if (count < w)
		{
			int num = wh;
			if (num + count >= w)
			{
				num = w - count;
			}
			g.fillRect(x + count, y, num, 1);
		}
		else if (count < w + h)
		{
			int num2 = wh;
			if (num2 + (count - w) >= h)
			{
				num2 = h - (count - w);
			}
			g.fillRect(x + w, y + (count - w), 1, num2);
		}
		else if (count < w * 2 + h)
		{
			int num3 = wh;
			if (num3 + (count - w - h) >= w)
			{
				num3 = w - (count - w - h);
			}
			g.fillRect(x + (w - (count - w - h)) - num3, y + h, num3, 1);
		}
		else if (count < w * h * 2)
		{
			int num4 = wh;
			if (num4 + (count - w * 2 - h) >= h)
			{
				num4 = h - (count - w * 2 - h);
			}
			g.fillRect(x, y + (h - (count - w * 2 - h)) - num4, 1, num4);
		}
		Res.num++;
		if (Res.num >= 4)
		{
			Res.num = 0;
		}
	}

	public static void paintDlgFull(MyGraphics g, int x, int y, int w, int h)
	{
		int num = w / 70 + 1;
		g.setClip(x, y, w, h);
		for (int i = 0; i < num; i++)
		{
			g.drawImage(imgInv[2], x + 70 * i, y, 0);
		}
		g.setColor(277044);
		g.fillRect(x, y + 25, w, h);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		for (int j = 0; j < 3; j++)
		{
			g.setColor(color[j]);
			g.drawRect(x + j, y + j, w - j * 2 - 1, h - j * 2 - 1);
			g.fillRect(x + 3, y + 25, w - 6, 1);
		}
		g.drawImage(imgInv[0], x - 2, y - 2, 0);
		g.drawRegion(imgInv[0], 0, 0, 18, 19, 2, x + w + 2, y - 2, MyGraphics.TOP | MyGraphics.RIGHT);
		g.drawRegion(imgInv3, 0, 0, 18, 19, 2, x - 2, y + h + 2, MyGraphics.BOTTOM | MyGraphics.LEFT);
		g.drawImage(imgInv3, x + w + 2, y + h + 2, MyGraphics.BOTTOM | MyGraphics.RIGHT);
	}

	public static void paintDlgFull(MyGraphics g, int x, int y, int w, int h, int y1, string tile, bool isDD, int h0)
	{
		int num = w / 70 + 1;
		g.setClip(x, y, w, h);
		for (int i = 0; i < num; i++)
		{
			g.drawImage(imgInv[2], x + 70 * i, y, 0);
		}
		g.setColor(277044);
		g.fillRect(x, y + 25, w, h);
		g.setClip(0, 0, Canvas.w, Canvas.h);
		for (int j = 0; j < 3; j++)
		{
			g.setColor(color[j]);
			g.drawRect(x + j, y + j, w - j * 2 - 1, h - j * 2 - 1);
		}
		g.fillRect(x + 3, y + 25, w - 6, 1);
		if (!isDD)
		{
			g.fillRect(x + 3, y + 25 + y1 + h0, w - 6, 1);
		}
		else
		{
			g.fillRect(x + 3, y + 25 + y1 + h0, w - 6, 1);
			g.fillRect(x + 3, y + y1 + h0 - 2, w - 6, 1);
		}
		MFont.normalFont[0].drawString(g, tile, x + w / 2, y + 8, 2);
		g.drawImage(imgInv[0], x - 2, y - 2, 0);
		g.drawRegion(imgInv[0], 0, 0, 18, 19, 2, x + w + 2, y - 2, MyGraphics.TOP | MyGraphics.RIGHT);
		g.drawRegion(imgInv[0], 0, 0, 18, 19, 6, x - 2, y + h + 2, MyGraphics.BOTTOM | MyGraphics.LEFT);
		g.drawRegion(imgInv[0], 0, 0, 18, 19, 3, x + w + 2, y + h + 2, MyGraphics.BOTTOM | MyGraphics.RIGHT);
	}

	public static void drawRect(MyGraphics g, int x, int y, int w, int h)
	{
		for (int i = 0; i < 3; i++)
		{
			g.setColor(color[i]);
			g.drawRect(x + i, y + i, w - i * 2, h - i * 2);
		}
	}

	public static int[] trimArray(int[] array)
	{
		int[] array2 = null;
		mVector mVector = new mVector();
		for (int i = 0; i < array.Length; i++)
		{
			if (mVector.size() == 0)
			{
				mVector.addElement(array[i] + string.Empty);
				continue;
			}
			bool flag = false;
			for (int j = 0; j < mVector.size(); j++)
			{
				int num = int.Parse((string)mVector.elementAt(j));
				if (num == array[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				mVector.addElement(array[i] + string.Empty);
			}
		}
		array2 = new int[mVector.size()];
		for (int k = 0; k < mVector.size(); k++)
		{
			array2[k] = int.Parse((string)mVector.elementAt(k));
		}
		return array2;
	}

	public static void paintPotion(MyGraphics g, int index, int x, int y, int anthor)
	{
		GameData.paintIcon(g, (short)(index + 5500), x, y, anthor);
	}

	public static void paintGem(MyGraphics g, int index, int x, int y)
	{
		GameData.paintIcon(g, (short)(index + 6500), x, y, 3);
	}

	public static void paintGemKhoa(MyGraphics g, int index, int x, int y)
	{
		GameData.paintIcon(g, (short)(index + 6500), x, y, 3);
	}

	public static Image createImgByByteArray(sbyte[] array)
	{
		return Image.createImage(array, 0, array.Length);
	}

	public static int rnd(int a)
	{
		return r.nextInt(a);
	}

	public static int rnd(int a, int b)
	{
		if (r.nextInt(2) == 0)
		{
			return a;
		}
		return b;
	}

	public static string[] getNameMap(int index, int id)
	{
		try
		{
			return nameMap[index][id];
			IL_000f:;
		}
		catch (Exception ex)
		{
			Out.LogError(" loi getNameMap nay Res" + ex.StackTrace);
		}
		return null;
	}

	public static short[] getLocation(int index, int id)
	{
		try
		{
			return locationMap[index][id];
			IL_000f:;
		}
		catch (Exception ex)
		{
			Out.LogError(" loi getLocation nay Res" + ex.StackTrace);
		}
		return null;
	}

	public static Image getWayPoint()
	{
		if (imgWayPoint == null)
		{
			FilePack.init(FilePack.main);
			imgWayPoint = FilePack.getImg("waypoint");
			FilePack.reset();
		}
		return imgWayPoint;
	}

	public static Image transparentBG(Image img)
	{
		return null;
	}

	public static sbyte[] intTosbyteArray(int value)
	{
		sbyte[] array = new sbyte[4];
		for (int i = 0; i < 4; i++)
		{
			int num = (array.Length - 1 - i) * 8;
			array[i] = (sbyte)((value >> num) & 0xFF);
		}
		return array;
	}

	public static int getDistance(int x, int y, int x2, int y2)
	{
		return getDistance(x - x2, y - y2);
	}

	public static int sqrt(int a)
	{
		if (a <= 0)
		{
			return 0;
		}
		int num = (a + 1) / 2;
		int num2;
		do
		{
			num2 = num;
			num = num / 2 + a / (2 * num);
		}
		while (Math.abs(num2 - num) > 1);
		return num;
	}

	public static int getDistance(int x, int y)
	{
		return sqrt(x * x + y * y);
	}

	public static int sbyteToInit(sbyte[] bArr)
	{
		return ((0xFF & bArr[0]) << 24) | ((0xFF & bArr[1]) << 16) | ((0xFF & bArr[2]) << 8) | (0xFF & bArr[3]);
	}

	public static void removePartInfo()
	{
	}

	public static int getRange(int x1, int x2, int y1, int y2)
	{
		return Math.abs(x1 - x2) + Math.abs(y1 - y2);
	}
}
