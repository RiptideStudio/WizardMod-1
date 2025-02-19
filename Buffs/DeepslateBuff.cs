using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class DeepslateBuff : ModBuff
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
		npc.lifeRegen -= 25;
		int num370 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 54, 0f, 0f, 100, default(Color), 1.5f);
		int num371 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, DustID.FlameBurst, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num370].velocity *= 1.4f;
		Main.dust[num370].noGravity = true;
		Main.dust[num371].noGravity = true;
		Main.dust[num371].noGravity = true;
	}
}
