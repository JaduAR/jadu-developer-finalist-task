using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleBool(string boolName)
    {
        anim.SetBool(boolName, !anim.GetBool(boolName));
    }

    public void SetBoolFalse(string boolName)
    {
        anim.SetBool(boolName, false);
    }

    public void SetBoolTrue(string boolName)
    {
        anim.SetBool(boolName, true);
    }

}
