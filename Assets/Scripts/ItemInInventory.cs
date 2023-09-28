using System;

public class ItemInInventory
{
	private static string[][] groupKick = new string[13][]
	{
		new string[2]
		{
			"Quần",
			"Nhẫn dưới"
		},
		new string[2]
		{
			"Ngọc",
			"Găng"
		},
		new string[2]
		{
			"áo",
			"Dây chuyền"
		},
		new string[2]
		{
			"áo",
			"Dây chuyền"
		},
		new string[2]
		{
			"áo",
			"Dây chuyền"
		},
		new string[2]
		{
			"áo",
			"Dây chuyền"
		},
		new string[2]
		{
			"áo",
			"Dây chuyền"
		},
		new string[2]
		{
			"áo",
			"Dây chuyền"
		},
		new string[4]
		{
			"Nón",
			"Vũ khí",
			"Ngọc bội",
			"Găng"
		},
		new string[2]
		{
			"Nhẫn dưới",
			"Quần"
		},
		new string[2]
		{
			"Nón",
			"Vũ khí"
		},
		new string[2]
		{
			"Giày",
			"Nhẫn trên"
		},
		new string[2]
		{
			"Giày",
			"Nhẫn trên"
		}
	};

	private static string[][] kickHe = new string[5][]
	{
		new string[1]
		{
			"Kim"
		},
		new string[1]
		{
			"Thủy"
		},
		new string[1]
		{
			"Mộc"
		},
		new string[1]
		{
			"Hỏa"
		},
		new string[1]
		{
			"Thổ"
		}
	};

	private static string[][] groupKickAnimal = new string[5][]
	{
		new string[1]
		{
			"Nón"
		},
		new string[1]
		{
			"Bàn đạp"
		},
		new string[1]
		{
			"Hộ uyển"
		},
		new string[1]
		{
			"Yên cương"
		},
		new string[1]
		{
			"Giáp"
		}
	};

	public sbyte[] newAtb = new sbyte[10];

	public sbyte[] addMoreLevelSkill = new sbyte[15];

	public sbyte[] lockAtb = new sbyte[3];

	public string nameCharSeal = string.Empty;

	public string nameCharSell;

	public string nameCharBet;

	public sbyte catagory = 3;

	public sbyte isItemDrop;

	public short itemID;

	public short number;

	public short itemOldID;

	public sbyte potionType;

	public sbyte charClazz;

	public sbyte heItem = -1;

	public sbyte beKicked;

	public sbyte hangItem = -1;

	public sbyte magic_physic = 2;

	public short idTemplate;

	public short plusTemplate;

	public short[] itemAttribute = new short[10];

	public short durable;

	public short mDurable;

	public int dayUse;

	public long lastTime;

	public short level = -1;

	public bool isSelling;

	public bool isShopItem;

	public int prize;

	public int islock;

	public sbyte clazz = -1;

	public sbyte maxNgoc;

	public static readonly string[] attrName = new string[10]
	{
		"Tấn công",
		"Thủ vật",
		"Né tránh",
		"Chính xác",
		"Chí mạng",
		"Sức khoẻ",
		"Thủ ma",
		"Chỉ số 7",
		"Chỉ số 8",
		"Chỉ số 9"
	};

	public short[] attCreate;

	public bool isEnoughData;

	public bool isTrade;

	public short[] property;

	public mVector allAttribute = new mVector();

	public sbyte numKham;

	public sbyte totalKham;

	public sbyte colorName;

	public sbyte viTriVe;

	public static bool[][] attribShowedForType = new bool[20][]
	{
		new bool[10]
		{
			false,
			true,
			true,
			true,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			true,
			true,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			true,
			true,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			false,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			false,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			true,
			false,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			false,
			true,
			true,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			false,
			false,
			true,
			true,
			true,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			true,
			false,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			true,
			false,
			false,
			false,
			true,
			false,
			false,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
			false
		},
		new bool[10]
		{
			false,
			true,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
			false
		}
	};

	public short[] otherAtt;

	private static string[] na = new string[6]
	{
		"Giáp nhẹ",
		"Giáp nặng",
		"Giáp vải",
		"Giáp nặng",
		"Giáp nhẹ",
		string.Empty
	};

