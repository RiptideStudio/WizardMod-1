using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Legs })]
public class EnchantedLegs : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Leggings");
		// Tooltip.SetDefault("5% Increased magic damage\n7% Increased movement speed");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1000;
		Item.rare = 3;
		Item.defense = 5;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.07f;
		player.GetDamage(DamageClass.Magic) += 0.05f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "EnchantedShard", 10);
		recipe.AddIngredient(19, 7);
		recipe.AddIngredient(null, "EnchantedSilk", 4);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "EnchantedShard", 10);
		recipe2.AddIngredient(706, 7);
		recipe2.AddIngredient(null, "EnchantedSilk", 4);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
