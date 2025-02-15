using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.World;

public class GlobalProj : GlobalProjectile
{
	public virtual void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
	{
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.player[projectile.owner];
		if (player.GetModPlayer<Global>().moltenRing && Main.rand.Next(0, 4) == 0)
		{
			target.AddBuff(Mod.Find<ModBuff>("DeepslateBuff").Type, 120);
		}
		if (projectile.type == 306 || projectile.type == 307)
		{
			target.AddBuff(Mod.Find<ModBuff>("RottenDebuff").Type, 240);
		}
		int spellPower = player.GetModPlayer<Global>().spellPower;
		if (spellPower > 1)
		{
			_ = 9 - spellPower / 2;
			_ = 5;
			int spellMax = 12 - spellPower;
			if (spellMax < 6)
			{
				spellMax = 6;
			}
			int num4 = Main.rand.Next(0, spellMax);
			int effectTime = 45 * spellPower / 2;
			if (effectTime < 180)
			{
				effectTime = 180;
			}
			if (num4 == 1)
			{
				if (spellPower > 1 && spellPower <= 4)
				{
					int num5 = Main.rand.Next(1, 4);
					if (num5 == 1)
					{
						target.AddBuff(24, effectTime);
					}
					if (num5 == 2)
					{
						target.AddBuff(44, effectTime);
					}
					if (num5 == 3)
					{
						target.AddBuff(20, effectTime);
					}
				}
				if (spellPower > 4 && spellPower <= 8)
				{
					int num6 = Main.rand.Next(1, 5);
					if (num6 == 1)
					{
						target.AddBuff(44, effectTime);
					}
					if (num6 == 2)
					{
						target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff").Type, effectTime);
					}
					if (num6 == 3)
					{
						target.AddBuff(31, effectTime);
					}
					if (num6 == 4)
					{
						target.AddBuff(Mod.Find<ModBuff>("RottenDebuff").Type, effectTime);
					}
				}
				if (spellPower > 8 && spellPower <= 12)
				{
					int num7 = Main.rand.Next(1, 5);
					if (num7 == 1)
					{
						target.AddBuff(44, effectTime);
					}
					if (num7 == 2)
					{
						target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff2").Type, effectTime);
					}
					if (num7 == 3)
					{
						target.AddBuff(31, effectTime);
					}
					if (num7 == 4)
					{
						target.AddBuff(69, effectTime);
					}
				}
				if (spellPower > 12)
				{
					int num8 = Main.rand.Next(1, 6);
					if (num8 == 1)
					{
						target.AddBuff(44, effectTime);
					}
					if (num8 == 2)
					{
						target.AddBuff(70, effectTime);
					}
					if (num8 == 3)
					{
						target.AddBuff(31, effectTime);
					}
					if (num8 == 4)
					{
						target.AddBuff(69, effectTime);
					}
					if (num8 == 5)
					{
						target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff3").Type, effectTime);
					}
				}
			}
		}
		if (projectile.type == 504 && Main.rand.Next(0, 2) == 0)
		{
			target.AddBuff(24, 60);
		}
		if (projectile.CountsAsClass(DamageClass.Magic) && player.GetModPlayer<Global>().corruptRing)
		{
			if (Main.rand.Next(0, 3) == 1)
			{
				if (Main.rand.Next(0, 2) == 1)
				{
					target.AddBuff(Mod.Find<ModBuff>("RottenDebuff").Type, 120);
				}
				else
				{
					target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff").Type, 120);
				}
			}
			player.GetModPlayer<Global>().damageDealt += damage;
			if (player.GetModPlayer<Global>().damageDealt >= 250)
			{
				player.GetModPlayer<Global>().damageDealt = 0;
				player.GetModPlayer<Global>().empowerMagic = true;
				SoundEngine.PlaySound(SoundID.NPCHit21, (Vector2?)projectile.position);
				for (int num3 = 0; num3 < 10; num3++)
				{
					int num1 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 18, 0f, 0f, 100, default(Color), 2.5f);
					Main.dust[num1].noGravity = true;
					Main.dust[num1].velocity *= 1f;
					int num2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 14, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num2].velocity *= 2f;
				}
				int newDamage2 = damage;
				if (damage > 25)
				{
					newDamage2 = 25;
				}
				float numberProjectiles2 = 1 + Main.rand.Next(1);
				for (int j = 0; (float)j < numberProjectiles2; j++)
				{
					_ = Vector2.Normalize(new Vector2(5f, 6f)) * 45f;
					float rotation2 = MathHelper.ToRadians(35 * Main.rand.Next(10));
					Vector2 perturbedSpeed2 = new Vector2(Main.rand.Next(6, 9), Main.rand.Next(5, 7)).RotatedBy(MathHelper.Lerp(0f - rotation2, rotation2, (float)j / (numberProjectiles2 - 1f))) * 0.15f;
					int proj3 = Projectile.NewProjectile(Entity.GetSource_NaturalSpawn(), new Vector2(target.position.X, target.position.Y - (float)(target.height / 2)), perturbedSpeed2 * 2f, 307, newDamage2, 1f, player.whoAmI, 0f, 0f);
					Main.projectile[proj3].hostile = false;
				}
			}
		}
		if (projectile.CountsAsClass(DamageClass.Magic) && player.GetModPlayer<Global>().vampireRing)
		{
			if (Main.rand.Next(0, 3) == 1)
			{
				if (Main.rand.Next(0, 2) == 1)
				{
					target.AddBuff(Mod.Find<ModBuff>("LifestealDebuff").Type, 120);
				}
				else
				{
					target.AddBuff(Mod.Find<ModBuff>("LifestealDebuff").Type, 120);
				}
			}
			player.GetModPlayer<Global>().damageDealt += damage;
			if (player.GetModPlayer<Global>().damageDealt >= 300)
			{
				player.GetModPlayer<Global>().damageDealt = 0;
				SoundEngine.PlaySound(SoundID.NPCHit21, (Vector2?)projectile.position);
				int newDamage = damage;
				if (damage > 25)
				{
					newDamage = 25;
				}
				float numberProjectiles = 2 + Main.rand.Next(2);
				for (int i = 0; (float)i < numberProjectiles; i++)
				{
					_ = Vector2.Normalize(new Vector2(5f, 6f)) * 45f;
					float rotation = MathHelper.ToRadians(35 * Main.rand.Next(10));
					Vector2 perturbedSpeed = new Vector2(Main.rand.Next(6, 9), Main.rand.Next(5, 7)).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f))) * 0.15f;
					int proj2 = Projectile.NewProjectile(Entity.GetSource_NaturalSpawn(), new Vector2(target.position.X, target.position.Y - (float)(target.height / 2)), perturbedSpeed * 2f, Mod.Find<ModProjectile>("HomingCrimson").Type, newDamage, 1f, player.whoAmI, 0f, 0f);
					Main.projectile[proj2].hostile = false;
				}
			}
		}
		if (projectile.type == 359)
		{
			target.AddBuff(44, 180);
			projectile.Kill();
		}
		if (player.GetModPlayer<Global>().deepArmor && projectile.CountsAsClass(DamageClass.Magic))
		{
			target.AddBuff(24, 120);
			target.AddBuff(Mod.Find<ModBuff>("DeepslateBuff").Type, 120);
		}
		if (player.GetModPlayer<Global>().moltenRing && projectile.CountsAsClass(DamageClass.Magic) && Main.rand.Next(0, 3) == 1 && player.GetModPlayer<Global>().diveBomb)
		{
			player.GetModPlayer<Global>().diveBomb = false;
			new Vector2(Main.rand.Next(0, 9));
			int maxDamage = damage;
			if (maxDamage > 25)
			{
				maxDamage = 25;
			}
			int proj = Projectile.NewProjectile(Entity.GetSource_NaturalSpawn(), new Vector2(target.Center.X, player.position.Y - 600f), new Vector2(0f, 0f), 18, 706, (float)maxDamage, 1, (float)player.whoAmI, 0f);
			Main.projectile[proj].tileCollide = false;
			Main.projectile[proj].penetrate = 1;
		}
		if (crit && projectile.CountsAsClass(DamageClass.Magic))
		{
			player.statMana += player.GetModPlayer<Global>().manaOnHit;
			player.ManaEffect(player.GetModPlayer<Global>().manaOnHit);
		}
	}

	public override void AI(Projectile projectile)
	{
		if (Main.player[projectile.owner].GetModPlayer<Global>().deepArmor && projectile.CountsAsClass(DamageClass.Magic) && Main.rand.Next(0, 2) == 1 && projectile.type != Mod.Find<ModProjectile>("AshenProj").Type && projectile.type != Mod.Find<ModProjectile>("AshenProj2").Type && Main.rand.Next(0, 3) == 1)
		{
			for (int i = 0; i < 3; i++)
			{
				int dust5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
				Main.dust[dust5].velocity.Y *= 1f;
				Main.dust[dust5].noGravity = true;
			}
		}
	}
}
