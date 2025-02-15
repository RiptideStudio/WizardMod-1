using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class VampireRing : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Vampire's Circlet");
		// Tooltip.SetDefault("Magic attacks may cause enemies to bleed\nAfter 300 damage is dealt, small homing crimson particles are released\nHoming particles steal life");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.rare = 3;
		Item.value = 5000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<Global>().vampireRing = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddIngredient(1257, 8);
		recipe.AddIngredient(1330, 5);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
