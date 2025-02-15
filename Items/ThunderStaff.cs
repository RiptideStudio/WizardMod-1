using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class ThunderStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Thunder Staff");
		// Tooltip.SetDefault("It was Zeus's favorite toy as a baby\nCasts a small bolt of lightning");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 17;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 7;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 28;
		Item.useAnimation = 28;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 10000;
		Item.rare = 2;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("ThunderStaffProj").Type;
		Item.shootSpeed = 60f;
	}

	public override void HoldItem(Player player)
	{
		player.itemLocation.Y = player.Center.Y;
		player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/ElectricZap").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X, position.Y - 16f), velocity, Mod.Find<ModProjectile>("ThunderStaffProj").Type, damage, knockback, player.whoAmI, 2f, 2f);
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(20, 8);
		recipe.AddIngredient(null, "InfusedStar", 12);
		recipe.AddIngredient(null, "SkyCrystal");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(703, 8);
		recipe2.AddIngredient(null, "InfusedStar", 12);
		recipe2.AddIngredient(null, "SkyCrystal");
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
