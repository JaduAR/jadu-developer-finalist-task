using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject mainCamera;
    public Transform screenOne;
    public Transform screenTwo;
    public Transform screenThree;
    public int pos = 2;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //cameraTransition(screenOne, screenTwo);
    }

    // Update is called once per frame
    void Update()
    {
        switch (pos)
        {
            case 1:
                cameraTransition(screenOne);
                break;
            case 2:
                cameraTransition(screenTwo);
                break;
            case 3:
                cameraTransition(screenThree);
                break;
            default:
                break;
        }
       
    }
    public void setPos(int i)
    {
        pos = i;
    }
    void cameraTransition(Transform end)
    {

        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, end.position, ref velocity, smoothTime);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, end.rotation, 0.02f);
    }
}
