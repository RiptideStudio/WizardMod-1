using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class SpellDebuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Spell Shock");
		//Description.SetDefault("You can't throw spells!");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
		Main.debuff[Type] = true;
	}
}
