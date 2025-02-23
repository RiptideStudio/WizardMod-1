using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class DeepslateChestplate : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Deepslate Chestplate");
        // Tooltip.SetDefault("Magic critical strike chance and damage increased by 6%");
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.value = 1250;
        Item.rare = 3;
        Item.defense = 9;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetCritChance(DamageClass.Magic) += 6f;
        player.GetDamage(DamageClass.Magic) += 0.06f;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 15);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
