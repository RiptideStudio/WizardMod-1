using Terraria;
using Terraria.ID;
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
		Item.CloneDefaults(ItemID.ManaCrystal);
		Item.rare = ItemRarityID.Orange;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "InfusedStar", 50);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}

    public override bool ConsumeItem(Player player)
    {
        if (player.statManaMax < 200)
        {
            player.statManaMax = 200;
			return true;
        }
		return false;
    }
}
