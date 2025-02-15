using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Items;

public class EnchantedGauntlet : ModItem
{
    private bool charged;

    private int time;

    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Enchanted Gauntlet");
        // Tooltip.SetDefault("Left-click to launch your fist\nRight-click to temporarily charge your fist for 10 mana");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(368);
        Item.damage = 23;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 13;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = 5;
        Item.knockBack = 6f;
        Item.value = 20000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = SoundID.Item102;
        Item.autoReuse = true;
        Item.shootSpeed = 18f;
        Item.shoot = 0;
    }

    public override bool CanUseItem(Player player)
    {
        //IL_0029: Unknown result type (might be due to invalid IL or missing references)
        if (player.altFunctionUse == 2)
        {
            if (player.statMana >= 10)
            {
                SoundEngine.PlaySound(SoundID.Item122, (Vector2?)player.position);
                Projectile.NewProjectile(player.GetSource_DropAsItem(), new Vector2(player.position.X + 12f, player.position.Y + 24f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("EnchantedGauntletShield").Type, 0, 3f, player.whoAmI, 0f, 0f);
                time = 0;
                charged = true;
                Item.useStyle = 5;
                Item.noUseGraphic = false;
                Item.mana = 0;
                Item.UseSound = SoundID.Item1;
                Item.noMelee = true;
                Item.shoot = 0;
                player.statMana -= 10;
            }
        }
        else
        {
            if (charged)
            {
                Item.shootSpeed = 20f;
            }
            Item.useStyle = 5;
            Item.noUseGraphic = true;
            Item.mana = 13;
            if (player.GetModPlayer<Global>().enchantedArmor)
            {
                Item.mana = 6;
            }
            Item.UseSound = SoundID.Item102;
            Item.noMelee = true;
            Item.shoot = 1;
        }
        return base.CanUseItem(player);
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override void HoldItem(Player player)
    {
        if (charged)
        {
            time++;
            if (time > 150)
            {
                time = 0;
                charged = false;
                Item.shootSpeed = 18f;
            }
        }
        Item.DamageType = DamageClass.Magic;
        if (player.GetModPlayer<Global>().enchantedArmor)
        {
            Item.mana = 7;
        }
        else
        {
            Item.mana = 13;
        }
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (player.altFunctionUse != 2)
        {
            if (charged)
            {
                Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("EnchantedGauntletCharged").Type, (int)((double)damage * 1.5), knockback, player.whoAmI, 0f, 0f);
            }
            else
            {
                Projectile.NewProjectile((IEntitySource)source, position, new Vector2(velocity.X * 0.75f, velocity.Y * 0.75f), Mod.Find<ModProjectile>("EnchantedGauntletProjectile").Type, damage, knockback, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "EnchantedShard", 12);
        recipe.AddIngredient(57, 5);
        recipe.AddIngredient(178);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
