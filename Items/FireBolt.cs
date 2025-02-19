using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class FireBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Magma Wave");
        // Tooltip.SetDefault("Shoots a slow moving wave of magma");
    }

    public override void SetDefaults()
    {
        Item.damage = 15;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 6;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 27;
        Item.useAnimation = 27;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 10000;
        Item.rare = 2;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 3.75f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile((IEntitySource)source, new Vector2(position.X + 12f, position.Y + 4f), velocity, Mod.Find<ModProjectile>("FireBoltProj").Type, damage, knockback, player.whoAmI, 2f, 2f);
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
        recipe.AddIngredient(null, "MagicSoul", 3);
        recipe.AddIngredient(null, "MoltenShard");
        recipe.AddTile(101);
        recipe.Register();
    }
}
