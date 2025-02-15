using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DemonWave : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 6;
	}

	public override void SetDefaults()
	{
		Projectile.width = 160;
		Projectile.height = 160;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 99;
		Projectile.timeLeft = 280;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		Projectile.aiStyle = 1;
		Projectile.alpha = 100;
	}

	public override bool PreDraw(ref Color lightColor)
	{
		new Vector2((float)TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, (float)Projectile.height * 0.5f);
		return true;
	}

	public override void AI()
	{
		Projectile.alpha += 4;
		Projectile.rotation += 0.5f;
		int xx = Main.rand.Next(-80, 80);
		int yy = Main.rand.Next(-80, 80);
		Dust.NewDust(Projectile.position, Projectile.width - xx, Projectile.height - yy, 173);
		if (++Projectile.frameCounter >= 5)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 7)
			{
				Projectile.Kill();
			}
		}
		Projectile.velocity.X = 0f;
		Projectile.velocity.Y = 0f;
		Projectile.aiStyle = 0;
		if (Projectile.timeLeft < 120)
		{
			Projectile.alpha += 5;
		}
		if (Projectile.alpha >= 255)
		{
			Projectile.Kill();
		}
	}
}
