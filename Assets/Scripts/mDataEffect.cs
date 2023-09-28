using System;
using UnityEngine;

public class mDataEffect
{
	public mVector listFrame = new mVector();

	public mVector listAnima = new mVector();

	public SmallImage[] smallImage;

	public sbyte[] sequence;

	private short FrameWith;

	private short FrameHeight;

	private short idimg;

	public string name = string.Empty;

	public sbyte isFly;

	public sbyte idShadow;

	public static sbyte[][] indexAction = new sbyte[3][]
	{
		new sbyte[14]
		{
			0,
			0,
			1,
			2,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[14]
		{
			4,
			4,
			5,
			6,
			7,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5
		},
		new sbyte[14]
		{
			8,
			8,
			9,
			10,
			11,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9
		}
	};

	public mDataEffect(sbyte[] array, int idimg, bool isMonster)
	{
		this.idimg = (short)idimg;
		setDataType1(array);
	}

	public mDataEffect(sbyte[] array)
	{
		setDataType1(array);
	}

	public void setDataType1(sbyte[] array)
	{
		short num = 0;
		DataInputStream dataInputStream = new DataInputStream(array);
		listFrame.removeAllElements();
		listAnima.removeAllElements();
		try
		{
			int num2 = dataInputStream.readByte();
			smallImage = new SmallImage[num2];
			for (int i = 0; i < num2; i++)
			{
				smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = -1000000;
			int num6 = dataInputStream.readShort();
			for (int j = 0; j < num6; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector = new mVector();
				for (int k = 0; k < b; k++)
				{
					PartFrame partFrame = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					partFrame.flip = dataInputStream.readByte();
					partFrame.onTop = dataInputStream.readByte();
					mVector.addElement(partFrame);
					if (j == 0)
					{
						if (num5 < partFrame.dy + smallImage[partFrame.idSmallImg].h)
						{
							num5 = partFrame.dy + smallImage[partFrame.idSmallImg].h;
						}
						if (num3 < Util.abs(partFrame.dy))
						{
							num3 = Util.abs(partFrame.dy);
						}
					}
				}
				if (j == 0 && num5 <= -5)
				{
					isFly = (sbyte)num5;
				}
				listFrame.addElement(new FrameEff(mVector, null));
			}
			FrameWith = smallImage[0].w;
			FrameHeight = (short)num3;
			num = dataInputStream.readShort();
			sequence = new sbyte[num];
			for (int l = 0; l < num; l++)
			{
				sequence[l] = (sbyte)dataInputStream.readShort();
			}
			num = dataInputStream.readByte();
			sbyte[] data = new sbyte[num];
			dataInputStream.read(ref data);
			Animation o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			data = new sbyte[num];
			dataInputStream.read(ref data);
			o = new Animation(data);
			listAnima.addElement(o);
			if (dataInputStream.available() > 0)
			{
				idShadow = dataInputStream.readByte();
				for (int m = 0; m < num6; m++)
				{
					FrameEff frameEff = (FrameEff)listFrame.elementAt(m);
					frameEff.xShadow = dataInputStream.readByte();
					frameEff.yShadow = dataInputStream.readByte();
				}
			}
			if (dataInputStream.available() > 0)
			{
				num = dataInputStream.readByte();
				data = new sbyte[num];
				dataInputStream.read(ref data);
				o = new Animation(data);
				listAnima.addElement(o);
				num = dataInputStream.readByte();
				data = new sbyte[num];
				dataInputStream.read(ref data);
				o = new Animation(data);
				listAnima.addElement(o);
				num = dataInputStream.readByte();
				data = new sbyte[num];
				dataInputStream.read(ref data);
				o = new Animation(data);
				listAnima.addElement(o);
				num = dataInputStream.readByte();
				data = new sbyte[num];
				dataInputStream.read(ref data);
				o = new Animation(data);
				listAnima.addElement(o);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
			try
			{
			}
			catch (Exception)
			{
			}
		}
	}

	public int getIndexAction(int action, int way)
	{
		return indexAction[way][action];
	}

	public Animation getAnim(int action, int way)
	{
		return (Animation)listAnima.elementAt(indexAction[way][action]);
	}

	public int getFrame(int f, int action, int way)
	{
		Animation animation = (Animation)listAnima.elementAt(indexAction[way][action]);
		if (f < animation.frame.Length)
		{
			return animation.frame[f];
		}
		return 0;
	}

	public void paintType2(Graphics g, int idFrame, int x, int y, int way)
	{
	}

	public FrameEff getFrame(int idFrame)
	{
		return (FrameEff)listFrame.elementAt(idFrame);
	}

	public sbyte[] getDxDyShadow(int idFrame)
	{
		FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
		if (frameEff != null)
		{
			return new sbyte[2]
			{
				frameEff.xShadow,
				frameEff.yShadow
			};
		}
		return new sbyte[2];
	}

	public void paintnoHeight(MyGraphics g, int idFrame, int x, int y, int way, Image img, bool isFly)
	{
		if (img != null)
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
			if (frameEff == null || frameEff.listPartTop == null)
			{
			}
			if (frameEff.listPartTop != null)
			{
				try
				{
					for (int i = 0; i < frameEff.listPartTop.size(); i++)
					{
						PartFrame partFrame = (PartFrame)frameEff.listPartTop.elementAt(i);
						SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
						int num = partFrame.dx;
						int num2 = partFrame.dy;
						if (isFly)
						{
							num2 += 35;
						}
						int num3 = smallImage.w;
						int h = smallImage.h;
						int num4 = smallImage.x;
						int num5 = smallImage.y;
						if (num4 > img.getWidth())
						{
							num4 = 0;
						}
						if (num5 > img.getHeight())
						{
							num5 = 0;
						}
						if (num4 + num3 > img.getWidth())
						{
							num3 = img.getWidth() - num4;
						}
						if (way == 2)
						{
							num = -num - num3;
						}
						if (partFrame.flip != 1)
						{
							g.drawRegion(img, num4, num5, num3, h, way, x + num, y + num2, 0);
						}
						else
						{
							g.drawRegion(img, num4, num5, num3, h, (way != 2) ? 2 : 0, x + num, y + num2, 0);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}

	public void paintPet(MyGraphics g, int idFrame, int x, int y, int way, Image img, int ysai)
	{
		if (img != null)
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
			if (frameEff == null || frameEff.listPartTop == null)
			{
			}
			if (frameEff.listPartTop != null)
			{
				try
				{
					for (int i = 0; i < frameEff.listPartTop.size(); i++)
					{
						PartFrame partFrame = (PartFrame)frameEff.listPartTop.elementAt(i);
						SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
						int num = partFrame.dx;
						int num2 = partFrame.dy;
						if (num2 < -40)
						{
							num2 += ysai;
						}
						int num3 = smallImage.w;
						int num4 = smallImage.h;
						int num5 = smallImage.x;
						int num6 = smallImage.y;
						if (num5 > img.getWidth())
						{
							num5 = 0;
						}
						if (num6 > img.getHeight())
						{
							num6 = 0;
						}
						if (num5 + num3 > img.getWidth())
						{
							num3 = img.getWidth() - num5;
						}
						if (num6 + num4 > img.getHeight())
						{
							num4 = img.getHeight() - num6;
						}
						if (way == 2)
						{
							num = -num - num3;
						}
						if (partFrame.flip != 1)
						{
							g.drawRegion(img, num5, num6, num3, num4, way, x + num, y + num2, 0);
						}
						else
						{
							g.drawRegion(img, num5, num6, num3, num4, (way != 2) ? 2 : 0, x + num, y + num2, 0);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}

	public void paint(MyGraphics g, int idFrame, int x, int y, int way, Image img)
	{
		if (img != null)
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
			if (frameEff == null || frameEff.listPartTop == null)
			{
			}
			if (frameEff.listPartTop != null)
			{
				try
				{
					for (int i = 0; i < frameEff.listPartTop.size(); i++)
					{
						PartFrame partFrame = (PartFrame)frameEff.listPartTop.elementAt(i);
						SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
						int num = partFrame.dx;
						int num2 = smallImage.w;
						int num3 = smallImage.h;
						int num4 = smallImage.x;
						int num5 = smallImage.y;
						if (num4 > img.getWidth())
						{
							num4 = 0;
						}
						if (num5 > img.getHeight())
						{
							num5 = 0;
						}
						if (num4 + num2 > img.getWidth())
						{
							num2 = img.getWidth() - num4;
						}
						if (num5 + num3 > img.getHeight())
						{
							num3 = img.getHeight() - num5;
						}
						if (way == 2)
						{
							num = -num - num2;
						}
						if (partFrame.flip != 1)
						{
							g.drawRegion(img, num4, num5, num2, num3, way, x + num, y + partFrame.dy, 0);
						}
						else
						{
							g.drawRegion(img, num4, num5, num2, num3, (way != 2) ? 2 : 0, x + num, y + partFrame.dy, 0);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}

	public int getPointStart()
	{
		return isFly;
	}

	public short getWith()
	{
		return FrameWith;
	}

	public short getHeight()
	{
		return FrameHeight;
	}
}
