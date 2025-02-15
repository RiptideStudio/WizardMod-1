using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Fiendfyre : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Fiendfyre");
        // Tooltip.SetDefault("Set the whole bloody place on fire!\nHold left-click to cast a massive concentrated blast of deep-burning fire");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(3069);
        Item.damage = 31;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 10;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 5;
        Item.useAnimation = 5;
        Item.useStyle = 5;
        Item.knockBack = 1f;
        Item.value = 2500000;
        Item.rare = 7;
        Item.noMelee = true;
        Item.channel = true;
        Item.shoot = Mod.Find<ModProjectile>("FiendfyreLaser").Type;
        Item.shootSpeed = 9f;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "WildFire");
        recipe.AddIngredient(null, "LunarBar", 12);
        recipe.AddIngredient(520, 5);
        recipe.AddIngredient(null, "LivingShard", 3);
        recipe.AddIngredient(null, "MoltenShard");
        recipe.AddTile(null, "WizardTable");
        recipe.Register();
    }
}
