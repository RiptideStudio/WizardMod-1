using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class StardustProj : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 21;
	}

	public override void SetDefaults()
	{
		Projectile.width = 48;
		Projectile.height = 36;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 160;
		Projectile.light = 2f;
		Projectile.ignoreWater = true;
		DrawOffsetX = -24;
		DrawOriginOffsetY = -24;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		if (++Projectile.frameCounter >= 1)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 21)
			{
				Projectile.frame = 0;
			}
		}
		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 159);
		Main.dust[dust2].velocity.Y *= 1f;
		Projectile.velocity.X *= 0.94f;
		Projectile.velocity.Y *= 0.94f;
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		for (int num371 = 0; num371 < 2; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 169, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 2f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 159, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 3f;
		}
	}

	public override void OnKill(int timeLeft)
	{
		_ = Main.player[Projectile.owner];
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 169, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 159, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 5f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 159, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 8f;
		}
		for (int i = 0; i < 12; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 169);
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 159);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity.Y *= 8f;
		}
	}
}
