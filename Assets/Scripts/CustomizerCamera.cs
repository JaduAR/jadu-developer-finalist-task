using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerCamera : MonoBehaviour
{
    [SerializeField] private Transform fullbodyCameraTransform;
    [SerializeField] private Transform closeupCameraTransform;
    [SerializeField] private Transform hairCloseUpCameraTransform;
    private int cameraIndex;

    private Vector3 originalLocalPos;
    private Quaternion originalRotation;
    public float transitionDuration = 1.0f;
    private float transitionTimer = 1.0f;

    void Update(){
        if(transform.localPosition != Vector3.zero){
            float t = transitionTimer/transitionDuration;
            transform.localPosition = Vector3.Slerp(originalLocalPos, Vector3.zero, t);
            transform.localRotation = Quaternion.Lerp(originalRotation, Quaternion.Euler(12,0,0), t);
            transitionTimer += Time.deltaTime;
        }
    }

    public void SwitchToFullBody(){
        if(cameraIndex == 0) return;
        cameraIndex = 0;
        TransitionCameraToTransform(fullbodyCameraTransform);
    }

    public void SwitchToCloseUp(){
        if(cameraIndex == 1) return;
        cameraIndex = 1;
        TransitionCameraToTransform(closeupCameraTransform);
    }

    public void SwitchToHairCloseUp(){
        if(cameraIndex == 2) return;
        cameraIndex = 2;
        TransitionCameraToTransform(hairCloseUpCameraTransform);
    }

    public void TransitionCameraToTransform(Transform target){
        transform.SetParent(target);
        originalLocalPos = transform.localPosition;
        originalRotation = transform.localRotation;
        transitionTimer = 0.0f;
    }
}
