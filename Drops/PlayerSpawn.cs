using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using WizardMod.Materials;

namespace WizardMod.Drops;

public class PlayerSpawn : ModPlayer
{
	public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
	{
		Item starterItem = new Item();
		starterItem.SetDefaults(ModContent.ItemType<StarterBag>(), false);
		yield return starterItem;
	}
}
