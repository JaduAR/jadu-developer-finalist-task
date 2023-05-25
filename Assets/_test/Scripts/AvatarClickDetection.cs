using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarClickDetection : MonoBehaviour
{
    public static Action OnAvatarClick;


    private void OnMouseDown() {
        OnAvatarClick?.Invoke();
    }
}
