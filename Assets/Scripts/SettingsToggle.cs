using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsToggle : MonoBehaviour
{
    public Toggle toggle;

    public Image background;
    public TMP_Text label;

    public bool controlsMusic;

    Color green = new Color32(77, 255, 77, 255);
    Color white = Color.white;

    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);

        OnToggleChanged(toggle.isOn);
    }

    void OnToggleChanged(bool value)
    {
        AudioManager.Instance.PlayButtonSound();
        
        if (value)
        {
            background.color = green;
            label.color = green;

            if (controlsMusic)
                AudioManager.Instance.SetMusic(true);
            else
                AudioManager.Instance.SetSound(true);
        }
        else
        {
            background.color = white;
            label.color = white;

            if (controlsMusic)
                AudioManager.Instance.SetMusic(false);
            else
                AudioManager.Instance.SetSound(false);
        }

        AudioManager.Instance.PlayButtonSound();
    }
}

