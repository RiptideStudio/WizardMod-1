using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Spells;

public class GreatManaLinger : ModProjectile
{
	private int splashAmount = 55;

	private int lingerAmount = 8;

	private int multiplier = 2;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 24;
		Projectile.height = 24;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = -1;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.scale = 1f;
		Projectile.extraUpdates = 1;
		Projectile.width = 60;
		Projectile.height = 60;
		Projectile.timeLeft = 722;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Player p = Main.LocalPlayer;
		double rad = (double)Projectile.ai[1] * 2.0 * (Math.PI / 180.0);
		double dist3 = 2.0;
		Projectile.position.X = Projectile.Center.X - (float)(int)(Math.Cos(rad) * dist3) - (float)(Projectile.width / 2);
		Projectile.position.Y = Projectile.Center.Y - (float)(int)(Math.Sin(rad) * dist3) - (float)(Projectile.height / 2);
		Projectile.ai[1] += 1f;
		int dist2 = 160;
		float num = p.position.X - 96f + (float)p.width * 0.5f - Projectile.Center.X;
		float shootToY2 = p.position.Y - 48f - Projectile.Center.Y;
		float distance2 = (float)Math.Sqrt((double)(num * num + shootToY2 * shootToY2));
		if (Projectile.timeLeft == 722 && distance2 < (float)dist2)
		{
			int healingAmount2 = this.splashAmount + p.GetModPlayer<Global>().spellPower * this.multiplier;
			p.statMana += healingAmount2;
			p.ManaEffect(healingAmount2);
		}
		if (Projectile.timeLeft % 60 == 0)
		{
			int dist = 192;
			float num2 = p.position.X - 96f + (float)p.width * 0.5f - Projectile.Center.X;
			float shootToY = p.position.Y - 48f - Projectile.Center.Y;
			if ((float)Math.Sqrt((double)(num2 * num2 + shootToY * shootToY)) < (float)dist)
			{
				int healingAmount = this.lingerAmount + p.GetModPlayer<Global>().spellPower / 2;
				p.statMana += healingAmount;
				p.ManaEffect(healingAmount);
			}
		}
		int xx = Main.rand.Next(216);
		int yy = Main.rand.Next(128);
		int dust3 = Dust.NewDust(Projectile.position, Projectile.width + 96 + xx, Projectile.height + yy, 16);
		Main.dust[dust3].noGravity = true;
		Main.dust[dust3].velocity *= 0f;
		Main.dust[dust3].scale *= 1.5f;
		int dust4 = Dust.NewDust(Projectile.position, Projectile.width + 96 + xx, Projectile.height + yy, 15);
		Main.dust[dust4].velocity *= 0f;
		int dust5 = Dust.NewDust(Projectile.position, Projectile.width + 96 + xx, Projectile.height + yy, 41);
		Main.dust[dust5].noGravity = true;
		Main.dust[dust5].velocity *= 0f;
	}
}
