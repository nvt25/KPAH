using System;
using System.IO;

public class GameData
{
	private static GameData me;

	public static FrameImage imgSkillIcon;

	public static mVector imgHorse = new mVector();

	public static MyHashTable listImgIcon = new MyHashTable();

	private bool loadData;

	public static byte idWait = 0;

	public static Image imgWait;

	public static GameData gI()
	{
		return (me != null) ? me : (me = new GameData());
	}

	public void getImage()
	{
		if (!loadData)
		{
			loadImgPotion();
			loadImgGemItem();
			loadData = true;
		}
	}

	public static void loadImgPotion()
	{
		try
		{
			RMS.clearRecord("nqshImgPotion");
		}
		catch (Exception)
		{
		}
		sbyte[] array = RMS.loadRMS("nqshImgPotionNew");
		int ver = 0;
		if (array == null)
		{
			ver = 0;
		}
		else
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			sbyte[] array2 = null;
			sbyte[][] array3 = null;
			try
			{
				short num = dataInputStream.readShort();
				array2 = new sbyte[num];
				dataInputStream.read(ref array2);
				sbyte b = dataInputStream.readByte();
				for (int i = 0; i < b; i++)
				{
					short num2 = dataInputStream.readShort();
					sbyte[] data = new sbyte[num2];
					dataInputStream.read(ref data);
					sbyte b2 = dataInputStream.readByte();
					array3 = new sbyte[b2][];
					for (int j = 0; j < b2; j++)
					{
						short num3 = dataInputStream.readShort();
						array3[j] = new sbyte[num3];
						dataInputStream.read(ref array3[j]);
					}
					createImgHorse(data, array3);
				}
				ver = dataInputStream.readByte();
				dataInputStream.close();
			}
			catch (IOException ex2)
			{
				Out.LogError("  loi   loadImgPotion" + ex2.StackTrace);
			}
		}
		GameService.gI().doGetImage(2, ver);
	}

	private static void createImgHorse(sbyte[] data, sbyte[][] header)
	{
		for (int i = 0; i < header.Length; i++)
		{
			imgHorse.addElement(Res.createImgByHeader(header[i], data));
		}
	}

	public static void saveImgPotion(sbyte ver, sbyte[] arrayPotion, sbyte[] arrayItem, sbyte[][] dataHorse, sbyte[][][] headHorse)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeShort((short)arrayPotion.Length);
			dataOutputStream.write(arrayPotion);
			dataOutputStream.writeByte((sbyte)dataHorse.Length);
			for (int i = 0; i < dataHorse.Length; i++)
			{
				dataOutputStream.writeShort((short)dataHorse[i].Length);
				dataOutputStream.write(dataHorse[i]);
				dataOutputStream.writeByte((sbyte)headHorse[i].Length);
				for (int j = 0; j < headHorse[i].Length; j++)
				{
					dataOutputStream.writeShort((short)headHorse[i][j].Length);
					dataOutputStream.write(headHorse[i][j]);
				}
				createImgHorse(dataHorse[i], headHorse[i]);
			}
			dataOutputStream.writeByte(ver);
			RMS.saveRMS("nqshImgPotionNew", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Out.LogError(" loi saveImgPotion" + ex.StackTrace);
		}
	}

	public static void saveImgSkill(int ver, sbyte[] array)
	{
		imgSkillIcon = new FrameImage(Image.createImage(array, 0, array.Length), 20, 20);
	}

	public static void saveImgGem(sbyte ver, sbyte[] array)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(ver);
			dataOutputStream.writeShort((short)array.Length);
			dataOutputStream.write(array);
			RMS.saveRMS("gemItem", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Out.LogError(" loi saveImgGem " + ex.StackTrace);
		}
	}

	public static void paintIconCayThan(MyGraphics g, short id, int x, int y)
	{
		ImageIcon imgIcon = getImgIcon(id);
		if (imgIcon != null)
		{
			if (!imgIcon.isLoad)
			{
				g.drawImage(imgIcon.img, x, y, 3);
				return;
			}
			g.drawRegion(imgWait, 0, idWait * 18, 18, 18, 0, x, y, 3);
			setIndexWait();
		}
	}

	public static void loadImgGemItem()
	{
		sbyte[] array = RMS.loadRMS("gemItem");
		int ver = 0;
		if (array == null)
		{
			ver = 0;
		}
		else
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			sbyte[] array2 = null;
			try
			{
				ver = dataInputStream.readByte();
				short num = dataInputStream.readShort();
				array2 = new sbyte[num];
				dataInputStream.read(ref array2);
				dataInputStream.close();
			}
			catch (Exception ex)
			{
				Out.LogError(ex.StackTrace + " loi load gamedata");
			}
		}
		GameService.gI().doGetImage(3, ver);
	}

	public static void loadbg()
	{
		try
		{
			if (imgWait == null)
			{
				imgWait = Image.createImage(Main.res + "/waiting");
			}
		}
		catch (Exception)
		{
		}
	}

	public static void setIndexWait()
	{
		if (Canvas.gameTick % 5 == 0)
		{
			idWait = (byte)((idWait + 1) % (imgWait.getHeight() / 18));
		}
	}

	public static void paintIconTuBinh(MyGraphics g, short id, int x, int y, int align)
	{
		ImageIcon imgIcon = getImgIcon(id);
		if (imgIcon != null)
		{
			if (!imgIcon.isLoad)
			{
				g.drawImage(imgIcon.img, x, y, align);
				return;
			}
			g.drawRegion(imgWait, 0, idWait * 18, 18, 18, 0, x, y, 3);
			setIndexWait();
		}
	}

	public static void paintIcon(MyGraphics g, short id, int x, int y)
	{
		ImageIcon imgIcon = getImgIcon(id);
		if (imgIcon == null)
		{
			return;
		}
		if (!imgIcon.isLoad)
		{
			int width = imgIcon.img.getWidth();
			int num = imgIcon.img.getHeight();
			int num2 = 1;
			if (num > 25)
			{
				num /= 3;
				num2 = 3;
			}
			if (Canvas.gameTick % 5 == 0)
			{
				imgIcon.indexFrame = (byte)((imgIcon.indexFrame + 1) % num2);
			}
			g.drawRegion(imgIcon.img, 0, imgIcon.indexFrame * num, width, num, 0, x, y, 3);
		}
		else
		{
			g.drawRegion(imgWait, 0, idWait * 18, 18, 18, 0, x, y, 3);
			setIndexWait();
		}
	}

	public static void paintIcon(MyGraphics g, short id, int x, int y, int align)
	{
		ImageIcon imgIcon = getImgIcon(id);
		if (imgIcon == null)
		{
			return;
		}
		if (!imgIcon.isLoad)
		{
			int width = imgIcon.img.getWidth();
			int num = imgIcon.img.getHeight();
			int num2 = 1;
			if (num > 25)
			{
				num /= 3;
				num2 = 3;
			}
			if (Canvas.gameTick % 5 == 0)
			{
				imgIcon.indexFrame = (byte)((imgIcon.indexFrame + 1) % num2);
			}
			g.drawRegion(imgIcon.img, 0, imgIcon.indexFrame * num, width, num, 0, x, y, align);
		}
		else
		{
			g.drawRegion(imgWait, 0, idWait * 18, 18, 18, 0, x, y, 3);
			setIndexWait();
		}
	}

	public static ImageIcon getImgIcon(short id)
	{
		ImageIcon imageIcon = (ImageIcon)listImgIcon.get(id + string.Empty);
		if (imageIcon == null)
		{
			imageIcon = new ImageIcon();
			imageIcon.id = id;
			imageIcon.isLoad = true;
			listImgIcon.put(string.Empty + id, imageIcon);
			GameService.gI().doGetImgIcon(id);
			imageIcon.timeGetBack = (int)(mSystem.getCurrentTimeMillis() / 1000);
		}
		else
		{
			if (imageIcon.img == null && mSystem.getCurrentTimeMillis() / 1000 - imageIcon.timeGetBack > 30)
			{
				GameService.gI().doGetImgIcon(id);
				imageIcon.timeGetBack = (int)(mSystem.getCurrentTimeMillis() / 1000);
			}
			imageIcon.timeRemove = (int)(mSystem.getCurrentTimeMillis() / 1000);
		}
		return imageIcon;
	}
}
