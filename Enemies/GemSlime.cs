using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace WizardMod.Enemies;

public class GemSlime : ModNPC
{
	private bool allowed = true;

	private int time;

	public override void SetStaticDefaults()
	{
		Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
	}

	public override void SetDefaults()
	{
		NPC.width = 32;
		NPC.height = 15;
		NPC.damage = 16;
		NPC.defense = 3;
		NPC.lifeMax = 60;
		NPC.knockBackResist = 0.33f;
		NPC.value = 500f;
		NPC.aiStyle = 1;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		AIType = -7;
		AnimationType = -6;
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		return SpawnCondition.Cavern.Chance * 0.25f;
	}

	public override void AI()
	{
		if (Main.rand.Next(0, 4) == 1)
		{
			Main.rand.Next(16);
			Main.rand.Next(12);
			int dust3 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 43, 0f, 0f, 100, Color.Blue, 1.5f);
			Main.dust[dust3].noGravity = true;
			Main.dust[dust3].velocity *= 0f;
			Main.dust[dust3].scale *= 0.75f;
		}
		this.time++;
		if (this.time >= 601)
		{
			this.time = 0;
		}
		if (this.time % 150 == 0 && this.allowed)
		{
			_ = Main.LocalPlayer;
			NPC.TargetClosest();
		}
	}

	public override void FindFrame(int frameHeight)
	{
		NPC.frameCounter += 1.0;
		if (NPC.frameCounter >= 20.0)
		{
			NPC.frameCounter = 0.0;
		}
		NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
	}

	public override void OnKill()
	{
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 23);
		for (int i = 0; i < Main.rand.Next(4, 8); i++)
		{
			Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		Main.rand.Next(1, 4);
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 181, Main.rand.Next(1, 4));
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 180, Main.rand.Next(1, 4));
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 179, Main.rand.Next(1, 3));
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 177, Main.rand.Next(1, 3));
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 178, Main.rand.Next(0, 3));
		Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), 182, Main.rand.Next(0, 3));
	}
}
