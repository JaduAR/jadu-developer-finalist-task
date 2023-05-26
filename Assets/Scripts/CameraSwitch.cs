using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public Transform[] camTransforms;
    public GameObject body;
    public GameObject canvas;
    public RectTransform menuRectTransform;
    Vector3 menuPosition;


    void Start()
    {
        SetCameraAndCanvas(0);
        canvas.SetActive(false);
        menuPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.name == "Body")
                {
                    SetCameraAndCanvas(1);
                    StartCoroutine(ShowMenu());
                }

            }
        }
    }

    IEnumerator ShowMenu()
    {
        float speed = 2000f;
        while (menuRectTransform.localPosition.y - menuPosition.y < 0) {
            menuRectTransform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
        
    }

    public void SetCameraAndCanvas(int i)
    {
        Camera.main.transform.position = camTransforms[i].position;
        Camera.main.transform.rotation = camTransforms[i].rotation;
        if (i == 0)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }

}
