using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    private static bool quiting = false;

    public static T Instance
    {
        get
        {
            if (instance == null && !quiting)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                }
            }

            return instance;
        }
        set
        {
            if (instance != value)
            {
                instance = value;
            }
        }
    }

    public void ClearInstance()
    {
        Instance = null;
    }

    public virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        quiting = true;
    }
}