using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class StarBand : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Band of Starpower");
		// Tooltip.SetDefault("Increases maximum mana by 20");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 2;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(111);
		recipe.AddIngredient(109);
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
