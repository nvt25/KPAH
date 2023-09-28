public class Skill_Boss_Xmas : SkillAnimate
{
	private bool isSkill5;

	private mVector mst = new mVector();

	public Skill_Boss_Xmas(bool isSkill5)
		: base(-1)
	{
		this.isSkill5 = isSkill5;
	}

	public override void setMonster(mVector mst)
	{
		this.mst = mst;
	}

	public override void updateSkill(Char c)
	{
	}

	public override void updateSkill(Monster c)
	{
		if (c == null)
		{
			return;
		}
		if (c.p1 == 3 && !isSkill5)
		{
			for (int i = 0; i < mst.size(); i++)
			{
				LiveActor liveActor = (LiveActor)mst.elementAt(i);
				Canvas.gameScr.startNewMagicBeam(7, c, liveActor, c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], liveActor.damAttack, 0);
			}
		}
		c.p1++;
	}
}
