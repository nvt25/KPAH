using System;

public class QuickSlot
{
	public int quickslotType = -1;

	public int potionType;

	private sbyte skillType;

	private sbyte indexPotion;

	public static readonly sbyte TYPE_SKILL = 1;

	public static readonly sbyte TYPE_POTION = 2;

	public static readonly sbyte[] WEAPON_OF_CLAZZ = new sbyte[10]
	{
		0,
		1,
		2,
		3,
		4,
		0,
		1,
		2,
		3,
		4
	};

	public static Image img = null;

	public bool isBuff;

	public static void getImg()
	{
		img = FilePack.getImg("cooldown");
	}

	public void setIsSkill(int skillType, int clazz, bool isBuff)
	{
		quickslotType = TYPE_SKILL;
		this.skillType = (sbyte)skillType;
		this.isBuff = isBuff;
	}

	public void paint(MyGraphics g, int x, int y)
	{
		if (!Main.isPC)
		{
			if (img != null)
			{
				try
				{
					if (quickslotType != -1)
					{
						if (quickslotType == TYPE_SKILL)
						{
							if (GameData.imgSkillIcon != null)
							{
								switch (Canvas.gameScr.mainChar.clazz)
								{
								case 0:
									g.drawRegion(Res.imgIconSkillKiem, 0, skillType * 20, 20, 20, 0, x, y, 3);
									break;
								case 1:
									g.drawRegion(Res.imgIconSkillDao, 0, skillType * 20, 20, 20, 0, x, y, 3);
									break;
								case 2:
									g.drawRegion(Res.imgIconSkillPs, 0, skillType * 20, 20, 20, 0, x, y, 3);
									break;
								case 3:
									g.drawRegion(Res.imgIconSkillBua, 0, skillType * 20, 20, 20, 0, x, y, 3);
									break;
								case 4:
									g.drawRegion(Res.imgIconSkillCung, 0, skillType * 20, 20, 20, 0, x, y, 3);
									break;
								}
							}
							long num = mSystem.getCurrentTimeMillis() - Canvas.gameScr.mainChar.timeLastUseSkills[skillType];
							if (num < Canvas.gameScr.mainChar.coolDownSkill[skillType])
							{
								int num2 = (int)(num * 26 / Canvas.gameScr.mainChar.coolDownSkill[skillType]);
								g.drawRegion(img, 0, num2, 39, 39 - num2, 0, x, y + 1 + num2 / 2, 3);
							}
						}
						else
						{
							Res.paintPotion(g, MainChar.listPotion[potionType].index, x, y, 3);
							MFont.smallFont.drawString(g, Canvas.gameScr.mainChar.potions[potionType] + string.Empty, x + 3, y + 3, MFont.CENTER);
							long num3 = mSystem.getCurrentTimeMillis() - Canvas.gameScr.mainChar.potionLastTimeUse[potionType];
							if (num3 < MainChar.listPotion[potionType].delay)
							{
								int num4 = (int)(num3 * 26 / MainChar.listPotion[potionType].delay);
								g.drawRegion(img, 0, num4, 39, 39 - num4, 0, x, y + 1 + num4 / 2, 3);
							}
						}
					}
				}
				catch (Exception)
				{
					Out.println("ERROR QUICKSLOT");
				}
			}
		}
		else
		{
			try
			{
				if (quickslotType != -1)
				{
					if (quickslotType == TYPE_SKILL)
					{
						if (GameData.imgSkillIcon != null)
						{
							GameData.imgSkillIcon.drawFrame(skillType, x - 2, y - 1, 0, 0, g);
						}
						long num5 = mSystem.getCurrentTimeMillis() - Canvas.gameScr.mainChar.timeLastUseSkills[skillType];
						if (num5 < Canvas.gameScr.mainChar.coolDownSkill[skillType])
						{
							int num6 = (int)(num5 * 20 / Canvas.gameScr.mainChar.coolDownSkill[skillType]);
							g.setColor(0, 0.5f);
							g.fillRect(x - 2, y - 2 + num6, 20, 20);
						}
					}
					else
					{
						Res.paintPotion(g, MainChar.listPotion[potionType].index, x, y, 0);
						MFont.smallFontColor[0].drawString(g, Canvas.gameScr.mainChar.potions[potionType] + string.Empty, x + 16, y + 12, 1);
						long num7 = mSystem.getCurrentTimeMillis() - Canvas.gameScr.mainChar.potionLastTimeUse[potionType];
						if (num7 < MainChar.listPotion[potionType].delay)
						{
							int num8 = (int)(num7 * 20 / MainChar.listPotion[potionType].delay);
							g.setColor(0, 0.5f);
							g.setColor(0, 0.5f);
							g.fillRect(x - 2, y - 2 + num8, 20, 20);
						}
					}
				}
			}
			catch (Exception)
			{
				Out.println("ERROR QUICKSLOT");
			}
		}
	}

	public sbyte getSkillType()
	{
		return skillType;
	}

	public int getPotionType()
	{
		return potionType;
	}

	public void setIsPotion(int potionType)
	{
		quickslotType = TYPE_POTION;
		this.potionType = potionType;
	}

	public void setIsNothing()
	{
		quickslotType = -1;
	}
}
