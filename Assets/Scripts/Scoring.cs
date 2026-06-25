using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private float score;

    void Update()
    {
        score += Time.deltaTime * 10f;

        scoreText.text = 
            " " + Mathf.FloorToInt(score);
    }
}
