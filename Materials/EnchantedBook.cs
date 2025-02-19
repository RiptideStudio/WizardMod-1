using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class EnchantedBook : ModItem
{
	public override void SetStaticDefaults()
	{
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = ItemRarityID.Green;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Book);
		recipe.AddIngredient(null, "MagicSoul", 10);
		recipe.AddTile(TileID.Bookcases);
		recipe.Register();
	}
}
