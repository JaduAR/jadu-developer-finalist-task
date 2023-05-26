using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Camera Cam;
    public AnimationCurve CamBlending;
    public float CamBlendInterval = 1.5f;

    public bool TransitionDone { get; private set; }

    public IEnumerator CamTransition(Transform target)
    {
        TransitionDone = false;
        float startTime = 0f;
        Vector3 sourcePos = Camera.main.transform.position;
        Quaternion sourceRot = Camera.main.transform.rotation;

        while (startTime < CamBlendInterval)
        {
            startTime += Time.deltaTime;
            float normalizedStep = CamBlending.Evaluate(startTime / CamBlendInterval);

            Vector3 pos = Vector3.Lerp(sourcePos, target.position, normalizedStep);
            Quaternion r = Quaternion.Lerp(sourceRot, target.rotation, normalizedStep);

            Camera.main.transform.position = pos;
            Camera.main.transform.rotation = r;
            yield return null;
        }

        TransitionDone = true;
    }
}
