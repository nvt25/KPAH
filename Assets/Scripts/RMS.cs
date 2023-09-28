using System;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

public class RMS
{
	private const int INTERVAL = 5;

	private const int MAXTIME = 500;

	public static int status;

	public static sbyte[] data;

	public static string filename;

	public static void saveRMS(string filename, sbyte[] data)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__saveRMS(filename, data);
		}
		else
		{
			_saveRMS(filename, data);
		}
	}

	public static sbyte[] loadRMS(string filename)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			return __loadRMS(filename);
		}
		return _loadRMS(filename);
	}

	private static void _saveRMS(string filename, sbyte[] data)
	{
		if (status != 0)
		{
			UnityEngine.Debug.LogError("Cannot save RMS " + filename + " because current is saving " + RMS.filename);
			return;
		}
		RMS.filename = filename;
		RMS.data = data;
		status = 2;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			UnityEngine.Debug.LogError("TOO LONG TO SAVE RMS " + filename);
		}
	}

	public static void saveRMSInt(string file, int x)
	{
		try
		{
			saveRMS(file, new sbyte[1]
			{
				(sbyte)x
			});
		}
		catch (Exception)
		{
		}
	}

	public static string loadRMSString(string filename)
	{
		sbyte[] array = loadRMS(filename);
		if (array == null)
		{
			return null;
		}
		return Encoding.UTF8.GetString(convertSbyteToByte(array));
	}

	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if (var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)(var[i] + 256);
			}
		}
		return array;
	}

	private static sbyte[] _loadRMS(string filename)
	{
		if (status != 0)
		{
			UnityEngine.Debug.LogError("Cannot load RMS " + filename + " because current is loading " + RMS.filename);
			return null;
		}
		RMS.filename = filename;
		data = null;
		status = 3;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			UnityEngine.Debug.LogError("TOO LONG TO LOAD RMS " + filename);
		}
		return data;
	}

	public static void update()
	{
		if (status == 2)
		{
			status = 1;
			__saveRMS(filename, data);
			status = 0;
		}
		else if (status == 3)
		{
			status = 1;
			data = __loadRMS(filename);
			status = 0;
		}
	}

	public static void saveRMSStringIp(string[] ip, short[] port, string[] name)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte((sbyte)ip.Length);
			for (int i = 0; i < ip.Length; i++)
			{
				dataOutputStream.writeUTF(ip[i]);
				dataOutputStream.writeShort(port[i]);
				dataOutputStream.writeUTF(name[i]);
			}
			saveRMS("nqshIP", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public static void saveNumberSuport(string number)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(number);
			sbyte[] array = dataOutputStream.toByteArray();
			saveRMS("numbersupport", array);
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public static void saveQuickSlot()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(Canvas.gameScr.mainChar.name);
			for (int i = 0; i < MainChar.quickSlot.Length; i++)
			{
				for (int j = 0; j < MainChar.quickSlot[i].Length; j++)
				{
					QuickSlot quickSlot = MainChar.quickSlot[i][j];
					dataOutputStream.writeByte((sbyte)quickSlot.quickslotType);
					if (quickSlot.quickslotType == QuickSlot.TYPE_POTION)
					{
						dataOutputStream.writeByte((sbyte)quickSlot.getPotionType());
					}
					else
					{
						dataOutputStream.writeByte(quickSlot.getSkillType());
					}
					dataOutputStream.writeBoolean(quickSlot.isBuff);
					dataOutputStream.writeByte((sbyte)GameScr.indexTabSlot);
				}
			}
			sbyte[] array = dataOutputStream.toByteArray();
			saveRMS("nqshQuickSlot", array);
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	public static void loadQuickSlot()
	{
		sbyte[] array = loadRMS("nqshQuickSlot");
		if (array != null)
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			try
			{
				string text = dataInputStream.readUTF();
				if (text.Equals(Canvas.gameScr.mainChar.name))
				{
					for (int i = 0; i < MainChar.quickSlot.Length; i++)
					{
						for (int j = 0; j < MainChar.quickSlot[i].Length; j++)
						{
							QuickSlot quickSlot = MainChar.quickSlot[i][j];
							quickSlot.quickslotType = dataInputStream.readUnsignedByte();
							sbyte b = dataInputStream.readByte();
							quickSlot.isBuff = dataInputStream.readBoolean();
							if (quickSlot.quickslotType == QuickSlot.TYPE_POTION)
							{
								quickSlot.setIsPotion(b);
							}
							else
							{
								quickSlot.setIsSkill(b, Canvas.gameScr.mainChar.clazz, quickSlot.isBuff);
							}
							GameScr.indexTabSlot = dataInputStream.readByte();
						}
					}
					dataInputStream.close();
				}
			}
			catch (IOException)
			{
				Out.println("ERROR LOAD QUICKSLOT");
			}
		}
	}

	private static void __saveRMS(string filename, sbyte[] data)
	{
		string value = ByteArrayToString(ArrayCast.cast(data));
		PlayerPrefs.SetString(filename, value);
	}

	private static sbyte[] __loadRMS(string filename)
	{
		string @string = PlayerPrefs.GetString(filename);
		byte[] array;
		try
		{
			array = StringToByteArray(@string);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("PARSE RMS STRING FAIL " + ex.StackTrace);
			return null;
			IL_0030:;
		}
		if (array.Length == 0)
		{
			return null;
		}
		return ArrayCast.cast(array);
	}

	public static void clearRecord(string name)
	{
		PlayerPrefs.DeleteKey(name);
	}

	public static void deleteAll()
	{
		UnityEngine.Debug.LogWarning("ALL RMS CLEAR");
		PlayerPrefs.DeleteAll();
	}

	public static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", string.Empty);
	}

	public static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}

	public static void saveRMSString(string filename, string info)
	{
		byte[] array = StringToByteArray(info);
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__saveRMS(filename, data);
		}
		else
		{
			_saveRMS(filename, data);
		}
	}
}
