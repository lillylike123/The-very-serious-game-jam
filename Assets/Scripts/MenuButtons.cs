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
        AudioManager.Instance.PlayButtonSound();

        Time.timeScale = 1f;
        SceneManager.LoadScene(gameScene);
    }

    public void Home()
    {
        AudioManager.Instance.PlayButtonSound();
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(homeScene);
    }

    public void OpenSettings()
    {
        AudioManager.Instance.PlayButtonSound();


        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        AudioManager.Instance.PlayButtonSound();


        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void Resume()
    {
        AudioManager.Instance.PlayButtonSound();

        Time.timeScale = 1f;

        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlayButtonSound();

        Application.Quit();
    }
}
