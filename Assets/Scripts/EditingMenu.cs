using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EditingMenu : Menu
{
    private VisualElement root;
    private List<Button> skinColorButtons = new List<Button>();
    private Button selectedSkinColorButton = null;
    private List<Button> hairButtons = new List<Button>();
    private Button selectedHairButton = null;

    public void Initialize()
    {
        root = CustomizerManager.instance.menuController.document.rootVisualElement;
    }

    public override void Enter()
    {
        base.Enter();
        root.style.display = DisplayStyle.Flex;
        root.Q<VisualElement>("SkinButton").Q<Button>().clicked += OnTapSkinButton;
        root.Q<VisualElement>("HairButton").Q<Button>().clicked += OnTapHairButton;
        root.Q<Button>("DoneButton").clicked += OnTapDoneButton;
        root.Q("Bottom").style.transitionDuration = new List<TimeValue> { new (0, TimeUnit.Millisecond) };
        root.Q("Top").style.transitionDuration = new List<TimeValue> { new (0, TimeUnit.Millisecond) };
        root.Q("Bottom").style.translate = new Translate(0, 600);
        root.Q("Top").style.opacity = 0;
        root.Q("Bottom").style.transitionDuration = new List<TimeValue> { new (500, TimeUnit.Millisecond) };
        root.Q("Top").style.transitionDuration = new List<TimeValue> { new (500, TimeUnit.Millisecond) };
        root.Q("Bottom").style.translate = new Translate(0, 0);
        root.Q("Top").style.opacity = 1;
    }

    public override void Exit()
    {
        base.Exit();
        root.style.display = DisplayStyle.None;
        root.Q<VisualElement>("SkinButton").Q<Button>().clicked -= OnTapSkinButton;
        root.Q<VisualElement>("HairButton").Q<Button>().clicked -= OnTapHairButton;
        root.Q<Button>("DoneButton").clicked -= OnTapDoneButton;
    }
    
    public void OnTapHairButton()
    {
        CustomizerManager.instance.SetHairState();
    }
    public void OnTapSkinButton()
    {
        CustomizerManager.instance.SetSkinState();
    }
    public void OnTapDoneButton()
    {
        CustomizerManager.instance.SetIdleState();
    }

    public void SelectSubMenu(EditingSubMenu editSubMenu)
    {
        switch(editSubMenu)
        {
            case EditingSubMenu.Skin:
                root.Q("SkinEditor").style.display = DisplayStyle.Flex;
                root.Q("HairEditor").style.display = DisplayStyle.None;
                root.Q<VisualElement>("SkinButton").Q("Underline").style.display = DisplayStyle.Flex;
                root.Q<VisualElement>("HairButton").Q("Underline").style.display = DisplayStyle.None;
                if (skinColorButtons.Count == 0)
                {
                    GenerateSkinEditorButtons();
                    OnSelectSkinEditorButton(skinColorButtons[0]);
                }
                break;
            case EditingSubMenu.Hair:
                root.Q("HairEditor").style.display = DisplayStyle.Flex;
                root.Q("SkinEditor").style.display = DisplayStyle.None;
                root.Q<VisualElement>("HairButton").Q("Underline").style.display = DisplayStyle.Flex;
                root.Q<VisualElement>("SkinButton").Q("Underline").style.display = DisplayStyle.None;
                if (hairButtons.Count == 0)
                {
                    GenerateHairEditorButtons();
                    OnSelectHairEditorButton(hairButtons[0]);
                }
                break;
        }
    }

    private void OnSelectSkinEditorButton(Button button)
    {
        if (button != selectedSkinColorButton)
        {
            if (selectedSkinColorButton != null)
            {
                selectedSkinColorButton.Q("circle").style.width = Length.Percent(100);
                selectedSkinColorButton.Q("circle").style.height = Length.Percent(100);
            }
            button.Q("circle").style.width = Length.Percent(50);
            button.Q("circle").style.height = Length.Percent(50);
        }
        selectedSkinColorButton = button;
    }

    private void GenerateSkinEditorButtons()
    {
        root.Q("SkinEditorList").Clear();
        for (int i = 0; i < 12; i++)
        {
            var newButton = GenerateSkinEditorButton();
            newButton.RegisterCallback<ClickEvent>(ev => OnSelectSkinEditorButton(newButton));
            skinColorButtons.Add(newButton);
            root.Q("SkinEditorList").Add(newButton);
        }
    }

    private Button GenerateSkinEditorButton()
    {
        var button = new Button();
        var circle = new VisualElement();
        button.Add(circle);

        button.AddToClassList("skin-selection-button");
        circle.AddToClassList("skin-selection-button-circle");
        circle.name = "circle";
        circle.style.backgroundColor = Random.ColorHSV(0, 1, 0, 1, 1, 1);

        return button;
    }

    void OnSelectHairEditorButton(Button button)
    {
        if (button != selectedHairButton)
        {
            if (selectedHairButton != null)
            {
                selectedHairButton.style.backgroundColor = Color.clear;
                selectedHairButton.Q<Image>("image").style.unityBackgroundImageTintColor = Color.white;
            }
            button.style.backgroundColor = new Color(0.1f, 0.1f, 0.1f);
            button.Q<Image>("image").style.unityBackgroundImageTintColor = new Color(0.5f, 0.5f, 0.5f);
        }
        selectedHairButton = button;
    }

    private void GenerateHairEditorButtons()
    {
        root.Q("HairEditorList").Clear();
        for (int i = 0; i < 2; i++)
        {
            var row = new VisualElement();
            row.AddToClassList("hair-selection-row");
            root.Q("HairEditorList").Add(row);

            for (int j = 0; j < 3; j++)
            {
                var newButton = GenerateHairEditorButton();
                newButton.RegisterCallback<ClickEvent>(ev => OnSelectHairEditorButton(newButton));
                hairButtons.Add(newButton);
                row.Add(newButton);
            }
        }

    }

    private Button GenerateHairEditorButton()
    {
        var button = new Button();
        button.AddToClassList("hair-selection-row__button");
        var image = new Image();
        image.AddToClassList("hair-selection-row__button__image");
        image.name = "image";
        button.Add(image);
        var label = new Label("HAIR STYLE");
        label.AddToClassList("hair-selection-row__button__label");
        button.Add(label);
        return button;
    }
}

public enum EditingSubMenu { Skin, Hair }
