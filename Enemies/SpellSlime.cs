using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace WizardMod.Enemies;

public class SpellSlime : ModNPC
{
	private bool allowed = true;

	private int time;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Spell Slime");
		Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
	}

	public override void SetDefaults()
	{
		NPC.width = 32;
		NPC.height = 15;
		NPC.damage = 8;
		NPC.defense = 0;
		NPC.lifeMax = 27;
		NPC.value = 500f;
		NPC.aiStyle = 1;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		AIType = -3;
		AnimationType = -3;
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
	}

	public override void AI()
	{
		if (Main.rand.Next(0, 4) == 1)
		{
			Main.rand.Next(16);
			Main.rand.Next(12);
			int dust3 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 21, 0f, 0f, 100, Color.Blue, 1.5f);
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
			Player player = Main.LocalPlayer;
			NPC.TargetClosest();
			if ((player.Center - NPC.Center).Length() < 240f)
			{
				float projectileSpeed = 3f;
				float knockBack = 3f;
				int type = Mod.Find<ModProjectile>("SpellSlimeProj").Type;
				Vector2 velocity = Vector2.Normalize(new Vector2(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2)) - new Vector2(NPC.position.X + (float)(NPC.width / 2), NPC.position.Y + (float)(NPC.height / 2))) * projectileSpeed;
				Projectile.NewProjectile(NPC.GetSource_ReleaseEntity(), NPC.position.X + (float)(NPC.width / 2), NPC.position.Y + (float)(NPC.height / 2), velocity.X, velocity.Y, type, 4, knockBack, Main.myPlayer, 0f, 0f);
			}
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
		for (int i = 0; i < Main.rand.Next(3, 6); i++)
		{
			Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), Mod.Find<ModItem>("MagicSoul").Type);
		}
		if (Main.rand.Next(0, 3) == 1 && NPC.downedBoss1)
		{
			Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), Mod.Find<ModItem>("EnchantedShard").Type, Main.rand.Next(1, 3));
		}
	}
}
