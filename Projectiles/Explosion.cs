using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class Explosion : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 24;
		Projectile.height = 24;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = -1;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.scale = 1f;
		Projectile.extraUpdates = 1;
		Projectile.width = 60;
		Projectile.height = 60;
		Projectile.timeLeft = 5;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
	}
}
