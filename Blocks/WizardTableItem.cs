using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Blocks;

public class WizardTableItem : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Arcanum");
		// Tooltip.SetDefault("Used to forge strong, celestial gear");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.maxStack = 999;
		Item.useTurn = true;
		Item.autoReuse = true;
		Item.useAnimation = 15;
		Item.useTime = 15;
		Item.useStyle = 1;
		Item.consumable = true;
		Item.rare = 5;
		Item.value = 1000;
		Item.createTile = Mod.Find<ModTile>("WizardTable").Type;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(382, 10);
		recipe.AddIngredient(502, 5);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(1191, 10);
		recipe2.AddIngredient(502, 5);
		recipe2.AddIngredient(null, "MagicSoul");
		recipe2.Register();
	}
}
