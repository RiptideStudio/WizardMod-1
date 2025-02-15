using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class GreenGauntletHeld : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 14;
		Projectile.height = 32;
		Projectile.friendly = true;
		Projectile.light = 1.5f;
		Projectile.alpha = 100;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 5;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		Player obj = Main.player[Projectile.owner];
		if (obj.dead)
		{
			Projectile.Kill();
		}
		int num371 = Dust.NewDust(obj.position, 12, 12, 15, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num371].velocity *= 0f;
		Main.dust[num371].noGravity = true;
	}

	public override bool? CanCutTiles()
	{
		return false;
	}

	public override bool MinionContactDamage()
	{
		return false;
	}
}
