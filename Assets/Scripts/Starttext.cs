using UnityEngine;

public class StartText : MonoBehaviour
{
    public float showTime = 4f;

    void Start()
    {
        Invoke(nameof(HideText), showTime);
    }

    void HideText()
    {
        gameObject.SetActive(false);
    }
}
