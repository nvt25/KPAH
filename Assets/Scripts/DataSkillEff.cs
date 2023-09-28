using System;

public class DataSkillEff
{
	public const sbyte ACTOR_NORMAL = 0;

	public const sbyte ACTOR_CAN_NOT_MOVE = 1;

	public const sbyte ACTOR_CAN_NOT_PAINT = 2;

	public const sbyte NORMAL = 0;

	public const sbyte REMOVE_BY_FRAME = 1;

	public const sbyte REMOVE_BY_TIME = 2;

	public const sbyte NO_REMOVE = 3;

	public bool isMatna;

	public mVector listFrame = new mVector();

	public mVector listAnima = new mVector();

	public SmallImage[] smallImage;

	public sbyte[][] frameChar = new sbyte[4][]
	{
		new sbyte[1],
		new sbyte[1],
		new sbyte[1],
		new sbyte[1]
	};

	public sbyte[] sequence;

	public sbyte Frame;

	public sbyte f;

	public static byte TYPE_EFFECT_END = 0;

	public static byte TYPE_EFFECT_STARTSKILL = 1;

	public static byte TYPE_EFFECT_BUFF = 2;

	public bool wantDetroy;

	public short x;

	public short y;

	public sbyte waitLoop;

	public sbyte indexStartSkill;

	public int idEff;

	private int dxx;

	private int dyy;

	public long timeRemove;

	public int typRequestImg = 112;

	public static MyHashTable ALL_DATA_EFF = new MyHashTable();

	public sbyte Typemove;

	public bool canremove;

	public bool canActorMove;

	public bool canPaintActor;

	public bool canActorFight;

	public sbyte typeupdate;

	public sbyte dyhorse;

	private bool isremovebyTime;

	private sbyte loop;

	private long lasttime;

	public long timelive;

