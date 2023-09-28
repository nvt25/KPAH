public class GemTemp
{
	public const sbyte TYPE_IMBUE = 0;

	public const sbyte TYPE_KHAM = 1;

	public const sbyte TYPE_DUC_LO = 2;

	public const sbyte TYPE_CREATE_ITEM = 3;

	public const sbyte TYPE_TU_BINH = 4;

	public const sbyte TYPE_HOP_ITEM_ANIMAL = 5;

	public const sbyte TYPE_ADD_NEW_ATTRIBUTE = 6;

	public static sbyte TYPE_LOCK_ANIMAL = 7;

	public static sbyte TYPE_LOCK_ITEM = 8;

	public static sbyte TYPE_BOT = 9;

	public static sbyte TYPE_DA_TIEN_GIAI = 10;

	public sbyte shopType;

	public sbyte type;

	public sbyte typeEp;

	public string name = string.Empty;

	public string decript = string.Empty;

	public short idImage;

	public short value;

	public short number;

	public short id;

	public sbyte typeMoney;

	public bool isSell;

	public int price;

	public sbyte isEff = -1;

	public int count = Res.rnd(68);

	public static int[] color = new int[3]
	{
		7667443,
		3334656,
		16705024
	};
}
