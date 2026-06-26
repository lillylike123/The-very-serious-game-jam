using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsPanel : MonoBehaviour
{
    void Update()
    {
        if (!gameObject.activeSelf)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(
                GetComponent<RectTransform>(),
                Input.mousePosition))
            {
                gameObject.SetActive(false);
            }
        }
    }
}

