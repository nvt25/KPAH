using System;

public class Pet : AnimalMove
{
	public const sbyte ROAM = 0;

	public const sbyte FOLLOW = 1;

	public const sbyte ATTACK = 2;

	public const sbyte RETURN = 3;

	public const sbyte WAIT = 4;

	public const sbyte DEATH = 5;

	public const sbyte ATTRACTION = 6;

	protected const sbyte DIS_TO_ATTRACT = 80;

	protected const sbyte DIS_TO_FOLLOW = 40;

	public const sbyte M_STAND = 0;

	public const sbyte M_DEAD = 1;

	public const sbyte M_WALK = 2;

	public const sbyte M_ATTACK = 3;

	public const sbyte AC_STAND = 0;

	public const sbyte AC_MOVE = 1;

	public const sbyte AC_FIRE = 2;

	public const sbyte AC_HIT = 3;

	public const sbyte AC_DIE = 4;

	public const sbyte DIR_UP = 1;

	public const sbyte DIR_DOWN = 0;

	public const sbyte DIR_LEFT = 2;

	public const sbyte DIR_RIGHT = 3;

	protected bool isSequenceAttack;

	protected bool isDoneAttack;

	protected sbyte imageId;

	protected sbyte Action;

	protected sbyte preState;

	protected sbyte attackType;

	protected int attackCount;

	protected int oldPosX;

	protected int oldPosY;

	protected int ownerX;

	protected new int p1;

	protected int ownerY;

	protected int time;

	protected int timeAutoAction;

	protected int vx;

	protected int vy;

	protected int xAnchor;

	protected int yAnchor;

	protected int limitMove;

	public int xtam;

	public int vatam = 6;

	public new int vMax;

	public int idTemplate;

	public short yfly;

	public short range;

	public short dyattack;

	public short idSkill;

	public sbyte typemove;

	public sbyte f;

	public sbyte mAction;

	protected mVector wayPoint = new mVector();

	private mVector ntarget = new mVector();

	protected Actor owner;

	public static sbyte[] mTypemove = new sbyte[6]
	{
		2,
		1,
		0,
		2,
		0,
		1
	};

	private bool isBeginAttack;

	private sbyte huongY;

	private sbyte flip;

	private new sbyte frame;

	public static MyHashTable ALL_PET_DATA = new MyHashTable();

	private int toX;

	private int toY;

	private int cmove;

	private bool isRunAttack;

	public long timeBeginMoveAttack;

	public int[] arrdame;

	public int[] arrhpcon;

	private sbyte typeAttack;

	public int maxAttack;

	public Pet(Char mowner, int idtemplate)
	{
		idTemplate = idtemplate;
		owner = mowner;
		xAnchor = owner.x;
		yAnchor = owner.y;
		x = owner.x;
		y = owner.y;
		oldPosX = owner.x;
		oldPosY = owner.y;
		limitMove = 48;
		dir = 0;
		vMax = 4;
		speed = (short)(owner.getSpeed() - 1);
		state = 0;
		Action = 0;
		mAction = 0;
		range = 30;
		timeAutoAction = Res.random(200, 250);
		catagory = Actor.CAT_MY_PET;
		ID = owner.ID;
	}

	public Pet(int idtemplate)
	{
		idTemplate = idtemplate;
		dir = 0;
		state = 0;
		Action = 0;
		mAction = 0;
		range = 30;
		timeAutoAction = Res.random(200, 250);
		catagory = Actor.CAT_MY_PET;
	}

	public Pet(short typePet, byte nFrame, byte imageId, byte typemove)
	{
	}

	public void loadpetData()
	{
	}

	public void setAnim()
	{
	}

	public void clearWayPoints()
	{
		wayPoint.removeAllElements();
	}

	public void setState(sbyte state)
	{
		base.state = state;
	}

