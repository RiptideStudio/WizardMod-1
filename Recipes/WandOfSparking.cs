using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class WandOfSparking : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Wand of Sparking");
		// Tooltip.SetDefault("6% reduced mana usage");
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
		Recipe recipe = Recipe.Create(3069);
		recipe.AddRecipeGroup("Wood", 5);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
