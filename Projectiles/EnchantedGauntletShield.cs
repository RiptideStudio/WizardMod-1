using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class EnchantedGauntletShield : ModProjectile
{
	private int timeLeft;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
	}

	public override void SetDefaults()
	{
		Projectile.width = 20;
		Projectile.height = 20;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.hostile = false;
		Projectile.friendly = true;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 2;
		Projectile.tileCollide = false;
	}

	public override void AI()
	{
		this.timeLeft = 20;
		for (int i = 0; i < 8; i++)
		{
			Vector2 position = Projectile.position;
			int posX = Main.rand.Next(-this.timeLeft, this.timeLeft);
			int posY = Main.rand.Next(-this.timeLeft, this.timeLeft);
			int dust2 = Dust.NewDust(position, Projectile.width + posX, Projectile.height + posY, 15);
			Main.dust[dust2].velocity *= 0.5f;
			Main.dust[dust2].scale = (float)Main.rand.Next(60, 115 + this.timeLeft) * 0.013f;
			Main.dust[dust2].noGravity = true;
			int dust3 = Dust.NewDust(position, Projectile.width + posX, Projectile.height + posY, 112);
			Main.dust[dust3].velocity *= 2f;
			Main.dust[dust3].scale = (float)Main.rand.Next(60, 115 + this.timeLeft) * 0.013f;
			Main.dust[dust3].noGravity = true;
		}
	}
}
