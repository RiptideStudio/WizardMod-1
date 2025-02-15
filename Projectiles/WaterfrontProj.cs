using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class WaterfrontProj : ModProjectile
{
	private bool up = true;

	private bool down;

	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Water blast");
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
		Projectile.penetrate = 10;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.alpha = 150;
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
		int constant = 3;
		float posX = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)constant;
		float posY = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)constant;
		Vector2 pos = new Vector2(posX, posY);
		float posX2 = Projectile.position.X + (float)Math.Sin((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		float posY2 = Projectile.position.Y + (float)Math.Cos((double)(Projectile.timeLeft / 10)) * (float)(-constant);
		Vector2 pos2 = new Vector2(posX2, posY2);
		Projectile.aiStyle = 21;
		AIType = 27;
		if (Main.rand.Next(1) == 0)
		{
			_ = Projectile.position;
			_ = Projectile.position;
			int dust2 = Dust.NewDust(pos2, 1, 1, 175);
			Main.dust[dust2].velocity *= 0.1f;
			Main.dust[dust2].scale = (float)Main.rand.Next(75, 125) * 0.013f;
			Main.dust[dust2].noGravity = true;
			int dust3 = Dust.NewDust(pos2, 1, 1, 56);
			Main.dust[dust3].velocity *= 0.1f;
			Main.dust[dust3].scale = (float)Main.rand.Next(65, 100) * 0.013f;
			Main.dust[dust3].noGravity = true;
			int dust = Dust.NewDust(pos, 1, 1, 211);
			Main.dust[dust].velocity *= 0f;
			Main.dust[dust].scale = (float)Main.rand.Next(65, 105) * 0.013f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].color = new Color(0, 0, 255);
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		Player player = Main.player[Main.myPlayer];
		if (this.up)
		{
			Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(1f, -5f), Mod.Find<ModProjectile>("WaterboltMini").Type, Projectile.damage / 2, 0f, player.whoAmI, 0f, 0f);
			this.up = false;
		}
		else
		{
			Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(-1f, -5f), Mod.Find<ModProjectile>("WaterboltMini").Type, Projectile.damage / 2, 0f, player.whoAmI, 0f, 0f);
			this.up = true;
		}
	}
}
