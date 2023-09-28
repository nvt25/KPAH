public class MsgInfo
{
	public string message;

	public string[] arr;

	private int x;

	private int w;

	private long timeRemove = -1L;

	public MsgInfo(string message)
	{
		this.message = message;
		arr = MFont.arialFontW.splitFontBStrInLine(message, Canvas.w - 8);
		w = MFont.arialFontW.getWidth(arr[0]);
		x = Canvas.w + w / 2;
	}

	public void paint(MyGraphics g)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			MFont.arialFontW.drawString(g, arr[i], x, i * 13, 2);
		}
	}

	public void update()
	{
		if (x != Canvas.w / 2)
		{
			if (Canvas.w / 2 - x >> 1 == 0)
			{
				x = Canvas.w / 2;
			}
			else
			{
				x += Canvas.w / 2 - x >> 1;
			}
		}
		if (x == Canvas.w / 2)
		{
			if (timeRemove == -1)
			{
				timeRemove = mSystem.getCurrentTimeMillis() / 1000 + 6;
			}
			if (timeRemove - mSystem.getCurrentTimeMillis() / 1000 <= 0)
			{
				GameScr.msgWorld.removeElement(this);
			}
		}
	}
}
