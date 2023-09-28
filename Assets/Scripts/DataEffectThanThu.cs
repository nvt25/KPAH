using System;

public class DataEffectThanThu
{
	public mVector listFrame = new mVector();

	public mVector listAnima = new mVector();

	public SmallImage[] smallImage;

	public sbyte[] sequence;

	private short FrameWith;

	private short FrameHeight;

	private short idimg;

	public string name = string.Empty;

	public static sbyte[][] indexAction = new sbyte[2][]
	{
		new sbyte[13]
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
			1
		},
		new sbyte[13]
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
			5
		}
	};

	public DataEffectThanThu(sbyte[] array, int idimg)
	{
		this.idimg = (short)idimg;
		setDataType1(array);
	}

	public DataEffectThanThu(sbyte[] array)
	{
		setDataType1(array);
	}

	public void setDataType1(sbyte[] array)
	{
		short num = 0;
		try
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			int num2 = dataInputStream.readByte();
			smallImage = new SmallImage[num2];
			for (int i = 0; i < num2; i++)
			{
				smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num3 = 0;
			int num4 = dataInputStream.readShort();
			for (int j = 0; j < num4; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector = new mVector();
				mVector mVector2 = new mVector();
				for (int k = 0; k < b; k++)
				{
					PartFrame partFrame = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					partFrame.flip = dataInputStream.readByte();
					partFrame.onTop = dataInputStream.readByte();
					if (partFrame.onTop == 0)
					{
						mVector.addElement(partFrame);
					}
					else
					{
						mVector2.addElement(partFrame);
					}
					if (num3 < Canvas.abs(partFrame.dy))
					{
						num3 = Canvas.abs(partFrame.dy);
					}
				}
				listFrame.addElement(new FrameEff(mVector, mVector2));
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
			sbyte[] array2 = new sbyte[num];
			for (int m = 0; m < num; m++)
			{
				array2[m] = dataInputStream.readByte();
			}
			Animation o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int n = 0; n < num; n++)
			{
				array2[n] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num5 = 0; num5 < num; num5++)
			{
				array2[num5] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num6 = 0; num6 < num; num6++)
			{
				array2[num6] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num7 = 0; num7 < num; num7++)
			{
				array2[num7] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num8 = 0; num8 < num; num8++)
			{
				array2[num8] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num9 = 0; num9 < num; num9++)
			{
				array2[num9] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
			num = dataInputStream.readByte();
			array2 = new sbyte[num];
			for (int num10 = 0; num10 < num; num10++)
			{
				array2[num10] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			listAnima.addElement(o);
		}
		catch (Exception)
		{
		}
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

	public void paintType2(MyGraphics g, int idFrame, int x, int y, int way)
	{
	}

	public void paint(MyGraphics g, int idFrame, int x, int y, int way, Image img)
	{
		if (img != null)
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
			try
			{
				mVector listPartPaint = frameEff.getListPartPaint();
				for (int i = 0; i < listPartPaint.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartPaint.elementAt(i);
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

	public short getWith()
	{
		return FrameWith;
	}

	public short getHeight()
	{
		return FrameHeight;
	}
}
