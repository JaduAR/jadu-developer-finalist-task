using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator UIAnimator;
    public Animator CameraAnimator;

    /// <summary>Syncs the states of the UI and Camera animators</summary>
    /// <param name="opt"> State to sync animators to</param>
    public void SetUIState(int state)
    {
        UIAnimator.SetInteger("State", state);
        CameraAnimator.SetInteger("State", state);
    }
  
}
