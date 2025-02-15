using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class EnchantedTunic : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Tunic");
		// Tooltip.SetDefault("3% Increased magic damage and critical strike chance\nMana usage reduced by 7%\nMax mana increased by 20\nCritical strike mana recvovery increased by 1");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1250;
		Item.rare = 3;
		Item.defense = 6;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetModPlayer<Global>().manaOnHit++;
		player.GetDamage(DamageClass.Magic) += 0.03f;
		player.GetCritChance(DamageClass.Magic) += 3f;
		player.manaCost -= 0.07f;
		player.statManaMax2 += 20;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "EnchantedShard", 12);
		recipe.AddIngredient(19, 10);
		recipe.AddIngredient(null, "EnchantedSilk", 4);
		recipe.AddIngredient(178);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "EnchantedShard", 12);
		recipe2.AddIngredient(706, 10);
		recipe2.AddIngredient(null, "EnchantedSilk", 4);
		recipe2.AddIngredient(178);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
