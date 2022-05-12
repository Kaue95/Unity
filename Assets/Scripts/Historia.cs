using UnityEngine;
using System;
using System.Collections;

public class Historia : MonoBehaviour
{

    public Sound[] Vetor1;
    public Sound[] Vetor2;
    private AudioSource source;
    private int historia = 0, direita = 0, esquerda = 1;
    private bool verificacao = false;

    public static Historia instance;
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound som in Vetor1)
        {
            som.source = gameObject.AddComponent<AudioSource>();
            som.source.clip = som.clip;
            som.source.volume = som.volume;
            som.source.loop = som.loop;
        }

        foreach (Sound som2 in Vetor2)
        {
            som2.source = gameObject.AddComponent<AudioSource>();
            som2.source.clip = som2.clip;
            som2.source.volume = som2.volume;
            som2.source.loop = som2.loop;
        }

        Narracao(historia);
        historia++;
        Update();
    }


    public void Narracao(int id)
    {
        Sound som = Array.Find(Vetor1, sound => sound.ID == id);
        Debug.LogWarning("Método chamado!");
        if (som == null)
        {
            Debug.LogWarning("O som: " + id + " não foi encontrado!");
            return;
        }
        if (!verificacao)
        {
            som.source.Play();
        }
        if (som.source.isPlaying)
        {
            verificacao = true;
        }
    }

    public void Escolha(int id)
    {
        Sound som2 = Array.Find(Vetor2, som => som.ID == id);
        Debug.LogWarning("Método chamado!");
        if (som2 == null)
        {
            Debug.LogWarning("O som: " + id + " não foi encontrado!");
            return;
        }
        som2.source.Play();
        source = som2.source;
    }

    void Update()
    {
        StartCoroutine(escolha());
    }

    IEnumerator escolha()
    {
        enabled = true;
        if (!Vetor1[historia].source.isPlaying)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Esquerda");
                Esquerda();
                while (source.isPlaying)
                {
                    yield return null;
                }
                verificacao = false;
                StartCoroutine(rotina());
                yield return enabled = false;

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Direita");
                Direita();
                while (source.isPlaying)
                {
                    yield return null;
                }
                verificacao = false;
                StartCoroutine(rotina());
                yield return enabled = false;
            }

        }
        IEnumerator rotina()
        {
            if (historia == 1)
            {
                Narracao(historia);
                yield return null;
            }
        }

        void Direita()
        {
            if (direita == 0)
            {
                Escolha(direita);
                direita = +2;
                esquerda = +2;
                Debug.Log("Valor da esquerda: " + direita);
            }
        }

        void Esquerda()
        {
            if (esquerda == 1)
            {
                Escolha(esquerda);
                esquerda = +2;
                direita = +2;
                Debug.Log("Valor da esquerda: " + esquerda);
            }
        }
    }
}