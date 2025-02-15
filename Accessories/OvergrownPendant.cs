using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class OvergrownPendant : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Overgrown Pendant");
		// Tooltip.SetDefault("Enemies explode into vilethorns when killed\nMagic attacks have a chance to poison enemies");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 2;
		Item.value = 20000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<Global>().overgrownPendant = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddRecipeGroup("Wood", 50);
		recipe.AddIngredient(null, "LivingShard", 5);
		recipe.AddIngredient(null, "EnchantedSilk", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
