using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class SuperExplosion : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 512;
		Projectile.height = 512;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 5;
		Projectile.light = 2f;
		Projectile.ignoreWater = true;
		DrawOffsetX = -64;
		DrawOriginOffsetY = -64;
		Projectile.tileCollide = false;
		Projectile.scale = 1f;
	}
}
