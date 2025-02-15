using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using WizardMod.World;

namespace WizardMod.Spells;

public class BestHealingSpell : ModItem
{
	private int splashHealAmount = 32;

	private int shot;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Greater Healing Spell");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(3105);
		Item.damage = 27;
		Item.rare = 5;
		Item.DamageType = DamageClass.Ranged;
		Item.maxStack = 999;
		Item.consumable = true;
		Item.mana = 0;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.value = 2500;
		Item.shoot = Mod.Find<ModProjectile>("BestHealingSpellProj").Type;
		Item.shootSpeed = 8f;
		Item.autoReuse = true;
	}

	public override bool CanUseItem(Player player)
	{
		if (!player.HasBuff(Mod.Find<ModBuff>("SpellDebuff").Type))
		{
			return true;
		}
		return false;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		this.shot++;
		if (this.shot <= 3 && !player.HasBuff(Mod.Find<ModBuff>("SpellDebuff").Type))
		{
			Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("BestHealingSpellProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		if (this.shot == 3)
		{
			player.AddBuff(Mod.Find<ModBuff>("SpellDebuff").Type, 180);
			this.shot = 0;
		}
		return false;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		Player player = Main.LocalPlayer;
		string sepText = "Splash heals players for " + (this.splashHealAmount + player.GetModPlayer<Global>().spellPower) + " health\nCreates a brief, lingering health cloud that heals " + (4 + player.GetModPlayer<Global>().spellPower / 2) + " health";
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

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(2);
		recipe.AddIngredient(null, "GreatHealingSpell", 2);
		recipe.AddIngredient(501, 5);
		recipe.AddTile(96);
		recipe.Register();
	}
}
