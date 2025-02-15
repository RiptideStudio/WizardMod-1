using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class EbonwoodStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Ebonwood Staff");
        // Tooltip.SetDefault("Shoots a bolt of darkness");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 11;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 2;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 10000;
        Item.rare = 1;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("EbonwoodProj").Type;
        Item.shootSpeed = 5.5f;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(619, 12);
        recipe.AddIngredient(null, "MagicSoul", 3);
        recipe.AddTile(18);
        recipe.Register();
    }
}
