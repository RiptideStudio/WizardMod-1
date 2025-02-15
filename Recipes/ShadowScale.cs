using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class ShadowScale : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Shadow Scale");
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
		Recipe recipe = Recipe.Create(86);
		recipe.AddIngredient(1329);
		recipe.AddTile(16);
		recipe.Register();
	}
}
