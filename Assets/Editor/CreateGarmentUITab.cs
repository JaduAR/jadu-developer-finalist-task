using UnityEditor;
using UnityEngine;

public class CreateGarmenUITab : MonoBehaviour
{
    [MenuItem("Assets/Create/Garment Tab")]
    public static void CreateAGarmentTab()
    {
        GarmentTabScriptableObject garmentTab = ScriptableObject.CreateInstance
            <GarmentTabScriptableObject>();
        string uniqueName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/garment_tab.asset");
        AssetDatabase.CreateAsset(garmentTab, uniqueName);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = garmentTab;
    }
}
