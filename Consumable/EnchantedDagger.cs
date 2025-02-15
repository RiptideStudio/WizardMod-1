using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Consumable;

public class EnchantedDagger : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Enchanted Dagger");
		// Tooltip.SetDefault("Like a knife, but magic");
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
		Item.damage = 18;
		Item.knockBack = 2f;
		Item.useStyle = 1;
		Item.noUseGraphic = true;
		Item.shoot = Mod.Find<ModProjectile>("EnchantedDaggerProjectile").Type;
		Item.consumable = true;
		Item.shootSpeed = 15f;
		Item.rare = 2;
		Item.noMelee = true;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		Vector2 pos = new Vector2(10f, -10f);
		for (int i = 0; i < 7; i++)
		{
			int xx = Main.rand.Next(-12, 12);
			int yy = Main.rand.Next(-12, 12);
			pos = ((player.direction != 1) ? new Vector2(-16f, -10f) : new Vector2(10f, -10f));
			int dust3 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 112);
			int dust4 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 15);
			Main.dust[dust3].noGravity = true;
			Main.dust[dust3].velocity *= 1f;
			Main.dust[dust4].noGravity = true;
			Main.dust[dust4].velocity *= 3f;
		}
		return true;
	}

	public override void PostUpdate()
	{
		Lighting.AddLight(Item.Center, Color.Orange.ToVector3() * 0.55f * Main.essScale);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(50);
		recipe.AddIngredient(null, "EnchantedShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
