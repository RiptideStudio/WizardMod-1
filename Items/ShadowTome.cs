using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class ShadowTome : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Shadow Tome");
		// Tooltip.SetDefault("Launches a piercing dark magic bolt\nCauses enemies to decay\nDecaying effect stacks twice");
	}

	public override void SetDefaults()
	{
		Item.damage = 21;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 7;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 26;
		Item.useAnimation = 26;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 20000;
		Item.rare = 2;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("ShadowProj").Type;
		Item.shootSpeed = 5f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/DarkCast1").WithPitchOffset(Main.rand.NextFloat(0f, 0.4f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "DarkTome");
		recipe.AddIngredient(null, "EnchantedBook");
		recipe.AddIngredient(19, 5);
		recipe.AddIngredient(null, "EnchantedShard", 3);
		recipe.AddTile(101);
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "DarkTome");
		recipe2.AddIngredient(null, "EnchantedBook");
		recipe2.AddIngredient(706, 5);
		recipe2.AddIngredient(null, "EnchantedShard", 3);
		recipe2.AddTile(101);
		recipe2.Register();
	}
}
