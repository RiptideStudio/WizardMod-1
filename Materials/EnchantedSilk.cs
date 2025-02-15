using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class EnchantedSilk : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Silk");
		// Tooltip.SetDefault("It's blue now!\nUsed to create magic gear");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 500;
		Item.rare = 1;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(2);
		recipe.AddIngredient(225, 2);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddTile(86);
		recipe.Register();
	}
}
