public abstract class IArrow
{
	public bool wantDestroy;

	public virtual void set(int type, int x, int y, int power, sbyte effect, LiveActor owner, LiveActor target)
	{
	}

	public virtual void setAngle(int angle)
	{
	}

	public virtual void update()
	{
	}

	public virtual void paint(MyGraphics g)
	{
	}

	public virtual void onArrowTouchTarget()
	{
	}
}
