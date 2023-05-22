using UnityEngine;

public class GarmentTabScriptableObject : ScriptableObject
{
    public GarementType         garementType;
    public Garment[]            garments;
    public InventoryScrollView  InventoryScrollView;
    /// <summary>
    /// expanded height
    /// </summary>
    public float                height;
    public Vector3              cameraPos;
    public Vector3              cameraRotation;
}
