using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class LunarBar : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Crystal Slab");
		// Tooltip.SetDefault("Contains ancient power\nUsed to forge deadly weapons");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 20000;
		Item.rare = 6;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(2);
		recipe.AddIngredient(117, 2);
		recipe.AddIngredient(502);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
