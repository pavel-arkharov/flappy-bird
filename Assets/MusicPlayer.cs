using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}