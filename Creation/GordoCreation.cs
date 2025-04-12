using PT_Modpack.Creation.Slime;

namespace PT_Modpack.Creation;

public static class GordoCreation
{
    public static void CreateVirtualGordo()
    {
        var gordoIdent = CreateGordoType("Virtual", null, AddTranslation("Virtual Gordo", "l.virtual_gordo"), "IdentifiableType.VirtualGordo");
        var gordoObject = CreateGordoObject(gordoIdent.prefab, gordoIdent, VirtualSlime.SlimeIdent, new GordoFaceData(), VirtualSlime.SlimeIdent.AppearancesDefault[0]._structures[0].DefaultMaterials[0]);
        CreateGordoSpawnLocation(gordoIdent, SpawnLocations.EmberValley, new Vector3(-326.5145f, 5.65f, 298.411f), Vector3.up * 283.9307f, "virtualGordo01");
    }
    
    public static void CreateDiamondGordo()
    {
        var gordoIdent = CreateGordoType("Diamond", null, AddTranslation("Diamond Gordo", "l.diamond_gordo"), "IdentifiableType.DiamondGordo");
        var gordoObject = CreateGordoObject(gordoIdent.prefab, gordoIdent, DiamondSlime.SlimeIdent, new GordoFaceData(), DiamondSlime.SlimeIdent.AppearancesDefault[0]._structures[0].DefaultMaterials[0]);
        CreateGordoSpawnLocation(gordoIdent, SpawnLocations.LabyrinthDreamland, new Vector3(1020.868f, 136.0236f, -894.7559f), Vector3.up * 51.8644f, "diamondGordo01");
    }
}