using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    //Checks what enemy type it is - Adrian
    [SerializeField] public bool isDog = false;
    [SerializeField] public bool isGlass = false;
    [SerializeField] public bool isBabyGlass = false;


    //REMEMBER TO MAKE A CONDITION FOR THIS - Adrian
    public bool inPlayProx = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }


    //makes enemies move towareds player - William
    private void Swarm()
    {
        if (isDog == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, dog.speed * Time.deltaTime);
        }
        if (isGlass == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, glass.speed * Time.deltaTime);
        }
        if (isBabyGlass == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, babyGlass.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            //checks the different enemy types to select right amount of damage - Adrian
            if(collider.GetComponent<karäktar>( ) != null && isDog == true)
            {
                collider.GetComponent<karäktar>().playHP -= dog.dmg;
            }
            if (collider.GetComponent<karäktar>() != null && isGlass == true)
            {
                collider.GetComponent<karäktar>().playHP -= glass.dmg;
            }
            if (collider.GetComponent<karäktar>() != null && isBabyGlass == true)
            {
                collider.GetComponent<karäktar>().playHP -= babyGlass.dmg;
            }
        }
    }
}