	public DataSkillEff(int id, int x, int y, long timelive, bool canmove, bool canpaint, bool canFight, int loop, sbyte dyhorse)
	{
		this.timelive = timelive;
		idEff = (short)id;
		this.dyhorse = dyhorse;
		switch (timelive)
		{
		case -1L:
			typeupdate = 3;
			break;
		case 0L:
			typeupdate = 1;
			break;
		default:
			typeupdate = 2;
			break;
		}
		canActorMove = canmove;
		canPaintActor = canpaint;
		canActorFight = canFight;
		PartFrame partFrame = (PartFrame)ALL_DATA_EFF.get(id + string.Empty);
		if (partFrame != null)
		{
			loadData(partFrame.data);
		}
	}

	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy)
	{
		idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		loadData(array);
	}

	public DataSkillEff(int id, int x, int y, long timelive)
	{
		this.timelive = timelive;
		idEff = (short)id;
		switch (timelive)
		{
		case -1L:
			typeupdate = 3;
			break;
		case 0L:
			typeupdate = 1;
			break;
		default:
			typeupdate = 2;
			break;
		}
		PartFrame partFrame = (PartFrame)ALL_DATA_EFF.get(id + string.Empty);
		if (partFrame != null)
		{
			loadData(partFrame.data);
		}
	}

	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy, long time, sbyte typemove)
	{
		idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		Typemove = typemove;
		timelive = time;
		isremovebyTime = true;
		loadData(array);
	}

	public DataSkillEff(int id)
	{
		idEff = id;
		PartFrame partFrame = (PartFrame)ALL_DATA_EFF.get(id + string.Empty);
		if (partFrame != null)
		{
			loadData(partFrame.data);
		}
	}

	public void setWaitLoop(sbyte wait)
	{
		waitLoop = wait;
	}

	public void loadData(sbyte[] array)
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
				}
				listFrame.addElement(new FrameEff(mVector, mVector2));
			}
			short num3 = (short)dataInputStream.readUnsignedByte();
			sequence = new sbyte[num3];
			for (int l = 0; l < num3; l++)
			{
				sequence[l] = (sbyte)dataInputStream.readShort();
			}
			indexStartSkill = dataInputStream.readByte();
			num3 = dataInputStream.readByte();
			frameChar[0] = new sbyte[num3];
			for (int m = 0; m < num3; m++)
			{
				frameChar[0][m] = dataInputStream.readByte();
			}
			num3 = dataInputStream.readByte();
			frameChar[1] = new sbyte[num3];
			for (int n = 0; n < num3; n++)
			{
				frameChar[1][n] = dataInputStream.readByte();
			}
			num3 = dataInputStream.readByte();
			frameChar[3] = new sbyte[num3];
			for (int num4 = 0; num4 < num3; num4++)
			{
				frameChar[3][num4] = dataInputStream.readByte();
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintBottomHorse(MyGraphics g, int x, int y, int Frame, int rotale)
	{
		if (Frame < listFrame.size())
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)idEff);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = partFrame.dx;
						int num2 = smallImage.w;
						int num3 = smallImage.h;
						int num4 = smallImage.x;
						int num5 = smallImage.y;
						int width = imgIcon.img.getWidth();
						int height = imgIcon.img.getHeight();
						if (num4 > width)
						{
							num4 = 0;
						}
						if (num5 > height)
						{
							num5 = 0;
						}
						if (num4 + num2 > width)
						{
							num2 = width - num4;
						}
						if (num5 + num3 > height)
						{
							num3 = height - num5;
						}
						int num6 = (partFrame.flip == 1) ? 2 : 0;
						if (rotale == 2 || rotale == 6)
						{
							num6 = ((num6 != 2) ? 2 : 0);
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void paintTopHorse(MyGraphics g, int x, int y, int Frame, int rotale)
	{
		if (Frame < listFrame.size())
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)idEff);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = partFrame.dx;
						int num2 = smallImage.w;
						int num3 = smallImage.h;
						int num4 = smallImage.x;
						int num5 = smallImage.y;
						int width = imgIcon.img.getWidth();
						int height = imgIcon.img.getHeight();
						if (num4 > width)
						{
							num4 = 0;
						}
						if (num5 > height)
						{
							num5 = 0;
						}
						if (num4 + num2 > width)
						{
							num2 = width - num4;
						}
						if (num5 + num3 > height)
						{
							num3 = height - num5;
						}
						int num6 = (partFrame.flip == 1) ? 2 : 0;
						if (rotale == 2 || rotale == 6)
						{
							num6 = ((num6 != 2) ? 2 : 0);
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void paintTop(MyGraphics g, int x, int y)
	{
		if (Frame < listFrame.size())
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				listPartTop = frameEff.listPartBottom;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)idEff);
					if (imgIcon != null && imgIcon.img != null)
					{
						int dx = partFrame.dx;
						int num = smallImage.w;
						int num2 = smallImage.h;
						int num3 = smallImage.x;
						int num4 = smallImage.y;
						int width = imgIcon.img.getWidth();
						int height = imgIcon.img.getHeight();
						if (num3 > width)
						{
							num3 = 0;
						}
						if (num4 > height)
						{
							num4 = 0;
						}
						if (num3 + num > width)
						{
							num = width - num3;
						}
						if (num4 + num2 > height)
						{
							num2 = height - num4;
						}
						g.drawRegion(imgIcon.img, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, x + dx + dxx, y + partFrame.dy + dyy, 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void paintBottom(MyGraphics g, int x, int y)
	{
		if (Frame < listFrame.size())
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)idEff);
					if (imgIcon != null && imgIcon.img != null)
					{
						int dx = partFrame.dx;
						int num = smallImage.w;
						int num2 = smallImage.h;
						int num3 = smallImage.x;
						int num4 = smallImage.y;
						int width = imgIcon.img.getWidth();
						int height = imgIcon.img.getHeight();
						if (num3 > width)
						{
							num3 = 0;
						}
						if (num4 > height)
						{
							num4 = 0;
						}
						if (num3 + num > width)
						{
							num = width - num3;
						}
						if (num4 + num2 > height)
						{
							num2 = height - num4;
						}
						g.drawRegion(imgIcon.img, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, x + dx + dxx, y + partFrame.dy + dyy, 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void paintTop(MyGraphics g, int x, int y, int Frame, int rotale)
	{
		if (Frame < listFrame.size())
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)idEff);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = partFrame.dx;
						int num2 = smallImage.w;
						int num3 = smallImage.h;
						int num4 = smallImage.x;
						int num5 = smallImage.y;
						int width = imgIcon.img.getWidth();
						int height = imgIcon.img.getHeight();
						if (num4 > width)
						{
							num4 = 0;
						}
						if (num5 > height)
						{
							num5 = 0;
						}
						if (num4 + num2 > width)
						{
							num2 = width - num4;
						}
						if (num5 + num3 > height)
						{
							num3 = height - num5;
						}
						int num6 = (partFrame.flip == 1) ? 2 : 0;
						if (rotale == 2 || rotale == 6)
						{
							num6 = ((num6 != 2) ? 2 : 0);
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void paintBottom(MyGraphics g, int x, int y, int Frame, int rotale)
	{
		if (Frame < listFrame.size())
		{
			FrameEff frameEff = (FrameEff)listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)idEff);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = partFrame.dx;
						int num2 = smallImage.w;
						int num3 = smallImage.h;
						int num4 = smallImage.x;
						int num5 = smallImage.y;
						int width = imgIcon.img.getWidth();
						int height = imgIcon.img.getHeight();
						if (num4 > width)
						{
							num4 = 0;
						}
						if (num5 > height)
						{
							num5 = 0;
						}
						if (num4 + num2 > width)
						{
							num2 = width - num4;
						}
						if (num5 + num3 > height)
						{
							num3 = height - num5;
						}
						int num6 = (partFrame.flip == 1) ? 2 : 0;
						if (rotale == 2 || rotale == 6)
						{
							num6 = ((num6 != 2) ? 2 : 0);
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + dxx, y + partFrame.dy + dyy, 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public bool lockmoveByeffAuto()
	{
		return Typemove == 1;
	}

	public bool CanpaintByeffauto()
	{
		return Typemove == 2;
	}

	public bool isTanghinhbyEffauto()
	{
		return Typemove == 17;
	}

	public void update()
	{
		try
		{
			switch (typeupdate)
			{
			case 0:
			case 1:
				f++;
				if (f < sequence.Length)
				{
					Frame = sequence[f];
				}
				if (f >= sequence.Length)
				{
					f = 0;
					wantDetroy = true;
				}
				break;
			case 2:
				f++;
				if (f > sequence.Length - 1)
				{
					f = 0;
				}
				if (f < sequence.Length)
				{
					Frame = sequence[f];
				}
				if (timelive - mSystem.currentTimeMillis() < 0)
				{
					wantDetroy = true;
				}
				break;
			case 3:
				f++;
				if (f < sequence.Length)
				{
					Frame = sequence[f];
				}
				if (f > sequence.Length)
				{
					if (waitLoop > 0)
					{
						if (mSystem.currentTimeMillis() - lasttime > waitLoop * 1000)
						{
							f = 0;
							lasttime = mSystem.currentTimeMillis();
						}
					}
					else
					{
						f = 0;
					}
				}
				break;
			}
		}
		catch (Exception)
		{
		}
	}
}
