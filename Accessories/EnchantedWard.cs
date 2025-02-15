using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Accessories;

[AutoloadEquip(new EquipType[] { EquipType.Shield })]
public class EnchantedWard : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Shield");
		// Tooltip.SetDefault("'You are protected by magic'\nMagically increases defense\nThe lower your health, the greater the protection\nHas a maximum defense of 12");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 3;
		Item.value = 150000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		int defense = player.statLifeMax * 3 / player.statLife;
		if (defense > 12)
		{
			defense = 12;
		}
		Item.defense = defense;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "EnchantedShard", 10);
		recipe.AddIngredient(19, 3);
		recipe.AddIngredient(178);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "EnchantedShard", 10);
		recipe2.AddIngredient(706, 3);
		recipe2.AddIngredient(178);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
