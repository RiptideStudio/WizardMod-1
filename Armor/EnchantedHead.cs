using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Head })]
public class EnchantedHead : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Enchanted Cowl");
        // Tooltip.SetDefault("5% Increased magic damage\nMax mana increased by 40");
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.value = 1000;
        Item.rare = 3;
        Item.defense = 5;
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Every third magic attack shoots an enchanted blast\nSpell power increased by 3\nEnchanted Tome and Enchanted Gauntlet mana cost reduced by 50%";
        player.GetModPlayer<Global>().enchantedArmor = true;
        player.GetModPlayer<Global>().manaOnHit++;
        player.GetModPlayer<Global>().spellPower += 3;
    }

    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 40;
        player.GetDamage(DamageClass.Magic) += 0.05f;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        if (body.type == Mod.Find<ModItem>("EnchantedTunic").Type)
        {
            return legs.type == Mod.Find<ModItem>("EnchantedLegs").Type;
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "EnchantedShard", 7);
        recipe.AddIngredient(19, 5);
        recipe.AddIngredient(null, "EnchantedSilk", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();

        Recipe recipe2 = CreateRecipe();
        recipe2.AddIngredient(null, "EnchantedShard", 7);
        recipe2.AddIngredient(706, 5);
        recipe2.AddIngredient(null, "EnchantedSilk", 3);
        recipe2.AddTile(null, "ArcaneTable");
        recipe2.Register();
    }
}
