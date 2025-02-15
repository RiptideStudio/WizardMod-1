using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DeathEaterProj : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.friendly = true;
		Projectile.light = 0.8f;
		Projectile.DamageType = DamageClass.Magic;
	}

	public override void AI()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if (Projectile.soundDelay == 0 && Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) > 2f)
		{
			Projectile.soundDelay = 10;
			SoundEngine.PlaySound(SoundID.Item9, (Vector2?)Projectile.position);
		}
		Dust dust = Dust.NewDustPerfect(Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5)), 109, null, 100, Color.Lime, 0.8f);
		dust.velocity *= 0.3f;
		dust.noGravity = true;
		if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
		{
			Player player = Main.player[Projectile.owner];
			if (player.channel)
			{
				float maxDistance = 18f;
				Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
				float distanceToCursor = vectorToCursor.Length();
				if (distanceToCursor > maxDistance)
				{
					distanceToCursor = maxDistance / distanceToCursor;
					vectorToCursor *= distanceToCursor;
				}
				int num = (int)(vectorToCursor.X * 1000f);
				int oldVelocityXBy1000 = (int)(Projectile.velocity.X * 1000f);
				int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
				int oldVelocityYBy1000 = (int)(Projectile.velocity.Y * 1000f);
				if (num != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
				{
					Projectile.netUpdate = true;
				}
				Projectile.velocity = vectorToCursor;
			}
			else if (Projectile.ai[0] == 0f)
			{
				Projectile.netUpdate = true;
				Vector2 vectorToCursor2 = Main.MouseWorld - Projectile.Center;
				float distanceToCursor2 = vectorToCursor2.Length();
				if (distanceToCursor2 == 0f)
				{
					vectorToCursor2 = Projectile.Center - player.Center;
					distanceToCursor2 = vectorToCursor2.Length();
				}
				distanceToCursor2 = 14f / distanceToCursor2;
				vectorToCursor2 *= distanceToCursor2;
				Projectile.velocity = vectorToCursor2;
				if (Projectile.velocity == Vector2.Zero)
				{
					Projectile.Kill();
					Main.projectile[Mod.Find<ModProjectile>("DeathEaterSkullPlayer").Type].timeLeft = 0;
				}
				Projectile.ai[0] = 1f;
			}
		}
		if (Projectile.velocity != Vector2.Zero)
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 4f;
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		if (Projectile.penetrate == 1)
		{
			Projectile.maxPenetrate = -1;
			Projectile.penetrate = -1;
			int explosionArea = 60;
			_ = Projectile.Size;
			Projectile.position = Projectile.Center;
			Projectile.Size += new Vector2(explosionArea);
			Projectile.Center = Projectile.position;
			Projectile.tileCollide = false;
			Projectile.velocity *= 0.01f;
			Projectile.Damage();
			Projectile.scale = 0.01f;
			Projectile.position = Projectile.Center;
			Projectile.Size = new Vector2(10f);
			Projectile.Center = Projectile.position;
		}
		SoundEngine.PlaySound(SoundID.Item10, (Vector2?)Projectile.position);
		for (int i = 0; i < 10; i++)
		{
			Dust dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, 109, 0f, 0f, 100, Color.Lime, 0.8f);
			dust.noGravity = true;
			dust.velocity *= 2f;
			Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, 109, 0f, 0f, 100, Color.Lime, 0.5f);
		}
	}
}
