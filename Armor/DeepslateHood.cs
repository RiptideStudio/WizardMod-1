using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Head })]
public class DeepslateHood : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Deepslate Hood");
        // Tooltip.SetDefault("12% Increased magic damage\nMax mana increased by 80");
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.value = 1000;
        Item.rare = 3;
        Item.defense = 4;
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Magic attacks inflict heavy burns on enemies\nSpell power increased by 4\nImmune to fire blocks";
        player.GetModPlayer<Global>().deepArmor = true;
        player.GetModPlayer<Global>().spellPower += 4;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Magic) += 0.12f;
        player.statManaMax2 += 80;
        player.fireWalk = true;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        if (body.type == Mod.Find<ModItem>("DeepslateChestplate").Type)
        {
            return legs.type == Mod.Find<ModItem>("DeepslateLegs").Type;
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 5);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
