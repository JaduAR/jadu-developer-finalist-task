using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator animator;

    public void SetState(CameraState state)
    {
        switch (state)
        {
            case CameraState.FullBody:
                animator.SetInteger("CameraState", 0);
                break;
            case CameraState.UpperBody:
                animator.SetInteger("CameraState", 1);
                break;
            case CameraState.Face:
                animator.SetInteger("CameraState", 2);
                break;
        }
    }
}

public enum CameraState { FullBody, Face, UpperBody };
