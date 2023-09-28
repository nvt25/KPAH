public class AnimalMove : Char
{
	public short status;

	public new short dir;

	public new short xTo;

	public new short yTo;

	public short wImg = 1;

	public short hImg = 1;

	public short sumFrame;

	public short addY;

	public short idSameMyOwnerID;

	public Char myOwner;

	public short v = 5;

	public short vMax;

	public short type;

	public short imgID;

	public short count;

	public short idFrame;

	public new int totalTime;

	public int timeMagic;

	public long timeStart;

	public string infoPet;

	private sbyte[] arr = new sbyte[4]
	{
		-1,
		0,
		1,
		0
	};

	private sbyte index;

	private sbyte fLip;

	private sbyte[][][] arrFrameMove = new sbyte[7][][]
	{
		new sbyte[4][]
		{
			new sbyte[12]
			{
				0,
				0,
				0,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1,
				1
			},
			new sbyte[12]
			{
				3,
				3,
				3,
				4,
				4,
				4,
				5,
				5,
				5,
				4,
				4,
				4
			},
			new sbyte[12]
			{
				6,
				6,
				6,
				7,
				7,
				7,
				8,
				8,
				8,
				7,
				7,
				7
			},
			new sbyte[12]
			{
				6,
				6,
				6,
				7,
				7,
				7,
				8,
				8,
				8,
				7,
				7,
				7
			}
		},
		new sbyte[4][]
		{
			new sbyte[10]
			{
				0,
				0,
				1,
				1,
				2,
				2,
				1,
				1,
				3,
				3
			},
			new sbyte[8]
			{
				5,
				5,
				6,
				6,
				5,
				5,
				7,
				7
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			}
		},
		new sbyte[4][]
		{
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				0,
				1,
				1
			},
			new sbyte[4]
			{
				2,
				2,
				3,
				3
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				0,
				1,
				1
			},
			new sbyte[4]
			{
				2,
				2,
				3,
				3
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			}
		},
		new sbyte[4][]
		{
			new sbyte[10]
			{
				0,
				0,
				1,
				1,
				2,
				2,
				1,
				1,
				3,
				3
			},
			new sbyte[8]
			{
				5,
				5,
				6,
				6,
				5,
				5,
				7,
				7
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			}
		},
		new sbyte[4][]
		{
			new sbyte[10]
			{
				0,
				0,
				1,
				1,
				2,
				2,
				1,
				1,
				3,
				3
			},
			new sbyte[8]
			{
				5,
				5,
				6,
				6,
				5,
				5,
				7,
				7
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			}
		}
	};

	private sbyte[][][] arrFrameStand = new sbyte[7][][]
	{
		new sbyte[4][]
		{
			new sbyte[12]
			{
				0,
				0,
				0,
				1,
				1,
				1,
				2,
				2,
				2,
				1,
				1,
				1
			},
			new sbyte[12]
			{
				3,
				3,
				3,
				4,
				4,
				4,
				5,
				5,
				5,
				4,
				4,
				4
			},
			new sbyte[12]
			{
				6,
				6,
				6,
				7,
				7,
				7,
				8,
				8,
				8,
				7,
				7,
				7
			},
			new sbyte[12]
			{
				6,
				6,
				6,
				7,
				7,
				7,
				8,
				8,
				8,
				7,
				7,
				7
			}
		},
		new sbyte[4][]
		{
			new sbyte[12]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				1
			},
			new sbyte[12]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5,
				5,
				5
			},
			new sbyte[12]
			{
				8,
				8,
				8,
				8,
				8,
				8,
				9,
				9,
				9,
				9,
				9,
				9
			},
			new sbyte[12]
			{
				8,
				8,
				8,
				8,
				8,
				8,
				9,
				9,
				9,
				9,
				9,
				9
			}
		},
		new sbyte[4][]
		{
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[8]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				0,
				1,
				1
			},
			new sbyte[4]
			{
				2,
				2,
				3,
				3
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			}
		},
		new sbyte[4][]
		{
			new sbyte[4]
			{
				0,
				0,
				1,
				1
			},
			new sbyte[4]
			{
				2,
				2,
				3,
				3
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			},
			new sbyte[4]
			{
				4,
				4,
				5,
				5
			}
		},
		new sbyte[4][]
		{
			new sbyte[10]
			{
				0,
				0,
				1,
				1,
				2,
				2,
				1,
				1,
				3,
				3
			},
			new sbyte[8]
			{
				5,
				5,
				6,
				6,
				5,
				5,
				7,
				7
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			}
		},
		new sbyte[4][]
		{
			new sbyte[10]
			{
				0,
				0,
				1,
				1,
				2,
				2,
				1,
				1,
				3,
				3
			},
			new sbyte[8]
			{
				5,
				5,
				6,
				6,
				5,
				5,
				7,
				7
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			},
			new sbyte[8]
			{
				9,
				9,
				10,
				10,
				9,
				9,
				11,
				11
			}
		}
	};

	public void setFrameType4()
	{
		if (type != 4)
		{
			return;
		}
		for (int i = 0; i < arrFrameStand[type].Length; i++)
		{
			for (int j = 0; j < arrFrameStand[type][i].Length; j++)
			{
				arrFrameStand[type][i] = new sbyte[sumFrame * 3];
				arrFrameStand[type][i][0] = 0;
				sbyte b = 0;
				for (int k = 1; k < sumFrame * 3; k++)
				{
					arrFrameStand[type][i][k] = b;
					if (k % 3 == 0)
					{
						b = (sbyte)(b + 1);
					}
				}
			}
		}
		arrFrameMove[type] = arrFrameStand[type];
	}

	public override void setPosTo(short x, short y)
	{
		xTo = x;
		yTo = y;
	}

	public override void update()
	{
		switch (status)
		{
		case 0:
			count++;
			if (count > arrFrameStand[type][dir].Length - 1)
			{
				count = 0;
			}
			idFrame = arrFrameStand[type][dir][count];
			if (isOutRange())
			{
				status = 1;
			}
			vMax = 0;
			break;
		case 1:
		{
			yTo = myOwner.y;
			if (type == 1)
			{
				if (myOwner.dir == Char.LEFT)
				{
					xTo = (short)(myOwner.x + myOwner.width / 2 + 16);
				}
				else if (myOwner.dir == Char.RIGHT)
				{
					xTo = (short)(myOwner.x - myOwner.width / 2 - 10);
				}
				else
				{
					xTo = myOwner.x;
					if (myOwner.dir == Char.UP)
					{
						yTo = (short)(myOwner.y + myOwner.height);
					}
					else
					{
						yTo = (short)(myOwner.y - myOwner.height - 10);
					}
				}
			}
			else if (myOwner.dir == Char.LEFT || myOwner.dir == Char.UP)
			{
				xTo = (short)(myOwner.x + myOwner.width / 2 + ((type != 2) ? 14 : 5));
			}
			else
			{
				xTo = (short)(myOwner.x - myOwner.width / 2 - ((type != 2) ? 10 : 5));
			}
			bool flag = false;
			bool flag2 = false;
			int num = Canvas.abs(x - xTo);
			int num2 = Canvas.abs(y - yTo);
			if (num <= v + vMax)
			{
				x = xTo;
				flag = true;
			}
			if (num2 <= v + vMax)
			{
				y = yTo;
				flag2 = true;
			}
			if (flag && flag2 && (myOwner.state == 0 || myOwner.state == 2))
			{
				if (myOwner.ID != Canvas.gameScr.mainChar.ID)
				{
					status = 0;
				}
				else if (Canvas.gameScr.mainChar.posTransRoad == null)
				{
					status = 0;
				}
				break;
			}
			if (x < xTo)
			{
				x += (short)(v + vMax);
				dir = Char.RIGHT;
			}
			else if (x > xTo)
			{
				x -= (short)(v + vMax);
				dir = Char.LEFT;
			}
			else if (y > yTo)
			{
				y -= (short)(v + vMax);
				dir = Char.UP;
			}
			else if (y < yTo)
			{
				y += (short)(v + vMax);
				dir = Char.DOWN;
			}
			else
			{
				dir = myOwner.dir;
			}
			if (isOutRange())
			{
				vMax = (sbyte)(v / 2);
			}
			count++;
			if (count > arrFrameMove[type][dir].Length - 1)
			{
				count = 0;
			}
			idFrame = arrFrameMove[type][dir][count];
			break;
		}
		case 3:
			if (timeMagic > 0)
			{
				timeMagic--;
			}
			if (timeMagic <= 0)
			{
				Canvas.gameScr.actors.removeElement(this);
			}
			if (timeMagic % 4 == 0)
			{
				EffectManager.addHiEffect(x, y + addY - hImg / 2, (type == 1) ? 23 : 11);
			}
			break;
		}
		if (type != 1 && Canvas.gameTick % 2 == 0)
		{
			index++;
			if (index > arr.Length - 1)
			{
				index = 0;
			}
		}
		if (myOwner.isDie && Canvas.gameScr.actors.conTains(this))
		{
			Canvas.gameScr.actors.removeElement(this);
		}
		if (totalTime - (mSystem.getCurrentTimeMillis() - timeStart) / 60000 <= 0 && status != 3)
		{
			status = 3;
			timeMagic = 20;
		}
		if (dir == Char.LEFT)
		{
			fLip = 2;
		}
		else
		{
			fLip = 0;
		}
		base.update();
	}

	public bool isOutRange()
	{
		if (myOwner == null)
		{
			return false;
		}
		int num = 64;
		int num2 = 70;
		int num3 = 70;
		if (type == 2)
		{
			num = 32;
			num2 = (num3 = 20);
		}
		if (myOwner.dir == Char.DOWN)
		{
			num = 48;
		}
		if (Util.distance(x, y, myOwner.x, myOwner.y) > num || (Math.abs(x - myOwner.x) > num2 && dir != 0 && dir != 1) || Math.abs(y - myOwner.y) > num3)
		{
			return true;
		}
		return false;
	}

	public override void paint(MyGraphics g)
	{
		ImageIcon imgIcon = GameData.getImgIcon((short)(imgID + 5200));
		if (myOwner != null && imgIcon != null && !imgIcon.isLoad)
		{
			if (hImg == 1)
			{
				hImg = (short)(imgIcon.img.getHeight() / sumFrame);
			}
			if (wImg == 1)
			{
				wImg = (short)imgIcon.img.getWidth();
			}
			if (timeMagic % 2 == 0)
			{
				g.drawRegion(imgIcon.img, 0, hImg * idFrame, wImg, hImg, fLip, x, y + addY + arr[index] + ((myOwner.useHorse == -1 && type != 1) ? 3 : 0), MyGraphics.BOTTOM | MyGraphics.HCENTER);
				g.drawImage(Res.imgShadowPet, x, y + ((myOwner.useHorse == -1 && type != 1) ? 3 : 0), 3);
			}
		}
	}
}
