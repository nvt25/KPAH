using System;

public class Util
{
	private static int[] sin1 = new int[91]
	{
		0,
		18,
		36,
		54,
		71,
		89,
		107,
		125,
		143,
		160,
		178,
		195,
		213,
		230,
		248,
		265,
		282,
		299,
		316,
		333,
		350,
		367,
		384,
		400,
		416,
		433,
		449,
		465,
		481,
		496,
		512,
		527,
		543,
		558,
		573,
		587,
		602,
		616,
		630,
		644,
		658,
		672,
		685,
		698,
		711,
		724,
		737,
		749,
		761,
		773,
		784,
		796,
		807,
		818,
		828,
		839,
		849,
		859,
		868,
		878,
		887,
		896,
		904,
		912,
		920,
		928,
		935,
		943,
		949,
		956,
		962,
		968,
		974,
		979,
		984,
		989,
		994,
		998,
		1002,
		1005,
		1008,
		1011,
		1014,
		1016,
		1018,
		1020,
		1022,
		1023,
		1023,
		1024,
		1024
	};

	public static int[] cos1;

	public static int[] tan1;

	private static string[][] st = new string[2][]
	{
		new string[7]
		{
			"áàảãạăắằẳẵặâấầẩẫậ",
			"éèẻẽẹêếềểễệ",
			"íìỉĩị",
			"óòỏõọôốồổỗộ",
			"ơớờởỡợ",
			"úùủũụưứừửữự",
			"ýỳỷỹỵ"
		},
		new string[7]
		{
			"a",
			"e",
			"i",
			"o",
			"o",
			"u",
			"y"
		}
	};

	public static void load()
	{
		cos1 = new int[91];
		tan1 = new int[91];
		for (int i = 0; i <= 90; i++)
		{
			cos1[i] = sin1[90 - i];
			if (cos1[i] == 0)
			{
				tan1[i] = int.MaxValue;
			}
			else
			{
				tan1[i] = (sin1[i] << 10) / cos1[i];
			}
		}
	}

	public static int Sin(int a)
	{
		if (a >= 0 && a < 90)
		{
			return sin1[a];
		}
		if (a >= 90 && a < 180)
		{
			return sin1[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return -sin1[a - 180];
		}
		return -sin1[360 - a];
	}

	public static int Cos(int a)
	{
		if (a >= 0 && a < 90)
		{
			return cos1[a];
		}
		if (a >= 90 && a < 180)
		{
			return -cos1[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return -cos1[a - 180];
		}
		return cos1[360 - a];
	}

	public static int isTan(int a)
	{
		if (a >= 0 && a < 90)
		{
			return tan1[a];
		}
		if (a >= 90 && a < 180)
		{
			return -tan1[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return tan1[a - 180];
		}
		return -tan1[360 - a];
	}

	public static int atan(int a)
	{
		for (int i = 0; i <= 90; i++)
		{
			if (tan1[i] >= a)
			{
				return i;
			}
		}
		return 0;
	}

	public static int angle(int dx, int dy)
	{
		int num;
		if (dx != 0)
		{
			int a = Math.abs((dy << 10) / dx);
			num = atan(a);
			if (dy >= 0 && dx < 0)
			{
				num = 180 - num;
			}
			if (dy < 0 && dx < 0)
			{
				num = 180 + num;
			}
			if (dy < 0 && dx >= 0)
			{
				num = 360 - num;
			}
		}
		else
		{
			num = ((dy <= 0) ? 270 : 90);
		}
		return num;
	}

	public static int fixangle(int angle)
	{
		if (angle >= 360)
		{
			angle -= 360;
		}
		if (angle < 0)
		{
			angle += 360;
		}
		return angle;
	}

	public static int subangle(int a1, int a2)
	{
		int num = a2 - a1;
		if (num < -180)
		{
			return num + 360;
		}
		if (num > 180)
		{
			return num - 360;
		}
		return num;
	}

	public static int distance(int x1, int y1, int x2, int y2)
	{
		return sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
	}

	public static int sqrt(int a)
	{
		if (a <= 0)
		{
			return 0;
		}
		int num = (a + 1) / 2;
		int num2;
		do
		{
			num2 = num;
			num = num / 2 + a / (2 * num);
		}
		while (Math.abs(num2 - num) > 1);
		return num;
	}

	public static bool inDataRange(Actor p1, Actor p2)
	{
		return Math.abs(p1.x - p2.x) < Canvas.w / 2 + 100 && Math.abs(p1.y - p2.y) < Canvas.w / 2 + 100;
	}

	public static void quickSort(mVector actors)
	{
		recQuickSort(actors, 0, actors.size() - 1);
	}

	private static void recQuickSort(mVector actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				int y = ((Actor)actors.elementAt(right)).getY();
				int num = partitionIt(actors, left, right, y);
				recQuickSort(actors, left, num - 1);
				recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
		}
	}

	private static int partitionIt(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			while (true)
			{
				if (((Actor)actors.elementAt(++num)).getY() >= pivot)
				{
					while (num2 > 0 && ((Actor)actors.elementAt(--num2)).getY() > pivot)
					{
					}
					if (num >= num2)
					{
						break;
					}
					swap(actors, num, num2);
				}
			}
			swap(actors, num, right);
			return num;
		}
		catch (Exception)
		{
			Out.println("LOI PAINT partitionIt TRONG UTIL");
			return num;
		}
	}

	private static void swap(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((Actor)actors.elementAt(dex2)).getY() != ((Actor)actors.elementAt(dex1)).getY())
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	public static int abs(int x)
	{
		return (x <= 0) ? (-x) : x;
	}

	public static short findDirection(Actor from, Actor lookTo)
	{
		if (from == null || lookTo == null)
		{
			return 0;
		}
		if (abs(from.x - lookTo.x) < abs(from.y - lookTo.y))
		{
			if (lookTo.y > from.y)
			{
				return 0;
			}
			return 1;
		}
		if (lookTo.x < from.x)
		{
			return 2;
		}
		return 3;
	}

	private static int pos(char a)
	{
		for (int i = 0; i < st[0].Length; i++)
		{
			if (st[0][i].IndexOf(a + string.Empty) != -1)
			{
				return i;
			}
		}
		return -1;
	}

	public static string converUTF2NoUTF(string st)
	{
		string text = string.Empty;
		foreach (char c in st)
		{
			int num = pos(c);
			text = ((num == -1) ? (text + c) : (text + Util.st[1][num]));
		}
		return text;
	}

	public static string[] split(string original, string separator)
	{
		mVector mVector = new mVector();
		for (int num = original.IndexOf(separator); num >= 0; num = original.IndexOf(separator))
		{
			mVector.addElement(original.Substring(0, num));
			original = original.Substring(num + separator.Length);
		}
		mVector.addElement(original);
		string[] array = new string[mVector.size()];
		if (mVector.size() > 0)
		{
			for (int i = 0; i < mVector.size(); i++)
			{
				array[i] = (string)mVector.elementAt(i);
			}
		}
		return array;
	}

	public static int getDistance(int x, int y, int x2, int y2)
	{
		return Res.getRange(x, x2, y, y2);
	}
}
