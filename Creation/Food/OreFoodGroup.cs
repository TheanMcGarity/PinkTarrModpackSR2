namespace PT_Modpack.Creation.Food;

public class OreFoodGroup
{
    public static IdentifiableTypeGroup Group { get; private set; }
    public static void CreateFoodGroup()
    {
        Group = CreateIdentifiableGroup(
            AddTranslation("Ores", "l.ores", "UI"),
            "EdibleOresGroup",
            crafts._memberGroups._items[0]._memberTypes._items.ToList(),
            new List<IdentifiableTypeGroup>(),
            true);
    }
}