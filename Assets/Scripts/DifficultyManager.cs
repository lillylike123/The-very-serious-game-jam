using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [Header("References")]
    public SpikeManager spikeManager;
    public GroundScroller groundScroller;

    [Header("Difficulty")]
    public float currentSpeed = 6.5f;
    public float maxSpeed = 20f;
    public float speedIncrease = 0.5f;
    private float difficultyTimer = 0f;
    public float difficultyInterval = 10f;

    void Start()
    {
        Debug.Log(
            $"DifficultyManager on {gameObject.name} | Speed={currentSpeed} | Increase={speedIncrease}"
        );
    }

    void Update()
    {
        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyInterval)
        {
            IncreaseDifficulty();
            difficultyTimer = 0f;
        }
    }

    public void IncreaseDifficulty()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedIncrease;

            if (currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
        }

        spikeManager.worldSpeed = currentSpeed;
        groundScroller.speed = currentSpeed;
    }

    public int GetMaxSpikeCount()
    {
        if (currentSpeed >= 14f)
            return 4;

        return 3;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
