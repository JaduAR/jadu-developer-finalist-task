using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AvatarCollider : MonoBehaviour
{
    public UnityEvent OnAvatarPress { get; private set; } = new UnityEvent();

    private void OnMouseDown()
    {
        OnAvatarPress.Invoke();
    }
}
