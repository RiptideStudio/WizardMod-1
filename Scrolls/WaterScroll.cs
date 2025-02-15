using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Scrolls;

public class WaterScroll : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Tsunami Scroll");
		// Tooltip.SetDefault("Summons a variety of oceanic attacks on use");
	}

	public override void SetDefaults()
	{
		Item.damage = 56;
		Item.DamageType = DamageClass.Magic;
		Item.consumable = true;
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 20000;
		Item.rare = 6;
		Item.autoReuse = true;
		Item.noMelee = true;
		Item.shoot = Mod.Find<ModProjectile>("WaterScrollProj").Type;
		Item.noUseGraphic = true;
		Item.shootSpeed = 30f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/Paper").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		float numberProjectiles = 10f;
		float rotation = MathHelper.ToRadians(180f);
		position += Vector2.Normalize(velocity) * 90f;
		for (int j = 0; (float)j < numberProjectiles; j++)
		{
			Vector2 perturbedSpeed2 = velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)j / (numberProjectiles - 1f))) * 0.2f;
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed2, 27, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed2 * 3f, 408, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed2, 22, damage * 2, knockback, player.whoAmI, 2f, 2f);
			int bubble2 = Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed2, 410, damage, knockback, player.whoAmI, 2f, 2f);
			Main.projectile[bubble2].scale = 0.25f;
			Main.projectile[bubble2].tileCollide = false;
			Main.projectile[bubble2].timeLeft = Main.rand.Next(120, 160);
		}
		for (int i = 0; i < 9; i++)
		{
			rotation = MathHelper.ToRadians(360f);
			Vector2 perturbedSpeed = new Vector2(30f, 30f).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f))) * 0.2f;
			int bubble = Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed * 2f, 410, damage, knockback, player.whoAmI, 2f, 2f);
			Main.projectile[bubble].scale = 0.25f;
			Main.projectile[bubble].tileCollide = false;
			Main.projectile[bubble].timeLeft = Main.rand.Next(120, 160);
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "Scroll");
		recipe.AddIngredient(275);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
