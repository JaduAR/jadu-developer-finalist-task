using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public UIStateMachine owner;

    public virtual void PrepareState() { }

    public virtual void UpdateState() { }

    public virtual void DestroyState() { }
}