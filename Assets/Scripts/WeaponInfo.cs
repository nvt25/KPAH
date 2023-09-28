public class WeaponInfo
{
	public class DirrectInfo
	{
		public sbyte idImg;

		public sbyte dx;

		public sbyte dy;

		public sbyte iFlip;
	}

	public Image img;

	public sbyte[] x0;

	public sbyte[] y0;

	public sbyte[] w0;

	public sbyte[] h0;

	public sbyte[] id;

	public DirrectInfo[] dirInfo = new DirrectInfo[4];

	public sbyte getID(int idI)
	{
		for (sbyte b = 0; b < id.Length; b = (sbyte)(b + 1))
		{
			if (id[b] == idI)
			{
				return b;
			}
		}
		return -1;
	}
}
