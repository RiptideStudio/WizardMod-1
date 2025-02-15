using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Projectiles;

public class LivingOrb : ModProjectile
{
	private int time;

	public override void SetDefaults()
	{
		Projectile.width = 14;
		Projectile.height = 34;
		Projectile.friendly = true;
		Projectile.light = 0.5f;
		Projectile.alpha = 100;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 99999999;
		Projectile.tileCollide = false;
		Projectile.scale = 1.1f;
	}

	public override void AI()
	{
		Player player = Main.LocalPlayer;
		Projectile.scale += (float)Math.Sin((double)(Projectile.timeLeft / 15)) / 150f;
		Projectile.alpha += (int)Math.Sin((double)Projectile.timeLeft);
		Projectile.position.X = player.position.X - 0.5f;
		Projectile.position.Y = player.position.Y - 39f;
		if (player.dead)
		{
			Projectile.Kill();
		}
		if (!player.GetModPlayer<Global>().livingArmor)
		{
			Projectile.Kill();
		}
		this.time++;
		if (this.time % 30 != 0)
		{
			return;
		}
		for (int i = 0; i < 200; i++)
		{
			NPC target = Main.npc[i];
			float num = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
			float shootToY = target.position.Y - Projectile.Center.Y + 12f;
			if ((float)Math.Sqrt((double)(num * num + shootToY * shootToY)) < 340f && !target.friendly && target.active && target.lifeMax > 5)
			{
				float projectileSpeed = 5f;
				Vector2 velocity = Vector2.Normalize(new Vector2(target.position.X + (float)(target.width / 2), target.position.Y + (float)(target.height / 2)) - new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2))) * projectileSpeed;
				int proj = Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X, Projectile.position.Y + 6f), velocity, 206, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				Main.projectile[proj].timeLeft = 300;
				Main.projectile[proj].netUpdate = true;
				Projectile.netUpdate = true;
				Projectile.ai[0] = 0f;
				break;
			}
		}
		Projectile.ai[0] += 1f;
	}

	public override bool? CanCutTiles()
	{
		return false;
	}

	public override bool MinionContactDamage()
	{
		return false;
	}
}
