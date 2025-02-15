using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class ManaFlower : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Nature's Gift");
		// Tooltip.SetDefault("6% reduced mana usage");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 3;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(223);
		recipe.AddIngredient(331, 6);
		recipe.AddIngredient(null, "MagicSoul", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
