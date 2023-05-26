using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public ScreenOneView screenOneView;
    public GameObject firstPos;
    public GameObject lastPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        screenOneView.OnModelClicked += ZoomIn;
        screenOneView.OnReturn += ResetCam;
    }

    private void OnDisable()
    {
        screenOneView.OnModelClicked -= ZoomIn;
    }

    public void ResetCam()
    {
        StartCoroutine(LerpPosition(firstPos, 0.3f));
    }

    public void ZoomIn()
    {
        StartCoroutine(LerpPosition(lastPos, 0.3f));
    }

    IEnumerator LerpPosition(GameObject targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition.transform.position, time / duration);
            transform.rotation = Quaternion.Lerp(startRotation, targetPosition.transform.rotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition.transform.position;
        transform.rotation = targetPosition.transform.rotation;
    }
}
