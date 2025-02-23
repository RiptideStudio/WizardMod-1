using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DeepslateBolt : ModProjectile
{
	private float posY = (float)Main.mouseY + Main.screenPosition.Y;

	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 6;
	}

	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 1f;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		Projectile.alpha = 40;
		int num = Main.rand.Next(0, 7);
		if (num == 1)
		{
			Projectile.scale = 0.5f;
		}
		if (num == 2)
		{
			Projectile.scale = 0.8f;
		}
		if (num == 3)
		{
			Projectile.scale = 0.6f;
		}
		if (num == 4)
		{
			Projectile.scale = 1f;
		}
		if (num == 5)
		{
			Projectile.scale = 1.2f;
		}
		if (num == 6)
		{
			Projectile.scale = 1.4f;
		}
		Projectile.damage = (int)((float)Projectile.damage * Projectile.scale);
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust2].velocity *= 3f;
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		if (Projectile.position.Y > this.posY)
		{
			Projectile.tileCollide = true;
		}
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.aiStyle = 0;
		if (Main.rand.Next(0, 3) == 1)
		{
			int dust5 = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, 6);
			Main.dust[dust5].velocity *= 0.25f;
			Main.dust[dust5].noGravity = true;
			int dust6 = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, 109);
			Main.dust[dust6].velocity *= 0.5f;
			Main.dust[dust6].noGravity = true;
		}
		if (++Projectile.frameCounter >= 9)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 6)
			{
				Projectile.frame = 0;
			}
		}
		else
		{
			Projectile.aiStyle = 0;
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		for (int i = 0; i < 7; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 109);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust2].velocity *= 3f;
		}
		target.AddBuff(24, 60);
	}

	public override void OnKill(int timeLeft)
	{
		_ = Main.player[Projectile.owner];
	}
}
