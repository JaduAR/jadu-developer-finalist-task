using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerManager : MonoBehaviour
{
    public static CustomizerManager instance = null;
    public CustomizerStateMachine stateMachine { get; private set; }
    public IdleState idleState;
    public SkinState skinState;
    public HairState hairState;
    public MenuController menuController;
    public CameraController cameraController;

    private void Awake()
    {
        if (CustomizerManager.instance == null)
            CustomizerManager.instance = this;
        else if (CustomizerManager.instance != this)
            Destroy(this.gameObject);
        
        stateMachine = new CustomizerStateMachine();
        idleState = new IdleState(menuController, cameraController);
        skinState = new SkinState(menuController, cameraController);
        hairState = new HairState(menuController, cameraController);
    }

    private void Start()
    {
        SetIdleState();
    }

    public void SetIdleState()
    {
        stateMachine.SetState(idleState);
    }

    public void SetSkinState()
    {
        stateMachine.SetState(skinState);
    }

    public void SetHairState()
    {
        stateMachine.SetState(hairState);
    }
}
