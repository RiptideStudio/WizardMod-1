using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class XionTome : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Xion's Dream Tome");
		// Tooltip.SetDefault("Summons coils of dreamy flames around the player\nExplodes with a splash of color");
	}

	public override void SetDefaults()
	{
		Item.damage = 52;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 19;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.channel = true;
		Item.value = 250000;
		Item.rare = -11;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item100;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("DreamProj").Type;
		Item.shootSpeed = 20f;
	}

	public override void HoldItem(Player player)
	{
		Item.rare = -11;
		player.itemLocation.Y = player.Center.Y - 8f;
		if (player.direction == 1)
		{
			player.itemLocation.X = player.Center.X - (float)(32 * player.direction);
		}
		if (player.direction == -1)
		{
			player.itemLocation.X = player.Center.X + (float)(6 * player.direction);
		}
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 1 + Main.rand.Next(2);
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(20f));
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("DreamProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("DreamProj2").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(8f, 0f);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "XionTomeDamaged");
		recipe.AddIngredient(null, "LunarBar", 10);
		recipe.AddIngredient(547, 5);
		recipe.AddIngredient(549, 5);
		recipe.AddIngredient(548, 5);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
