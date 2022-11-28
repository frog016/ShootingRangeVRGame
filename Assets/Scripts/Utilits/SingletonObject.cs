using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T: SingletonObject<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = gameObject.GetComponent<T>();
    }
}
