using UnityEngine;
using System;
using System.Collections;

public class Historia : MonoBehaviour
{

    public Sound[] Vetor1;
    public Sound[] Vetor2;
    private AudioSource source, source2;
    private int historia = 0, direita = 0, esquerda = 1;
    private bool verificacao = false, verificacao2 = false;

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


    // Funções que buscam os aúdios no vetores por ID
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
            source2 = som.source;
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
        if (!verificacao2)
        {
            som2.source.Play();
            source = som2.source;
        }
        if(som2.source.isPlaying)
        {
            verificacao2 = true;
        }
    }

    void Update()
    {
        StartCoroutine(escolha());
    }

    // Rotina que capta o input das setas esquerda e direita
    IEnumerator escolha()
    {
        if (!source2.isPlaying)
        {
            Debug.Log("Condição preenchida!");
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Esquerda");
                Esquerda();
                while (source.isPlaying)
                {
                    yield return null;
                }
                verificacao = false;
                Story();
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
                Story();
            }
        }

        // Flag para saber se a condição está funcionando
        /*
        else
        {
            yield return null;
            Debug.Log("Nulo");
        }
        */
        
    }
       
        // Aúdios da história
        public void Story()
        {
            Debug.Log("Valor historia: " + historia);
            if (!source2.isPlaying)
            {
                if (historia == 1)
                {
                    Narracao(historia);
                    historia++;
                    verificacao2 = false;
                }
                else if (historia == 2)
                {
                    Narracao(historia);
                    historia++;
                    verificacao2 = false;

                }
                else if (historia == 3)
                {
                    Narracao(historia);
                    historia++;
                    verificacao2 = false;
                }
            }
        }

        // Escolhas da Direita
        public void Direita()
        {
            if (direita == 0)
            {
                Escolha(direita);
                Debug.Log("Valor da esquerda: " + direita);
            }
        }

        // Escolhas da Esquerda
        public void Esquerda()
        {
            if (esquerda == 1)
            {
                Escolha(esquerda);
                Debug.Log("Valor da esquerda: " + esquerda);
            }
        }
}