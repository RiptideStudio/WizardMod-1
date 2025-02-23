using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Projectiles;

public class HealingOrb4 : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	private int bookPower = 2;

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
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 2;
	}

	public override void AI()
	{
		Player player = Main.LocalPlayer;
		float shootToX = player.position.X + (float)player.width * 0.5f - Projectile.Center.X;
		float shootToY = player.position.Y + 32f - Projectile.Center.Y;
		float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
		if (distance < 16f)
		{
			int healingAmount = this.bookPower + player.GetModPlayer<Global>().spellPower;
			player.statLife += healingAmount;
			player.HealEffect(healingAmount);
			Projectile.Kill();
		}
		distance = 3f / distance;
		shootToX *= distance * 2f;
		shootToY *= distance * 2f;
		Projectile.velocity.X = shootToX;
		Projectile.velocity.Y = shootToY;
		for (int i = 0; i < 12; i++)
		{
			int dust = Dust.NewDust(Projectile.position, 1, 1, 264);
			Main.dust[dust].velocity *= 0f;
			Main.dust[dust].scale = (float)Main.rand.Next(45, 100) * 0.013f;
			Main.dust[dust].noGravity = true;
		}
	}
}
