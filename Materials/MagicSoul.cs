using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class MagicSoul : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Magic Essence");
		// Tooltip.SetDefault("Used to craft magical items\nCan be traded with the Apprentice");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 8));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		ItemID.Sets.ItemNoGravity[Item.type] = true;
		ItemID.Sets.ItemIconPulse[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(547);
		Item.width = 24;
		Item.height = 24;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 1;
		Item.noMelee = true;
	}

	public override void PostUpdate()
	{
		Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
	}
}
