public class Ground : Actor
{
	public MyTree myTree;

	public short idTree;

	public new int timeLive;

	public int minutes;

	private long currentTime;

	private sbyte count;

	private sbyte addyMytree;

	private sbyte colorInfo;

	public bool isBuyOk;

	private string clockInfo = string.Empty;

	public Ground(int idFarm, int id, int x, int y, string info, string name, int idImg, int timeLive, bool isBuyOk, sbyte addyMytree, sbyte colorInfo)
	{
		ID = (short)idFarm;
		idTree = (short)id;
		base.x = (short)x;
		base.y = (short)y;
		catagory = Actor.CAT_MY_GROUND;
		infoGround = info;
		this.timeLive = timeLive / 60;
		minutes = timeLive % 60;
		myTree = null;
		this.isBuyOk = isBuyOk;
		currentTime = mSystem.getCurrentTimeMillis();
		this.addyMytree = addyMytree;
		this.colorInfo = colorInfo;
		if (id > -1)
		{
			myTree = new MyTree(id, x + 16, y + 16 + addyMytree, idImg);
			Canvas.gameScr.actors.addElement(myTree);
		}
	}

	public void setInfo(int idFarm, int id, int x, int y, string info, string name, int idImgTree, int timeLive, bool isBuyOk, sbyte addyMytree, sbyte colorInfo)
	{
		ID = (short)idFarm;
		idTree = (short)id;
		base.x = (short)x;
		base.y = (short)y;
		catagory = Actor.CAT_MY_GROUND;
		infoGround = info;
		this.timeLive = timeLive / 60;
		minutes = timeLive % 60;
		this.isBuyOk = isBuyOk;
		currentTime = mSystem.getCurrentTimeMillis();
		this.addyMytree = addyMytree;
		this.colorInfo = colorInfo;
		if (id > -1)
		{
			if (myTree != null)
			{
				myTree.himg = 1;
				myTree.idTree = (short)id;
				myTree.idImg = (byte)idImgTree;
			}
			else
			{
				myTree = new MyTree(id, x + 16, y + 16 + addyMytree, idImgTree);
				Canvas.gameScr.actors.addElement(myTree);
			}
		}
		else if (myTree != null)
		{
			Canvas.gameScr.actors.removeElement(myTree);
			myTree = null;
		}
	}

	public override void paint(MyGraphics g)
	{
		if (Res.imgGround != null)
		{
			if (isBuyOk)
			{
				if (myTree == null)
				{
					g.drawImage(Res.imgGround[0], x, y, 0);
				}
				else
				{
					g.drawImage(Res.imgGround[2], x, y, 0);
				}
			}
			else
			{
				g.drawImage(Res.imgGround[1], x, y, 0);
			}
		}
		if (isFocus)
		{
			if (timeLive > -1 && myTree != null)
			{
				int width = MFont.normalFont[colorInfo].getWidth(clockInfo);
				g.setColor(1593912);
				g.fillRect(x + 16 - width / 2 - 3, y - ((myTree != null) ? (myTree.himg + 15) : 8), width + 5, 14);
				g.setColor(16772608);
				g.drawRect(x + 16 - width / 2 - 3, y - ((myTree != null) ? (myTree.himg + 15) : 8), width + 5, 14);
				MFont.normalFont[colorInfo].drawString(g, clockInfo, x + 16, y - ((myTree != null) ? (myTree.himg + 15) : 8), 2);
			}
			if (PopupName.imgArrow != null)
			{
				PopupName.imgArrow.drawFrame(0, x + 16, y - ((myTree != null) ? myTree.himg : 8) + Canvas.gameTick % 8, 0, 33, g);
			}
		}
	}

	public override void update()
	{
		count = (sbyte)(minutes - (mSystem.getCurrentTimeMillis() - currentTime) / 1000);
		if (count <= 0)
		{
			timeLive--;
			currentTime = mSystem.getCurrentTimeMillis();
			minutes = 59;
		}
		if (isFocus && timeLive > -1 && myTree != null)
		{
			clockInfo = ((timeLive >= 10) ? (timeLive + string.Empty) : ("0" + timeLive)) + " : " + ((count >= 10) ? (count + string.Empty) : ("0" + count));
		}
		base.update();
	}

	public new void setPosTo(short x, short y)
	{
	}
}
