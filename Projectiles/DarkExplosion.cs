using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DarkExplosion : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 7;
	}

	public override void SetDefaults()
	{
		Projectile.width = 4;
		Projectile.arrow = true;
		Projectile.height = 4;
		Projectile.aiStyle = 612;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = 3751057;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.extraUpdates = 1;
		Projectile.width = 36;
		Projectile.height = 36;
		Projectile.timeLeft = 15;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		if (++Projectile.frameCounter >= 1)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 7)
			{
				Projectile.frame = 0;
			}
		}
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		return true;
	}
}
