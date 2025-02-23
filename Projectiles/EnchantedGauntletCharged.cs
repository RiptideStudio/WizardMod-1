using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class EnchantedGauntletCharged : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 3;
	}

	public override void SetDefaults()
	{
		Projectile.width = 8;
		Projectile.height = 8;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = 4;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.aiStyle = 1;
		Projectile.timeLeft = 300;
		DrawOffsetX = -9;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		int constant = 5;
		float posX = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)constant;
		float posY = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)constant;
		new Vector2(posX, posY);
		float posX2 = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		float posY2 = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		new Vector2(posX2, posY2);
		Projectile.width = 14;
		Projectile.height = 14;
		_ = Main.player[Projectile.owner];
		Projectile.scale = 1.2f;
		Projectile.alpha = 0;
		if (++Projectile.frameCounter >= 7)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame > 2)
			{
				Projectile.frame = 0;
			}
		}
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 1; i++)
			{
				Vector2 position = new Vector2(Projectile.position.X - Projectile.velocity.X, Projectile.position.Y - Projectile.velocity.Y);
				Main.rand.Next(-24, 24);
				int dust2 = Dust.NewDust(position, 3, 3, 20);
				Main.dust[dust2].velocity *= 0f;
				Main.dust[dust2].scale = (float)Main.rand.Next(25, 125) * 0.013f;
				Main.dust[dust2].noGravity = true;
				int dust3 = Dust.NewDust(position, 3, 3, 112);
				Main.dust[dust3].velocity *= 0f;
				Main.dust[dust3].scale = (float)Main.rand.Next(25, 125) * 0.013f;
				Main.dust[dust3].noGravity = true;
			}
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		Player p = Main.player[Projectile.owner];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 24f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, 0f, p.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Item14, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 112, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
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
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 112);
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity.Y *= 2f;
		}
	}
}
