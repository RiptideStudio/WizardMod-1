using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class RainbowStaff : ModItem
{
	private int attack;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Gemspark Flash");
		// Tooltip.SetDefault("Has the effects of all gem staffs\nCasts an emerald raindrop every second attack\nCasts a topaz beam every third attack\nShoots a burst of rainbow beams every fourth attack\nActs as a spear");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 25;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 17;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 100000;
		Item.rare = 4;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 3.5f;
		Item.noUseGraphic = true;
	}

	public override bool CanUseItem(Player player)
	{
		return player.ownedProjectileCounts[Mod.Find<ModProjectile>("RainbowSpear").Type] < 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - velocity.X, position.Y - velocity.Y), velocity, Mod.Find<ModProjectile>("RainbowSpear").Type, damage / 2, knockback, player.whoAmI, 0f, 0f);
		position += new Vector2(velocity.X * 15f, velocity.Y * 15f);
		Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("RainbowBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		attack++;
		if (attack == 3)
		{
			Projectile.NewProjectile((IEntitySource)source, position, velocity * 3f, Mod.Find<ModProjectile>("TopazBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		if (attack == 1 || attack == 3)
		{
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 24f - velocity.Y, position.Y + 12f + velocity.X), velocity, Mod.Find<ModProjectile>("EmeraldBeam").Type, damage, 0f, player.whoAmI, 0f, 0f);
		}
		if (attack == 4)
		{
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 24f - velocity.Y, position.Y + 12f + velocity.X), velocity, Mod.Find<ModProjectile>("RubyBeam").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + 24f + velocity.Y, position.Y - 12f - velocity.X), velocity, Mod.Find<ModProjectile>("SapphireBeam").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + velocity.Y, position.Y + 18f + velocity.X), velocity, Mod.Find<ModProjectile>("AmethystBeam").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - velocity.Y, position.Y - 18f - velocity.X), velocity, Mod.Find<ModProjectile>("DiamondBeam").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + velocity.Y, position.Y + 6f + velocity.X), velocity, Mod.Find<ModProjectile>("EmeraldBeamReal").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + velocity.Y, position.Y - 6f - velocity.X), velocity, Mod.Find<ModProjectile>("TopazBeamReal").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			attack = 0;
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "AmethystScepter");
		recipe.AddIngredient(null, "TopazScepter");
		recipe.AddIngredient(null, "SapphireScepter");
		recipe.AddIngredient(null, "EmeraldScepter");
		recipe.AddIngredient(null, "RubyScepter");
		recipe.AddIngredient(null, "DiamondScepter");
		recipe.AddIngredient(null, "EnchantedShard", 12);
		recipe.AddTile(26);
		recipe.Register();
	}
}
