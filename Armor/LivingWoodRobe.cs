using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class LivingWoodRobe : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Living Tunic");
		// Tooltip.SetDefault("Max mana increased by 20\nMana usage reduced by 5%");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1250;
		Item.rare = 1;
		Item.defense = 3;
	}

	public override void UpdateEquip(Player player)
	{
		player.statManaMax2 += 20;
		player.manaCost -= 0.05f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(9, 35);
		recipe.AddIngredient(null, "LivingShard", 2);
		recipe.AddIngredient(null, "EnchantedSilk", 5);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
