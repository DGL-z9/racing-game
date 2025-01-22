using UnityEngine;

public class Singleton<T> : MonoBehaviour where T :MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "Auto Generate" + typeof(T).Name;
                    obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }

        OnAwake();
    }

    private void OnAwake()
    {
    }
}
