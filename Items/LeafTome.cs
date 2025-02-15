using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class LeafTome : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Leaf Tome");
        // Tooltip.SetDefault("Rapidly pelts your enemy with leaves\nIs slightly inaccurate");
    }

    public override void SetDefaults()
    {
        Item.damage = 11;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 3;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 12;
        Item.useAnimation = 12;
        Item.useStyle = 5;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = 206;
        Item.shootSpeed = 7f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "EnchantedBook");
        recipe.AddIngredient(null, "LivingShard", 3);
        recipe.AddIngredient(null, "MagicSoul", 2);
        recipe.AddIngredient(9, 20);
        recipe.AddTile(101);
        recipe.Register();
    }
}
