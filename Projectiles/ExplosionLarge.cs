using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class ExplosionLarge : ModProjectile
{
	private float force = 1f;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 8;
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
		Projectile.timeLeft = 75;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		Projectile.alpha += 4;
		if (++Projectile.frameCounter >= 7)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame > 12)
			{
				Projectile.frame = 0;
			}
		}
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		this.force -= 0.01f;
		Projectile.position.Y -= this.force;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		return true;
	}
}
