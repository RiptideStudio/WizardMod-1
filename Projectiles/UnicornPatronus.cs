using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class UnicornPatronus : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 6;
	}

	public override void SetDefaults()
	{
		Projectile.width = 54;
		Projectile.height = 104;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 99;
		Projectile.timeLeft = 180;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		Projectile.aiStyle = 0;
		Projectile.alpha = 255;
	}

	public override void AI()
	{
		int constant = 2;
		Projectile.position.X += (float)Math.Sin((double)(Projectile.timeLeft / 15)) * (float)constant;
		Projectile.position.Y += (float)Math.Cos((double)(Projectile.timeLeft / 15)) * (float)constant;
		if (Projectile.alpha > 100)
		{
			Projectile.alpha -= 2;
		}
		if (Projectile.velocity.X > 0f)
		{
			Projectile.direction = 1;
		}
		else
		{
			Projectile.direction = -1;
		}
		Projectile.aiStyle = 0;
		_ = Main.player[Projectile.owner];
		int num370 = Dust.NewDust(new Vector2(Projectile.position.X - 12f, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num370].velocity *= 1f;
		Main.dust[num370].noGravity = true;
		if (++Projectile.frameCounter >= 5)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 6)
			{
				Projectile.frame = 0;
			}
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		Player p = Main.player[Projectile.owner];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 24f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, 0f, p.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Item15, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 5f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 1f;
		}
		for (int i = 0; i < 12; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity.Y *= 1f;
		}
	}
}
