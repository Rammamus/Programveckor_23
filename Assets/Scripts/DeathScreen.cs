using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public karäktar player;

    public GameObject pausePanel;
    public GameObject deathPanel;

    public bool gamePaused = false;
    public bool deathScreen = false;
    public void Activate_pausemenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void DeActivate_pausemenu()
    {
        pausePanel.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
        print("deactive");
    }
    public void Activate_deathscreen()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Update()
    {
        //condition for game pause - Adrian
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Activate_pausemenu();
        }
        //condition for death screen - Adrian
        if (player.GetComponent<karäktar>().playHP <= 0)
        {
            deathScreen = true;
        }
        if (deathScreen)
        {
            Activate_deathscreen();
        }
    }

    public void Lobby ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
 
    

}
