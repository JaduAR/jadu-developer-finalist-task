using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class CustomizerStateMachine
{
    public ICustomizerState CurrentState { get; private set; }

    public void SetState(ICustomizerState state)
    {
        if (state == CurrentState)
            return;

        CurrentState?.OnExit();
        CurrentState = state;
        CurrentState.OnEnter();
    }
}

public interface ICustomizerState
{
    void OnEnter();
    void OnExit();
}

public class IdleState : ICustomizerState
{
    private MenuController MenuController { get; set; }
    private CameraController CameraController { get; set; }

    public IdleState(MenuController menuController, CameraController cameraController)
    {
        MenuController = menuController;
        CameraController = cameraController;
    }

    // Go to idle menu (blank UI)
    // Zoom to full body
    public void OnEnter()
    {
        MenuController.Push(MenuController.idleMenu);
        CameraController.SetState(CameraState.FullBody);
    }

    public void OnExit()
    {
    }
}

public class SkinState: ICustomizerState
{
    private MenuController MenuController { get; set; }
    private CameraController CameraController { get; set; }

    public SkinState(MenuController menuController, CameraController cameraController)
    {
        MenuController = menuController;
        CameraController = cameraController;
    }
    
    // Bring up editing menu if needed
    // Swap to skin menu
    // Zoom to face
    public void OnEnter()
    {
        MenuController.Push(MenuController.editingMenu);
        MenuController.editingMenu.SelectSubMenu(EditingSubMenu.Skin);
        CameraController.SetState(CameraState.Face);
    }

    public void OnExit()
    {
    }
}

public class HairState: ICustomizerState
{
    private MenuController MenuController { get; set; }
    private CameraController CameraController { get; set; }

    public HairState(MenuController menuController, CameraController cameraController)
    {
        MenuController = menuController;
        CameraController = cameraController;
    }
    
    // Bring up editing menu if needed
    // Swap to hair menu
    // Zoom to upper body
    public void OnEnter()
    {
        MenuController.Push(MenuController.editingMenu);
        MenuController.editingMenu.SelectSubMenu(EditingSubMenu.Hair);
        CameraController.SetState(CameraState.UpperBody);
    }

    public void OnExit()
    {
    }
}
