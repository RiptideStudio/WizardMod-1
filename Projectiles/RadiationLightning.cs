using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class RadiationLightning : ModProjectile
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
		Projectile.width = 32;
		Projectile.height = 32;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = false;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 140;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
	}

	public override void AI()
	{
		if (Projectile.timeLeft < 110)
		{
			Projectile.friendly = true;
			if (Projectile.alpha > 70)
			{
				Projectile.alpha -= 15;
				if (Projectile.alpha < 70)
				{
					Projectile.alpha = 70;
				}
			}
			if (Projectile.localAI[0] == 0f)
			{
				this.AdjustMagnitude(ref Projectile.velocity);
				Projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 480f;
			bool target = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].lifeMax > 1)
				{
					Vector2 newMove = Main.npc[i].Center - Projectile.Center;
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
				Projectile.velocity = (10f * Projectile.velocity + move) / 11f;
				this.AdjustMagnitude(ref Projectile.velocity);
			}
		}
		Projectile.position.X += (float)Math.Sin((double)(Projectile.timeLeft / 2)) / 4f * 7f;
		Projectile.position.Y += (float)Math.Cos((double)(Projectile.timeLeft / 2)) / 4f * 7f;
		if (Main.rand.Next(1) == 0)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 107);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(35, 75) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 75);
			Main.dust[dust2].velocity *= 0.2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(35, 75) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
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
		target.AddBuff(Mod.Find<ModBuff>("RadiationDebuff").Type, 180);
		_ = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		_ = Main.player[Projectile.owner];
		SoundEngine.PlaySound(SoundID.Item93, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 8; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 107, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 5; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 75, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 5f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 75, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 4f;
		}
		for (int i = 0; i < 3; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 107);
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 75);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity.Y *= 6f;
		}
	}
}
