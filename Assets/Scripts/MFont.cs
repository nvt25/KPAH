using System;
using System.Collections;
using UnityEngine;

public class MFont
{
	public static int LEFT = 0;

	public static int RIGHT = 1;

	public static int CENTER = 2;

	public static int RED = 0;

	public static int YELLOW = 1;

	public static int GREEN = 2;

	public static int FATAL = 3;

	public static int MISS = 4;

	public static int ORANGE = 5;

	public static int ADDMONEY = 6;

	public static int MISS_ME = 7;

	public static int FATAL_ME = 8;

	private int space;

	private Image imgFont;

	private string strFont;

	private int[][] fImages;

	public static MFont normalFontColor;

	public static MFont borderFont;

	public static MFont bigFont;

	public static MFont blackFont;

	public static MFont arialFont;

	public static MFont smallFontYellow;

	public static MFont smallFont;

	public static MFont arialFontW;

	public static MFont[] smallFontColor = new MFont[5];

	public static MFont[] normalFont = new MFont[6];

	public Font myFont;

	private int height;

	private int wO;

	public Color color1 = Color.white;

	public Color color2 = Color.gray;

	public sbyte id;

	public int fstyle;

	public string st1000 = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ";

	public string st2000 = "\u00b8µ¶·¹\u00a8¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ®\u00b8µ¶·¹¡¾»¼½Æ¢ÊÇÈÉËÐÌÎÏÑ£ÕÒÓÔÖÝ×ØÜÞãßáâä¤èåæçé¥íêëìîóïñòô¦øõö÷ùýúûüþ§";

	private int typeBitMap;

	private string charList;

	public sbyte[] charWidth;

	private int charHeight;

	private int charSpace;

	private static Color[] Color1 = new Color[18]
	{
		Color.white,
		Color.green,
		Color.red,
		setColor(1573115),
		new Color(0.5f, 0f, 0.5f),
		Color.white,
		Color.white,
		Color.yellow,
		Color.green,
		setColor(1573115),
		Color.red,
		Color.white,
		Color.white,
		Color.black,
		Color.black,
		Color.yellow,
		new Color(0.6523438f, 0.9960938f, 127f / 128f),
		Color.white
	};

	public MFont(string charList, sbyte[] charWidth, int charHeight, string fontFile, int type, int charSpace)
	{
		typeBitMap = 1;
		this.charSpace = charSpace;
		this.charList = charList;
		this.charWidth = charWidth;
		this.charHeight = charHeight;
		try
		{
			sbyte[] header = FilePack.instance.loadFile(fontFile + type + "_h");
			sbyte[] data = FilePack.instance.loadFile(fontFile + "_data");
			imgFont = Res.createImgByHeader(header, data);
		}
		catch (Exception)
		{
		}
	}

	public MFont(sbyte id)
	{
		typeBitMap = 0;
		string path = "normalFont0";
		if ((id >= 0 && id <= 5) || id == 13 || id == 14 || id == 17 || id == 11 || id == 100)
		{
			path = "normalFont0";
		}
		else if ((id >= 6 && id <= 10) || id == 16)
		{
			path = "normalFont1";
		}
		else if (id == 12)
		{
			path = "normalFont2";
		}
		this.id = id;
		myFont = (Font)Resources.Load(path);
		color1 = setColorFont(id);
		color2 = setColorFont(id);
		wO = getWidthExactOf("o");
	}