	public override void paint(MyGraphics g)
	{
		try
		{
			mDataEffect mDataEffect = (mDataEffect)ALL_PET_DATA.get(string.Empty + idTemplate);
			if (mDataEffect != null && mDataEffect != null)
			{
				int action = mAction;
				if (state == 2 && isBeginAttack)
				{
					action = 3;
				}
				sbyte[] dxDyShadow = mDataEffect.getDxDyShadow(mDataEffect.getFrame(frame, action, huongY));
				if (isFly())
				{
					int x = base.x + dxDyShadow[0];
					int y = base.y + dxDyShadow[1];
					g.drawImage(GameScr.petShadow, x, y, 0);
				}
				else
				{
					int x2 = base.x + dxDyShadow[0];
					int y2 = base.y + dxDyShadow[1];
					g.drawImage(GameScr.petShadow, x2, y2, 0);
				}
				if (width == 0 || height == 0)
				{
					width = mDataEffect.getWith();
					height = mDataEffect.getHeight();
				}
				ImageIcon imgIcon = GameData.getImgIcon((short)(idTemplate + 8700));
				if (imgIcon != null && imgIcon.img != null)
				{
					mDataEffect.paintPet(g, mDataEffect.getFrame(frame, action, huongY), base.x, base.y, flip, imgIcon.img, dyattack);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public bool isFly()
	{
		mDataEffect mDataEffect = (mDataEffect)ALL_PET_DATA.get(string.Empty + idTemplate);
		if (mDataEffect != null && mDataEffect.isFly <= -5)
		{
			return true;
		}
		return false;
	}

	protected void roam()
	{
		vMax = 1;
		if (Action == 1)
		{
			if (time > timeAutoAction || Res.random(16) == 0 || Util.getDistance(x + vx, y + vy, xAnchor, yAnchor) >= limitMove)
			{
				time = 0;
				Action = 0;
				mAction = 0;
				vx = 0;
				vy = 0;
			}
		}
		else if (Action == 0)
		{
			vx = 0;
			vy = 0;
			if (time > timeAutoAction / 2 || Res.random(12) == 0)
			{
				time = 0;
				Action = 1;
				mAction = 2;
				dir = (short)Res.random(4);
				setSpeedInDirection(vMax);
			}
		}
		if (owner != null)
		{
			if (owner.getState() == 1 && Util.getDistance(x, y, ownerX, ownerY) > 40)
			{
				setState(1);
			}
			if (owner.getState() == 0 && Util.getDistance(x, y, ownerX, ownerY) > limitMove * 2)
			{
				setState(3);
			}
		}
		else
		{
			int distance = Util.getDistance(x, y, Canvas.gameScr.mainChar.x, Canvas.gameScr.mainChar.y);
			if (distance < 80 && distance > 40 && Res.random(6) == 0)
			{
				setState(6);
			}
		}
	}

	public void setSpeedInDirection(int max)
	{
		int x = Res.random_Am_0(3);
		if (Util.abs(x) > 1)
		{
			max--;
		}
		switch (dir)
		{
		case 1:
			vy = -max;
			vx = x;
			break;
		case 0:
			vy = max;
			vx = x;
			break;
		case 2:
			vy = x;
			vx = -max;
			break;
		case 3:
			vy = x;
			vx = max;
			break;
		}
		if (vx == 0 && Res.random(3) == 0)
		{
			time = 0;
			state = 0;
			vx = 0;
			vy = 0;
			mAction = 0;
		}
		if (vx > 0)
		{
			dir = 3;
		}
		else
		{
			dir = 2;
		}
		huongY = (sbyte)((vy > 0) ? 1 : 0);
		flip = (sbyte)((vx <= 0) ? 2 : 0);
		flip = 0;
		if (dir == Char.RIGHT)
		{
			flip = 2;
		}
		else if (dir != Char.LEFT)
		{
			if (dir == Char.DOWN)
			{
				huongY = 0;
			}
			else if (dir == Char.UP)
			{
				huongY = 1;
			}
		}
		mAction = 2;
	}

	public void setHuong(int xto, int yto)
	{
		huongY = (sbyte)((y > yto) ? 1 : 0);
		flip = (sbyte)((x - xto <= 0) ? 2 : 0);
		flip = 0;
		if (dir == Char.RIGHT)
		{
			flip = 2;
		}
		else if (dir != Char.LEFT)
		{
			if (dir == Char.DOWN)
			{
				huongY = 0;
			}
			else if (dir == Char.UP)
			{
				huongY = 1;
			}
		}
	}

	protected void standStill()
	{
		vx = 0;
		vy = 0;
		state = 4;
		if (owner != null && owner.getState() == 0)
		{
			setState(0);
		}
	}

	protected void follow()
	{
		vMax = owner.getSpeed();
		Action = 1;
		if (wayPoint.size() <= 0)
		{
			cmove++;
			if (cmove > 20)
			{
				setState(0);
			}
		}
		if (Util.getDistance(oldPosX, oldPosY, ownerX, ownerY) > 40)
		{
			Point o = new Point(ownerX, ownerY);
			oldPosX = ownerX;
			oldPosY = ownerY;
			wayPoint.addElement(o);
		}
		else if (Util.getDistance(x, y, xAnchor, yAnchor) < 40)
		{
			wayPoint.removeAllElements();
			setState(4);
		}
		if (wayPoint.size() > 0 && wayPoint.elementAt(0) != null)
		{
			toX = ((Point)wayPoint.elementAt(0)).x;
			toY = ((Point)wayPoint.elementAt(0)).y;
			setHuong(toX, toY);
			move_to_XY();
		}
	}

	public void move_to_XY()
	{
		int num = Math.abs(x - toX);
		int num2 = Math.abs(y - toY);
		if (num <= speed)
		{
			x = (short)toX;
		}
		if (num2 < speed)
		{
			y = (short)toY;
		}
		if (x < toX)
		{
			x += speed;
			dir = Char.RIGHT;
		}
		else if (x > toX)
		{
			x -= speed;
			dir = Char.LEFT;
		}
		else if (y > toY)
		{
			y -= speed;
			dir = Char.UP;
		}
		else if (y < toY)
		{
			dir = Char.DOWN;
			y += speed;
		}
		huongY = (sbyte)((vy > 0) ? 1 : 0);
		flip = (sbyte)((vx <= 0) ? 2 : 0);
		flip = 0;
		if (dir == Char.RIGHT)
		{
			flip = 2;
		}
		else if (dir != Char.LEFT)
		{
			if (dir == Char.DOWN)
			{
				huongY = 0;
			}
			else if (dir == Char.UP)
			{
				huongY = 1;
			}
		}
		if (state != 3 && (owner.getDir() == Char.UP || owner.getDir() == Char.DOWN))
		{
			xtam += vatam;
			if (vatam > 0)
			{
				dir = 3;
			}
			if (vatam < 0)
			{
				dir = 2;
			}
			if ((xtam + vatam >= 48 && vatam > 0) || (xtam + vatam < -48 && vatam < 0))
			{
				vatam *= -1;
			}
		}
	}

	public void initAttackState(sbyte skillId)
	{
		try
		{
			attackType = skillId;
			isRunAttack = true;
			timeBeginMoveAttack = mSystem.currentTimeMillis();
			attackCount = 0;
			isSequenceAttack = false;
		}
		catch (Exception)
		{
		}
	}

	public override void petAttack(mVector target, sbyte type, short idSkill, int[] dame, int[] hpcon)
	{
		state = 2;
		ntarget = target;
		typeAttack = type;
		this.idSkill = idSkill;
		arrdame = dame;
		arrhpcon = hpcon;
	}

	protected new void attack()
	{
		if (ntarget != null && ntarget.size() > 0)
		{
			Actor actor = (Actor)ntarget.elementAt(0);
			if (actor == null)
			{
				setState(1);
				return;
			}
			if (Util.getDistance(x + speed, y + speed, actor.x, actor.y) > range && !isBeginAttack && actor.getHp() > 0)
			{
				toX = actor.x;
				toY = actor.y;
				setHuong(toX, toY);
				move_to_XY();
				mAction = 2;
				if (dyattack < 40 && isFly())
				{
					dyattack++;
				}
			}
			else
			{
				isBeginAttack = true;
			}
			if (!isBeginAttack)
			{
				return;
			}
			if (dyattack < 50 && isFly())
			{
				dyattack += 10;
			}
			p1++;
			if (p1 <= 6)
			{
				return;
			}
			p1 = 0;
			isBeginAttack = false;
			setState(4);
			for (int i = 0; i < ntarget.size(); i++)
			{
				Actor actor2 = (Actor)ntarget.elementAt(i);
				if (actor2 != null)
				{
					Canvas.gameScr.startFlyText(arrdame[i] + string.Empty, 0, actor2.x, actor2.y - 15, 1, -2);
					actor2.setHP(arrhpcon[i]);
					actor2.addEffectSkillTime(idSkill, actor2.x, actor2.y, 0L, canmove: false, canpaint: false, canfight: false, 0, 0, 0);
				}
			}
		}
		else
		{
			p1++;
			isBeginAttack = true;
			if (p1 > 6)
			{
				p1 = 0;
				isBeginAttack = false;
				setState(4);
			}
		}
	}

	protected void returnToPlayer()
	{
		vMax = owner.getSpeed();
		toX = owner.x;
		toY = owner.y;
		setHuong(toX, toY);
		move_to_XY();
		if (Util.getDistance(x, y, xAnchor, yAnchor) < 40 && owner.getState() != 2)
		{
			setState(0);
		}
	}

	protected void waitForCommand()
	{
		vx = 0;
		vy = 0;
		Action = 1;
		if (owner != null)
		{
			if (owner.getState() == 0)
			{
				wayPoint.removeAllElements();
				setState(0);
			}
			else if (owner.getState() == 1 && Util.getDistance(x, y, xAnchor, yAnchor) > 40)
			{
				wayPoint.removeAllElements();
				setState(1);
			}
		}
	}

	public void addAttackEffect()
	{
	}

	private void attract()
	{
		vMax = 3;
		state = 1;
		toX = Canvas.gameScr.mainChar.x;
		toY = Canvas.gameScr.mainChar.y;
		move_to_XY();
		if (Util.getDistance(x, y, toX, toY) < 40)
		{
			setState(0);
		}
	}

	public void doChangeFrmaeBoss()
	{
		mDataEffect mDataEffect = (mDataEffect)ALL_PET_DATA.get(string.Empty + idTemplate);
		if (mDataEffect != null)
		{
			int action = mAction;
			if (state == 2 && isBeginAttack)
			{
				action = 3;
			}
			frame = (sbyte)((frame + 1) % mDataEffect.getAnim(action, huongY).frame.Length);
			if (maxAttack == 0)
			{
				maxAttack = mDataEffect.getAnim(3, huongY).frame.Length;
			}
		}
	}

	public void updateMenu()
	{
		if (Canvas.gameTick % 2 == 0)
		{
			f = (sbyte)((f + 1) % 3);
		}
		if (state != 2)
		{
			x += (short)vx;
			y += (short)vy;
		}
		doChangeFrmaeBoss();
		if (Canvas.gameTick % 200 == 0)
		{
			state = 2;
		}
		if (state == 2)
		{
			attack();
		}
	}

	public override void update()
	{
		try
		{
			if (!isBeginAttack && dyattack > 0)
			{
				dyattack -= 3;
				if (dyattack < 0)
				{
					dyattack = 0;
				}
			}
			if (Canvas.gameTick % 2 == 0)
			{
				f = (sbyte)((f + 1) % 3);
			}
			if (state != 2)
			{
				x += (short)vx;
				y += (short)vy;
			}
			doChangeFrmaeBoss();
			if (owner != null)
			{
				if (Util.getDistance(x, y, toX, toY) <= 10 && wayPoint.size() > 0)
				{
					wayPoint.removeElementAt(0);
				}
				xAnchor = owner.x;
				yAnchor = owner.y;
				ownerX = owner.x;
				ownerY = owner.y;
			}
			time++;
			if (state != preState)
			{
				preState = state;
			}
			switch (state)
			{
			case 5:
				break;
			case 0:
				roam();
				break;
			case 1:
				mAction = 2;
				follow();
				break;
			case 2:
				attack();
				break;
			case 3:
				returnToPlayer();
				mAction = 2;
				break;
			case 4:
				mAction = 0;
				waitForCommand();
				break;
			case 6:
				attract();
				break;
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	public bool canFocus()
	{
		return false;
	}

	public void startAttack(mVector target, int idskill)
	{
		state = 2;
	}

	public void setidTemplatePet(short id)
	{
		idTemplate = id;
	}

	public void petAttack(sbyte idSkill, mVector ntarget, int[] dame, short range)
	{
		this.range = range;
		this.idSkill = idSkill;
		this.ntarget = ntarget;
		state = 2;
		dyattack = 0;
	}

	public bool isMypet()
	{
		return owner.ID == Canvas.gameScr.mainChar.ID;
	}

	public int getIDTem()
	{
		return idTemplate;
	}

	public new void setPosTo(short x, short y)
	{
	}

	public short getOwnerID()
	{
		return ID;
	}

	public override bool ispetTool()
	{
		return true;
	}
}
