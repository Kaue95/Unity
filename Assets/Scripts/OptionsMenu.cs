using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System;

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

    internal static void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
