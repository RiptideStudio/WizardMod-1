using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class EnchantedShard : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Shards");
		// Tooltip.SetDefault("Used to create powerful magic gear");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(20, 3));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 2000;
		Item.rare = 2;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(25);
		recipe.AddIngredient(989);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(21);
		recipe2.AddIngredient(null, "InfusedStar");
		recipe2.AddIngredient(null, "MagicSoul");
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
		Recipe recipe3 = CreateRecipe();
		recipe3.AddIngredient(705);
		recipe3.AddIngredient(null, "InfusedStar");
		recipe3.AddIngredient(null, "MagicSoul");
		recipe3.AddTile(null, "ArcaneTable");
		recipe3.Register();
		Recipe recipe4 = CreateRecipe(10);
		recipe4.AddIngredient(55);
		recipe4.AddTile(null, "ArcaneTable");
		recipe4.Register();
	}
}
