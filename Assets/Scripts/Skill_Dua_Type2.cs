public class Skill_Dua_Type2 : SkillAnimate
{
	private int pmonster;

	public Skill_Dua_Type2()
		: base(-1)
	{
	}

	public override void updateSkill(Monster c)
	{
		Canvas.gameScr.startNewMagicBeam(3, c, c.attackTarget, c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c.targethplost, (sbyte)c.eff);
	}

	public override void updateSkill(Char c)
	{
		if (c == null)
		{
			return;
		}
		base.updateSkill(c);
		if (c.state != 0)
		{
			updateSkillDua(c);
			if (c.p1 == 3)
			{
				Canvas.gameScr.startNewMagicBeam(3, c, c.attackTarget, c.x + SkillAnimate.splashDuaX[c.dir], c.y + SkillAnimate.splashDuaY[c.dir], c.attkPower, c.attkEffect);
			}
			c.p1++;
		}
	}
}
