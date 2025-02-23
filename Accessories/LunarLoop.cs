using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class LunarLoop : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Stardust Loophole");
		// Tooltip.SetDefault("Increases maximum mana by 20\n7% increased magic damage\nSpell power increased by 1");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.rare = 2;
		Item.value = 5000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.statManaMax2 += 20;
		player.GetDamage(DamageClass.Magic) += 0.07f;
		player.GetModPlayer<Global>().spellPower++;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddIngredient(null, "InfusedStar", 35);
		recipe.AddIngredient(ItemID.GoldBar, 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "MetalBand");
		recipe2.AddIngredient(null, "InfusedStar", 35);
		recipe2.AddIngredient(ItemID.PlatinumBar, 3);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
