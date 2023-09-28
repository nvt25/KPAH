public class DropPotion : Dropable
{
	private byte startItemQuest = 10;

	public override void paint(MyGraphics g)
	{
		GameData.paintIcon(g, (short)(MainChar.listPotion[item_template_id].index + 5500), x, y - deltaH);
	}

	public override string getDisplayName()
	{
		if (item_template_id < 7 || item_template_id >= 14)
		{
			return MainChar.listPotion[item_template_id].name;
		}
		if (item_template_id > 9 && item_template_id < 14)
		{
			return Res.PORTION_ITEM_NAME;
		}
		return Res.PORTION_ITEM_NAME_CLAN;
	}

	public string getDisplayName2()
	{
		if (item_template_id < 7 || item_template_id >= 14)
		{
			return MainChar.listPotion[item_template_id].name2;
		}
		if (item_template_id > 9 && item_template_id < 14)
		{
			return Res.PORTION_ITEM_NAME2;
		}
		return Res.PORTION_ITEM_NAME_CLAN;
	}

	public override bool isItemCanGet()
	{
		return true;
	}
}
