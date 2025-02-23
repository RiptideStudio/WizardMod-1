using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Hailstorm : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Hailstorm");
        // Tooltip.SetDefault("Rapidly rains frozen bombs from the sky");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 23;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 8;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = 5;
        Item.knockBack = 2f;
        Item.value = 20000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("IcicleProj").Type;
        Item.shootSpeed = 5f;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X + (float)(2 * player.direction);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        for (int j = 0; j < Main.rand.Next(1, 3); j++)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 1; i++)
            {
                position = player.Center + new Vector2((0f - (float)Main.rand.Next(0, 250)) * (float)player.direction, -600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= velocity.Length();
                velocity.X = heading.X;
                velocity.Y = heading.Y + 9f;
                Vector2 newPos = new Vector2((float)Main.mouseX + Main.screenPosition.X, position.Y);
                Vector2 newvel = new Vector2(Main.rand.Next(-3, 3), velocity.Y * 2.1f);
                Projectile.NewProjectile((IEntitySource)source, newPos, newvel, Mod.Find<ModProjectile>("IcicleProj").Type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "FrozenShard", 5);
        recipe.AddIngredient(2358, 3);
        recipe.AddIngredient(86, 12);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
        Recipe recipe2 = CreateRecipe();
        recipe2.AddIngredient(null, "FrozenShard", 5);
        recipe2.AddIngredient(2358, 3);
        recipe2.AddIngredient(1329, 12);
        recipe2.AddTile(null, "ArcaneTable");
        recipe2.Register();
    }
}
