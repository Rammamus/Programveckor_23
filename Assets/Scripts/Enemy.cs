using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy BabyGlassPreFab1;
    public Enemy BabyGlassPreFab2;
    public Enemy BabyGlassPreFab3;
    public Transform LaunchOffset;

    public bool hasSpawned = false;
    public bool isImmortal = false;
    float immortalTimer = 0;

    //stats for enemies - Adrian
    public float enemyHP;
    public float enemyDMG;
    public float enemySpeed;

    public bool isEasy = false;
    public bool isMedium = false;
    public bool isHard = false;
    public bool isImpossible = false;

    // Variables for animation - Zion
    public Animator anima;
    bool isrunningM = true;
    public Animator animat;
    bool isAttackingM = true;

    public float moveSpeed;

    // Variable for SpriteRenderer - Zion
    public SpriteRenderer sR;

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
    public bool canSpawnBabies = true;

    private GameObject player;
    private GameObject testEnemy;
    public karäktar karaktär;
    Vector3 dir;

    //Checks what enemy type it is - Adrian
    [SerializeField] public bool isDog = false;
    [SerializeField] public bool isGlass = false;
    [SerializeField] public bool isBabyGlass1 = false;
    [SerializeField] public bool isBabyGlass2 = false;
    [SerializeField] public bool isBabyGlass3 = false;


    //REMEMBER TO MAKE A CONDITION FOR THIS - Adrian
    public bool inPlayProx = false;

    //audiosource -ocran
    [SerializeField] AudioSource sfxShatter;

    void Start()
    {

        sfxShatter = GetComponent<AudioSource>();

        animat= GetComponent<Animator>();
        testEnemy = GameObject.FindGameObjectWithTag("Enemy");
        anima = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
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
        else if (isBabyGlass1 || isBabyGlass2 || isBabyGlass3)
        {
            enemyHP = babyGlass.hp;
            enemyDMG = babyGlass.dmg;
            enemySpeed = babyGlass.speed;
            isImmortal = true;
        }

        //changes enemy stats with game difficulty - Casper
        if (StaticVariableHolder.staticEasy == true)
        {
            enemyHP *= 0.5f;
            enemyDMG *= 0.5f;
        }
        if (StaticVariableHolder.staticMedium == true)
        {
            enemyHP *= 1f;
            enemyDMG *= 1f;
        }
        if (StaticVariableHolder.staticHard == true)
        {
            enemyHP *= 1.25f;
            enemyDMG *= 1.5f;
        }
        if (StaticVariableHolder.staticImpossible == true)
        {
            enemyHP *= 1.5f;
            enemyDMG *= 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        immortalTimer += Time.deltaTime;
        if (immortalTimer > 1)
        {
            print("no longer");
            isImmortal = false;
        }
        Swarm(); //Enemy always follow player - William

        //Enemy die if 0hp or under and spawns small babies if glass enemy - Adrian
        if (enemyHP <= 0 && !isGlass && isImmortal == false)
        {
            Destroy(this.gameObject);
            anima.SetBool("IsDead", true);
        }
        if (isGlass && enemyHP <= 0 && canSpawnBabies == true)
        {

            print("hhgh");
            Instantiate(BabyGlassPreFab1, LaunchOffset.position, transform.rotation);
            Instantiate(BabyGlassPreFab2, LaunchOffset.position, transform.rotation);
            Instantiate(BabyGlassPreFab3, LaunchOffset.position, transform.rotation);
            hasSpawned = true;
        }
        if (isGlass && enemyHP <= 0 && hasSpawned)
        {
            sfxShatter.Play();
            Destroy(this.gameObject);
        }

        // The Animation for monster run cycle- Zion

        if (isrunningM == true)
        {
            anima.SetBool("isrunningM", true);
            if (anima != null)
            {
                isrunningM = false;
            }
        }
        // will switch side of monster - Zion

        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
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
            player.GetComponent<karäktar>().playHP -= enemyDMG;
            print(player.GetComponent<karäktar>().playHP);
        }



        // The Animation for monster attack- Zion

        if ((collider.CompareTag("Player") == true) && isDog)
        {
            animat.SetBool("isAttackingM", true);
            if (animat != null)
            {
                isAttackingM = false;
            }
        }
        if (collider.CompareTag("Attack") && isImmortal == false)
        {
            enemyHP -= GameObject.FindObjectOfType<karäktar>().playDMG;
        }
    }

}

