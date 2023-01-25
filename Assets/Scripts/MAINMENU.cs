using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//Laddar in en scene - casper

public class MAINMENU : MonoBehaviour
{
    public AudioSource clickSound;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // byt ut 1an mot gamescene
        clickSound.Play();
        Time.timeScale = 1;
 
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

   
}
