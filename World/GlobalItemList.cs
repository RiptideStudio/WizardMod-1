using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.World;

public class GlobalItemList : GlobalItem
{
	public float awesome;

	internal int index;

	internal int instanceIndex;

	private int timer;

	public WizardMod mod { get; internal set; }

	public new string Name { get; internal set; }

	public override bool InstancePerEntity => true;

	protected override bool CloneNewInstances => true;

	public override void SetDefaults(Item item)
	{
		if (item.CountsAsClass(DamageClass.Magic))
		{
			item.autoReuse = true;
		}
		if (item.type == 238)
		{
			item.defense = 4;
			item.rare = 3;
		}
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		if (item.type == 238)
		{
			TooltipLine line6 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
			if (line6 != null)
			{
				line6.Text = "Did something change here?\n12% increased magic damage\n5% increased magic critical strike chance\nSpell power increased by 1";
			}
		}
		if (item.type == 489)
		{
			TooltipLine line5 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
			if (line5 != null)
			{
				line5.Text = "15% increased magic damage\nSpell power increased by 2";
			}
		}
		if (item.type == 111)
		{
			TooltipLine line4 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
			if (line4 != null)
			{
				line4.Text = "Increases maximum mana by 40\nSpell power increased by 1";
			}
		}
		if (item.type == 2221)
		{
			TooltipLine line3 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
			TooltipLine line8 = tooltips.LastOrDefault((TooltipLine x) => x.Name == "Tooltip1" && x.Mod == "Terraria");
			if (line3 != null)
			{
				line3.Text = "Increases pickup range for mana stars\nRestores mana when damaged\nIncreases maximum mana by 20\nSpell power increased by 1";
				line8.Text = "";
			}
		}
		if (item.type == 1791)
		{
			TooltipLine line2 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
			if (line2 != null)
			{
				line2.Text = "Hmm... needs more salt!\nUsed to brew magic spells";
			}
		}
		if (item.type == 555)
		{
			TooltipLine line = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
			TooltipLine line7 = tooltips.LastOrDefault((TooltipLine x) => x.Name == "Tooltip1" && x.Mod == "Terraria");
			if (line != null)
			{
				line.Text = "25% reduced mana usage\n5% decreased magic damage\nCritical stirke mana recovery increased by 3\nMana regeneration is greatly improved";
			}
			if (line7 != null)
			{
				line7.Text = "";
			}
		}
	}

	public override void UpdateEquip(Item item, Player player)
	{
		this.timer++;
		if (item.type == 2221)
		{
			player.GetModPlayer<Global>().spellPower++;
		}
		if (item.type == 111)
		{
			player.GetModPlayer<Global>().spellPower++;
			player.statManaMax2 += 20;
		}
		if (item.type == 489)
		{
			player.GetModPlayer<Global>().spellPower += 2;
		}
		if (item.type == 238)
		{
			player.GetCritChance(DamageClass.Magic) += 5f;
		}
		if (item.type == 555)
		{
			player.GetDamage(DamageClass.Magic) -= 0.05f;
			player.manaCost -= 0.25f;
			if (this.timer % 30 == 0)
			{
				player.statMana++;
				this.timer = 0;
			}
			player.GetModPlayer<Global>().manaOnHit += 3;
		}
	}
}
