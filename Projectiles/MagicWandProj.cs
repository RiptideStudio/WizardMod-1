using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class MagicWandProj : ModProjectile
{
	private int dust_num = 173;

	private int dust_num2 = 65;

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
		Projectile.penetrate = 1;
		Projectile.timeLeft = 200;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num2);
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		if (Projectile.timeLeft < 160)
		{
			Projectile.velocity.Y += 0.05f;
		}
		if (Main.rand.Next(1) == 0)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 242);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num2);
			Main.dust[dust].velocity *= 0f;
			Main.dust[dust2].velocity *= 0f;
		}
		Projectile.position.X += (float)Math.Sin((double)Projectile.timeLeft) * 2f;
		Projectile.position.Y += (float)Math.Cos((double)Projectile.timeLeft) * 2f;
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		int num = Main.rand.Next(0, 4);
		if (num == 1)
		{
			target.AddBuff(24, 180);
		}
		if (num == 2)
		{
			target.AddBuff(44, 180);
		}
		if (num == 3)
		{
			target.AddBuff(69, 180);
		}
		if (num == 0)
		{
			target.AddBuff(20, 180);
		}
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num2);
		}
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num2);
		}
	}
}
