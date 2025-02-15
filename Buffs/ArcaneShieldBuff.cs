using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class ArcaneShieldBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Magic Barrier");
		//Description.SetDefault("A magic barrier surrounds you");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
	}
}
