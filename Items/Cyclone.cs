using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Cyclone : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("The Cyclone");
        // Tooltip.SetDefault("Left-click to cast countless forks of lightning\nRight-click to drop a devastating thunderbolt for 25 mana\nLightning coils jump to a nearby enemy");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 41;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 16;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.useStyle = 5;
        Item.knockBack = 5f;
        Item.value = 200000;
        Item.rare = 6;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("StormSenderProj").Type;
        Item.shootSpeed = 60f;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y;
        player.itemLocation.X = player.Center.X - (float)(4 * player.direction);
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.mana = 25;
            Item.useTime = 35;
            Item.useAnimation = 35;
        }
        else
        {
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.mana = 16;
        }
        return base.CanUseItem(player);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_00ce: Unknown result type (might be due to invalid IL or missing references)
        Vector2 pos = new Vector2((float)Main.mouseX + Main.screenPosition.X, player.position.Y - 512f);
        if (player.altFunctionUse == 2)
        {
            Projectile.NewProjectile((IEntitySource)source, pos, new Vector2(0f, 20f), Mod.Find<ModProjectile>("ThunderboltStrike").Type, damage * 2, knockback, player.whoAmI, 0f, 0f);
        }
        else
        {
            int numberProjectiles = 3 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/ElectricZap").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
                SoundEngine.PlaySound(soundStyle, (Vector2?)position);
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30f));
                Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("CycloneLightning").Type, damage, knockback, player.whoAmI, 0f, 0f);
            }
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "StormSender");
        recipe.AddIngredient(null, "LunarBar", 5);
        recipe.AddIngredient(575, 15);
        recipe.AddTile(null, "WizardTable");
        recipe.Register();
    }
}
