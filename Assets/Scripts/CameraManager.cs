using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEditor.Progress;
using System.Linq;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    public CinemachineVirtualCamera[] Cameras;

    [SerializeField] 
    [Header("Default initial camera")]
    private CinemachineVirtualCamera _activeCam;// default to IdleCam

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Cameras.Length <= 0)
            Cameras = FindObjectsOfType<CinemachineVirtualCamera>();

        if (Cameras.Length > 0)
        {// Find the highest priority camera and set it as active 
            _activeCam = Cameras[0];

            foreach (var cam in Cameras)
            {
                if (cam.Priority > _activeCam.Priority) _activeCam = cam;
            }
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera nextCam)
    {

        _activeCam = nextCam;

        foreach (var cam in Cameras)
        {
            if (cam == _activeCam) _activeCam.Priority = 1;
            else cam.Priority = 0;
        }

        print($"Active cam: {_activeCam}. Priority {_activeCam.Priority}");

    }
}
