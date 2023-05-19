using UnityEditor;
using UnityEngine;

public class CreateHairType : MonoBehaviour
{
    [MenuItem("Assets/Create/Skin Type")]
    public static void CreateAHairType()
    {
        Garement playerScriptableObject = ScriptableObject.CreateInstance
            <Garement>();
        playerScriptableObject.garementType = GarementType.HAIR;
        string uniqueName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/hair.asset");
        AssetDatabase.CreateAsset(playerScriptableObject, uniqueName);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = playerScriptableObject;
    }
}
