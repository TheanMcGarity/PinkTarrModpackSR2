using Il2CppInterop.Runtime.InteropTypes.Arrays;
using PT_Modpack.Creation.Food;

namespace PT_Modpack.Creation.Slime;

public static class VirtualSlime
{  
    public static SlimeDefinition SlimeIdent { get; private set; }
    public static IdentifiableType PlortIdent { get; private set; }

    
    public const LargoSettings largoSettings = LargoSettings.KeepFirstBody |
                                               LargoSettings.KeepSecondFace |
                                               LargoSettings.KeepFirstColor |
                                               LargoSettings.KeepSecondTwinColor;
    
    public static readonly Color32 topColor = new Color32(2, 191, 2, 255); 
    public static readonly Color32 middleColor = new Color32(16, 107, 16, 255); 
    public static readonly Color32 bottomColor = new Color32(12, 56, 12, 255); 
    public static readonly Color32 vacColor = new Color32(10, 117, 10, 255); 
    public static void CreateSlime()
    {
        var def = CreateSlimeDef(
            "Virtual",
            vacColor,
            null,
            GetSlime("Pink").AppearancesDefault[0],
            "VirtualDefault",
            "SlimeDefinition.Virtual",
            true,
            largoSettings);
        
        var plort = CreatePlortType(
            "Virtual",
            vacColor,
            null,
            "IdentifiableType.VirtualPlort",
            27,
            18);

        var plortObj = GetPlort("PinkPlort").prefab.CopyObject();
        var slimeObj = GetSlime("Pink").prefab.CopyObject();
        
        plort.prefab = plortObj;
        def.prefab = slimeObj;
        
        slimeObj.SetObjectIdent(def);
        plortObj.SetObjectIdent(plort);

        def.localizedName = AddTranslation("Virtual Slime", "l.virtual_slime");
        plort.localizedName = AddTranslation("Virtual Plort", "l.virtual_plort");
        
        def.SetSlimeColor(topColor, middleColor, bottomColor);
        SetPlortColor(topColor, middleColor, bottomColor, plortObj);
        def.AppearancesDefault[0]._splatColor = vacColor;
        def.AppearancesDefault[0].SetSplatColor();

        def.MakeVaccable();

        def.Diet.MajorFoodIdentifiableTypeGroups = new(new[] { meat });
        def.AddFavorite(DigitalHen.Ident);
        def.AddProduceIdent(plort);
        def.RefreshEatmap();
        
        SlimeIdent = def;
        PlortIdent = plort;
        
        MakeSpawnableInZones(def, new DirectedActorSpawner.TimeWindow{TimeMode = DirectedActorSpawner.TimeMode.ANY}, SpawnLocations.EmberValley | SpawnLocations.StarlightStand, 0.25f, SpawnerTypes.Slime);
    }
}