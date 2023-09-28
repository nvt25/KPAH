public class PauseMenu : MyScreen
{
	public static PauseMenu me;

	private string[][] name = new string[9][]
	{
		new string[1]
		{
			"Cửa hàng"
		},
		new string[7]
		{
			"Cài đặt",
			"Cấu hình",
			"Bản đồ lớn",
			"Bật/tắt giao diện",
			"Hướng dẫn",
			"âm thanh",
			"Bật/tắt lời mời"
		},
		new string[7]
		{
			"Bản thân",
			"Hành trang",
			"Kỹ năng",
			"Tiềm năng",
			"Trang bị",
			"Thông tin",
			"Trang bị thú"
		},
		new string[1]
		{
			"Nap Xu"
		},
		new string[1]
		{
			"Nhiệm vụ"
		},
		new string[1]
		{
			"Đồ sát"
		},
		new string[7]
		{
			"Khác",
			"Tin nhắn",
			"Nhóm",
			"Bạn bè",
			"Top cao thủ",
			"Top đại gia",
			"Kênh thế giới"
		},
		new string[1]
		{
			string.Empty
		},
		new string[1]
		{
			"Thoát"
		}
	};

	public static PauseMenu gI()
	{
		return (me != null) ? me : (me = new PauseMenu());
	}

	public override void init()
	{
	}

	public void showMe(int index)
	{
		WindowInfoScr.gI().switchToMe();
		WindowInfoScr.gI().setInfo(index, WindowInfoScr.gI().isSell, WindowInfoScr.gI().isSell ? WindowInfoScr.gI().arrSell : new sbyte[8]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			31
		});
		WindowInfoScr.charWearing = Canvas.gameScr.mainChar;
		WindowInfoScr.gI().setImageCharWear();
	}

	public void showShopNew(int index)
	{
		ShopNew.gI().switchToMe();
		ShopNew.gI().setInfo(index, ShopNew.gI().isSell, ShopNew.gI().isSell ? ShopNew.gI().arrSell : new sbyte[8]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			31
		});
		ShopNew.charWearing = Canvas.gameScr.mainChar;
		ShopNew.gI().setImageCharWear();
	}

	public void initName()
	{
		if (Canvas.gameScr.mainChar.idClan == -1)
		{
			name[7] = new string[3]
			{
				"Bang hội",
				"Top bang hội",
				"Đăng ký bang hội"
			};
		}
		else if (Canvas.gameScr.mainChar.isMaster == 0)
		{
			name[7] = new string[10]
			{
				"Bang hội",
				"Top bang hội",
				"Nhiệm vụ",
				"Thành viên bang hội",
				"Thông tin bang hội",
				"Tin nhắn bang hội",
				"Kỹ năng",
				"Chat toàn bang",
				"Quyên góp",
				"Giải tán bang hội"
			};
			if (Char.dissolved)
			{
				name[7][9] = "Phục hồi bang hội";
			}
		}
		else
		{
			name[7] = new string[10]
			{
				"Bang hội",
				"Top bang hội",
				"Nhiệm vụ",
				"Thành viên bang hội",
				"Thông tin bang hội",
				"Tin nhắn bang hội",
				"Kỹ năng",
				"Chat toàn bang",
				"Quyên góp",
				"Rời bang"
			};
		}
	}
}
