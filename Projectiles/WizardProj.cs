using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class WizardProj : ModProjectile
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
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 5;
		Projectile.timeLeft = 600;
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
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 27);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
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
				int dust = Dust.NewDust(position, 1, 1, 27);
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = (float)Main.rand.Next(125, 255) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(position, 1, 1, 15);
				Main.dust[dust2].velocity *= 0.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(125, 255) * 0.013f;
				Main.dust[dust2].noGravity = true;
				int dust3 = Dust.NewDust(position, 1, 1, 112);
				Main.dust[dust3].velocity *= 0.2f;
				Main.dust[dust3].scale = (float)Main.rand.Next(125, 255) * 0.013f;
				Main.dust[dust3].noGravity = true;
			}
		}
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
		float distance = 300f;
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
			Projectile.velocity = (25f * Projectile.velocity + move) / 2f;
			this.AdjustMagnitude(ref Projectile.velocity);
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
		target.AddBuff(Mod.Find<ModBuff>("LightDebuff4").Type, 180);
	}
}
