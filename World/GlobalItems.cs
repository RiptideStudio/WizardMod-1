using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.World;

public class GlobalItems : GlobalItem
{
	public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (player.GetModPlayer<Global>().enchantedArmor && item.CountsAsClass(DamageClass.Magic))
		{
			player.GetModPlayer<Global>().enchantedNum++;
			Vector2 beamVelocity = Vector2.Normalize(velocity) * new Vector2(10,10);
			if (player.GetModPlayer<Global>().enchantedNum == 3)
			{
				Projectile.NewProjectile((IEntitySource)source, position, beamVelocity, Mod.Find<ModProjectile>("MagicProjBasic").Type, damage, knockback, player.whoAmI, 0f, 0f);
				player.GetModPlayer<Global>().enchantedNum = 0;
			}
		}
		if (player.GetModPlayer<Global>().gandalfArmor && item.CountsAsClass(DamageClass.Magic))
		{
			player.GetModPlayer<Global>().gandalfNum++;
			if (player.GetModPlayer<Global>().gandalfNum == 4)
			{
				Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 24f, position.Y), velocity * 4f, Mod.Find<ModProjectile>("GandalfFireProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
				player.GetModPlayer<Global>().gandalfNum = 0;
			}
		}
		return true;
	}
}
