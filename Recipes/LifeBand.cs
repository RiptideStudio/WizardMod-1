using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class LifeBand : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Band of Regeneration");
		// Tooltip.SetDefault("Slowly regenerates life");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 1;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(49);
		recipe.AddIngredient(29);
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
