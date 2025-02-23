using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class CorruptRing : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Corrupted Ringlet");
		// Tooltip.SetDefault("Magic attacks may cause enemies to rot or decay\nAfter 250 damage is dealt, small homing corrupt particles are released");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.rare = 3;
		Item.value = 5000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<Global>().corruptRing = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddIngredient(57, 8);
		recipe.AddIngredient(68, 5);
		recipe.AddIngredient(69, 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
