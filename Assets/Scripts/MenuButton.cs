using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    public GameObject Main;
    public GameObject Options;
    public GameObject Slots;
  

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Main.SetActive(false);
            Options.SetActive(true);
            Slots.SetActive(false);
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Main.SetActive(true);
            Options.SetActive(false);
            Slots.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Slots.SetActive(true);
            Options.SetActive(false);
            Main.SetActive(false);
           
        }else if(Slots == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }

    }

}
