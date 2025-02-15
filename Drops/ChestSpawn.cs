using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Drops;

public class ChestSpawn : ModSystem
{
	public override void PostWorldGen()
	{
		int itemsToPlaceInChestsChoice = 0;
		for (int chestIndex3 = 0; chestIndex3 < 1000; chestIndex3++)
		{
			Chest chest3 = Main.chest[chestIndex3];
			int[] itemsToPlaceInChests6 = new int[1] { Mod.Find<ModItem>("EnchantedDagger").Type };
			int enchantedDaggerNum3 = Main.rand.Next(23, 51);
			if (chest3 == null || Main.tile[chest3.x, chest3.y].TileType != 21 || Main.tile[chest3.x, chest3.y].TileFrameX != 0)
			{
				continue;
			}
			for (int inventoryIndex3 = 0; inventoryIndex3 < 40; inventoryIndex3++)
			{
				if (chest3.item[inventoryIndex3].type == 0)
				{
					chest3.item[inventoryIndex3].SetDefaults(itemsToPlaceInChests6[itemsToPlaceInChestsChoice]);
					chest3.item[inventoryIndex3].stack = enchantedDaggerNum3;
					itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests6.Length;
					inventoryIndex3++;
					break;
				}
			}
		}
		for (int chestIndex2 = 0; chestIndex2 < 1000; chestIndex2++)
		{
			Chest chest2 = Main.chest[chestIndex2];
			int[] itemsToPlaceInChests5 = new int[1] { Mod.Find<ModItem>("CharredScroll").Type };
			int enchantedDaggerNum2 = Main.rand.Next(2, 5);
			if (chest2 == null || Main.tile[chest2.x, chest2.y].TileType != 21 || Main.tile[chest2.x, chest2.y].TileFrameX != 36)
			{
				continue;
			}
			for (int inventoryIndex2 = 0; inventoryIndex2 < 40; inventoryIndex2++)
			{
				if (chest2.item[inventoryIndex2].type == 0)
				{
					chest2.item[inventoryIndex2].SetDefaults(itemsToPlaceInChests5[itemsToPlaceInChestsChoice]);
					chest2.item[inventoryIndex2].stack = enchantedDaggerNum2;
					itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests5.Length;
					inventoryIndex2++;
					break;
				}
			}
		}
		for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
		{
			Chest chest = Main.chest[chestIndex];
			int[] itemsToPlaceInChests4 = new int[1] { Mod.Find<ModItem>("IceScroll").Type };
			int enchantedDaggerNum = Main.rand.Next(2, 5);
			if (chest == null || Main.tile[chest.x, chest.y].TileType != 21 || Main.tile[chest.x, chest.y].TileFrameX != 396)
			{
				continue;
			}
			for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
			{
				if (chest.item[inventoryIndex].type == 0)
				{
					chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests4[itemsToPlaceInChestsChoice]);
					chest.item[inventoryIndex].stack = enchantedDaggerNum;
					itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests4.Length;
					inventoryIndex++;
					break;
				}
			}
		}
	}
}
