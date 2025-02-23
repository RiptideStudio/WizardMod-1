using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Spells;

public class GreatManaSpellProj : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 24;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		DrawOffsetX = -12;
		DrawOriginOffsetY = -12;
	}

	public override void AI()
	{
		Projectile.rotation += 0.04f;
		if (Projectile.timeLeft < 580)
		{
			Projectile.velocity.Y += 0.1f;
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(SoundID.Item27, (Vector2?)Projectile.position);
		Player p = Main.player[Projectile.owner];
		Projectile.NewProjectile(p.GetSource_ReleaseEntity(), Projectile.position, Projectile.velocity, Mod.Find<ModProjectile>("GreatManaLinger").Type, 0, 0f, p.whoAmI, 0f, 0f);
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 16, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 16, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 3f;
			Main.dust[num372].color = Color.Cyan;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 2f;
		}
		for (int i = 0; i < 12; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 16);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].color = Color.Cyan;
			Main.dust[dust].velocity *= 8f;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity.Y *= 8f;
		}
	}
}
