using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class EnergyProjMiddle : ModProjectile
{
	private int time;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 0;
		Projectile.height = 0;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = true;
		Projectile.light = 5f;
		Projectile.ignoreWater = true;
		Projectile.extraUpdates = 1;
		Projectile.tileCollide = false;
		Projectile.timeLeft = 1801;
		DrawOriginOffsetY = -272;
		DrawOriginOffsetX = 0f;
		DrawOffsetX = -272;
		Projectile.scale = 0f;
		Projectile.alpha = 255;
	}

	public override void AI()
	{
		if (Projectile.scale < 1f)
		{
			Projectile.scale += 0.025f;
		}
		if (Projectile.alpha > 120)
		{
			Projectile.alpha -= 3;
		}
		Projectile.rotation -= 0.003f;
		this.time++;
		_ = Main.LocalPlayer;
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Main.rand.Next(-600, 600);
		Main.rand.Next(-288, 288);
		for (int i = 0; i < 200; i++)
		{
			NPC target = Main.npc[i];
			int dist = 296;
			float num = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
			float poisonToY = target.position.Y - Projectile.Center.Y;
			float PoisonDistance = (float)Math.Sqrt((double)(num * num + poisonToY * poisonToY));
			if (!target.friendly && PoisonDistance < (float)dist)
			{
				target.AddBuff(70, 240);
			}
		}
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 50; i++)
		{
			Main.rand.Next(292);
			Main.rand.Next(620);
			Vector2 position = new Vector2(Projectile.position.X - 277f, Projectile.position.Y - 258f);
			Dust.NewDust(position, 544, 544, 75);
			Dust.NewDust(position, 544, 544, 74);
			Dust.NewDust(position, 544, 544, 61);
		}
	}
}
