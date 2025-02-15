using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class FreezeFlameProj : ModProjectile
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
		Projectile.extraUpdates = 1;
	}

	public override void AI()
	{
		Projectile.position.Y += (float)Math.Sin((double)(Projectile.timeLeft / 30));
		int constant = 5;
		float posX = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)constant;
		float posY = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)constant;
		Vector2 pos = new Vector2(posX, posY);
		float posX2 = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		float posY2 = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		Vector2 pos2 = new Vector2(posX2, posY2);
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 2; i++)
			{
				_ = Projectile.position;
				int dust = Dust.NewDust(pos, 1, 1, 135);
				Main.dust[dust].velocity *= 1.4f;
				Main.dust[dust].scale = (float)Main.rand.Next(125, 165) * 0.013f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].rotation = Main.rand.Next(0, 360);
				int dust3 = Dust.NewDust(pos, 1, 1, 158);
				Main.dust[dust3].velocity *= 1.2f;
				Main.dust[dust3].scale = (float)Main.rand.Next(85, 135) * 0.013f;
				Main.dust[dust3].noGravity = true;
				int dust2 = Dust.NewDust(pos2, 1, 1, 6);
				Main.dust[dust2].velocity *= 1.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(125, 165) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		target.AddBuff(44, 180);
		target.AddBuff(24, 180);
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}
}
