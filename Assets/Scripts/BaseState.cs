using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    // Reference to our state machine.
    public UIStateMachine owner;

    /// <summary>
    /// Method called to prepare state to operate - same as Unity's Start()
    /// </summary>
    public virtual void PrepareState() { }

    /// <summary>
    /// Method called to update state on every frame - same as Unity's Update()
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Method called to destroy state - same as Unity's OnDestroy() but here it might be important!
    /// </summary>
    public virtual void DestroyState() { }
}