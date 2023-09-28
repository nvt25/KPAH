public class ChatTab
{
	public Command center;

	public Command right;

	public int count;

	public string name;

	public mVector text;

	public bool isInput;

	public bool isOpen;

	public ChatTab(string name, Command cen, Command right, bool isInput)
	{
		this.name = name;
		center = cen;
		this.right = right;
		this.isInput = isInput;
		isOpen = true;
		count = Res.rnd(10);
	}
}
