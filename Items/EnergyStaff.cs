using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using WizardMod.World;

namespace WizardMod.Items;

public class EnergyStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Ancient Wand");
        // Tooltip.SetDefault("\nCreates a healing rune around the cursor that scales with spell power\nAny enemies that touch the rune are poisoned");
        Item.staff[Item.type] = true;
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        Player player = Main.LocalPlayer;
        string sepText = "Heals player life by " + player.GetModPlayer<Global>().spellPower + " every 2 seconds";
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
            else
            {
                yOffset = 0;
            }
        }
        return true;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y + 2f;
        player.itemLocation.X = player.Center.X - (float)(2 * player.direction);
    }

    public override void SetDefaults()
    {
        Item.DamageType = DamageClass.Magic;
        Item.mana = 100;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 34;
        Item.useAnimation = 34;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 100000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("EnergyProj").Type;
        Item.shootSpeed = 5.5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_00cf: Unknown result type (might be due to invalid IL or missing references)
        if (Main.LocalPlayer.ownedProjectileCounts[Mod.Find<ModProjectile>("EnergyProj").Type] > 0)
        {
            for (int i = 0; i < 255; i++)
            {
                if (Main.projectile[i].type == Mod.Find<ModProjectile>("EnergyProj").Type)
                {
                    Main.projectile[i].Kill();
                }
                if (Main.projectile[i].type == Mod.Find<ModProjectile>("EnergyProjMiddle").Type)
                {
                    Main.projectile[i].Kill();
                }
            }
        }
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/SpellCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        Vector2 projPos = new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y);
        Projectile.NewProjectile((IEntitySource)source, projPos, new Vector2(0f, 0f), Mod.Find<ModProjectile>("EnergyProj").Type, 0, knockback, player.whoAmI, 2f, 2f);
        Projectile.NewProjectile((IEntitySource)source, projPos, new Vector2(0f, 0f), Mod.Find<ModProjectile>("EnergyProjMiddle").Type, 0, knockback, player.whoAmI, 2f, 2f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(620, 25);
        recipe.AddIngredient(331, 12);
        recipe.AddIngredient(210, 3);
        recipe.AddIngredient(null, "LivingShard", 5);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
