public class Quest
{
	public const sbyte TYPE_KILL_MONS = 0;

	public const sbyte TYPE_TRANSFORM = 1;

	public const sbyte TYPE_GET_ITEM = 2;

	public const sbyte TYPE_TALK = 3;

	public const sbyte TYPE_KILL_MONSTER_LEVEL = 4;

	public const sbyte RECEIVE = 0;

	public const sbyte DEL = 2;

	public const sbyte RESPONSE = 1;

	public sbyte type;

	public short idQuest;

	public short idNpcReceive = 32000;

	public short idNpcResponse = 32000;

	public sbyte main_sub;

	public mVector content = new mVector();

	public mVector rescontent = new mVector();

	public string scontent = string.Empty;

	public string decript = string.Empty;

	public string name = string.Empty;

	public short[] idMonsKill;

	public short[] allMonsKilled;

	public short[] totalMonskill;

	public sbyte stateQuest;

	public short[] idItemGet;

	public short[] allItemGet;

	public short[] totalItemGet;

	public string infoGift = string.Empty;

	public bool isShow;

	public short deltaLv;

	private sbyte index;

	public Quest(int id)
	{
		index = 0;
		stateQuest = -1;
		idQuest = (short)id;
	}

	public void update(Actor mychar, Actor npc)
	{
		if (!Canvas.keyPressed[5])
		{
			return;
		}
		Canvas.keyPressed[5] = false;
		if (npc != null && ((npc.getTypeNpc() != idNpcReceive && stateQuest == 0) || (npc.getTypeNpc() != idNpcResponse && stateQuest == 1)))
		{
			isShow = false;
			index = 0;
			return;
		}
		index++;
		if (stateQuest == 0)
		{
			if (index >= content.size() - 1)
			{
				if (type == 3)
				{
					string str = (string)content.elementAt(index);
					GameScr.addChat(npc, str, 100);
					stateQuest = GameScr.STATE_DONE;
					GameService.gI().onSendInfoQuest(1, idQuest, main_sub);
					isShow = false;
					index = 0;
				}
				return;
			}
			string text = (string)content.elementAt(index);
			if (text.StartsWith("1"))
			{
				GameScr.addChat(npc, text.Substring(1), 100);
			}
			else
			{
				GameScr.addChat(mychar, text.Substring(1), 100);
			}
			if (type != 3 && index >= content.size() - 2)
			{
				index++;
				ActionPerform yesAction = delegate
				{
					GameService.gI().onSendInfoQuest(0, idQuest, main_sub);
					isShow = false;
					Canvas.endDlg();
				};
				ActionPerform noAction = delegate
				{
					isShow = false;
					index = 0;
					Canvas.endDlg();
				};
				Canvas.startYesNoDlg((string)content.elementAt(index), yesAction, noAction);
			}
		}
		else if (stateQuest == 1)
		{
			if (index >= rescontent.size() - 1)
			{
				GameService.gI().onSendInfoQuest(1, idQuest, main_sub);
				isShow = false;
				stateQuest = GameScr.STATE_DONE;
				Canvas.endDlg();
				return;
			}
			string text2 = (string)rescontent.elementAt(index);
			if (text2.StartsWith("1"))
			{
				GameScr.addChat(npc, text2.Substring(1), 100);
			}
			else
			{
				GameScr.addChat(mychar, text2.Substring(1), 100);
			}
			if (index >= rescontent.size() - 2)
			{
				index++;
				GameService.gI().onSendInfoQuest(1, idQuest, main_sub);
				isShow = false;
				stateQuest = GameScr.STATE_DONE;
				Canvas.endDlg();
			}
		}
		else if (stateQuest == 2)
		{
			GameScr.addChat(npc, decript, 100);
			isShow = false;
			index = 0;
		}
	}

