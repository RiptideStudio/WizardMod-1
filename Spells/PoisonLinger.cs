using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Spells;

public class PoisonLinger : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 460;
		Projectile.height = 160;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = -1;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.scale = 1f;
		Projectile.extraUpdates = 1;
		Projectile.timeLeft = 722;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		for (int i = 0; i < 1; i++)
		{
			Player p = Main.LocalPlayer;
			double rad = (double)Projectile.ai[1] * 2.0 * (Math.PI / 180.0);
			double dist3 = 2.0;
			Projectile.position.X = Projectile.Center.X - (float)(int)(Math.Cos(rad) * dist3) - (float)(Projectile.width / 2);
			Projectile.position.Y = Projectile.Center.Y - (float)(int)(Math.Sin(rad) * dist3) - (float)(Projectile.height / 2);
			Projectile.ai[1] += 1f;
			float num = p.position.X - 96f + (float)p.width * 0.5f - Projectile.Center.X;
			float shootToY2 = p.position.Y - 48f - Projectile.Center.Y;
			Math.Sqrt((double)(num * num + shootToY2 * shootToY2));
			if (Projectile.timeLeft % 60 == 0)
			{
				float num2 = p.position.X - 96f + (float)p.width * 0.5f - Projectile.Center.X;
				float shootToY = p.position.Y - 48f - Projectile.Center.Y;
				Math.Sqrt((double)(num2 * num2 + shootToY * shootToY));
			}
		}
		int xx = Main.rand.Next(216);
		int yy = Main.rand.Next(128);
		int dust3 = Dust.NewDust(Projectile.position, Projectile.width / 2 + 96 + xx, Projectile.height + yy, 44);
		Main.dust[dust3].noGravity = true;
		Main.dust[dust3].velocity *= 1.25f;
		Main.dust[dust3].scale *= 1.5f;
		int dust4 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width / 2 + 96 + xx, Projectile.height + yy, 74, 0f, 0f, 100, Color.Green, 1.5f);
		Main.dust[dust4].velocity *= 1.25f;
		Main.dust[dust4].noGravity = true;
		int dust5 = Dust.NewDust(Projectile.position, Projectile.width / 2 + 96 + xx, Projectile.height + yy, 188);
		Main.dust[dust5].noGravity = true;
	}
}
