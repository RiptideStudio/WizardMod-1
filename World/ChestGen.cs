using Terraria;
using Terraria.ModLoader;

namespace WizardMod.World;

public class ChestGen : ModSystem
{
	public override void PostWorldGen()
	{
		int[] itemsToPlaceInIceChests = new int[1] { 3093 };
		int[] livingScrollItem = new int[1] { Mod.Find<ModItem>("LivingScroll").Type };
		int itemsToPlaceInIceChestsChoice = 0;
		for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
		{
			int itemnum = Main.rand.Next(0, 5);
			Chest chest = Main.chest[chestIndex];
			if (chest == null || Main.tile[chest.x, chest.y].TileType != 21 || Main.tile[chest.x, chest.y].TileFrameX != 0)
			{
				continue;
			}
			for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
			{
				if (chest.item[inventoryIndex].type == 0)
				{
					chest.item[inventoryIndex].SetDefaults(livingScrollItem[itemsToPlaceInIceChestsChoice]);
					chest.item[inventoryIndex].stack = itemnum;
					itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1) % itemsToPlaceInIceChests.Length;
					break;
				}
			}
		}
	}
}
