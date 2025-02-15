using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class BuriedTome : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Buried Tome");
        // Tooltip.SetDefault("Shoots a rock that smashes open upon impact and confuses enemies");
    }

    public override void SetDefaults()
    {
        Item.damage = 14;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 12;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 42;
        Item.useAnimation = 42;
        Item.useStyle = 5;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item69;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("RockSmashProj").Type;
        Item.shootSpeed = 8f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "EnchantedBook");
        recipe.AddIngredient(3271, 25);
        recipe.AddIngredient(180, 5);
        recipe.AddIngredient(323, 3);
        recipe.AddTile(101);
        recipe.Register();
    }
}
