public class PartyInfo
{
	public int id = -1;

	public string name = string.Empty;

	public int lv;

	public int clazz;

	public PartyInfo(int id, string name, int lv, int clazz)
	{
		this.id = id;
		this.name = name;
		this.lv = lv;
		this.clazz = clazz;
	}
}
