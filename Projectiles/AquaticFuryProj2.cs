using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class AquaticFuryProj2 : ModProjectile
{
	private bool up = true;

	private bool down;

	private int dust_num = 162;

	private int dust_num2 = 6;

	private int time = -1;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Water blast");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		Main.projFrames[Projectile.type] = 3;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 200;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 5;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 5; i++)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 56);
			Main.dust[dust].velocity *= 1f;
			Main.dust[dust].scale = (float)Main.rand.Next(35, 125) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 67);
			Main.dust[dust2].velocity *= 1.2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(35, 90) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		if (++Projectile.frameCounter >= 7)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame > 2)
			{
				Projectile.frame = 0;
			}
		}
		if (Main.rand.Next(1) == 0)
		{
			Vector2 position = new Vector2(Projectile.position.X + 17f + Projectile.velocity.X * 3f, Projectile.position.Y + Projectile.velocity.Y * 3f);
			int dust2 = Dust.NewDust(position, 1, 1, 56);
			Main.dust[dust2].velocity *= 0.1f;
			Main.dust[dust2].scale = (float)Main.rand.Next(85, 125) * 0.013f;
			Main.dust[dust2].noGravity = true;
			int dust = Dust.NewDust(position, 1, 1, 211);
			Main.dust[dust].velocity *= 0f;
			Main.dust[dust].scale = (float)Main.rand.Next(85, 125) * 0.013f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].color = new Color(0, 0, 255);
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		Player player = Main.player[Main.myPlayer];
		Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y - 16f), new Vector2(1f, -5f), Mod.Find<ModProjectile>("WaterExplosion").Type, 0, 0f, player.whoAmI, 0f, 0f);
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 6; i++)
		{
			Vector2 position = new Vector2(Projectile.position.X, Projectile.position.Y);
			Vector2 pos = new Vector2(Projectile.position.X, Projectile.position.Y);
			_ = Projectile.position;
			_ = Projectile.position;
			int dust2 = Dust.NewDust(position, 1, 1, 175);
			Main.dust[dust2].velocity *= 2f;
			Main.dust[dust2].scale = (float)Main.rand.Next(95, 145) * 0.013f;
			Main.dust[dust2].noGravity = true;
			int dust3 = Dust.NewDust(position, 1, 1, 56);
			Main.dust[dust3].velocity *= 2f;
			Main.dust[dust3].scale = (float)Main.rand.Next(85, 125) * 0.013f;
			Main.dust[dust3].noGravity = true;
			int dust = Dust.NewDust(pos, 1, 1, 211);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust].scale = (float)Main.rand.Next(85, 125) * 0.013f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].color = new Color(0, 0, 255);
		}
		Player player = Main.player[Main.myPlayer];
		Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y - 16f), new Vector2(1f, -5f), Mod.Find<ModProjectile>("WaterExplosion").Type, 0, 0f, player.whoAmI, 0f, 0f);
		int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y - 16f), new Vector2(0f, 0f), 384, Projectile.damage, 0f, player.whoAmI, 0f, 0f);
		Main.projectile[proj].friendly = true;
		Main.projectile[proj].hostile = false;
		Main.projectile[proj].timeLeft = 120;
	}
}
