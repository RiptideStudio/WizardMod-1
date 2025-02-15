using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class PocketFireballProjectile : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		Main.projFrames[Projectile.type] = 6;
	}

	public override void SetDefaults()
	{
		Projectile.width = 6;
		Projectile.height = 6;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 3;
		Projectile.timeLeft = 300;
		Projectile.light = 0.65f;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.alpha = 40;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 127);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust2].velocity *= 3f;
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		if (Main.rand.Next(0, 3) == 1)
		{
			int dust5 = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, 6);
			Main.dust[dust5].velocity = Projectile.velocity * 0.25f;
			Main.dust[dust5].noGravity = true;
			int dust6 = Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height, 127);
			Main.dust[dust6].velocity *= Projectile.velocity * 0.5f;
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
		Projectile.velocity.Y *= 1.01f;
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
		for (int i = 0; i < 7; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 127);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust2].velocity *= 3f;
		}
		target.AddBuff(24, 60);
	}

	public override void OnKill(int timeLeft)
	{
		Player p = Main.player[Projectile.owner];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 12f, Projectile.position.Y + 2f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("FireballDie").Type, 0, 0f, p.whoAmI, 0f, 0f);
	}
}
