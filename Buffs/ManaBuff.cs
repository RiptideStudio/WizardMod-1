using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class ManaBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("");
		//Description.SetDefault("");
		Main.buffNoSave[Type] = false;
		Main.buffNoTimeDisplay[Type] = true;
		Main.debuff[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.buffTime[buffIndex] = 18000;
		player.statManaMax2 += 25;
	}
}
