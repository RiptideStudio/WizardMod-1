using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class RadiationProjectile : ModProjectile
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
		Projectile.width = 24;
		Projectile.height = 24;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 0.1f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.scale = 1f;
		Projectile.alpha = 75;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		for (int i = 0; i < 2; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0);
		}
		return true;
	}

	public override void AI()
	{
		Projectile.alpha++;
		Projectile.aiStyle = 0;
		Projectile.rotation += 0.05f;
		if (Projectile.scale < 1f)
		{
			Projectile.scale += 0.075f;
		}
		Lighting.AddLight(Projectile.position, 0f, 1f, 0f);
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 2; i++)
			{
				_ = Projectile.position;
			}
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(SoundID.Item14, (Vector2?)Projectile.position);
		SoundEngine.PlaySound(SoundID.Item93, (Vector2?)Projectile.position);
		int proj = Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 4f, Projectile.position.Y + 4f), new Vector2(-3f, -2f), Mod.Find<ModProjectile>("RadiationLaser").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
		int proj2 = Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 4f, Projectile.position.Y + 4f), new Vector2(0f, 2f), Mod.Find<ModProjectile>("RadiationLaser").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
		int proj3 = Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 4f, Projectile.position.Y + 4f), new Vector2(3f, -2f), Mod.Find<ModProjectile>("RadiationLaser").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
		Main.projectile[proj].timeLeft = 27;
		Main.projectile[proj2].timeLeft = 34;
		Main.projectile[proj3].timeLeft = 40;
		for (int i = 0; i < 30; i++)
		{
			int xx = Main.rand.Next(64);
			int yy = Main.rand.Next(64);
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width + xx, Projectile.height + yy, 75);
			Dust.NewDust(Projectile.position, Projectile.width + xx, Projectile.height + yy, 107);
			int dust4 = Dust.NewDust(Projectile.position, Projectile.width + xx, Projectile.height + yy, 75);
			Main.dust[dust3].noGravity = true;
			Main.dust[dust3].velocity *= 20f;
			Main.dust[dust4].noGravity = true;
			Main.dust[dust4].velocity *= 16f;
		}
	}
}