	public void startTalk(Actor mychar, Actor npc, int state)
	{
		index = 0;
		string text = string.Empty;
		switch (state)
		{
		case 0:
			text = (string)content.elementAt(index);
			break;
		case 2:
			text = decript;
			GameScr.addChat(npc, text, 100);
			return;
		case 1:
			text = (string)rescontent.elementAt(index);
			break;
		}
		if (text.StartsWith("1"))
		{
			GameScr.addChat(npc, text.Substring(1), 100);
		}
		else
		{
			GameScr.addChat(mychar, text.Substring(1), 100);
		}
		isShow = true;
		if (stateQuest == 0 && type != 3 && content.size() <= 2)
		{
			index++;
			ActionPerform yesAction = delegate
			{
				GameService.gI().onSendInfoQuest(0, idQuest, main_sub);
				isShow = false;
				Canvas.endDlg();
			};
			ActionPerform noAction = delegate
			{
				isShow = false;
				index = 0;
				Canvas.endDlg();
			};
			Canvas.startYesNoDlg((string)content.elementAt(index), yesAction, noAction);
		}
		else if (stateQuest == 1 && type != 3 && rescontent.size() <= 2)
		{
			index++;
			GameService.gI().onSendInfoQuest(1, idQuest, main_sub);
			isShow = false;
			stateQuest = GameScr.STATE_DONE;
			Canvas.endDlg();
		}
	}

	public string getItemQuest(int type)
	{
		if (this.type == 2)
		{
			for (int i = 0; i < idItemGet.Length; i++)
			{
				if (idItemGet[i] == type && allItemGet[i] < totalItemGet[i])
				{
					allItemGet[i]++;
					return (allItemGet[i] >= totalItemGet[i]) ? ("Nhiệm vụ " + name + " đã hoàn thành") : ("Nhặt được " + allItemGet[i] + "/" + totalItemGet[i] + " " + ItemQuest.NAME_ITEM[type]);
				}
			}
		}
		return string.Empty;
	}

	public string killMonster(int idMonstemplate, string nameMons)
	{
		if (type == 0)
		{
			for (int i = 0; i < idMonsKill.Length; i++)
			{
				if (idMonsKill[i] == idMonstemplate && allMonsKilled[i] < totalMonskill[i])
				{
					allMonsKilled[i]++;
					return (allMonsKilled[i] >= totalMonskill[i]) ? ("Nhiệm vụ " + name + " đã hoàn thành") : ("Giết được " + allMonsKilled[i] + "/" + totalMonskill[i] + " " + nameMons);
				}
			}
		}
		return string.Empty;
	}

	public string killMonsterByLv(int lv)
	{
		if (type == 4 && lv <= deltaLv)
		{
			for (int i = 0; i < allMonsKilled.Length; i++)
			{
				if (allMonsKilled[i] < totalMonskill[i])
				{
					allMonsKilled[i]++;
					return (allMonsKilled[i] >= totalMonskill[i]) ? ("Nhiệm vụ " + name + " đã hoàn thành") : ("Giết được " + allMonsKilled[i] + "/" + totalMonskill[i] + " ");
				}
			}
		}
		return string.Empty;
	}

	public string getInfoPaintScr()
	{
		string result = string.Empty;
		if (stateQuest == 1)
		{
			result = decript;
			result = result + "|" + infoGift;
		}
		else if (stateQuest == 2)
		{
			switch (type)
			{
			case 2:
				result = ItemQuest.NAME_ITEM[idItemGet[0]] + ": " + allItemGet[0] + "/" + totalItemGet[0];
				for (int j = 1; j < idItemGet.Length; j++)
				{
					string text = result;
					result = text + "|" + ItemQuest.NAME_ITEM[idItemGet[j]] + ": " + allItemGet[j] + "/" + totalItemGet[j];
				}
				result = result + "|" + infoGift;
				break;
			case 0:
				result = Res.monsterTemplates[idMonsKill[0]].name + ": " + allMonsKilled[0] + "/" + totalMonskill[0];
				for (int i = 1; i < idMonsKill.Length; i++)
				{
					string text = result;
					result = text + "|" + Res.monsterTemplates[idMonsKill[i]] + ": " + allMonsKilled[i] + "/" + totalMonskill[i];
				}
				result = result + "|" + infoGift;
				break;
			case 4:
				result = "Giết: " + allMonsKilled[0] + "/" + totalMonskill[0];
				result = result + "|" + infoGift;
				break;
			}
		}
		return result;
	}

	public bool isTalk()
	{
		return type == 3;
	}

	public bool isGetItem()
	{
		return type == 2;
	}

	public bool isKillMons()
	{
		return type == 0;
	}

	public bool isKillMonsByLv()
	{
		return type == 4;
	}

	public bool isTransform()
	{
		return type == 1;
	}

	public bool isFinish()
	{
		return stateQuest == 1;
	}

	public bool isReceive()
	{
		return stateQuest == 0;
	}

	public bool isWorking()
	{
		return stateQuest == 2;
	}
}