	private static string[] nameNguHanh = new string[7]
	{
		"Giảm st vật: ",
		"Giảm st ma: ",
		"Tăng tc: ",
		"Bỏ qua pt: ",
		"Phản st: ",
		"Bỏ qua tc ma",
		"Bỏ qua tc vật"
	};

	private static string[] nameHangItem = new string[6]
	{
		string.Empty,
		"nhất phẩm",
		"nhị phẩm",
		"tam phẩm",
		"tứ phẩm",
		"ngũ phẩm"
	};

	private static string[] he = new string[5]
	{
		"hệ thuỷ",
		"hệ mộc",
		"hệ hoả",
		"hệ thổ",
		"hệ kim"
	};

	private static string[] magic = new string[3]
	{
		"ma pháp",
		"vật lý",
		string.Empty
	};

	public static sbyte typeItemBuy = 2;

	private int count = Res.rnd(68);

	public int prizeFix;

	public int prizeBet;

	public long timeEnd;

	public string daySell = string.Empty;

	private static int[] color = new int[3]
	{
		7667443,
		3334656,
		16705024
	};

	public sbyte kindItemInventory;

	public short[] getPoint()
	{
		return null;
	}

	public static bool isItemChar(int type)
	{
		return type < 13;
	}

	public static bool isModelClothe(int id)
	{
		return id == 1;
	}

	public static bool isArmor(int type)
	{
		return type < 3;
	}

	public bool isMyItem()
	{
		return nameCharSell.Equals(Canvas.gameScr.mainChar.name);
	}

	public ItemTemplate getTemplate()
	{
		return Res.getItem(charClazz, idTemplate);
	}

	public string[] getName()
	{
		string[] array = new string[3]
		{
			string.Empty,
			string.Empty,
			string.Empty
		};
		if (catagory == 3)
		{
			ItemTemplate item = Res.getItem(charClazz, idTemplate);
			string text = string.Empty;
			if (plusTemplate > 0)
			{
				text = text + " +" + plusTemplate;
			}
			text = text + " " + magic[magic_physic];
			array[0] = colorName + item.name + ((plusTemplate <= 0) ? string.Empty : (" +" + plusTemplate));
			array[1] = "Giá bán: " + prize + " xu";
			array[2] = "Giá bid: " + prizeBet + " xu";
		}
		return array;
	}

