using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class CelestialSky : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Celestial Sky");
        // Tooltip.SetDefault("Shoots a pair of rapidly rotating star-discs that home in on enemies");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 22;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 15;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.useStyle = 5;
        Item.knockBack = 2f;
        Item.value = 150000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("CelestialSkyProj").Type;
        Item.shootSpeed = 10f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int numberProjectiles = 2;
        float rotation = MathHelper.ToRadians(15f);
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, i / numberProjectiles));
            Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("CelestialSkyProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X + (float)(2 * player.direction);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "StardustStaff");
        recipe.AddIngredient(null, "SkyCrystal", 3);
        recipe.AddIngredient(57, 5);
        recipe.AddIngredient(null, "InfusedStar", 15);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
        Recipe recipe2 = CreateRecipe();
        recipe2.AddIngredient(null, "StardustStaff");
        recipe2.AddIngredient(null, "SkyCrystal", 3);
        recipe2.AddIngredient(1257, 5);
        recipe2.AddIngredient(null, "InfusedStar", 15);
        recipe2.AddTile(null, "ArcaneTable");
        recipe2.Register();
    }
}
