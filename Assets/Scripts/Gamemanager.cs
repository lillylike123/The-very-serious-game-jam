using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathPanel;

    public void GameOver()
    {
        Debug.Log("Inside GameOver");
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void GoHome()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("HomeScene");
    }
}



