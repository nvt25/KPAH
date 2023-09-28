public class Tree : Actor
{
	public int type;

	public Tree(int x, int y, int type)
	{
		base.x = (short)x;
		base.y = (short)y;
		this.type = type;
		catagory = Actor.CAT_TREE;
	}

	public void removeImage()
	{
		Res.removeTreeImage(type);
	}

	public int getH()
	{
		return Res.getHeightTree(type);
	}

	public int getW()
	{
		return Res.getwidthTree(type);
	}

	public override void paint(MyGraphics g)
	{
		TreeInfo tree = Res.getTree(type);
		int num = (x << 4) + tree.dx;
		int num2 = (y << 4) + tree.dy;
		if (num >= GameScr.cmx - tree.w && num2 >= GameScr.cmy - tree.h && num <= GameScr.cmx + GameScr.gsw && num2 <= GameScr.cmy + GameScr.gsh)
		{
			tree.paint(g, num, num2);
		}
	}

	public override int getX()
	{
		return base.getX();
	}

	public override int getY()
	{
		int num = 0;
		return (y << 4) + Res.getDyTree(type) + Res.getHeightTree(type);
	}

	public override void setPosTo(short x, short y)
	{
	}
}
