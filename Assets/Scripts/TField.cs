using System;
using System.Threading;

public class TField : ObjGame
{
	public const sbyte KEY_LEFT = 14;

	public const sbyte KEY_RIGHT = 15;

	public const sbyte KEY_CLEAR = 19;

	public bool isFocus;

	public new int x;

	public new int y;

	public new int width;

	public new int height;

	public bool lockArrow;

	public bool justReturnFromTextBox;

	public bool paintFocus = true;

	public static int typeXpeed = 2;

	private static readonly int[] MAX_TIME_TO_CONFIRM_KEY = new int[7]
	{
		30,
		14,
		11,
		9,
		6,
		4,
		2
	};

	private static int CARET_HEIGHT = 0;

	private static readonly int CARET_WIDTH = 1;

	private static readonly int CARET_SHOWING_TIME = 5;

	private static readonly int TEXT_GAP_X = 4;

	private static readonly int MAX_SHOW_CARET_COUNER = 10;

	public static readonly int INPUT_TYPE_ANY = 0;

	public static readonly int INPUT_TYPE_NUMERIC = 1;

	public static readonly int INPUT_TYPE_PASSWORD = 2;

	public static readonly int INPUT_ALPHA_NUMBER_ONLY = 3;

	private static string[] print = new string[12]
	{
		" 0",
		".,@?!_1\"/$-():*+<=>;%&~#%^&*{}[];'/1",
		"abc2áàảãạâấầẩẫậăắằẳẵặ2",
		"def3đéèẻẽẹêếềểễệ3",
		"ghi4íìỉĩị4",
		"jkl5",
		"mno6óòỏõọôốồổỗộơớờởỡợ6",
		"pqrs7",
		"tuv8úùủũụưứừửữự8",
		"wxyz9ýỳỷỹỵ9",
		"*",
		"#"
	};

	private static string[] printA = new string[12]
	{
		"0",
		"1",
		"abc2",
		"def3",
		"ghi4",
		"jkl5",
		"mno6",
		"pqrs7",
		"tuv8",
		"wxyz9",
		"0",
		"0"
	};

	private static string[] printBB = new string[17]
	{
		" 0",
		"er1",
		"ty2",
		"ui3",
		"df4",
		"gh5",
		"jk6",
		"cv7",
		"bn8",
		"m9",
		"0",
		"0",
		"qw!",
		"as?",
		"zx",
		"op.",
		"l,"
	};

	private string text = string.Empty;

	private string passwordText = string.Empty;

	private string paintedText = string.Empty;

	private int caretPos;

	private int counter;

	private int maxTextLenght = 500;

	private int offsetX;

	private static int lastKey = -1984;

	private int keyInActiveState;

	private int indexOfActiveChar;

	private int showCaretCounter = MAX_SHOW_CARET_COUNER;

	private int inputType = INPUT_TYPE_ANY;

	public static bool isQwerty = true;

	public static int typingModeAreaWidth;

	public static int mode = 0;

	public static long timeChangeMode;

	public static readonly string[] modeNotify = new string[4]
	{
		"abc",
		"Abc",
		"ABC",
		"123"
	};

	public static readonly int NOKIA = 0;

	public static readonly int MOTO = 1;

	public static readonly int ORTHER = 2;

	public static readonly int BB = 3;

	public static int changeModeKey = 11;

	public static readonly sbyte abc = 0;

	public static readonly sbyte Abc = 1;

	public static readonly sbyte ABC = 2;

	public static readonly sbyte number123 = 3;

	public static TField currentTField;

	public new bool isTfield;

	public string name = string.Empty;

	public Command cmdClear;

	public Command cmdDoneAction;

	private MyScreen parentScr;

	private int holdCount;

	public static int changeDau;

	private int indexDau = -1;

	private int indexTemplate;

	private int indexCong;

	private long timeDau;

	private static string printDau = "aáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ";

	public bool showSubTextField = true;

