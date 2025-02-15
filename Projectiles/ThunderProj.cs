using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class ThunderProj : ModProjectile
{
	private double dist = 64.0;

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
		Projectile.timeLeft = 1560;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		_ = Main.player[Projectile.owner];
		return false;
	}

	public override void AI()
	{
		Player p = Main.player[Projectile.owner];
		double rad = (double)Projectile.ai[1] * 3.0 * (Math.PI / 180.0);
		this.dist -= Math.Sin((double)(Projectile.timeLeft / 15));
		Projectile.position.X = p.Center.X + 8f - (float)(int)(Math.Cos(rad) * this.dist) - (float)(Projectile.width / 2);
		Projectile.position.Y = p.Center.Y + 8f - (float)(int)(Math.Sin(rad) * this.dist) - (float)(Projectile.height / 2);
		float posY = p.Center.Y - (float)(int)(Math.Cos(rad) * (0.0 - this.dist)) - (float)(Projectile.height / 2);
		float posX = p.Center.X - (float)(int)(Math.Sin(rad) * (0.0 - this.dist)) - (float)(Projectile.width / 2);
		Projectile.ai[1] += 1f;
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Vector2 position = new Vector2(Projectile.position.X, Projectile.position.Y);
		Vector2 projectilePosition2 = new Vector2(posX, posY);
		int dust = Dust.NewDust(position, 1, 1, 160);
		Main.dust[dust].velocity *= 1f;
		Main.dust[dust].scale = (float)Main.rand.Next(125, 165) * 0.013f;
		Main.dust[dust].noGravity = true;
		int dust2 = Dust.NewDust(position, 1, 1, 160);
		Main.dust[dust2].velocity *= 1.2f;
		Main.dust[dust2].scale = (float)Main.rand.Next(125, 165) * 0.013f;
		Main.dust[dust2].noGravity = true;
		int dust3 = Dust.NewDust(projectilePosition2, 1, 1, 160);
		Main.dust[dust3].velocity *= 0.6f;
		Main.dust[dust3].scale = (float)Main.rand.Next(125, 165) * 0.013f;
		Main.dust[dust3].noGravity = true;
		int dust4 = Dust.NewDust(projectilePosition2, 1, 1, 160);
		Main.dust[dust4].velocity *= 1f;
		Main.dust[dust4].scale = (float)Main.rand.Next(125, 165) * 0.013f;
		Main.dust[dust4].noGravity = true;
	}
}
