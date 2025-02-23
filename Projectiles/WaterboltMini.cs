using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class WaterboltMini : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Water blast");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 200;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.alpha = 150;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		SoundEngine.PlaySound(SoundID.Item10, (Vector2?)Projectile.position);
		if (Projectile.velocity.X != oldVelocity.X)
		{
			Projectile.velocity.X = (0f - oldVelocity.X) / 2f;
		}
		if (Projectile.velocity.Y != oldVelocity.Y)
		{
			Projectile.velocity.Y = 0f - oldVelocity.Y;
		}
		for (int i = 0; i < 5; i++)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 56);
			Main.dust[dust].velocity *= 1f;
			Main.dust[dust].scale = (float)Main.rand.Next(35, 100) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 67);
			Main.dust[dust2].velocity *= 1.2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(35, 75) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
		return true;
	}

	public override void AI()
	{
		int constant = 2;
		float posX = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)constant;
		float posY = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)constant;
		Vector2 pos = new Vector2(posX, posY);
		float posX2 = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		float posY2 = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		Vector2 pos2 = new Vector2(posX2, posY2);
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 3; i++)
			{
				_ = Projectile.position;
				_ = Projectile.position;
				int dust2 = Dust.NewDust(pos2, 1, 1, 175);
				Main.dust[dust2].velocity *= 0f;
				Main.dust[dust2].scale = (float)Main.rand.Next(40, 75) * 0.013f;
				Main.dust[dust2].noGravity = true;
				int dust3 = Dust.NewDust(pos2, 1, 1, 56);
				Main.dust[dust3].velocity *= 0f;
				Main.dust[dust3].scale = (float)Main.rand.Next(25, 55) * 0.013f;
				Main.dust[dust3].noGravity = true;
				int dust = Dust.NewDust(pos, 1, 1, 56);
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].scale = (float)Main.rand.Next(25, 60) * 0.013f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
