using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Dusts;

public class LifeDust : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		dust.velocity.Y *= 0.6f;
		dust.velocity.X *= 0.3f;
		dust.noGravity = true;
		dust.noLight = false;
		dust.scale *= 1f;
	}

	public override bool Update(Dust dust)
	{
		dust.scale *= 0.99f;
		dust.position += dust.velocity;
		dust.rotation += dust.velocity.X * 0.05f;
		if (dust.scale <= 0f)
		{
			dust.active = false;
		}
		return false;
	}
}
