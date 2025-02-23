using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class WaterFront : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Waterfront");
		// Tooltip.SetDefault("Casts a slow moving bolt of deep water\nCreates miniature water bolts that fly upwards and then rain down on impact");
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(165);
		Item.damage = 25;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 12;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 23;
		Item.useAnimation = 23;
		Item.useStyle = 5;
		Item.knockBack = 5f;
		Item.value = 30000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("WaterfrontProj").Type;
		Item.shootSpeed = 2.5f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		return true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(165);
		recipe.AddIngredient(null, "EnchantedBook");
		recipe.AddIngredient(275, 3);
		recipe.AddIngredient(2626, 3);
		recipe.AddIngredient(2625, 3);
		recipe.AddIngredient(154, 15);
		recipe.AddTile(101);
		recipe.Register();
	}
}
