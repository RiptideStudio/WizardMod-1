using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class ArcaneDebuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Arcane Cooldown");
		//Description.SetDefault("The Arcane Power buff is on cooldown");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
		Main.debuff[Type] = true;
	}
}
