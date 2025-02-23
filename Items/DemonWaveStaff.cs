using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DemonWaveStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Demonwave Staff");
        // Tooltip.SetDefault("Creates a swirling shockwave on impact");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(739);
        Item.damage = 16;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 11;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useStyle = 5;
        Item.knockBack = 7f;
        Item.value = 10000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 7f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("DemonWaveProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(57, 12);
        recipe.AddIngredient(null, "InfusedStar", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
