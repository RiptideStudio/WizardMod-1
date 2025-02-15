using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace WizardMod.Blocks;

public class ArcaneTable : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileTable[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileFrameImportant[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.Width = 3;
        TileObjectData.addTile(Type);
        //ModTranslation name = ((ModBlockType)this).CreateMapEntryName((string)null);
        //name.SetDefault("Arcane Table");
        //AddMapEntry(new Color(175, 13, 166), name);
        AddMapEntry(new Color(175, 13, 166), CreateMapEntryName());
    }

    //public override void KillMultiTile(int i, int j, int frameX, int frameY)
    //{
    //    Item.NewItem(Main.LocalPlayer.GetSource_DropAsItem(), new Vector2(i * 16, j * 16), new Vector2(32f, 32f), Mod.Find<ModItem>("ArcaneTableItem").Type);
    //}

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.8f;
        g = 0.5f;
        b = 0.75f;
    }
}
