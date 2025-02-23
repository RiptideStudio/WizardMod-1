using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class SapphireBeamMini : ModProjectile
{
	private int dust_num = 88;

	private int dust_num2 = 88;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sapphire Beam");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 7;
		Projectile.height = 10;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 350;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 6;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		int dust = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X, Projectile.position.Y), 0, 0, this.dust_num);
		Main.dust[dust].velocity *= 0f;
		Main.dust[dust].scale = (float)Main.rand.Next(65, 85) * 0.013f;
		Main.dust[dust].noGravity = true;
		Projectile.velocity *= 0.996f;
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 8; i++)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, this.dust_num);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust].scale = (float)Main.rand.Next(115, 155) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, this.dust_num2);
			Main.dust[dust2].velocity *= 3f;
			Main.dust[dust2].scale = (float)Main.rand.Next(115, 155) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
	}
}
