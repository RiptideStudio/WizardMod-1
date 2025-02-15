using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class MasterProj : ModProjectile
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
		Projectile.penetrate = 3;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedX = 5f;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		Vector2 vector = new Vector2(projectilespeedX, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
		projectilespeedX = vector.X;
		projectilespeedY = vector.Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(projectilespeedX, projectilespeedY), Mod.Find<ModProjectile>("LightExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 64);
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
				Main.dust[dust].scale = (float)Main.rand.Next(125, 180) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(position, 1, 1, 64);
				Main.dust[dust2].velocity *= 0.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(125, 180) * 0.013f;
				Main.dust[dust2].noGravity = true;
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
		float distance = 150f;
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
			Projectile.velocity = (30f * Projectile.velocity + move) / 2f;
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
		target.AddBuff(Mod.Find<ModBuff>("LightDebuff2").Type, 180);
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("LightExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}
}
