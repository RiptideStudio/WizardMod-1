using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace WizardMod.World;

public class Global : ModPlayer
{
	public bool livingArmor = true;

	public bool deepArmor = true;

	public bool gandalfArmor = true;

	public int manaOnHit = 2;

	public bool aetherAmulet;

	public bool enchantedArmor;

	public bool overgrownPendant;

	public bool deathEater;

	public int enchantedNum;

	public int gandalfNum;

	public bool chaosEnchantment;

	public int spellPower = 1;

	public int spellString;

	public bool moltenRing;

	public bool arcaneShield;

	public bool screenShake;

	public bool corruptRing;

	public bool empowerMagic;

	public bool diveBomb = true;

	public bool vampireRing = true;

	public bool manaPotionOff;

	public bool doManaPotion;

	public bool celestialHoop;

	public int damageDealt;

	public int damageTaken;

	private int time;

	public int timer;

	public override void ModifyScreenPosition()
	{
		if (this.screenShake && this.time < 30)
		{
			this.time++;
			Main.screenPosition = new Vector2(Main.screenPosition.X - (float)Main.rand.Next(-4, 4), Main.screenPosition.Y - (float)Main.rand.Next(-4, 4));
		}
		if (this.time >= 30)
		{
			this.screenShake = false;
			this.time = 0;
		}
	}

	public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
	{
		if (this.manaPotionOff)
		{
			healValue = 0;
		}
	}

	public override void ResetEffects()
	{
		this.doManaPotion = false;
		this.timer++;
		if (this.timer > 180)
		{
			this.timer = 0;
			this.diveBomb = true;
		}
		if (this.time >= 30)
		{
			this.screenShake = false;
		}
		this.manaPotionOff = false;
		this.vampireRing = false;
		this.moltenRing = false;
		this.livingArmor = false;
		this.arcaneShield = false;
		this.celestialHoop = false;
		this.deepArmor = false;
		this.aetherAmulet = false;
		this.enchantedArmor = false;
		this.chaosEnchantment = false;
		this.gandalfArmor = false;
		this.overgrownPendant = false;
		this.corruptRing = false;
		this.manaOnHit = 2;
		this.spellPower = 1;
	}

	public override void PreUpdate()
	{
		if (this.deepArmor)
		{
			if (Player.velocity.X != 0f)
			{
				if (Player.direction == 1)
				{
					int num371 = Dust.NewDust(new Vector2(Player.position.X - 12f, Player.position.Y), Player.width, Player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num371].velocity *= 1f;
					Main.dust[num371].noGravity = true;
				}
				else
				{
					int num370 = Dust.NewDust(new Vector2(Player.position.X + 12f, Player.position.Y), Player.width, Player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num370].velocity *= 1f;
					Main.dust[num370].noGravity = true;
				}
			}
			if (Player.velocity.Y != 0f)
			{
				int num372 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num372].velocity *= 1f;
				Main.dust[num372].noGravity = true;
			}
		}
        if (this.enchantedArmor && (Player.velocity.X != 0f || Player.velocity.Y != 0f))
        {
            Vector2 dustPosition = Player.position + new Vector2(Player.velocity.X != 0f ? (Player.direction == 1 ? -8f : 8f) : 0f, 0f);
            int dustIndex = Dust.NewDust(dustPosition, Player.width, Player.height, 15, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[dustIndex].velocity = Vector2.Zero;
            Main.dust[dustIndex].noGravity = true;
        }
        if (this.livingArmor && Player.ownedProjectileCounts[Mod.Find<ModProjectile>("LivingOrb").Type] == 0)
		{
			Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("LivingOrb").Type, 12, 0f, Player.whoAmI, 0f, 0f);
		}
	}

	public virtual void OnHitByNPC(NPC npc, int damage, bool crit)
	{
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		if (this.celestialHoop)
		{
			int proj1 = Projectile.NewProjectile(npc.GetSource_Death(), npc.position, new Vector2(-3f, 3f), Mod.Find<ModProjectile>("StardustProjMini").Type, 12, 1f, Player.whoAmI, 0f, 0f);
			int proj2 = Projectile.NewProjectile(npc.GetSource_Death(), npc.position, new Vector2(0f, 3f), Mod.Find<ModProjectile>("StardustProjMini").Type, 12, 1f, Player.whoAmI, 0f, 0f);
			int proj3 = Projectile.NewProjectile(npc.GetSource_Death(), npc.position, new Vector2(-3f, -3f), Mod.Find<ModProjectile>("StardustProjMini").Type, 12, 1f, Player.whoAmI, 0f, 0f);
			Main.projectile[proj1].scale = 0.5f;
			Main.projectile[proj2].scale = 0.5f;
			Main.projectile[proj3].scale = 0.5f;
		}
		if (this.arcaneShield && !Player.HasBuff(Mod.Find<ModBuff>("ArcaneShieldCooldown").Type) && !Player.HasBuff(Mod.Find<ModBuff>("ArcaneShieldBuff").Type))
		{
			SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
			SoundEngine.PlaySound(soundStyle, (Vector2?)npc.position);
			Player.AddBuff(Mod.Find<ModBuff>("ArcaneShieldBuff").Type, 600, quiet: false);
			Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj2").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj3").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj4").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
		}
		if (this.aetherAmulet)
		{
			Player.immuneTime += 70;
			if (!Player.HasBuff(Mod.Find<ModBuff>("GodArmorDebuff").Type))
			{
				Player.AddBuff(Mod.Find<ModBuff>("GodArmorBuff").Type, 300, quiet: false);
				Player.AddBuff(Mod.Find<ModBuff>("GodArmorDebuff").Type, 1800, quiet: false);
			}
		}
	}

	public virtual void ModifyHitByProjectile(Projectile projectile, ref int damage, ref bool crit)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		if (this.arcaneShield && !Player.HasBuff(Mod.Find<ModBuff>("ArcaneShieldCooldown").Type))
		{
			SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
			SoundEngine.PlaySound(soundStyle, (Vector2?)projectile.position);
			Player.AddBuff(Mod.Find<ModBuff>("ArcaneShieldBuff").Type, 600, quiet: false);
			Player.AddBuff(Mod.Find<ModBuff>("ArcaneShieldCooldown").Type, 1200, quiet: false);
			Projectile.NewProjectile(projectile.GetSource_FromThis(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(projectile.GetSource_FromThis(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj2").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(projectile.GetSource_FromThis(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj3").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(projectile.GetSource_FromThis(), Player.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ArcaneShieldProj4").Type, 12 + (int)Player.GetCritChance(DamageClass.Magic), 0f, Player.whoAmI, 0f, 0f);
		}
		if (this.aetherAmulet)
		{
			Player.immuneTime += 70;
			if (!Player.HasBuff(Mod.Find<ModBuff>("ArcaneDebuff").Type))
			{
				Player.AddBuff(Mod.Find<ModBuff>("ArcaneBuff").Type, 600, quiet: false);
				Player.AddBuff(Mod.Find<ModBuff>("ArcaneDebuff").Type, 1800, quiet: false);
			}
		}
	}

	public override void PostUpdateEquips()
	{
		if (this.doManaPotion)
		{
			Player.manaFlower = true;
		}
		else
		{
			Player.manaFlower = false;
		}
	}
}
