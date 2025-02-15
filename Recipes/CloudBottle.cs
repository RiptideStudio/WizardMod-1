using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class CloudBottle : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Cloud in a Bottle");
		// Tooltip.SetDefault("Allows the holder to double jump");
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
		Recipe recipe = Recipe.Create(53);
		recipe.AddIngredient(751, 50);
		recipe.AddIngredient(21, 5);
		recipe.AddIngredient(null, "SkyCrystal", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = Recipe.Create(53);
		recipe2.AddIngredient(751, 50);
		recipe2.AddIngredient(705, 5);
		recipe2.AddIngredient(null, "SkyCrystal", 3);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
