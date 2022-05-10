using UnityEngine;
using System;
using UnityEngine.Audio;

public class Escolhas : MonoBehaviour
{

    public Sound[] sounds;
    private int esquerda = 0;
    private int direita = 1;

    public static Escolhas instance;
    void Awake()
    {

        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Play (int id)
    {
        Sound s =  Array.Find(sounds, sound => sound.ID == id);
        Debug.LogWarning("Método chamado!");
        if (s == null)
        {
            Debug.LogWarning("O som: " + id + " não foi encontrado!");
            return;
        }
        s.source.Play();
    }

    public void Escolha()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Esquerdo();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direito();
        }
    }

    public void Direito()
    {
            if (sounds[direita].ID == 1)
            {
                Play(direita);
                if (sounds[direita].source.isPlaying)
                {
                    direita += 2;
                }
            }
            else if (sounds[direita].ID == 3)
            {
                if (!sounds[direita - 2].source.isPlaying)
                {
                    Play(direita);
                    direita += 2;
                }
            }
            else if (sounds[direita].ID == 5)
            {
                if (!sounds[direita - 2].source.isPlaying)
                {
                    Play(direita);
                    direita += 2;
                }
            }
            Debug.LogWarning("Fim direita!");
    }

    public void Esquerdo()
    {

            if (sounds[esquerda].ID == 0)
            {
                Play(esquerda);
                if (sounds[esquerda].source.isPlaying)
                {
                    esquerda += 2;
                }
            }
            else if (sounds[esquerda].ID == 2)
            {
                if (!sounds[esquerda - 2].source.isPlaying)
                {
                    Play(esquerda);
                    esquerda += 2;
                }
            }
            else if (sounds[esquerda].ID == 4)
            {
                if (!sounds[esquerda - 2].source.isPlaying)
                {
                    Play(esquerda);
                    esquerda += 2;
                }
            }
            Debug.LogWarning("Fim esquerda!");
        
    }
}

