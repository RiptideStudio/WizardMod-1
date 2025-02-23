using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Relic : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Relic");
		// Tooltip.SetDefault("Launches a dusty fossil that creates an explosion of sand on impact\nCreates piercing rocks that linger on the ground and damage enemies that step on them\nLingering rocks shrink and eventually explode");
	}

	public override void SetDefaults()
	{
		Item.damage = 23;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 14;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 37;
		Item.useAnimation = 37;
		Item.useStyle = 5;
		Item.knockBack = 7f;
		Item.value = 25000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item69;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("RelicRock").Type;
		Item.shootSpeed = 8.5f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(149);
		recipe.AddIngredient(323, 3);
		recipe.AddIngredient(3271, 50);
		recipe.AddIngredient(null, "MagicSoul", 10);
		recipe.AddTile(101);
		recipe.Register();
	}
}
