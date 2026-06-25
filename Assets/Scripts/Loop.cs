using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    public float leftLimit = -25f;
    public float resetX = 25f;

    void Update()
    {
        if(transform.position.x < leftLimit)
        {
            transform.position =
                new Vector3(
                    resetX,
                    transform.position.y,
                    transform.position.z
                );
        }
    }
}
