using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Blocks;

public class ArcaneTableItem : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Arcane Table");
		// Tooltip.SetDefault("'You're a wizard!'\nUsed to make magical items");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.maxStack = 999;
		Item.useTurn = true;
		Item.autoReuse = true;
		Item.useAnimation = 15;
		Item.useTime = 10;
		Item.useStyle = 1;
		Item.consumable = true;
		Item.rare = 3;
		Item.value = 1000;
		Item.createTile = Mod.Find<ModTile>("ArcaneTable").Type;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(36);
		recipe.AddIngredient(null, "MagicSoul", 10);
		recipe.AddTile(18);
		recipe.Register();
	}
}