	public static TouchScreenKeyboard kb;

	public static int[][] BBKEY = new int[17][]
	{
		new int[2]
		{
			32,
			48
		},
		new int[2]
		{
			49,
			69
		},
		new int[2]
		{
			50,
			84
		},
		new int[2]
		{
			51,
			85
		},
		new int[2]
		{
			52,
			68
		},
		new int[2]
		{
			53,
			71
		},
		new int[2]
		{
			54,
			74
		},
		new int[2]
		{
			55,
			67
		},
		new int[2]
		{
			56,
			66
		},
		new int[2]
		{
			57,
			77
		},
		new int[2]
		{
			42,
			128
		},
		new int[2]
		{
			35,
			137
		},
		new int[2]
		{
			33,
			113
		},
		new int[2]
		{
			63,
			97
		},
		new int[3]
		{
			64,
			121,
			122
		},
		new int[2]
		{
			46,
			111
		},
		new int[2]
		{
			44,
			108
		}
	};

	public TField(MyScreen parentScr)
	{
		text = string.Empty;
		this.parentScr = parentScr;
		init();
	}

	public TField()
	{
		text = string.Empty;
		init();
	}

	public TField(int x, int y, int w, int h)
	{
		text = string.Empty;
		init();
		this.x = x;
		this.y = y;
		width = w;
		height = h;
	}

	public TField(string text, int maxLen, int inputType)
	{
		this.text = text;
		maxTextLenght = maxLen;
		this.inputType = inputType;
		init();
		isTfield = true;
	}

