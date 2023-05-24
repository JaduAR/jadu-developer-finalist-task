using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IdleMenu : Menu
{
    public AvatarCollider avatarCollider;

    private void OnEnable()
    {
        avatarCollider.OnAvatarPress.AddListener(OnTapAvatar);
    }

    private void OnDisable()
    {
        avatarCollider.OnAvatarPress.RemoveListener(OnTapAvatar);
    }

    public override void Enter()
    {
        base.Enter();
        VisualElement root = CustomizerManager.instance.menuController.document.rootVisualElement;
        root.style.display = DisplayStyle.None;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void OnTapAvatar()
    {
        if (CustomizerManager.instance.stateMachine.CurrentState is IdleState)
            CustomizerManager.instance.SetSkinState();
    }
}
