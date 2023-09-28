public class ChatInfo
{
	public string name;

	public int ID;

	public string content;

	public ChatInfo()
	{
	}

	public ChatInfo(string from, string content, int color)
	{
		name = from;
		this.content = content.ToLower();
	}
}
