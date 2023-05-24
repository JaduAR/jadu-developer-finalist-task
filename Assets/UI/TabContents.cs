using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]
public class TabContents : MonoBehaviour {
    public void SetSelected(bool selected) {
        GetComponent<Animator>().SetBool("Selected", selected);

        // disable `blocksRaycasts` if not selected
        // this is needed since the Animator just sets opacity to 0 which still consumes cursor inputs
        GetComponent<CanvasGroup>().blocksRaycasts = selected;
    }
}
