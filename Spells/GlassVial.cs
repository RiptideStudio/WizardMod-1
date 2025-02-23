using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Spells;

public class GlassVial : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Glass Vial");
		// Tooltip.SetDefault("Can be filled with liquid");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 1;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(170);
		recipe.AddRecipeGroup("Wood");
		recipe.AddTile(17);
		recipe.Register();
	}
}
