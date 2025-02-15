using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DemonGauntlet : ModItem
{
    private bool style = false;

    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Dread Cutter [Unfinished]");
        // Tooltip.SetDefault("Left-click to jab and swing at enemies\nRight-click to slash multiple enemies");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(368);
        Item.damage = 21;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 8;
        Item.width = 48;
        Item.height = 16;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.useStyle = 5;
        Item.knockBack = 6.5f;
        Item.value = 20000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.noUseGraphic = false;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.shootSpeed = 12f;
        Item.shoot = 0;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 8f);
    }

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.useStyle = 1;
            Item.mana = 0;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.useTime = 10;
            Item.shoot = Mod.Find<ModProjectile>("DemonGauntletProjectile").Type;
            Item.useAnimation = 10;
        }
        else
        {
            Item.noMelee = false;
            Item.shoot = 0;
            Item.width = 40;
            if (style) Item.useStyle = ItemUseStyleID.Swing;
            else Item.useStyle = ItemUseStyleID.Thrust;
            style = !style;
            Item.mana = 0;
            Item.UseSound = SoundID.Item7;
            Item.useTime = 15;
            Item.useAnimation = 15;
        }
        return base.CanUseItem(player);
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(57, 12);
        recipe.AddIngredient(null, "MagicSoul", 5);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
