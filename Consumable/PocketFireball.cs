using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Consumable;

public class PocketFireball : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Pocket Fireball");
		// Tooltip.SetDefault("Useful for a mage on the run\nBriefly lights enemies on fire");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
		ItemID.Sets.ItemNoGravity[Item.type] = true;
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 12;
		Item.height = 10;
		Item.maxStack = 999;
		Item.value = 100;
		Item.DamageType = DamageClass.Magic;
		Item.autoReuse = true;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 6;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item20;
		Item.useStyle = 5;
		Item.noUseGraphic = true;
		Item.shoot = Mod.Find<ModProjectile>("PocketFireballProjectile").Type;
		Item.consumable = true;
		Item.shootSpeed = 7f;
		Item.rare = 1;
		Item.noMelee = true;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		position = new Vector2(player.position.X, player.Center.Y);
		return true;
	}

	public override void PostUpdate()
	{
		Lighting.AddLight(Item.Center, Color.Orange.ToVector3() * 0.55f * Main.essScale);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(20);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.Register();
	}
}
