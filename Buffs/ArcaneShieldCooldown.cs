using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class ArcaneShieldCooldown : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Magic Barrier Cooldown");
		//Description.SetDefault("The Magic Barrier is on cooldown");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
		Main.debuff[Type] = true;
	}
}
