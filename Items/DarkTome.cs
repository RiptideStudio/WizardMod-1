using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DarkTome : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Dark Tome");
        // Tooltip.SetDefault("'Harness the power of dark magic'\nShoots a dark bolt of magic\nCauses enemies to decay");
    }

    public override void SetDefaults()
    {
        Item.damage = 16;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 4;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 32;
        Item.useAnimation = 32;
        Item.useStyle = 5;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 1;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("DarkProj").Type;
        Item.shootSpeed = 3.5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_0031: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/DarkCast1").WithPitchOffset(Main.rand.NextFloat(0f, 0.4f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        return true;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(149);
        recipe.AddIngredient(null, "MagicSoul", 5);
        recipe.AddTile(101);
        recipe.Register();
    }
}
