using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float speed;
    public DifficultyManager difficultyManager;
    
    void Update()
    {
        
        speed = difficultyManager.GetCurrentSpeed();

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
