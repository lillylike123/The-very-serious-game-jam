using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class SceneLoader : MonoBehaviour
{
    // This method must be public so the UI Button can see it
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Loads the scene by its exact name
    }
}
