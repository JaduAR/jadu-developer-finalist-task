using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public GameObject body;
    public Button hairButton;
    public Button skinButton;
    public Button doneButton;

    private Camera currCam;

    // Start is called before the first frame update
    void Start()
    {
        currCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = currCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.name == "body")
                {
                    ToggleCam(cam2, cam1, cam3);
                }

            }
        }
    }

    void ToggleCam (Camera activeCam, Camera inactiveCam1, Camera inactiveCam2)
    {
        currCam = activeCam;
        activeCam.enabled = true;
        inactiveCam1.enabled = false;
        inactiveCam2.enabled = false;
    }
}
