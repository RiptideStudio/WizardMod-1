using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class IceBoltProj : ModProjectile
{
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
		Projectile.height = 8;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 2;
		Projectile.timeLeft = 300;
		Projectile.light = 0.65f;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.alpha = 0;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 135);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 111);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust2].velocity *= 0.5f;
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		if (Main.rand.Next(0, 3) == 1)
		{
			int dust5 = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, 135);
			Main.dust[dust5].velocity *= 0.25f;
			Main.dust[dust5].noGravity = true;
			int dust6 = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, 111);
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
		if (Projectile.timeLeft < 275)
		{
			Projectile.aiStyle = 1;
		}
		else
		{
			Projectile.aiStyle = 0;
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 135);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 111);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust2].velocity *= 0.5f;
		}
		target.AddBuff(44, 120);
		if (Main.rand.Next(0, 4) == 1 && target.lifeMax <= 250)
		{
			SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/IceBreak").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
			SoundEngine.PlaySound(soundStyle, (Vector2?)Projectile.position);
			target.AddBuff(Mod.Find<ModBuff>("SlowBuff").Type, 120);
		}
	}

	public override void OnKill(int timeLeft)
	{
		Player p = Main.player[Projectile.owner];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 12f, Projectile.position.Y + 2f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("FireballDieIce").Type, 0, 0f, p.whoAmI, 0f, 0f);
	}
}
