using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class MotherEarth : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Mother Earth [Uncoded]");
		// Tooltip.SetDefault("Contains the destructive power of the earth itself");
	}

	public override void SetDefaults()
	{
		Item.damage = 71;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 21;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 17;
		Item.useAnimation = 17;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 300000;
		Item.rare = 10;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("AquaticFuryProj2").Type;
		Item.shootSpeed = 6f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		position += new Vector2(velocity.X * 3f, 0f);
		int numberProjectiles = 3;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(-10 + i * 10));
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("AquaticFuryProj2").Type, damage, knockback, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("MonsoonBlast").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		for (int j = 0; j < 5; j++)
		{
			Vector2 pos = new Vector2(10f, -10f);
			int xx = Main.rand.Next(-12, 12);
			int yy = Main.rand.Next(-12, 12);
			pos = ((player.direction != 1) ? new Vector2(-16f, -10f) : new Vector2(10f, -10f));
			int dust3 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 175);
			Dust.NewDust(position + pos + pos, Item.width + xx, Item.height + yy, 56);
			int dust4 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 211);
			Main.dust[dust3].noGravity = true;
			Main.dust[dust3].velocity *= 12f;
			Main.dust[dust4].noGravity = true;
			Main.dust[dust4].velocity *= 6f;
		}
		return true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}
}
