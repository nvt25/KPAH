public class ChatPopup
{
	public int timeOut;

	public int xc;

	public int yc;

	public int arrowType;

	public int h;

	public int w;

	public int isAr;

	private string[] chats;

	public static Image imgPopup;

	public static Image imgArrow;

	public ChatPopup()
	{
	}

	public ChatPopup(int time, string chat, int isAr)
	{
		prepareData(time, chat);
		this.isAr = isAr;
	}

	public static void getImg()
	{
		imgPopup = FilePack.getImg("c");
		imgArrow = FilePack.getImg("ar");
	}

	public void setPos(int x, int y)
	{
		xc = x;
		yc = y;
	}

	public bool setOut()
	{
		if (timeOut > 0)
		{
			timeOut--;
		}
		if (timeOut == 0)
		{
			return true;
		}
		return false;
	}

	public void prepareData(int time, string chat)
	{
		chats = MFont.blackFont.splitFontBStrInLine(chat, 80);
		GameScr.timeDelayTask = chats.Length * 8;
		h = 14 * chats.Length + 4 + 4;
		w = 30;
		for (int i = 0; i < chats.Length; i++)
		{
			int num = MFont.blackFont.getWidth(chats[i]) + 50;
			if (num > w)
			{
				w = num;
			}
		}
		timeOut = time + 3;
	}

	public void paintAnimal(MyGraphics g)
	{
		paintRoundRect(g, xc - w / 2, yc - h - 4, w, h, 16777215, 1);
		if (isAr == 1)
		{
			g.drawImage(imgArrow, xc, yc - 5, MyGraphics.TOP | MyGraphics.HCENTER);
		}
		int num = yc - h;
		for (int i = 0; i < chats.Length; i++)
		{
			MFont.blackFont.drawString(g, chats[i], xc, num, 2);
			num += 14;
		}
	}

	public static void paintRoundRect(MyGraphics g, int x, int y, int w, int h, int color1, int color2)
	{
		g.drawRegion(imgPopup, 0, 0, 8, 8, 0, x, y, 0);
		g.drawRegion(imgPopup, 0, 8, 8, 8, 0, x + w - 8, y, 0);
		g.drawRegion(imgPopup, 0, 24, 8, 8, 0, x, y + h - 8, 0);
		g.drawRegion(imgPopup, 0, 16, 8, 8, 0, x + w - 8, y + h - 8, 0);
		g.setColor(color1);
		g.fillRect(x + 8, y, w - 16, 8);
		g.fillRect(x + 8, y + h - 8, w - 16, 7);
		g.fillRect(x, y + 8, w, h - 16);
		g.setColor(color2);
		g.fillRect(x + 8, y, w - 16, 1);
		g.fillRect(x + 8, y + h - 1, w - 16, 1);
		g.fillRect(x, y + 8, 1, h - 16);
		g.fillRect(x + w - 1, y + 8, 1, h - 16);
	}
}
