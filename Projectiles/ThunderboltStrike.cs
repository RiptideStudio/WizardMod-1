using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class ThunderboltStrike : ModProjectile
{
	private int time = Main.rand.Next(0, 100);

	private int force = 20;

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
		Projectile.width = 14;
		Projectile.height = 14;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 300;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 6;
		Projectile.position.X += 32f;
		Projectile.position.Y += 24f;
	}

	public override void AI()
	{
		Player player = Main.player[Projectile.owner];
		if (Projectile.position.Y > player.position.Y)
		{
			Projectile.tileCollide = true;
		}
		this.force += Main.rand.Next(0, 1);
		if (Main.rand.Next(0, 4) == 0)
		{
			Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4)), Mod.Find<ModProjectile>("CycloneLightningForked").Type, Projectile.damage / 2, 0f, Main.myPlayer, 0f, 0f);
		}
		this.time++;
		Projectile.position.X += (float)Math.Sin((double)this.time) / 5f * (float)this.force;
		Projectile.position.Y += (float)Math.Cos((double)(this.time / 2)) / 5f * (float)this.force;
		if (Main.rand.Next(1) == 0)
		{
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, 160);
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].scale = (float)Main.rand.Next(180, 265) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, 160);
			Main.dust[dust2].velocity *= 0.7f;
			Main.dust[dust2].scale = (float)Main.rand.Next(180, 265) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt((double)(vector.X * vector.X + vector.Y * vector.Y));
		if (magnitude > 8.5f)
		{
			vector *= 8.5f / magnitude;
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		Player p = Main.player[Projectile.owner];
		SoundEngine.PlaySound(SoundID.Item14, (Vector2?)Projectile.position);
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 24f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, 0f, p.whoAmI, 0f, 0f);
		SoundEngine.PlaySound(SoundID.Item122, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 160, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 8f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 160, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 5f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 160, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 8f;
		}
		for (int i = 0; i < 56; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width - Main.rand.Next(-32, 32), Projectile.height - Main.rand.Next(-32, 32), 160);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity.Y *= 12f;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width - Main.rand.Next(-32, 32), Projectile.height - Main.rand.Next(-32, 32), 160);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity.Y *= 8f;
		}
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
	}
}
