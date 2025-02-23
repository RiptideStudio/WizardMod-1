using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Supernova : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Supernova");
		// Tooltip.SetDefault("Left-click to shoot a pair of rapidly rotating star-discs that home in on enemies\nRight-click to plant a deadly supernova for 100 mana\nUses true mana");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 47;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 14;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.useStyle = 5;
		Item.knockBack = 5f;
		Item.value = 300000;
		Item.rare = 6;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 11f;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.mana = 100;
			Item.useTime = 50;
			Item.useAnimation = 50;
		}
		else
		{
			Item.mana = 10;
			Item.useTime = 35;
			Item.useAnimation = 35;
		}
		return base.CanUseItem(player);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (player.altFunctionUse == 2)
		{
			Projectile.NewProjectile((IEntitySource)source, new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y), new Vector2(0f, 0f), Mod.Find<ModProjectile>("SuperNova").Type, damage * 2, knockback, player.whoAmI, 0f, 0f);
		}
		else
		{
			int numberProjectiles = 1;
			float rotation = MathHelper.ToRadians(15f);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, i / numberProjectiles));
				Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("SuperNovaDisc").Type, damage, knockback, player.whoAmI, 0f, 0f);
			}
			int numProjectiles2 = 1;
			float spread = MathHelper.ToRadians(15f);
			double startAngle = Math.Atan2((double)velocity.X, (double)velocity.Y) - (double)(spread / 2f);
			double deltaAngle = spread / (float)numProjectiles2;
			for (int j = 0; j < numProjectiles2; j++)
			{
				double offsetAngle = startAngle + deltaAngle * (double)j;
				Projectile.NewProjectile((IEntitySource)source, position, velocity * (float)Math.Sin(offsetAngle), Mod.Find<ModProjectile>("SuperNovaDisc").Type, damage, knockback, player.whoAmI, 0f, 0f);
			}
		}
		return false;
	}

	public override void HoldItem(Player player)
	{
		player.itemLocation.Y = player.Center.Y + 2f;
		player.itemLocation.X = player.Center.X + (float)(2 * player.direction);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "CelestialSky");
		recipe.AddIngredient(null, "LunarBar", 5);
		recipe.AddIngredient(520, 15);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
