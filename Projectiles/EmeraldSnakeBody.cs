using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class EmeraldSnakeBody : ModProjectile
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
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 6;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
	}
}
