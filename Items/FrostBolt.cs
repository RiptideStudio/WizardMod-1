using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class FrostBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Permafrost");
        // Tooltip.SetDefault("Rapidly launches bolts of ice\nHas a chance to freeze weaker enemies");
    }

    public override void SetDefaults()
    {
        Item.damage = 12;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 8;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 16;
        Item.useAnimation = 16;
        Item.useStyle = 5;
        Item.knockBack = 1.5f;
        Item.value = 10000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 6f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 8f, position.Y), velocity, Mod.Find<ModProjectile>("IceBoltProj").Type, damage, knockback, player.whoAmI, 2f, 2f);
        return false;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(2f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "EnchantedBook");
        recipe.AddIngredient(null, "FrozenShard", 2);
        recipe.AddIngredient(2503, 25);
        recipe.AddTile(101);
        recipe.Register();
    }
}