	public static void init()
	{
		FilePack.init(FilePack.font);
		normalFont[0] = new MFont(0);
		normalFont[1] = new MFont(1);
		normalFont[2] = new MFont(2);
		normalFont[3] = new MFont(3);
		normalFont[4] = new MFont(4);
		normalFont[5] = new MFont(100);
		borderFont = new MFont(5);
		smallFontColor[0] = new MFont(6);
		smallFontColor[1] = new MFont(7);
		smallFontColor[2] = new MFont(8);
		smallFontColor[3] = new MFont(9);
		smallFontColor[4] = new MFont(10);
		normalFontColor = new MFont(11);
		bigFont = new MFont(12);
		blackFont = new MFont(13);
		arialFont = new MFont(14);
		smallFontYellow = new MFont("0123456789-+abcdefghijklmnopqrstuvwxyz ", new sbyte[39]
		{
			10,
			6,
			10,
			10,
			10,
			10,
			11,
			10,
			10,
			9,
			8,
			8,
			11,
			10,
			10,
			10,
			9,
			9,
			10,
			10,
			6,
			8,
			11,
			9,
			11,
			11,
			11,
			10,
			11,
			10,
			10,
			11,
			11,
			11,
			11,
			11,
			11,
			10,
			5
		}, 11, "small_f", 0, 0);
		smallFont = new MFont(16);
		arialFontW = new MFont(17);
		FilePack.reset();
	}

	public static Color setColor(int rgb)
	{
		int num = rgb & 0xFF;
		int num2 = (rgb >> 8) & 0xFF;
		int num3 = (rgb >> 16) & 0xFF;
		float b = (float)num / 256f;
		float g = (float)num2 / 256f;
		float r = (float)num3 / 256f;
		return new Color(r, g, b);
	}

	public void setTypePaint(MyGraphics g, string st, int x, int y, int align, sbyte idFont)
	{
		switch (id)
		{
		case 0:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color.white;
			color2 = Color.white;
			_drawString(g, st, x, y, align);
			break;
		case 1:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 2:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 3:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 4:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 5:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 6:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color.white;
			color2 = Color.white;
			_drawString(g, st, x, y, align);
			break;
		case 7:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color.yellow;
			color2 = Color.yellow;
			_drawString(g, st, x, y, align);
			break;
		case 8:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color.green;
			color2 = Color.green;
			_drawString(g, st, x, y, align);
			break;
		case 9:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color.blue;
			color2 = Color.blue;
			_drawString(g, st, x, y, align);
			break;
		case 10:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color.red;
			color2 = Color.red;
			_drawString(g, st, x, y, align);
			break;
		case 11:
		case 12:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 13:
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 14:
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 15:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = setColor(16767780);
			color2 = setColor(16767780);
			_drawString(g, st, x, y, align);
			break;
		case 16:
			color1 = Color.black;
			color2 = Color.black;
			_drawString(g, st, x, y + 1, align);
			color1 = setColor(16711591);
			color2 = setColor(16711591);
			_drawString(g, st, x, y, align);
			break;
		case 17:
			color1 = Color1[id];
			color2 = Color1[id];
			_drawString(g, st, x, y, align);
			break;
		case 100:
			color1 = setColor(16770348);
			color1 = setColor(16770348);
			_drawString(g, st, x, y, align);
			break;
		}
	}

	public Color setColorFont(sbyte id)
	{
		switch (id)
		{
		case 0:
			return Color.white;
		case 1:
			return Color.red;
		case 2:
			return Color.blue;
		case 3:
			return setColor(13500671);
		case 4:
			return setColor(16755200);
		case 5:
			return Color.green;
		case 6:
			return setColor(16776960);
		case 7:
			return Color.white;
		case 8:
			return Color.black;
		case 9:
			return setColor(65535);
		case 10:
			return Color.white;
		case 11:
			return Color.yellow;
		case 12:
			return setColor(5592405);
		case 13:
			return Color.red;
		case 14:
			return setColor(33023);
		case 16:
			return setColor(15655191);
		case 17:
			return setColor(0);
		case 18:
			return setColor(0);
		case 19:
			return setColor(0);
		case 20:
			return setColor(0);
		case 21:
			return setColor(0);
		case 22:
			return setColor(5592405);
		case 23:
			return setColor(5592405);
		case 24:
			return setColor(5592405);
		case 25:
			return setColor(5592405);
		case 26:
			return setColor(5592405);
		case 100:
			return setColor(16770348);
		default:
			return Color.white;
		}
	}

