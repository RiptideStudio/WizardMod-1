using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Head })]
public class LivingWoodMask : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Living Hood");
		// Tooltip.SetDefault("5% Increased magic damage");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1000;
		Item.rare = 1;
		Item.defense = 1;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "A living orb protects you\nSpell power increased by 1";
		player.GetModPlayer<Global>().livingArmor = true;
		player.GetModPlayer<Global>().spellPower++;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Magic) += 0.05f;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (body.type == Mod.Find<ModItem>("LivingWoodRobe").Type)
		{
			return legs.type == Mod.Find<ModItem>("LivingWoodLegs").Type;
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(9, 25);
		recipe.AddIngredient(null, "LivingShard");
		recipe.AddIngredient(null, "EnchantedSilk", 2);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
