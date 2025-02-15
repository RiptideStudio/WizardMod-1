using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class InfusedStar : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Lunar Essence");
		// Tooltip.SetDefault("'All you need is faith, trust, and stardust!'\nUsed to craft magic weapons and spells");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 8));
		ItemID.Sets.ItemNoGravity[Item.type] = true;
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.maxStack = 999;
		Item.value = 1000;
		Item.rare = 2;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(8);
		recipe.AddIngredient(75);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
