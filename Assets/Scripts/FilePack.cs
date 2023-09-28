using System;
using System.IO;
using UnityEngine;

public class FilePack
{
	public static FilePack instance;

	public string[] fname;

	private int[] fpos;

	private int[] flen;

	private sbyte[] fullData;

	private int nFile;

	private int hSize;

	private string name;

	private static sbyte[] code = new sbyte[13]
	{
		78,
		103,
		117,
		121,
		101,
		110,
		86,
		97,
		110,
		77,
		105,
		110,
		104
	};

	private int codeLen = code.Length;

	public static string[] charAvatar = new string[5]
	{
		Main.res + "/c/leg/",
		Main.res + "/c/body/",
		Main.res + "/c/head/",
		Main.res + "/c/hat/",
		Main.res + "/c/coat/"
	};

	public static string cBody = Main.res + "/body";

	public static string cHat = Main.res + "/hat";

	public static string cLeg = Main.res + "/leg";

	public static string cHead = Main.res + "/head";

	public static string main = Main.res + "/main";

	public static string font = Main.res + "/font";

	public static string npc = Main.res + "/npc";

	public static string eff = Main.res + "/eff";

	public static string tree = "/tree/";

	public static string type = "/type.sh";

	public static string wps = Main.res + "/wpsplash/";

	public static string arrow = Main.res + "/arrow";

	public static string effPublic = Main.res + "/skillpublic";

	public static string ground = Main.res + "/g";

	public static string nation = Main.res + "/nation";

	public static string box = Main.res + "/box";

	private DataInputStream file;

	public FilePack()
	{
	}

	public FilePack(string name, sbyte[] array)
	{
		int num = 0;
		int num2 = 0;
		this.name = name;
		hSize = 0;
		if (array == null)
		{
			open();
		}
		else
		{
			openbyArray(array);
		}
		if (file == null)
		{
			instance = null;
			return;
		}
		try
		{
			nFile = encode(file.readUnsignedByte());
			hSize++;
			fname = new string[nFile];
			fpos = new int[nFile];
			flen = new int[nFile];
			for (int i = 0; i < nFile; i++)
			{
				int num3 = encode(file.readByte());
				sbyte[] data = new sbyte[num3];
				file.read(ref data);
				encode(data);
				fname[i] = new string(mSystem.ToCharArray(data));
				fpos[i] = num;
				flen[i] = encode(file.readUnsignedShort());
				num += flen[i];
				num2 += flen[i];
				hSize += num3 + 3;
			}
			fullData = new sbyte[num2];
			file.readFully(ref fullData);
			encode(fullData);
		}
		catch (IOException)
		{
		}
		close();
	}

	public FilePack(string name)
	{
		int num = 0;
		int num2 = 0;
		this.name = name;
		hSize = 0;
		open();
		try
		{
			nFile = encode(file.readUnsignedByte());
			hSize++;
			fname = new string[nFile];
			fpos = new int[nFile];
			flen = new int[nFile];
			for (int i = 0; i < nFile; i++)
			{
				int num3 = encode(file.readByte());
				sbyte[] data = new sbyte[num3];
				file.read(ref data);
				encode(data);
				fname[i] = new string(mSystem.ToCharArray(data));
				fpos[i] = num;
				flen[i] = encode(file.readUnsignedShort());
				num += flen[i];
				num2 += flen[i];
				hSize += num3 + 3;
			}
			fullData = new sbyte[num2];
			file.readFully(ref fullData);
			encode(fullData);
		}
		catch (Exception)
		{
		}
		close();
	}

	public static void reset()
	{
		if (instance != null)
		{
			instance.close();
		}
		instance = null;
	}

	public static Image getImg(string path)
	{
		return instance.loadImage(path + ".png");
	}

	public static void init(string path)
	{
		instance = new FilePack(path);
	}

	public static void initByArray(sbyte[] array)
	{
		instance = new FilePack(string.Empty, array);
	}

	private int encode(int i)
	{
		return i;
	}

	private void encode(sbyte[] bytes)
	{
		int num = bytes.Length;
		for (int i = 0; i < num; i++)
		{
			bytes[i] = (sbyte)(bytes[i] ^ code[i % codeLen]);
		}
	}

	private void open()
	{
		file = new DataInputStream(name);
	}

	private void openbyArray(sbyte[] array)
	{
		file = new DataInputStream(array);
	}

	public void close()
	{
		try
		{
			if (file != null)
			{
				file.close();
			}
		}
		catch (IOException)
		{
		}
	}

	public sbyte[] loadFile(string fileName)
	{
		try
		{
			for (int i = 0; i < nFile; i++)
			{
				if (fname[i].CompareTo(fileName) == 0)
				{
					sbyte[] array = new sbyte[flen[i]];
					Array.Copy(fullData, fpos[i], array, 0, flen[i]);
					return array;
				}
			}
		}
		catch (Exception)
		{
			UnityEngine.Debug.Log("File '" + fileName + "' not found!");
		}
		return null;
	}

	public Image loadImage(string fileName)
	{
		for (int i = 0; i < nFile; i++)
		{
			if (fname[i].CompareTo(fileName) == 0)
			{
				return Image.createImage(fullData, fpos[i], flen[i]);
			}
		}
		return null;
	}

	public sbyte[] loadData(string name)
	{
		for (int i = 0; i < nFile; i++)
		{
			if (fname[i].CompareTo(name) == 0)
			{
				sbyte[] array = new sbyte[flen[i]];
				Array.Copy(fullData, fpos[i], array, 0, flen[i]);
				return array;
			}
		}
		return null;
	}

	public sbyte[] getBinaryFile(string name)
	{
		for (int i = 0; i < nFile; i++)
		{
			if (fname[i].CompareTo(name) == 0)
			{
				sbyte[] array = new sbyte[flen[i]];
				Array.Copy(fullData, fpos[i], array, 0, flen[i]);
				return array;
			}
		}
		UnityEngine.Debug.Log("File '" + name + "' not found!");
		return null;
	}
}
