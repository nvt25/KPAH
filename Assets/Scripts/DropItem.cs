public class DropItem : Dropable
{
	public override void paint(MyGraphics g)
	{
		ItemTemplate itemTemplate = ((ItemTemplate[])Res.itemTemplates.elementAt(itemClass))[item_template_id];
		GameData.paintIcon(g, itemTemplate.idIcon, x, y - deltaH);
	}

	public override string getDisplayName()
	{
		return ((ItemTemplate[])Res.itemTemplates.elementAt(itemClass))[item_template_id].name;
	}

	public override bool isItemCanGet()
	{
		return true;
	}
}
