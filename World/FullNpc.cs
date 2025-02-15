using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.World;

public class FullNpc : GlobalNPC
{
	public virtual void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
	{
		if (projectile.CountsAsClass(DamageClass.Magic))
		{
			Player player = Main.LocalPlayer;
			if (Main.rand.Next(0, 3) == 2 && player.GetModPlayer<Global>().overgrownPendant)
			{
				npc.AddBuff(20, 180);
			}
			if (player.GetModPlayer<Global>().gandalfArmor && projectile.type != Mod.Find<ModProjectile>("ThunderStrikeProj").Type)
			{
				Main.rand.Next(3);
				MathHelper.ToRadians(145f);
				_ = Vector2.Normalize(new Vector2(5f, 5f)) * 45f;
				if (Main.rand.Next(0, 2) == 1)
				{
					Projectile.NewProjectile(npc.GetSource_FromThis(), new Vector2(npc.position.X + 24f, npc.position.Y), new Vector2(0f, 0f), Mod.Find<ModProjectile>("ExplosionDark").Type, projectile.damage / 2, 0f, player.whoAmI, 0f, 0f);
				}
				if (Main.rand.Next(0, 2) == 1)
				{
					Projectile.NewProjectile(npc.GetSource_FromThis(), new Vector2(npc.position.X + 36f, npc.position.Y - 512f), new Vector2(0f, 20f), Mod.Find<ModProjectile>("ThunderStrikeProj").Type, projectile.damage, 1f, player.whoAmI, 0f, 0f);
				}
			}
		}
		if (projectile.type == Mod.Find<ModProjectile>("ToothProj").Type && npc.HasBuff(Mod.Find<ModBuff>("RottenDebuff").Type))
		{
			damage += projectile.damage / 2;
		}
		if (projectile.type == Mod.Find<ModProjectile>("BloodyProj").Type && npc.HasBuff(Mod.Find<ModBuff>("LifestealDebuff").Type))
		{
			Player obj = Main.player[projectile.owner];
			int healingAmount2 = obj.GetModPlayer<Global>().spellPower;
			obj.statLife += healingAmount2;
			obj.HealEffect(healingAmount2);
		}
		if (projectile.type == Mod.Find<ModProjectile>("HomingCrimson").Type)
		{
			Player obj2 = Main.player[projectile.owner];
			int healingAmount = obj2.GetModPlayer<Global>().spellPower;
			obj2.statLife += healingAmount;
			obj2.HealEffect(healingAmount);
		}
	}

	public override void OnKill(NPC npc)
	{
		Player player = Main.LocalPlayer;
		if (player.GetModPlayer<Global>().overgrownPendant)
		{
			float numberProjectiles = 1 + Main.rand.Next(3);
			Vector2 position = Vector2.Normalize(new Vector2(7f, 7f)) * 45f;
			for (int i = 0; (float)i < numberProjectiles; i++)
			{
				float rotation = MathHelper.ToRadians(35 * Main.rand.Next(10));
				Vector2 perturbedSpeed = new Vector2(85f, 85f).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f))) * 0.2f;
				Projectile.NewProjectile(npc.GetSource_FromThis(), position, perturbedSpeed, 7, 7, 1f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
