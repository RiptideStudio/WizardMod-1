using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class AquaticFury : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Aquatic Fury");
        // Tooltip.SetDefault("\nFires a powerful blast of water\nReleases mini water-bolts on impact");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(165);
        Item.damage = 47;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 16;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.useStyle = 5;
        Item.knockBack = 3f;
        Item.value = 50000;
        Item.rare = 5;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("AquaticFuryProj1").Type;
        Item.shootSpeed = 5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        position += new Vector2(velocity.X * 3f, 0f);
        for (int i = 0; i < 5; i++)
        {
            Vector2 pos = new Vector2(10f, -10f);
            int xx = Main.rand.Next(-12, 12);
            int yy = Main.rand.Next(-12, 12);
            pos = ((player.direction != 1) ? new Vector2(-16f, -10f) : new Vector2(10f, -10f));
            int dust3 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 175);
            Dust.NewDust(position + pos + pos, Item.width + xx, Item.height + yy, 56);
            int dust4 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 211);
            Main.dust[dust3].noGravity = true;
            Main.dust[dust3].velocity *= 12f;
            Main.dust[dust4].noGravity = true;
            Main.dust[dust4].velocity *= 6f;
        }
        return true;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "WaterFront");
        recipe.AddIngredient(531);
        recipe.AddIngredient(null, "MagicSoul", 15);
        recipe.AddIngredient(548, 5);
        recipe.AddIngredient(547, 5);
        recipe.AddIngredient(549, 5);
        recipe.AddIngredient(319, 3);
        recipe.AddTile(null, "WizardTable");
        recipe.Register();
    }
}
