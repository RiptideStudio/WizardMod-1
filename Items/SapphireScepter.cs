using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class SapphireScepter : ModItem
{
	private int attack;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sapphire Caduceus");
		// Tooltip.SetDefault("Casts a sapphire beam that releases smaller sapphire bolts every fourth shot");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 15;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 8;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 10000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 2f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		position += new Vector2(velocity.X * 21f, velocity.Y * 21f);
		Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("SapphireBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		attack++;
		if (attack == 4)
		{
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 24f - velocity.Y, position.Y + 12f + velocity.X), velocity, Mod.Find<ModProjectile>("SapphireBeamMini").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + 24f + velocity.Y, position.Y - 12f - velocity.X), velocity, Mod.Find<ModProjectile>("SapphireBeamMini").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + velocity.Y, position.Y + 24f + velocity.X), velocity, Mod.Find<ModProjectile>("SapphireBeamMini").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - velocity.Y, position.Y - 24f - velocity.X), velocity, Mod.Find<ModProjectile>("SapphireBeamMini").Type, damage / 2, 0f, player.whoAmI, 0f, 0f);
		}
		if (attack == 4)
		{
			attack = 0;
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(741);
		recipe.AddIngredient(null, "InfusedStar", 3);
		recipe.AddIngredient(null, "EnchantedShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
