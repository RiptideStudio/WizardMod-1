using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class ChainSpaceGun : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Chain Space Gun");
        // Tooltip.SetDefault("Pew-pew!\nRapidly shoots lasers\nIs slightly inaccurate");
    }

    public override void SetDefaults()
    {
        Item.damage = 25;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 5;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 7;
        Item.useAnimation = 7;
        Item.useStyle = 5;
        Item.knockBack = 1f;
        Item.value = 70000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 20;
        Item.shootSpeed = 14f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(2f, 0f);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/ChainLaser").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15f));
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + velocity.X * 3f, position.Y + velocity.Y * 3f), perturbedSpeed, Mod.Find<ModProjectile>("ChainSpaceLaser").Type, damage, knockback, player.whoAmI, 2f, 2f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(127);
        recipe.AddIngredient(324);
        recipe.AddIngredient(154, 25);
        recipe.AddIngredient(null, "InfusedStar", 12);
        recipe.AddIngredient(null, "SkyCrystal", 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
