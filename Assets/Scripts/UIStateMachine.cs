using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateMachine : MonoBehaviour
{
    // Reference to currently operating state.
    private BaseState currentState;

    // Reference to UI root that holds references to different views
    [SerializeField]
    private UIRoot ui;
    public UIRoot UI => ui;

    /// <summary>
    /// Unity method called on first frame
    /// </summary>
    private void Start()
    {
        // Start game in menu state
        ChangeState(new ScreenOneState());
    }

    /// <summary>
    /// Unity method called each frame
    /// </summary>
    private void Update()
    {
        // If we have reference to state, we should update it!
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    /// <summary>
    /// Method used to change state
    /// </summary>
    /// <param name="newState">New state.</param>
    public void ChangeState(BaseState newState)
    {
        // If we currently have state, we need to destroy it!
        if (currentState != null)
        {
            currentState.DestroyState();
        }

        // Swap reference
        currentState = newState;

        // If we passed reference to new state, we should assign owner of that state and initialize it!
        // If we decided to pass null as new state, nothing will happened.
        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }
}
