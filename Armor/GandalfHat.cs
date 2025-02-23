using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Head })]
public class GandalfHat : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Death Eater's Hat");
		// Tooltip.SetDefault("15% Increased magic damage\nMana usage reduced by 12%");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 10000;
		Item.rare = 5;
		Item.defense = 5;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "Magic attacks have a chance to summon lightning strikes and dark explosions on impact\nDark explosions cause enemies to decay\nEach fourth magic attack casts a fireball";
		player.GetModPlayer<Global>().gandalfArmor = true;
	}

	public override void UpdateEquip(Player player)
	{
		player.manaCost -= 0.12f;
		player.GetDamage(DamageClass.Magic) += 0.15f;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (body.type == Mod.Find<ModItem>("GandalfRobe").Type)
		{
			return legs.type == Mod.Find<ModItem>("GandalfLegs").Type;
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(527);
		recipe.AddIngredient(521, 3);
		recipe.AddIngredient(null, "LunarBar", 10);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
