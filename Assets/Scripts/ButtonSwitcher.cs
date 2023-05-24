using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
   [SerializeField] private Button[] _buttons;

   [SerializeField] private Color normalColor;
   [SerializeField] private Color pressedColor;

   [SerializeField] private RectTransform panel;
   
   public void Click(Button button) {
      foreach (var but in _buttons) {
         but.GetComponentInChildren<TextMeshProUGUI>().color = normalColor;
         but.transform.GetChild(1).gameObject.SetActive(false);
      }
      button.transform.GetChild(1).gameObject.SetActive(true);
      button.GetComponentInChildren<TextMeshProUGUI>().color = pressedColor;   
   }

   public void ChangeRect(float top) {
      panel.offsetMax = new Vector2(panel.offsetMax.x, top);
   }
   
}
