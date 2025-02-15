using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace bowmod.Prefixes;

public class Blessed : ModPrefix
{
	private readonly byte _power;

	public override PrefixCategory Category => PrefixCategory.Magic;

	public override float RollChance(Item item)
	{
		return 3f;
	}

	public override bool CanRoll(Item item)
	{
		return true;
	}

	public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
	{
		manaMult -= 0.25f;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		ModContent.PrefixType<Blessed>();
		return true;
	}

	public override void Apply(Item item)
	{
		item.GetGlobalItem<GlobalItemList>().awesome = (int)this._power;
	}

	public override void ModifyValue(ref float valueMult)
	{
		_ = this._power;
		valueMult = 1.25f;
	}
}
