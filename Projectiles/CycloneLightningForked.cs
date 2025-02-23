using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class CycloneLightningForked : ModProjectile
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
		Projectile.width = 4;
		Projectile.height = 4;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 25;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 6;
		Projectile.position.X += 32f;
		Projectile.position.Y += 24f;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		if (Projectile.velocity.X != oldVelocity.X)
		{
			Projectile.velocity.X = (0f - oldVelocity.X) / 2f;
		}
		if (Projectile.velocity.Y != oldVelocity.Y)
		{
			Projectile.velocity.Y = 0f - oldVelocity.Y;
		}
		return false;
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		_ = Main.player[Projectile.owner];
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4)), Mod.Find<ModProjectile>("ThunderStaffProj").Type, Projectile.damage / 2, 0f, Main.myPlayer, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Item93, (Vector2?)Projectile.position);
	}

	public override void AI()
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
		float distance = 100f;
		bool target = false;
		for (int i = 0; i < 200; i++)
		{
			if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].lifeMax > 5)
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
			Projectile.velocity = (10f * Projectile.velocity + move) / 8f;
			this.AdjustMagnitude(ref Projectile.velocity);
		}
		Projectile.position.X += (float)Math.Sin((double)Projectile.timeLeft) / 5f * 20f;
		Projectile.position.Y += (float)Math.Cos((double)(Projectile.timeLeft / 2)) / 5f * 20f;
		if (Main.rand.Next(1) == 0)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 160);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(64, 98) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 160);
			Main.dust[dust2].velocity *= 0.2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(64, 98) * 0.013f;
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

	public override void OnKill(int timeLeft)
	{
	}
}
