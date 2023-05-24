using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public class SelectableButton : MonoBehaviour {

    public void AddListener(UnityAction fn) {
        GetComponent<Button>().onClick.AddListener(fn);
    }

    public void SetSelected(bool selected) {
        GetComponent<Animator>().SetBool("Selected", selected);
    }
}
