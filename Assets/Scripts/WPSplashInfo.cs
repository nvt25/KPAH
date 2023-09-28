public class WPSplashInfo
{
	public int[][] P0_X = new int[4][];

	public int[][] P0_Y = new int[4][];

	public int[][] PF_X = new int[4][];

	public int[][] PF_Y = new int[4][];

	public int[][] PF_W = new int[4][];

	public int[][] PF_H = new int[4][];

	public Image image;

	public WPSplashInfo()
	{
		for (int i = 0; i < 4; i++)
		{
			P0_X[i] = new int[8];
			P0_Y[i] = new int[8];
			PF_X[i] = new int[8];
			PF_Y[i] = new int[8];
			PF_W[i] = new int[8];
			PF_H[i] = new int[8];
		}
	}
}
