public class EffectManager : mVector
{
	public static EffectManager lowEffects = new EffectManager();

	public static EffectManager hiEffects = new EffectManager();

	public void updateAll()
	{
		for (int num = size() - 1; num >= 0; num--)
		{
			Effect effect = (Effect)elementAt(num);
			if (effect != null)
			{
				effect.update();
				if (effect.wantDetroy)
				{
					effect = null;
					removeElementAt(num);
				}
			}
		}
	}

	public void paintAll(MyGraphics g)
	{
		for (int i = 0; i < size(); i++)
		{
			((Effect)elementAt(i))?.paint(g);
		}
	}

	public static void addHiEffect(int x, int y, int type)
	{
		hiEffects.addElement(new Effect(x, y, type));
	}

	public static void addHiEffect(Effect e)
	{
		hiEffects.addElement(e);
	}

	public static void addLowEffect(int x, int y, int type)
	{
		lowEffects.addElement(new Effect(x, y, type));
	}

	public static void addLowEffect(Effect ef)
	{
		lowEffects.addElement(ef);
	}
}
