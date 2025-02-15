using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class ChaosEnchantment : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Chaos Enchantment");
		// Tooltip.SetDefault("'Let the chaos reign!'\nDebuffs spread to nearby enemies every second\nRe-applied debuffs quickly disappear");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 3;
		Item.value = 30000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<Global>().chaosEnchantment = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(57, 10);
		recipe.AddIngredient(null, "EnchantedShard", 3);
		recipe.AddIngredient(null, "MagicSoul", 5);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(1257, 10);
		recipe2.AddIngredient(null, "EnchantedShard", 3);
		recipe2.AddIngredient(null, "MagicSoul", 5);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
