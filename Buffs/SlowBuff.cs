using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class SlowBuff : ModBuff
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
		npc.velocity.X = (float)Math.Sign(npc.direction) * 0.1f;
		npc.velocity.Y *= 0.92f;
		int num370 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 67, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num370].velocity *= 1.4f;
		Main.dust[num370].noGravity = true;
	}
}
