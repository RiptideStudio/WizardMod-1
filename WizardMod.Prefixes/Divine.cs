using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace bowmod.Prefixes;

public class Divine : ModPrefix
{
	private readonly byte _power;

	public override PrefixCategory Category => PrefixCategory.Magic;

	public override float RollChance(Item item)
	{
		return 1f;
	}

	public override bool CanRoll(Item item)
	{
		return true;
	}

	public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
	{
		damageMult += 0.17f;
		useTimeMult -= 0.12f;
		critBonus += 7;
		manaMult -= 0.12f;
		knockbackMult += 0.17f;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		ModContent.PrefixType<Divine>();
		return true;
	}

	public override void Apply(Item item)
	{
		item.GetGlobalItem<GlobalItemList>().awesome = (int)this._power;
	}

	public override void ModifyValue(ref float valueMult)
	{
		_ = this._power;
		valueMult = 1.5f;
	}
}
