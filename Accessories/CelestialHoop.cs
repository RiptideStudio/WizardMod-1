using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class CelestialHoop : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Celestial Hoop");
		// Tooltip.SetDefault("Increases maximum mana by 40\n7% increased magic damage and critical strike chance\nSpell power increased by 1\nCauses stardust scythes to be released when hit");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.rare = 3;
		Item.value = 30000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.statManaMax2 += 40;
		player.GetDamage(DamageClass.Magic) += 0.07f;
		player.GetCritChance(DamageClass.Magic) += 7f;
		player.GetModPlayer<Global>().spellPower++;
		player.GetModPlayer<Global>().celestialHoop = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddIngredient(null, "InfusedStar", 35);
		recipe.AddIngredient(19, 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "MetalBand");
		recipe2.AddIngredient(null, "InfusedStar", 35);
		recipe2.AddIngredient(706, 3);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
