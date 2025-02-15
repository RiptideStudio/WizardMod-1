using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class ElectrifiedBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Electrified");
		//Description.SetDefault("You are charged with electricity");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		if (Main.rand.Next(0, 3) == 1)
		{
			int num370 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 21, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
	}
}
