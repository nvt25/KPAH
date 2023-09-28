using System;

public class DataEffect
{
	public mVector listFrame = new mVector();

	public mVector listAnima = new mVector();

	public SmallImage[] smallImage;

	public sbyte[] sequence;

	public static sbyte[] indexAction = new sbyte[9]
	{
		0,
		0,
		1,
		2,
		3,
		1,
		1,
		1,
		1
	};

	public DataEffect(sbyte[] array)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			int num = dataInputStream.readByte();
			smallImage = new SmallImage[num];
			for (int i = 0; i < num; i++)
			{
				smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num2 = dataInputStream.readShort();
			for (int j = 0; j < num2; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector = new mVector();
				for (int k = 0; k < b; k++)
				{
					PartFrame o = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					mVector.addElement(o);
				}
				listFrame.addElement(new FrameEff(mVector));
			}
			short num3 = dataInputStream.readShort();
			sequence = new sbyte[num3];
			for (int l = 0; l < num3; l++)
			{
				sequence[l] = (sbyte)dataInputStream.readShort();
			}
			sbyte b2 = dataInputStream.readByte();
			sbyte b3 = dataInputStream.readByte();
			num3 = dataInputStream.readByte();
			sbyte[] data = new sbyte[num3];
			dataInputStream.read(ref data);
			Animation o2 = new Animation(data);
			listAnima.addElement(o2);
			num3 = dataInputStream.readByte();
			data = new sbyte[num3];
			dataInputStream.read(ref data);
			o2 = new Animation(data);
			listAnima.addElement(o2);
			num3 = dataInputStream.readByte();
			data = new sbyte[num3];
			dataInputStream.read(ref data);
			o2 = new Animation(data);
			listAnima.addElement(o2);
			num3 = dataInputStream.readByte();
			data = new sbyte[num3];
			dataInputStream.read(ref data);
			o2 = new Animation(data);
			listAnima.addElement(o2);
		}
		catch (Exception)
		{
		}
	}

	public Animation getAnim(int action)
	{
		return (Animation)listAnima.elementAt(indexAction[action]);
	}

	public int getFrame(int f, int action)
	{
		Animation animation = (Animation)listAnima.elementAt(indexAction[action]);
		if (f < animation.frame.Length)
		{
			return animation.frame[f];
		}
		return 0;
	}

	public void paint(MyGraphics g, int idFrame, int x, int y, int way, Image img)
	{
		if (img != null)
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(idFrame);
			try
			{
				for (int i = 0; i < frameEff.listPart.size(); i++)
				{
					PartFrame partFrame = (PartFrame)frameEff.listPart.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					int num = partFrame.dx;
					if (way == 2)
					{
						num = -num - smallImage.w;
					}
					g.drawRegion(img, smallImage.x, smallImage.y, smallImage.w, smallImage.h, way, x + num, y + partFrame.dy, 0);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
