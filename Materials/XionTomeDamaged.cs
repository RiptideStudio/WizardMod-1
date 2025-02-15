using Terraria.ModLoader;

namespace WizardMod.Materials;

public class XionTomeDamaged : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Damaged Xion's Tome");
		// Tooltip.SetDefault("You feel ancient power resonate from within\nCan be repaired");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.maxStack = 999;
		Item.value = 1000;
		Item.rare = -1;
		Item.noMelee = true;
	}
}
