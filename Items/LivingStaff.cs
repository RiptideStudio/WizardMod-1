using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class LivingStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Mossy Wand");
        // Tooltip.SetDefault("Shoots a sphere of natural energy\nReleases green bolts of energy at nearby enemies");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 11;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 10;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 10000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("LivingProj").Type;
        Item.shootSpeed = 1.5f;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(832);
        recipe.AddIngredient(null, "MagicSoul", 5);
        recipe.AddIngredient(null, "LivingShard", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
