public class PartFrame
{
	public short dx;

	public short dy;

	public sbyte idSmallImg;

	public sbyte flip;

	public sbyte onTop;

	public sbyte[] data;

	public short id;

	public PartFrame(short dx, short dy, sbyte idSmall)
	{
		idSmallImg = idSmall;
		this.dx = dx;
		this.dy = dy;
	}

	public PartFrame(int id, sbyte[] data)
	{
		this.id = (short)id;
		this.data = data;
	}
}
