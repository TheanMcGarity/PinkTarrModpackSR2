using Il2CppInterop.Runtime.InteropTypes.Arrays;
using PT_Modpack.Creation.Food;

namespace PT_Modpack.Creation.Slime;

public static class DiamondSlime
{  
    public static SlimeDefinition SlimeIdent { get; private set; }
    public static Texture2D SlimeTexture { get; private set; }
    public static IdentifiableType PlortIdent { get; private set; }

    
    public const LargoSettings largoSettings = LargoSettings.KeepFirstBody |
                                               LargoSettings.KeepSecondFace |
                                               LargoSettings.KeepFirstColor |
                                               LargoSettings.KeepSecondTwinColor;
    
    public static readonly Color32 vacColor = new Color32(134, 235, 225, 255); 
    public static void CreateSlime()
    {
        SlimeTexture = LoadPNG("Image.DiamondTexture");
        
        var def = CreateSlimeDef(
            "Diamond",
            vacColor,
            null,
            GetSlime("Pink").AppearancesDefault[0],
            "DiamondDefault",
            "SlimeDefinition.Diamond");
        
        var plort = CreatePlortType(
            "Diamond",
            vacColor,
            null,
            "IdentifiableType.DiamondPlort",
            96,
            44);

        var plortObj = GetPlort("PinkPlort").prefab.CopyObject();
        var slimeObj = GetSlime("Pink").prefab.CopyObject();
        
        plort.prefab = plortObj;
        def.prefab = slimeObj;
        
        slimeObj.SetObjectIdent(def);
        plortObj.SetObjectIdent(plort);

        def.localizedName = AddTranslation("Diamond Slime", "l.diamond_slime");
        plort.localizedName = AddTranslation("Diamond Plort", "l.diamond_plort");
        
        def.AppearancesDefault[0]._splatColor = vacColor;
        def.AppearancesDefault[0].SetSplatColor();

        def.MakeVaccable();
        
        def.AddSlimeFoodGroup(OreFoodGroup.Group);
        def.AddFavorite(GetCraft("StrangeDiamondCraft"));
        def.AddProduceIdent(plort);
        def.RefreshEatmap();
        
        SlimeIdent = def;
        PlortIdent = plort;

        var mat = def.AppearancesDefault[0]._structures[0].DefaultMaterials[0];
        mat.EnableKeyword("_ENABLEMATCAP_ON");     
        mat.SetTexture("_CubemapOverride", SlimeTexture);
        def.SetSlimeColor(vacColor, vacColor, vacColor);
        plortObj.GetComponent<MeshRenderer>().material = mat;
        def.AppearancesDefault[0]._splatColor = vacColor;
        def.AppearancesDefault[0].SetSplatColor();
        
        MakeSpawnableInZones(def, new DirectedActorSpawner.TimeWindow{TimeMode = DirectedActorSpawner.TimeMode.ANY}, SpawnLocations.LabyrinthDreamland, 0.000000001f, SpawnerTypes.Slime);

        
        def.AppearancesDefault[0].AddStructure(
            PackEntry.spikesStructure,
            SlimeAppearance.SlimeBone.SLIME,
            SlimeAppearance.SlimeBone.SLIME,
            "DiamondSpikes");
    }

    public static void CreateLargos()
    {
        foreach (var type in baseSlimes.GetAllMembersArray())
        {
            var slime = type.Cast<SlimeDefinition>();
            
            if (!slime.CanLargofy)
                continue;
            
            var largo = CreateCompleteLargo(SlimeIdent, slime.Cast<SlimeDefinition>(), largoSettings);
            largo.AppearancesDefault[0].SetSlimeTexture(SlimeTexture);
        }
    }
}