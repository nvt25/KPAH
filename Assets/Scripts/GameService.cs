using System;
using System.IO;
using UnityEngine;

public class GameService : Cmd_message
{
	public ISession session;

	protected static GameService instance;

	public static GameService gI()
	{
		if (instance == null)
		{
			instance = new GameService();
		}
		return instance;
	}

	private Message init(sbyte cmd)
	{
		return new Message(cmd);
	}

	public void giveCard2NPC(int x, int y)
	{
		Message message = init(-25);
		try
		{
			message.writer().writeByte((sbyte)x);
			message.writer().writeByte((sbyte)y);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void dosendKhacMenu()
	{
		Message message = init(-76);
		try
		{
			message.writer().writeShort(-10000);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void playMiniGame(sbyte type, sbyte id)
	{
		Message message = init(-62);
		try
		{
			message.writer().writeByte(type);
			if (id != 100)
			{
				message.writer().writeByte(id);
			}
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void learnSkill(int cClass, int idSelect)
	{
		Message message = init(109);
		try
		{
			message.writer().writeByte((sbyte)cClass);
			message.writer().writeByte((sbyte)idSelect);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void unRideHorse(sbyte type)
	{
		Message message = init(108);
		try
		{
			message.writer().writeByte(type);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void setConfig(int type)
	{
		Message message = init(104);
		try
		{
			message.writer().writeByte((sbyte)type);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void onSendNapSMS(int type, string cardType, string cardID, string cardCode)
	{
		Message message = init(107);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeUTF(cardType);
			message.writer().writeUTF(cardID);
			message.writer().writeUTF(cardCode);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void requestGetListUser(int npcType, int shopID)
	{
		Message message = init(94);
		try
		{
			message.writer().writeByte(0);
			message.writer().writeByte((sbyte)npcType);
			message.writer().writeByte((sbyte)shopID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void requestGetListItem(int npcType, int shopID, int charID)
	{
		Message message = init(94);
		try
		{
			message.writer().writeByte(1);
			message.writer().writeByte((sbyte)npcType);
			message.writer().writeByte((sbyte)shopID);
			message.writer().writeShort((short)charID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void requestGetListItemMain(int npcType, int shopID, int charID)
	{
		Message message = init(94);
		try
		{
			message.writer().writeByte(2);
			message.writer().writeByte((sbyte)npcType);
			message.writer().writeByte((sbyte)shopID);
			message.writer().writeShort((short)charID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void requestSellItem(int typeNpc, int shopID, ItemInInventory itemSell, short real, int prize, bool isSelling)
	{
		Message message = init(92);
		try
		{
			message.writer().writeBoolean(isSelling);
			message.writer().writeByte((sbyte)typeNpc);
			message.writer().writeByte((sbyte)shopID);
			if (itemSell != null)
			{
				message.writer().writeShort(itemSell.itemID);
			}
			else
			{
				message.writer().writeShort(real);
			}
			message.writer().writeInt(prize);
			if (itemSell != null)
			{
				message.writer().writeByte(0);
			}
			else
			{
				message.writer().writeByte(1);
			}
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void requestBuyItemUser(int charID, int npcID, int shopID, int itemID, int type)
	{
		Message message = init(95);
		try
		{
			message.writer().writeByte((sbyte)npcID);
			message.writer().writeByte((sbyte)shopID);
			message.writer().writeShort((short)charID);
			message.writer().writeShort((short)itemID);
			message.writer().writeByte((sbyte)type);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendGetMonsterTEmplate(int idTemplate)
	{
		Message message = init(100);
		try
		{
			message.writer().writeShort((short)idTemplate);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendGetMonsterTEmplate(int type, int idTemplate)
	{
		Message message = init(100);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort((short)idTemplate);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void doUseSpecialItem(int realID)
	{
		Message message = init(86);
		try
		{
			message.writer().writeShort((short)realID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void buyItemShopSpecial(int id)
	{
		Message message = init(85);
		try
		{
			message.writer().writeByte((sbyte)id);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void moveUpBoard()
	{
		Message message = init(82);
		try
		{
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doMove2Map(sbyte index, int mapid)
	{
		Message message = init(79);
		try
		{
			message.writer().writeByte(index);
			message.writer().writeShort((short)mapid);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void addItemImbue(short itemID)
	{
		Message message = init(75);
		try
		{
			message.writer().writeShort(itemID);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void addGemItemImbue(short gemId, sbyte boVaoLayRa)
	{
		Message message = init(76);
		try
		{
			message.writer().writeShort(gemId);
			message.writer().writeByte(boVaoLayRa);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void repairItem(int id)
	{
		Message message = init(72);
		try
		{
			message.writer().writeByte((sbyte)id);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void requestImbue(int type)
	{
		Message message = init(71);
		try
		{
			message.writer().writeByte((sbyte)type);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
			UnityEngine.Debug.Log("loi tai requestImbue game service");
		}
	}

	public void doImbueItem(int ok)
	{
		Message message = init(77);
		try
		{
			message.writer().writeByte((sbyte)ok);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void login(string username, string pass, string version)
	{
		Message message = init(1);
		try
		{
			message.writer().writeUTF(username);
			message.writer().writeUTF(pass);
			message.writer().writeUTF(version);
			message.writer().writeUTF("nokia/1/1");
			message.writer().writeUTF(GameMidlet.client_Provider);
			message.writer().writeUTF(GameMidlet.provider);
			message.writer().writeUTF(GameMidlet.agent);
			message.writer().writeByte((sbyte)((!Main.isPC) ? 2 : 4));
			message.writer().writeShort((short)Canvas.w);
			message.writer().writeByte((sbyte)(Canvas.isLoadTileServer ? (-1) : 0));
			message.writer().writeByte(getInDexServer(ServerListScr.index));
			session.sendMessage(message);
			message.cleanup();
			Out.println((short)Canvas.w + ".w><><h ." + (short)Canvas.h);
		}
		catch (Exception)
		{
		}
	}

	public sbyte getInDexServer(int index)
	{
		if (index > ServerListScr.index_server.Length - 1)
		{
			return 0;
		}
		return ServerListScr.index_server[index];
	}

	public void requestKiller()
	{
		Message message = init(67);
		try
		{
			message.writer().writeByte(1);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void requestCreateParty(int charID)
	{
		Message message = init(48);
		try
		{
			message.writer().writeInt(charID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void invite2Party(int idUser)
	{
		Message message = init(49);
		try
		{
			message.writer().writeByte(0);
			message.writer().writeShort((short)idUser);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void trade(int idUser)
	{
		Message message = init(66);
		try
		{
			message.writer().writeByte(0);
			message.writer().writeShort((short)idUser);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendInfoAddFriend(int charID, int ok)
	{
		Message message = init(101);
		try
		{
			message.writer().writeShort((short)charID);
			message.writer().writeByte((sbyte)ok);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void getFriendList()
	{
		Message message = init(102);
		try
		{
			message.writer().writeByte(0);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void getDetailFriend(int charID)
	{
		Message message = init(102);
		try
		{
			message.writer().writeByte(1);
			message.writer().writeInt(charID);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void sendOk_notOkInviteTrafe(int userid, int ok)
	{
		Message message = init(66);
		try
		{
			message.writer().writeByte((sbyte)ok);
			message.writer().writeShort((short)userid);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendOkTrade(int userid)
	{
		Message message = init(66);
		try
		{
			message.writer().writeByte(4);
			message.writer().writeShort((short)userid);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendCancelTrade(int userid)
	{
		Message message = init(66);
		try
		{
			message.writer().writeByte(3);
			message.writer().writeShort((short)userid);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendAddItemTrade(short itemID, int type, int number)
	{
		Message message = init(66);
		try
		{
			message.writer().writeByte(2);
			message.writer().writeByte((sbyte)type);
			switch (type)
			{
			case 0:
				message.writer().writeShort(itemID);
				break;
			case 1:
				message.writer().writeByte((sbyte)itemID);
				message.writer().writeShort((short)number);
				break;
			case 2:
				message.writer().writeByte((sbyte)itemID);
				break;
			}
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void kickOutParty(int idUser, sbyte kickOrDel)
	{
		Message message = init(50);
		try
		{
			message.writer().writeByte(kickOrDel);
			message.writer().writeShort((short)idUser);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void joinParty(short idParty)
	{
		Message message = init(49);
		try
		{
			message.writer().writeShort(idParty);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void outParty(int isParty, int isUser)
	{
	}

	public void moveChar(int x, int y)
	{
		if (!Tilemap.isOfflineMap && !Tilemap.tileTypeAtPixel(x, y, 2) && y / 16 * Tilemap.w + x / 16 < Tilemap.type.Length)
		{
			Message message = init(4);
			try
			{
				message.writer().writeShort((short)x);
				message.writer().writeShort((short)y);
			}
			catch (Exception)
			{
			}
			session.sendMessage(message);
			message.cleanup();
		}
	}

	public void requestCharInfo(short actorID)
	{
		Message message = init(5);
		try
		{
			message.writer().writeShort(actorID);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void attackMonster(short id, sbyte skillType, sbyte effect, int dam, int crit, int haveBuffEff)
	{
		Message message = init(9);
		try
		{
			message.writer().writeShort(id);
			message.writer().writeByte(skillType);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void attackMultiMonster(short id, sbyte skillType, sbyte effect, int dam, int crit, int haveBuffEff, mVector mst)
	{
		Message message = init(106);
		try
		{
			message.writer().writeByte(skillType);
			message.writer().writeByte((sbyte)mst.size());
			for (int i = 0; i < mst.size(); i++)
			{
				message.writer().writeShort(((Actor)mst.elementAt(i)).ID);
			}
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void attackOtherPlayer(short id, sbyte skillType, sbyte effect, int dam, int crit, int haveBuffEff)
	{
		Message message = init(6);
		try
		{
			message.writer().writeShort(id);
			message.writer().writeByte(skillType);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void useBuff(short id, sbyte skillType, sbyte eff, short dam)
	{
		Message message = init(51);
		try
		{
			message.writer().writeByte(1);
			message.writer().writeShort(id);
			message.writer().writeByte(skillType);
			message.writer().writeByte(eff);
			message.writer().writeShort(dam);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void endBuff(short idchar, sbyte buffType)
	{
		Message message = init(51);
		try
		{
			message.writer().writeByte(0);
			message.writer().writeShort(idchar);
			message.writer().writeByte(buffType);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void requestMonsterInfo(short actorID)
	{
		Message message = init(7);
		try
		{
			message.writer().writeShort(actorID);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void ping()
	{
		Message message = init(11);
		message.cleanup();
	}

	public void setSession(ISession gi)
	{
		session = gi;
	}

	public void selectChar(int id, int type)
	{
		try
		{
			Message message = init(13);
			message.writer().writeByte((sbyte)type);
			message.writer().writeInt(id);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void createChar(string charName, int clazz, int headStyle, int gender, int idnation)
	{
		Message message = init(14);
		try
		{
			message.writer().writeUTF(charName);
			message.writer().writeByte((sbyte)clazz);
			message.writer().writeByte((sbyte)headStyle);
			message.writer().writeByte((sbyte)gender);
			message.writer().writeByte((sbyte)idnation);
			message.writer().writeByte(ServerListScr.index_server[ServerListScr.index]);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void setClientType()
	{
		Message message = init(-1);
		try
		{
			message.writer().writeByte(2);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void getDropableFromGround(sbyte catagory, short iD)
	{
		try
		{
			if (catagory == 3)
			{
				Message message = init(18);
				message.writer().writeShort(iD);
				session.sendMessage(message);
				message.cleanup();
			}
			else if (catagory == 4)
			{
				Message message2 = init(19);
				message2.writer().writeShort(iD);
				session.sendMessage(message2);
				message2.cleanup();
			}
			else if (catagory == 7 || catagory == 6)
			{
				Message message3 = init(-41);
				message3.writer().writeByte(catagory);
				message3.writer().writeShort(iD);
				session.sendMessage(message3);
				message3.cleanup();
			}
			else if (catagory == 14)
			{
				Message message4 = init(-65);
				message4.writer().writeShort(iD);
				session.sendMessage(message4);
			}
		}
		catch (IOException)
		{
		}
	}

	public void requestMainCharInfo()
	{
		Message message = init(88);
		try
		{
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
		message.cleanup();
	}

	public void sendRequestMainInfo(int me, int id)
	{
		Message message = init(-2);
		try
		{
			message.writer().writeByte((sbyte)me);
			message.writer().writeShort((short)id);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
		message.cleanup();
	}

	public void requestWearingInfo(int me, int id)
	{
		Message message = init(-3);
		try
		{
			message.writer().writeByte((sbyte)me);
			message.writer().writeShort((short)id);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
		message.cleanup();
	}

	public void buyTicket()
	{
		Message message = init(81);
		try
		{
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void requestItemInfo(short itemID, short id)
	{
		Message message = init(21);
		try
		{
			message.writer().writeShort(itemID);
			message.writer().writeShort(id);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void dobuyitemShopnew(sbyte id, short typeshop)
	{
		Message message = init(-76);
		try
		{
			message.writer().writeShort(typeshop);
			message.writer().writeByte(id);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void usePotion(int potionType)
	{
		Message message = init(22);
		try
		{
			message.writer().writeByte((sbyte)potionType);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void changeMap(int toM, int toX, int toY)
	{
		ChangScr.gI().setMap(toM, toX, toY);
		Canvas.gameScr.posBoss = null;
		Message message = init(12);
		try
		{
			message.writer().writeShort((short)toM);
			message.writer().writeShort((short)toX);
			message.writer().writeShort((short)toY);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void changeMapOK(int toM, int toX, int toY)
	{
		Message message = init(12);
		try
		{
			message.writer().writeShort((short)toM);
			message.writer().writeShort((short)toX);
			message.writer().writeShort((short)toY);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void requestNPCInfo(int type)
	{
		Message message = init(23);
		try
		{
			message.writer().writeByte((sbyte)type);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void requestNPCInfo(int type, int idType)
	{
		Message message = init(23);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeByte((sbyte)idType);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void buyGemItem(mVector item)
	{
		Message message = init(74);
		try
		{
			int num = 0;
			for (int i = 0; i < item.size(); i++)
			{
				GemTemp gemTemp = (GemTemp)item.elementAt(i);
				num += gemTemp.number;
			}
			message.writer().writeShort((short)num);
			for (int j = 0; j < item.size(); j++)
			{
				GemTemp gemTemp2 = (GemTemp)item.elementAt(j);
				for (int k = 0; k < gemTemp2.number; k++)
				{
					message.writer().writeShort(gemTemp2.id);
				}
			}
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void buyItem(mVector items)
	{
		Message message = init(24);
		try
		{
			message.writer().writeByte((sbyte)items.size());
			for (int i = 0; i < items.size(); i++)
			{
				ItemInInventory itemInInventory = (ItemInInventory)items.elementAt(i);
				ItemTemplate item = Res.getItem(itemInInventory.charClazz, itemInInventory.idTemplate);
				message.writer().writeByte(itemInInventory.catagory);
				message.writer().writeShort(item.id);
				message.writer().writeShort(1);
				if (itemInInventory.catagory == 3)
				{
					if (WindowInfoScr.gI().idClass >= 0)
					{
						message.writer().writeByte((sbyte)WindowInfoScr.gI().idClass);
					}
					else
					{
						message.writer().writeByte(item.clazz);
					}
				}
			}
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void buyPotion(mVector items)
	{
		Message message = init(24);
		try
		{
			message.writer().writeByte((sbyte)items.size());
			for (int i = 0; i < items.size(); i++)
			{
				ItemInInventory itemInInventory = (ItemInInventory)items.elementAt(i);
				message.writer().writeByte(4);
				message.writer().writeShort(itemInInventory.potionType);
				message.writer().writeShort(itemInInventory.number);
			}
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void chat(string text)
	{
		Message message = init(27);
		try
		{
			message.writer().writeUTF(text);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void finishPutItem2Bag()
	{
		Message message = init(70);
		try
		{
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void putItem2Bag(short itemID)
	{
		Message message = init(68);
		try
		{
			message.writer().writeShort(itemID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void getItemFromBag(short itemID)
	{
		Message message = init(69);
		try
		{
			message.writer().writeShort(itemID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void sellItem(short itemID)
	{
		Message message = init(28);
		try
		{
			message.writer().writeShort(itemID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void sellGemItem(short realID, sbyte khoa)
	{
		Message message = init(78);
		try
		{
			message.writer().writeShort(realID);
			message.writer().writeByte(khoa);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void useItem(short itemID)
	{
		Message message = init(29);
		try
		{
			message.writer().writeShort(itemID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void giveItemToGround(short itemID)
	{
		Message message = init(61);
		try
		{
			message.writer().writeShort(itemID);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void comeHomeWhenDie()
	{
		Message message = init(31);
		session.sendMessage(message);
		message.cleanup();
	}

	public void addBasePoint(int toWhatPoint, int point)
	{
		Message message = init(34);
		try
		{
			message.writer().writeByte((sbyte)toWhatPoint);
			message.writer().writeShort((short)point);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void addSkillPoint(int skillType)
	{
		Message message = init(36);
		try
		{
			message.writer().writeByte((sbyte)skillType);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (IOException)
		{
		}
	}

	public void requestRegister(string username, string pass)
	{
		Message message = init(39);
		try
		{
			message.writer().writeUTF(username);
			message.writer().writeUTF(pass);
			GameMidlet.client_Provider.Trim();
			message.writer().writeUTF(GameMidlet.client_Provider);
			message.writer().writeUTF(GameMidlet.provider);
			message.writer().writeUTF(GameMidlet.agent);
			message.writer().writeUTF(Canvas.IMEI);
			message.writer().writeInt(GameMidlet.verSionCode);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void receiveQuest(int idNPC, int idQuest, int type)
	{
		Message message = init(52);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeByte((sbyte)idNPC);
			message.writer().writeShort((short)idQuest);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
		message.cleanup();
	}

	public void talk_npc_response_quest(int idNpc, int type, int idQuest)
	{
		Message message = init(55);
		try
		{
			message.writer().writeByte((sbyte)idNpc);
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort((short)idQuest);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
		finally
		{
			try
			{
				message.cleanup();
			}
			catch (Exception)
			{
			}
		}
	}

	public void talk_npc(int idNpc, int type, int idQuest)
	{
		Message message = init(53);
		try
		{
			message.writer().writeByte((sbyte)idNpc);
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort((short)idQuest);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
		finally
		{
			try
			{
				message.cleanup();
			}
			catch (Exception)
			{
			}
		}
	}

	public void sendRequestAddClan(short id, sbyte type, bool iss)
	{
		Message message = init(-11);
		try
		{
			message.writer().writeByte(type);
			message.writer().writeShort(id);
			if (type == 1)
			{
				message.writer().writeBoolean(iss);
			}
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void sendMsgPrivate(string name, string text)
	{
		Message message = init(-5);
		try
		{
			message.writer().writeUTF(name);
			message.writer().writeUTF(text);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void removeFriend(string name)
	{
		Message message = init(-6);
		try
		{
			message.writer().writeUTF(name);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void requestClanList(int idClan, sbyte page)
	{
		Message message = init(-7);
		try
		{
			message.writer().writeByte(page);
			message.writer().writeShort((short)idClan);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void doGetImage(sbyte type, int ver)
	{
		Message message = init(-8);
		try
		{
			message.writer().writeByte(type);
			message.writer().writeByte((sbyte)ver);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void registerClan()
	{
		Message message = init(-9);
		session.sendMessage(message);
	}

	public void chooseIconClan(short index, string name)
	{
		Message message = init(-10);
		try
		{
			message.writer().writeShort(index);
			message.writer().writeUTF(name);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void requestClanInfo(int idClan)
	{
		Canvas.startWaitDlg();
		Message message = init(-12);
		try
		{
			message.writer().writeShort((short)idClan);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void requestEvictionClan(string name)
	{
		Message message = init(-13);
		try
		{
			message.writer().writeUTF(name);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void dissolveCLan()
	{
		Message message = init(-14);
		session.sendMessage(message);
	}

	public void outClan()
	{
		Message message = init(-15);
		session.sendMessage(message);
	}

	public void setSologan(string str)
	{
		Message message = init(-16);
		try
		{
			message.writer().writeUTF(str);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void msgClanAll(string str, sbyte type, int idUser)
	{
		Message message = init(-17);
		try
		{
			message.writer().writeByte(type);
			if (type == 0)
			{
				message.writer().writeUTF(str);
			}
			else if (type == 2)
			{
				message.writer().writeInt(idUser);
			}
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void chatToClan(string str)
	{
		Message message = init(-18);
		try
		{
			message.writer().writeUTF(str);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void requestTopStronger_Righer(int type, int page)
	{
		Canvas.startWaitDlg();
		Message message = init(-19);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeByte((sbyte)page);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void transMoney(int parseInt)
	{
		Message message = init(-20);
		try
		{
			message.writer().writeInt(parseInt);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void dellPotion(int potionType)
	{
		Message message = init(-21);
		try
		{
			message.writer().writeShort((short)potionType);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void requestSomeOneInfo(short id, sbyte type)
	{
		Message message = init(-22);
		try
		{
			message.writer().writeShort(id);
			message.writer().writeByte(type);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void dellGemItem(short id, int type, sbyte khoa)
	{
		Message message = init(-23);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort(id);
			if (type == 0)
			{
				message.writer().writeByte(khoa);
			}
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void requestString(int type)
	{
		Message message = init(-24);
		try
		{
			message.writer().writeByte((sbyte)type);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestWeapone(int type, int weaponType, int weaponStyle, sbyte weaponIndex)
	{
		Message message = init(-27);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeByte((sbyte)weaponType);
			message.writer().writeByte((sbyte)weaponStyle);
			message.writer().writeByte(weaponIndex);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doCapCha(string text)
	{
		Message message = init(-28);
		try
		{
			message.writer().writeUTF(text);
		}
		catch (IOException)
		{
			UnityEngine.Debug.Log("cap cha");
		}
		session.sendMessage(message);
	}

	public void doMenuOption(int userID, sbyte idMenu, int i)
	{
		Message message = init(-30);
		try
		{
			message.writer().writeShort((short)userID);
			message.writer().writeByte(idMenu);
			message.writer().writeByte((sbyte)i);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void doTextBox(int userID, sbyte idMenu, string text)
	{
		Message message = init(-31);
		try
		{
			message.writer().writeShort((short)userID);
			message.writer().writeByte(idMenu);
			message.writer().writeUTF(text);
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void doCustomPopup(int idB, sbyte idPopup, string text5, int ok)
	{
		Message message = init(-32);
		try
		{
			message.writer().writeShort((short)idB);
			message.writer().writeByte(idPopup);
			message.writer().writeUTF(text5);
			message.writer().writeByte((sbyte)ok);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doWayPoint(int x, int y, short type)
	{
		Message message = init(-33);
		try
		{
			message.writer().writeByte((sbyte)(x / 16));
			message.writer().writeByte((sbyte)(y / 16));
			message.writer().writeShort(type);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void requestKham(int type)
	{
		Message message = init(-34);
		try
		{
			message.writer().writeByte((sbyte)type);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doKhamItem(int i)
	{
		Message message = init(-35);
		try
		{
			message.writer().writeByte((sbyte)i);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void epNgoc(int type, mVector listTemp)
	{
		Message message = init(-36);
		try
		{
			message.writer().writeByte((sbyte)type);
			if (type == 1)
			{
				message.writer().writeByte((sbyte)listTemp.size());
				for (int i = 0; i < listTemp.size(); i++)
				{
					RealID realID = (RealID)listTemp.elementAt(i);
					message.writer().writeShort(realID.realID);
				}
			}
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void epDothu(mVector listTemp, sbyte[] listNL)
	{
		Message message = init(-61);
		try
		{
			message.writer().writeByte((sbyte)listTemp.size());
			for (int i = 0; i < listTemp.size(); i++)
			{
				ItemInInventory itemInInventory = (ItemInInventory)listTemp.elementAt(i);
				message.writer().writeShort(itemInInventory.itemID);
			}
			for (int j = 0; j < listNL.Length; j++)
			{
				message.writer().writeByte(listNL[j]);
			}
		}
		catch (IOException)
		{
		}
		session.sendMessage(message);
	}

	public void questClan(int type)
	{
		Message message = init(-37);
		try
		{
			message.writer().writeByte((sbyte)type);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRideAnimal(short id, sbyte typeAnimal)
	{
		Message message = init(-45);
		try
		{
			message.writer().writeByte(typeAnimal);
			message.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestSoundData(byte id)
	{
		Message message = new Message((sbyte)(-46));
		try
		{
			message.writer().writeByte((sbyte)id);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestImageMonster(int idTemplate, sbyte palate, sbyte sPalate)
	{
		Message message = new Message((sbyte)(-47));
		try
		{
			message.writer().writeByte(palate);
			message.writer().writeByte(sPalate);
			message.writer().writeShort((short)idTemplate);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void getTreeImage(int i, int typeClothes, int id)
	{
		Message message = new Message((sbyte)(-48));
		try
		{
			if (i == -1)
			{
				message.writer().writeByte((sbyte)i);
				message.writer().writeByte((sbyte)typeClothes);
				message.writer().writeByte((sbyte)id);
			}
			else
			{
				message.writer().writeByte((sbyte)i);
			}
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestEffectData(short id3)
	{
		Message message = new Message((sbyte)(-49));
		try
		{
			message.writer().writeByte((sbyte)id3);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doCheDo(short size, short idItem, sbyte[][] arrNumber)
	{
		Message message = new Message((sbyte)(-52));
		try
		{
			message.writer().writeByte(WindowInfoScr.optionCreateItem);
			message.writer().writeShort(idItem);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < arrNumber[i].Length; j++)
				{
					message.writer().writeByte(arrNumber[i][j]);
				}
			}
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestTachNguyenLIeu(short idItem, int type, int idMaterial, int ilock)
	{
		Message message = new Message((sbyte)(-68));
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort(idItem);
			message.writer().writeShort((short)idMaterial);
			message.writer().writeByte((sbyte)ilock);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestThemThuocTinh(short idItem, int type, int idBot, int lockbot, int idDatiengiai, int lockda)
	{
		Message message = new Message((sbyte)(-68));
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort(idItem);
			message.writer().writeShort((short)idBot);
			message.writer().writeByte((sbyte)lockbot);
			message.writer().writeShort((short)idDatiengiai);
			message.writer().writeByte((sbyte)lockda);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void doRequestActionCheDo(int type, short idItem)
	{
		Message message = new Message((sbyte)(-52));
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort(idItem);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void requestQuanLyBang(short idClan)
	{
		Message message = new Message((sbyte)(-53));
		try
		{
			message.writer().writeShort(idClan);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void doGetImgIcon(short id)
	{
		Message message = new Message((sbyte)(-51));
		try
		{
			message.writer().writeShort(id);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void doRequestChangTypeItem(short itemID, int i)
	{
		Message message = new Message((sbyte)(-54));
		try
		{
			message.writer().writeByte((sbyte)i);
			message.writer().writeShort(itemID);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void sendGetImgIsanimal(int typeMonter, int idChar)
	{
		Message message = new Message((sbyte)(-57));
		try
		{
			message.writer().writeByte((sbyte)typeMonter);
			message.writer().writeShort((short)idChar);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void requestCharMonter(int idChar)
	{
		Message message = new Message((sbyte)(-57));
		try
		{
			message.writer().writeByte(-1);
			message.writer().writeShort((short)idChar);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void doPlant(sbyte type, sbyte idFarm)
	{
		Message message = new Message((sbyte)(-59));
		try
		{
			message.writer().writeByte(type);
			message.writer().writeByte(idFarm);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void sendTickets(sbyte num)
	{
		Message message = new Message((sbyte)(-63));
		try
		{
			message.writer().writeByte(num);
		}
		catch (Exception)
		{
		}
		session.sendMessage(message);
	}

	public void invite2Party(int idUser, int type)
	{
		Message message = init(49);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort((short)idUser);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void onStartLuckyDraw(int index)
	{
		Message message = new Message((sbyte)87);
		try
		{
			message.writer().writeByte((sbyte)index);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void onSendInfoQuest(int type, int idQuest, int mainsub)
	{
		Message message = new Message((sbyte)(-64));
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort((short)idQuest);
			message.writer().writeByte((sbyte)mainsub);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log(ex.Message);
		}
		session.sendMessage(message);
	}

	public void sendConfirmTrade()
	{
		Message message = init(66);
		try
		{
			message.writer().writeByte(5);
			session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception)
		{
		}
	}

	public void sendInfoFruit(int index, int type)
	{
		Message message = init(-66);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeByte((sbyte)index);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void douseGemItem(int idGemTemplate, sbyte locks)
	{
		Message message = init(-67);
		try
		{
			message.writer().writeShort((short)idGemTemplate);
			message.writer().writeByte(locks);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doAutoImbue(int idItem, mVector idGem, int plus, mVector mlock, int isauto)
	{
		Message message = init(-69);
		try
		{
			message.writer().writeShort((short)idItem);
			message.writer().writeByte((sbyte)plus);
			message.writer().writeByte((sbyte)idGem.size());
			for (int i = 0; i < idGem.size(); i++)
			{
				short value = short.Parse((string)idGem.elementAt(i));
				message.writer().writeShort(value);
				string s = (string)mlock.elementAt(i);
				message.writer().writeByte(sbyte.Parse(s));
			}
			message.writer().writeByte((sbyte)isauto);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doRequestSelItem(int type, int idItem, int price, int priceBid)
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte((sbyte)type);
			message.writer().writeShort((short)idItem);
			message.writer().writeInt(price);
			message.writer().writeInt(priceBid);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doBuyItemShopOnline(int id, int newItem_searchItem)
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte(3);
			message.writer().writeByte((sbyte)newItem_searchItem);
			message.writer().writeShort((short)id);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doBid(int index, int newItem_searchItem, int price)
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte(6);
			message.writer().writeByte((sbyte)newItem_searchItem);
			message.writer().writeShort((short)index);
			message.writer().writeInt(price);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doGetItemBackInventory(int index)
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte(4);
			message.writer().writeByte((sbyte)index);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doGetMoneySellInventory()
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte(5);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doSearchItemSell(int level, int typeItem, int colorItem, int pham, int cong)
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte(2);
			message.writer().writeByte((sbyte)level);
			message.writer().writeByte((sbyte)typeItem);
			message.writer().writeByte((sbyte)colorItem);
			message.writer().writeByte((sbyte)pham);
			message.writer().writeByte((sbyte)cong);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void doSearchByName(string name)
	{
		Message message = init(62);
		try
		{
			message.writer().writeByte(7);
			message.writer().writeUTF(name);
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}

	public void oninfoBydialog(string[] text)
	{
		Message message = init(-72);
		try
		{
			sbyte b = (sbyte)text.Length;
			message.writer().writeByte(b);
			for (int i = 0; i < b; i++)
			{
				message.writer().writeUTF(text[i]);
			}
			session.sendMessage(message);
		}
		catch (Exception)
		{
		}
	}
}
