using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
  public enum ActiveCamera
  {
    HAIR_CAM = 0,
    SKIN_CAM = 1,
    FULL_BODY = 2,
  };

  public delegate void TabContentViewEventHandler(ActiveCamera newState);
  public static event TabContentViewEventHandler OnContentViewChanged;

  public delegate void TabContentViewResetHandler();
  public static event TabContentViewResetHandler OnContentViewReset;

  [SerializeField]
  CinemachineVirtualCamera fullBodyCam;

  [SerializeField]
  CinemachineVirtualCamera skinCam;

  [SerializeField]
  CinemachineVirtualCamera hairCam;

  [SerializeField]
  GameObject canvas;

  [SerializeField]
  GameObject skinPanel;

  [SerializeField]
  GameObject hairPanel;

  [SerializeField]
  ActiveCamera cameraState = ActiveCamera.FULL_BODY;

  [SerializeField]
  LayerMask layerMask;

  // In cinemachine, a virtual camera with the highest priority becomes the active camera that the virtual camera brain component picks
  const int HIGH_PRIORITY = 1;
  const int LOW_PRIORITY = 0;


  // Used to debug different camera views within the editor
  void OnValidate()
  {
    ChangeCameras();
  }

  void Update()
  {
    if (cameraState == ActiveCamera.FULL_BODY && Input.GetMouseButtonDown(0))
    {
      Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(camRay, out RaycastHit hit, 100f, layerMask))
      {
        var cams = new CinemachineVirtualCamera[] { fullBodyCam, hairCam };
        UpdateCameraPriority(ref skinCam, ref cams);
        canvas.SetActive(true);
        skinPanel.SetActive(true);
      }
      
    }
  }

  void ChangeCameras()
  {
    switch (cameraState)
    {
      case ActiveCamera.FULL_BODY:
        var cams = new CinemachineVirtualCamera[] { skinCam, hairCam };
        UpdateCameraPriority(ref fullBodyCam, ref cams);
        break;
      case ActiveCamera.SKIN_CAM:
        cams = new CinemachineVirtualCamera[] { fullBodyCam, hairCam };
        UpdateCameraPriority(ref skinCam, ref cams);
        break;
      case ActiveCamera.HAIR_CAM:
        cams = new CinemachineVirtualCamera[] { fullBodyCam, skinCam };
        UpdateCameraPriority(ref hairCam, ref cams);
        break;
    }
  }

  void UpdateCameraPriority(ref CinemachineVirtualCamera target, ref CinemachineVirtualCamera[] otherCameras)
  {
    target.Priority = HIGH_PRIORITY;
    foreach (var virtualCam in otherCameras)
    {
      virtualCam.Priority = LOW_PRIORITY;
    }
  }

  public void OnDoneButtonClicked()
  {
    OnContentViewReset?.Invoke();
    var cams = new CinemachineVirtualCamera[] { skinCam, hairCam };
    UpdateCameraPriority(ref fullBodyCam, ref cams);
    cameraState = ActiveCamera.FULL_BODY;
    HideUI();
  }

  public void OnTabButtonClicked(int newState)
  {
    cameraState = (ActiveCamera)newState;
    ChangeCameras();
    OnContentViewChanged?.Invoke(cameraState);
  }

  void HideUI()
  {
    canvas.SetActive(false);
    skinPanel.SetActive(false);
    hairPanel.SetActive(false);
  }
}
