using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10 (volume) * 20);
    }

    public void SetNarration(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
