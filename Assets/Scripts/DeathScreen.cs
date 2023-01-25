using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public karäktar player;
    public Animator andeath;
    bool isdying = true;
    public float timerdeath = 0;
    public GameObject pausePanel;
    public GameObject deathPanel;
    public Animator runningAnimation;
    bool isrunning = true;
    public bool gamePaused = false;
    public bool deathScreen = false;


    private void Start()
    {
        andeath = GetComponent<Animator>();
        isrunning = GetComponent<Animator>();
    }
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
            // animation when player dies and a timer in 1.1 seconds to deathscreen- Zion
            andeath.SetBool("isdying", true);
            if (isdying == true)
            {
                runningAnimation.SetBool( "isrunning" ,false);
                Time.timeScale = 1;
                timerdeath += Time.deltaTime;
                if (timerdeath > 1.1f)
                {
                    deathScreen = true;
                    timerdeath = 0;
                }


            } 
            
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
