public class AttackResult
{
	public int mpLost;

	public int dam;

	public sbyte effect;

	public int buffEffect = -1;

	public static readonly sbyte EFF_NORMAL = 0;

	public static readonly sbyte EFF_MISS = 1;

	public static readonly sbyte EFF_CRITICAL = 2;

	public static readonly sbyte EFF_XUYEN_GIAP = 3;

	public static readonly sbyte EFF_BAO_KICH = 4;

	public static readonly string[] EFF_NAME = new string[5]
	{
		string.Empty,
		"miss",
		"CHI MANG",
		"XUYEN GIAP",
		"BAOKICH"
	};

	public AttackResult(int dam, sbyte effect)
	{
		this.dam = dam;
		this.effect = effect;
	}

	public AttackResult()
	{
	}

	public static void startEff(sbyte eff, int x, int y)
	{
		if (eff > 0)
		{
			Canvas.gameScr.startFlyText(EFF_NAME[eff], 0, x, y, 1, -2);
		}
	}
}
