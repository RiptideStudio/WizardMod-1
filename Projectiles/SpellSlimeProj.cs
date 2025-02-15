using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class SpellSlimeProj : ModProjectile
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
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = false;
		Projectile.hostile = true;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 400;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 112);
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 112);
		}
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		if (Projectile.timeLeft < 350)
		{
			Projectile.velocity.Y += 0.075f;
		}
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 2; i++)
			{
				int dust = Dust.NewDust(Projectile.position, 1, 1, 112, 0f, 0f, 0, Color.Aqua);
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = (float)Main.rand.Next(35, 95) * 0.013f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
