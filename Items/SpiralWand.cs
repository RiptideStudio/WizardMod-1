using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class SpiralWand : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Death Eater Wand");
		// Tooltip.SetDefault("Hold left-click to turn into a dark spiral\nRapidly drains your mana\nHoming rotting skulls are released while active\nAllows the player to go through walls");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(739);
		Item.damage = 47;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 5;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 5;
		Item.useAnimation = 5;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 10000;
		Item.rare = 6;
		Item.noMelee = false;
		Item.channel = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("SpiralProj").Type;
		Item.shootSpeed = 23f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		player.noKnockback = true;
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		return player.ownedProjectileCounts[Mod.Find<ModProjectile>("SpiralProj").Type] <= 0;
	}
}
