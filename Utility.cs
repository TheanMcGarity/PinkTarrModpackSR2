namespace PT_Modpack;

public static class Utility
{
    public static void SetSlimeTexture(this SlimeAppearance app, Texture2D texture)
    {
        for (int i = 0; i < app.Structures.Count - 1; i++)
        {
            SlimeAppearanceStructure a = app.Structures[i];
            
            var mat = a.DefaultMaterials[0];
            
            mat.EnableKeyword("_ENABLEMATCAP_ON");     
            mat.SetTexture("_CubemapOverride", texture);
        }
    }
}