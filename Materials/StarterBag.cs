using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class StarterBag : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Wizard's Pouch");
        // Tooltip.SetDefault("Right-click to open\nContains an assortment of magical goods");
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.consumable = true;
        Item.width = 24;
        Item.height = 24;
        Item.rare = 1;
        Item.value = 4000;
    }

    public override bool CanRightClick()
    {
        return true;
    }

    public override void ModifyItemLoot(ItemLoot itemLoot)
    {
        itemLoot.Add(ItemDropRule.Common(3069));
        itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PocketFireball").Type, 1, 75, 75));
        itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("MagicSoul").Type, 1, 10, 10));
        itemLoot.Add(ItemDropRule.Common(3093, 1, 5, 5));
        itemLoot.Add(ItemDropRule.Common(75, 1, 3, 3));
        itemLoot.Add(ItemDropRule.Common(109));
        itemLoot.Add(ItemDropRule.Common(149, 1, 10, 10));
        itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Paper").Type, 1, 5, 5));
        itemLoot.Add(ItemDropRule.Common(1791));
    }
}
