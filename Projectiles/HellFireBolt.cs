using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class HellFireBolt : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 228;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 32;
		Projectile.height = 32;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 999;
		Projectile.timeLeft = 480;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 55);
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		float xx = (float)Math.Sin((double)Projectile.timeLeft) * (float)Math.Sin((double)Projectile.timeLeft) * 100f;
		Math.Cos((double)Projectile.timeLeft);
		Math.Cos((double)Projectile.timeLeft);
		Vector2 dustPos1 = new Vector2(Projectile.position.X - xx, Projectile.position.Y + xx);
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 5; i++)
			{
				_ = Projectile.position;
				int dust = Dust.NewDust(dustPos1, 1, 1, 6);
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = (float)Main.rand.Next(75, 175) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(dustPos1, 1, 1, 55);
				Main.dust[dust2].velocity *= 0.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(10, 120) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
		}
		target.AddBuff(24, 180);
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 20; i++)
		{
			int xx = Main.rand.Next(16);
			int yy = Main.rand.Next(16);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 55);
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width + 8 + xx, Projectile.height + yy, 55);
			Main.dust[dust3].velocity *= 0.2f;
			Main.dust[dust3].scale = (float)Main.rand.Next(10, 120) * 0.013f;
			Main.dust[dust3].noGravity = true;
			int dust4 = Dust.NewDust(Projectile.position, Projectile.width + 8 + xx, Projectile.height + yy, 6);
			Main.dust[dust4].velocity *= 0.2f;
			Main.dust[dust4].scale = (float)Main.rand.Next(10, 175) * 0.013f;
			Main.dust[dust4].noGravity = true;
			int dust5 = Dust.NewDust(Projectile.position, Projectile.width + 8 + xx, Projectile.height + yy, 6);
			Main.dust[dust5].velocity *= 0.2f;
			Main.dust[dust5].scale = (float)Main.rand.Next(10, 175) * 0.013f;
			Main.dust[dust5].noGravity = true;
		}
	}
}
