using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class CrimtaneBar : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Crimtane Bar");
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
		Recipe recipe = Recipe.Create(1257);
		recipe.AddIngredient(57);
		recipe.AddTile(16);
		recipe.Register();
	}
}
