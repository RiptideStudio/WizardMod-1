using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class DeepslateBar : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Deepslate Bar");
		// Tooltip.SetDefault("'Reborn from the ashes'");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 5000;
		Item.rare = 3;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(5);
		recipe.AddIngredient(175, 5);
		recipe.AddIngredient(null, "MoltenShard");
		recipe.AddIngredient(154);
		recipe.AddTile(77);
		recipe.Register();
	}
}
