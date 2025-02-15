using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class StardustStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Stardust Slicer");
		// Tooltip.SetDefault("Shoots rapidly rotating star-discs");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 13;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 9;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 15000;
		Item.rare = 2;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("StardustProj").Type;
		Item.shootSpeed = 20f;
	}

	public override void HoldItem(Player player)
	{
		player.itemLocation.Y = player.Center.Y + 2f;
		player.itemLocation.X = player.Center.X + (float)(2 * player.direction);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "SkyCrystal");
		recipe.AddIngredient(null, "InfusedStar", 30);
		recipe.AddIngredient(706, 8);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "SkyCrystal");
		recipe2.AddIngredient(null, "InfusedStar", 30);
		recipe2.AddIngredient(19, 8);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
