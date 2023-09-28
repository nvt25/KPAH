using System.Collections;
using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
	public static Main main;

	public static Canvas canvas;

	public static MyGraphics g;

	public static GameMidlet midlet;

	public static string res = "res";

	public static string mainThreadName;

	public static bool started;

	public static bool isDisConnect;

	public static bool isStartSaveIp;

	public static bool isPC;

	public static int hdtype;

	public int countUpdate;

	public int countPaint;

	private bool isStart;

	private Image ii;

	private bool isBeginTouchDow0;

	private bool isBeginTouchDow1;

	private bool isBeginTouchRelease0;

	private bool isBeginTouchRelease1;

	private Vector2 lastMousePos = default(Vector2);

	private Vector2 lastMousePos1 = default(Vector2);

	public string s;

	private int yy;

	public static bool isCompactDevice = true;

	private IEnumerator DoStart()
	{
		GUI.depth = 2;
		while (true)
		{
			if (Time.timeScale == 1f)
			{
				yield return new WaitForSeconds(0.1f);
				Session_ME.update();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	private void Start()
	{
		Screen.SetResolution(800, 600, fullscreen: false);
	}

	public void platformRequest(string url)
	{
		Out.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	public void loadDataGame()
	{
		PlayerPrefs.DeleteAll();
		Res.loadRes();
		FilePack.init(FilePack.arrow);
		for (int i = 0; i < 7; i++)
		{
			Res.imgArrow[i] = FilePack.getImg("arrow" + i);
		}
		FilePack.reset();
		FilePack.init(FilePack.eff);
		for (int j = 0; j < Res.imgEffect.Length; j++)
		{
			if (j < 25 || j > 33)
			{
				Res.imgEffect[j] = FilePack.getImg("g" + j);
			}
			if (Res.imgEffect[26] == null)
			{
				Res.imgEffect[25] = FilePack.getImg("g25");
				Res.imgEffect[26] = FilePack.getImg("g26");
				Res.imgEffect[27] = Image.creatImageByImage(Res.imgEffect[25]);
				Res.imgEffect[28] = FilePack.getImg("g27");
				Res.imgEffect[29] = FilePack.getImg("g28");
				Res.imgEffect[30] = FilePack.getImg("g29");
				Res.imgEffect[31] = FilePack.getImg("g30");
				Res.imgEffect[32] = FilePack.getImg("g31");
				Res.imgEffect[33] = FilePack.getImg("g32");
				Res.backSmoke = new FrameImage(Res.imgEffect[32], 12, 13);
			}
		}
		FilePack.reset();
		for (int k = 0; k < 5; k++)
		{
			for (int l = 0; l < 7; l++)
			{
				for (int m = 0; m < 7; m++)
				{
					Res.getImgWeaPone(k, l, m);
				}
			}
		}
		for (int n = 0; n < 5; n++)
		{
			for (int num = 0; num < 3; num++)
			{
				Res.GetWPSplashInfo(n, num);
			}
		}
	}

	private void OnGUI()
	{
		if (yy >= 10)
		{
			checkInput();
			Session_ME.update();
			if (Event.current.type.Equals(EventType.Repaint))
			{
				canvas.paint(g);
				countPaint++;
				g.reset();
			}
		}
	}

	private void checkInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Canvas.isPointerDrange = false;
			Vector3 mousePosition = UnityEngine.Input.mousePosition;
			canvas.pointerPressed((int)ScaleGUI.scaleX(mousePosition.x), (int)ScaleGUI.scaleX((float)Screen.height - mousePosition.y));
			lastMousePos.x = mousePosition.x;
			lastMousePos.y = mousePosition.y;
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition2 = UnityEngine.Input.mousePosition;
			if (mousePosition2.x < lastMousePos.x - 5f || mousePosition2.x > lastMousePos.x + 5f || mousePosition2.y < lastMousePos.y - 5f || mousePosition2.y > lastMousePos.y + 5f)
			{
				Canvas.isPointerDrange = true;
			}
			if (Canvas.isPointerDrange)
			{
				canvas.pointerDragged((int)ScaleGUI.scaleX(mousePosition2.x), (int)ScaleGUI.scaleX((float)Screen.height - mousePosition2.y));
				lastMousePos.x = mousePosition2.x;
				lastMousePos.y = mousePosition2.y;
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			Vector3 mousePosition3 = UnityEngine.Input.mousePosition;
			canvas.pointerReleased((int)ScaleGUI.scaleX(mousePosition3.x), (int)ScaleGUI.scaleX((float)Screen.height - mousePosition3.y));
			lastMousePos.x = mousePosition3.x;
			lastMousePos.y = mousePosition3.y;
		}
		if (Event.current.type == EventType.KeyDown)
		{
			int num = MyKeyMap.map(Event.current.keyCode);
			if (num != 0)
			{
				canvas.onKeyPressed(num);
			}
		}
		if (Event.current.type == EventType.KeyUp)
		{
			int num2 = MyKeyMap.map(Event.current.keyCode);
			if (num2 != 0)
			{
				canvas.onKeyReleased(num2);
			}
		}
	}

	public void OnApplicationQuit()
	{
	}

	private void FixedUpdate()
	{
		yy++;
		if (yy < 10)
		{
			return;
		}
		if (!started)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			Application.runInBackground = true;
			Application.targetFrameRate = 30;
			base.useGUILayout = false;
			isCompactDevice = detectCompactDevice();
			if (main == null)
			{
				main = this;
			}
			started = true;
			ScaleGUI.initScaleGUI();
			if (Thread.CurrentThread.Name != "Main")
			{
				Thread.CurrentThread.Name = "Main";
			}
			mainThreadName = Thread.CurrentThread.Name;
			isPC = true;
			if (isPC)
			{
				Screen.fullScreen = false;
			}
			loadDataGame();
			g = new MyGraphics();
			g.CreateLineMaterial();
			midlet = new GameMidlet();
			canvas = new Canvas();
			canvas.start();
			midlet.load();
			Res.load = new LoadData();
			Res.load.isInitGame = true;
			if (!isPC && Canvas.loginScr.isRememPass)
			{
				ServerListScr.loadIPAuTo();
				ServerListScr.doLoginAuTo();
				Canvas.loginScr.doLoginAuTo();
			}
		}
		countUpdate++;
		if (Res.load != null)
		{
			Res.load.run();
		}
		canvas.update();
		RMS.update();
		DataInputStream.update();
		SMS.update();
		Image.update();
		Canvas.isPointerClick = false;
		ipKeyboard.update();
		Net.update();
	}

	private void Update()
	{
	}

	public static void exit()
	{
		main.OnApplicationQuit();
	}

	public static bool detectCompactDevice()
	{
		if (iPhoneSettings.generation == iPhoneGeneration.iPhone || iPhoneSettings.generation == iPhoneGeneration.iPhone3G || iPhoneSettings.generation == iPhoneGeneration.iPodTouch1Gen || iPhoneSettings.generation == iPhoneGeneration.iPodTouch2Gen)
		{
			return false;
		}
		return true;
	}

	public static bool checkCanSendSMS()
	{
		if (iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen)
		{
			return true;
		}
		return false;
	}
}
