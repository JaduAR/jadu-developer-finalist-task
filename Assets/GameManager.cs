using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] CameraManager CameraManager = CameraManager.Instance;

    public CinemachineVirtualCamera IdleCam;
    public CinemachineVirtualCamera SkinCloseUpCam;
    public CinemachineVirtualCamera HairCloseUpCam;

    public GameObject CustomizationPanel;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!CameraManager) CameraManager = CameraManager.Instance;
    }
    public void SetIdleState()
    {
        CameraManager.SwitchCamera(IdleCam);
        CustomizationPanel.SetActive(false);
    }
    public void SetSkinSelectState()
    {
        CameraManager.SwitchCamera(SkinCloseUpCam);
    }
    public void SetHairSelectState()
    {
        CameraManager.SwitchCamera(HairCloseUpCam);
    }

    public void SetCustomizeState()
    {
        CustomizationPanel.SetActive(true);
        SetSkinSelectState();
        if (Input.GetMouseButtonDown(0))
        {
            print(Input.mousePosition);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print(Input.mousePosition);

            //We transform the touch position into word space from screen space and store it.
            var touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
            }

        }
    }
}
