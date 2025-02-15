using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Projectiles;

public class SuperNova : ModProjectile
{
	private int increase = 256;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 48;
		Projectile.height = 36;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = false;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 100;
		Projectile.light = 2f;
		Projectile.ignoreWater = true;
		DrawOffsetX = -256;
		DrawOriginOffsetY = -256;
		Projectile.tileCollide = false;
		Projectile.scale = 1f;
	}

	public override void AI()
	{
		_ = Main.player[Projectile.owner];
		this.increase -= 3;
		if (this.increase < 0)
		{
			this.increase = 0;
		}
		int xx = Main.rand.Next(-this.increase, this.increase);
		int yy = Main.rand.Next(-this.increase, this.increase);
		for (int num370 = 0; num370 < 118; num370++)
		{
			int num371 = Dust.NewDust(new Vector2(Projectile.position.X + (float)xx, Projectile.position.Y + (float)yy), 32, 32, 169, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num371].velocity *= 1.4f;
			Main.dust[num371].noGravity = true;
		}
		for (int num369 = 0; num369 < 118; num369++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X + (float)xx, Projectile.position.Y + (float)yy), 32, 32, 159, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 2f;
			Main.dust[num372].noGravity = true;
		}
		if (Projectile.scale > 0f)
		{
			Projectile.scale -= 0.0125f;
		}
		else
		{
			Projectile.scale = 0f;
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		for (int num369 = 0; num369 < 118; num369++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X + 32f, Projectile.position.Y + 32f), 32, 32, 169, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 6f;
			Main.dust[num372].noGravity = true;
		}
		for (int num370 = 0; num370 < 118; num370++)
		{
			int num375 = Dust.NewDust(new Vector2(Projectile.position.X + 32f, Projectile.position.Y + 32f), 32, 32, 159, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num375].velocity *= 8f;
			Main.dust[num375].noGravity = true;
		}
		this.increase = 256;
		int xx = Main.rand.Next(-this.increase, this.increase);
		int yy = Main.rand.Next(-this.increase, this.increase);
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/LargeExplosion").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)Projectile.position);
		Player p = Main.player[Projectile.owner];
		p.GetModPlayer<Global>().screenShake = true;
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0f, 0f), Mod.Find<ModProjectile>("SuperExplosion").Type, Projectile.damage * 3, 0f, p.whoAmI, 0f, 0f);
		for (int num371 = 0; num371 < 125; num371++)
		{
			xx = Main.rand.Next(-192, 192);
			yy = Main.rand.Next(-192, 192);
			int num373 = Dust.NewDust(new Vector2(Projectile.position.X + (float)xx, Projectile.position.Y + (float)yy), Projectile.width, Projectile.height, 169, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num373].velocity *= 1.4f;
			Main.dust[num373].noGravity = true;
		}
		for (int num374 = 0; num374 < 125; num374++)
		{
			xx = Main.rand.Next(-192, 192);
			yy = Main.rand.Next(-192, 192);
			int num376 = Dust.NewDust(new Vector2(Projectile.position.X + (float)xx, Projectile.position.Y + (float)yy), Projectile.width, Projectile.height, 159, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num376].noGravity = true;
			Main.dust[num376].velocity *= 7f;
			num376 = Dust.NewDust(new Vector2(Projectile.position.X + (float)xx, Projectile.position.Y + (float)yy), Projectile.width, Projectile.height, 159, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num376].velocity *= 9f;
		}
	}
}
