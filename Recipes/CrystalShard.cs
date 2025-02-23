using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class CrystalShard : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Crystal Shard");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 1;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(502);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddIngredient(ItemID.SoulofLight);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
