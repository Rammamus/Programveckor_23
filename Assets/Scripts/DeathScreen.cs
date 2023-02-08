using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//gjord av Adrian
public class DeathScreen : MonoBehaviour
{
    public kar�ktar player;
    bool isdying = true;
    public float timerdeath = 0;
    public GameObject pausePanel;
    public GameObject deathPanel;
    public Animator anim;
    bool isrunning = true;
    public bool gamePaused = false;
    public bool deathScreen = false;

    public TMPro.TextMeshProUGUI coinTextpls;

    private void Start()
    {
        anim = GetComponent<Animator>();
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
        if (coinTextpls != null)
        {
            coinTextpls.text = StaticVariableHolder.test + " " + StaticVariableHolder.permaCoins.ToString();
        }
        
        //condition for game pause - Adrian
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Activate_pausemenu();
        }
    }

    public void Lobby ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
 
    

}
