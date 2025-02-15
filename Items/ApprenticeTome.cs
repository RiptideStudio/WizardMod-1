using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using WizardMod.World;

namespace WizardMod.Items;

public class ApprenticeTome : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Inept Tome");
        // Tooltip.SetDefault("Shoots a weak magic bolt\nInflicts Cleansing debuff, which causes enemies to release healing orbs\nHealing orb power scales with spell power");
    }

    public override void SetDefaults()
    {
        Item.damage = 15;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 4;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.useStyle = 5;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 1;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("ApprenticeProj").Type;
        Item.shootSpeed = 3.5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_0043: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(30f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)player.position);
        return true;
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        Player player = Main.LocalPlayer;
        string sepText = "Heals ally life by " + player.GetModPlayer<Global>().spellPower;
        tooltips.Add(new TooltipLine(Mod, "name", sepText));
    }

    public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
    {
        if (!line.OneDropLogo)
        {
            Player player = Main.player[Main.myPlayer];
            float sepHeight = 0f;
            if (line.Name == "ItemName" && line.Mod == "Terraria")
            {
                float drawX = (float)line.X + line.Font.MeasureString(line.Text).X;
                float drawY = line.Y;
                new Color(100, 100, 255);
                ChatManager.DrawColorCodedStringWithShadow(baseColor: new Color(100, 255, 100), spriteBatch: Main.spriteBatch, font: line.Font, text: " (" + player.GetModPlayer<Global>().spellPower + " Spell power)", position: new Vector2(drawX, drawY), rotation: line.Rotation, origin: line.Origin, baseScale: line.BaseScale, maxWidth: line.MaxWidth, spread: line.Spread);
                yOffset = (int)sepHeight;
            }
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
        recipe.AddIngredient(149);
        recipe.AddIngredient(null, "MagicSoul", 5);
        recipe.AddTile(101);
        recipe.Register();
    }
}
