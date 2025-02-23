using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class AurorStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Auror's Staff");
        // Tooltip.SetDefault("Charges the player with electricity\nZaps any enemies that come near you or hit you\nCan target multiple enemies");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(739);
        Item.damage = 18;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 100;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 10000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 7.5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("ThunderProj").Type] == 0)
        {
            Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("ThunderProj").Type, damage, knockback, player.whoAmI, 2f, 2f);
            Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("AurorProj").Type, damage, knockback, player.whoAmI, 2f, 2f);
            player.AddBuff(Mod.Find<ModBuff>("ElectrifiedBuff").Type, 780);
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(320, 6);
        recipe.AddIngredient(19, 8);
        recipe.AddIngredient(null, "SkyCrystal", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
        Recipe recipe2 = CreateRecipe();
        recipe2.AddIngredient(320, 6);
        recipe2.AddIngredient(706, 8);
        recipe2.AddIngredient(null, "SkyCrystal", 3);
        recipe2.AddTile(null, "ArcaneTable");
        recipe2.Register();
    }
}
