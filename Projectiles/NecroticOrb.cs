using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class NecroticOrb : ModProjectile
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
		Projectile.width = 22;
		Projectile.height = 14;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 5;
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 800;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		Projectile.penetrate--;
		if (Projectile.penetrate <= 0)
		{
			Projectile.Kill();
		}
		else
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundStyle soundStyle = SoundID.Item10.WithVolumeScale(0.8f).WithPitchOffset(0.5f);
			SoundEngine.PlaySound(soundStyle, (Vector2?)Projectile.position);
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = (0f - oldVelocity.X) / 3f;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = 0f - oldVelocity.Y;
			}
		}
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 160);
		}
		Player p = Main.player[Projectile.owner];
		Vector2 position = Projectile.Center;
		float projectilespeedX = 5f;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		Vector2 vector = new Vector2(projectilespeedX, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
		projectilespeedX = vector.X;
		projectilespeedY = vector.Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(position.X, position.Y), new Vector2(projectilespeedX, projectilespeedY), Mod.Find<ModProjectile>("NecroticExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return false;
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
				int dust = Dust.NewDust(pos, 1, 1, 160);
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = (float)Main.rand.Next(125, 216) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(pos2, 1, 1, 109);
				Main.dust[dust2].velocity *= 0.2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(145, 215) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff").Type, 120);
		if (target.type != 488)
		{
			int healingAmount = damage / 25;
			if (healingAmount > 3)
			{
				healingAmount = 3;
			}
			p.statLife += healingAmount;
			p.HealEffect(healingAmount);
		}
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("NecroticExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}
}
