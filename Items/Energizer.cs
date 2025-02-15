using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Energizer : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Energy Blaster");
        // Tooltip.SetDefault("Launches green spheres of energy that explode into miniature homing particles");
    }

    public override void SetDefaults()
    {
        Item.damage = 25;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 12;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 32;
        Item.useAnimation = 32;
        Item.useStyle = 5;
        Item.knockBack = 1f;
        Item.value = 100000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 20;
        Item.shootSpeed = 12f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(2f, 0f);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnergizerShoot").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        Vector2 pos = new Vector2(10f, -10f);
        for (int i = 0; i < 6; i++)
        {
            int xx = Main.rand.Next(-12, 12);
            int yy = Main.rand.Next(-12, 12);
            pos = ((player.direction != 1) ? new Vector2(-16f, -10f) : new Vector2(10f, -10f));
            int dust3 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 75);
            Dust.NewDust(position + pos + pos, Item.width + xx, Item.height + yy, 107);
            int dust4 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 75);
            Main.dust[dust3].noGravity = true;
            Main.dust[dust3].velocity *= 12f;
            Main.dust[dust4].noGravity = true;
            Main.dust[dust4].velocity *= 6f;
        }
        Vector2 newPos = new Vector2(position.X - 4f, position.Y);
        Projectile.NewProjectile((IEntitySource)source, newPos, velocity, Mod.Find<ModProjectile>("EnergizerLaser").Type, damage, knockback, player.whoAmI, 2f, 2f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(127);
        recipe.AddIngredient(57, 12);
        recipe.AddIngredient(86, 8);
        recipe.AddIngredient(null, "LivingShard", 5);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
        Recipe recipe2 = CreateRecipe();
        recipe2.AddIngredient(127);
        recipe2.AddIngredient(1257, 12);
        recipe2.AddIngredient(1329, 8);
        recipe2.AddIngredient(null, "LivingShard", 5);
        recipe2.AddTile(null, "ArcaneTable");
        recipe2.Register();
    }
}
