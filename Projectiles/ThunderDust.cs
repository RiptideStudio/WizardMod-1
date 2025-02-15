using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class ThunderDust : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 4;
		Projectile.height = 4;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 15;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 6;
		Projectile.position.X += 32f;
		Projectile.position.Y += 24f;
	}

	public override void AI()
	{
		Projectile.damage = 0;
		Projectile.position.X += (float)Math.Sin((double)Projectile.timeLeft) / 5f * 20f;
		Projectile.position.Y += (float)Math.Cos((double)(Projectile.timeLeft / 2)) / 5f * 20f;
		if (Main.rand.Next(1) == 0)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 160);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(64, 98) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 160);
			Main.dust[dust2].velocity *= 0.2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(64, 98) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt((double)(vector.X * vector.X + vector.Y * vector.Y));
		if (magnitude > 8.5f)
		{
			vector *= 8.5f / magnitude;
		}
	}
}
