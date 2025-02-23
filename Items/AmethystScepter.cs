using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class AmethystScepter : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Amethyst Trident");
        // Tooltip.SetDefault("Launches a volley of amethyst bolts");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 10;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 5;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 10000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 1.5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_0052: Unknown result type (might be due to invalid IL or missing references)
        position += velocity * 17f;
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, position);
        int numberProjectiles = 3;
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(10 * (i - 1)));
            Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("AmethystBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(739);
        recipe.AddIngredient(null, "InfusedStar", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
