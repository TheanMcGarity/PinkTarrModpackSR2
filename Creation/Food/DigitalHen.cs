namespace PT_Modpack.Creation.Food;

public static class DigitalHen
{
    public static IdentifiableType Ident { get; private set; }
    public static void CreateHen()
    {
        var texture = LoadPNG("Image.alb_digitalHen");
        var type = CreateBlankType("DigitalHen", new Color32(88, 176, 88, 255), null, "IdentifiableType.DigitalHen");
        var obj = CreateHenObject(
            type,
            texture,
            Texture2D.blackTexture,
            out var baitObject);

        type.localizedName = AddTranslation("Digital Hen", "l.digital_hen");
        
        type.AddToGroup("MeatGroup");
        type.groupType = meat;
        type.prefab = obj;
        
        MakeSpawnableInZones(type, new DirectedActorSpawner.TimeWindow{TimeMode = DirectedActorSpawner.TimeMode.ANY}, SpawnLocations.RainbowFields, 0.05f, SpawnerTypes.Animal);

        Ident = type;
    }
}