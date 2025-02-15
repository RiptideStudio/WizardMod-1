using System;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.World;

public class BuffGlobal : GlobalBuff
{
	private int time;

	public override void Update(int type, NPC npc, ref int buffIndex)
	{
		this.time++;
		if (!Main.player[Main.myPlayer].GetModPlayer<Global>().chaosEnchantment)
		{
			return;
		}
		for (int i = 0; i < 200; i++)
		{
			NPC target = Main.npc[i];
			int dist = 176;
			float num = npc.position.X + (float)target.width * 0.5f - target.Center.X;
			float poisonToY = npc.position.Y - target.Center.Y;
			float PoisonDistance = (float)Math.Sqrt((double)(num * num + poisonToY * poisonToY));
			if (!target.friendly && PoisonDistance < (float)dist && this.time % 60 == 0)
			{
				if (target != npc && target.buffType[buffIndex] != npc.buffType[buffIndex] && npc.buffType[buffIndex] != Mod.Find<ModBuff>("SlowBuff").Type)
				{
					target.AddBuff(npc.buffType[buffIndex], 59);
				}
				this.time = 0;
			}
		}
	}
}
