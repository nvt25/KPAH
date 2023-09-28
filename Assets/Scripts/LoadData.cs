using UnityEngine;

public class LoadData
{
	public int iWpsPlash = -1;

	public int jWpsPlash = -1;

	public int iImgWeaPone = -1;

	public int jImgWeaPone = -1;

	public int indexWeapone = -1;

	public int indexImgEffect = -1;

	public int indexTreeImg = -1;

	public int indexMap = -1;

	public int indexArrow = -1;

	private ActionPerform iaLoadMap;

	public bool isInitGame;

	public sbyte[] byteMap;

	private Command cmd;

	public void loadMap(int index, ActionPerform ia, sbyte[] byteMap)
	{
		indexMap = index;
		indexMap = index;
		iaLoadMap = ia;
		this.byteMap = byteMap;
		Tilemap.reset();
		cmd = new Command();
		ActionPerform action = iaLoadMap;
		cmd.action = action;
		UnityEngine.Debug.Log(" trung---------------------------ê---------");
	}

	public void loadWpsPlash(int i, int j)
	{
		if (iWpsPlash == -1 && jWpsPlash == -1)
		{
			iWpsPlash = i;
			jWpsPlash = j;
		}
	}

	public void loadImgWeaPone(int i, int j, int index)
	{
		if (iImgWeaPone == -1 && jImgWeaPone == -1)
		{
			iImgWeaPone = i;
			jImgWeaPone = j;
			indexWeapone = index;
		}
	}

	public void loadImgEffect(int index)
	{
		if (indexImgEffect == -1)
		{
			indexImgEffect = index;
		}
	}

	public void run()
	{
		if (iWpsPlash != -1 && jWpsPlash != -1)
		{
			Res.GetWPSplashInfo(iWpsPlash, jWpsPlash);
			iWpsPlash = -1;
			jWpsPlash = -1;
		}
		if (iImgWeaPone != -1 && jImgWeaPone != -1)
		{
			Res.getImgWeaPone(iImgWeaPone, jImgWeaPone, indexWeapone);
			iImgWeaPone = -1;
			jImgWeaPone = -1;
		}
		if (indexImgEffect != -1)
		{
			Res.getImgEffect(indexImgEffect);
			indexImgEffect = -1;
		}
		if (indexMap != -1)
		{
			int level = indexMap;
			indexMap = -1;
			Tilemap.loadMap(level, byteMap);
			cmd.action = iaLoadMap;
			cmd.perform();
			byteMap = null;
		}
		if (indexArrow != -1)
		{
			Res.loadImgArrow(indexArrow);
			indexArrow = -1;
		}
	}
}
