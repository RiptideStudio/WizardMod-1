using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class FlameProj : ModProjectile
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
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 2;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 246);
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 position = Projectile.position;
				int dust = Dust.NewDust(position, 1, 1, 87);
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = (float)Main.rand.Next(35, 145) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(position, 1, 1, 6);
				Main.dust[dust2].velocity *= 0.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(35, 145) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 246);
		}
		target.AddBuff(24, 180);
	}
}
