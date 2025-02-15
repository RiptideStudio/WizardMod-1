using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class LivingShard : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Living Shard");
		// Tooltip.SetDefault("Imbued with mother nature's power");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 2;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddIngredient(27);
		recipe.AddRecipeGroup("Wood", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
