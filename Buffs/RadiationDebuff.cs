using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class RadiationDebuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sharpened Arrows");
		//Description.SetDefault("Arrow damage increased by 10%");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.lifeRegen -= 35;
		int num370 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 75, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num370].velocity *= 0.2f;
		Main.dust[num370].scale = (float)Main.rand.Next(75, 125) * 0.013f;
		Main.dust[num370].noGravity = true;
		int num371 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 64, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num371].velocity *= 0.2f;
		Main.dust[num371].scale = (float)Main.rand.Next(75, 125) * 0.013f;
		Main.dust[num371].noGravity = true;
	}
}
