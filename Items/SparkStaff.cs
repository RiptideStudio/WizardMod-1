using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class SparkStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Staff of Sparking");
		// Tooltip.SetDefault("Casts a wave of sparks");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(3069);
		Item.damage = 11;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 6;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.useStyle = 5;
		Item.knockBack = 1f;
		Item.value = 10000;
		Item.rare = 2;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 7f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		MathHelper.ToRadians(0f);
		Projectile.NewProjectile((IEntitySource)source, position, velocity, 504, damage, knockback, player.whoAmI, 0f, 0f);
		int numProjectiles2 = 1;
		float spread = MathHelper.ToRadians(10f);
		double num = Math.Atan2((double)velocity.X, (double)velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / (float)numProjectiles2;
		double offsetAngle = num + deltaAngle;
		Projectile.NewProjectile((IEntitySource)source, position, velocity * (float)Math.Sin(offsetAngle), 504, damage, knockback, player.whoAmI, 0f, 0f);
		int numProjectiles3 = 1;
		float spread2 = MathHelper.ToRadians(-10f);
		double num2 = Math.Atan2((double)velocity.X, (double)velocity.Y) - (double)(spread2 / 2f);
		double deltaAngle2 = spread2 / (float)numProjectiles3;
		double offsetAngle2 = num2 + deltaAngle2;
		Projectile.NewProjectile((IEntitySource)source, position, velocity * (float)Math.Sin(offsetAngle2), 504, damage, knockback, player.whoAmI, 0f, 0f);
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "LivingShard");
		recipe.AddIngredient(null, "MagicSoul", 10);
		recipe.AddIngredient(3069);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
