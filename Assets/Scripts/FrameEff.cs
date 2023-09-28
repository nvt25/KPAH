public class FrameEff
{
	public mVector listPart = new mVector();

	public mVector listPartBottom = new mVector();

	public mVector listPartTop = new mVector();

	public sbyte xShadow;

	public sbyte yShadow;

	public FrameEff(mVector list)
	{
		listPart = list;
	}

	public FrameEff(mVector listtop, mVector listbottom)
	{
		listPartTop = listtop;
		listPartBottom = listbottom;
		listPart = listtop;
	}

	public mVector getListPartPaint()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < listPartBottom.size(); i++)
		{
			mVector.addElement(listPartBottom.elementAt(i));
		}
		for (int j = 0; j < listPart.size(); j++)
		{
			mVector.addElement(listPart.elementAt(j));
		}
		return mVector;
	}
}
