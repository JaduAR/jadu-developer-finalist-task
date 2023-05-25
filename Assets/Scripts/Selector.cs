using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selector : MonoBehaviour
{
    protected Tab owner;
    public abstract void Select();
    public abstract void Deselect();
    public virtual void SetOwner(Tab owner)
    {
        this.owner = owner;
    }
}
