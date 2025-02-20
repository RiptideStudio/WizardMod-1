using System.IO;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using WizardMod.NPCs;

namespace ArcheryOverhaul.World
{
    // This class tracks if specific Town NPC have ever spawned in this world. If they have, then their spawn conditions are not required anymore to respawn in the same world. This behavior is new to Terraria v1.4.4 and is not automatic, it needs code to support it.
    // Spawn conditions that can't be undone, such as defeating bosses, would not require tracking like this since those conditions will still be true when the Town NPC attempts to respawn. Spawn conditions checking for items in the player inventory like ExamplePerson does, for example, would need tracking.
    public class TownNPCRespawnSystem : ModSystem
    {
        // Tracks if the Archer has ever been spawned in this world
        public static bool unlockedApprentice = false;

        // Town NPC rescued in the world would follow a similar implementation, the only difference being how the value is set to true.
        // public static bool savedExamplePerson = false;

        public override void ClearWorld()
        {
            unlockedApprentice = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag[nameof(unlockedApprentice)] = unlockedApprentice;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            unlockedApprentice = tag.GetBool(nameof(unlockedApprentice));

            // This line sets unlockedExamplePersonSpawn to true if an ExamplePerson is already in the world. This is only needed because unlockedExamplePersonSpawn was added in an update to this mod, meaning that existing users might have unlockedExamplePersonSpawn incorrectly set to false.
            // If you are tracking Town NPC unlocks from your initial mod release, then this isn't necessary.
            unlockedApprentice |= NPC.AnyNPCs(ModContent.NPCType<Apprentice>());
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(unlockedApprentice);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out unlockedApprentice);
        }
    }
}
