using UnityEngine;
using TMPro;
using System.Collections;

public class ChaosUIManager : MonoBehaviour
{
    public TextMeshProUGUI chaosText;

    public void ShowChaos(string chaosName)
    {
        StartCoroutine(
            ShowChaosRoutine(
                chaosName
            )
        );
    }

    IEnumerator ShowChaosRoutine(
        string chaosName
    )
    {
        chaosText.gameObject.SetActive(true);

        chaosText.text =
            chaosName.ToUpper();

        yield return new WaitForSeconds(2f);

        chaosText.gameObject.SetActive(false);
    }
}

