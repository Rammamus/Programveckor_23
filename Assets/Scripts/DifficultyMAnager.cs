using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMAnager : MonoBehaviour
{
    public bool mediumIsBeat = false;
    public bool hardIsBeat = false;
    public bool hardIsUnlock = false;
    public bool bossDeadMedium = false;
    public bool bossDeadHard = false;
    public bool impossibleisUnlock = false;
    public bool impossibleLocked = true;
    public bool hardLocked = true;
    public GameObject hardbutton;
    public GameObject impossibleButton;
    public GameObject hardlockedButton;
    public GameObject impossibleLockedButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //unlockar olika svårhetsgrader - casper
    // Update is called once per frame
    void Update()
    {
        if (bossDeadMedium == true)
        {
            mediumIsBeat = true; 
        }


        if (mediumIsBeat == true)
        {
            hardIsUnlock = true;
            StaticVariableHolder.staticUnlockHard = true;
        }

        if (hardIsBeat == true)
        {
            impossibleisUnlock = true;
            StaticVariableHolder.staticUnlockImpos = true;
        }

        if (StaticVariableHolder.staticUnlockHard == false)
        {
            hardbutton.SetActive(false);
            hardlockedButton.SetActive(true);

        }
        else if (StaticVariableHolder.staticUnlockHard == true)
        {
            hardbutton.SetActive(true);
            hardlockedButton.SetActive(false);
        }

        if (StaticVariableHolder.staticUnlockImpos == false)
        {
            impossibleButton.SetActive(false);
            impossibleLockedButton.SetActive(true);
        } 
        else if (StaticVariableHolder.staticUnlockImpos == true)
        {
            impossibleButton.SetActive(true);
            impossibleLockedButton.SetActive(false);
        }
        

    }

    
}