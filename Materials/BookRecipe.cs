using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class BookRecipe : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Book");
		// Tooltip.SetDefault("Can be placed\n'It contains strange symbols'");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 0;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(149);
		recipe.AddIngredient(68);
		recipe.AddIngredient(null, "Paper", 5);
		recipe.AddTile(106);
		recipe.Register();
		Recipe recipe2 = Recipe.Create(149);
		recipe2.AddIngredient(1330);
		recipe2.AddIngredient(null, "Paper", 5);
		recipe2.AddTile(106);
		recipe2.Register();
	}
}
