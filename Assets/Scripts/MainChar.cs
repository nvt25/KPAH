public class MainChar : Char
{
	public static QuickSlot[][] quickSlot;

	public bool isFirstTimeGetItem;

	public bool isFirstTimeGetMoney;

	public bool isFirstTimeGetPotion;

	public bool autoFight;

	public bool check;

	public bool canMove;

	public sbyte idSkill;

	public sbyte limItemBag;

	public int idMonster;

	public static mVector gemitemImbue = new mVector();

	public static mVector gemItem = new mVector();

	public static mVector gemItemKhoa = new mVector();

	public static mVector shopItem = new mVector();

	public mVector tItems = new mVector();

	public mVector rItems = new mVector();

	public static Potion[] listPotion;

	public static short[] itemQuest;

	public bool first;

	public short lastLv;

	public short xBegin;

	public short yBegin;

	public int countRoad;

	public short[] posTransRoad;

	public short day;

	public int dedicationPoint;

	public Quest mainQuest;

	public sbyte typeClass;

	public int pArena;

	public string nameHusband_wife = string.Empty;

	public bool stop;

	public static void remove()
	{
		gemitemImbue.removeAllElements();
		gemItem.removeAllElements();
		gemItemKhoa.removeAllElements();
		shopItem.removeAllElements();
		quickSlot = null;
		listPotion = null;
	}

	public override bool FuntioncanMove()
	{
		return base.FuntioncanMove();
	}

	public void loadQuickSlot()
	{
		if (quickSlot == null)
		{
			quickSlot = new QuickSlot[2][];
			for (int i = 0; i < quickSlot.Length; i++)
			{
				quickSlot[i] = new QuickSlot[5];
			}
			for (int j = 0; j < 5; j++)
			{
				quickSlot[0][j] = new QuickSlot();
				quickSlot[1][j] = new QuickSlot();
			}
			if (Char.skillLevelLearnt[1] > 0)
			{
				quickSlot[0][0].setIsSkill(1, clazz, isBuff: false);
			}
			if (Char.skillLevelLearnt[2] > 0)
			{
				quickSlot[0][1].setIsSkill(2, clazz, isBuff: false);
			}
			quickSlot[0][2].setIsSkill(0, clazz, isBuff: false);
			quickSlot[0][3].setIsPotion(1);
			quickSlot[0][4].setIsPotion(4);
			quickSlot[1][3].setIsPotion(1);
			quickSlot[1][4].setIsPotion(4);
			RMS.loadQuickSlot();
		}
	}

	public void resetAuto()
	{
		autoFight = false;
		idSkill = 0;
	}

	public string getPercent()
	{
		return lvpercent / 10 + "." + lvpercent % 10 + "%";
	}

	public void add2Party(PartyInfo info)
	{
		for (int i = 0; i < Char.party.size(); i++)
		{
			if (((PartyInfo)Char.party.elementAt(i)).name.Equals(info.name))
			{
				return;
			}
		}
		Char.party.addElement(info);
	}

	public void add2Party(Char info)
	{
		for (int i = 0; i < Char.party.size(); i++)
		{
			Char @char = (Char)Char.party.elementAt(i);
			if (@char == info)
			{
				return;
			}
		}
		Char.party.addElement(info);
	}

	public string removeUserParty(short iduser)
	{
		string empty = string.Empty;
		for (int i = 0; i < Char.party.size(); i++)
		{
			if (((PartyInfo)Char.party.elementAt(i)).id == iduser)
			{
				empty = ((PartyInfo)Char.party.elementAt(i)).name;
				Char.party.removeElementAt(i);
				return empty;
			}
		}
		return string.Empty;
	}

	public string removeCharParty(short iduser)
	{
		string empty = string.Empty;
		for (int i = 0; i < Char.party.size(); i++)
		{
			if (((Char)Char.party.elementAt(i)).ID == iduser)
			{
				empty = ((Char)Char.party.elementAt(i)).name;
				Char.party.removeElementAt(i);
				return empty;
			}
		}
		return string.Empty;
	}

	public override void update()
	{
		base.update();
		if (!isFreeze && posTransRoad != null)
		{
			updateWayPointer();
			check = false;
		}
		if (!stop && mSystem.currentTimeMillis() - GameScr.timeMove >= 0)
		{
			GameScr.timeMove = mSystem.currentTimeMillis() + GameScr.dtmove;
			stop = true;
			GameService.gI().moveChar(x, y);
		}
		checkChangemapTouch();
	}

	private void checkChangemapTouch()
	{
		if (GameScr.iTaskAuto == 2)
		{
			return;
		}
		if (canMove && !check && state == 1)
		{
			int num = 0;
			int num2 = 0;
			if (dir == Char.LEFT)
			{
				num = -32;
			}
			else if (dir == Char.RIGHT)
			{
				num = 32;
			}
			if (dir == Char.DOWN)
			{
				num2 = 32;
			}
			else if (dir == Char.UP)
			{
				num2 = -32;
			}
			if ((Math.abs(x - xBegin) >= 16 || Math.abs(y - yBegin) >= 16) && Canvas.gameScr.checkCanChangeMap(x + num, y + num2, dir))
			{
				posTransRoad = null;
				check = true;
				return;
			}
		}
		if (state == 1)
		{
			canMove = true;
		}
		else
		{
			canMove = false;
		}
	}

	private void updateWayPointer()
	{
		if (Util.abs(x - xTo) > 3 || Util.abs(y - yTo) > 3)
		{
			return;
		}
		int num = posTransRoad.Length - 1 - countRoad;
		while (true)
		{
			if (num < 0)
			{
				return;
			}
			if (posTransRoad[num] > 0)
			{
				sbyte b = (sbyte)(GameScr.xStart + (posTransRoad[num] >> 8));
				sbyte b2 = (sbyte)(GameScr.yStart + (posTransRoad[num] & 0xFF));
				if (GameScr.iTaskAuto != 2 && (dir == 1 || Tilemap.isOfflineMap) && Canvas.gameScr.checkCanChangeMap(b * 16 + speed, b2 * 16 + speed, dir))
				{
					posTransRoad = null;
					countRoad = 0;
					return;
				}
				if (Canvas.gameScr.checkMoveLimit(b * 16 + speed, b2 * 16 + speed))
				{
					posTransRoad = null;
					return;
				}
				moveTo((short)(b * 16 + speed), (short)(b2 * 16 + speed));
				Canvas.gameScr.sendActorMove((short)(b * 16 + speed), (short)(b2 * 16 + speed));
				posTransRoad[num] = -1;
				countRoad++;
				return;
			}
			if (num == 0)
			{
				break;
			}
			num--;
		}
		posTransRoad = null;
		countRoad = 0;
	}

	public string[] getInfoSkill(int idSkill)
	{
		string[] result = null;
		if (Char.skillLevelLearnt[idSkill] == -1)
		{
			result = new string[2]
			{
				"Chưa học kỹ năng này",
				"Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][1]
			};
		}
		else if (Char.skillLevelLearnt[idSkill] == 0)
		{
			result = new string[2]
			{
				"Chưa học kỹ năng này",
				getLvRequest(idSkill)
			};
		}
		else if (!MenuWindows.gI().isBuffSkill())
		{
			result = new string[5]
			{
				"Thời gian đánh: " + SkillManager.getSkillCooldown((sbyte)idSkill, clazz, Char.skillLevelLearnt[idSkill]) + " ms",
				SkillManager.infoString[clazz][idSkill] + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
				"Phạm vi: " + SkillManager.getSkillRange((sbyte)idSkill, clazz),
				"MP mất: " + SkillManager.getSkillMP(idSkill, Char.skillLevelLearnt[idSkill], clazz),
				(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
			};
		}
		else
		{
			sbyte[][] array = new sbyte[5][]
			{
				new sbyte[2]
				{
					1,
					5
				},
				new sbyte[2]
				{
					1,
					2
				},
				new sbyte[4]
				{
					3,
					4,
					5,
					6
				},
				new sbyte[2]
				{
					0,
					1
				},
				new sbyte[2]
				{
					0,
					3
				}
			};
			string text = "MP mất: " + SkillManager.getSkillMP(idSkill, Char.skillLevelLearnt[idSkill], clazz);
			switch (clazz)
			{
			case 0:
				switch (idSkill)
				{
				case 4:
					result = new string[4]
					{
						"Đánh xuyên giáp",
						"Tỷ lệ thành công: " + SkillManager.SKILL_DAM_PERCENT[clazz][idSkill][Char.skillLevelLearnt[idSkill]] + "%",
						text,
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				case 5:
					result = new string[6]
					{
						"Gây tác hại lại 1 phần",
						"sức công cho đối thủ",
						"Thời gian: " + SkillManager.TIME_LIFE_BUFF_SKILL[array[clazz][idSkill - 4]][Char.skillLevelLearnt[idSkill]] + "s",
						"Tỷ lệ: " + SkillManager.SKILL_DAM_PERCENT[clazz][idSkill][Char.skillLevelLearnt[idSkill]] + "%",
						text,
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				}
				break;
			case 1:
				switch (idSkill)
				{
				case 5:
					result = new string[4]
					{
						"Tăng sức tấn công",
						"của bản thân",
						"Tỷ lệ tăng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				case 4:
					result = new string[4]
					{
						"Phòng thủ tăng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						"Thời gian: " + SkillManager.TIME_LIFE_BUFF_SKILL[array[clazz][idSkill - 4]][Char.skillLevelLearnt[idSkill]] + "s",
						text,
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				}
				break;
			case 2:
				switch (idSkill)
				{
				case 5:
					result = new string[4]
					{
						"Tăng tinh thần",
						"của bản thân",
						"Tỷ lệ tăng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				case 4:
					result = new string[4]
					{
						"MP + HP tăng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + " %",
						"Thời gian: " + SkillManager.TIME_LIFE_BUFF_SKILL[array[clazz][idSkill - 4]][Char.skillLevelLearnt[idSkill]] + "s",
						text,
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				case 6:
					result = new string[4]
					{
						"Hồi sinh",
						"HP hồi phục: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						text,
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				case 7:
					result = new string[7]
					{
						"Khiên MP",
						"Chuyển 1 lượng hao tổn",
						"HP sang MP",
						"Tỷ lệ chuyển: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						"Thời gian: " + SkillManager.TIME_LIFE_BUFF_SKILL[array[clazz][idSkill - 4]][Char.skillLevelLearnt[idSkill]] + "s",
						text,
						(Char.skillLevelLearnt[idSkill] >= 9) ? string.Empty : ("Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]])
					};
					break;
				}
				break;
			case 3:
				switch (idSkill)
				{
				case 5:
					result = new string[4]
					{
						"Tăng sức phòng thủ",
						"của bản thân",
						"Tỷ lệ tăng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						getLvRequest(idSkill)
					};
					break;
				case 4:
					result = new string[6]
					{
						"Gây choáng cho",
						"đối phương",
						"Thời gian: " + 5 + "s",
						"Tỷ lệ gây choáng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						text,
						getLvRequest(idSkill)
					};
					break;
				}
				break;
			case 4:
				switch (idSkill)
				{
				case 5:
					result = new string[3]
					{
						"Tăng độc tính sử dụng",
						"Tỷ lệ tăng: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "%",
						getLvRequest(idSkill)
					};
					break;
				case 4:
					result = new string[5]
					{
						"Tẩm độc vào tên: ",
						"Độc tính: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz),
						"Thời gian: " + SkillManager.getSkillDamPercent(idSkill, Char.skillLevelLearnt[idSkill], clazz) + "s",
						text,
						getLvRequest(idSkill)
					};
					break;
				}
				break;
			}
		}
		return result;
	}

	public string getLvRequest(int idSkill)
	{
		return "Lv yêu cầu: " + SkillManager.LEVEL_ADD_SKILL[idSkill][Char.skillLevelLearnt[idSkill]];
	}

	public bool setWay(int vX, int vY)
	{
		short x = base.x;
		if (vX != 0)
		{
			if (!Tilemap.tileTypeAtPixel(base.x + vX, y - 16, 2) && !Tilemap.tileTypeAtPixel(base.x, y - 16, 2))
			{
				moveTo(x, (short)(y - 16));
				return true;
			}
			if (!Tilemap.tileTypeAtPixel(base.x + vX, y + 16, 2) && !Tilemap.tileTypeAtPixel(base.x, y + 16, 2))
			{
				moveTo(x, (short)(y + 16));
				return true;
			}
		}
		else if (vY != 0)
		{
			if (!Tilemap.tileTypeAtPixel(base.x - 16, y + vY, 2) && !Tilemap.tileTypeAtPixel(base.x - 16, y, 2))
			{
				moveTo((short)(base.x - 16), y);
				return true;
			}
			if (!Tilemap.tileTypeAtPixel(base.x + 16, y + vY, 2) && !Tilemap.tileTypeAtPixel(base.x + 16, y, 2))
			{
				moveTo((short)(base.x + 16), y);
				return true;
			}
		}
		return false;
	}
}
