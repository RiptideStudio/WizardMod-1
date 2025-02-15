using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class AetherAmulet : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Aether Amulet");
		// Tooltip.SetDefault("Greatly increased invincibility time after being hit\nWhen hit, the player receives the Arcane Buff, which increases magic capabilities\nArcane Buff has a 30 second cooldown after being activated");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 7;
		Item.value = 150000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<Global>().aetherAmulet = true;
		if (player.HasBuff(Mod.Find<ModBuff>("ArcaneBuff").Type))
		{
			Item.defense = 4;
		}
		else
		{
			Item.defense = 0;
		}
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(554);
		recipe.AddIngredient(501, 25);
		recipe.AddIngredient(1225, 10);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
