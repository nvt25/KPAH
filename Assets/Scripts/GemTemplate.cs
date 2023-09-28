public class GemTemplate
{
	public short id;

	public short rID;

	public int number;

	public int price;

	public bool ilock;

	public GemTemplate()
	{
	}

	public GemTemplate(int id)
	{
		this.id = (sbyte)id;
	}

	public static GemTemplate getGemByID(short id)
	{
		for (int i = 0; i < MainChar.gemItem.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(i);
			if (gemTemplate.id == id)
			{
				return gemTemplate;
			}
		}
		return null;
	}

	public static GemTemplate getGemByRealID(short rID)
	{
		for (int i = 0; i < MainChar.gemItem.size(); i++)
		{
			GemTemplate gemTemplate = (GemTemplate)MainChar.gemItem.elementAt(i);
			if (gemTemplate.rID == rID)
			{
				return gemTemplate;
			}
		}
		return null;
	}

	public static GemTemplate copyData(GemTemplate from, GemTemplate to)
	{
		to.id = from.id;
		to.number = from.number;
		to.price = from.price;
		to.rID = from.rID;
		return to;
	}
}
