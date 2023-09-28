public class Potion
{
	public int number;

	public int numTrade;

	public short id;

	public short index;

	public long delay;

	public bool isTrade;

	public string name;

	public string name2;

	public void paint(MyGraphics g, Image img, int x, int y, int align)
	{
		g.drawImage(img, x, y, align);
	}
}
