public class Npc_Server : NPC
{
	public short idImg;

	public sbyte nFrame;

	public sbyte index;

	public Npc_Server()
	{
		npcType = 1;
		catagory = 2;
	}

	public Npc_Server(int tx, int ty, int type, FilePack file)
		: base(tx, ty, type, file)
	{
	}

	public override void paint(MyGraphics g)
	{
		ImageIcon imgIcon = GameData.getImgIcon((short)(idImg + 4200));
		if (imgIcon != null && !imgIcon.isLoad)
		{
			g.drawRegion(GameData.getImgIcon((short)(idImg + 4200)).img, 0, height * index, width, height, 0, x, y, MyGraphics.BOTTOM | MyGraphics.HCENTER);
		}
		Image imgQuest = GameScr.getImgQuest(type);
		if (!imgQuest.Equals(Res.imgSelect))
		{
			g.drawImage(imgQuest, x, y - height - 5, MyGraphics.HCENTER | MyGraphics.BOTTOM);
		}
	}

	public override void paintCorner(MyGraphics g, int xCorner, int yCorner)
	{
		g.setClip(xCorner - 10, yCorner + 12 - height, 20, 22);
		ImageIcon imgIcon = GameData.getImgIcon((short)(idImg + 4200));
		if (imgIcon != null && !imgIcon.isLoad)
		{
			g.drawRegion(GameData.getImgIcon((short)(idImg + 4200)).img, 0, 0, width, height, 0, xCorner, yCorner + 12 - height, MyGraphics.TOP | MyGraphics.HCENTER);
		}
	}

	public override void update()
	{
		if (Canvas.gameTick % 4 == 0)
		{
			index++;
		}
		if (index >= nFrame)
		{
			index = 0;
		}
	}

	public override void setPosTo(short x, short y)
	{
	}

	public override int getLimxL()
	{
		return x - width / 2 + 10;
	}

	public override int getLimxR()
	{
		return x + width / 2 - 10;
	}

	public override int getLimyD()
	{
		return y - 40;
	}

	public override int getLimyU()
	{
		return y - height * 3 / 4 - 30;
	}

	public override bool isNPC()
	{
		return true;
	}

	public override int getNpcType()
	{
		return npcType;
	}
}
