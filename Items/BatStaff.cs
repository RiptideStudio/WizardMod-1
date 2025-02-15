using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class BatStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Bat-Swarm Staff");
        // Tooltip.SetDefault("Casts a ball of poisonus gunk that causes bats to swarm the enemy");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(3870);
        Item.damage = 14;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 4;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = 5;
        Item.knockBack = 2f;
        Item.value = 10000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("BatOrbProj").Type;
        Item.shootSpeed = 8.5f;
    }
}
