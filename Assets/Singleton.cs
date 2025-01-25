using UnityEngine;

public class Singleton : MonoBehaviour
{
    //Sets this as a DontDestroyOnLoad and hopefully does the same for all children. Should save some trouble.
    private static Singleton _instance; private void Awake() { if (_instance != null) Destroy(this.gameObject); DontDestroyOnLoad(this.gameObject); _instance = this; }
}