	public static mVector getAllItemCharDrop()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (isItemChar(item.type) && itemInInventory.dayUse == 0 && (itemInInventory.isItemDrop == 1 || itemInInventory.colorName != 0))
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public string compareItem(ItemInInventory it)
	{
		string text = string.Empty;
		if (catagory == 3)
		{
			string text2 = string.Empty;
			ItemTemplate item = Res.getItem(charClazz, idTemplate);
			if (!isModelClothe(item.attb[9]))
			{
				if (plusTemplate > 0)
				{
					text2 = text2 + " +" + plusTemplate;
				}
				text2 = text2 + " " + magic[magic_physic];
				if (hangItem > -1)
				{
					text2 = text2 + " " + nameHangItem[hangItem];
				}
				if (heItem > -1)
				{
					text2 = text2 + " " + he[heItem];
				}
				text += setTemp(item.name + text2, string.Empty + colorName);
				if (!nameCharSeal.Equals(string.Empty))
				{
					text = text + "\n0" + nameCharSeal.ToUpper() + " tạo";
				}
				if (islock == 1)
				{
					text += "\nĐã khoá";
				}
				if (isArmor(item.type) && item.type != 13 && !isAnimalArmor(item.type))
				{
					text = text + "\n" + na[clazz];
				}
				if (clazz != -1 && item.type != 13 && item.type != 19 && !isAnimalArmor(item.type))
				{
					text = text + "\n" + Res.nameClazz[clazz];
				}
				if (item.level != -1)
				{
					text = text + "\nYêu cầu lv: " + level;
				}
				text = text + "\nĐộ bền: " + durable;
				for (byte b = 0; b < allAttribute.size(); b = (byte)(b + 1))
				{
					InfoAttributeItem infoAttributeItem = (InfoAttributeItem)allAttribute.elementAt(b);
					string temp = infoAttributeItem.getName(clazz) + infoAttributeItem.getValue() + ((!infoAttributeItem.isPercent()) ? string.Empty : "%");
					text += setTemp(temp, infoAttributeItem.getColorPaint(beKicked == 1) + string.Empty);
					for (int i = 0; i < it.allAttribute.size(); i++)
					{
						InfoAttributeItem infoAttributeItem2 = (InfoAttributeItem)allAttribute.elementAt(b);
						if (infoAttributeItem2.getID() == infoAttributeItem.getID())
						{
							if (infoAttributeItem2.getValueAtt() > infoAttributeItem.getValueAtt())
							{
								text = text + "~1" + (infoAttributeItem2.getValueAtt() - infoAttributeItem.getValueAtt());
							}
							else if (infoAttributeItem2.getValueAtt() > infoAttributeItem.getValueAtt())
							{
								text = text + "~0" + (infoAttributeItem.getValueAtt() - infoAttributeItem2.getValueAtt());
							}
						}
					}
				}
				try
				{
					if (hangItem > 0 && hangItem < 5 && item.type != 13 && item.type < 13)
					{
						text = ((item.type != 8) ? (text + setTemp("cần " + groupKick[item.type][0] + " hoặc " + groupKick[item.type][1] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0")) : ((viTriVe != 1) ? (text + setTemp("Nhẫn dưới cần " + groupKick[item.type][2] + " hoặc " + groupKick[item.type][3] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0")) : (text + setTemp("Nhẫn trên cần " + groupKick[item.type][0] + " hoặc " + groupKick[item.type][1] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0"))));
					}
					if (hangItem > 0 && hangItem < 5 && isAnimalArmor(item.type))
					{
						text += setTemp("cần " + groupKickAnimal[item.type - 14][0] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0");
					}
				}
				catch (Exception)
				{
				}
			}
			else
			{
				text += item.name;
				string text3 = text;
				text = text3 + "\nTấn công tăng: " + item.attb[0] + "%";
				text3 = text;
				text = text3 + "\nThủ tăng: " + item.attb[1] + "%";
				text = text + "\nHP tăng: " + item.attb[2];
				text = text + "\nMP tăng: " + item.attb[3];
			}
			if (dayUse != 0)
			{
				long num = dayUse - (mSystem.currentTimeMillis() - lastTime) / 60000;
				if (num < 0)
				{
					num = 1L;
				}
				text += setTemp("\nThời gian còn lại: " + ((num / 60 <= 0) ? string.Empty : (num / 60 + "h ")) + ((num % 60 <= 0) ? string.Empty : (num % 60 + "p")), 0 + string.Empty);
			}
			if (timeEnd > 0)
			{
				text += setTemp(nameCharSell, "0");
				text += setTemp(daySell, "0");
				text += setTemp("Bid: " + prizeBet + " xu", "0");
				text += setTemp((!nameCharBet.Equals(string.Empty)) ? (nameCharBet + " bid") : "----", "0");
				text += setTemp(getTimeSell(), 0 + string.Empty);
			}
		}
		return text;
	}

	public string getDescription(bool showResellPrice)
	{
		string text = string.Empty;
		if (catagory == 3)
		{
			string text2 = string.Empty;
			ItemTemplate item = Res.getItem(charClazz, idTemplate);
			if (!isModelClothe(item.attb[9]))
			{
				if (plusTemplate > 0)
				{
					text2 = text2 + " +" + plusTemplate;
				}
				text2 = text2 + " " + magic[magic_physic];
				if (hangItem > -1)
				{
					text2 = text2 + " " + nameHangItem[hangItem];
				}
				if (heItem > -1)
				{
					text2 = text2 + " " + he[heItem];
				}
				text += setTemp(item.name + text2, string.Empty + colorName);
				if (!nameCharSeal.Equals(string.Empty))
				{
					text = text + "\n0" + nameCharSeal.ToLower() + ((nameCharSeal.IndexOf("-") <= -1) ? " tạo" : string.Empty);
				}
				if (islock == 1)
				{
					text += "\nĐã khoá";
				}
				if (isArmor(item.type) && item.type != 13 && !isAnimalArmor(item.type))
				{
					text = text + "\n" + na[clazz];
				}
				if (clazz != -1 && item.type != 13 && item.type != 19 && !isAnimalArmor(item.type))
				{
					text = text + "\n" + Res.nameClazz[clazz];
				}
				if (isSelling)
				{
					text = text + "\nGiá bán: " + Canvas.getMoneys(prize) + "~";
				}
				else if (showResellPrice)
				{
					text = text + "\nGiá bán lại: " + Canvas.getMoneys(item.price / 5 + plusTemplate * 1000) + "~";
				}
				if (item.level != -1)
				{
					text = text + "\nYêu cầu lv: " + level;
				}
				text = text + "\nĐộ bền: " + durable;
				for (sbyte b = 0; b < allAttribute.size(); b = (sbyte)(b + 1))
				{
					InfoAttributeItem infoAttributeItem = (InfoAttributeItem)allAttribute.elementAt(b);
					string temp = infoAttributeItem.getName(clazz) + infoAttributeItem.getValue() + ((!infoAttributeItem.isPercent()) ? string.Empty : "%");
					text += setTemp(temp, infoAttributeItem.getColorPaint(beKicked == 1) + string.Empty);
				}
				try
				{
					if (hangItem > 0 && hangItem < 5 && item.type != 13 && item.type < 13)
					{
						text = ((item.type != 8) ? (text + setTemp("cần " + groupKick[item.type][0] + " hoặc " + groupKick[item.type][1] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0")) : ((viTriVe != 1) ? (text + setTemp("Nhẫn dưới cần " + groupKick[item.type][2] + " hoặc " + groupKick[item.type][3] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0")) : (text + setTemp("Nhẫn trên cần " + groupKick[item.type][0] + " hoặc " + groupKick[item.type][1] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0"))));
					}
					if (hangItem > 0 && hangItem < 5 && isAnimalArmor(item.type))
					{
						text += setTemp("cần " + groupKickAnimal[item.type - 14][0] + " hệ " + kickHe[heItem][0] + " để kích ngũ hành", "0");
					}
				}
				catch (Exception)
				{
				}
			}
			else
			{
				text += item.name;
				if (!nameCharSeal.Equals(string.Empty))
				{
					text = text + "\n0" + nameCharSeal.ToLower() + ((nameCharSeal.IndexOf("-") <= -1) ? " tạo" : string.Empty);
				}
				for (byte b2 = 0; b2 < allAttribute.size(); b2 = (byte)(b2 + 1))
				{
					InfoAttributeItem infoAttributeItem2 = (InfoAttributeItem)allAttribute.elementAt(b2);
					string temp2 = infoAttributeItem2.getName(clazz) + infoAttributeItem2.getValue() + ((!infoAttributeItem2.isPercent()) ? string.Empty : "%");
					text += setTemp(temp2, infoAttributeItem2.getColorPaint(beKicked == 1) + string.Empty);
				}
			}
			if (dayUse != 0)
			{
				long num = dayUse - (mSystem.currentTimeMillis() - lastTime) / 60000;
				if (num < 0)
				{
					num = 1L;
				}
				text += setTemp("\nThời gian còn lại: " + ((num / 60 <= 0) ? string.Empty : (num / 60 + "h ")) + ((num % 60 <= 0) ? string.Empty : (num % 60 + "p")), 0 + string.Empty);
			}
			if (timeEnd > 0)
			{
				text += setTemp(nameCharSell, "0");
				text += setTemp(daySell, "0");
				text += setTemp("Bid: " + prizeBet + " xu", "0");
				text += setTemp((!nameCharBet.Equals(string.Empty)) ? (nameCharBet + " bid") : "----", "0");
				text += setTemp(getTimeSell(), 0 + string.Empty);
			}
		}
		return text;
	}

	public static string setTemp(string temp, string typeFont)
	{
		string text = string.Empty;
		string[] array = MFont.borderFont.splitFontBStrInLine(temp, 95);
		for (int i = 0; i < array.Length; i++)
		{
			text = text + "\n" + typeFont + array[i];
		}
		return text;
	}

	public static bool isAnimalArmor(int type)
	{
		return type >= 14 && type <= 18;
	}

	public string getTemplateDescription()
	{
		string text = string.Empty;
		try
		{
			string[] array = new string[5]
			{
				"Giáp nhẹ",
				"Giáp nặng",
				"Giáp vải",
				"Giáp nặng",
				"Giáp nhẹ"
			};
			if (catagory == 3)
			{
				string text2 = string.Empty;
				ItemTemplate item = Res.getItem(charClazz, idTemplate);
				if (idTemplate < 264 || idTemplate > 267)
				{
					if (plusTemplate > 0)
					{
						text2 = text2 + "+" + plusTemplate;
					}
					text = text + "\n" + item.name;
					text = text + " " + text2;
					if ((item.id < 79 || item.id > 137) && item.type != 13 && isAnimalArmor(item.type))
					{
						text = text + "\n" + array[clazz];
					}
					if (item.id > 113 && item.id <= 137 && item.type != 13)
					{
						text = text + "\n" + Res.nameClazz[clazz];
					}
					text = ((item.ndayLoan != 0) ? (text + "\nGiá: " + Canvas.getMoneys(item.price + plusTemplate) + " Lượng") : (text + "\nGiá: " + Canvas.getMoneys(item.price + plusTemplate * 1000) + " xu"));
					if (level != -1)
					{
						text = text + "\nYêu cầu lv: " + level;
					}
					text = text + "\nĐộ bền: " + durable;
					if (item.clazz != -1 && item.type != 13)
					{
						text = text + "\nDành cho: " + CreateCharScr.clazz[clazz][CreateCharScr.selectGender].name;
					}
					int[] attributeItem = Res.getAttributeItem(charClazz, idTemplate, item.type);
					if (item.type < 2 || item.type == 10 || item.type == 11 || isAnimalArmor(item.type))
					{
						if (typeItemBuy == 0)
						{
							attributeItem[6] = attributeItem[1];
							attributeItem[1] /= 10;
						}
						else
						{
							attributeItem[6] = attributeItem[1] / 10;
						}
					}
					for (int i = 0; i < 10; i++)
					{
						if (attribShowedForType[item.type][i])
						{
							string text3 = text;
							text = text3 + "\n" + attrName[i] + ": " + attributeItem[i];
						}
					}
				}
				else
				{
					text += item.name;
					string text3 = text;
					text = text3 + "\nTấn công tăng: " + item.attb[0] + "%";
					text3 = text;
					text = text3 + "\nThủ tăng: " + item.attb[1] + "%";
					text = text + "\nHP tăng: " + item.attb[2];
					text = text + "\nMP tăng: " + item.attb[3];
				}
				if (item.ndayLoan > 0)
				{
					text += setTemp("\nThời hạn: " + item.ndayLoan + " Phút.", "0");
				}
			}
			if (catagory != 4)
			{
				return text;
			}
			if (!isShopItem)
			{
				return text;
			}
			text = string.Empty + MainChar.listPotion[potionType].name;
			text = text + "\nGiá: " + Canvas.getMoneys(Res.potionTemplates[potionType].price) + "$";
			if (Res.potionTemplates[potionType].recovered >= 80)
			{
				string text3 = text;
				text = text3 + "\nTăng " + Res.potionTemplates[potionType].recovered + " " + MainChar.listPotion[potionType].name2;
			}
			else if (Res.potionTemplates[potionType].recovered == 0)
			{
				text += "\nKhăn đeo dùng khi đánh nhau.";
			}
			else if (Res.potionTemplates[potionType].recovered == -1)
			{
				text += "\nDịch chuyển tức thời về làng.";
			}
			int num = Canvas.gameScr.mainChar.potions[potionType];
			int num2 = 0;
			for (int j = 0; j < WindowInfoScr.gI().readyBuy.size(); j++)
			{
				ItemInInventory itemInInventory = (ItemInInventory)WindowInfoScr.gI().readyBuy.elementAt(j);
				if (itemInInventory.potionType == potionType)
				{
					num2 = itemInInventory.number;
				}
			}
			if (num2 == 0)
			{
				string text3 = text;
				text = text3 + "\nĐang có: " + num + " cái.";
			}
			else
			{
				string text3 = text;
				text = text3 + "\nĐang có: " + num + "+" + num2 + " cái.";
			}
			if (num + num2 < WindowInfoScr.MAX_POTION)
			{
				return text;
			}
			text += "\n(tối đa)";
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}

	public string getInfoItemUserSell()
	{
		string empty = string.Empty;
		string text = string.Empty;
		ItemTemplate item = Res.getItem(charClazz, idTemplate);
		if (plusTemplate > 0)
		{
			text = text + " +" + plusTemplate;
		}
		text = text + " " + magic[magic_physic];
		if (hangItem > -1)
		{
			text = text + " " + nameHangItem[hangItem];
		}
		if (heItem > -1)
		{
			text = text + " " + he[heItem];
		}
		empty += setTemp(item.name + text, string.Empty + colorName);
		if (!nameCharSeal.Equals(string.Empty))
		{
			empty = empty + "\n0" + nameCharSeal.ToUpper() + " tạo";
		}
		if (level != -1)
		{
			empty = empty + "\nYêu cầu lv: " + level;
		}
		empty = empty + "\nĐộ bền: " + durable;
		if (clazz != -1)
		{
			empty = empty + "\nDòng: " + CreateCharScr.clazz[clazz][CreateCharScr.selectGender].name;
		}
		for (sbyte b = 0; b < allAttribute.size(); b = (sbyte)(b + 1))
		{
			InfoAttributeItem infoAttributeItem = (InfoAttributeItem)allAttribute.elementAt(b);
			string temp = infoAttributeItem.getName(clazz) + infoAttributeItem.getValue() + ((!infoAttributeItem.isPercent()) ? string.Empty : "%");
			empty += setTemp(temp, infoAttributeItem.getColorPaint(kick: false) + string.Empty);
		}
		if (prize > 0)
		{
			empty = empty + "\nGiá bán:\n0" + Canvas.getMoneys(prize);
			Out.println(prize + " GIA BAN " + Canvas.getMoneys(prize));
		}
		return empty;
	}

	public static mVector getAllItemChar()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (isItemChar(item.type) && itemInInventory.dayUse == 0)
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public static mVector getAllItem(int colorItem)
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			if (itemInInventory.colorName == colorItem)
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public static mVector getAllItemCharExcepColor(int colorItem)
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			if (itemInInventory.colorName != colorItem && isItemChar(itemInInventory.getTemplate().type))
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public static mVector getAllItemAnimal(int colorItem, int hang)
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			if (itemInInventory.colorName == colorItem && itemInInventory.hangItem == hang && isAnimalArmor(itemInInventory.getTemplate().type))
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public static mVector getAllItemCanSell()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (!isModelClothe(item.attb[9]) && itemInInventory.islock == 0 && itemInInventory.dayUse == 0)
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public static mVector getAllItem()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Char.inventory.size(); i++)
		{
			ItemInInventory itemInInventory = (ItemInInventory)Char.inventory.elementAt(i);
			ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
			if (!isModelClothe(item.attb[9]))
			{
				mVector.addElement(itemInInventory);
			}
		}
		return mVector;
	}

	public void paint(MyGraphics g, int x, int y)
	{
		ItemTemplate item = Res.getItem(charClazz, idTemplate);
		GameData.paintIcon(g, item.idIcon, x, y);
		if (plusTemplate > 12)
		{
			Res.paintRectColor(g, x - 9, y - 9, 17, 17, count, color[plusTemplate - 13], 16516369);
			count += 3;
			if (count > 68)
			{
				count = 0;
			}
		}
	}

	public static bool isThanThu(int type)
	{
		return type == 25;
	}

	public string getTimeSell()
	{
		long num = timeEnd - mSystem.currentTimeMillis();
		if (num <= 0)
		{
			return "Hết giờ";
		}
		if (num > 0 && num / 60000 == 0L)
		{
			return (num <= 0) ? string.Empty : ("Còn lại: " + num / 1000 + " giây");
		}
		return (num <= 0) ? string.Empty : ("Còn lại: " + num / 60000 + " phút");
	}
}
