using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    public bool keepDontDestroyOnLoad;

    private static T instance;

    // Property to get the instance of the singleton
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // Try to find an existing instance in the scene
                instance = FindObjectOfType<T>();

                // If no instance is found, create a new GameObject and attach the component
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // Ensure there is only one instance of this script in the scene
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // If this is the first instance, set it as the instance
        instance = this as T;

        if (!keepDontDestroyOnLoad)
        {
            return;
        }

        // Keep the GameObject that holds this script between scenes
        DontDestroyOnLoad(this.gameObject);
    }
}
