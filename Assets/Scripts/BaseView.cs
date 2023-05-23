using UnityEngine;

/// <summary>
/// Class used for providing simples methods for UI views.
/// </summary>
public class BaseView : MonoBehaviour
{
    /// <summary>
    /// Method called to show view
    /// </summary>
    public virtual void ShowView()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Method called to hide view
    /// </summary>
    public virtual void HideView()
    {
        gameObject.SetActive(false);
    }
}