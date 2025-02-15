using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Buffs;

public class LightDebuff2 : ModBuff
{
	private int time;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sharpened Arrows");
		//Description.SetDefault("Arrow damage increased by 10%");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = false;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		this.time++;
		if (this.time % 60 == 0 && Main.LocalPlayer.ownedProjectileCounts[Mod.Find<ModProjectile>("HealingOrb2").Type] < 3)
		{
			this.time = 0;
			Player player = Main.LocalPlayer;
			Projectile.NewProjectile(player.GetSource_DropAsItem(), new Vector2(npc.position.X + 12f, npc.position.Y + 2f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("HealingOrb2").Type, 0, 0f, player.whoAmI, 0f, 0f);
		}
		int num370 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 246, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num370].velocity *= 1.4f;
		Main.dust[num370].noGravity = true;
	}
}
