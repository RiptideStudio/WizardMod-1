using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class FreezeFlameProj2 : ModProjectile
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
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 540;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		DrawOriginOffsetY = -4;
	}

	public override void AI()
	{
		Vector2 move = Vector2.Zero;
		float distance = 600f;
		bool target = false;
		for (int j = 0; j < 200; j++)
		{
			if (Main.npc[j].active && !Main.npc[j].dontTakeDamage && !Main.npc[j].friendly && Main.npc[j].lifeMax > 5)
			{
				Vector2 newMove = Main.npc[j].Center - Projectile.Center;
				float distanceTo = (float)Math.Sqrt((double)(newMove.X * newMove.X + newMove.Y * newMove.Y));
				if (distanceTo < distance)
				{
					move = newMove;
					distance = distanceTo;
					target = true;
				}
			}
		}
		if (target)
		{
			this.AdjustMagnitude(ref move);
			Projectile.velocity = (10f * Projectile.velocity + move) / 5f;
			this.AdjustMagnitude(ref Projectile.velocity);
		}
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 position = Projectile.position;
				int dust = Dust.NewDust(position, 1, 1, 135);
				Main.dust[dust].velocity *= 1f;
				Main.dust[dust].scale = (float)Main.rand.Next(55, 110) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(position, 1, 1, 213);
				Main.dust[dust2].velocity *= 0.8f;
				Main.dust[dust2].scale = (float)Main.rand.Next(85, 120) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
		Projectile.position.X -= (float)Math.Sin((double)(Projectile.timeLeft / 20)) * 0.85f;
		Projectile.position.Y -= (float)Math.Cos((double)(Projectile.timeLeft / 20)) * 0.85f;
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt((double)(vector.X * vector.X + vector.Y * vector.Y));
		if (magnitude > 8.5f)
		{
			vector *= 8.5f / magnitude;
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		for (int i = 0; i < 7; i++)
		{
			Vector2 position = new Vector2(Projectile.position.X - 24f, Projectile.position.Y + 16f);
			Dust.NewDust(position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(position, Projectile.width, Projectile.height, 6);
		}
		target.AddBuff(44, 180);
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 20; i++)
		{
			int xx = Main.rand.Next(16);
			int yy = Main.rand.Next(16);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 55);
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width + 8 + xx, Projectile.height + yy, 135);
			Main.dust[dust3].velocity *= 0.2f;
			Main.dust[dust3].scale = (float)Main.rand.Next(10, 120) * 0.013f;
			Main.dust[dust3].noGravity = true;
			int dust4 = Dust.NewDust(Projectile.position, Projectile.width + 8 + xx, Projectile.height + yy, 135);
			Main.dust[dust4].velocity *= 0.2f;
			Main.dust[dust4].scale = (float)Main.rand.Next(10, 175) * 0.013f;
			Main.dust[dust4].noGravity = true;
			int dust5 = Dust.NewDust(Projectile.position, Projectile.width + 8 + xx, Projectile.height + yy, 213);
			Main.dust[dust5].velocity *= 0.2f;
			Main.dust[dust5].scale = (float)Main.rand.Next(10, 175) * 0.013f;
			Main.dust[dust5].noGravity = true;
		}
	}
}
