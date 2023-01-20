using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//Laddar in en scene - casper

public class MAINMENU : MonoBehaviour
{
    public AudioSource clickSound;

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // byt ut 1an mot gamescene
        clickSound.Play();
 
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

   
}