	public static bool setNormal(char ch)
	{
		if ((ch < '0' || ch > '9') && (ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z'))
		{
			return false;
		}
		return true;
	}

	public static void setVendorTypeMode(int mode)
	{
		if (mode == MOTO)
		{
			print[0] = "0";
			print[10] = " *";
			print[11] = "#";
			changeModeKey = 35;
		}
		else if (mode == NOKIA)
		{
			print[0] = " 0";
			print[10] = "*";
			print[11] = "#";
			changeModeKey = 35;
		}
		else if (mode == ORTHER)
		{
			print[0] = "0";
			print[10] = "*";
			print[11] = " #";
			changeModeKey = 42;
		}
	}

	public void init()
	{
		CARET_HEIGHT = MyScreen.ITEM_HEIGHT + 1;
		if (Main.isPC)
		{
			typeXpeed = 0;
		}
	}

	public void clear()
	{
		if (caretPos > 0 && text.Length > 0)
		{
			text = text.Substring(0, caretPos - 1);
			caretPos--;
			setOffset(0);
			setPasswordTest();
			if (kb != null)
			{
				kb.text = text;
			}
		}
	}

	public void clearAll()
	{
		if (caretPos > 0 && text.Length > 0)
		{
			text = text.Substring(0, text.Length - 1);
			caretPos--;
			setOffset();
			setPasswordTest();
			setFocusWithKb(isFocus: true);
			if (kb != null)
			{
				kb.text = string.Empty;
			}
		}
	}

	public void setOffset()
	{
		if (paintedText != null && MFont.normalFont[0] != null)
		{
			if (inputType == INPUT_TYPE_PASSWORD)
			{
				paintedText = passwordText;
			}
			else
			{
				paintedText = text;
			}
			if (offsetX < 0 && MFont.normalFont[0].getWidth(paintedText) + offsetX < width - TEXT_GAP_X - 13 - typingModeAreaWidth)
			{
				offsetX = width - 10 - typingModeAreaWidth - MFont.normalFont[0].getWidth(paintedText);
			}
			if (offsetX + MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos)) <= 0)
			{
				offsetX = -MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos));
				offsetX += 40;
			}
			else if (offsetX + MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos)) >= width - 12 - typingModeAreaWidth)
			{
				offsetX = width - 10 - typingModeAreaWidth - MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos)) - 2 * TEXT_GAP_X;
			}
			if (offsetX > 0)
			{
				offsetX = 0;
			}
		}
	}

	private void keyPressedAny(int keyCode)
	{
		string[] array = (inputType != INPUT_TYPE_PASSWORD && inputType != INPUT_ALPHA_NUMBER_ONLY) ? print : printA;
		if (keyCode == lastKey)
		{
			indexOfActiveChar = (indexOfActiveChar + 1) % array[keyCode - 48].Length;
			char c = array[keyCode - 48][indexOfActiveChar];
			string str = string.Concat(arg1: (mode == 0) ? char.ToLower(c) : ((mode == 1) ? char.ToUpper(c) : ((mode != 2) ? array[keyCode - 48][array[keyCode - 48].Length - 1] : char.ToUpper(c))), arg0: text.Substring(0, caretPos - 1));
			if (caretPos < text.Length)
			{
				str += text.Substring(caretPos, text.Length);
			}
			text = str;
			keyInActiveState = MAX_TIME_TO_CONFIRM_KEY[typeXpeed];
			setPasswordTest();
		}
		else if (text.Length < maxTextLenght)
		{
			if (mode == 1 && lastKey != -1984)
			{
				mode = 0;
			}
			indexOfActiveChar = 0;
			char c2 = array[keyCode - 48][indexOfActiveChar];
			string str2 = string.Concat(arg1: (mode == 0) ? char.ToLower(c2) : ((mode == 1) ? char.ToUpper(c2) : ((mode != 2) ? array[keyCode - 48][array[keyCode - 48].Length - 1] : char.ToUpper(c2))), arg0: text.Substring(0, caretPos));
			if (caretPos < text.Length)
			{
				str2 += text.Substring(caretPos, text.Length);
			}
			text = str2;
			keyInActiveState = MAX_TIME_TO_CONFIRM_KEY[typeXpeed];
			caretPos++;
			setPasswordTest();
			setOffset();
		}
		lastKey = keyCode;
	}

	private void keyPressedAscii(int keyCode)
	{
		if ((inputType == INPUT_TYPE_PASSWORD || inputType == INPUT_ALPHA_NUMBER_ONLY) && (keyCode < 48 || keyCode > 57) && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 122))
		{
			return;
		}
		if (text.Length < maxTextLenght)
		{
			string str = text.Substring(0, caretPos) + (char)keyCode;
			if (caretPos < text.Length)
			{
				str += text.Substring(caretPos, text.Length - caretPos);
			}
			text = str;
			caretPos++;
			setPasswordTest();
			setOffset(0);
		}
		if (kb != null)
		{
			kb.text = text;
		}
	}

	public void keyHold(int keyCode)
	{
		holdCount++;
		if (holdCount > 15 && !isQwerty && keyCode < print.Length)
		{
			clear();
			keyPressedAscii(print[keyCode][print[keyCode].Length - 1]);
			keyInActiveState = MAX_TIME_TO_CONFIRM_KEY[typeXpeed];
			holdCount = 0;
		}
	}

	public static void setMode()
	{
		mode++;
		if (mode > 3)
		{
			mode = 0;
		}
		lastKey = changeModeKey;
		timeChangeMode = Environment.TickCount / 1000;
	}

	private void setDau()
	{
		timeDau = Environment.TickCount / 100;
		if (indexDau == -1)
		{
			for (int num = caretPos; num > 0; num--)
			{
				char c = text[num - 1];
				for (int i = 0; i < printDau.Length; i++)
				{
					char c2 = printDau[i];
					if (c == c2)
					{
						indexTemplate = i;
						indexCong = 0;
						indexDau = num - 1;
						return;
					}
				}
			}
			indexDau = -1;
		}
		else
		{
			indexCong++;
			if (indexCong >= 6)
			{
				indexCong = 0;
			}
			string str = text.Substring(0, indexDau);
			string str2 = text.Substring(indexDau + 1);
			string str3 = printDau.Substring(indexTemplate + indexCong, 1);
			text = str + str3 + str2;
		}
	}

	public new bool keyPressed(int keyCode)
	{
		if (keyCode == 8 || keyCode == -8 || keyCode == 204)
		{
			clear();
			return true;
		}
		if (isQwerty && keyCode >= 32)
		{
			keyPressedAscii(keyCode);
			return false;
		}
		if (keyCode == changeDau && inputType == INPUT_TYPE_ANY)
		{
			setDau();
			return false;
		}
		if (keyCode == 42)
		{
			keyCode = 58;
		}
		if (keyCode == 35)
		{
			keyCode = 59;
		}
		if (keyCode >= 48 && keyCode <= 59)
		{
			if (inputType == INPUT_TYPE_ANY || inputType == INPUT_TYPE_PASSWORD || inputType == INPUT_ALPHA_NUMBER_ONLY)
			{
				keyPressedAny(keyCode);
			}
			else if (inputType == INPUT_TYPE_NUMERIC)
			{
				keyPressedAscii(keyCode);
				keyInActiveState = 1;
			}
		}
		else
		{
			indexOfActiveChar = 0;
			lastKey = -1984;
			if (keyCode == 14 && !lockArrow)
			{
				if (caretPos > 0)
				{
					caretPos--;
					setOffset(0);
					showCaretCounter = MAX_SHOW_CARET_COUNER;
					return false;
				}
			}
			else if (keyCode == 15 && !lockArrow)
			{
				if (caretPos < text.Length)
				{
					caretPos++;
					setOffset(0);
					showCaretCounter = MAX_SHOW_CARET_COUNER;
					return false;
				}
			}
			else
			{
				if (keyCode == 19)
				{
					clear();
					return false;
				}
				lastKey = keyCode;
			}
		}
		return true;
	}

	public void setOffset(int index)
	{
		if (paintedText != null && MFont.normalFont[0] != null)
		{
			if (inputType == INPUT_TYPE_PASSWORD)
			{
				paintedText = passwordText;
			}
			else
			{
				paintedText = text;
			}
			if (offsetX < 0 && MFont.normalFont[0].getWidth(paintedText) + offsetX < width - TEXT_GAP_X - 13 - typingModeAreaWidth)
			{
				offsetX = width - 10 - typingModeAreaWidth - MFont.normalFont[0].getWidth(paintedText);
			}
			if (offsetX + MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos)) <= 0)
			{
				offsetX = -MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos));
				offsetX += 40;
			}
			else if (offsetX + MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos)) >= width - 12 - typingModeAreaWidth)
			{
				offsetX = width - 10 - typingModeAreaWidth - MFont.normalFont[0].getWidth(paintedText.Substring(0, caretPos)) - 2 * TEXT_GAP_X;
			}
			if (offsetX > 0)
			{
				offsetX = 0;
			}
		}
	}

	public new void paint(MyGraphics g)
	{
		bool flag = isFocused();
		int num = 1;
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			paintedText = passwordText;
		}
		else
		{
			paintedText = text;
			num = -1;
		}
		if (flag)
		{
			if (paintFocus)
			{
				g.setColor(7950336);
			}
		}
		else
		{
			g.setColor(5979911);
		}
		g.fillRect(x + 1, y + 1, width - 2, height - 2);
		if (flag)
		{
			if (paintFocus)
			{
				g.setColor(16767892);
				g.fillRect(x + 1, y + 1, width - 1, height - 1);
			}
		}
		else
		{
			g.setColor(11768142);
			g.fillRect(x + 1, y + 1, width - 1, height - 1);
		}
		g.setClip(x + 3, y + 1, width - typingModeAreaWidth - 8, height - 3);
		g.setColor(0);
		MFont.arialFont.drawString(g, paintedText, TEXT_GAP_X + offsetX + x, num + y + (height - MFont.arialFont.getHeight()) / 2 + 3, 0);
		if (isFocused() && keyInActiveState == 0 && (showCaretCounter > 0 || counter / CARET_SHOWING_TIME % 2 == 0))
		{
			g.setColor(0);
			g.fillRect(TEXT_GAP_X + 1 + offsetX + x + MFont.arialFont.getWidth(paintedText.Substring(0, caretPos) + "a") - CARET_WIDTH - MFont.arialFont.getWidth("a"), y + (height - CARET_HEIGHT) / 2 + 2, CARET_WIDTH, CARET_HEIGHT + 2);
		}
	}

	public void paintByList(MyGraphics g)
	{
		bool flag = isFocused();
		int num = 1;
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			paintedText = passwordText;
		}
		else
		{
			paintedText = text;
			num = -1;
		}
		if (flag)
		{
			if (paintFocus)
			{
				g.setColor(7950336);
			}
		}
		else
		{
			g.setColor(5979911);
		}
		g.fillRect(x + 1, y + 1, width - 2, height - 2);
		if (flag)
		{
			if (paintFocus)
			{
				g.setColor(16767892);
				g.fillRect(x + 1, y + 1, width - 1, height - 1);
			}
		}
		else
		{
			g.setColor(11768142);
			g.fillRect(x + 1, y + 1, width - 1, height - 1);
		}
		g.setColor(0);
		MFont.arialFont.drawString(g, paintedText, TEXT_GAP_X + offsetX + x, num + y + (height - MFont.arialFont.getHeight()) / 2 + 3, 0);
		if (isFocused() && keyInActiveState == 0 && (showCaretCounter > 0 || counter / CARET_SHOWING_TIME % 2 == 0))
		{
			g.setColor(0);
			g.fillRect(TEXT_GAP_X + 1 + offsetX + x + MFont.arialFont.getWidth(paintedText.Substring(0, caretPos) + "a") - CARET_WIDTH - MFont.arialFont.getWidth("a"), y + (height - CARET_HEIGHT) / 2 + 2, CARET_WIDTH, CARET_HEIGHT - 3);
		}
	}

	private bool isFocused()
	{
		return isFocus;
	}

	public string subString(string str, int index, int indexTo)
	{
		if (index >= 0 && indexTo > str.Length - 1)
		{
			return str.Substring(index);
		}
		if (index < 0 || index > str.Length - 1 || indexTo < 0 || indexTo > str.Length - 1)
		{
			return string.Empty;
		}
		string text = string.Empty;
		for (int i = index; i < indexTo; i++)
		{
			text += str[i];
		}
		return text;
	}

	private void setPasswordTest()
	{
		if (inputType == INPUT_TYPE_PASSWORD)
		{
			passwordText = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				passwordText += "*";
			}
			if (keyInActiveState > 0 && caretPos > 0)
			{
				passwordText = passwordText.Substring(0, caretPos - 1) + text[caretPos - 1] + passwordText.Substring(caretPos, passwordText.Length);
			}
		}
	}

	public new void update()
	{
		if (kb != null && currentTField == this)
		{
			if (kb.text.Length < 40)
			{
				setText(kb.text);
			}
			if (!kb.done)
			{
			}
		}
		counter++;
		if (keyInActiveState > 0)
		{
			keyInActiveState--;
			if (keyInActiveState == 0)
			{
				indexOfActiveChar = 0;
				if (mode == 1 && lastKey != changeModeKey && isFocus)
				{
					mode = 0;
				}
				lastKey = -1984;
				setPasswordTest();
			}
		}
		if (showCaretCounter > 0)
		{
			showCaretCounter--;
		}
		if (Canvas.isPointerJustRelease)
		{
			setTextBox();
		}
		if (indexDau != -1 && Environment.TickCount / 100 - timeDau > 5)
		{
			indexDau = -1;
		}
	}

	public void updatelist()
	{
		if (kb != null && currentTField == this)
		{
			if (kb.text.Length < 40)
			{
				setText(kb.text);
			}
			if (!kb.done)
			{
			}
		}
		counter++;
		if (keyInActiveState > 0)
		{
			keyInActiveState--;
			if (keyInActiveState == 0)
			{
				indexOfActiveChar = 0;
				if (mode == 1 && lastKey != changeModeKey && isFocus)
				{
					mode = 0;
				}
				lastKey = -1984;
				setPasswordTest();
			}
		}
		if (showCaretCounter > 0)
		{
			showCaretCounter--;
		}
		if (Canvas.isPointerJustRelease)
		{
			setTextBoxlist();
		}
		if (indexDau != -1 && Environment.TickCount / 100 - timeDau > 5)
		{
			indexDau = -1;
		}
	}

	public void setTextBoxlist()
	{
		if (Canvas.isPointer(x, y - InputDlg.scr.cmy, width, height))
		{
			setFocusWithKb(isFocus: true);
		}
		else
		{
			setFocus(isFocus: false);
		}
	}

	public void setTextBox()
	{
		if (Canvas.isPointer(x, y, width, height))
		{
			setFocusWithKb(isFocus: true);
		}
		else
		{
			setFocus(isFocus: false);
		}
	}

	public void setFocus(bool isFocus)
	{
		if (this.isFocus != isFocus)
		{
			mode = 0;
		}
		lastKey = -1984;
		timeChangeMode = (int)(DateTime.Now.Ticks / 1000);
		this.isFocus = isFocus;
		if (isFocus)
		{
			currentTField = this;
			if (kb != null)
			{
				kb.text = currentTField.text;
			}
		}
	}

	public void setFocusWithKb(bool isFocus)
	{
		if (this.isFocus != isFocus)
		{
			mode = 0;
		}
		lastKey = -1984;
		timeChangeMode = (int)(DateTime.Now.Ticks / 1000);
		this.isFocus = isFocus;
		if (isFocus)
		{
			currentTField = this;
		}
		else if (currentTField == this)
		{
			currentTField = null;
		}
		if (Thread.CurrentThread.Name == Main.mainThreadName && currentTField != null)
		{
			isFocus = true;
			TouchScreenKeyboard.hideInput = !currentTField.showSubTextField;
			TouchScreenKeyboardType t = TouchScreenKeyboardType.ASCIICapable;
			if (inputType == INPUT_TYPE_NUMERIC)
			{
				t = TouchScreenKeyboardType.NumberPad;
			}
			bool type = false;
			if (inputType == INPUT_TYPE_PASSWORD)
			{
				type = true;
			}
			kb = TouchScreenKeyboard.Open(currentTField.text, t, b1: false, b2: false, type, b3: false, currentTField.name);
			if (kb != null)
			{
				kb.text = currentTField.text;
			}
		}
	}

	public string getText()
	{
		return text;
	}

	public void setText(string text)
	{
		if (text != null)
		{
			lastKey = -1984;
			keyInActiveState = 0;
			indexOfActiveChar = 0;
			this.text = text;
			paintedText = text;
			setPasswordTest();
			caretPos = text.Length;
			setOffset();
		}
	}

	public void insertText(string text)
	{
		this.text = this.text.Substring(0, caretPos) + text + this.text.Substring(caretPos);
		setPasswordTest();
		caretPos += text.Length;
		setOffset();
	}

	public int getMaxTextLenght()
	{
		return maxTextLenght;
	}

	public void setMaxTextLenght(int maxTextLenght)
	{
		this.maxTextLenght = maxTextLenght;
	}

	public int getIputType()
	{
		return inputType;
	}

	public void setIputType(int iputType)
	{
		inputType = iputType;
	}

	public int getBBKeyCode(int keyCode)
	{
		for (int i = 0; i < BBKEY.Length; i++)
		{
			for (int j = 0; j < BBKEY[i].Length; j++)
			{
				if (BBKEY[i][j] == keyCode)
				{
					return i + 48;
				}
			}
		}
		return -1;
	}

	public static int getHeight()
	{
		return 30;
	}
}
