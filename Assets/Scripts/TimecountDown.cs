public class TimecountDown
{
	private long mysecond;

	public string tile;

	public bool wantdestroy;

	public short id;

	public short idIcon;

	public sbyte typeCount;

	public TimecountDown(short id, long second, string tile)
	{
		mysecond = mSystem.currentTimeMillis() + second * 1000;
		this.tile = tile;
		this.id = id;
		idIcon = -1;
	}

	public TimecountDown(short id, short idIcon, long second, string tile, sbyte type)
	{
		mysecond = mSystem.currentTimeMillis() + second * 1000;
		this.tile = tile;
		this.id = id;
		this.idIcon = idIcon;
		typeCount = type;
		if (typeCount == 0)
		{
			mysecond = second;
		}
	}

	public void paint(MyGraphics g, int x, int y)
	{
		if (idIcon == -1)
		{
			if (typeCount == 1)
			{
				int num = (int)((mysecond - mSystem.currentTimeMillis()) / 1000);
				if (num > 0)
				{
					MFont.arialFont.drawString(g, tile + " : " + converSecon2hours(num), x - 5, y + 1, 1);
					MFont.arialFontW.drawString(g, tile + " : " + converSecon2hours(num), x - 4, y, 1);
				}
			}
			else
			{
				MFont.arialFont.drawString(g, tile, x + 1, y + 1, 1);
				MFont.arialFontW.drawString(g, tile, x, y, 1);
			}
			return;
		}
		ImageIcon imgIcon = GameData.getImgIcon(idIcon);
		if (imgIcon != null && imgIcon.img != null)
		{
			if (typeCount == 0)
			{
				int width = MFont.arialFont.getWidth(tile + " : ");
				g.drawImage(imgIcon.img, x - width - imgIcon.img.getWidth() * 2, y + imgIcon.img.getHeight() / 4, 0);
				MFont.arialFont.drawString(g, tile, x - width - imgIcon.img.getWidth() * 2 + 1 + imgIcon.img.getWidth(), y + 1 + imgIcon.img.getHeight() / 4, 0);
				MFont.arialFontW.drawString(g, tile, x - width - imgIcon.img.getWidth() * 2 + imgIcon.img.getWidth(), y + imgIcon.img.getHeight() / 4, 0);
			}
			else if (typeCount == 1)
			{
				int totalSeconds = (int)((mysecond - mSystem.currentTimeMillis()) / 1000);
				int width2 = MFont.arialFont.getWidth(converSecon2hours(totalSeconds) + ":");
				g.drawImage(imgIcon.img, x - width2 - imgIcon.img.getWidth() * 2, y + imgIcon.img.getHeight() / 4, 0);
				MFont.arialFont.drawString(g, " : " + converSecon2hours(totalSeconds), x - width2 - imgIcon.img.getWidth() * 2 + 1 + imgIcon.img.getWidth(), y + 1 + imgIcon.img.getHeight() / 4, 0);
				MFont.arialFontW.drawString(g, " : " + converSecon2hours(totalSeconds), x - width2 - imgIcon.img.getWidth() * 2 + imgIcon.img.getWidth(), y + imgIcon.img.getHeight() / 4, 0);
			}
		}
	}

	public void setsecond(long second)
	{
		mysecond = mSystem.currentTimeMillis() + second * 1000;
	}

	public void update()
	{
		if (typeCount == 1 && mSystem.currentTimeMillis() - mysecond >= 0)
		{
			wantdestroy = true;
		}
	}

	public static string converSecon2hours(int totalSeconds)
	{
		int num = totalSeconds % 60;
		int num2 = totalSeconds / 60;
		int num3 = num2 % 60;
		int num4 = num2 / 60;
		if (num4 > 0)
		{
			return num4 + ":" + num3;
		}
		if (num3 > 0)
		{
			return num3 + ":" + num;
		}
		if (num < 0)
		{
			return "0:" + num;
		}
		return num + string.Empty;
	}
}
