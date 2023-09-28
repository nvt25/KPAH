public abstract class Actor
{
	public static sbyte CAT_PLAYER;

	public static sbyte CAT_MONSTER = 1;

	public static sbyte CAT_NPC = 2;

	public static sbyte CAT_ITEM = 3;

	public static sbyte CAT_POTION = 4;

	public static sbyte CAT_PARTY = 5;

	public static sbyte CAT_GEM_ITEM = 6;

	public static sbyte CAT_SPECIAL_ITEM = 7;

	public static sbyte CAT_MY_GROUND = 10;

	public static sbyte CAT_MY_TREE = 11;

	public static sbyte CAT_MY_PET = 12;

	public static sbyte CAT_TREE = 13;

	public static sbyte CAT_ITEM_QUEST = 14;

	public static sbyte CAT_EXPLOTION = 126;

	public static int CAT_CAN_NOT_FOCUS = 127;

	public bool wantDestroy;

	public int hp;

	public int maxhp;

	public sbyte catagory;

	public short ID = 32001;

	public short idClan = -1;

	public short IDParty = -1;

	public short IDMasterParty = -1;

	public short x;

	public short y;

	public short height;

	public short width;

	public short xFirst;

	public short yFirst;

	public short centerX;

	public short centerY;

	public short killer;

	public sbyte pk = -1;

	public sbyte nationID = -1;

	public sbyte typeLimit;

	public sbyte inCountry = -1;

	public sbyte state;

	public string nameUserTrade = string.Empty;

	public bool isWearing;

	public bool isMaininfo;

	public bool beStune;

	public bool isFocus;

	public bool iskiller;

	public long timeBeStune;

	public ChatPopup chat;

	public string infoGround;

	public bool isDie;

	public bool canfocus = true;

	public int timeLive = -1;

	public mVector buff = new mVector();

	public short poinson;

	public long timeOutPoinson;

	public short tDelay;

	public bool die;

	public long testmove = mSystem.currentTimeMillis();

	public virtual void paint(MyGraphics g)
	{
	}

	public virtual void actorDie()
	{
	}

	public virtual void setPosTo(short x, short y)
	{
	}

	public virtual void createBuff(int typeBuffEff, int timeLive)
	{
	}

	public virtual void update()
	{
		if (chat != null)
		{
			chat.setPos(x, y - height - 10);
			if (chat.setOut())
			{
				chat = null;
			}
		}
	}

	public virtual bool isDropItem()
	{
		return false;
	}

	public virtual void addBuff(CharBuff b)
	{
		for (int i = 0; i < buff.size(); i++)
		{
			CharBuff charBuff = (CharBuff)buff.elementAt(i);
			if (charBuff.type == b.type)
			{
				buff.removeElementAt(i);
				break;
			}
		}
		buff.addElement(b);
	}

	public virtual bool isPaint()
	{
		return true;
	}

	public virtual void setType(short type)
	{
	}

	public virtual int checkMagicShield(int dam)
	{
		return 0;
	}

	public virtual void paintCorner(MyGraphics g, int xCorner, int yCorner)
	{
		g.translate(-x + xCorner, -y + yCorner);
		paint(g);
	}

	public virtual void paintActive(MyGraphics g, int x, int y)
	{
	}

	public virtual void paintName(MyGraphics g)
	{
		if (chat != null)
		{
			chat.paintAnimal(g);
		}
	}

	public virtual string getDisplayName()
	{
		return "Actor C=" + catagory + " ID=" + ID;
	}

	public virtual bool allwayPaint()
	{
		return false;
	}

	public virtual void dead()
	{
	}

	public virtual int getX()
	{
		return x;
	}

	public virtual int getY()
	{
		return y;
	}

	public virtual bool isNPC()
	{
		return false;
	}

	public virtual bool isMonster()
	{
		return false;
	}

	public virtual bool isMineral()
	{
		return false;
	}

	public virtual bool isPlayer()
	{
		return false;
	}

	public virtual bool isItemCanGet()
	{
		return false;
	}

	public virtual int isNpcQuest()
	{
		return -1;
	}

	public virtual int getNpcType()
	{
		return 0;
	}

	public virtual int getTypeNpc()
	{
		return 32000;
	}

	public virtual bool isNpcChar()
	{
		return false;
	}

	public virtual void setIdSkill(int idSkill)
	{
	}

	public virtual void setByMap(int type)
	{
	}

	public virtual void setNewMonster(int isNewMonster)
	{
	}

	public virtual void setIdThanThu(int id)
	{
	}

	public virtual int getIdThanThu()
	{
		return -1;
	}

	public virtual int getHp()
	{
		return 0;
	}

	public virtual int getRealHp()
	{
		return 0;
	}

	public virtual void setState(int state)
	{
	}

	public virtual short getSpeed()
	{
		return 0;
	}

	public virtual sbyte getState()
	{
		return 0;
	}

	public virtual short getDir()
	{
		return 0;
	}

	public virtual string getCharName()
	{
		return string.Empty;
	}

	public virtual bool ispetTool()
	{
		return false;
	}

	public virtual void addEffbuff(int id, int x, int y, long timelive)
	{
	}

	public virtual void petAttack(mVector target, sbyte type, short idSkill, int[] dame, int[] hpcon)
	{
	}

	public virtual void setHP(int hp)
	{
	}

	public virtual void addEffectSkillTime(int id, int x, int y, long timelive, bool canmove, bool canpaint, bool canfight, int loop, sbyte WaitLoop, sbyte dyhorse)
	{
	}

	public virtual void setHorse(int idhorse, int typehorse)
	{
	}

	public virtual void setWeapon(int id, int type, int idImg)
	{
	}

	public virtual void setPartWearing(short idHair, short idBody, short idLeg)
	{
	}

	public virtual void setEff(short[] arrID, sbyte[] arrTick)
	{
	}

	public virtual short getyHorse()
	{
		return 0;
	}

	public virtual short getx()
	{
		return 0;
	}

	public virtual short gety()
	{
		return 0;
	}
}
