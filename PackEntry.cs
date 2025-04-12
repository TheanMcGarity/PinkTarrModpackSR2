using PT_Modpack;
using PT_Modpack.Creation;
using PT_Modpack.Creation.Food;
using PT_Modpack.Creation.Slime;

[assembly: MelonInfo(typeof(PackEntry), "PT Modpack", "0.0.0", "PinkTarr")]
[assembly: MelonGame("MonomiPark", "SlimeRancher2")]
namespace PT_Modpack;

public class PackEntry : CottonModInstance<PackEntry>
{
    public static AssetBundle meshes;
    public static Mesh spikesStructure;
    
    public override void SaveDirectorLoaded()
    {
        meshes = LoadBundle("Bundle.mesh");

        spikesStructure = meshes.LoadAsset<Mesh>("spikes");
        
        // Foods
        DigitalHen.CreateHen();
        OreFoodGroup.CreateFoodGroup();
        
        // Slimes
        VirtualSlime.CreateSlime();
        DiamondSlime.CreateSlime();
        
        // Gordos
        GordoCreation.CreateVirtualGordo();
        GordoCreation.CreateDiamondGordo();
    }

    public override void LateSaveDirectorLoaded()
    {
        // Largos
        DiamondSlime.CreateLargos();
    }
}