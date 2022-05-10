using UnityEngine;
using System;
using UnityEngine.Audio;

public class Historia : MonoBehaviour
{
    public Sound[] sounds;
    private Escolhas escolha;
    private int historia = 0;
    void Start()
    {
        escolha.Play(historia);
    }
}