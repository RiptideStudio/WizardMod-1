using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Items;

public class EnchantedTome : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 22;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 8;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = 5;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 4f;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.GetModPlayer<Global>().enchantedArmor)
        {
            Item.mana = 4;
        }
        else
        {
            Item.mana = 8;
        }
        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("MagicProjBasic").Type, damage, knockback, player.whoAmI, 2f, 2f);
        return false;
    }

    public override void HoldItem(Player player)
    {
        if (player.GetModPlayer<Global>().enchantedArmor)
        {
            Item.mana = 4;
        }
        else
        {
            Item.mana = 8;
        }
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "EnchantedBook");
        recipe.AddIngredient(null, "EnchantedShard", 15);
        recipe.AddTile(101);
        recipe.Register();
    }
}
