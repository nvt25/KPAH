public class NameAttributeItem
{
	public sbyte ispercent;

	public sbyte colorPaint;

	public string name = string.Empty;

	public short id;

	public NameAttributeItem(short id, string name, sbyte ispercent, sbyte colorPaint)
	{
		this.id = id;
		this.name = name;
		this.colorPaint = colorPaint;
		this.ispercent = ispercent;
	}

	public sbyte getColorPaint(bool kick)
	{
		sbyte b = colorPaint;
		if (b == 1 && kick)
		{
			b = 2;
		}
		return b;
	}
}
