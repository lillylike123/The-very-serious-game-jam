using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [Header("References")]
    public GameObject spikePrefab;
    public Rigidbody2D playerRB;

    [Header("Movement")]
    public float worldSpeed;

    [Header("Spawn Position")]
    public float spawnX = 20f;
    public float floorY = -3.5f;
    public float ceilingY = 3.85f;

    [Header("Spawn Timing")]
    public float spawnInterval = 1.5f;

    [Header("Cleanup")]
    public float destroyX = -20f;
    public DifficultyManager difficultyManager;
    private float spawnTimer;
    public ChaosEffectManager chaosManager;
    public ChaosWheel chaosWheel;


    void Update()
    {
        MoveSpikes();
        worldSpeed = difficultyManager.GetCurrentSpeed();

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnGroup();
            spawnTimer = 0f;
        }
    }

    void SpawnSpikyFloor()
    {
        float spacing = 2.5f;

        for (int i = 0; i < 12; i++)
        {
            Instantiate(
                spikePrefab,
                new Vector3(
                    spawnX + i * spacing,
                    -3.5f,
                    -1f
                ),
                Quaternion.identity
            );
        }
    }

    void SpawnGroup()
    {
        if (chaosManager.IsFlappyMode())
        {
            if (chaosManager.IsSpikyFloor())
            {
                SpawnSpikyFloor();
                return;
            }
            
            if (chaosWheel.GetTimer() > 5f)
            {
            SpawnFlappyWall();
            }

            return;
        }

        if (chaosManager != null && chaosManager.IsFlappyMode())
        {
            SpawnFlappyWall();
            return;
        }

        bool ceilingMode =
            playerRB != null &&
            playerRB.gravityScale < 0;

        float spawnY =
            ceilingMode
            ? ceilingY
            : floorY;

        int spikeCount =
            Random.Range(
                1,
                difficultyManager.GetMaxSpikeCount() + 1
            );

        for (int i = 0; i < spikeCount; i++)
        {
            GameObject spike =
                Instantiate(
                    spikePrefab,
                    new Vector3(
                        spawnX + i,
                        spawnY,
                        -1f
                    ),
                    Quaternion.identity
                );

            if (ceilingMode)
            {
                spike.transform.rotation =
                    Quaternion.Euler(
                        0,
                        0,
                        180
                    );
            }
        }
    }

    void MoveSpikes()
    {
        GameObject[] spikes =
            GameObject.FindGameObjectsWithTag(
                "Spike"
            );

        foreach (GameObject spike in spikes)
        {
            spike.transform.Translate(
                Vector3.left *
                worldSpeed *
                Time.deltaTime,
                Space.World
            );

            if (spike.transform.position.x < destroyX)
            {
                Destroy(spike);
            }
        }
    }

    void SpawnFlappyWall()
    {
        for (int i = 0; i < 15; i++)
        {
            Instantiate(
                spikePrefab,
                new Vector3(
                    spawnX + i,
                    -3.5f,
                    -1f
                ),
                Quaternion.identity
            );

            GameObject topSpike =
                Instantiate(
                    spikePrefab,
                    new Vector3(
                        spawnX + i,
                        3.85f,
                        -1f
                    ),
                    Quaternion.Euler(
                        0,
                        0,
                        180
                    )
            );
        }
    }

    public void ClearAllSpikes()
    {
        GameObject[] spikes =
            GameObject.FindGameObjectsWithTag("Spike");

        foreach (GameObject spike in spikes)
        {
            Destroy(spike);
        }
    }

}

