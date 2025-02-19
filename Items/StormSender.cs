using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class StormSender : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Storm Sender");
		// Tooltip.SetDefault("Casts multiple bolts of lightning which bounce off walls\nThe forked lightning now deals halved damage");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 22;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 12;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 24;
		Item.useAnimation = 24;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 20000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("StormSenderProj").Type;
		Item.shootSpeed = 60f;
	}

	public override void HoldItem(Player player)
	{
		player.itemLocation.Y = player.Center.Y;
		player.itemLocation.X = player.Center.X - (float)(4 * player.direction);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/ElectricZap").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		int numberProjectiles = 2 + Main.rand.Next(2);
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30f));
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("StormSenderProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "ThunderStaff");
		recipe.AddIngredient(null, "SkyCrystal", 5);
		recipe.AddIngredient(57, 10);
		recipe.AddIngredient(null, "InfusedStar", 20);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "ThunderStaff");
		recipe2.AddIngredient(null, "SkyCrystal", 5);
		recipe2.AddIngredient(1257, 10);
		recipe2.AddIngredient(null, "InfusedStar", 20);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
