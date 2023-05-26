using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonOutline : MonoBehaviour, IDeselectHandler
{
    private Button button;
    private Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        outline.effectColor = new Color(1, 0, 1, 1);
    }

    public void Unclicked()
    {
        outline.effectColor = new Color(1, 1, 1, 1);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Unclicked();
    }
}
