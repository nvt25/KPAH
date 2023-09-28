public class InfoAttributeItem
{
	private short id;

	private short value;

	public InfoAttributeItem(short id, short value)
	{
		this.id = id;
		this.value = value;
	}

	public sbyte getColorPaint(bool kick)
	{
		return ((NameAttributeItem)ItemTemplate.ALL_NAME_ATTRIBUTE_ITEM.get(id + string.Empty)).getColorPaint(kick);
	}

	public string getName(int clazz)
	{
		string str = ((NameAttributeItem)ItemTemplate.ALL_NAME_ATTRIBUTE_ITEM.get(id + string.Empty)).name;
		if (id >= 43 && id <= 57)
		{
			str = SkillManager.SKILL_NAME[clazz][id - 43];
		}
		return str + ": ";
	}

	public bool isPercent()
	{
		sbyte ispercent = ((NameAttributeItem)ItemTemplate.ALL_NAME_ATTRIBUTE_ITEM.get(id + string.Empty)).ispercent;
		return ispercent == 1 || ispercent == 2;
	}

	public string getValue()
	{
		string result = value + string.Empty;
		if (((NameAttributeItem)ItemTemplate.ALL_NAME_ATTRIBUTE_ITEM.get(id + string.Empty)).ispercent == 2)
		{
			result = value / 10 + "." + value % 10;
		}
		return result;
	}

	public int getValueAtt()
	{
		return value;
	}

	public short getID()
	{
		return id;
	}
}
