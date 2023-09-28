using System;

public class DynamicEffect : Actor
{
	public static MyHashTable ALL_DATA_DYNAMIC_EFFECT = new MyHashTable();

	public short id;

	public long timeExist = -1L;

	private sbyte index;

	public int power = 2000000000;

	public int dam;

	public sbyte stop;

	public DynamicEffect(int id)
	{
		this.id = (short)id;
	}

	public void paint(MyGraphics g, int x, int y)
	{
		DataEffect dataEffect = (DataEffect)ALL_DATA_DYNAMIC_EFFECT.get(id + string.Empty);
		if (dataEffect != null)
		{
			ImageIcon imgIcon = GameData.getImgIcon((short)(id + 8700));
			if (imgIcon != null && imgIcon.img != null)
			{
				sbyte[] sequence = getSequence(id);
				dataEffect.paint(g, sequence[index], x, y, 0, imgIcon.img);
			}
		}
	}

	public static void setDataEffect(sbyte[][] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			DataEffect v = new DataEffect(array[i]);
			ALL_DATA_DYNAMIC_EFFECT.put(i + string.Empty, v);
		}
	}

	public static sbyte[] getSequence(int id)
	{
		return ((DataEffect)ALL_DATA_DYNAMIC_EFFECT.get(id + string.Empty))?.sequence;
	}

	public bool canDestroy()
	{
		if (timeExist == -1)
		{
			return false;
		}
		return mSystem.currentTimeMillis() - timeExist >= 0 && index == 0;
	}

	public override void update()
	{
		try
		{
			sbyte[] sequence = getSequence(id);
			if (sequence != null)
			{
				index = (sbyte)((index + 1) % sequence.Length);
				if (index >= sequence.Length / 2 && dam > 0)
				{
					Canvas.gameScr.startFlyText("-" + dam, 0, x, y - 15, 1, -2);
					dam = 0;
				}
			}
		}
		catch (Exception)
		{
		}
		if (canDestroy())
		{
			wantDestroy = true;
		}
	}

	public override void paint(MyGraphics g)
	{
		DataEffect dataEffect = (DataEffect)ALL_DATA_DYNAMIC_EFFECT.get(id + string.Empty);
		if (dataEffect != null)
		{
			ImageIcon imgIcon = GameData.getImgIcon((short)(id + 8700));
			if (imgIcon != null && imgIcon.img != null)
			{
				sbyte[] sequence = getSequence(id);
				dataEffect.paint(g, sequence[index], x, y, 0, imgIcon.img);
			}
		}
	}

	public override void setPosTo(short x, short y)
	{
	}
}
