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
    public CoinCounter cc;
    public TMPro.TextMeshProUGUI styrkePris;
    public TMPro.TextMeshProUGUI Attackpris;
    public TMPro.TextMeshProUGUI Speedpris;
    public TMPro.TextMeshProUGUI Healthpris;

    

    
    //All below allows buying perma stat boosts - Adrian
    public void BuyHPStat()
    {
        if (cc.currentCoins >= HP.price)
        {
            cc.DecreaseCoins(HP.price);
            HP.price *= 2;
            StaticVariableHolder.staticMaxHP += 0.1f;
            player.GetComponent<karäktar>().playHP *= StaticVariableHolder.staticMaxHP;
        }

    }

    public void BuyStrengthStat()
    {
        if (cc.currentCoins >= Strength.price)
        {
            cc.DecreaseCoins(Strength.price);
            Strength.price *= 2;
            StaticVariableHolder.staticDMG += 0.1f;
            player.GetComponent<karäktar>().playDMG *= StaticVariableHolder.staticDMG;

        }
    }

    public void BuySpeedStat()
    {
        if (cc.currentCoins >= Speed.price)
        {
            cc.DecreaseCoins(Speed.price);
            Speed.price *= 2;
            StaticVariableHolder.staticSpeed += 0.1f;
            player.GetComponent<karäktar>().playSpeed *= StaticVariableHolder.staticSpeed;
        }
    }

    public void BuyAttackSpeed()
    {
        if (cc.currentCoins >= AttackSpeed.price)
        {
            cc.DecreaseCoins(AttackSpeed.price);
            AttackSpeed.price *= 2;
            StaticVariableHolder.staticAtckSpeed += 0.1f;
            player.GetComponent<karäktar>().playAttackSpeed *= StaticVariableHolder.staticAtckSpeed;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
         score = 0;
        cc = FindObjectOfType<CoinCounter>();
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
    PermaUpgrades HP = new PermaUpgrades("Thicker Jumpsuit", 150);
    PermaUpgrades Strength = new PermaUpgrades("Bicep Curls", 70);
    PermaUpgrades Speed = new PermaUpgrades("New Boots", 110);
    PermaUpgrades AttackSpeed = new PermaUpgrades("Lighter Gloves", 50);
}
