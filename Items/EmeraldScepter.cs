using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class EmeraldScepter : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Emerald Scepter");
        // Tooltip.SetDefault("Sprays your enemies with emerald water");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 14;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 9;
        Item.width = 16;
        Item.height = 24;
        Item.useTime = 14;
        Item.useAnimation = 14;
        Item.channel = true;
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
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        position += new Vector2(velocity.X * 15f, velocity.Y * 15f);
        Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("EmeraldBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(742);
        recipe.AddIngredient(null, "InfusedStar", 3);
        recipe.AddIngredient(null, "EnchantedShard");
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
