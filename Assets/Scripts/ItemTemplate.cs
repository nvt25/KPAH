public class ItemTemplate
{
	public string name;

	public static string[] nameItem = new string[20]
	{
		"áo",
		"Quần",
		"Nón",
		"Kiếm",
		"Đao",
		"Bút",
		"Búa",
		"Cung",
		"Nhẫn",
		"Dây chuyền",
		"Giày",
		"Găng tay",
		"Ngọc bội",
		"Cuốc",
		"Giáp linh thú",
		"Hộ uyển",
		"Nón linh thú",
		"Bàn đạp",
		"Yên cương",
		"Phi phong"
	};

	public short type;

	public short style;

	public short index;

	public short he;

	public short gender;

	public short level;

	public short durable;

	public short idIcon;

	public short ndayLoan;

	public int price;

	public short[] attb = new short[10];

	public sbyte clazz;

	public short id;

	public sbyte plus;

	public sbyte colorItem;

	public static MyHashTable ALL_NAME_ATTRIBUTE_ITEM = new MyHashTable();

	public mVector allAttribute = new mVector();
}
