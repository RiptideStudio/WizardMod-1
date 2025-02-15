using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DiamondScepter : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("The Diamond Tendril");
        // Tooltip.SetDefault("Casts a volley of diamond bolts");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 18;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 13;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 32;
        Item.useAnimation = 32;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 10000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 3f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_0065: Unknown result type (might be due to invalid IL or missing references)
        position += new Vector2(velocity.X * 15f, velocity.Y * 15f);
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        int numberProjectiles = 3;
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(10 * (i - 1)));
            Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("DiamondBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(744);
        recipe.AddIngredient(null, "InfusedStar", 3);
        recipe.AddIngredient(null, "EnchantedShard");
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
