using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class CursedFlames : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Crystal Flames");
        // Tooltip.SetDefault("\nSpews out a mix of cursed flames and crystals\nIs slightly inaccurate");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(518);
        Item.damage = 53;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 9;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 9;
        Item.useAnimation = 9;
        Item.useStyle = 5;
        Item.knockBack = 2f;
        Item.value = 35000;
        Item.rare = 7;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shootSpeed = 15f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/DarkCast1").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        int proj = Projectile.NewProjectile((IEntitySource)source, position, velocity, 96, damage, knockback, player.whoAmI, 0f, 0f);
        Main.projectile[proj].friendly = true;
        Main.projectile[proj].hostile = false;
        Main.projectile[proj].scale = 0.6f;
        return true;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(519);
        recipe.AddIngredient(518);
        recipe.AddIngredient(528, 2);
        recipe.AddIngredient(527, 2);
        recipe.AddTile(101);
        recipe.Register();
    }
}
