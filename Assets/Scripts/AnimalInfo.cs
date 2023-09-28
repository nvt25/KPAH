public class AnimalInfo
{
	public string info = string.Empty;

	public string name = string.Empty;

	public sbyte idImg;

	public sbyte level;

	public sbyte typeAnimal;

	public sbyte typePet = -1;

	public short id;

	public static Image imgAnimal;

	private static bool isGetImg;

	public long timeStart;

	public int totalTimeCon;

	public sbyte idPaint;

	public void paint(MyGraphics g, int x, int y)
	{
		GameData.paintIcon(g, (short)(idPaint + 7500), x, y);
	}

	public static void getImg()
	{
		if (!isGetImg)
		{
			GameService.gI().doGetImage(4, 0);
		}
		isGetImg = true;
	}
}
