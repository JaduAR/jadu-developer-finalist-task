using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField]
    private List<ScreenOneView> screenOneView;
    public List<ScreenOneView> ScreenOneView => screenOneView;

    [SerializeField]
    private List<ScreenTwoView> screenTwoView;
    public List<ScreenTwoView> ScreenTwoView => screenTwoView;

    [SerializeField]
    private List<ScreenThreeView> screenThreeView;
    public List<ScreenThreeView> ScreenThreeView => screenThreeView;
}
