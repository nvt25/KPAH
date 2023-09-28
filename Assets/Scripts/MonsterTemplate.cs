using System;
using UnityEngine;

public class MonsterTemplate
{
	public static MyHashTable ALL_DATE_NEW_MONSTER = new MyHashTable();

	public int type = -1;

	public Image image;

	public Image[] Arrimage;

	public sbyte moveType;

	public sbyte speed = 1;

	public sbyte height;

	public sbyte w;

	public sbyte h;

	public sbyte xCenter;

	public sbyte yCenter;

	public sbyte xadd;

	public sbyte yadd;

	public sbyte isNewMonster;

	public string name;

	public sbyte he;

	public sbyte palate;

	public sbyte spalate;

	public int maxhp;

	public bool isLoad;

	public bool isMaxHight;

	public ImageObj imageObj;

	public mVector dataMonsterNew = new mVector();

	public long timePaint;

	private sbyte[] arrayDataMonsterNew;

	public MonsterTemplate()
	{
	}

	public MonsterTemplate(int type, string name, string image, sbyte moveType, sbyte speed, sbyte height, sbyte w, sbyte h, sbyte xCenter, sbyte yCenter, sbyte xadd, sbyte yadd)
	{
		this.type = type;
		this.name = name;
		this.moveType = moveType;
		this.speed = speed;
		this.height = height;
		this.w = w;
		this.h = h;
		this.xCenter = xCenter;
		this.yCenter = yCenter;
		this.xadd = xadd;
		this.yadd = yadd;
		isMaxHight = false;
	}

	public void setInfo(int type, string name, string image, sbyte moveType, sbyte speed, sbyte height, sbyte w, sbyte h, sbyte xCenter, sbyte yCenter, sbyte xadd, sbyte yadd)
	{
		this.type = type;
		this.name = name;
		this.moveType = moveType;
		this.speed = speed;
		this.height = height;
		this.w = w;
		this.h = h;
		this.xCenter = xCenter;
		this.yCenter = yCenter;
		this.xadd = xadd;
		this.yadd = yadd;
	}

	public void paint(MyGraphics g, int x, int y, int flip, int anchor, int f)
	{
		if (image != null)
		{
			try
			{
				g.drawRegion(image, 0, f * h, w, h, flip, x - xCenter, y - yCenter, anchor);
			}
			catch (Exception)
			{
			}
		}
		timePaint = mSystem.currentTimeMillis();
	}

	public void resetImage()
	{
		if (mSystem.currentTimeMillis() - timePaint > 60000)
		{
			image = null;
			imageObj = null;
			dataMonsterNew.removeAllElements();
			ALL_DATE_NEW_MONSTER.remove(string.Empty + spalate);
		}
	}

	public mVector getDataMonster()
	{
		try
		{
			if (type > -1)
			{
				mVector mVector = (mVector)ALL_DATE_NEW_MONSTER.get(string.Empty + spalate);
				if (mVector != null)
				{
					dataMonsterNew = mVector;
				}
				else
				{
					DataInputStream dataInputStream = new DataInputStream(Main.res + "/boss/" + spalate);
					sbyte b = dataInputStream.readByte();
					for (int i = 0; i < b; i++)
					{
						short num = dataInputStream.readShort();
						sbyte[] array = new sbyte[num];
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = dataInputStream.readByte();
						}
						dataMonsterNew.addElement(new DataEffect(array));
					}
					ALL_DATE_NEW_MONSTER.put(string.Empty + spalate, dataMonsterNew);
				}
			}
			timePaint = mSystem.currentTimeMillis();
		}
		catch (Exception)
		{
		}
		return dataMonsterNew;
	}

	public void loadImage()
	{
		if (!isLoad && type > -1)
		{
			GameService.gI().doRequestImageMonster(type, palate, spalate);
			isLoad = true;
		}
	}

	public void onImage(bool isSave, sbyte[] arr)
	{
		try
		{
			if ((palate >= 70 && palate <= 88) || palate == 90 || palate == 91 || palate == 92 || isNewMonster == 1)
			{
				imageObj = new ImageObj(arr);
			}
			else
			{
				FilePack.initByArray(arr);
				if (palate == 39 || palate == 40)
				{
					imageObj = new ImageObj(palate, spalate);
				}
				else
				{
					sbyte[] header = FilePack.instance.loadFile(spalate + "_h");
					sbyte[] data = FilePack.instance.loadFile("data");
					image = Res.createImgByHeader(header, data);
					int num = image.getHeight();
					isMaxHight = false;
					if (num > 1024)
					{
						isMaxHight = true;
						Arrimage = new Image[num / h];
						for (int i = 0; i < Arrimage.Length; i++)
						{
							Arrimage[i] = Image.createImage(image, 0, i * h, w, h, 0);
						}
						image.texture = null;
						image = null;
						Resources.UnloadUnusedAssets();
						GC.Collect();
					}
				}
				FilePack.reset();
			}
		}
		catch (Exception)
		{
		}
		isLoad = false;
	}

	public Image getImage(int index)
	{
		if (imageObj == null)
		{
			return null;
		}
		return imageObj.getImage(index);
	}

	public void doSetDataMonsterNew(sbyte[] array)
	{
		try
		{
			arrayDataMonsterNew = array;
			mVector mVector = (mVector)ALL_DATE_NEW_MONSTER.get(string.Empty + spalate);
			if (mVector != null)
			{
				dataMonsterNew = mVector;
			}
			else
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				sbyte b = dataInputStream.readByte();
				for (int i = 0; i < b; i++)
				{
					short num = dataInputStream.readShort();
					sbyte[] array2 = new sbyte[num];
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j] = dataInputStream.readByte();
					}
					dataMonsterNew.addElement(new DataEffect(array2));
				}
				ALL_DATE_NEW_MONSTER.put(string.Empty + spalate, dataMonsterNew);
				dataInputStream.close();
			}
		}
		catch (Exception)
		{
		}
	}
}
