using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Drops;

public class DropItems : GlobalNPC
{
	public override void OnKill(NPC npc)
	{
		int num = Main.rand.Next(1000);
		int chance = 980;
		Player player = Main.LocalPlayer;
		if (num >= chance)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 327 && Main.rand.Next(0, 7) == 1)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("SpiralWand").Type);
		}
		if (npc.type == 45)
		{
			for (int k = 0; k < 5; k++)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			for (int j = 0; j < Main.rand.Next(9, 13); j++)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("EnchantedShard").Type);
			}
		}
		if (npc.type == 4)
		{
			for (int i = 0; i < Main.rand.Next(9, 12); i++)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("EnchantedShard").Type);
			}
		}
		if (NPC.downedBoss1)
		{
			if (npc.type == 495)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("EnchantedShard").Type);
			}
			if (npc.type == 494)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("EnchantedShard").Type);
			}
			if (Main.rand.Next(0, 4) == 1)
			{
				if (npc.type == 482)
				{
					Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("EnchantedShard").Type, Main.rand.Next(1, 4));
				}
				if (npc.type == 483)
				{
					Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("EnchantedShard").Type, Main.rand.Next(1, 4));
				}
			}
		}
		if (npc.type == 49 && Main.rand.Next(0, 100) > 95)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("BatStaff").Type);
		}
		if (npc.type == -7)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 62)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 86)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 43)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 204)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 29)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 509)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (npc.type == 24)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (Main.rand.Next(0, 2) == 1 && npc.type == 61)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), 320);
		}
		if (Main.rand.Next(0, 2) == 1)
		{
			if (npc.type == -10)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 150)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 61)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 42)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == -17)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 48)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 32)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 483)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 84)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 224)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 181)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 6)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == -12)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 239)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 240)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 173)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
		}
		if (Main.rand.Next(0, 3) == 1)
		{
			if (npc.type == 23)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 75)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
		}
		if (Main.rand.Next(0, 4) == 1)
		{
			if (npc.type == 489)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
			if (npc.type == 490)
			{
				Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
			}
		}
		if (npc.type == 266)
		{
			Item.NewItem(player.GetSource_DropAsItem(), npc.getRect(), Mod.Find<ModItem>("TumorTome").Type);
		}
	}
}
