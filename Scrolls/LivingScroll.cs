using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Scrolls;

public class LivingScroll : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Living Scroll");
		// Tooltip.SetDefault("Unleashes an all-natural, organic, grass-fed gluten free assault on your enemies");
	}

	public override void SetDefaults()
	{
		Item.damage = 15;
		Item.DamageType = DamageClass.Magic;
		Item.consumable = true;
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.useStyle = 5;
		Item.knockBack = 2f;
		Item.value = 10000;
		Item.rare = 2;
		Item.autoReuse = true;
		Item.noMelee = true;
		Item.shoot = Mod.Find<ModProjectile>("LivingScrollProj").Type;
		Item.noUseGraphic = true;
		Item.shootSpeed = 30f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle;
		if (Main.rand.Next(0, 5) == 1)
		{
			soundStyle = new SoundStyle("WizardMod/Sounds/SpellCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
			SoundEngine.PlaySound(soundStyle, (Vector2?)position);
			Projectile.NewProjectile((IEntitySource)source, new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y), new Vector2(0f, 0f), Mod.Find<ModProjectile>("EnergyProj").Type, 0, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y), new Vector2(0f, 0f), Mod.Find<ModProjectile>("EnergyProjMiddle").Type, 0, knockback, player.whoAmI, 2f, 2f);
		}
		soundStyle = new SoundStyle("WizardMod/Sounds/Paper").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		float numberProjectiles = 10f;
		float rotation = MathHelper.ToRadians(180f);
		position += Vector2.Normalize(velocity) * 90f;
		for (int i = 0; (float)i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f))) * 0.2f;
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed, 206, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed, 227, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed / 2f, Mod.Find<ModProjectile>("EnergizerLightning").Type, damage, knockback, player.whoAmI, 2f, 2f);
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(2);
		recipe.AddIngredient(null, "Scroll", 2);
		recipe.AddIngredient(null, "LivingShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
