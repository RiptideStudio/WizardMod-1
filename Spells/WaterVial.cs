using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Spells;

public class WaterVial : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Water Vial");
		// Tooltip.SetDefault("Used to brew magic spells");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 2;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "GlassVial");
		recipe.HasCondition(Condition.NearWater);
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "GlassVial");
		recipe.AddTile(96);
		recipe2.Register();
	}
}
