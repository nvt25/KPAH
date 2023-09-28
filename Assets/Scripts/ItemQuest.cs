public class ItemQuest : Dropable
{
	public static string[] NAME_ITEM = new string[1]
	{
		string.Empty
	};

	public static sbyte[] ICON_IMG = new sbyte[1];

	public override void paint(MyGraphics g)
	{
		GameData.paintIcon(g, (short)(ICON_IMG[item_template_id] + 8000), x, y - deltaH);
	}

	public override string getDisplayName()
	{
		return NAME_ITEM[item_template_id];
	}

	public override bool isItemCanGet()
	{
		return true;
	}
}