	public void drawString(MyGraphics g, string st, int x, int y, int align)
	{
		setTypePaint(g, st, x, y, align, 0);
	}

	public void drawString(MyGraphics g, string st, int x, int y, int align, MFont font)
	{
		setTypePaint(g, st, x, y + 1, align, font.id);
		setTypePaint(g, st, x, y, align, 0);
	}

	public mVector splitFontVector(string src, int lineWidth)
	{
		mVector mVector = new mVector();
		string text = string.Empty;
		for (int i = 0; i < src.Length; i++)
		{
			if (src[i] == '\n')
			{
				mVector.addElement(text);
				text = string.Empty;
				continue;
			}
			text += src[i];
			if (getWidth(text) > lineWidth)
			{
				int num = 0;
				num = text.Length - 1;
				while (num >= 0 && text[num] != ' ')
				{
					num--;
				}
				if (num < 0)
				{
					num = text.Length - 1;
				}
				mVector.addElement(text.Substring(0, num));
				i = i - (text.Length - num) + 1;
				text = string.Empty;
			}
			if (i == src.Length - 1 && !text.Trim().Equals(string.Empty))
			{
				mVector.addElement(text);
			}
		}
		return mVector;
	}

	public string splitFirst(string str)
	{
		string text = string.Empty;
		bool flag = false;
		for (int i = 0; i < str.Length; i++)
		{
			if (!flag)
			{
				string text2 = str.Substring(i);
				text = ((!compare(text2, " ")) ? (text + text2) : (text + str[i] + "-"));
				flag = true;
			}
			else if (str[i] == ' ')
			{
				flag = false;
			}
		}
		return text;
	}

	public string[] splitFontArray(string src, int lineWidth)
	{
		mVector mVector = splitFontVector(src, lineWidth);
		string[] array = new string[mVector.size()];
		for (int i = 0; i < mVector.size(); i++)
		{
			array[i] = (string)mVector.elementAt(i);
		}
		return array;
	}

	public bool compare(string strSource, string str)
	{
		for (int i = 0; i < strSource.Length; i++)
		{
			if ((string.Empty + strSource[i]).Equals(str))
			{
				return true;
			}
		}
		return false;
	}

	public int getWidth(string s)
	{
		return getWidthExactOf(s);
	}

	public int getWidthExactOf(string s)
	{
		try
		{
			GUIStyle gUIStyle = new GUIStyle();
			gUIStyle.font = myFont;
			Vector2 vector = gUIStyle.CalcSize(new GUIContent(s));
			return (int)vector.x;
			IL_002d:
			int result;
			return result;
		}
		catch (Exception ex)
		{
			Out.LogError("GET WIDTH OF " + s + " FAIL.\n" + ex.Message + "\n" + ex.StackTrace);
			return getWidthNotExactOf(s);
			IL_007e:
			int result;
			return result;
		}
	}

	public int getWidthNotExactOf(string s)
	{
		return s.Length * wO;
	}

	public int getHeight()
	{
		if (height > 0)
		{
			return height;
		}
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.font = myFont;
		try
		{
			Vector2 vector = gUIStyle.CalcSize(new GUIContent("Adg"));
			height = (int)vector.y + 2;
		}
		catch (Exception ex)
		{
			Out.LogError("FAIL GET HEIGHT " + ex.StackTrace);
			height = 20;
		}
		return height;
	}

	public void paintFontBitMap(MyGraphics g, string st, int x, int y, int align)
	{
		int length = st.Length;
		int num;
		switch (align)
		{
		case 0:
			num = x;
			break;
		case 1:
			num = x - getWidth(st);
			break;
		default:
			num = x - (getWidth(st) >> 1);
			break;
		}
		for (int i = 0; i < length; i++)
		{
			int num2 = charList.IndexOf(st[i]);
			if (num2 == -1)
			{
				num2 = 0;
			}
			if (num2 > -1)
			{
				g.drawRegion(imgFont, 0, num2 * charHeight, imgFont.getWidth(), charHeight, 0, num, y, 20);
			}
			num += charWidth[num2] + charSpace;
		}
	}

