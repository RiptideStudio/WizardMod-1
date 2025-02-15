using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Weeper : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Weeper");
		// Tooltip.SetDefault("Casts a blast of dark magic\nCauses enemies to decay longer\nDecaying effect stacks thrice");
	}

	public override void SetDefaults()
	{
		Item.damage = 28;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 8;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 22;
		Item.useAnimation = 22;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 20000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("WeeperProj").Type;
		Item.shootSpeed = 6.5f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/DarkCast2").WithPitchOffset(Main.rand.NextFloat(-0.4f, 0f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		return true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "ShadowTome");
		recipe.AddIngredient(null, "EnchantedBook");
		recipe.AddIngredient(null, "MagicSoul", 10);
		recipe.AddIngredient(86, 6);
		recipe.AddIngredient(null, "InfusedStar", 3);
		recipe.AddTile(101);
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "ShadowTome");
		recipe2.AddIngredient(null, "EnchantedBook");
		recipe2.AddIngredient(null, "MagicSoul", 10);
		recipe2.AddIngredient(1329, 6);
		recipe2.AddIngredient(null, "InfusedStar", 3);
		recipe2.AddTile(101);
		recipe2.Register();
	}
}
