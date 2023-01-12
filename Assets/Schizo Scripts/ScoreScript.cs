using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    //gissa
    public int score;
    public int highScore;
    public int coins;
    public int cost;
    
    //upgrades - Adrian
    public bool buySpeed = false;
    public bool buyAttackDmg = false;
    public bool buyStrength = false;
    public bool buyAttackSpeed = false;
    public bool buyHP = false;

    //upgrades cost - Adrian
    public int costSpeed;
    public int costAttackDmg;
    public int costStrength;
    public int costAttackSpeed;
    public int costHP;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        score = 0;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            score++;
            print(score);
        }

        //new highscore
        if (score > highScore)
        {
            highScore = score;
        }

        if (Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene("Adrian 2");
        }
        /*
        if (hP == true && coins >= cost)
        {
            coins -= cost;
            coins -= HP.price;
        }
        */
    }
    
    //allows creation of new item - Adrian
    class PermaUpgrades
    {
        public string name;
        public int price;

        public PermaUpgrades(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }

    //Item list - Adrian
    PermaUpgrades HP = new PermaUpgrades("HP", 50);

    /*
    if(press the HP key && coins >= HP.price)
    {
        coins -= HP.price;
    }
     */
}
