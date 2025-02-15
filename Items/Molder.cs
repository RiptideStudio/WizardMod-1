using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Molder : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Moulderer");
		// Tooltip.SetDefault("Right-click to shoot an infectious projectile that inflicts rotting\nLeft-click to launch a piercing rotten tooth, which deals more damage against rotting enemies");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(3870);
		Item.damage = 27;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 10;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 18;
		Item.useAnimation = 18;
		Item.useStyle = 5;
		Item.knockBack = 2f;
		Item.value = 10000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 9.5f;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.knockBack = 2f;
			Item.shootSpeed = 10f;
			Item.mana = 5;
		}
		else
		{
			Item.knockBack = 3f;
			Item.shootSpeed = 9f;
			Item.mana = 10;
		}
		return base.CanUseItem(player);
	}

	public override void HoldItem(Player player)
	{
		player.itemLocation.Y = player.Center.Y;
		player.itemLocation.X = player.Center.X - (float)(4 * player.direction);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 offset = Vector2.Normalize(velocity) * 15f;
		position += offset;
		if (player.altFunctionUse == 2)
		{
			Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("RottenProj").Type, damage / 2, knockback, player.whoAmI, 0f, 0f);
		}
		else
		{
			Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("ToothProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(57, 12);
		recipe.AddIngredient(86, 4);
		recipe.AddIngredient(null, "MagicSoul", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
