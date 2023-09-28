public class SkillManager : MyHashTable
{
	public static SkillManager instance = new SkillManager();

	private static string strTancong = "Tấn công tăng: ";

	private static string strPhongThu = "Phòng thủ tăng: ";

	public static string[][] infoString = new string[5][]
	{
		new string[9]
		{
			strTancong,
			strTancong,
			strTancong,
			strTancong,
			strPhongThu,
			strTancong,
			strTancong,
			strTancong,
			strTancong
		},
		new string[9]
		{
			strTancong,
			strTancong,
			strTancong,
			strTancong,
			strPhongThu,
			"Tăng sức công: ",
			strTancong,
			strTancong,
			strTancong
		},
		new string[11]
		{
			strTancong,
			strTancong,
			strTancong,
			strTancong,
			"HP+MP tăng: ",
			"MP tăng: ",
			"Hồi sinh: ",
			"Chia sẻ thiệt hại: ",
			strTancong,
			strTancong,
			strTancong
		},
		new string[9]
		{
			strTancong,
			strTancong,
			strTancong,
			strTancong,
			"Tốc độ tăng: ",
			strPhongThu,
			strTancong,
			strTancong,
			strTancong
		},
		new string[9]
		{
			strTancong,
			strTancong,
			strTancong,
			strTancong,
			"Tốc độ tăng: ",
			"HP tăng: ",
			strTancong,
			strTancong,
			strTancong
		}
	};

	public static sbyte[][] LEVEL_ADD_SKILL;

	public static readonly sbyte[][] EFF_BUFF_SKILL = new sbyte[5][]
	{
		new sbyte[2]
		{
			20,
			24
		},
		new sbyte[2]
		{
			20,
			21
		},
		new sbyte[4]
		{
			25,
			30,
			27,
			23
		},
		new sbyte[2]
		{
			19,
			20
		},
		new sbyte[2]
		{
			22,
			19
		}
	};

	public static readonly sbyte[][] SKILL_CAN_BUFF_TO_USER = new sbyte[5][]
	{
		new sbyte[2]
		{
			-1,
			0
		},
		new sbyte[2]
		{
			0,
			-1
		},
		new sbyte[4]
		{
			0,
			-1,
			1,
			0
		},
		new sbyte[2]
		{
			0,
			-1
		},
		new sbyte[2]
		{
			0,
			-1
		}
	};

	public static sbyte[][] SKILL_AEO;

	public static readonly sbyte[][][] RANGE_SKILL_AEO = new sbyte[1][][]
	{
		new sbyte[3][]
		{
			new sbyte[11]
			{
				0,
				64,
				64,
				80,
				80,
				96,
				96,
				102,
				118,
				124,
				124
			},
			new sbyte[11]
			{
				0,
				64,
				64,
				80,
				80,
				96,
				96,
				102,
				118,
				124,
				124
			},
			new sbyte[11]
			{
				0,
				64,
				64,
				80,
				80,
				96,
				96,
				102,
				118,
				124,
				124
			}
		}
	};

	public static short[][][] SKILL_DAM_PERCENT;

	public static short[][] TIME_LIFE_BUFF_SKILL;

	public static int[][][] SKILL_COOLDOWN;

	public static short[][][] SKILL_MP;

	public static short[][] SKILL_RANGE;

	public static readonly string[][] SKILL_NAME = new string[5][]
	{
		new string[9]
		{
			"Chém",
			"Kim tinh pháp",
			"Lôi điện pháp",
			"Kinh lôi bát thủ",
			"Hộ sát tiến",
			"Dĩ lực đáo công",
			"Thiên lôi điện trảm",
			"Sấm động dương gian",
			"Kiếm phi kinh thiên"
		},
		new string[9]
		{
			"Chém",
			"Hỏa kinh thiên",
			"Nhất hỏa long",
			"Bát đại hỏa long",
			"Cường thân giáp",
			"Hộ công tiến",
			"Thiên long bạo kích",
			"Liệt hỏa bạo kích",
			"Sao băng giáng thế"
		},
		new string[11]
		{
			"Đánh",
			"Thủy giáng minh",
			"Thần long thủy",
			"Bát đại hải long",
			"Hồi công lực đan",
			"Hồi lực tiến",
			"Hồi sinh",
			"Song hộ công thủ",
			"Hải long xuất thế",
			"Song long thị uy",
			"Hàn băng vũ"
		},
		new string[9]
		{
			"Đập",
			"Thổ Tú",
			"Kim sơn thủy",
			"Khổng kình bát vĩ",
			"Bất di biến",
			"Hộ thủ tiến",
			"Kinh thiên động địa",
			"Sơn Tinh bộ thiên",
			"Thạch nhũ công tâm"
		},
		new string[9]
		{
			"Bắn",
			"Nhất hồn tiễn",
			"Phi thiên tiễn",
			"Bát kim tễn đáo",
			"Độc lưu tiễn",
			"Hộ độc tiễn",
			"Thập diện tâm tiễn",
			"Thăng thiên loạn tiễn",
			"Vạn tiễn quy tâm"
		}
	};

	public static SkillAnimate[][] SKILL_ANIMATE = new SkillAnimate[5][]
	{
		new SkillAnimate[9]
		{
			new Skill_Kiem_Type0(700),
			new Skill_Kiem_Type1(),
			new Skill_Kiem_Type2(),
			new Skill_Kiem_Type3(0),
			null,
			null,
			new Skill_Kiem_TypeAEO(4),
			new Skill_Kiem_TypeAEO(5),
			new Skill_Kiem_Type4()
		},
		new SkillAnimate[9]
		{
			new Skill_Kiem_Type0(1200),
			new Skill_Dao_Type1(),
			new Skill_Dao_Type2(),
			new Skill_Dao_Type3(0),
			null,
			null,
			new Skill_Dao_TypeAEO(isSkill5: false),
			new Skill_Dao_TypeAEO(isSkill5: true),
			new Skill_Dao_Type4()
		},
		new SkillAnimate[11]
		{
			new Skill_Kiem_Type0(1000),
			new Skill_Dua_Type1(),
			new Skill_Dua_Type2(),
			new Skill_Dua_Type3(0),
			null,
			null,
			null,
			null,
			new Skill_Dua_TypeAEO(isSkill5: false),
			new Skill_Dua_TypeAEO(isSkill5: true),
			new Skill_Dua_Type4(0)
		},
		new SkillAnimate[9]
		{
			new Skill_Kiem_Type0(1500),
			new Skill_Bua_Type1(),
			new Skill_Bua_Type2(),
			new Skill_Bua_Type3(0),
			null,
			null,
			new Skill_Bua_TypeAEO(isSkill5: false),
			new Skill_Bua_TypeAEO(isSkill5: true),
			new Skill_Bua_Type4(0)
		},
		new SkillAnimate[10]
		{
			new Skill_Cung_Type0(),
			new Skill_Cung_Type1(),
			new Skill_Cung_Type2(),
			new Skill_Cung_Type3(0),
			null,
			null,
			new Skill_Cung_TypeAEO(4, iss: false, 2),
			new Skill_Cung_TypeAEO(5, iss: true, 2),
			new Skill_Cung_Type4(0),
			new Skill_Cung_TypeAEO(4, iss: false, 5)
		}
	};

	public static int getSkillDamPercent(int skillType, int skillLevel, int clazz)
	{
		return (skillLevel > -1) ? SKILL_DAM_PERCENT[0][skillType][skillLevel] : 0;
	}

	public static int getSkillMP(int skillType, int skillLevel, int clazz)
	{
		return (skillLevel > -1) ? SKILL_MP[0][skillType][skillLevel] : 0;
	}

	public static long getSkillCooldown(sbyte skillType, sbyte clazz, int level)
	{
		return (level > -1) ? SKILL_COOLDOWN[0][skillType][level] : 0;
	}

	public static int getSkillRange(sbyte skillType, sbyte clazz)
	{
		return SKILL_RANGE[0][skillType];
	}

	public static short getLvAddSkill(int clazz, int idSkill, int lvSkill)
	{
		return (short)((lvSkill > -1) ? LEVEL_ADD_SKILL[idSkill][lvSkill] : 0);
	}

	public static sbyte getBuffToUser(int clazz, int id)
	{
		return SKILL_CAN_BUFF_TO_USER[clazz][id];
	}

	public static bool isSkillAeo(int cClass, int skill)
	{
		for (int i = 0; i < SKILL_AEO[cClass].Length; i++)
		{
			if (skill == SKILL_AEO[cClass][i])
			{
				return true;
			}
		}
		return false;
	}

	public static int getRangeSkillAeo(int charClass, int skill)
	{
		int num = Char.skillLevelLearnt[skill];
		if (num > -1)
		{
			for (int i = 0; i < SKILL_AEO[charClass].Length; i++)
			{
				if (skill == SKILL_AEO[charClass][i])
				{
					return RANGE_SKILL_AEO[0][i][num];
				}
			}
		}
		return 1984;
	}

	public static SkillAnimate getSkillAnimate(int skillType, int clazz)
	{
		if (clazz > SKILL_ANIMATE.Length)
		{
			return null;
		}
		if (skillType > SKILL_ANIMATE[clazz].Length)
		{
			return null;
		}
		return SKILL_ANIMATE[clazz][skillType];
	}

	public static SkillAnimate setSkillBoss_Xmas()
	{
		return new Skill_Boss_Xmas(isSkill5: false);
	}
}
