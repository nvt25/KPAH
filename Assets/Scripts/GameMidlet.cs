using System;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class GameMidlet
{
	public static GameMidlet instance;

	public static string version = "2.2.5";

	public static string client_Provider = "0";

	public static string provider = "-1";

	public static string agent = "-1";

	public static bool loadEnglish;

	public static bool isEnglish;

	public static int hDrawStringCmd;

	public static int verSionCode = 1;

	public static int MAX_W = 480;

	public static int MAX_H = 320;

	public static string url = string.Empty;

	public static string numberSupport = "19001530";

	public static bool isLoadAgentPro;

	public static bool isKPAH = true;

	public GameMidlet()
	{
		instance = this;
		MFont.init();
	}

	public void load()
	{
		ServerListScr.loadSv(isKPAH);
		Canvas.imgLogo = Canvas.getLogo();
		RMS.clearRecord("nqshImgPotionNew");
		Res.loadImgMap();
		Util.load();
		Main.canvas.init();
		Main.canvas.sizeChanged(0, 0);
		Res.loadTreeImage();
		Res.loadMonster();
		Res.loadPart2();
		Session_ME.gI().setHandler(MessageHandler.gI());
		GameService.gI().setSession(Session_ME.gI());
		Res.resetImgMonsTemp();
		Tilemap.loadMap(0, null);
		ServerListScr.gI().switchToMe();
		Canvas.isLoad = false;
		if (isKPAH)
		{
			client_Provider = "0";
			provider = "-1";
			agent = "-1";
		}
		else
		{
			client_Provider = "1";
			provider = "1";
			agent = "3";
			isLoadAgentPro = false;
		}
		string str = "/agent";
		if (!isKPAH)
		{
			str = "/vtcagent";
		}
		string str2 = "/provider";
		if (!isKPAH)
		{
			str2 = "/vtcprovider";
		}
		if (isLoadAgentPro)
		{
			agent = RMS.loadRMSString("agent");
			if (agent == null)
			{
				agent = "-1";
			}
			provider = RMS.loadRMSString("provider");
			if (provider == null)
			{
				provider = "-1";
			}
		}
		else
		{
			try
			{
				StringReader stringReader = null;
				TextAsset textAsset = (TextAsset)Resources.Load(Main.res + str, typeof(TextAsset));
				stringReader = new StringReader(textAsset.text);
				if (stringReader != null)
				{
					string text = stringReader.ReadLine();
					if (text != null)
					{
						string text2 = text.ToString();
						agent = text2.Trim();
					}
				}
			}
			catch (IOException)
			{
			}
			try
			{
				StringReader stringReader2 = null;
				TextAsset textAsset2 = (TextAsset)Resources.Load(Main.res + str2, typeof(TextAsset));
				stringReader2 = new StringReader(textAsset2.text);
				if (stringReader2 != null)
				{
					string text3 = stringReader2.ReadLine();
					if (text3 != null)
					{
						string text4 = text3.ToString();
						provider = text4.Trim();
					}
				}
			}
			catch (IOException)
			{
			}
		}
		UnityEngine.Debug.Log(isLoadAgentPro + " agent >>>>>" + agent);
		UnityEngine.Debug.Log(isLoadAgentPro + " provider >>>>>" + provider);
		UnityEngine.Debug.Log(isLoadAgentPro + " client  >>>>>" + client_Provider);
	}

	public static string connectHTTP(string link)
	{
		string result = null;
		WebResponse webResponse = null;
		StreamReader streamReader = null;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
			httpWebRequest.Method = "GET";
			webResponse = httpWebRequest.GetResponse();
			streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			result = streamReader.ReadToEnd();
			return result;
		}
		catch (Exception ex)
		{
			Out.println("Loi tai http : ma loi : " + ex.StackTrace);
			return result;
		}
		finally
		{
			streamReader?.Close();
			webResponse?.Close();
		}
	}

	protected void destroyApp(bool arg0)
	{
	}

	protected void pauseApp()
	{
	}

	protected void startApp()
	{
	}

	public static void requestLink(string link)
	{
		try
		{
			Main.main.platformRequest(link);
			Main.main.OnApplicationQuit();
		}
		catch (Exception)
		{
		}
	}

	public static void destroy()
	{
		Canvas.instance.timeRemove = -1L;
		Canvas.infoDisConnect = "Mất kết nối.";
		Canvas.xInfoDisConnect = Canvas.w;
		Main.isDisConnect = true;
		Main.isStartSaveIp = false;
		Canvas.endDlg();
		Canvas.instance.init();
		Session_ME.gI().close();
		Tilemap.loadMap(0, null);
		ServerListScr.gI().switchToMe();
	}

	public static void sendSMS(string data, string to, Command cmdYes, Command cmdNo)
	{
		if (Main.isPC)
		{
			Canvas.startOKDlg("Không thể gửi tin nhắn với phiên bản này");
			return;
		}
		if (to.Contains("sms://"))
		{
			to = to.Remove(0, 6);
		}
		Out.LogWarning("SEND SMS: " + data + " ---> " + to);
		if (SMS.send(data, to) == -1)
		{
			cmdNo?.perform();
		}
		else
		{
			cmdYes?.perform();
		}
	}

	public static void sendSMS(string data, string to, ActionPerform successAction, ActionPerform failAction)
	{
		if (Main.isPC)
		{
			Canvas.startOKDlg("Không thể gửi tin nhắn với phiên bản này");
			return;
		}
		if (to.Contains("sms://"))
		{
			to = to.Remove(0, 6);
		}
		Out.LogWarning("SEND SMS: " + data + " ---> " + to);
		Command command = new Command();
		command.action = successAction;
		Command command2 = new Command();
		command2.action = failAction;
		if (SMS.send(data, to) == -1)
		{
			command2?.perform();
		}
		else
		{
			command?.perform();
		}
	}
}
