public class EffectObj : Actor
{
	public new short ID;

	public short dx;

	public short dy;

	public short idPlayer;

	public sbyte style;

	public sbyte index;

	public EffectObj()
	{
		dx = (dy = 0);
		catagory = 100;
		index = 0;
	}

	public override void update()
	{
		EffectData effect = EffectServerManager.getEffect(ID);
		if (effect != null)
		{
			index++;
			if (index >= effect.arrFrame.Length)
			{
				remove();
			}
		}
		else
		{
			remove();
		}
	}

	public override void paint(MyGraphics g)
	{
		EffectData effect = EffectServerManager.getEffect(ID);
		if (effect == null)
		{
			return;
		}
		if (style == 0)
		{
			Actor actor = Canvas.gameScr.findActorByID(idPlayer);
			if (actor != null)
			{
				x = (short)(actor.x + dx);
				y = (short)(actor.y + dy);
			}
		}
		effect.paint(g, x, y, index);
	}

	private void remove()
	{
		Canvas.gameScr.actors.removeElement(this);
	}

	public override void setPosTo(short x, short y)
	{
	}
}
