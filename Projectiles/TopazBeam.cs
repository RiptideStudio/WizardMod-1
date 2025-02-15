using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class TopazBeam : ModProjectile
{
	private int dust_num = 87;

	private int dust_num2 = 87;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Topaz Beam");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 3;
		Projectile.timeLeft = 75;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 6;
	}

	public override void AI()
	{
		int dust = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X, Projectile.position.Y), 0, 0, this.dust_num);
		Main.dust[dust].velocity *= 0f;
		Main.dust[dust].scale = (float)Main.rand.Next(90, 125) * 0.013f;
		Main.dust[dust].noGravity = true;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		if (Projectile.velocity.X != oldVelocity.X)
		{
			Projectile.velocity.X = (0f - oldVelocity.X) / 2f;
		}
		if (Projectile.velocity.Y != oldVelocity.Y)
		{
			Projectile.velocity.Y = 0f - oldVelocity.Y;
		}
		return false;
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
