using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class ClearCrystal : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Clear Stone");
		// Tooltip.SetDefault("Max mana increased by 40\nCritical strike mana recovery increased by 1\nSpell power increased by 1");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 1;
		Item.value = 15000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.statManaMax2 += 40;
		player.GetModPlayer<Global>().spellPower++;
		player.GetModPlayer<Global>().manaOnHit++;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.ManaCrystal);
		recipe.AddIngredient(null, "InfusedStar", 5);
		recipe.AddIngredient(null, "EnchantedShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
