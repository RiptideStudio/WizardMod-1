using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class WeeperProj : ModProjectile
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
		Projectile.width = 20;
		Projectile.height = 12;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 3;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 64);
		}
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		Vector2 perturbedSpeed = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
		projectilespeedY = perturbedSpeed.Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, perturbedSpeed, Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
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
				int dust = Dust.NewDust(pos, 1, 1, 87);
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = (float)Main.rand.Next(125, 165) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(pos2, 1, 1, 109);
				Main.dust[dust2].velocity *= 0.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(145, 215) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		if (target.HasBuff(Mod.Find<ModBuff>("DarknessDebuff_2").Type))
		{
			target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff_3").Type, 120);
		}
		else if (target.HasBuff(Mod.Find<ModBuff>("DarknessDebuff").Type))
		{
			target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff_2").Type, 120);
		}
		target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff").Type, 120);
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}
}
