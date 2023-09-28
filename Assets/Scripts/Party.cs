public class Party
{
	public short idParty = -1;

	private mVector userParty = new mVector();

	public Party()
	{
	}

	public Party(short id)
	{
		idParty = id;
	}

	public void addUser(PartyInfo user)
	{
		if (!userParty.conTains(user))
		{
			userParty.addElement(user);
		}
	}

	public void removeUser(PartyInfo user)
	{
		if (userParty.conTains(user))
		{
			userParty.removeElement(user);
		}
	}

	public int getSize()
	{
		return userParty.size();
	}

	public mVector getChar()
	{
		return userParty;
	}
}
