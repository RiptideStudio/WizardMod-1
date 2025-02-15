using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class InfusedCrystal : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Wizard's Crystal");
		// Tooltip.SetDefault("Permanently raises your max mana to 200\nCan only be used once");
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(109);
		Item.rare = 3;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "InfusedStar", 25);
		recipe.AddIngredient(null, "MagicSoul", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}

	public override bool CanUseItem(Player player)
	{
		return true;
	}

	public override bool? UseItem(Player player)
	{
		if (player.statManaMax < 200)
		{
			player.statManaMax = 200;
			return true;
		}
		return false;
	}
}
