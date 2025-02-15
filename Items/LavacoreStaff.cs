using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class LavacoreStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Lavacore Staff");
        // Tooltip.SetDefault("Launches a volley of frozen and flaming rocks");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(3870);
        Item.damage = 42;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 21;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.useStyle = 5;
        Item.knockBack = 7f;
        Item.value = 100000;
        Item.rare = 5;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("EbonwoodProj").Type;
        Item.shootSpeed = 11f;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num371 = 0; num371 < 7; num371++)
        {
            int num374 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 213, 0f, 0f, 100, default(Color), 2.5f);
            Main.dust[num374].noGravity = true;
            Main.dust[num374].velocity *= 5f;
            num374 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 135, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num374].velocity *= 3f;
        }
        for (int num372 = 0; num372 < 7; num372++)
        {
            int num373 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2.5f);
            Main.dust[num373].noGravity = true;
            Main.dust[num373].velocity *= 5f;
            num373 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num373].velocity *= 3f;
        }
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 8f, position.Y), velocity, Mod.Find<ModProjectile>("FrozenProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + 8f, position.Y), velocity, Mod.Find<ModProjectile>("FrozenProj2").Type, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + 8f, position.Y), velocity, Mod.Find<ModProjectile>("AshenProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X - 8f, position.Y), velocity, Mod.Find<ModProjectile>("AshenProj2").Type, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "AshenStaff");
        recipe.AddIngredient(null, "Hailstorm");
        recipe.AddIngredient(520, 5);
        recipe.AddIngredient(521, 5);
        recipe.AddTile(134);
        recipe.Register();
    }
}
