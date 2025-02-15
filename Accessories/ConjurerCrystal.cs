using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class ConjurerCrystal : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Conjurer's Crystal");
		// Tooltip.SetDefault("Max mana increased by 40\nMax life increased by 40\nMana and life regeneration increased\nCritical strike mana recovery increased by 2\nSpell power increased by 1");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 3;
		Item.value = 15000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.statManaMax2 += 40;
		player.statLifeMax2 += 40;
		player.lifeRegen += 4;
		player.manaRegen += 4;
		player.GetModPlayer<Global>().manaOnHit += 2;
		player.GetModPlayer<Global>().spellPower++;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "LifeCrystal");
		recipe.AddIngredient(null, "ClearCrystal");
		recipe.AddTile(114);
		recipe.Register();
	}
}
