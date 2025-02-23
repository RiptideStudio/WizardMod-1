using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class BloodRippleStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("The Bloodrippler");
        // Tooltip.SetDefault("Creates a swirling shockwave of blood on impact");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(739);
        Item.damage = 18;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 10;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 32;
        Item.useAnimation = 32;
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
        Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("CrimsonWaveProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(1257, 12);
        recipe.AddIngredient(null, "InfusedStar", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
