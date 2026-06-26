using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [Header("Scene Names")]
    public string gameScene = "Game Scene";
    public string homeScene = "Main Scene";

    [Header("Panels")]
    public GameObject settingsPanel;

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameScene);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(homeScene);
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
