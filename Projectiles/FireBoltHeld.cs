using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class FireBoltHeld : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 52;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
	}

	public override void AI()
	{
		Projectile.damage = 0;
		Projectile.aiStyle = 0;
		Player player = Main.player[Projectile.owner];
		player.heldProj = Projectile.whoAmI;
		Projectile.aiStyle = 0;
		if (player.direction == 1)
		{
			Projectile.rotation = 25f;
			Projectile.spriteDirection = -1;
			Projectile.position.X = player.position.X + 4f;
			Projectile.position.Y = player.Center.Y - 16f;
		}
		if (player.direction == -1)
		{
			Projectile.rotation = 25f;
			Projectile.position.X = player.position.X - 16f;
			Projectile.position.Y = player.Center.Y - 16f;
		}
	}
}
