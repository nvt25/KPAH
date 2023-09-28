public class CharClassInfo
{
	public sbyte classID;

	public string name;

	public string sex;

	public string weapon;

	public string area;

	public string element;

	public short bodyID;

	public short legID;

	public short headID;

	public short weaponType;

	public short weaponImageID;

	public CharClassInfo(sbyte classID, string name, string sex, string weapon, string area, string element, int weaponType, int weaponImageID)
	{
		this.classID = classID;
		this.name = name;
		this.sex = sex;
		this.weapon = weapon;
		this.area = area;
		this.element = element;
		if (sex.Equals("Nam"))
		{
			bodyID = 2;
			legID = 2;
			headID = 2;
		}
		else
		{
			bodyID = 3;
			legID = 3;
			headID = 3;
		}
		this.weaponType = (short)weaponType;
		this.weaponImageID = (short)weaponImageID;
	}
}
