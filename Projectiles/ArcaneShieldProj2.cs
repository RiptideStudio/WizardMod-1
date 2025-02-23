using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class ArcaneShieldProj2 : ModProjectile
{
	private int dustType = 112;

	private double dist = 96.0;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 24;
		Projectile.height = 24;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.extraUpdates = 1;
		Projectile.timeLeft = 1200;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		_ = Main.player[Projectile.owner];
		return false;
	}

	public override void AI()
	{
		Player p = Main.player[Projectile.owner];
		double rad = (double)Projectile.ai[1] * 2.0 * (Math.PI / 180.0);
		this.dist -= Math.Sin((double)(Projectile.timeLeft / 10)) / 2.0;
		Projectile.position.X = p.Center.X - (float)(int)(Math.Sin(rad) * this.dist) - (float)(Projectile.width / 2);
		Projectile.position.Y = p.Center.Y - (float)(int)(Math.Cos(rad) * this.dist) - (float)(Projectile.height / 2);
		int minDustSize = 40 + (int)p.GetCritChance(DamageClass.Magic) * 4;
		int maxDustSize = 70 + (int)p.GetCritChance(DamageClass.Magic) * 4;
		Projectile.width = 16 + (int)p.GetCritChance(DamageClass.Magic) * 3;
		Projectile.height = 16 + (int)p.GetCritChance(DamageClass.Magic) * 3;
		Projectile.ai[1] += 1f;
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Vector2 position = new Vector2(Projectile.position.X, Projectile.position.Y);
		int dustType = 112;
		int dust = Dust.NewDust(position, 1, 1, dustType);
		Main.dust[dust].velocity *= 0.2f;
		Main.dust[dust].scale = (float)Main.rand.Next(minDustSize, maxDustSize) * 0.013f;
		Main.dust[dust].noGravity = true;
		int dust2 = Dust.NewDust(position, 1, 1, dustType);
		Main.dust[dust2].velocity *= 0.2f;
		Main.dust[dust2].scale = (float)Main.rand.Next(minDustSize, maxDustSize) * 0.013f;
		Main.dust[dust2].noGravity = true;
	}

	public override void OnKill(int timeLeft)
	{
		_ = Main.player[Projectile.owner];
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 112, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 0.4f;
			Main.dust[num370].noGravity = true;
		}
	}
}
