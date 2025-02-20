using ArcheryOverhaul.World;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Server;
using WizardMod.Accessories;
using WizardMod.Consumable;
using WizardMod.Items;
using WizardMod.Materials;
using WizardMod.Scrolls;
using WizardMod.Spells;

namespace WizardMod.NPCs;

[AutoloadHead]
public class Apprentice : ModNPC
{
	private bool scrap;

    public override void SetStaticDefaults()
    {
        NPC.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Like);
        NPC.Happiness.SetNPCAffection(NPCID.Princess, AffectionLevel.Love);
        NPC.Happiness.SetNPCAffection(NPCID.Princess, AffectionLevel.Like);
    }

    public override void SetDefaults()
	{
		NPC.townNPC = true;
		NPC.friendly = true;
		NPC.width = 18;
		NPC.height = 46;
		NPC.aiStyle = 7;
		NPC.defense = 25;
		NPC.lifeMax = 250;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.knockBackResist = 0.5f;
		Main.npcFrameCount[NPC.type] = 25;
		NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
		NPCID.Sets.AttackFrameCount[NPC.type] = 1;
		NPCID.Sets.DangerDetectRange[NPC.type] = 300;
		NPCID.Sets.AttackType[NPC.type] = 2;
		NPCID.Sets.AttackTime[NPC.type] = 30;
		NPCID.Sets.AttackAverageChance[NPC.type] = 10;
		NPCID.Sets.HatOffsetY[NPC.type] = 4;
		AnimationType = 22;
	}

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("The Sorcerer's Apprentice, trained by none other than Balthazar himself."),
            });
    }

    public override bool CanTownNPCSpawn(int numTownNPCs)
    {
        if (TownNPCRespawnSystem.unlockedApprentice)
        {
            return true;
        }

        for (int i = 0; i < 255; i++)
        {
            Player player = Main.player[i];
            if (player.statMana >= 40)
            {
				return true;
            }
        }
        return false;
    }


    public override List<string> SetNPCNameList()
	{
		return new List<string> { "Xion", "Tom", "Severus", "Alatar", "Alzeus" };
	}

	public override void SetChatButtons(ref string button, ref string button2)
	{
		button = "Shop";
		button2 = "Trade Magic Essence";
	}
    public override void AddShops()
    {
        NPCShop shop = new(NPC.type, "Shop");
        shop.Add(ModContent.ItemType<PocketFireball>(), []);
        shop.Add(ModContent.ItemType<EnchantedDagger>(), [Condition.DownedKingSlime]);
        shop.Add(ModContent.ItemType<GlassVial>(), []);
        shop.Add(ModContent.ItemType<Scroll>(), [Condition.DownedEowOrBoc]);
        shop.Add(ModContent.ItemType<CharredScroll>(), [Condition.DownedEyeOfCthulhu]);
        shop.Add(ModContent.ItemType<IceScroll>(), []);
        shop.Add(ModContent.ItemType<ArcaneOrb>(), []);
        shop.Add(ItemID.FallenStar, [Condition.TimeNight]);
        shop.Add(ItemID.Amethyst, []);
        shop.Add(ItemID.Topaz, []);
        shop.Add(ItemID.Sapphire, []);
        shop.Add(ItemID.Emerald, []);
        shop.Add(ItemID.Ruby, [Condition.DownedEyeOfCthulhu]);
        shop.Add(ItemID.Diamond, [Condition.DownedEyeOfCthulhu]);
        shop.Add(ItemID.Amber, [Condition.DownedEowOrBoc]);
        shop.Add(ModContent.ItemType<HealVialSpell>(), [Condition.DownedEyeOfCthulhu]);
        shop.Add(ModContent.ItemType<ManaSpell>(), []);
        shop.Add(ModContent.ItemType<GreatHealingSpell>(), [Condition.DownedEowOrBoc]);
        shop.Add(ModContent.ItemType<GreaterManaSpell>(), [Condition.DownedEowOrBoc]);

        shop.Register();
    }

    public override void OnChatButtonClicked(bool firstButton, ref string shopName)
    {
		if (firstButton)
		{
			shopName = "Shop";
			return;
		}
		for (int h = 0; h < 200; h++)
		{
			Player player = Main.player[h];
			if (!player.active)
			{
				continue;
			}
			Item[] inventory = player.inventory;
			foreach (Item item in inventory)
			{
				if (item.type != Mod.Find<ModItem>("MagicSoul").Type)
				{
					continue;
				}
				item.stack--;
				Main.npcChatText = "Ah, magic essence! Here is your reimbursement.";
				int table = Main.rand.Next(1, 9);
				Main.rand.Next(0, 100);
				int num_low = Main.rand.Next(1, 3);
				int num_medium = Main.rand.Next(3, 5);
				int num_high = Main.rand.Next(5, 8);
				Main.rand.Next(16, 21);
				if (Main.rand.Next(0, 100) > 98)
				{
					Main.npcChatText = "Looks like you've found something rare!";
					Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 238);
				}
				if (Main.rand.Next(0, 100) == 2)
				{
					Main.npcChatText = "Looks like you've found something rare!";
					Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 2279);
				}
				if (Main.rand.Next(0, 350) == 1)
				{
					Main.npcChatText = "Oh my! Looks like you've found Xion's Tome!\nSeems like it needs to be repaired, though.";
					Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("XionTomeDamaged").Type);
				}
				if (Main.rand.Next(0, 100) > 90 && NPC.downedBoss1)
				{
					for (int i27 = 0; i27 < num_low; i27++)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("EnchantedShard").Type);
					}
				}
				if (Main.rand.Next(0, 100) < 8)
				{
					for (int i26 = 0; i26 < num_low; i26++)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("EnchantedSilk").Type);
					}
				}
				if (Main.rand.Next(0, 100) < 3)
				{
					Main.npcChatText = "Looks like you've found something uncommon!";
					int num2 = Main.rand.Next(1, 7);
					if (num2 == 1)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 739);
					}
					if (num2 == 2)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 740);
					}
					if (num2 == 3)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 741);
					}
					if (num2 == 4)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 742);
					}
					if (num2 == 5)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 743);
					}
					if (num2 == 6 && NPC.downedBoss1)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 744);
					}
				}
				if (Main.rand.Next(0, 100) < 3)
				{
					Main.npcChatText = "Looks like you've found something uncommon!";
					int num3 = Main.rand.Next(1, 7);
					if (num3 == 1)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1282);
					}
					if (num3 == 2)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1283);
					}
					if (num3 == 3)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1284);
					}
					if (num3 == 4)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1285);
					}
					if (num3 == 5)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1286);
					}
					if (num3 == 6)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1287);
					}
				}
				if (Main.rand.Next(0, 200) > 198)
				{
					Main.npcChatText = "Looks like you've found something rare!";
					for (int i25 = 0; i25 < 1; i25++)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 555);
					}
				}
				if (Main.rand.Next(0, 200) > 198)
				{
					Main.npcChatText = "Looks like you've found something rare!";
					for (int i24 = 0; i24 < 1; i24++)
					{
						Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 2219);
					}
				}
				if (Main.rand.Next(0, 200) > 198)
				{
					Main.npcChatText = "Looks like you've found something rare!";
					Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 64);
				}
				if (Main.rand.Next(0, 250) == 1)
				{
					Main.npcChatText = "Looks like you've found something rare!";
					Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1810);
				}
				if (NPC.downedBoss1)
				{
					if (Main.rand.Next(0, 100) > 75)
					{
						for (int i21 = 0; i21 < num_low; i21++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 189);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) > 75)
					{
						for (int i20 = 0; i20 < num_low; i20++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 188);
						}
					}
					num_low = Main.rand.Next(1, 4);
				}
				else
				{
					if (Main.rand.Next(0, 100) > 75)
					{
						for (int i23 = 0; i23 < num_low; i23++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 110);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) > 75)
					{
						for (int i22 = 0; i22 < num_low; i22++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 28);
						}
					}
					num_low = Main.rand.Next(1, 4);
				}
				if (table == 1)
				{
					if (Main.rand.Next(0, 100) < 66)
					{
						for (int i19 = 0; i19 < num_low; i19++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 181);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 50)
					{
						for (int i18 = 0; i18 < num_medium; i18++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("InfusedStar").Type);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) > 80 && NPC.downedBoss1)
					{
						for (int i17 = 0; i17 < num_low; i17++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 182);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int i16 = 0; i16 < num_medium; i16++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 179);
						}
					}
				}
				if (table == 2)
				{
					int num_low_3 = Main.rand.Next(1, 3);
					if (Main.rand.Next(0, 100) < 70)
					{
						for (int i15 = 0; i15 < num_low_3; i15++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 180);
						}
					}
					if (Main.rand.Next(0, 100) < 20)
					{
						for (int i14 = 0; i14 < num_high; i14++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("GlassVial").Type);
						}
					}
					num_low_3 = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 25)
					{
						for (int i13 = 0; i13 < num_low_3; i13++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 22);
						}
					}
					num_low_3 = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 10)
					{
						for (int i12 = 0; i12 < 1; i12++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("FrozenShard").Type);
						}
					}
				}
				if (table == 3)
				{
					if (Main.rand.Next(0, 100) < 85)
					{
						for (int i11 = 0; i11 < num_low; i11++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 177);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 33)
					{
						for (int i10 = 0; i10 < num_medium; i10++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 19);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 20)
					{
						for (int i9 = 0; i9 < num_low; i9++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("ManaSpell").Type);
						}
					}
				}
				if (table == 4)
				{
					if (Main.rand.Next(0, 100) < 40)
					{
						for (int i8 = 0; i8 < num_low; i8++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 178);
						}
					}
					num_low = Main.rand.Next(1, 4);
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 25)
					{
						for (int i7 = 0; i7 < num_low + 1; i7++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("Scroll").Type);
						}
					}
					num_low = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int i6 = 0; i6 < num_medium - 1; i6++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("CharredScroll").Type);
						}
					}
					num_low = Main.rand.Next(1, 4);
				}
				if (table == 5)
				{
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int i5 = 0; i5 < 1; i5++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 225);
						}
					}
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int i4 = 0; i4 < num_medium - 1; i4++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("IceScroll").Type);
						}
					}
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int i3 = 0; i3 < 1; i3++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 3093);
						}
					}
				}
				if (table == 6)
				{
					if (Main.rand.Next(0, 100) < 75)
					{
						for (int i2 = 0; i2 < Main.rand.Next(1, 3); i2++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("HoneySpell").Type);
						}
					}
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int n = 0; n < num_low; n++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("LivingShard").Type);
						}
					}
					if (Main.rand.Next(0, 100) < 10)
					{
						for (int m = 0; m < num_low; m++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("SkyCrystal").Type);
						}
					}
				}
				if (table == 7)
				{
					int num_low_2 = Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) > 96)
					{
						for (int l = 0; l < 1; l++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 1239);
						}
					}
					if (Main.rand.Next(0, 100) < 25 && NPC.downedBoss1)
					{
						for (int k = 0; k < num_low_2; k++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 57);
						}
					}
				}
				if (table == 8)
				{
					Main.rand.Next(1, 4);
					if (Main.rand.Next(0, 100) < 15)
					{
						for (int j = 0; j < num_low; j++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("MagmaShard").Type);
						}
					}
					if (Main.rand.Next(0, 100) < 40)
					{
						for (int i = 0; i < num_low; i++)
						{
							Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("HealVialSpell").Type);
						}
					}
				}
				int coinCopperAmount = Main.rand.Next(17, 26);
				int coinSilverAmount = Main.rand.Next(0, 2);
				Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), Mod.Find<ModItem>("PocketFireball").Type, Main.rand.Next(4, 13));
				Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 71, coinCopperAmount);
				Main.LocalPlayer.QuickSpawnItem(Terraria.Entity.GetSource_NaturalSpawn(), 72, coinSilverAmount);
				this.scrap = true;
			}
		}
	}

	public override string GetChat()
	{
		if (this.scrap)
		{
			this.scrap = false;
			return "Do you need me to scrap more magic essence?";
		}
		if (Main.dayTime)
		{
			return Main.rand.Next(4) switch
			{
				0 => "I recently conjured up a new beard enhancing spell in an attempt to grow a beard to rival that of my master. Instead, I turned into a demon. It was a hell of a time!", 
				1 => "I remember when my master and I had our first lesson together. He accidentally burned his robe while he was trying to show off. I saw a little bit too much that day.", 
				2 => "Do I smell magic essence on you? It is indeed powerful. Give it to me so I may stea- I mean, scrap it, so that you may reap the rewards!", 
				3 => "Looking for fallen stars, eh? Come back at nighttime, I might have some by then. In the meantime, I will be pacing back and forth and flaunting my staff.", 
				4 => "I recently discovered that Wizards can improve their magic by increasing their spell power. It can add secondary effects to your attacks, making them much more powerful!", 
				_ => "Does my hat look big? I recently tried casting my first 'Engorgio' spell. My master says the size of your hat reflects your experience as a wizard.", 
			};
		}
		return Main.rand.Next(4) switch
		{
			0 => "I recently conjured up a new beard enhancing spell in an attempt to grow a beard to rival that of my master. Instead, I turned into a demon. It was a hell of a time!", 
			1 => "I remember when my master and I had our first lesson together. He accidentally burned his robe while he was trying to show off. I saw a little bit too much that day.", 
			2 => "Do I smell magic essence on you? It is indeed powerful. Give it to me so I may stea- I mean, scrap it, so that you may reap the rewards!", 
			_ => "Does my hat look big? I recently tried casting my first 'Engorgio' spell. My master says the size of your hat reflects your competence as a wizard.", 
		};
	}

	public override void TownNPCAttackStrength(ref int damage, ref float knockback)
	{
		damage = 15;
		knockback = 2f;
	}

	public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
	{
		cooldown = 5;
		randExtraCooldown = 10;
	}

	public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
	{
		projType = 15;
		attackDelay = 1;
	}

	public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
	{
		multiplier = 7f;
	}

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SparkStaff>(), 5));
    }
}
