using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class NecroticTome : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Necrotic Tome");
		// Tooltip.SetDefault("Launches a volley of life stealing dark orbs\nBounces off walls");
	}

	public override void SetDefaults()
	{
		Item.damage = 38;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 16;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 300000;
		Item.rare = 5;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item60;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("NecroticOrb").Type;
		Item.shootSpeed = 10.5f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 1 + Main.rand.Next(2);
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(25f));
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("NecroticOrb").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "Weeper");
		recipe.AddIngredient(531);
		recipe.AddIngredient(521, 12);
		recipe.AddIngredient(527, 3);
		recipe.AddTile(101);
		recipe.Register();
	}
}
