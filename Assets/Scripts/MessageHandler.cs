using System;

public class MessageHandler : Cmd_message, IMessageHandler
{
	protected static MessageHandler instance;

	public static MessageHandler gI()
	{
		if (instance == null)
		{
			instance = new MessageHandler();
		}
		return instance;
	}

	public void onConnectOK()
	{
		Out.println("Conect Ok .");
		Canvas.gameScr.onConnectOK();
	}

	public void onConnectionFail()
	{
		Out.println("Conect fail");
		Canvas.gameScr.onConnectFail();
	}

	public void onDisconnected()
	{
		Out.println("Conect stop");
		Canvas.gameScr.onDisconnect();
	}

	public void onMessage(Message msg)
	{
		try
		{
			ItemDropInfo[] array = null;
			switch (msg.command)
			{
			case -72:
			case -58:
			case -54:
			case -46:
			case -45:
			case -44:
			case -40:
			case -29:
			case -28:
			case -25:
			case -23:
			case -21:
			case -16:
			case -15:
			case -14:
			case -6:
			case -4:
			case -3:
			case -2:
			case -1:
			case 0:
			case 29:
			case 31:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 53:
			case 55:
			case 63:
			case 70:
			case 74:
			case 75:
			case 79:
			case 84:
			case 88:
			case 93:
			case 96:
			case 97:
			case 98:
			case 99:
				break;
			case 57:
				break;
			case 91:
				break;
			case -76:
				Canvas.gameScr.onShopNew(msg);
				break;
			case -75:
				Canvas.gameScr.onCountDown(msg);
				break;
			case -74:
				Canvas.gameScr.onEffData(msg);
				break;
			case -73:
				Canvas.gameScr.onPetAttack(msg);
				break;
			case 62:
				Canvas.gameScr.onItemShopOnline(msg);
				break;
			case -68:
				Canvas.gameScr.onTachNguyenLieu(msg);
				break;
			case -69:
				Canvas.gameScr.onAutoImbue(msg);
				break;
			case -70:
				Canvas.gameScr.onNewEffect(msg);
				break;
			case -71:
				Canvas.gameScr.onDynamicEffect(msg);
				break;
			case -66:
				Canvas.gameScr.onFruit(msg);
				break;
			case -67:
				Canvas.gameScr.onTuBinh(msg);
				break;
			case -64:
				Canvas.gameScr.onQuest(msg);
				break;
			case 104:
				try
				{
					GameScr.loadConfig(msg.reader().readByte());
					int num2 = msg.reader().readByte();
				}
				catch (Exception ex2)
				{
					Out.println("LOI CHO NAY NE " + ex2.StackTrace);
				}
				break;
			case 103:
				Canvas.gameScr.onSMSStruct(msg);
				break;
			case 102:
				Canvas.gameScr.onFriendList(msg, 0, "BẠN BÈ");
				break;
			case 101:
				Canvas.gameScr.onInfoFriend(msg);
				break;
			case 95:
			{
				short itemID4 = msg.reader().readShort();
				short charID5 = msg.reader().readShort();
				sbyte type4 = msg.reader().readByte();
				Canvas.gameScr.onBuyItemOfUser(itemID4, charID5, type4);
				break;
			}
			case 94:
				Canvas.gameScr.onListInfoDepositeItem(msg);
				break;
			case 92:
				Canvas.gameScr.onUserSellItem(msg);
				break;
			case 72:
				Canvas.startOKDlg("Đã sửa xong.");
				break;
			case 89:
				Canvas.gameScr.onBuffAttack(msg);
				break;
			case 90:
				Canvas.gameScr.onActorDie(msg);
				break;
			case 82:
				Canvas.currentDialog = null;
				if (Canvas.gameScr.mainChar.delay <= 0)
				{
					Canvas.gameScr.mainChar.delay = msg.reader().readByte();
					Canvas.gameScr.mainChar.realTime = Canvas.gameScr.mainChar.delay;
					Canvas.gameScr.mainChar.timeWait2Board = mSystem.getCurrentTimeMillis();
				}
				break;
			case 81:
				Canvas.startOKDlg("Đã mua được vé");
				break;
			case 80:
				Res.XAPHU = new XaphuTemplate[msg.reader().readByte()];
				for (int num143 = 0; num143 < Res.XAPHU.Length; num143++)
				{
					Res.XAPHU[num143] = new XaphuTemplate();
					int num144 = msg.reader().readByte();
					Res.XAPHU[num143].mapID = new int[num144];
					for (int num145 = 0; num145 < Res.XAPHU[num143].mapID.Length; num145++)
					{
						Res.XAPHU[num143].mapID[num145] = msg.reader().readByte();
					}
					Res.XAPHU[num143].x = new int[num144];
					for (int num146 = 0; num146 < Res.XAPHU[num143].x.Length; num146++)
					{
						Res.XAPHU[num143].x[num146] = msg.reader().readShort();
					}
					Res.XAPHU[num143].y = new int[num144];
					for (int num147 = 0; num147 < Res.XAPHU[num143].y.Length; num147++)
					{
						Res.XAPHU[num143].y[num147] = msg.reader().readShort();
					}
					Res.XAPHU[num143].price = new int[num144];
					for (int num148 = 0; num148 < Res.XAPHU[num143].price.Length; num148++)
					{
						Res.XAPHU[num143].price[num148] = msg.reader().readShort();
					}
				}
				break;
			case 77:
				Canvas.gameScr.onImbueOK(msg.reader().readUTF());
				break;
			case -35:
				Canvas.gameScr.onImbueOK(msg.reader().readUTF());
				break;
			case -36:
				if (msg.reader().readByte() == 0)
				{
					Canvas.gameScr.onEpNgoc(msg.reader().readShort());
				}
				else
				{
					Canvas.gameScr.onImbueOK(msg.reader().readUTF());
				}
				break;
			case 85:
				Canvas.startOKDlg("Đã mua, món đồ đang ở trong hành trang.");
				break;
			case 86:
				switch (msg.reader().readByte())
				{
				case 1:
					Canvas.gameScr.mainChar.timeUseGolgTicket = mSystem.getCurrentTimeMillis();
					Char.idGoldTicket = msg.reader().readByte() - 1;
					Char.goldTimeMinute = 1440;
					Char.goldTime = msg.reader().readUTF();
					break;
				case 0:
					Canvas.gameScr.mainChar.timeUseGolgTicket = 0L;
					Char.goldTimeMinute = 0;
					Char.goldTime = string.Empty;
					break;
				case 2:
					Char.idGoldTicket = msg.reader().readByte() - 1;
					Canvas.gameScr.mainChar.timeUseGolgTicket = mSystem.getCurrentTimeMillis();
					Char.goldTimeMinute = msg.reader().readInt();
					Char.goldTime = msg.reader().readUTF();
					break;
				}
				break;
			case 73:
				Canvas.gameScr.onGemItem(msg);
				break;
			case 76:
				Canvas.gameScr.onSpecialItem(msg);
				break;
			case 71:
			{
				msg.reader().readByte();
				short priceImbue = msg.reader().readShort();
				sbyte khoa3 = 0;
				try
				{
					khoa3 = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onImbue(priceImbue, khoa3);
				break;
			}
			case -34:
			{
				short price = msg.reader().readShort();
				sbyte khoa2 = 0;
				try
				{
					khoa2 = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onKham(price, khoa2);
				break;
			}
			case 68:
				Canvas.gameScr.onPutItem2Bag(msg.reader().readShort());
				Canvas.endDlg();
				break;
			case 69:
				Canvas.gameScr.onGetItemFromBag(msg.reader().readShort());
				Canvas.endDlg();
				break;
			case 66:
			{
				sbyte b79 = msg.reader().readByte();
				if (b79 == 0)
				{
					Canvas.gameScr.onRequestTrade(msg.reader().readShort());
				}
				else if (b79 == -2)
				{
					Canvas.startOKDlg("Người bạn mời đang trao đổi với người khác");
				}
				else if (b79 == 1)
				{
					Canvas.gameScr.onOkTrade(msg.reader().readShort());
				}
				else if (b79 == -1)
				{
					Canvas.gameScr.onDeniedTrade(msg.reader().readShort());
				}
				else if (b79 == 2)
				{
					sbyte type3 = msg.reader().readByte();
					Canvas.gameScr.onItemTrade(msg.reader().readShort(), msg, type3);
				}
				else if (b79 == 3)
				{
					Canvas.gameScr.oncancelTrade();
				}
				else if (b79 == 4)
				{
					Canvas.gameScr.onFinishTrade();
				}
				else if (b79 == 5)
				{
					Canvas.gameScr.onConfirmTrade();
				}
				break;
			}
			case 67:
				Canvas.gameScr.onKiller(msg.reader().readShort(), msg.reader().readByte(), msg.reader().readShort());
				break;
			case 60:
				Canvas.gameScr.onNewHPMP(msg);
				break;
			case 65:
				Canvas.gameScr.onUseItemPK(msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte());
				break;
			case 2:
			{
				string text17 = msg.reader().readUTF();
				if (text17.StartsWith("2"))
				{
					if (!Main.isDisConnect)
					{
						string[] array27 = new string[msg.reader().readByte()];
						short[] array28 = new short[array27.Length];
						string[] array29 = new string[array27.Length];
						for (int num117 = 0; num117 < array27.Length; num117++)
						{
							array27[num117] = msg.reader().readUTF();
							array28[num117] = msg.reader().readShort();
							array29[num117] = msg.reader().readUTF();
						}
						Canvas.gameScr.listServer(text17.Substring(1), array27, array28, array29);
					}
					else
					{
						Command command4 = new Command("OK");
						ActionPerform actionPerform2 = command4.action = delegate
						{
							Canvas.endDlg();
							Canvas.instance.init();
							Session_ME.gI().close();
							Tilemap.loadMap(0, null);
							ServerListScr.gI().switchToMe();
						};
						Canvas.msgdlg.setInfo(text17.Substring(1), null, command4, null);
						Canvas.currentDialog = Canvas.msgdlg;
					}
				}
				else if (text17.StartsWith("3"))
				{
					string text18 = msg.reader().readUTF();
					string text19 = msg.reader().readUTF();
					GameMidlet.provider = text18;
					GameMidlet.agent = text19;
					RMS.saveRMSString("provider", text18);
					RMS.saveRMSString("agent", text19);
				}
				else
				{
					Canvas.gameScr.onLoginFail(text17);
				}
				break;
			}
			case 1:
			{
				Char.char_speed = msg.reader().readByte();
				if (Char.char_speed < 3)
				{
					Char.char_speed = 3;
				}
				GameScr.pTicket = msg.reader().readShort();
				Char.CHAR_POTION = msg.reader().readUnsignedByte();
				MainChar.listPotion = new Potion[Char.CHAR_POTION];
				Canvas.gameScr.mainChar.potionLastTimeUse = new long[Char.CHAR_POTION];
				for (int num210 = 0; num210 < Char.CHAR_POTION; num210++)
				{
					MainChar.listPotion[num210] = new Potion();
					MainChar.listPotion[num210].index = msg.reader().readUnsignedByte();
					MainChar.listPotion[num210].name = msg.reader().readUTF();
					MainChar.listPotion[num210].name2 = msg.reader().readUTF();
					MainChar.listPotion[num210].delay = msg.reader().readShort();
					MainChar.listPotion[num210].id = (short)num210;
					MainChar.listPotion[num210].isTrade = msg.reader().readBoolean();
				}
				for (int num211 = 0; num211 < Char.nSkill.Length; num211++)
				{
					Char.nSkill[num211] = msg.reader().readByte();
				}
				GameScr.infoNewSkill.removeAllElements();
				for (int num212 = 0; num212 < 5; num212++)
				{
					int num213 = msg.reader().readByte();
					mVector mVector12 = new mVector();
					for (int num214 = 0; num214 < num213; num214++)
					{
						InfoSkillLearn infoSkillLearn = new InfoSkillLearn();
						infoSkillLearn.idSkill = msg.reader().readByte();
						infoSkillLearn.name = msg.reader().readUTF();
						infoSkillLearn.decript = msg.reader().readUTF();
						infoSkillLearn.price = msg.reader().readInt();
						infoSkillLearn.charClass = (sbyte)num212;
						mVector12.addElement(infoSkillLearn);
					}
					GameScr.infoNewSkill.addElement(mVector12);
				}
				if (msg.reader().available() > 0)
				{
					GameScr.idMapPK = msg.reader().readShort();
					int num215 = msg.reader().readUnsignedByte();
					for (int num216 = 0; num216 < num215; num216++)
					{
						string o6 = msg.reader().readUnsignedByte() + string.Empty;
						WindowInfoScr.gI().potionShop.addElement(o6);
					}
					for (int num217 = 0; num217 < 5; num217++)
					{
						for (int num218 = 0; num218 < 5; num218++)
						{
							Char.mainDef[num217][num218] = msg.reader().readByte();
							Char.mainAt[num217][num218] = msg.reader().readByte();
							Char.pcAttack[num217][num218] = msg.reader().readByte();
							Char.pcDef[num217][num218] = msg.reader().readByte();
						}
					}
				}
				GameScr.xArena = msg.reader().readByte();
				GameScr.yArena = msg.reader().readByte();
				GameScr.wArena = msg.reader().readByte();
				GameScr.hArena = msg.reader().readByte();
				sbyte b90 = msg.reader().readByte();
				Res.khamProperty = new string[b90];
				Res.idNgocKham = new sbyte[b90];
				for (int num219 = 0; num219 < b90; num219++)
				{
					Res.khamProperty[num219] = msg.reader().readUTF();
					Res.idNgocKham[num219] = msg.reader().readByte();
				}
				string text21 = msg.reader().readUTF();
				if (!GameMidlet.numberSupport.Equals(text21))
				{
					GameMidlet.numberSupport = text21;
					RMS.saveRMSString("numbersupport", text21);
				}
				sbyte b91 = msg.reader().readByte();
				GameScr.TYPE_MP_HP[0] = new sbyte[b91];
				GameScr.TYPE_MP_HP[1] = new sbyte[b91];
				GameScr.VALUE_MP_HP[1] = new int[b91];
				GameScr.VALUE_MP_HP[0] = new int[b91];
				for (int num220 = 0; num220 < b91; num220++)
				{
					GameScr.TYPE_MP_HP[0][num220] = msg.reader().readByte();
					GameScr.VALUE_MP_HP[0][num220] = msg.reader().readInt();
					GameScr.TYPE_MP_HP[1][num220] = msg.reader().readByte();
					GameScr.VALUE_MP_HP[1][num220] = msg.reader().readInt();
				}
				int num221 = msg.reader().readByte();
				ItemQuest.NAME_ITEM = new string[num221];
				ItemQuest.ICON_IMG = new sbyte[num221];
				for (int num222 = 0; num222 < num221; num222++)
				{
					ItemQuest.ICON_IMG[num222] = msg.reader().readByte();
					ItemQuest.NAME_ITEM[num222] = msg.reader().readUTF();
				}
				GameMidlet.url = msg.reader().readUTF();
				sbyte b92 = msg.reader().readByte();
				for (int num223 = 0; num223 < b92; num223++)
				{
					short num224 = msg.reader().readShort();
					sbyte[] array39 = new sbyte[num224];
					for (int num225 = 0; num225 < num224; num225++)
					{
						array39[num225] = msg.reader().readByte();
					}
					RMS.saveRMS(Canvas.nameTile[num223], array39);
				}
				sbyte b93 = msg.reader().readByte();
				try
				{
					ThanThu.ALL_DATA_THAN_THU.clear();
					sbyte b94 = msg.reader().readByte();
					for (int num226 = 0; num226 < b94; num226++)
					{
						sbyte[] array40 = new sbyte[msg.reader().readShort()];
						for (int num227 = 0; num227 < array40.Length; num227++)
						{
							array40[num227] = msg.reader().readByte();
						}
						ThanThu.setDataThanThu(num226, array40);
					}
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onLoginSuccess();
				break;
			}
			case 3:
			{
				MainChar mainChar = Canvas.gameScr.mainChar;
				try
				{
					mainChar.ID = msg.reader().readShort();
					mainChar.name = msg.reader().readUTF();
					mainChar.wName = (short)MFont.smallFont.getWidth(mainChar.name);
					mainChar.hp = (mainChar.realHP = msg.reader().readInt());
					mainChar.maxhp = msg.reader().readInt();
					mainChar.mp = msg.reader().readInt();
					mainChar.maxmp = msg.reader().readInt();
					mainChar.currentHead = msg.reader().readByte();
					mainChar.clazz = msg.reader().readByte();
					mainChar.attack = msg.reader().readInt();
					mainChar.defend = msg.reader().readInt();
					mainChar.defend_magic = msg.reader().readInt();
					mainChar.accurate = msg.reader().readShort();
					mainChar.dodge = msg.reader().readShort();
					mainChar.critical = msg.reader().readShort();
					mainChar.he = msg.reader().readByte();
					mainChar.level = msg.reader().readByte();
					mainChar.lvpercent = msg.reader().readShort();
					mainChar.strength = msg.reader().readShort();
					mainChar.agility = msg.reader().readShort();
					mainChar.spirit = msg.reader().readShort();
					mainChar.health = msg.reader().readShort();
					mainChar.luck = msg.reader().readShort();
					mainChar.basePointLeft = msg.reader().readShort();
					mainChar.skillPointLeft = msg.reader().readShort();
					mainChar.dedicationPoint = msg.reader().readInt();
					mainChar.baokich = msg.reader().readShort();
					Char.skillLevelLearnt = new sbyte[msg.reader().readByte()];
					for (int num197 = 0; num197 < Char.skillLevelLearnt.Length; num197++)
					{
						Char.skillLevelLearnt[num197] = msg.reader().readByte();
					}
					mainChar.killer = msg.reader().readShort();
					if (mainChar.killer > 0)
					{
						mainChar.iskiller = true;
					}
					mainChar.gender = msg.reader().readByte();
					sbyte b83 = msg.reader().readByte();
					if (b83 >= 0)
					{
						mainChar.useHorse = (sbyte)(b83 - 1);
					}
					mainChar.anmFly = msg.reader().readByte();
					mainChar.idImgHorse = msg.reader().readByte();
					mainChar.speed = msg.reader().readByte();
					mainChar.idClan = msg.reader().readShort();
					if (mainChar.idClan != -1)
					{
						Canvas.gameScr.mainChar.isMaster = msg.reader().readByte();
					}
					if (Canvas.gameScr.mainChar.isMaster == 0)
					{
						Char.dissolved = msg.reader().readBoolean();
					}
					mainChar.isNo = msg.reader().readBoolean();
					mainChar.limItemBag = msg.reader().readByte();
					mainChar.nationID = msg.reader().readByte();
					mainChar.inCountry = msg.reader().readByte();
					mainChar.lienTram = msg.reader().readShort();
					mainChar.congTrang = msg.reader().readInt();
					mainChar.hoatdong = msg.reader().readShort();
					mainChar.pArena = msg.reader().readInt();
					mainChar.nameHusband_wife = msg.reader().readUTF();
					mainChar.paintHat = msg.reader().readBoolean();
					short num198 = -1;
					short num199 = -1;
					try
					{
						num198 = msg.reader().readShort();
						num199 = msg.reader().readByte();
					}
					catch (Exception)
					{
						num198 = -1;
						num199 = -1;
					}
					Canvas.gameScr.mainChar.setHorse(num198, num199);
					short num200 = -1;
					short num201 = -1;
					short num202 = -1;
					try
					{
						num200 = msg.reader().readShort();
						num201 = msg.reader().readByte();
						num202 = msg.reader().readShort();
					}
					catch (Exception)
					{
						num200 = -1;
						num201 = -1;
						num202 = -1;
					}
					Canvas.gameScr.mainChar.setWeapon(num200, num201, num202);
					short num203 = -1;
					short num204 = -1;
					short num205 = -1;
					try
					{
						num203 = msg.reader().readShort();
						num204 = msg.reader().readShort();
						num205 = msg.reader().readShort();
					}
					catch (Exception)
					{
						num203 = -1;
						num204 = -1;
						num205 = -1;
					}
					Canvas.gameScr.mainChar.setPartWearing(num203, num204, num205);
					sbyte b84 = -1;
					try
					{
						b84 = msg.reader().readByte();
						short[] array37 = new short[b84];
						sbyte[] array38 = new sbyte[b84];
						for (int num206 = 0; num206 < b84; num206++)
						{
							array37[num206] = msg.reader().readShort();
							array38[num206] = msg.reader().readByte();
						}
						Canvas.gameScr.mainChar.setEff(array37, array38);
						string text20 = msg.reader().readUTF();
						if (!text20.Equals(string.Empty))
						{
							WindowInfoScr.infoMainCharServer = Util.split(text20, "@");
						}
						else
						{
							WindowInfoScr.infoMainCharServer = null;
						}
					}
					catch (Exception)
					{
					}
					short num207 = -1;
					try
					{
						num207 = msg.reader().readShort();
					}
					catch (Exception)
					{
						num207 = -1;
					}
					sbyte b85 = -1;
					short num208 = -1;
					sbyte b86 = 0;
					sbyte b87 = 0;
					try
					{
						b85 = msg.reader().readByte();
						num208 = msg.reader().readShort();
						b86 = msg.reader().readByte();
						b87 = msg.reader().readByte();
					}
					catch (Exception)
					{
						b85 = -1;
						num208 = -1;
						b86 = 0;
						b87 = 0;
					}
					Canvas.gameScr.mainChar.indexPP = b85;
					Canvas.gameScr.mainChar.idImgPP = num208;
					Canvas.gameScr.mainChar.nFrameWP = b86;
					Canvas.gameScr.mainChar.nFramePP = b87;
					sbyte b88 = -1;
					short num209 = -1;
					sbyte b89 = 0;
					try
					{
						b88 = msg.reader().readByte();
						num209 = msg.reader().readShort();
						b89 = msg.reader().readByte();
					}
					catch (Exception)
					{
						b88 = -1;
						num209 = -1;
						b89 = 0;
					}
					Canvas.gameScr.mainChar.indexAVT = b88;
					Canvas.gameScr.mainChar.idImgAVT = num209;
					Canvas.gameScr.mainChar.nFrameAVT = b89;
					Canvas.gameScr.mainChar.idPhiPhong = num207;
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onMainCharInfo();
				break;
			}
			case 5:
				if (Canvas.gameScr.readyGetGameLogic)
				{
					short num75 = msg.reader().readShort();
					Char char3 = (Char)Canvas.gameScr.findCharByID(num75);
					if (char3 != null)
					{
						char3.ID = num75;
						if (char3.idBoss != -1)
						{
							char3.dir = 0;
						}
						char3.name = msg.reader().readUTF();
						char3.x = msg.reader().readShort();
						char3.y = msg.reader().readShort();
						char3.hp = msg.reader().readInt();
						char3.maxhp = msg.reader().readInt();
						char3.mp = msg.reader().readInt();
						char3.maxmp = msg.reader().readInt();
						char3.currentHead = msg.reader().readByte();
						char3.clazz = msg.reader().readByte();
						for (int num76 = 0; num76 < char3.buffType.Length; num76++)
						{
							char3.buffType[num76] = msg.reader().readByte();
						}
						for (int num77 = 0; num77 < char3.buffType.Length; num77++)
						{
							char3.countDown[num77] = msg.reader().readShort();
						}
						char3.killer = msg.reader().readShort();
						char3.pk = msg.reader().readByte();
						char3.defend = msg.reader().readShort();
						char3.defend_magic = msg.reader().readShort();
						char3.level = msg.reader().readByte();
						char3.he = msg.reader().readByte();
						sbyte b50 = msg.reader().readByte();
						if (b50 >= 0)
						{
							char3.useHorse = (sbyte)(b50 - 1);
						}
						char3.anmFly = msg.reader().readByte();
						char3.idImgHorse = msg.reader().readByte();
						char3.speed = msg.reader().readByte();
						char3.idClan = msg.reader().readShort();
						char3.idBoss = msg.reader().readByte();
						if (char3.idClan != -1)
						{
							char3.isMaster = msg.reader().readByte();
						}
						char3.idFashion = msg.reader().readByte();
						for (int num78 = 0; num78 < char3.idModel.Length; num78++)
						{
							char3.idModel[num78] = msg.reader().readShort();
						}
						char3.isNo = msg.reader().readBoolean();
						char3.setCharInfo();
						Canvas.gameScr.onCharInfo(char3);
						if (msg.reader().readBoolean())
						{
							Canvas.gameScr.gameService.requestCharMonter(char3.ID);
						}
						char3.nationID = msg.reader().readByte();
						char3.inCountry = msg.reader().readByte();
						char3.paintHat = msg.reader().readBoolean();
						short num79 = -1;
						short num80 = -1;
						try
						{
							num79 = msg.reader().readShort();
							num80 = msg.reader().readByte();
						}
						catch (Exception)
						{
							num79 = -1;
							num80 = -1;
						}
						char3.setHorse(num79, num80);
						short num81 = -1;
						short num82 = -1;
						short num83 = -1;
						try
						{
							num81 = msg.reader().readShort();
							num82 = msg.reader().readByte();
							num83 = msg.reader().readShort();
						}
						catch (Exception)
						{
							num81 = -1;
							num82 = -1;
							num83 = -1;
						}
						char3.setWeapon(num81, num82, num83);
						short num84 = -1;
						short num85 = -1;
						short num86 = -1;
						try
						{
							num84 = msg.reader().readShort();
							num85 = msg.reader().readShort();
							num86 = msg.reader().readShort();
						}
						catch (Exception)
						{
							num84 = -1;
							num85 = -1;
							num86 = -1;
						}
						char3.setPartWearing(num84, num85, num86);
						sbyte b51 = -1;
						try
						{
							b51 = msg.reader().readByte();
							short[] array16 = new short[b51];
							sbyte[] array17 = new sbyte[b51];
							for (int num87 = 0; num87 < b51; num87++)
							{
								array16[num87] = msg.reader().readShort();
								array17[num87] = msg.reader().readByte();
							}
							char3.setEff(array16, array17);
						}
						catch (Exception)
						{
						}
						short num88 = -1;
						try
						{
							num88 = msg.reader().readShort();
						}
						catch (Exception)
						{
							num88 = -1;
						}
						char3.idPhiPhong = num88;
						sbyte b52 = -1;
						short num89 = -1;
						sbyte b53 = 0;
						sbyte b54 = 0;
						try
						{
							b52 = msg.reader().readByte();
							num89 = msg.reader().readShort();
							b53 = msg.reader().readByte();
							b54 = msg.reader().readByte();
						}
						catch (Exception)
						{
							b52 = -1;
							num89 = -1;
							b53 = 0;
							b54 = 0;
						}
						char3.indexPP = b52;
						char3.idImgPP = num89;
						char3.nFrameWP = b53;
						char3.nFramePP = b54;
						sbyte b55 = -1;
						short num90 = -1;
						sbyte b56 = 0;
						try
						{
							b55 = msg.reader().readByte();
							num90 = msg.reader().readShort();
							b56 = msg.reader().readByte();
						}
						catch (Exception)
						{
							b55 = -1;
							num90 = -1;
							b56 = 0;
						}
						char3.indexAVT = b55;
						char3.idImgAVT = num90;
						char3.nFrameAVT = b56;
					}
				}
				break;
			case 12:
			{
				short map = msg.reader().readShort();
				short toX = msg.reader().readShort();
				short toY = msg.reader().readShort();
				sbyte idXaphu = -1;
				try
				{
					idXaphu = msg.reader().readByte();
				}
				catch (Exception ex30)
				{
					Out.LogError(ex30.StackTrace + " loi change map");
				}
				short mapLoad = msg.reader().readShort();
				string mapName = msg.reader().readUTF();
				sbyte[] array21 = null;
				try
				{
					if (msg.reader().readBoolean())
					{
						int num98 = 0;
						int num99 = 0;
						array21 = new sbyte[msg.reader().available()];
						for (int num100 = 0; num100 < array21.Length - num99; num100++)
						{
							array21[num100] = msg.reader().readByte();
						}
						num98 = array21.Length;
						num99 += num98;
					}
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onMap(map, toX, toY, mapLoad, mapName, array21);
				Tilemap.idXaphu = idXaphu;
				break;
			}
			case 4:
				while (msg.reader().available() > 0)
				{
					sbyte b48 = msg.reader().readByte();
					short type = msg.reader().readUnsignedByte();
					short actorID = msg.reader().readShort();
					short x3 = msg.reader().readShort();
					short y = msg.reader().readShort();
					sbyte pk = msg.reader().readByte();
					int charid = -1;
					sbyte isnewmonster = 0;
					try
					{
						charid = msg.reader().readInt();
					}
					catch (Exception)
					{
					}
					try
					{
						if (b48 == Actor.CAT_MONSTER)
						{
							isnewmonster = msg.reader().readByte();
						}
					}
					catch (Exception)
					{
					}
					sbyte isThanthu = -1;
					try
					{
						isThanthu = msg.reader().readByte();
					}
					catch (Exception)
					{
					}
					bool canfocus = true;
					try
					{
						canfocus = msg.reader().readBoolean();
					}
					catch (Exception)
					{
					}
					Canvas.gameScr.onActorMove(b48, type, actorID, x3, y, pk, charid, isnewmonster, isThanthu, canfocus);
				}
				break;
			case 8:
				while (msg.reader().available() > 0)
				{
					short charID2 = msg.reader().readShort();
					Canvas.gameScr.charOutGame(charID2);
				}
				break;
			case 7:
			{
				MonsterInfo monsterInfo = new MonsterInfo();
				monsterInfo.id = msg.reader().readShort();
				monsterInfo.monster_type = msg.reader().readUnsignedByte();
				monsterInfo.x = msg.reader().readShort();
				monsterInfo.y = msg.reader().readShort();
				monsterInfo.hp = msg.reader().readInt();
				monsterInfo.lv = msg.reader().readByte();
				monsterInfo.he = msg.reader().readByte();
				monsterInfo.maxhp = msg.reader().readInt();
				monsterInfo.timeLive = msg.reader().readInt();
				Canvas.gameScr.onMonsterInfo(monsterInfo);
				break;
			}
			case 6:
			{
				short attacker2 = msg.reader().readShort();
				short attacked2 = msg.reader().readShort();
				sbyte skillID = msg.reader().readByte();
				int hpLost2 = msg.reader().readInt();
				int hpLeft2 = msg.reader().readInt();
				sbyte effect = msg.reader().readByte();
				sbyte x = msg.reader().readByte();
				sbyte buffAttack = msg.reader().readByte();
				sbyte level = msg.reader().readByte();
				Canvas.gameScr.onPlayerAttackPlayer(attacker2, attacked2, skillID, hpLost2, hpLeft2, effect, x, buffAttack, level);
				break;
			}
			case 9:
			{
				short attacker3 = msg.reader().readShort();
				short attacked3 = msg.reader().readShort();
				sbyte skillID2 = msg.reader().readByte();
				int hpLost3 = msg.reader().readInt();
				int hpLeft3 = msg.reader().readInt();
				sbyte effect2 = msg.reader().readByte();
				sbyte x2 = msg.reader().readByte();
				sbyte buffAttack2 = msg.reader().readByte();
				sbyte level2 = msg.reader().readByte();
				Canvas.gameScr.onPlayerAttackMonster(attacker3, attacked3, skillID2, hpLost3, hpLeft3, effect2, x2, buffAttack2, level2);
				break;
			}
			case 106:
				Canvas.gameScr.onAttackMultiTarget(msg);
				break;
			case 10:
			{
				short attacker = msg.reader().readShort();
				short attacked = msg.reader().readShort();
				int hpLost = msg.reader().readInt();
				int hpLeft = msg.reader().readInt();
				Canvas.gameScr.onMonsterAttackPlayer(attacker, attacked, hpLost, hpLeft);
				break;
			}
			case 83:
				Canvas.gameScr.onBossAttackPlayer(msg);
				break;
			case 17:
				try
				{
					MonsterDieInfo monsterDieInfo = new MonsterDieInfo();
					monsterDieInfo.attacker = msg.reader().readShort();
					monsterDieInfo.attacked = msg.reader().readShort();
					monsterDieInfo.skillID = msg.reader().readByte();
					monsterDieInfo.hpLost = msg.reader().readInt();
					monsterDieInfo.effect = msg.reader().readByte();
					monsterDieInfo.itemDrop = new ItemDropInfo[msg.reader().readByte()];
					Out.println("SO LUONG ITEMDROP " + monsterDieInfo.itemDrop.Length);
					for (int num56 = 0; num56 < monsterDieInfo.itemDrop.Length; num56++)
					{
						monsterDieInfo.itemDrop[num56] = new ItemDropInfo();
						monsterDieInfo.itemDrop[num56].itemCatagory = msg.reader().readByte();
						string arg = monsterDieInfo.itemDrop[num56].itemCatagory + "_";
						monsterDieInfo.itemDrop[num56].itemTemplateID = msg.reader().readShort();
						arg = arg + monsterDieInfo.itemDrop[num56].itemTemplateID + "_";
						monsterDieInfo.itemDrop[num56].itemID = msg.reader().readShort();
						arg = arg + monsterDieInfo.itemDrop[num56].itemID + "_";
						monsterDieInfo.itemDrop[num56].x = msg.reader().readShort();
						arg = arg + monsterDieInfo.itemDrop[num56].x + "_";
						monsterDieInfo.itemDrop[num56].y = msg.reader().readShort();
						arg = arg + monsterDieInfo.itemDrop[num56].y + "_";
						Out.println(arg);
					}
					Out.println("DOC XONG DATA ITEMDROP");
					if (msg.reader().available() > 0)
					{
						monsterDieInfo.x2 = msg.reader().readByte();
					}
					if (msg.reader().available() > 0)
					{
						monsterDieInfo.buffAttack = msg.reader().readByte();
					}
					if (msg.reader().available() > 0)
					{
						monsterDieInfo.level = msg.reader().readByte();
					}
					Canvas.gameScr.onMonsterDie(monsterDieInfo);
				}
				catch (Exception)
				{
					Out.println("LOI TRONG HAM NHAN DATA ");
				}
				break;
			case 64:
				array = new ItemDropInfo[msg.reader().readByte()];
				for (int num55 = 0; num55 < array.Length; num55++)
				{
					array[num55] = new ItemDropInfo();
					array[num55].itemCatagory = msg.reader().readByte();
					array[num55].itemTemplateID = msg.reader().readByte();
					array[num55].itemID = msg.reader().readShort();
					array[num55].x = msg.reader().readShort();
					array[num55].y = msg.reader().readShort();
				}
				break;
			case 11:
				Canvas.gameScr.onPingBack();
				break;
			case 13:
			{
				sbyte b18 = msg.reader().readByte();
				MainChar[] array6 = null;
				if (b18 == -1)
				{
					Canvas.startOKDlg(msg.reader().readUTF());
				}
				else
				{
					array6 = new MainChar[b18];
					for (int num9 = 0; num9 < b18; num9++)
					{
						array6[num9] = new MainChar();
						array6[num9].IDDB = msg.reader().readInt();
						array6[num9].name = msg.reader().readUTF();
						array6[num9].currentHead = msg.reader().readByte();
						sbyte b19 = msg.reader().readByte();
						for (int num10 = 0; num10 < b19; num10++)
						{
							sbyte b20 = msg.reader().readByte();
							sbyte b21 = msg.reader().readByte();
							if (b20 == 0)
							{
								array6[num9].bodyStyle = b21;
							}
							else if (b20 == 1)
							{
								array6[num9].legStyle = b21;
							}
							else if (b20 == 2)
							{
								array6[num9].hatStyle = b21;
							}
							else if (b20 == 3 || b20 == 4 || b20 == 5 || b20 == 6 || b20 == 7)
							{
								array6[num9].weaponType = b20;
								array6[num9].weaponStyle = b21;
							}
							else if (b20 == 19)
							{
								array6[num9].coatStyle = b21;
							}
						}
						array6[num9].lastLv = msg.reader().readShort();
						array6[num9].isusing = msg.reader().readByte();
						array6[num9].nationID = msg.reader().readByte();
						array6[num9].day = msg.reader().readShort();
						sbyte b22 = msg.reader().readByte();
						if (b22 != -1)
						{
							int num11 = msg.reader().readShort();
							sbyte[] array7 = new sbyte[num11];
							for (int num12 = 0; num12 < num11; num12++)
							{
								array7[num12] = msg.reader().readByte();
							}
							int num13 = msg.reader().readShort();
							sbyte[] array8 = new sbyte[num13];
							for (int num14 = 0; num14 < num13; num14++)
							{
								array8[num14] = msg.reader().readByte();
							}
							array6[num9].imgWpa = Res.createImgByHeader(array7, array8);
							array6[num9].dxWear = msg.reader().readByte();
							array6[num9].dyWear = msg.reader().readByte();
						}
					}
					if (array6 != null)
					{
						for (int num15 = 0; num15 < b18; num15++)
						{
							int num16 = -1;
							try
							{
								num16 = msg.reader().readInt();
							}
							catch (Exception)
							{
								num16 = -1;
							}
							if (num16 != -1 && array6[num15].IDDB == num16)
							{
								short num17 = -1;
								sbyte b23 = -1;
								sbyte b24 = -1;
								short num18 = -1;
								sbyte b25 = -1;
								sbyte b26 = -1;
								short num19 = -1;
								sbyte b27 = -1;
								sbyte b28 = -1;
								try
								{
									num17 = msg.reader().readShort();
									b23 = msg.reader().readByte();
									b24 = msg.reader().readByte();
									num18 = msg.reader().readShort();
									b25 = msg.reader().readByte();
									b26 = msg.reader().readByte();
									num19 = msg.reader().readShort();
									b27 = msg.reader().readByte();
									b28 = msg.reader().readByte();
								}
								catch (Exception)
								{
									num17 = -1;
									b23 = -1;
									b24 = -1;
									num18 = -1;
									b25 = -1;
									b26 = -1;
									num19 = -1;
									b27 = -1;
									b28 = -1;
								}
								array6[num15].idImgAVT = num17;
								array6[num15].indexAVT = b23;
								array6[num15].nFrameAVT = b24;
								array6[num15].idImgPP = num18;
								array6[num15].indexPP = b25;
								array6[num15].nFramePP = b26;
								array6[num15].idImageWeapon = num19;
								array6[num15].typeWeapon = b27;
								array6[num15].nFrameWP = b28;
							}
						}
					}
					CharSelectScr.gI().setCharList(array6);
					CharSelectScr.gI().switchToMe();
				}
				break;
			}
			case 15:
			{
				sbyte b70 = msg.reader().readByte();
				if (b70 == 0)
				{
					mVector mVector8 = new mVector();
					short charID3 = msg.reader().readShort();
					int num165 = msg.reader().readByte();
					for (int num166 = 0; num166 < num165; num166++)
					{
						ItemInInventory itemInInventory6 = new ItemInInventory();
						itemInInventory6.charClazz = (itemInInventory6.clazz = msg.reader().readByte());
						itemInInventory6.itemID = msg.reader().readShort();
						itemInInventory6.idTemplate = msg.reader().readShort();
						itemInInventory6.plusTemplate = msg.reader().readByte();
						itemInInventory6.level = msg.reader().readByte();
						itemInInventory6.mDurable = msg.reader().readShort();
						itemInInventory6.durable = msg.reader().readShort();
						itemInInventory6.colorName = msg.reader().readByte();
						itemInInventory6.viTriVe = msg.reader().readByte();
						itemInInventory6.heItem = msg.reader().readByte();
						itemInInventory6.beKicked = msg.reader().readByte();
						itemInInventory6.hangItem = msg.reader().readByte();
						itemInInventory6.magic_physic = msg.reader().readByte();
						itemInInventory6.islock = msg.reader().readByte();
						itemInInventory6.nameCharSeal = msg.reader().readUTF();
						itemInInventory6.allAttribute.removeAllElements();
						itemInInventory6.lastTime = mSystem.getCurrentTimeMillis();
						itemInInventory6.dayUse = msg.reader().readUnsignedShort();
						sbyte b71 = msg.reader().readByte();
						for (sbyte b72 = 0; b72 < b71; b72 = (sbyte)(b72 + 1))
						{
							InfoAttributeItem o4 = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
							itemInInventory6.allAttribute.addElement(o4);
						}
						itemInInventory6.isEnoughData = true;
						mVector8.addElement(itemInInventory6);
					}
					sbyte idFashion = msg.reader().readByte();
					short[] array34 = new short[5]
					{
						-1,
						-1,
						-1,
						-1,
						-1
					};
					for (int num167 = 0; num167 < array34.Length; num167++)
					{
						array34[num167] = msg.reader().readShort();
					}
					sbyte b73 = msg.reader().readByte();
					sbyte idIconAnimal = 0;
					string petInfo = string.Empty;
					if (b73 != -1)
					{
						petInfo = msg.reader().readUTF();
						idIconAnimal = msg.reader().readByte();
					}
					sbyte b74 = msg.reader().readByte();
					AnimalMove animalMove = null;
					if (b74 != -1)
					{
						animalMove = new AnimalMove();
						animalMove.type = msg.reader().readByte();
						animalMove.imgID = msg.reader().readShort();
						animalMove.sumFrame = msg.reader().readByte();
						animalMove.infoPet = msg.reader().readUTF();
						animalMove.totalTime = msg.reader().readInt();
						animalMove.timeStart = mSystem.getCurrentTimeMillis();
						animalMove.count = (animalMove.idFrame = 0);
						animalMove.catagory = Actor.CAT_MY_PET;
					}
					Canvas.gameScr.onCharWearingInfo(charID3, mVector8, idFashion, b73, petInfo, animalMove, array34, idIconAnimal);
				}
				else
				{
					mVector mVector9 = new mVector();
					short charID4 = msg.reader().readShort();
					int num168 = msg.reader().readByte();
					if (num168 > -1)
					{
						for (int num169 = 0; num169 < num168; num169++)
						{
							ItemInInventory itemInInventory7 = new ItemInInventory();
							itemInInventory7.charClazz = (itemInInventory7.clazz = msg.reader().readByte());
							itemInInventory7.itemID = msg.reader().readShort();
							itemInInventory7.idTemplate = msg.reader().readShort();
							itemInInventory7.plusTemplate = msg.reader().readByte();
							itemInInventory7.level = msg.reader().readByte();
							itemInInventory7.mDurable = msg.reader().readShort();
							itemInInventory7.durable = msg.reader().readShort();
							itemInInventory7.colorName = msg.reader().readByte();
							itemInInventory7.viTriVe = msg.reader().readByte();
							itemInInventory7.heItem = msg.reader().readByte();
							itemInInventory7.beKicked = msg.reader().readByte();
							itemInInventory7.hangItem = msg.reader().readByte();
							itemInInventory7.magic_physic = msg.reader().readByte();
							itemInInventory7.islock = msg.reader().readByte();
							itemInInventory7.nameCharSeal = msg.reader().readUTF();
							itemInInventory7.allAttribute.removeAllElements();
							sbyte b75 = msg.reader().readByte();
							for (byte b76 = 0; b76 < b75; b76 = (byte)(b76 + 1))
							{
								InfoAttributeItem o5 = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
								itemInInventory7.allAttribute.addElement(o5);
							}
							itemInInventory7.isEnoughData = true;
							mVector9.addElement(itemInInventory7);
						}
						sbyte b77 = msg.reader().readByte();
						Image image2 = null;
						int wimg = 0;
						int himg = 0;
						sbyte timeChangeFrame = 1;
						sbyte[] array35 = new sbyte[msg.reader().available()];
						while (msg.reader().available() > 0)
						{
							for (int num170 = 0; num170 < array35.Length; num170++)
							{
								array35[num170] = msg.reader().readByte();
							}
						}
						if (array35.Length > 0)
						{
							image2 = Res.createImgByByteArray(array35);
							timeChangeFrame = (sbyte)((b77 != 3) ? 6 : 3);
							if (image2 != null)
							{
								wimg = image2.getWidth();
								himg = image2.getHeight() / b77;
							}
						}
						WindowInfoScr.gI().countFrame = 0;
						Canvas.gameScr.onAnimalWearingInfo(charID4, mVector9, image2, b77, wimg, himg, timeChangeFrame);
					}
				}
				break;
			}
			case 16:
			{
				int num154 = msg.reader().readByte();
				int[] array33 = new int[Char.CHAR_POTION];
				long charXu = 0L;
				try
				{
					if (num154 == 0)
					{
						charXu = msg.reader().readLong();
						array33[0] = 0;
						int num155 = msg.reader().readByte();
						for (int num156 = 0; num156 < num155; num156++)
						{
							int num157 = msg.reader().readUnsignedByte();
							int num158 = msg.reader().readInt();
							MainChar.listPotion[num157].number = num158;
							array33[num157] = num158;
							Out.println(MainChar.listPotion[num157].name);
						}
					}
					mVector mVector6 = new mVector();
					if (num154 == 1)
					{
						int num159 = msg.reader().readShort();
						for (int num160 = 0; num160 < num159; num160++)
						{
							ItemInInventory itemInInventory5 = new ItemInInventory();
							itemInInventory5.charClazz = msg.reader().readByte();
							itemInInventory5.itemID = msg.reader().readShort();
							itemInInventory5.idTemplate = msg.reader().readShort();
							itemInInventory5.plusTemplate = msg.reader().readByte();
							itemInInventory5.level = msg.reader().readByte();
							itemInInventory5.mDurable = msg.reader().readShort();
							itemInInventory5.durable = msg.reader().readShort();
							itemInInventory5.clazz = msg.reader().readByte();
							itemInInventory5.numKham = msg.reader().readByte();
							itemInInventory5.totalKham = msg.reader().readByte();
							itemInInventory5.colorName = msg.reader().readByte();
							itemInInventory5.heItem = msg.reader().readByte();
							itemInInventory5.beKicked = msg.reader().readByte();
							itemInInventory5.hangItem = msg.reader().readByte();
							itemInInventory5.magic_physic = msg.reader().readByte();
							itemInInventory5.islock = msg.reader().readByte();
							itemInInventory5.nameCharSeal = msg.reader().readUTF();
							itemInInventory5.allAttribute.removeAllElements();
							itemInInventory5.lastTime = mSystem.getCurrentTimeMillis();
							itemInInventory5.dayUse = msg.reader().readUnsignedShort();
							sbyte b68 = msg.reader().readByte();
							for (sbyte b69 = 0; b69 < b68; b69 = (sbyte)(b69 + 1))
							{
								InfoAttributeItem o3 = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
								itemInInventory5.allAttribute.addElement(o3);
							}
							itemInInventory5.isItemDrop = msg.reader().readByte();
							itemInInventory5.isEnoughData = true;
							mVector6.addElement(itemInInventory5);
						}
					}
					Canvas.gameScr.mainChar.luong = msg.reader().readInt();
					mVector mVector7 = new mVector();
					if (num154 == 2)
					{
						int num161 = msg.reader().readByte();
						for (int num162 = 0; num162 < num161; num162++)
						{
							AnimalInfo animalInfo = new AnimalInfo();
							animalInfo.id = msg.reader().readShort();
							animalInfo.idImg = msg.reader().readByte();
							animalInfo.idPaint = msg.reader().readByte();
							animalInfo.level = msg.reader().readByte();
							animalInfo.name = msg.reader().readUTF();
							animalInfo.info = msg.reader().readUTF();
							animalInfo.typeAnimal = msg.reader().readByte();
							mVector7.addElement(animalInfo);
						}
						num161 = msg.reader().readByte();
						for (int num163 = 0; num163 < num161; num163++)
						{
							AnimalInfo animalInfo2 = new AnimalInfo();
							animalInfo2.id = msg.reader().readShort();
							animalInfo2.idImg = msg.reader().readByte();
							animalInfo2.idPaint = msg.reader().readByte();
							animalInfo2.name = msg.reader().readUTF();
							animalInfo2.typePet = msg.reader().readByte();
							animalInfo2.info = msg.reader().readUTF();
							animalInfo2.totalTimeCon = msg.reader().readInt();
							animalInfo2.timeStart = mSystem.getCurrentTimeMillis();
							animalInfo2.typeAnimal = msg.reader().readByte();
							mVector7.addElement(animalInfo2);
						}
					}
					if (num154 == 3)
					{
						MainChar.itemQuest = new short[msg.reader().readByte()];
						for (int num164 = 0; num164 < MainChar.itemQuest.Length; num164++)
						{
							MainChar.itemQuest[num164] = msg.reader().readShort();
						}
					}
					Out.println("DONG XONG DATA ");
					Canvas.gameScr.mainChar.luongKhoa = msg.reader().readInt();
					Canvas.gameScr.onCharInventory(charXu, array33, mVector6, mVector7, num154);
				}
				catch (Exception)
				{
					Out.println("LOI CHARINVENTORY " + num154);
				}
				break;
			}
			case 18:
			{
				short whoGet3 = msg.reader().readShort();
				ItemInInventory itemInInventory4 = new ItemInInventory();
				itemInInventory4.clazz = (itemInInventory4.charClazz = msg.reader().readByte());
				itemInInventory4.itemOldID = msg.reader().readShort();
				itemInInventory4.itemID = msg.reader().readShort();
				itemInInventory4.idTemplate = msg.reader().readShort();
				itemInInventory4.plusTemplate = msg.reader().readByte();
				itemInInventory4.level = msg.reader().readByte();
				itemInInventory4.durable = msg.reader().readShort();
				itemInInventory4.mDurable = msg.reader().readShort();
				Canvas.gameScr.onGetItemFromGround(whoGet3, itemInInventory4);
				break;
			}
			case 19:
			{
				short whoGet2 = msg.reader().readShort();
				short potionID = msg.reader().readShort();
				short potionType2 = msg.reader().readUnsignedByte();
				short potionQuantity = msg.reader().readShort();
				Canvas.gameScr.onGetPotionFromGround(whoGet2, potionID, potionType2, potionQuantity);
				break;
			}
			case -65:
				try
				{
					short whoGet = msg.reader().readShort();
					short gemID = msg.reader().readShort();
					sbyte itemQuestType = msg.reader().readByte();
					Canvas.gameScr.onGetItemQuestFromGround(whoGet, gemID, itemQuestType);
				}
				catch (Exception)
				{
				}
				break;
			case -41:
			{
				short whoGet4 = msg.reader().readShort();
				sbyte catagory = msg.reader().readByte();
				short gemID2 = msg.reader().readShort();
				Canvas.gameScr.onGetGemFromGround(whoGet4, gemID2, catagory);
				break;
			}
			case 21:
			{
				ItemInInventory itemInInventory3 = new ItemInInventory();
				itemInInventory3.itemID = msg.reader().readShort();
				itemInInventory3.durable = msg.reader().readShort();
				itemInInventory3.clazz = msg.reader().readByte();
				itemInInventory3.dayUse = msg.reader().readUnsignedShort();
				itemInInventory3.allAttribute.removeAllElements();
				sbyte b65 = msg.reader().readByte();
				for (sbyte b66 = 0; b66 < b65; b66 = (sbyte)(b66 + 1))
				{
					InfoAttributeItem o2 = new InfoAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readShort());
					itemInInventory3.allAttribute.addElement(o2);
				}
				itemInInventory3.plusTemplate = msg.reader().readByte();
				try
				{
					itemInInventory3.islock = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onItemInfo(itemInInventory3);
				break;
			}
			case 22:
			{
				short userId = msg.reader().readShort();
				sbyte potionType = msg.reader().readByte();
				short valueAdd = msg.reader().readShort();
				int valueNew = msg.reader().readInt();
				int isHP = 0;
				try
				{
					isHP = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onUsePotion(userId, potionType, valueAdd, valueNew, isHP);
				break;
			}
			case 23:
			{
				sbyte b38 = msg.reader().readByte();
				if (b38 == 0)
				{
					sbyte b39 = msg.reader().readByte();
					sbyte[] array13 = new sbyte[b39];
					for (int num60 = 0; num60 < b39; num60++)
					{
						array13[num60] = msg.reader().readByte();
					}
					Canvas.gameScr.onNPCSellPotion(array13);
				}
				if (b38 == 1)
				{
					int num61 = msg.reader().readByte();
					WindowInfoScr.gI().idClass = num61;
					mVector mVector3 = new mVector();
					int num62 = msg.reader().readShort();
					for (int num63 = 0; num63 < num62; num63++)
					{
						ItemInInventory itemInInventory = new ItemInInventory();
						itemInInventory.isEnoughData = true;
						itemInInventory.isShopItem = true;
						int num64 = msg.reader().readShort();
						if (num61 == -1)
						{
							itemInInventory.charClazz = (sbyte)getIndexClassFromItemID(num64);
						}
						else
						{
							itemInInventory.charClazz = (sbyte)num61;
						}
						itemInInventory.idTemplate = (short)num64;
						itemInInventory.clazz = (sbyte)((num61 != -1) ? num61 : getIndexClassFromItemID(num64));
						ItemTemplate item = Res.getItem(itemInInventory.charClazz, num64);
						itemInInventory.level = item.level;
						itemInInventory.durable = item.durable;
						mVector3.addElement(itemInInventory);
					}
					try
					{
						ItemInInventory.typeItemBuy = 2;
						ItemInInventory.typeItemBuy = msg.reader().readByte();
					}
					catch (Exception)
					{
					}
					Canvas.gameScr.onNPCSellItem(mVector3);
				}
				try
				{
					if (b38 == 2)
					{
						mVector mVector4 = new mVector();
						sbyte b40 = msg.reader().readByte();
						for (int num65 = 0; num65 < b40; num65++)
						{
							ItemInInventory itemInInventory2 = new ItemInInventory();
							sbyte b41 = msg.reader().readByte();
							itemInInventory2.itemID = msg.reader().readShort();
							short num66 = msg.reader().readShort();
							if (num66 < 0)
							{
								num66 = (short)(num66 + 256);
							}
							itemInInventory2.charClazz = b41;
							itemInInventory2.idTemplate = num66;
							itemInInventory2.plusTemplate = msg.reader().readByte();
							itemInInventory2.level = msg.reader().readByte();
							itemInInventory2.mDurable = msg.reader().readShort();
							itemInInventory2.durable = msg.reader().readShort();
							itemInInventory2.clazz = b41;
							mVector4.addElement(itemInInventory2);
						}
						Canvas.gameScr.onNPCKeepItem(mVector4);
					}
				}
				catch (Exception)
				{
					Out.LogError("LOI NHAN ITEM TRONG KHO DO");
				}
				if (b38 == 3)
				{
					Canvas.gameScr.onNPCSellGemItem(null);
				}
				if (b38 == 4)
				{
					sbyte b42 = msg.reader().readByte();
					sbyte[] array14 = new sbyte[b42 + 2];
					for (int num67 = 0; num67 < b42; num67++)
					{
						array14[num67] = msg.reader().readByte();
					}
					array14[b42] = msg.reader().readByte();
					array14[b42 + 1] = msg.reader().readByte();
					Canvas.gameScr.onListShopOfNPC(array14);
				}
				break;
			}
			case 25:
			{
				int num22 = msg.reader().readUnsignedByte();
				ItemTemplate.ALL_NAME_ATTRIBUTE_ITEM.clear();
				for (byte b30 = 0; b30 < num22; b30 = (byte)(b30 + 1))
				{
					ItemTemplate.ALL_NAME_ATTRIBUTE_ITEM.put(b30 + string.Empty, new NameAttributeItem(msg.reader().readUnsignedByte(), msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readByte()));
				}
				int num23 = msg.reader().readByte();
				for (int num24 = 0; num24 < num23; num24++)
				{
					Res.potionTemplates[num24] = new PotionTemplate(msg.reader().readShort(), msg.reader().readShort());
				}
				for (int num25 = 0; num25 < 5; num25++)
				{
					Res.percent[num25] = msg.reader().readByte();
				}
				int num26 = msg.reader().readShort();
				ItemTemplate[] array9 = new ItemTemplate[num26 + 1];
				for (int num27 = 0; num27 < num26; num27++)
				{
					int num28 = msg.reader().readShort();
					try
					{
						array9[num28] = new ItemTemplate();
						array9[num28].id = (short)num28;
						array9[num28].name = msg.reader().readUTF();
						array9[num28].type = msg.reader().readByte();
						array9[num28].style = msg.reader().readByte();
						array9[num28].he = msg.reader().readByte();
						array9[num28].gender = msg.reader().readByte();
						array9[num28].level = msg.reader().readByte();
						array9[num28].durable = msg.reader().readShort();
						for (int num29 = 0; num29 < 10; num29++)
						{
							array9[num28].attb[num29] = msg.reader().readShort();
						}
						array9[num28].price = msg.reader().readInt();
						array9[num28].clazz = msg.reader().readByte();
						array9[num28].colorItem = msg.reader().readByte();
						array9[num28].idIcon = msg.reader().readShort();
						array9[num28].ndayLoan = msg.reader().readShort();
					}
					catch (Exception ex5)
					{
						Out.println(ex5.StackTrace + " loi tai ITEM_TEMPLATE");
					}
				}
				Res.itemTemplates.addElement(array9);
				short num30 = msg.reader().readShort();
				Res.gemTemplate.removeAllElements();
				for (int num31 = 0; num31 < num30; num31++)
				{
					GemTemp gemTemp = new GemTemp();
					gemTemp.id = msg.reader().readShort();
					gemTemp.idImage = msg.reader().readByte();
					gemTemp.price = msg.reader().readInt();
					gemTemp.name = msg.reader().readUTF();
					string s = gemTemp.name.Substring(gemTemp.name.Length - 1);
					gemTemp.decript = msg.reader().readUTF();
					gemTemp.type = msg.reader().readByte();
					try
					{
						int num32 = int.Parse(s);
						if (num32 >= 4 && gemTemp.type != 4)
						{
							gemTemp.isEff = (sbyte)(num32 - 4);
						}
					}
					catch (Exception)
					{
					}
					gemTemp.isSell = msg.reader().readBoolean();
					gemTemp.typeEp = msg.reader().readByte();
					gemTemp.typeMoney = msg.reader().readByte();
					Res.gemTemplate.addElement(gemTemp);
				}
				int num33 = msg.reader().readUnsignedByte();
				Res.shopTemplate.removeAllElements();
				for (int num34 = 0; num34 < num33; num34++)
				{
					GemTemp gemTemp2 = new GemTemp();
					gemTemp2.id = msg.reader().readUnsignedByte();
					gemTemp2.idImage = msg.reader().readUnsignedByte();
					gemTemp2.price = msg.reader().readInt();
					gemTemp2.name = msg.reader().readUTF();
					gemTemp2.decript = msg.reader().readUTF();
					gemTemp2.typeMoney = msg.reader().readByte();
					gemTemp2.shopType = msg.reader().readByte();
					gemTemp2.isSell = msg.reader().readBoolean();
					gemTemp2.value = msg.reader().readShort();
					Res.shopTemplate.addElement(gemTemp2);
				}
				break;
			}
			case 26:
			{
				int num35 = msg.reader().readUnsignedByte();
				Res.monsterTemplates = new MonsterTemplate[num35];
				short num36 = msg.reader().readShort();
				sbyte[] data = new sbyte[num36];
				msg.reader().read(ref data);
				Res.setEffSh(data);
				try
				{
					num36 = msg.reader().readUnsignedByte();
					sbyte[][] array10 = new sbyte[num36][];
					for (int num37 = 0; num37 < num36; num37++)
					{
						array10[num37] = new sbyte[msg.reader().readShort()];
						msg.reader().read(ref array10[num37]);
					}
					DynamicEffect.setDataEffect(array10);
				}
				catch (Exception)
				{
				}
				try
				{
					num36 = msg.reader().readUnsignedByte();
					for (int num38 = 0; num38 < num36; num38++)
					{
						int num39 = msg.reader().readShort();
						short num40 = msg.reader().readShort();
						sbyte[] data2 = new sbyte[num40];
						msg.reader().read(ref data2);
						mDataEffect v = new mDataEffect(data2, num39, isMonster: true);
						Pet.ALL_PET_DATA.put(string.Empty + num39, v);
					}
				}
				catch (Exception)
				{
				}
				try
				{
					int num41 = msg.reader().readUnsignedByte();
					for (int num42 = 0; num42 < num41; num42++)
					{
						int num43 = msg.reader().readShort();
						sbyte[] data3 = new sbyte[msg.reader().readShort()];
						msg.reader().read(ref data3);
						PartFrame v2 = new PartFrame(num43, data3);
						DataSkillEff.ALL_DATA_EFF.put(num43 + string.Empty, v2);
					}
				}
				catch (Exception)
				{
				}
				try
				{
					sbyte b31 = msg.reader().readByte();
					Char.dx_horse = new sbyte[b31][];
					Char.dy_horse = new sbyte[b31][];
					for (int num44 = 0; num44 < b31; num44++)
					{
						Char.dx_horse[num44] = new sbyte[4];
						Char.dy_horse[num44] = new sbyte[4];
						for (int num45 = 0; num45 < 4; num45++)
						{
							Char.dx_horse[num44][num45] = msg.reader().readByte();
						}
						for (int num46 = 0; num46 < 4; num46++)
						{
							Char.dy_horse[num44][num46] = msg.reader().readByte();
						}
					}
				}
				catch (Exception)
				{
					Char.dx_horse = new sbyte[1][]
					{
						new sbyte[4]
						{
							0,
							0,
							7,
							-7
						}
					};
					Char.dy_horse = new sbyte[1][]
					{
						new sbyte[4]
						{
							-20,
							-15,
							-15,
							-15
						}
					};
				}
				try
				{
					for (int num47 = 0; num47 < 2; num47++)
					{
						sbyte b32 = msg.reader().readByte();
						Char.Dx_Dy_WP[num47] = new sbyte[b32];
						for (int num48 = 0; num48 < b32; num48++)
						{
							Char.Dx_Dy_WP[num47][num48] = msg.reader().readByte();
						}
					}
				}
				catch (Exception)
				{
					Char.Dx_Dy_WP = new sbyte[2][]
					{
						new sbyte[1],
						new sbyte[1]
					};
				}
				try
				{
					for (int num49 = 0; num49 < 2; num49++)
					{
						sbyte b33 = msg.reader().readByte();
						Char.Dx_Dy_PP[num49] = new sbyte[b33];
						for (int num50 = 0; num50 < b33; num50++)
						{
							Char.Dx_Dy_PP[num49][num50] = msg.reader().readByte();
						}
					}
				}
				catch (Exception)
				{
					Char.Dx_Dy_PP = new sbyte[2][]
					{
						new sbyte[1],
						new sbyte[1]
					};
				}
				try
				{
					for (int num51 = 0; num51 < 2; num51++)
					{
						sbyte b34 = msg.reader().readByte();
						Char.Dx_Dy_AVT[num51] = new sbyte[b34];
						for (int num52 = 0; num52 < b34; num52++)
						{
							Char.Dx_Dy_AVT[num51][num52] = msg.reader().readByte();
						}
					}
				}
				catch (Exception)
				{
					Char.Dx_Dy_AVT = new sbyte[2][]
					{
						new sbyte[1],
						new sbyte[1]
					};
				}
				break;
			}
			case 100:
				Canvas.gameScr.onTemplateInfo(msg);
				break;
			case 58:
			{
				int num3 = msg.reader().readByte();
				int[] array4 = new int[num3];
				for (int j = 0; j < num3; j++)
				{
					array4[j] = msg.reader().readShort();
				}
				break;
			}
			case 24:
				Canvas.endDlg();
				break;
			case 27:
			{
				short chatFromID = msg.reader().readShort();
				string text7 = msg.reader().readUTF();
				Canvas.gameScr.onChat(chatFromID, text7);
				break;
			}
			case 28:
			{
				short itemID3 = msg.reader().readShort();
				Canvas.gameScr.onSellItem(itemID3);
				break;
			}
			case 78:
			{
				short itemID2 = msg.reader().readShort();
				Canvas.gameScr.onSellGemItem(itemID2);
				break;
			}
			case 61:
			{
				short charID = msg.reader().readShort();
				short itemID = msg.reader().readShort();
				ItemDropInfo itemDropInfo = new ItemDropInfo();
				itemDropInfo.itemCatagory = msg.reader().readByte();
				itemDropInfo.itemTemplateID = msg.reader().readByte();
				itemDropInfo.itemID = msg.reader().readShort();
				itemDropInfo.x = msg.reader().readShort();
				itemDropInfo.y = msg.reader().readShort();
				Canvas.gameScr.onGiveItemToGround(charID, itemID, itemDropInfo);
				break;
			}
			case 30:
			{
				short whoSetXP = msg.reader().readShort();
				short newpercent = msg.reader().readShort();
				int dxp = msg.reader().readInt();
				Canvas.gameScr.onSetXP(whoSetXP, newpercent, dxp);
				break;
			}
			case 32:
			{
				short num = msg.reader().readShort();
				sbyte b = msg.reader().readByte();
				Property[] array2 = new Property[b];
				for (int i = 0; i < b; i++)
				{
					array2[i] = new Property();
					array2[i].key = msg.reader().readUTF();
					array2[i].value = msg.reader().readInt();
				}
				if (num == Canvas.gameScr.mainChar.ID)
				{
					Canvas.gameScr.mainChar.level = msg.reader().readByte();
					Canvas.gameScr.mainChar.lvpercent = msg.reader().readShort();
				}
				Canvas.gameScr.onCharProperties(num, array2);
				break;
			}
			case 33:
			{
				short idc = msg.reader().readShort();
				sbyte newlevel = msg.reader().readByte();
				Canvas.gameScr.onLevelUp(idc, newlevel, msg.reader().readInt(), msg.reader().readInt());
				break;
			}
			case 35:
				SkillManager.SKILL_DAM_PERCENT = new short[1][][];
				for (int num118 = 0; num118 < 1; num118++)
				{
					SkillManager.SKILL_DAM_PERCENT[num118] = new short[15][];
					for (int num119 = 0; num119 < 15; num119++)
					{
						SkillManager.SKILL_DAM_PERCENT[num118][num119] = new short[11];
					}
				}
				for (int num120 = 0; num120 < 15; num120++)
				{
					for (int num121 = 0; num121 < 11; num121++)
					{
						SkillManager.SKILL_DAM_PERCENT[0][num120][num121] = msg.reader().readShort();
					}
				}
				SkillManager.SKILL_COOLDOWN = new int[1][][];
				for (int num122 = 0; num122 < 1; num122++)
				{
					SkillManager.SKILL_COOLDOWN[num122] = new int[15][];
					for (int num123 = 0; num123 < 15; num123++)
					{
						SkillManager.SKILL_COOLDOWN[num122][num123] = new int[11];
					}
				}
				for (int num124 = 0; num124 < 15; num124++)
				{
					for (int num125 = 0; num125 < 11; num125++)
					{
						SkillManager.SKILL_COOLDOWN[0][num124][num125] = msg.reader().readShort() * 100;
					}
				}
				SkillManager.SKILL_RANGE = new short[1][];
				for (int num126 = 0; num126 < 1; num126++)
				{
					SkillManager.SKILL_RANGE[num126] = new short[15];
				}
				for (int num127 = 0; num127 < 15; num127++)
				{
					SkillManager.SKILL_RANGE[0][num127] = msg.reader().readShort();
				}
				SkillManager.SKILL_MP = new short[1][][];
				for (int num128 = 0; num128 < 1; num128++)
				{
					SkillManager.SKILL_MP[num128] = new short[15][];
					for (int num129 = 0; num129 < 15; num129++)
					{
						SkillManager.SKILL_MP[num128][num129] = new short[11];
					}
				}
				for (int num130 = 0; num130 < 15; num130++)
				{
					for (int num131 = 0; num131 < 11; num131++)
					{
						SkillManager.SKILL_MP[0][num130][num131] = msg.reader().readUnsignedByte();
					}
				}
				SkillManager.TIME_LIFE_BUFF_SKILL = new short[15][];
				for (int num132 = 0; num132 < 15; num132++)
				{
					SkillManager.TIME_LIFE_BUFF_SKILL[num132] = new short[11];
				}
				for (int num133 = 0; num133 < 15; num133++)
				{
					for (int num134 = 0; num134 < 11; num134++)
					{
						SkillManager.TIME_LIFE_BUFF_SKILL[num133][num134] = msg.reader().readShort();
					}
				}
				SkillManager.LEVEL_ADD_SKILL = new sbyte[15][];
				for (int num135 = 0; num135 < 15; num135++)
				{
					SkillManager.LEVEL_ADD_SKILL[num135] = new sbyte[11];
				}
				for (int num136 = 0; num136 < 15; num136++)
				{
					for (int num137 = 0; num137 < 11; num137++)
					{
						SkillManager.LEVEL_ADD_SKILL[num136][num137] = msg.reader().readByte();
					}
				}
				SkillManager.SKILL_AEO = new sbyte[5][];
				for (int num138 = 0; num138 < 5; num138++)
				{
					SkillManager.SKILL_AEO[num138] = new sbyte[msg.reader().readByte()];
					for (int num139 = 0; num139 < SkillManager.SKILL_AEO[num138].Length; num139++)
					{
						SkillManager.SKILL_AEO[num138][num139] = msg.reader().readByte();
					}
				}
				break;
			case 14:
				Canvas.startOKDlg("Xin chọn tên nhân vật khác");
				break;
			case 34:
				Canvas.endDlg();
				break;
			case 36:
				Canvas.endDlg();
				break;
			case 48:
				Canvas.gameScr.onCreadtePTOK(msg.reader().readShort());
				break;
			case 49:
				Canvas.gameScr.onAdd2Party(msg);
				break;
			case 50:
				Canvas.gameScr.onKickOutParty(msg);
				break;
			case 38:
			{
				string o = msg.reader().readUTF();
				GameScr.serverInfo.addElement(o);
				break;
			}
			case 37:
			{
				string info4 = msg.reader().readUTF();
				string url = msg.reader().readUTF();
				if (url.Equals(string.Empty))
				{
					Canvas.startOKDlg(info4);
				}
				else
				{
					Canvas.gameScr.isNewVersionAvailable = true;
					Command command = new Command("OK");
					Command command2 = new Command();
					command2.action = (command.action = delegate
					{
						Main.main.platformRequest(url);
						Main.main.OnApplicationQuit();
					});
					Command command3 = new Command("Đóng");
					ActionPerform actionPerform = command3.action = delegate
					{
						Canvas.endDlg();
					};
					Canvas.msgdlg.isIcon = false;
					Canvas.msgdlg.setInfo(info4, command, command2, command3);
					Canvas.currentDialog = Canvas.msgdlg;
				}
				break;
			}
			case 39:
			{
				string text12 = msg.reader().readUTF();
				bool flag2 = msg.reader().readBoolean();
				string text13 = msg.reader().readUTF();
				string text14 = msg.reader().readUTF();
				if (!flag2)
				{
					Canvas.startOKDlg("Xin chọn nick khác");
				}
				else
				{
					ActionPerform successAction = delegate
					{
						Canvas.startOKDlg("Đã gửi thông tin. Vui lòng thoát game và chờ trong ít phút");
					};
					ActionPerform failAction = delegate
					{
						Canvas.startOKDlg("Có lỗi xảy ra. Xin hãy thử lại");
					};
					if (Main.isPC)
					{
						Canvas.startOKDlg("Để đăng ký tài khoản vui lòng soạn\n" + text13 + text12 + " \ngửi tới " + text14);
					}
					else
					{
						GameMidlet.sendSMS(text13 + text12, "sms://" + text14, successAction, failAction);
					}
				}
				break;
			}
			case 20:
			{
				sbyte cat = msg.reader().readByte();
				short actorID2 = msg.reader().readShort();
				Canvas.gameScr.onRemoveActor(actorID2, cat);
				break;
			}
			case 51:
				Canvas.gameScr.onCharUseBuff(msg);
				break;
			case 52:
				Canvas.gameScr.isreceiveQuest(msg);
				break;
			case 54:
				Canvas.gameScr.onFinishQuest(msg);
				break;
			case 56:
				Canvas.gameScr.onInfoQuestLogin(msg);
				break;
			case 59:
				Canvas.gameScr.onInfoGiftQuest(msg.reader().readUTF());
				break;
			case -5:
			{
				sbyte b49 = msg.reader().readByte();
				for (int num74 = 0; num74 < b49; num74++)
				{
					string text11 = msg.reader().readUTF();
					string str = msg.reader().readUTF();
					MessageScr.gI().addTab(text11 + ": " + str, text11, 0);
				}
				break;
			}
			case -53:
			{
				string text10 = msg.reader().readUTF();
				Canvas.gameScr.onFriendList(msg, 6, text10.ToUpper());
				break;
			}
			case -7:
			{
				string text9 = msg.reader().readUTF();
				Canvas.gameScr.onFriendList(msg, 1, text9.ToUpper());
				break;
			}
			case -8:
			{
				sbyte b57 = msg.reader().readByte();
				sbyte b58 = msg.reader().readByte();
				sbyte[] array18 = null;
				short num91 = msg.reader().readShort();
				array18 = new sbyte[num91];
				msg.reader().read(ref array18);
				switch (b57)
				{
				case 1:
					GameData.saveImgSkill(b58, array18);
					break;
				case 2:
				{
					short num92 = msg.reader().readShort();
					sbyte[] data5 = new sbyte[num92];
					msg.reader().read(ref data5);
					sbyte b59 = msg.reader().readByte();
					sbyte[][] array19 = new sbyte[b59][];
					sbyte[][][] array20 = new sbyte[b59][][];
					for (int num93 = 0; num93 < b59; num93++)
					{
						short num94 = msg.reader().readShort();
						array19[num93] = new sbyte[num94];
						msg.reader().read(ref array19[num93]);
						short num95 = msg.reader().readByte();
						array20[num93] = new sbyte[num95][];
						for (int num96 = 0; num96 < num95; num96++)
						{
							short num97 = msg.reader().readShort();
							array20[num93][num96] = new sbyte[num97];
							msg.reader().read(ref array20[num93][num96]);
						}
					}
					GameData.saveImgPotion(b58, array18, null, array19, array20);
					break;
				}
				case 3:
					GameData.saveImgGem(b58, array18);
					break;
				case 4:
					AnimalInfo.imgAnimal = Image.createImage(array18, 0, array18.Length);
					break;
				}
				break;
			}
			case -9:
			{
				short num69 = msg.reader().readShort();
				short[] array15 = new short[num69];
				for (int num70 = 0; num70 < num69; num70++)
				{
					array15[num70] = msg.reader().readShort();
				}
				string text8 = msg.reader().readUTF();
				if (text8.Equals(string.Empty))
				{
					Canvas.gameScr.onRegClan(array15);
				}
				else
				{
					short[] arr = array15;
					ActionPerform yesAction2 = delegate
					{
						Canvas.gameScr.onRegClan(arr);
						Canvas.endDlg();
					};
					Canvas.startYesNoDlg(text8, yesAction2);
				}
				break;
			}
			case -10:
			{
				short idClan2 = msg.reader().readShort();
				string info3 = msg.reader().readUTF();
				Canvas.gameScr.mainChar.idClan = idClan2;
				Canvas.gameScr.mainChar.isMaster = 0;
				PauseMenu.gI().initName();
				Canvas.startOKDlg(info3);
				break;
			}
			case -11:
			{
				sbyte b35 = msg.reader().readByte();
				if (b35 == 0)
				{
					short idUser = msg.reader().readShort();
					string info = msg.reader().readUTF();
					ActionPerform yesAction = delegate
					{
						GameService.gI().sendRequestAddClan(idUser, 1, iss: true);
						Canvas.endDlg();
					};
					ActionPerform noAction = delegate
					{
						GameService.gI().sendRequestAddClan(idUser, 1, iss: false);
						Canvas.endDlg();
					};
					Canvas.startYesNoDlg(info, yesAction, noAction);
				}
				else
				{
					string info2 = msg.reader().readUTF();
					if (msg.reader().readBoolean())
					{
						short num57 = msg.reader().readShort();
						short idClan = msg.reader().readShort();
						if (num57 == Canvas.gameScr.mainChar.ID)
						{
							Canvas.gameScr.mainChar.idClan = num57;
							PauseMenu.gI().initName();
						}
						else
						{
							Char char2 = (Char)Canvas.gameScr.findCharByID(num57);
							char2.idClan = idClan;
						}
					}
					Canvas.startOKDlg(info2);
				}
				break;
			}
			case -12:
			{
				ClanInfo clanInfo2 = new ClanInfo();
				clanInfo2.id = msg.reader().readShort();
				clanInfo2.name = msg.reader().readUTF();
				clanInfo2.master = msg.reader().readUTF();
				clanInfo2.level = msg.reader().readByte();
				clanInfo2.members = msg.reader().readShort();
				clanInfo2.money = msg.reader().readLong();
				clanInfo2.dedicationPoint = msg.reader().readLong();
				clanInfo2.xp = msg.reader().readLong();
				clanInfo2.date = msg.reader().readUTF();
				clanInfo2.status = msg.reader().readUTF();
				clanInfo2.dissolved = msg.reader().readBoolean();
				clanInfo2.nationID = msg.reader().readByte();
				if (clanInfo2.dissolved)
				{
					clanInfo2.strDissolved = msg.reader().readUTF();
				}
				Canvas.gameScr.showClanInfo(clanInfo2);
				break;
			}
			case -13:
				Canvas.gameScr.mainChar.idClan = -1;
				Canvas.startOKDlg("Bạn bị mời khỏi bang hội.");
				break;
			case -17:
			{
				mVector mVector2 = new mVector();
				short num53 = msg.reader().readShort();
				for (int num54 = 0; num54 < num53; num54++)
				{
					ChatInfo chatInfo = new ChatInfo();
					chatInfo.ID = msg.reader().readInt();
					chatInfo.name = msg.reader().readUTF();
					chatInfo.content = msg.reader().readUTF();
					mVector2.addElement(chatInfo);
				}
				ListScr.gI().setInfo(mVector2, 2, "THÔNG BÁO");
				ListScr.gI().switchToMe();
				Canvas.endDlg();
				break;
			}
			case -18:
			{
				string te = msg.reader().readUTF();
				MessageScr.gI().addTab(te, "Bang hội", 1);
				break;
			}
			case -19:
			{
				sbyte b29 = msg.reader().readByte();
				string title = msg.reader().readUTF();
				mVector mVector = new mVector();
				if (b29 == ListScr.TOP_CLAN)
				{
					short num20 = msg.reader().readShort();
					for (int num21 = 0; num21 < num20; num21++)
					{
						ClanInfo clanInfo = new ClanInfo();
						clanInfo.id = msg.reader().readShort();
						clanInfo.name = msg.reader().readUTF();
						clanInfo.master = msg.reader().readUTF();
						clanInfo.level = msg.reader().readByte();
						clanInfo.members = msg.reader().readShort();
						clanInfo.money = msg.reader().readLong();
						clanInfo.nationID = msg.reader().readByte();
						mVector.addElement(clanInfo);
					}
					ListScr.gI().setInfo(mVector, b29, "TOP BANG HỘI");
					ListScr.gI().switchToMe();
					Canvas.endDlg();
				}
				else if (b29 == ListScr.TOP || b29 == ListScr.TOP_CUC_BO)
				{
					Canvas.gameScr.onFriendList(msg, b29, title);
				}
				else if (b29 == ListScr.STRONGER)
				{
					Canvas.gameScr.onFriendList(msg, b29, "TOP CAO THỦ");
				}
				else
				{
					Canvas.gameScr.onFriendList(msg, b29, "TOP ĐẠI GIA");
				}
				break;
			}
			case -20:
			{
				int moneyClan = msg.reader().readInt();
				ActionPerform action = delegate
				{
					Canvas.gameScr.mainChar.charXu += moneyClan;
				};
				Canvas.startOKDlg("Bạn nhận được " + moneyClan + "xu từ bang hội.", action);
				break;
			}
			case -22:
			{
				Char char5 = new Char();
				sbyte b80 = msg.reader().readByte();
				if (b80 == 0)
				{
					char5.name = msg.reader().readUTF();
					char5.currentHead = msg.reader().readByte();
					char5.dir = 0;
					char5.level = msg.reader().readByte();
					char5.weapon_frame = 0;
					sbyte b81 = msg.reader().readByte();
					mVector mVector10 = new mVector();
					for (int num184 = 0; num184 < b81; num184++)
					{
						ItemInInventory itemInInventory8 = new ItemInInventory();
						char5.clazz = (itemInInventory8.clazz = (itemInInventory8.charClazz = msg.reader().readByte()));
						itemInInventory8.idTemplate = msg.reader().readShort();
						itemInInventory8.level = msg.reader().readByte();
						itemInInventory8.plusTemplate = msg.reader().readByte();
						itemInInventory8.itemID = msg.reader().readShort();
						itemInInventory8.colorName = msg.reader().readByte();
						itemInInventory8.attCreate = new short[5];
						for (int num185 = 0; num185 < 5; num185++)
						{
							itemInInventory8.attCreate[num185] = msg.reader().readShort();
						}
						itemInInventory8.heItem = msg.reader().readByte();
						itemInInventory8.beKicked = msg.reader().readByte();
						itemInInventory8.hangItem = msg.reader().readByte();
						itemInInventory8.magic_physic = msg.reader().readByte();
						itemInInventory8.islock = msg.reader().readByte();
						itemInInventory8.nameCharSeal = msg.reader().readUTF();
						for (int num186 = 0; num186 < itemInInventory8.newAtb.Length; num186++)
						{
							itemInInventory8.newAtb[num186] = msg.reader().readByte();
						}
						for (int num187 = 0; num187 < itemInInventory8.lockAtb.Length; num187++)
						{
							itemInInventory8.lockAtb[num187] = msg.reader().readByte();
						}
						for (int num188 = 0; num188 < itemInInventory8.addMoreLevelSkill.Length; num188++)
						{
							itemInInventory8.addMoreLevelSkill[num188] = msg.reader().readByte();
						}
						mVector10.addElement(itemInInventory8);
						ItemTemplate item2 = Res.getItem(itemInInventory8.charClazz, itemInInventory8.idTemplate);
						if (item2.type >= 3 && item2.type < 8)
						{
							ItemTemplate item3 = Res.getItem(char5.clazz, itemInInventory8.idTemplate);
							GameService.gI().doRequestWeapone(2, item2.type, item2.style, item3.colorItem);
							Canvas.startWaitDlg();
						}
					}
					char5.idClan = msg.reader().readShort();
					char5.idFashion = msg.reader().readByte();
					for (int num189 = 0; num189 < char5.idModel.Length; num189++)
					{
						char5.idModel[num189] = msg.reader().readShort();
					}
					char5.idAnimal = msg.reader().readByte();
					if (char5.idAnimal != -1)
					{
						char5.infoAnimal = msg.reader().readUTF();
					}
					char5.setWearingInfo(mVector10);
					if (Canvas.gameScr.focusedActor != null)
					{
						char5.ID = Canvas.gameScr.focusedActor.ID;
					}
					Canvas.gameScr.onViewCharInfo(char5);
				}
				else
				{
					mVector mVector11 = new mVector();
					int num190 = msg.reader().readByte();
					if (num190 > -1)
					{
						for (int num191 = 0; num191 < num190; num191++)
						{
							ItemInInventory itemInInventory9 = new ItemInInventory();
							itemInInventory9.charClazz = (itemInInventory9.clazz = msg.reader().readByte());
							itemInInventory9.itemID = msg.reader().readShort();
							itemInInventory9.idTemplate = msg.reader().readShort();
							itemInInventory9.plusTemplate = msg.reader().readByte();
							itemInInventory9.level = msg.reader().readByte();
							itemInInventory9.mDurable = msg.reader().readShort();
							itemInInventory9.durable = msg.reader().readShort();
							itemInInventory9.colorName = msg.reader().readByte();
							itemInInventory9.attCreate = new short[5];
							for (int num192 = 0; num192 < 5; num192++)
							{
								itemInInventory9.attCreate[num192] = msg.reader().readShort();
							}
							itemInInventory9.heItem = msg.reader().readByte();
							itemInInventory9.beKicked = msg.reader().readByte();
							itemInInventory9.hangItem = msg.reader().readByte();
							itemInInventory9.magic_physic = msg.reader().readByte();
							itemInInventory9.islock = msg.reader().readByte();
							itemInInventory9.nameCharSeal = msg.reader().readUTF();
							for (int num193 = 0; num193 < itemInInventory9.newAtb.Length; num193++)
							{
								itemInInventory9.newAtb[num193] = msg.reader().readByte();
							}
							for (int num194 = 0; num194 < itemInInventory9.lockAtb.Length; num194++)
							{
								itemInInventory9.lockAtb[num194] = msg.reader().readByte();
							}
							for (int num195 = 0; num195 < itemInInventory9.addMoreLevelSkill.Length; num195++)
							{
								itemInInventory9.addMoreLevelSkill[num195] = msg.reader().readByte();
							}
							mVector11.addElement(itemInInventory9);
						}
						Image image3 = null;
						sbyte b82 = msg.reader().readByte();
						int wimg2 = 0;
						int himg2 = 0;
						sbyte timeChangeFrame2 = 0;
						sbyte[] array36 = new sbyte[msg.reader().available()];
						while (msg.reader().available() > 0)
						{
							for (int num196 = 0; num196 < array36.Length; num196++)
							{
								array36[num196] = msg.reader().readByte();
							}
						}
						if (array36.Length > 0)
						{
							image3 = Res.createImgByByteArray(array36);
							timeChangeFrame2 = (sbyte)((b82 != 3) ? 6 : 3);
							if (image3 != null)
							{
								wimg2 = image3.getWidth();
								himg2 = image3.getHeight() / b82;
							}
						}
						Canvas.gameScr.onAnimalWearingInfo(Canvas.gameScr.saveIDViewInfoAnimal, mVector11, image3, b82, wimg2, himg2, timeChangeFrame2);
					}
					else
					{
						Canvas.startOKDlg("Chưa có thông tin linh thú");
					}
				}
				break;
			}
			case 105:
			{
				int num171 = msg.reader().readByte();
				int num172 = msg.reader().readByte();
				Res.locationMap = new short[num172][][];
				Res.nameMap = new string[num172][][];
				for (int num173 = 0; num173 < num172; num173++)
				{
					int num174 = msg.reader().readByte();
					Res.locationMap[num173] = new short[num174][];
					Res.nameMap[num173] = new string[num174][];
					for (int num175 = 0; num175 < num174; num175++)
					{
						Res.locationMap[num173][num175] = new short[num171 * 3];
						Res.nameMap[num173][num175] = new string[num171];
						for (int num176 = 0; num176 < num171 * 3; num176++)
						{
							Res.locationMap[num173][num175][num176] = msg.reader().readShort();
							if (num176 % 3 == 0)
							{
								Res.nameMap[num173][num175][num176 / 3] = msg.reader().readUTF();
							}
						}
					}
				}
				num172 = msg.reader().readByte();
				GameScr.mapID = new short[num172][];
				GameScr.idArrMap = new short[num172];
				for (int num177 = 0; num177 < num172; num177++)
				{
					GameScr.mapID[num177] = new short[num171];
					for (int num178 = 0; num178 < num171; num178++)
					{
						GameScr.mapID[num177][num178] = msg.reader().readShort();
					}
					GameScr.idArrMap[num177] = msg.reader().readShort();
				}
				int num179 = msg.reader().readByte();
				Res.localXaphu = new short[num179][];
				for (int num180 = 0; num180 < Res.localXaphu.Length; num180++)
				{
					Res.localXaphu[num180] = new short[num171 * 3];
				}
				Res.namMap = new string[num179][];
				for (int num181 = 0; num181 < Res.namMap.Length; num181++)
				{
					Res.namMap[num181] = new string[num171];
				}
				for (int num182 = 0; num182 < num179; num182++)
				{
					for (int num183 = 0; num183 < num171 * 3; num183++)
					{
						Res.localXaphu[num182][num183] = msg.reader().readShort();
						if (num183 % 3 == 0)
						{
							Res.namMap[num182][num183 / 3] = msg.reader().readUTF();
						}
					}
				}
				break;
			}
			case -24:
			{
				sbyte b78 = msg.reader().readByte();
				string info5 = msg.reader().readUTF();
				if (b78 == 0)
				{
					HelpScr.gI().setInfo(info5);
				}
				else if (b78 != 1)
				{
				}
				break;
			}
			case -26:
				Canvas.gameScr.onMSGServer(msg.reader().readUTF());
				break;
			case -27:
			{
				int num149 = msg.reader().readByte();
				sbyte b67 = msg.reader().readByte();
				if (b67 != -1)
				{
					int num150 = msg.reader().readShort();
					sbyte[] array31 = new sbyte[num150];
					for (int num151 = 0; num151 < num150; num151++)
					{
						array31[num151] = msg.reader().readByte();
					}
					int num152 = msg.reader().readShort();
					sbyte[] array32 = new sbyte[num152];
					for (int num153 = 0; num153 < num152; num153++)
					{
						array32[num153] = msg.reader().readByte();
					}
					Image image = Res.createImgByHeader(array31, array32);
					short dxWear = msg.reader().readByte();
					short dyWear = msg.reader().readByte();
					switch (num149)
					{
					case 0:
						CreateCharScr.gI().ch.imgWpa = image;
						CreateCharScr.gI().ch.dxWear = dxWear;
						CreateCharScr.gI().ch.dyWear = dyWear;
						break;
					case 1:
						Canvas.gameScr.mainChar.weaponIndex = b67;
						Canvas.gameScr.mainChar.imgWpa = image;
						Canvas.gameScr.mainChar.dxWear = dxWear;
						Canvas.gameScr.mainChar.dyWear = dyWear;
						break;
					case 2:
						if (WindowInfoScr.getIndex() == 1)
						{
							WindowInfoScr.charWearing.imgWpa = image;
							WindowInfoScr.charWearing.dxWear = dxWear;
							WindowInfoScr.charWearing.dyWear = dyWear;
						}
						else
						{
							WindowInfoScr.gI().imgWeaponAvatar = image;
						}
						break;
					}
				}
				Canvas.endDlg();
				break;
			}
			case -30:
			{
				int userId2 = msg.reader().readShort();
				sbyte idMenu2 = msg.reader().readByte();
				int num141 = msg.reader().readByte();
				string[] array30 = new string[num141];
				for (int num142 = 0; num142 < num141; num142++)
				{
					array30[num142] = msg.reader().readUTF();
				}
				Canvas.gameScr.onMenuOption(userId2, idMenu2, array30);
				break;
			}
			case -31:
			{
				int userID = msg.reader().readShort();
				sbyte idMenu = msg.reader().readByte();
				string nameText = msg.reader().readUTF();
				int typeInput = msg.reader().readByte();
				Canvas.gameScr.onTextBox(userID, idMenu, nameText, typeInput);
				break;
			}
			case -32:
			{
				int idB = msg.reader().readShort();
				sbyte idPopup = msg.reader().readByte();
				string text5 = msg.reader().readUTF();
				ActionPerform yesAction3 = delegate
				{
					Canvas.endDlg();
					GameService.gI().doCustomPopup(idB, idPopup, text5, 1);
				};
				ActionPerform noAction2 = delegate
				{
					Canvas.endDlg();
					GameService.gI().doCustomPopup(idB, idPopup, text5, 0);
				};
				Canvas.startYesNoDlg(text5, yesAction3, noAction2);
				break;
			}
			case -33:
			{
				int x4 = msg.reader().readByte() * 16;
				int y2 = msg.reader().readByte() * 16;
				short num140 = msg.reader().readShort();
				Canvas.gameScr.posBoss = new Position(x4, y2);
				Canvas.gameScr.posBoss.index = num140;
				if (Canvas.gameScr.posBoss.index == Canvas.gameScr.map)
				{
					EffectManager.lowEffects.addElement(new WayPoint(x4, y2, num140, 0, isWay: true));
					EffectManager.hiEffects.addElement(new WayPoint(x4, y2, num140, 1, isWay: true));
				}
				break;
			}
			case -37:
			{
				sbyte b63 = msg.reader().readByte();
				if (b63 == 0)
				{
					string text15 = "`" + msg.reader().readUTF();
					sbyte b64 = msg.reader().readByte();
					if (b64 == 0)
					{
						WindowInfoScr.idMonsterClanQuest = msg.reader().readByte();
						WindowInfoScr.numberQuestAll = msg.reader().readShort();
						WindowInfoScr.numberQuestGet = msg.reader().readShort();
						string text16 = text15;
						text15 = text16 + "\nHoàn thành: " + WindowInfoScr.numberQuestGet + "/" + WindowInfoScr.numberQuestAll + "Con";
					}
					else if (b64 == 1)
					{
						GameScr.idItemClanquest = msg.reader().readByte();
						WindowInfoScr.numberQuestAll = msg.reader().readShort();
						WindowInfoScr.numberQuestGet = msg.reader().readShort();
						string text16 = text15;
						text15 = text16 + "\nĐã lấy: " + WindowInfoScr.numberQuestGet + "/" + WindowInfoScr.numberQuestAll + text15 + text15;
					}
					else if (b64 == 2)
					{
						GameScr.posNpcReceiveClan = new Position();
						GameScr.posNpcReceiveClan.index = msg.reader().readByte();
						for (int num116 = 0; num116 < Canvas.gameScr.actors.size(); num116++)
						{
							Actor actor = (Actor)Canvas.gameScr.actors.elementAt(num116);
							if (actor is NPC && ((NPC)actor).type == GameScr.posNpcReceiveClan.index)
							{
								GameScr.posNpcReceiveClan.x = actor.x;
								GameScr.posNpcReceiveClan.y = actor.y;
								break;
							}
						}
					}
					Res.PORTION_ITEM_NAME_CLAN = msg.reader().readUTF();
					WindowInfoScr.gI().questClan(text15, 0);
				}
				else if (b63 == 1)
				{
					string content = msg.reader().readUTF();
					Canvas.gameScr.onContentClanQuest(content);
				}
				else if (b63 == 2)
				{
					string str2 = msg.reader().readUTF();
					Res.PORTION_ITEM_NAME_CLAN = msg.reader().readUTF();
					ViewInfoScr.gI().setInfo("NHIỆM VỤ", str2);
					ViewInfoScr.gI().switchToMe();
					Canvas.endDlg();
				}
				break;
			}
			case -38:
			{
				GameScr.isFight = msg.reader().readBoolean();
				int num113 = msg.reader().readByte();
				GameScr.timeChiemThanh = new long[num113];
				GameScr.nameChiemThanh = new string[num113];
				GameScr.curTimeCT = new long[num113];
				GameScr.idChiemThanh = new short[num113];
				GameScr.nameClan = new string[num113];
				for (int num114 = 0; num114 < num113; num114++)
				{
					GameScr.timeChiemThanh[num114] = msg.reader().readShort();
					short num115 = msg.reader().readShort();
					GameScr.nameChiemThanh[num114] = msg.reader().readUTF();
					GameScr.curTimeCT[num114] = mSystem.getCurrentTimeMillis() / 1000;
					Char char4 = (Char)Canvas.gameScr.findCharByID(num115);
					GameScr.idChiemThanh[num114] = num115;
					if (char4 != null)
					{
						char4.EffFace = null;
					}
					if (char4 != null && GameScr.timeChiemThanh[num114] > 0)
					{
						char4.EffFace = new WayPoint(char4.x, char4.y - 5, 1, 1, isWay: false);
					}
					GameScr.nameClan[num114] = msg.reader().readUTF().ToLower();
				}
				break;
			}
			case -39:
			{
				sbyte weather = msg.reader().readByte();
				int number = msg.reader().readShort();
				int timeLimit = msg.reader().readInt();
				GameScr.onWeather(weather, number, timeLimit);
				break;
			}
			case -42:
			{
				short idChar = msg.reader().readShort();
				sbyte b62 = (sbyte)(msg.reader().available() / 2);
				sbyte[] array25 = new sbyte[b62];
				sbyte[] array26 = new sbyte[b62];
				int num112 = 0;
				while (msg.reader().available() > 0)
				{
					array25[num112] = msg.reader().readByte();
					array26[num112] = msg.reader().readByte();
					num112++;
				}
				Canvas.gameScr.onSetCharKham(idChar, array25, array26);
				break;
			}
			case -43:
			{
				int num105 = msg.reader().readByte();
				if (num105 > 0)
				{
					Image[] array23 = new Image[num105];
					for (int num106 = 0; num106 < num105; num106++)
					{
						try
						{
							sbyte[] array24 = new sbyte[msg.reader().readInt()];
							for (int num107 = 0; num107 < array24.Length; num107++)
							{
								array24[num107] = msg.reader().readByte();
							}
							array23[num106] = Image.createImage(array24, 0, array24.Length);
						}
						catch (Exception)
						{
						}
					}
					sbyte b61 = msg.reader().readByte();
					for (int num108 = 0; num108 < b61; num108++)
					{
						DynamicObj dynamicObj = new DynamicObj();
						int num109 = msg.reader().readByte();
						short num110 = msg.reader().readByte();
						short num111 = msg.reader().readByte();
						dynamicObj.w = msg.reader().readByte();
						dynamicObj.h = msg.reader().readByte();
						dynamicObj.nFrame = msg.reader().readByte();
						num110 = (short)(num110 * 16);
						num111 = (short)(num111 * 16);
						dynamicObj.setPosTo(num110, num111);
						dynamicObj.img = array23[num109];
						dynamicObj.height = (short)(dynamicObj.img.getHeight() / dynamicObj.nFrame);
						Canvas.gameScr.onDynamicObj(dynamicObj);
					}
				}
				break;
			}
			case -47:
			{
				short num103 = msg.reader().readShort();
				bool isSave = msg.reader().readBoolean();
				short num104 = msg.reader().readShort();
				sbyte[] data7 = new sbyte[num104];
				msg.reader().read(ref data7);
				if (Res.monsterTemplates[num103] != null)
				{
					Res.monsterTemplates[num103].onImage(isSave, data7);
				}
				break;
			}
			case -48:
			{
				sbyte b60 = msg.reader().readByte();
				if (b60 != -1)
				{
					short num101 = msg.reader().readShort();
					sbyte[] data6 = new sbyte[num101];
					msg.reader().read(ref data6);
					Res.getTree(b60)?.onImage(data6, b60);
				}
				else
				{
					sbyte type2 = msg.reader().readByte();
					sbyte id2 = msg.reader().readByte();
					sbyte[] array22 = new sbyte[msg.reader().available()];
					for (int num102 = 0; num102 < array22.Length; num102++)
					{
						array22[num102] = msg.reader().readByte();
					}
					Canvas.gameScr.onLoadCloth(array22, type2, id2);
				}
				break;
			}
			case -49:
			{
				sbyte b46 = msg.reader().readByte();
				short num72 = msg.reader().readByte();
				if (b46 == 0)
				{
					EffectData effect3 = EffectServerManager.getEffect(num72);
					if (effect3 == null)
					{
						GameService.gI().doRequestEffectData(num72);
					}
					EffectServerManager effectServerManager = new EffectServerManager();
					effectServerManager.ID = num72;
					effectServerManager.style = msg.reader().readByte();
					effectServerManager.loopLimit = (effectServerManager.count = msg.reader().readByte());
					effectServerManager.loop = msg.reader().readShort();
					effectServerManager.loopType = msg.reader().readByte();
					if (effectServerManager.loopType == 1)
					{
						effectServerManager.radius = msg.reader().readShort();
					}
					else if (effectServerManager.loopType == 2)
					{
						sbyte b47 = msg.reader().readByte();
						effectServerManager.xLoop = new short[b47];
						effectServerManager.yLoop = new short[b47];
						for (int num73 = 0; num73 < b47; num73++)
						{
							effectServerManager.xLoop[num73] = msg.reader().readShort();
							effectServerManager.yLoop[num73] = msg.reader().readShort();
						}
					}
					if (effectServerManager.style == 0)
					{
						effectServerManager.idPlayer = msg.reader().readShort();
					}
					else
					{
						effectServerManager.x = msg.reader().readShort();
						effectServerManager.y = msg.reader().readShort();
					}
					Canvas.gameScr.onEffect(effectServerManager);
				}
				else
				{
					EffectData effectData = new EffectData();
					effectData.ID = num72;
					effectData.setInfo(msg);
					EffectServerManager.effectList.addElement(effectData);
				}
				break;
			}
			case -50:
				Canvas.gameScr.setNPC_server(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte());
				break;
			case -51:
			{
				short num71 = msg.reader().readShort();
				sbyte[] data4 = new sbyte[msg.reader().available()];
				msg.reader().read(ref data4);
				ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(string.Empty + num71);
				imageIcon.isLoad = false;
				imageIcon.img = Image.createImage(data4, 0, data4.Length);
				break;
			}
			case -52:
			{
				string nameItem = msg.reader().readUTF();
				short idItem = msg.reader().readShort();
				sbyte b43 = msg.reader().readByte();
				mVector mVector5 = new mVector();
				for (int num68 = 0; num68 < b43; num68++)
				{
					Mineral mineral = new Mineral();
					mineral.name = msg.reader().readUTF();
					mineral.idTemplate = msg.reader().readShort();
					mineral.number = msg.reader().readByte();
					mVector5.addElement(mineral);
				}
				sbyte b44 = msg.reader().readByte();
				sbyte b45 = 0;
				try
				{
					b45 = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onCheDo(nameItem, idItem, mVector5, b44, b45);
				break;
			}
			case -55:
				Canvas.gameScr.onDropItem2Ground(msg);
				break;
			case -56:
			{
				sbyte b36 = msg.reader().readByte();
				SkillClan[] array11 = null;
				array11 = new SkillClan[b36];
				for (int num58 = 0; num58 < b36; num58++)
				{
					array11[num58] = new SkillClan();
					array11[num58].time = msg.reader().readShort();
					array11[num58].idIcon = msg.reader().readByte();
					array11[num58].info = msg.reader().readUTF();
					array11[num58].lv = msg.reader().readByte();
				}
				sbyte b37 = msg.reader().readByte();
				SkillClan[] array12 = null;
				array12 = new SkillClan[b37];
				for (int num59 = 0; num59 < b37; num59++)
				{
					array12[num59] = new SkillClan();
					array12[num59].time = msg.reader().readShort();
					array12[num59].idIcon = msg.reader().readByte();
					array12[num59].info = msg.reader().readUTF();
					array12[num59].lv = msg.reader().readByte();
				}
				Canvas.gameScr.onSkillClan(array11, array12);
				break;
			}
			case -57:
			{
				sbyte b12 = msg.reader().readByte();
				if (b12 == 0)
				{
					bool flag = msg.reader().readBoolean();
					short num4 = msg.reader().readShort();
					sbyte b13 = msg.reader().readByte();
					if (Canvas.gameScr.mainChar.ID == num4)
					{
						Canvas.gameScr.mainChar.isAnimal = flag;
						if (flag)
						{
							Canvas.gameScr.mainChar.myAnimal = new IsAnimal();
							Canvas.gameScr.mainChar.myAnimal.idMonster = b13;
							Canvas.gameScr.mainChar.myAnimal.type = b13;
							Canvas.gameScr.mainChar.effAnimal = new WayPoint(Canvas.gameScr.mainChar.x, Canvas.gameScr.mainChar.y - 5, 1, 1, isWay: false);
							Canvas.gameScr.mainChar.timeRemoEffanimal = mSystem.getCurrentTimeMillis() / 1000 + 5;
						}
						else if (Canvas.gameScr.mainChar.myAnimal != null)
						{
							Canvas.gameScr.mainChar.myAnimal = null;
						}
					}
					else
					{
						Char @char = (Char)Canvas.gameScr.findCharByID(num4);
						if (@char != null)
						{
							@char.isAnimal = flag;
							if (flag)
							{
								@char.myAnimal = new IsAnimal();
								@char.myAnimal.idMonster = b13;
								@char.myAnimal.type = b13;
								@char.effAnimal = new WayPoint(@char.x, @char.y - 5, 1, 1, isWay: false);
								@char.timeRemoEffanimal = mSystem.getCurrentTimeMillis() / 1000 + 5;
							}
							else if (@char.myAnimal != null)
							{
								@char.myAnimal = null;
							}
						}
					}
					if (IsAnimal.img[b13] == null)
					{
						Canvas.gameScr.gameService.sendGetImgIsanimal(b13, num4);
					}
				}
				else
				{
					sbyte b14 = msg.reader().readByte();
					int num5 = msg.reader().readShort();
					sbyte[] array5 = new sbyte[num5];
					for (int k = 0; k < num5; k++)
					{
						array5[k] = msg.reader().readByte();
					}
					IsAnimal.hImg[b14] = msg.reader().readByte();
					IsAnimal.img[b14] = Res.createImgByByteArray(array5);
					IsAnimal.wimg[b14] = IsAnimal.img[b14].getWidth();
					sbyte b15 = msg.reader().readByte();
					IsAnimal.frameRun[b14] = new sbyte[4][];
					for (int l = 0; l < 4; l++)
					{
						IsAnimal.frameRun[b14][l] = new sbyte[b15];
					}
					for (int m = 0; m < IsAnimal.frameRun[b14][0].Length; m++)
					{
						IsAnimal.frameRun[b14][0][m] = msg.reader().readByte();
						IsAnimal.frameRun[b14][1][m] = msg.reader().readByte();
						IsAnimal.frameRun[b14][2][m] = msg.reader().readByte();
						IsAnimal.frameRun[b14][3][m] = msg.reader().readByte();
					}
					sbyte b16 = msg.reader().readByte();
					IsAnimal.frameStand[b14] = new sbyte[4][];
					for (int n = 0; n < 4; n++)
					{
						IsAnimal.frameStand[b14][n] = new sbyte[b16];
					}
					for (int num6 = 0; num6 < IsAnimal.frameStand[b14][0].Length; num6++)
					{
						IsAnimal.frameStand[b14][0][num6] = msg.reader().readByte();
						IsAnimal.frameStand[b14][1][num6] = msg.reader().readByte();
						IsAnimal.frameStand[b14][2][num6] = msg.reader().readByte();
						IsAnimal.frameStand[b14][3][num6] = msg.reader().readByte();
					}
					sbyte b17 = msg.reader().readByte();
					IsAnimal.frameAt[b14] = new sbyte[4][];
					for (int num7 = 0; num7 < 4; num7++)
					{
						IsAnimal.frameAt[b14][num7] = new sbyte[b17];
					}
					for (int num8 = 0; num8 < IsAnimal.frameAt[b14][0].Length; num8++)
					{
						IsAnimal.frameAt[b14][0][num8] = msg.reader().readByte();
						IsAnimal.frameAt[b14][1][num8] = msg.reader().readByte();
						IsAnimal.frameAt[b14][2][num8] = msg.reader().readByte();
						IsAnimal.frameAt[b14][3][num8] = msg.reader().readByte();
					}
					IsAnimal.addx[b14] = msg.reader().readByte();
					IsAnimal.addy[b14] = msg.reader().readByte();
				}
				break;
			}
			case -59:
			{
				sbyte b5 = msg.reader().readByte();
				for (sbyte b6 = 0; b6 < b5; b6 = (sbyte)(b6 + 1))
				{
					sbyte b7 = msg.reader().readByte();
					sbyte b8 = msg.reader().readByte();
					string text6 = msg.reader().readUTF();
					sbyte b9 = msg.reader().readByte();
					int timeLive = msg.reader().readInt();
					sbyte b10 = msg.reader().readByte();
					sbyte b11 = msg.reader().readByte();
					bool isBuyOk = msg.reader().readBoolean();
					sbyte addy = msg.reader().readByte();
					sbyte colorString = msg.reader().readByte();
					Canvas.gameScr.setMyFarm(b7, b8, b10 * 16, b11 * 16, text6, text6, b9, timeLive, isBuyOk, addy, colorString);
				}
				Canvas.gameScr.xBeginFrame = (short)getMinMax(Canvas.gameScr.actors, 0, 5000);
				Canvas.gameScr.yBeginFrame = (short)getMinMax(Canvas.gameScr.actors, 1, 5000);
				Canvas.gameScr.xTheendFrame = (short)getMinMax(Canvas.gameScr.actors, 2, -1);
				Canvas.gameScr.yTheendFrame = (short)getMinMax(Canvas.gameScr.actors, 3, -1);
				break;
			}
			case -60:
				Canvas.gameScr.addMsgWorld(msg.reader().readUTF());
				break;
			case -62:
			{
				sbyte b2 = msg.reader().readByte();
				if (b2 == 0)
				{
					MiniGame.gI().switchToMe();
					MiniGame.gI().onMiniGame(msg);
				}
				else if (b2 == 1)
				{
					sbyte id = msg.reader().readByte();
					string infoBox = msg.reader().readUTF();
					sbyte b3 = msg.reader().readByte();
					string[] array3 = new string[b3];
					for (sbyte b4 = 0; b4 < b3; b4 = (sbyte)(b4 + 1))
					{
						array3[b4] = msg.reader().readUTF();
					}
					MiniGame.gI().getInfoBox(id, infoBox, array3);
				}
				else if (b2 == 2)
				{
					MiniGame.gI().reSetGame();
					Canvas.gameScr.switchToMe();
				}
				break;
			}
			case -63:
				MTickets.gi().onHappy(msg);
				MTickets.gi().switchToMe();
				break;
			case -61:
			{
				sbyte idColor = msg.reader().readByte();
				sbyte lv = msg.reader().readByte();
				sbyte slNguyenLieu = msg.reader().readByte();
				short startIDNL = msg.reader().readShort();
				sbyte magic = msg.reader().readByte();
				sbyte khoa = 0;
				try
				{
					khoa = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				Canvas.gameScr.onEpDothu(1000, idColor, lv, startIDNL, slNguyenLieu, magic, khoa);
				break;
			}
			case 87:
				Canvas.gameScr.onLuckyDraw(msg);
				break;
			}
		}
		catch (Exception ex47)
		{
			Out.println(" Loi tai >>>>>>>>>>>> cmd thu >>  " + msg.command + " ly do" + ex47.StackTrace);
		}
	}

	public int getMinMax(mVector data, sbyte typeXY, int aa)
	{
		for (int i = 0; i < data.size(); i++)
		{
			Actor actor = (Actor)data.elementAt(i);
			if (actor.catagory != Actor.CAT_MY_GROUND)
			{
				continue;
			}
			Ground ground = (Ground)actor;
			switch (typeXY)
			{
			case 0:
				if (aa > ground.x)
				{
					aa = ground.x;
				}
				break;
			case 1:
				if (aa > ground.y)
				{
					aa = ground.y;
				}
				break;
			case 2:
				if (aa < ground.x)
				{
					aa = ground.x;
				}
				break;
			case 3:
				if (aa < ground.y)
				{
					aa = ground.y;
				}
				break;
			}
		}
		return aa;
	}

	public int getIndexClassFromItemID(int itemID)
	{
		if (itemID >= 79 && itemID <= 113)
		{
			return (itemID - 79) / 7;
		}
		if (itemID >= 174 && itemID <= 213)
		{
			return (itemID - 174) / 8;
		}
		if (itemID >= 214 && itemID <= 263)
		{
			return (itemID - 214) / 10;
		}
		return 0;
	}
}
