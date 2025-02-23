using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class ShadewoodStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Shadewood Staff");
		// Tooltip.SetDefault("Shoots a bolt of blood");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 12;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 2;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 34;
		Item.useAnimation = 34;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 10000;
		Item.rare = 1;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("ShadewoodProj").Type;
		Item.shootSpeed = 5.5f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(911, 12);
		recipe.AddIngredient(null, "MagicSoul", 3);
		recipe.AddTile(18);
		recipe.Register();
	}
}
