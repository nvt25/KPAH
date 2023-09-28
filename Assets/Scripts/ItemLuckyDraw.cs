using System;

public class ItemLuckyDraw
{
	public sbyte cat;

	public sbyte isSelect = 1;

	public int id;

	public string name;

	public string[] decript;

	public void paint(MyGraphics g, int x, int y)
	{
		try
		{
			switch (cat)
			{
			case 3:
			{
				ItemTemplate item = Res.getItem(0, id);
				GameData.paintIcon(g, item.idIcon, x, y);
				break;
			}
			case 12:
				GameData.paintIcon(g, (short)(id + 7500), x, y);
				break;
			case 4:
				Res.paintPotion(g, MainChar.listPotion[id].index, x, y, 3);
				break;
			case 6:
				Res.paintGemKhoa(g, Res.getGemByID((short)id).idImage, x, y);
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public string getName()
	{
		return name;
	}

	public string[] getDecript()
	{
		return (decript != null) ? decript : new string[1]
		{
			name
		};
	}
}
