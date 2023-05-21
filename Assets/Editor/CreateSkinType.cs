using UnityEditor;
using UnityEngine;

public class CreateSkinType
{
    [MenuItem("Assets/Create/Skin Type")]
    public static void CreateASkinType()
    {
        Garment playerScriptableObject = ScriptableObject.CreateInstance
            <Garment>();
        playerScriptableObject.garementType = GarementType.SKIN;
        string uniqueName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/skin.asset");
        AssetDatabase.CreateAsset(playerScriptableObject, uniqueName);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = playerScriptableObject;
    }
}
