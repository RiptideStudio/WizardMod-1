using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class RelicRockSmash : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 3;
	}

	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 5;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		DrawOriginOffsetY = -8;
		Projectile.frame = Main.rand.Next(0, 3);
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Projectile.velocity.Y = 0f;
		Projectile.velocity.X = 0f;
		return false;
	}

	public override void AI()
	{
		Projectile.scale -= 0.001f;
		if (Main.rand.Next(1, 5) == 2)
		{
			int dusty = Dust.NewDust(Projectile.position + new Vector2(8f, -14f), Projectile.width, Projectile.height, 32);
			Main.dust[dusty].velocity.Y *= 2f;
			Main.dust[dusty].velocity.X *= 0.2f;
			Main.dust[dusty].noGravity = true;
		}
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.rotation += 0.035f;
	}

	public override void OnKill(int timeLeft)
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.player[Main.myPlayer];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 24f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, 0f, player.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Item14, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 12; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 85, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 5; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 85, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 3f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 268, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 2f;
		}
		for (int i = 0; i < 6; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 268);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 85);
			Main.dust[dust2].velocity.Y *= 2f;
		}
	}
}
