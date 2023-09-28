using System;

public class TreeInfo
{
	public int dx;

	public int dy;

	public int startx;

	public int starty;

	public int endx;

	public int endy;

	public int w;

	public int h;

	public int id;

	public Image imgTree;

	private long timeGetImage;

	public void onImage(sbyte[] arr, int index)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(arr);
			sbyte[] array = new sbyte[dataInputStream.readShort()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = dataInputStream.readByte();
			}
			imgTree = Image.createImage(array, 0, array.Length);
			sbyte[] array2 = new sbyte[dataInputStream.readShort()];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = dataInputStream.readByte();
			}
			DataInputStream dataInputStream2 = new DataInputStream(array2);
			dx = dataInputStream2.readByte();
			dy = dataInputStream2.readByte();
			startx = dataInputStream2.readUnsignedByte();
			starty = dataInputStream2.readUnsignedByte();
			endx = dataInputStream2.readUnsignedByte();
			endy = dataInputStream2.readUnsignedByte();
			w = imgTree.getWidth();
			h = imgTree.getHeight();
			dataInputStream.close();
			dataInputStream2.close();
		}
		catch (Exception)
		{
			imgTree = null;
		}
	}

	public Image getImage()
	{
		if (mSystem.currentTimeMillis() - timeGetImage > 180000 && imgTree == null)
		{
			GameService.gI().getTreeImage(id, 0, 0);
		}
		timeGetImage = mSystem.currentTimeMillis();
		return imgTree;
	}

	public int getHeight()
	{
		if (imgTree != null)
		{
			return imgTree.getHeight();
		}
		return 0;
	}

	public int getWidth()
	{
		if (imgTree != null)
		{
			return imgTree.getWidth();
		}
		return 0;
	}

	public void paint(MyGraphics g, int x, int y)
	{
		if (getImage() != null)
		{
			g.drawImage(imgTree, x, y, 0);
		}
	}

	public void loadData()
	{
		try
		{
			imgTree = Image.createImage("/t6.png");
			DataInputStream resourceAsStream = DataInputStream.getResourceAsStream(Main.res + "t6");
			dx = resourceAsStream.readUnsignedByte();
			dy = resourceAsStream.readUnsignedByte();
			if (dx > 127)
			{
				dx -= 256;
			}
			if (dy > 127)
			{
				dy -= 256;
			}
			startx = resourceAsStream.readUnsignedByte();
			starty = resourceAsStream.readUnsignedByte();
			endx = resourceAsStream.readUnsignedByte();
			endy = resourceAsStream.readUnsignedByte();
			w = imgTree.getWidth();
			h = imgTree.getHeight();
		}
		catch (Exception)
		{
		}
	}
}
