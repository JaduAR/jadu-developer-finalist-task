//Created 5/23/2023 
//Basic SO for helping store camera information used in other scripts.
using UnityEngine;

[CreateAssetMenu(fileName = "CamInfo", menuName = "ScriptableObjects/CameraInfoScriptableObject", order = 1)]
public class CameraInfo : ScriptableObject
{
    public float fov;
    public Vector3 position;
    public Quaternion rotation;
}