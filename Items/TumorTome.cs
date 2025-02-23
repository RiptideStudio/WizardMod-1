using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class TumorTome : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Tumor");
		// Tooltip.SetDefault("Shoots tumors which breifly latch onto enemies until they die\nDrains enemy life upon critical hits\nOnly one tumor can be alive at once");
	}

	public override void SetDefaults()
	{
		Item.damage = 17;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 14;
		Item.width = 16;
		Item.crit = 9;
		Item.height = 32;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.useStyle = 5;
		Item.knockBack = 1f;
		Item.value = 20000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 7f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("TumorClump").Type] < 1)
		{
			SoundEngine.PlaySound(SoundID.Item20, (Vector2?)player.position);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.position.X + 4f, position.Y + 6f), velocity, Mod.Find<ModProjectile>("TumorClump").Type, damage, knockback, player.whoAmI, 2f, 2f);
		}
		return false;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(2f, 0f);
	}

	public override void HoldItem(Player player)
	{
		if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("TumorClump").Type] < 1)
		{
			Item.mana = 14;
		}
		else
		{
			Item.mana = 0;
		}
	}
}
