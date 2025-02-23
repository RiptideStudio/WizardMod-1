using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class AurorProj : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 24;
		Projectile.height = 24;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 999;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.extraUpdates = 1;
		Projectile.timeLeft = 1560;
		Projectile.tileCollide = false;
		Projectile.arrow = false;
		Projectile.DamageType = DamageClass.Magic;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Player p = Main.player[Projectile.owner];
		Projectile.position.X = p.position.X;
		Projectile.position.Y = p.position.Y;
		return false;
	}

	public override void AI()
	{
		Player p = Main.player[Projectile.owner];
		Projectile.position.X = p.position.X - 32f;
		Projectile.position.Y = p.position.Y - 16f;
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Projectile.position.X = p.position.X - 32f;
		Projectile.position.Y = p.position.Y - 16f;
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Projectile.scale += (float)Math.Sin((double)(Projectile.timeLeft / 15)) / 150f;
		Projectile.alpha += (int)Math.Sin((double)Projectile.timeLeft);
		_ = Main.player[Projectile.owner];
		for (int i = 0; i < 100; i++)
		{
			NPC target = Main.npc[i];
			float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
			float shootToY = target.position.Y + 8f - Projectile.Center.Y;
			float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
			if (distance < 480f && !target.friendly && target.active && Projectile.timeLeft % 120 == 0)
			{
				distance = 3f / distance;
				shootToX *= distance * 5f;
				shootToY *= distance * 5f;
				Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 16f, Projectile.position.Y + 16f), new Vector2(shootToX, shootToY), Mod.Find<ModProjectile>("LightningDirection").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
			}
		}
	}
}
