using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class MetalBand : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Metal Band");
		// Tooltip.SetDefault("Used to craft magic rings\nBeyonce loves it!");
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
		Recipe recipe = CreateRecipe();
		recipe.AddRecipeGroup("IronBar", 5);
		recipe.AddTile(16);
		recipe.Register();
	}
}
