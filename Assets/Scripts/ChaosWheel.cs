using UnityEngine;
using TMPro;
using System.Collections;

public class ChaosWheel : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public ChaosUIManager uiManager;
    public SpikeManager spikeManager;

    public ChaosEffectManager chaosManager;
    private bool spikesCleared = false;
    public DifficultyManager difficultyManager;

    private float timer = 20f;

    private string[] chaosList =
    {
        "Gravity Flip",
        "Jump Flipping",
        "Flappy Mode",
        "Spiky Floor"
    };

    private bool spinning = false;

    void Update()
    {
        if (spinning)
            return;

        timer -= Time.deltaTime;

        timerText.text = Mathf.Ceil(timer).ToString();

        if (timer <= 0)
        {
            StartCoroutine(SpinWheel());
        }
    }

    IEnumerator SpinWheel()
    {
        spinning = true;
        spikesCleared = false;

        chaosManager.StopCurrentChaos();

        float spinTime = 3f;

        while (spinTime > 0)
        {
            transform.Rotate(
                0,
                0,
                -500 * Time.deltaTime
            );

            spinTime -= Time.deltaTime;

            // 2 seconds into the spin, clear all spikes
            if (!spikesCleared && spinTime <= 1f)
            {
                spikeManager.ClearAllSpikes();
                spikesCleared = true;
            }

            yield return null;
        }

        // Finish the last second of spinning
        yield return new WaitForSeconds(1f);

        string selectedChaos =
            chaosList[
                Random.Range(
                    0,
                    chaosList.Length
                )
            ];

        uiManager.ShowChaos(selectedChaos);

        chaosManager.ActivateChaos(selectedChaos);

        timer = 20f;

        spinning = false;
    }

    public float GetTimer()
    {
        return timer;
    }

}

