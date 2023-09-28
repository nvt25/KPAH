public class DropGemItem : Dropable
{
	public override void paint(MyGraphics g)
	{
		if (catagory == 6)
		{
			Res.paintGem(g, Res.getGemByID(item_template_id).idImage, x, y - deltaH);
		}
		else
		{
			GameData.paintIcon(g, (short)(Res.getShopByID((byte)item_template_id).idImage + 5500), x, y - deltaH);
		}
	}

	public override string getDisplayName()
	{
		if (catagory == 6)
		{
			return Res.getGemByID(item_template_id).name;
		}
		return Res.getShopByID(item_template_id).name;
	}

	public override bool isItemCanGet()
	{
		return true;
	}
}
