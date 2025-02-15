using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class SpiralProj : ModProjectile
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
		Projectile.CloneDefaults(16);
		Projectile.width = 100;
		Projectile.height = 100;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.alpha = 0;
		Projectile.timeLeft = 1200;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 64);
		}
		Player p = Main.player[Projectile.owner];
		Vector2 position = Projectile.Center;
		float projectilespeedX = 5f;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		Vector2 vector = new Vector2(projectilespeedX, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
		projectilespeedX = vector.X;
		projectilespeedY = vector.Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(position.X, position.Y), new Vector2(projectilespeedX, projectilespeedY), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
		return true;
	}

	public override void AI()
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		Projectile.aiStyle = 1;
		if (Projectile.soundDelay == 0 && Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) > 2f)
		{
			Projectile.soundDelay = 10;
			SoundEngine.PlaySound(SoundID.Item103, (Vector2?)Projectile.position);
		}
		Player player = Main.player[Projectile.owner];
		player.noKnockback = true;
		player.position.X = Projectile.position.X + 48f;
		player.position.Y = Projectile.position.Y + 28f;
		player.velocity.X = Projectile.velocity.X * 2f;
		player.velocity.Y = Projectile.velocity.Y * 2f;
		player.AddBuff(10, 3);
		if (player.velocity.X > 0f)
		{
			player.direction = 1;
		}
		if (player.velocity.X < 0f)
		{
			player.direction = -1;
		}
		if (player.statMana <= 0)
		{
			Projectile.Kill();
		}
		player.statMana--;
		if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
		{
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
				Projectile.velocity = vectorToCursor / 3f;
			}
			else
			{
				Projectile.Kill();
			}
		}
		Projectile.aiStyle = 0;
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X, Projectile.position.X), new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, 0f, player.whoAmI, 0f, 0f);
		if (Projectile.timeLeft % 10 == 0)
		{
			Vector2 position = Projectile.Center;
			float projectilespeedX = 5f;
			float projectilespeedY = 5f;
			float projectileknockBack = 3f;
			Vector2 vector = new Vector2(projectilespeedX, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
			projectilespeedX = vector.X;
			projectilespeedY = vector.Y;
			Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(position.X, position.Y), new Vector2(projectilespeedX, projectilespeedY), Mod.Find<ModProjectile>("DeathProj").Type, Projectile.damage, projectileknockBack, player.whoAmI, 0f, 0f);
		}
		if (Main.rand.Next(1) == 0)
		{
			Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + (float)Main.rand.Next(-32, 64), Projectile.position.Y + (float)Main.rand.Next(0, 172)), new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, 0f, player.whoAmI, 0f, 0f);
			for (int i = 0; i < 3; i++)
			{
				int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
				int dust4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
				Main.dust[dust3].velocity *= 1f;
				Main.dust[dust3].scale = (float)Main.rand.Next(125, 250) * 0.013f;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].velocity *= 0.2f;
				Main.dust[dust4].scale = (float)Main.rand.Next(125, 290) * 0.013f;
				Main.dust[dust4].noGravity = true;
			}
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		Main.player[Projectile.owner].noKnockback = true;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(target.position.X, target.position.Y), new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}

	public override void OnKill(int timeLeft)
	{
		_ = Main.player[Projectile.owner];
	}
}