	public void _drawString(MyGraphics g, string st, int x0, int y0, int align)
	{
		GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
		gUIStyle.font = myFont;
		float num = 0f;
		float num2 = 0f;
		switch (align)
		{
		case 0:
			num = x0;
			num2 = y0;
			gUIStyle.alignment = TextAnchor.UpperLeft;
			break;
		case 1:
			num = x0 - Canvas.w;
			num2 = y0;
			gUIStyle.alignment = TextAnchor.UpperRight;
			break;
		case 2:
		case 3:
			num = x0 - Canvas.w / 2;
			num2 = y0;
			gUIStyle.alignment = TextAnchor.UpperCenter;
			break;
		}
		gUIStyle.normal.textColor = color1;
		int width = getWidth(st);
		g.drawString(st, (int)num, (int)num2, gUIStyle, width);
	}

	public string[] splitFontBStrInLine(string src, int lineWidth)
	{
		ArrayList arrayList = splitStrInLineA(src, lineWidth);
		string[] array = new string[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[i] = (string)arrayList[i];
		}
		return array;
	}

	public ArrayList splitStrInLineA(string src, int lineWidth)
	{
		ArrayList arrayList = new ArrayList();
		int i = 0;
		int num = 0;
		int length = src.Length;
		if (length < 5)
		{
			arrayList.Add(src);
			return arrayList;
		}
		string text = string.Empty;
		try
		{
			while (true)
			{
				if (getWidth(text) < lineWidth)
				{
					text += src[num];
					num++;
					if (src[num] != '\n')
					{
						if (num < length - 1)
						{
							continue;
						}
						num = length - 1;
					}
				}
				if (num != length - 1 && src[num + 1] != ' ')
				{
					int num2 = num;
					while (src[num + 1] != '\n' && (src[num + 1] != ' ' || src[num] == ' ') && num != i)
					{
						num--;
					}
					if (num == i)
					{
						num = num2;
					}
				}
				string text2 = src.Substring(i, num + 1 - i);
				if (text2[0] == '\n')
				{
					text2 = text2.Substring(1, text2.Length - 1);
				}
				if (text2[text2.Length - 1] == '\n')
				{
					text2 = text2.Substring(0, text2.Length - 1);
				}
				arrayList.Add(text2);
				if (num == length - 1)
				{
					return arrayList;
				}
				for (i = num + 1; i != length - 1 && src[i] == ' '; i++)
				{
				}
				if (i == length - 1)
				{
					break;
				}
				num = i;
				text = string.Empty;
			}
			return arrayList;
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("EXCEPTION WHEN REAL SPLIT " + src + "\nend=" + num + "\n" + ex.Message + "\n" + ex.StackTrace);
			arrayList.Add(src);
			return arrayList;
		}
	}

	public static string[] splitStringSv(string _text, string _searchStr)
	{
		int num = 0;
		int startIndex = 0;
		int length = _searchStr.Length;
		int num2 = _text.IndexOf(_searchStr, startIndex);
		while (num2 != -1)
		{
			startIndex = num2 + length;
			num2 = _text.IndexOf(_searchStr, startIndex);
			num++;
		}
		string[] array = new string[num + 1];
		int num3 = _text.IndexOf(_searchStr);
		int num4 = 0;
		int num5 = 0;
		while (num3 != -1)
		{
			array[num5] = _text.Substring(num4, num3 - num4);
			num4 = num3 + length;
			num3 = _text.IndexOf(_searchStr, num4);
			num5++;
		}
		array[num5] = _text.Substring(num4, _text.Length - num4);
		return array;
	}

	public void reloadImage()
	{
	}

	public void freeImage()
	{
	}
}
