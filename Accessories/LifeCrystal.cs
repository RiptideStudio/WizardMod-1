using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Accessories;

public class LifeCrystal : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Pure Stone");
		// Tooltip.SetDefault("Max life increased by 40\nLife regeneration slightly increased");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 2;
		Item.value = 15000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.statLifeMax2 += 40;
		player.lifeRegen += 3;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(29);
		recipe.AddIngredient(null, "EnchantedShard", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
