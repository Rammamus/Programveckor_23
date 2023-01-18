using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //stats for enemies - Adrian
    public float enemyHP;
    public float enemyDMG;
    public float enemySpeed;

    public bool isEasy = false;
    public bool isMedium = false;
    public bool isHard = false;
    public bool isImpossible = false;

    //allows for creating different enemy types - Adrian
    class Enemies
    {
        public string name;
        public float hp;
        public float dmg;
        public float speed;

        public Enemies(string name, float hp, float dmg, float speed)
        {
            this.name = name;
            this.hp = hp;
            this.dmg = dmg;
            this.speed = speed;
        }
    }

    //creates the different enemy types - Adrian
    Enemies dog = new Enemies("Dog", 30, 10, 2.5f);
    Enemies glass = new Enemies("Glass", 40, 15, 1.5f);
    Enemies babyGlass = new Enemies("Baby Glass", 20, 7.5f, 2.5f);

    private GameObject player;

    //Checks what enemy type it is - Adrian
    [SerializeField] public bool isDog = false;
    [SerializeField] public bool isGlass = false;
    [SerializeField] public bool isBabyGlass = false;


    //REMEMBER TO MAKE A CONDITION FOR THIS - Adrian
    public bool inPlayProx = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //checks enemy type and changes stats accordingly - Adrian
        if (isDog == true)
        {
            enemyHP = dog.hp;
            enemyDMG = dog.dmg;
            enemySpeed = dog.speed;
        }
        else if (isGlass == true)
        {
            enemyHP = glass.hp;
            enemyDMG = glass.dmg;
            enemySpeed = glass.speed;
        }
        else if (isBabyGlass)
        {
            enemyHP = babyGlass.hp;
            enemyDMG = babyGlass.dmg;
            enemySpeed = babyGlass.speed;
        }

        //changes enemy stats with game difficulty - Casper
        if (isEasy == true)
        {
            enemyHP *= 0.5f;
            enemyDMG *= 0.5f;
        }
        if (isMedium == true)
        {
            enemyHP *= 1f;
            enemyDMG *= 1f;
        }
        if (isHard == true)
        {
            enemyHP *= 1.25f;
            enemyDMG *= 1.5f;
        }
        if (isImpossible == true)
        {
            enemyHP *= 1.5f;
            enemyDMG *= 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Swarm(); //Enemy always follow player - William

        //Enemy die if 0hp or under - Adrian
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //makes enemies move towareds player - William
    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<kar�ktar>() != null)
            {
                collider.GetComponent<kar�ktar>().playHP -= enemyDMG;
            }
        }
        if (collider.CompareTag("Attack"))
        {
            enemyHP -= GameObject.FindObjectOfType<kar�ktar>().playDMG;
        }
    }

}

