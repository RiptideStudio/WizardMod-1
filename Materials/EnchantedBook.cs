using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class EnchantedBook : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Book");
		// Tooltip.SetDefault("Used to craft magic tomes");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 1;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(149);
		recipe.AddIngredient(null, "MagicSoul", 5);
		recipe.AddTile(101);
		recipe.Register();
	}
}
