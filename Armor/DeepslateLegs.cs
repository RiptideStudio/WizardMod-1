using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Legs })]
public class DeepslateLegs : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Deepslate Leggings");
        // Tooltip.SetDefault("12% Increased movement speed\nCritical strike mana recovery increased by 2");
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.value = 1000;
        Item.rare = 3;
        Item.defense = 7;
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.12f;
        player.GetModPlayer<Global>().manaOnHit += 2;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 10);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
