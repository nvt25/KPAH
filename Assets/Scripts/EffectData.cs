using System;

public class EffectData
{
	public sbyte[] arrFrame;

	public ImageInfo[] imgImfo;

	public Image img;

	public Frame[] frame;

	public short ID;

	public void setInfo(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte[] data = new sbyte[num];
			msg.reader().read(ref data);
			img = Res.createImgByByteArray(data);
			sbyte b = msg.reader().readByte();
			imgImfo = new ImageInfo[b];
			for (int i = 0; i < b; i++)
			{
				imgImfo[i] = new ImageInfo();
				imgImfo[i].ID = msg.reader().readByte();
				imgImfo[i].x0 = msg.reader().readByte();
				imgImfo[i].y0 = msg.reader().readByte();
				imgImfo[i].w = msg.reader().readByte();
				imgImfo[i].h = msg.reader().readByte();
			}
			sbyte b2 = msg.reader().readByte();
			frame = new Frame[b2];
			for (int j = 0; j < b2; j++)
			{
				frame[j] = new Frame();
				sbyte b3 = msg.reader().readByte();
				frame[j].dx = new sbyte[b3];
				frame[j].dy = new sbyte[b3];
				frame[j].idImg = new sbyte[b3];
				for (int k = 0; k < b3; k++)
				{
					frame[j].dx[k] = msg.reader().readByte();
					frame[j].dy[k] = msg.reader().readByte();
					frame[j].idImg[k] = msg.reader().readByte();
				}
			}
			sbyte b4 = msg.reader().readByte();
			arrFrame = new sbyte[b4];
			for (int l = 0; l < b4; l++)
			{
				arrFrame[l] = msg.reader().readByte();
			}
		}
		catch (Exception)
		{
		}
	}

	public ImageInfo getImgInfo(sbyte id)
	{
		for (int i = 0; i < imgImfo.Length; i++)
		{
			if (imgImfo[i].ID == id)
			{
				return imgImfo[i];
			}
		}
		return null;
	}

	public void paint(MyGraphics g, int x, int y, int index)
	{
		Frame frame = this.frame[arrFrame[index]];
		for (int i = 0; i < frame.dx.Length; i++)
		{
			ImageInfo imgInfo = getImgInfo(frame.idImg[i]);
			g.drawRegion(img, imgInfo.x0, imgInfo.y0, imgInfo.w, imgInfo.h, 0, x + frame.dx[i], y + frame.dy[i], 0);
		}
	}
}
