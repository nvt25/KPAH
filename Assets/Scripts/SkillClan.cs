public class SkillClan
{
	public short time;

	public long timeCur;

	public string info;

	public sbyte idIcon;

	public sbyte lv;

	public SkillClan()
	{
		timeCur = mSystem.getCurrentTimeMillis() / 1000;
	}

	public void updateTime()
	{
		if (mSystem.getCurrentTimeMillis() / 1000 - timeCur >= time)
		{
			time = 0;
		}
	}
}
