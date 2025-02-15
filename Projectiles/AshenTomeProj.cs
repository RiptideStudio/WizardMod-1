using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class AshenTomeProj : ModProjectile
{
	private float posY = (float)Main.mouseY + Main.screenPosition.Y;

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
		Projectile.width = 32;
		Projectile.height = 32;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 1.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		Lighting.AddLight(Projectile.position, 0.75f, 0.05f, 0.1f);
		if (Projectile.position.Y > this.posY)
		{
			Projectile.tileCollide = true;
		}
		if (Projectile.timeLeft < 570)
		{
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			Main.dust[dust3].velocity *= 0.2f;
			Main.dust[dust3].noGravity = true;
		}
		else
		{
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			Main.dust[dust2].velocity *= 0.2f;
			Main.dust[dust2].noGravity = true;
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(24, 120);
		target.AddBuff(Mod.Find<ModBuff>("DeepslateBuff").Type, 120);
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/FireImpact").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)Projectile.position);
		Player p = Main.player[Projectile.owner];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X - 2f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("ExplosionLarge").Type, 0, 0f, p.whoAmI, 0f, 0f);
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 24f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, 0f, p.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Item14, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 87, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity = Projectile.velocity;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 5f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity = Projectile.velocity;
		}
		for (int i = 0; i < 12; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 87);
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity = Projectile.velocity;
		}
	}
}
