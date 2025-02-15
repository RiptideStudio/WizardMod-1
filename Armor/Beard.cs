using Terraria.ModLoader;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Head })]
public class Beard : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Familar Looking Beard");
        // Tooltip.SetDefault("A beard for those who have bad hair genes");
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.value = 1000;
        Item.rare = 4;
        Item.vanity = true;
        Item.accessory = true;
    }
}
