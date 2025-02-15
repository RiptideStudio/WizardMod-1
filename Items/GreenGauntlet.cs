using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class GreenGauntlet : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Bramble Bracer");
        // Tooltip.SetDefault("Left-click to shoot a burst of poisonous wooden spikes\nRight-click to slash enemies");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(368);
        Item.damage = 14;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 8;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 32;
        Item.useAnimation = 32;
        Item.useStyle = 1;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.noUseGraphic = false;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.shootSpeed = 6.5f;
        Item.shoot = 0;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.mana = 0;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.useTime = 10;
            Item.shoot = 0;
            Item.useAnimation = 10;
        }
        else
        {
            Item.mana = 7;
            Item.UseSound = SoundID.Item7;
            Item.noMelee = true;
            Item.useTime = 32;
            Item.shoot = 1;
            Item.useAnimation = 32;
        }
        return base.CanUseItem(player);
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override void HoldItem(Player player)
    {
        Item.DamageType = DamageClass.Magic;
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (player.altFunctionUse != 2)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30f));
                Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("ThornProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(620, 25);
        recipe.AddIngredient(209, 5);
        recipe.AddIngredient(331, 2);
        recipe.AddIngredient(null, "LivingShard", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
