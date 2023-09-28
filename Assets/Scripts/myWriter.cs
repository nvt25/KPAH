using System.IO;
using System.Text;
using UnityEngine;

public class myWriter
{
	public sbyte[] buffer = new sbyte[2048];

	private int posWrite;

	private int lenght = 2048;

	public void writeSByte(sbyte value)
	{
		checkLenght();
		buffer[posWrite++] = value;
	}

	public void writeByte(sbyte value)
	{
		writeSByte(value);
	}

	public void writeUnsignedByte(byte value)
	{
		writeSByte((sbyte)value);
	}

	public void writeUnsignedByte(byte[] value)
	{
		for (int i = 0; i < value.Length; i++)
		{
			writeSByte((sbyte)value[i]);
		}
	}

	public void writeSByte(sbyte[] value)
	{
		for (int i = 0; i < value.Length; i++)
		{
			writeSByte(value[i]);
		}
	}

	public void writeShort(short value)
	{
		for (int num = 1; num >= 0; num--)
		{
			writeSByte((sbyte)(value >> num * 8));
		}
	}

	public void writeUnsignedShort(ushort value)
	{
		for (int num = 1; num >= 0; num--)
		{
			writeSByte((sbyte)(value >> num * 8));
		}
	}

	public void writeInt(int value)
	{
		for (int num = 3; num >= 0; num--)
		{
			writeSByte((sbyte)(value >> num * 8));
		}
	}

	public void writeLong(long value)
	{
		for (int num = 7; num >= 0; num--)
		{
			writeSByte((sbyte)(value >> num * 8));
		}
	}

	public void writeBoolean(bool value)
	{
		writeSByte((sbyte)(value ? 1 : 0));
	}

	public void writeBool(bool value)
	{
		writeSByte((sbyte)(value ? 1 : 0));
	}

	public void writeString(string value)
	{
		char[] array = value.ToCharArray();
		writeShort((short)array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			writeSByte((sbyte)array[i]);
		}
	}

	public void writeUTF(string value)
	{
		Encoding unicode = Encoding.Unicode;
		Encoding encoding = Encoding.GetEncoding(65001);
		byte[] bytes = unicode.GetBytes(value);
		byte[] array = Encoding.Convert(unicode, encoding, bytes);
		writeShort((short)array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			sbyte value2 = (sbyte)array[i];
			writeSByte(value2);
		}
	}

	public sbyte[] getData()
	{
		sbyte[] array = new sbyte[posWrite];
		for (int i = 0; i < posWrite; i++)
		{
			array[i] = buffer[i];
		}
		return array;
	}

	public void checkLenght()
	{
		if (posWrite > lenght - 4)
		{
			sbyte[] array = new sbyte[lenght + 4096];
			for (int i = 0; i < lenght; i++)
			{
				array[i] = buffer[i];
			}
			buffer = null;
			buffer = array;
			lenght += 4096;
		}
	}

	private static void convertString(string[] args)
	{
		string path = args[0];
		string path2 = args[1];
		using (StreamReader input = new StreamReader(path, Encoding.Unicode))
		{
			using (StreamWriter output = new StreamWriter(path2, append: false, Encoding.UTF8))
			{
				CopyContents(input, output);
			}
		}
	}

	private static void CopyContents(TextReader input, TextWriter output)
	{
		char[] array = new char[8192];
		int count;
		while ((count = input.Read(array, 0, array.Length)) != 0)
		{
			output.Write(array, 0, count);
		}
		output.Flush();
		string message = output.ToString();
		UnityEngine.Debug.Log(message);
	}

	public byte convertSbyteToByte(sbyte var)
	{
		if (var > 0)
		{
			return (byte)var;
		}
		return (byte)(var + 256);
	}

	public byte[] convertSbyteToByte(sbyte[] var)
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
}
