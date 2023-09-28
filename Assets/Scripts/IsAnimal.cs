using System;

public class IsAnimal
{
	public static sbyte[][][] frameRun = new sbyte[10][][]
	{
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		}
	};

	public static sbyte[][][] frameStand = new sbyte[10][][]
	{
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		}
	};

	public static sbyte[][][] frameAt = new sbyte[10][][]
	{
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		},
		new sbyte[4][]
		{
			new sbyte[1],
			new sbyte[1],
			new sbyte[1],
			new sbyte[1]
		}
	};

	public static Image[] img = new Image[10];

	public static int[] wimg = new int[10];

	public static int[] hImg = new int[10];

	public static int[] addx = new int[10];

	public static int[] addy = new int[10];

	public sbyte idMonster;

	public int status;

	public int idFrame;

	public int p1;

	public int dir;

	public int type;

	public void paint(MyGraphics g, int xx, int yy)
	{
		if (img[idMonster] != null)
		{
			g.drawRegion(img[idMonster], 0, idFrame * hImg[idMonster], wimg[idMonster], hImg[idMonster], 0, xx + addx[idMonster], yy + addy[idMonster], 33);
		}
	}

	public void update()
	{
		if (idMonster < 0)
		{
			idMonster = 0;
		}
		try
		{
			switch (status)
			{
			case 0:
				p1++;
				if (p1 > frameStand[idMonster][dir].Length - 1)
				{
					p1 = 0;
				}
				idFrame = frameStand[idMonster][dir][p1];
				break;
			case 1:
				p1++;
				if (p1 > frameRun[idMonster][dir].Length - 1)
				{
					p1 = 0;
				}
				idFrame = frameRun[idMonster][dir][p1];
				break;
			case 2:
				p1++;
				if (p1 > frameAt[idMonster][dir].Length - 1)
				{
					p1 = frameAt[idMonster][dir].Length - 1;
				}
				idFrame = frameAt[idMonster][dir][p1];
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public int getHeight()
	{
		return hImg[idMonster];
	}
}
