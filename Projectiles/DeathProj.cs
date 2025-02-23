using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DeathProj : ModProjectile
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
		Projectile.penetrate = 1;
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 250;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		for (int j = 0; j < 7; j++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
		}
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedX = 5f;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		for (int i = 0; i < 5; i++)
		{
			Vector2 perturbedSpeed = new Vector2(projectilespeedX, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
			projectilespeedX = perturbedSpeed.X;
			projectilespeedY = perturbedSpeed.Y;
			Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, perturbedSpeed, Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		Projectile.position.X += (float)Math.Sin((double)(Projectile.timeLeft / 10)) * 5f;
		Projectile.position.Y += (float)Math.Cos((double)(Projectile.timeLeft / 10)) * 5f;
		if (Main.rand.Next(1) == 0)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 191);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(125, 180) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 109);
			Main.dust[dust2].velocity *= 0.2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(125, 180) * 0.013f;
			Main.dust[dust2].noGravity = true;
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
		float distance = 350f;
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
			Projectile.velocity = (5f * Projectile.velocity + move) / 2f;
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

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
		target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff").Type, 120);
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}
}
