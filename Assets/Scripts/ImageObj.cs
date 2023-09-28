using System;

public class ImageObj
{
	private Image[] img = new Image[1];

	public sbyte[] index;

	public sbyte[] x0;

	public sbyte[] y0;

	public sbyte[] w;

	public sbyte[] h;

	public short[] dx;

	public short[] dy;

	public ImageObj()
	{
	}

	public ImageObj(int type, int palate)
	{
		try
		{
			sbyte[] header = FilePack.instance.loadFile(palate + "_h");
			sbyte[] data = FilePack.instance.loadFile("data");
			img[0] = Res.createImgByHeader(header, data);
			sbyte[] data2 = FilePack.instance.loadFile("pos");
			DataInputStream dataInputStream = new DataInputStream(data2);
			int num = dataInputStream.readByte();
			index = new sbyte[num];
			x0 = new sbyte[num];
			y0 = new sbyte[num];
			w = new sbyte[num];
			h = new sbyte[num];
			dx = new short[num];
			dy = new short[num];
			for (int i = 0; i < num; i++)
			{
				index[i] = dataInputStream.readByte();
				x0[i] = dataInputStream.readByte();
				y0[i] = dataInputStream.readByte();
				w[i] = dataInputStream.readByte();
				h[i] = dataInputStream.readByte();
				dx[i] = dataInputStream.readByte();
				dy[i] = dataInputStream.readByte();
			}
		}
		catch (Exception)
		{
		}
	}

	public ImageObj(sbyte[] array)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			img = new Image[dataInputStream.readByte()];
			for (int i = 0; i < img.Length; i++)
			{
				int num = dataInputStream.readShort();
				sbyte[] data = new sbyte[num];
				dataInputStream.read(ref data);
				img[i] = Image.createImage(data, 0, num);
			}
		}
		catch (Exception)
		{
		}
	}

	public void paint(MyGraphics g, int x, int y, int index, int trans, int dirX, int dirY)
	{
		g.drawRegion(img[0], x0[index], y0[index], w[index], h[index], trans, x + dx[index] * dirX, y + dy[index] * dirY, 3);
	}

	public Image getImage(int indexImg)
	{
		if (img == null)
		{
			return null;
		}
		return img[indexImg];
	}

	public void initImage(int nImg)
	{
		img = new Image[nImg];
	}
}
