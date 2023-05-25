using UnityEditor;
using UnityEngine;

public class CreateHairType : MonoBehaviour
{
    [MenuItem("Assets/Create/Hair Type")]
    public static void CreateAHairType()
    {
        Garment playerScriptableObject = ScriptableObject.CreateInstance
            <Garment>();
        playerScriptableObject.garementType = GarementType.HAIR;
        string uniqueName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/hair.asset");
        AssetDatabase.CreateAsset(playerScriptableObject, uniqueName);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = playerScriptableObject;
    }
}
