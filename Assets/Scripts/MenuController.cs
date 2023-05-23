using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    private Stack<Menu> menuStack;
    public IdleMenu idleMenu;
    public EditingMenu editingMenu;
    public UIDocument document;

    private void Awake()
    {
        menuStack = new Stack<Menu>();
        editingMenu.Initialize();
    }

    public void Push(Menu menu)
    {
        if (menuStack.Count > 0)
        {
            Menu topMenu = menuStack.Peek();
            if (topMenu == menu)
                return;
            menuStack.Pop();
            topMenu.Exit();
        }
        menuStack.Push(menu);
        menu.Enter();
    }
}
