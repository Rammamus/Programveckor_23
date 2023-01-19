using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    public int value;
}
public class ScoreScript : MonoBehaviour
{
    //gissa
    public int score;
    public int highScore;
    public int coins;
    public karäktar player;
    public TMPro.TextMeshProUGUI styrkePris;
    public TMPro.TextMeshProUGUI Attackpris;
    public TMPro.TextMeshProUGUI Speedpris;
    public TMPro.TextMeshProUGUI Healthpris;
    //All below allows buying perma stat boosts - Adrian
    public void BuyHPStat()
    {
        if (coins >= HP.price)
        {
            coins -= HP.price;
            HP.price *= 2;
            player.GetComponent<karäktar>().playHP *= 1.1f;
        }

    }

    public void BuyStrengthStat()
    {
        if (coins >= Strength.price)
        {
            coins -= Strength.price;
            Strength.price *= 2;
            player.GetComponent<karäktar>().playDMG *= 1.1f;

        }
    }

    public void BuySpeedStat()
    {
        if (coins >= Speed.price)
        {
            coins -= Speed.price;
            Speed.price *= 2;
            player.GetComponent<karäktar>().playSpeed *= 1.1f;
        }
    }

    public void BuyAttackSpeed()
    {
        if (coins >= AttackSpeed.price)
        {
            coins -= AttackSpeed.price;
            AttackSpeed.price *= 2;
            player.GetComponent<karäktar>().playAttackSpeed *= 1.1f;
        }
    }

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
        coins = player.GetComponent<karäktar>().coins;

        if (Input.GetKey(KeyCode.Space))
        {
            score++;
            print(score);
        }
        

        //new highscore - Adrian
        if (score > highScore)
        {
            highScore = score;
        }
    }

  
    //allows creation of new items - Adrian
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
    PermaUpgrades HP = new PermaUpgrades("Thicker Jumpsuit", 50);
    PermaUpgrades Strength = new PermaUpgrades("Bicep Curls", 50);
    PermaUpgrades Speed = new PermaUpgrades("New Boots", 50);
    PermaUpgrades AttackSpeed = new PermaUpgrades("Lighter Gloves", 50);
}
