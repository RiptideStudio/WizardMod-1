using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class LightningProj : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 4;
		Projectile.arrow = false;
		Projectile.height = 4;
		Projectile.aiStyle = 3;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 999;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		Projectile.CloneDefaults(443);
		Main.projFrames[Projectile.type] = 4;
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.timeLeft = 30;
		Projectile.arrow = false;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Magic;
	}

	public override void AI()
	{
		Player p = Main.player[Projectile.owner];
		if (Projectile.timeLeft % 5 == 0)
		{
			Main.rand.Next(3);
			_ = Vector2.Normalize(new Vector2(7f, 7f)) * 45f;
			MathHelper.ToRadians(360f);
			Vector2 perturbedSpeed = new Vector2(6f, 6f).RotatedByRandom(MathHelper.ToRadians(360f));
			Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 32f, Projectile.position.Y + 16f), new Vector2(perturbedSpeed.X / 10f, perturbedSpeed.Y / 10f), Mod.Find<ModProjectile>("StormSenderProj").Type, 9, 1f, p.whoAmI, 0f, 0f);
		}
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Projectile.rotation = 0f;
		if (Projectile.timeLeft % 120 == 0)
		{
			float num = p.position.X + (float)p.width * 0.5f - Projectile.Center.X;
			float shootToY = p.position.Y - Projectile.Center.Y;
			Math.Sqrt((double)(num * num + shootToY * shootToY));
		}
		Main.rand.Next(24);
		Main.rand.Next(24);
		for (int i = 0; i < 200; i++)
		{
			NPC target = Main.npc[i];
			float num2 = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
			float poisonToY = target.position.Y - Projectile.Center.Y;
			Math.Sqrt((double)(num2 * num2 + poisonToY * poisonToY));
		}
	}
}
