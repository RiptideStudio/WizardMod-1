using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class WildFire : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Wildfire");
		// Tooltip.SetDefault("The Lorax is coming for you...\nHold left-click to cast a concentrated blast of fire");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(3069);
		Item.damage = 14;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 6;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 5;
		Item.useAnimation = 5;
		Item.useStyle = 5;
		Item.knockBack = 1f;
		Item.value = 30000;
		Item.rare = 4;
		Item.noMelee = true;
		Item.channel = true;
		Item.shoot = Mod.Find<ModProjectile>("ExampleLaser").Type;
		Item.shootSpeed = 9f;
	}

	public override void HoldItem(Player player)
	{
		player.itemLocation.Y = player.Center.Y + 6f;
		player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "SparkStaff");
		recipe.AddIngredient(null, "EnchantedShard", 3);
		recipe.AddIngredient(null, "LivingShard", 5);
		recipe.AddIngredient(null, "DeepslateBar", 8);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
