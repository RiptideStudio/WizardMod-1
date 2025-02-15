using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class RainbowBeam : ModProjectile
{
	private int dust_num = 88;

	private int dust_num2 = 88;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Rainbow Beam");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 3;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 6;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		Vector2 position = new Vector2(Projectile.position.X - Projectile.velocity.X, Projectile.position.Y);
		int dust = Dust.NewDust(position, 0, 0, 87);
		Main.dust[dust].velocity *= 0f;
		Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust].noGravity = true;
		int dust2 = Dust.NewDust(position, 0, 0, 88);
		Main.dust[dust2].velocity *= 0f;
		Main.dust[dust2].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust2].noGravity = true;
		int dust3 = Dust.NewDust(position, 0, 0, 89);
		Main.dust[dust3].velocity *= 0f;
		Main.dust[dust3].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust3].noGravity = true;
		int dust4 = Dust.NewDust(position, 0, 0, 90);
		Main.dust[dust4].velocity *= 0f;
		Main.dust[dust4].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust4].noGravity = true;
		int dust5 = Dust.NewDust(position, 0, 0, 91);
		Main.dust[dust5].velocity *= 0f;
		Main.dust[dust5].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust5].noGravity = true;
		int dust6 = Dust.NewDust(position, 0, 0, 86);
		Main.dust[dust6].velocity *= 0f;
		Main.dust[dust6].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust6].noGravity = true;
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 8; i++)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 0, 0, 87);
			Main.dust[dust].velocity *= 2f;
			Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 0, 0, 88);
			Main.dust[dust2].velocity *= 3f;
			Main.dust[dust2].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust2].noGravity = true;
			int dust3 = Dust.NewDust(position, 0, 0, 89);
			Main.dust[dust3].velocity *= 2f;
			Main.dust[dust3].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust3].noGravity = true;
			int dust4 = Dust.NewDust(position, 0, 0, 90);
			Main.dust[dust4].velocity *= 3f;
			Main.dust[dust4].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust4].noGravity = true;
			int dust5 = Dust.NewDust(position, 0, 0, 91);
			Main.dust[dust5].velocity *= 2f;
			Main.dust[dust5].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust5].noGravity = true;
			int dust6 = Dust.NewDust(position, 0, 0, 86);
			Main.dust[dust6].velocity *= 3f;
			Main.dust[dust6].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust6].noGravity = true;
		}
	}
}
