using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    public void Activate_deathscreen()
    {
        deathPanel.SetActive(true);
    }
    public void Update()
    {
        //condition for game pause - Adrian
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = true;
        }
        //condition for death screen - Adrian
        if (player.GetComponent<karäktar>().playHP <= 0)
        {
            deathScreen = true;
        }

        if (gamePaused)
        {
            Activate_pausemenu();
        }
        if (deathScreen)
        {
            Activate_deathscreen();
        }
    }
}
