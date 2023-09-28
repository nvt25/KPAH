using System.IO;
using System.Text;
using UnityEngine;

public class myReader
{
	public sbyte[] buffer;

	private int posRead;

	public myReader()
	{
	}

	public myReader(sbyte[] data)
	{
		buffer = data;
	}

	public myReader(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		buffer = mSystem.convertToSbyte(textAsset.bytes);
	}

	public sbyte readSByte()
	{
		if (posRead < buffer.Length)
		{
			return buffer[posRead++];
		}
		posRead = buffer.Length;
		return -1;
	}

	public sbyte[] readArray(sbyte[] arr, int begin, int lenght, Message msg)
	{
		try
		{
			for (int i = 0; i < lenght; i++)
			{
				arr[i] = msg.reader().readByte();
			}
			return arr;
		}
		catch (IOException ex)
		{
			Out.println(ex.StackTrace + " loi readSingBytes");
			return arr;
		}
	}

	public sbyte readByte()
	{
		return readSByte();
	}

	public byte readUnsignedByte()
	{
		return convertSbyteToByte(readSByte());
	}

	public short readShort()
	{
		short num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (short)(num << 8);
			num = (short)(num | (short)(0xFF & buffer[posRead++]));
		}
		return num;
	}

	public ushort readUnsignedShort()
	{
		ushort num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (ushort)(num << 8);
			num = (ushort)(num | (ushort)(0xFF & buffer[posRead++]));
		}
		return num;
	}

	public int readInt()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num <<= 8;
			num |= (0xFF & buffer[posRead++]);
		}
		return num;
	}

	public long readLong()
	{
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			num <<= 8;
			num |= (0xFF & buffer[posRead++]);
		}
		return num;
	}

	public bool readBool()
	{
		return (readSByte() > 0) ? true : false;
	}

	public bool readBoolean()
	{
		return (readSByte() > 0) ? true : false;
	}

	public string readString()
	{
		short num = readShort();
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = convertSbyteToByte(readSByte());
		}
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		return uTF8Encoding.GetString(array);
	}

	public string readUTF()
	{
		short num = readShort();
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = convertSbyteToByte(readSByte());
		}
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		return uTF8Encoding.GetString(array);
	}

	public int read()
	{
		if (posRead < buffer.Length)
		{
			return readSByte();
		}
		return -1;
	}

	public int read(ref sbyte[] data)
	{
		if (data == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = readSByte();
			if (posRead >= buffer.Length)
			{
				return -1;
			}
			num++;
		}
		return num;
	}

	public int available()
	{
		return buffer.Length - posRead;
	}

	public static byte convertSbyteToByte(sbyte var)
	{
		if (var > 0)
		{
			return (byte)var;
		}
		return (byte)(var + 256);
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

	public void Close()
	{
		buffer = null;
	}

	public void read(ref sbyte[] data, int arg1, int arg2)
	{
		if (data == null)
		{
			return;
		}
		for (int i = 0; i < arg2; i++)
		{
			data[i + arg1] = readSByte();
			if (posRead > buffer.Length)
			{
				break;
			}
		}
	}
}
