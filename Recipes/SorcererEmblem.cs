using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class SorcererEmblem : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sorcerer Emblem");
		// Tooltip.SetDefault("15% increased magic damage");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 4;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(489);
		recipe.AddIngredient(491);
		recipe.AddIngredient(null, "MagicSoul", 20);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = Recipe.Create(489);
		recipe2.AddIngredient(490);
		recipe2.AddIngredient(null, "MagicSoul", 20);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
		Recipe recipe3 = Recipe.Create(489);
		recipe3.AddIngredient(2998);
		recipe3.AddIngredient(null, "MagicSoul", 20);
		recipe3.AddTile(null, "ArcaneTable");
		recipe3.Register();
	}
}
