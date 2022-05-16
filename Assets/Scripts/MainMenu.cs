using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator fade;
   public void PlayGame()
    {
        StartCoroutine(Play(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Play(int index)
    {
        fade.SetTrigger("Start");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(index);
    }

    internal static void SetActive(bool v)
    {
        throw new NotImplementedException();
    }
}
