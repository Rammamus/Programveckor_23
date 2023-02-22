using System.Collections;
using UnityEngine;

public class karäktar : MonoBehaviour

{
    public bool deathScreenBool = false;
    public bool isDying;
    public HealthBar healthBar;
    public Animator andeath;
    //Variables for attacking - Adrian
    public GameObject attack;
    public bool isAttacking = false;
    float attackDis = 0;
    float timer;

    // Variables for animation - Zion
    public DeathScreen deathScreen;
    public Animator runningAnimation;
    public Animator slicingAnimation;
    bool isrunning = true;
    bool isrunningWAx = true;
   
    public Animator animPA;
    bool swosh1 = true;
    // Variable for SpriteRenderer - Zion
    public SpriteRenderer sRSprint;
    public SpriteRenderer sRSlash;

    public Enemy enemy;

    //Variables for movement and dash - Casper
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode vänster;
    [SerializeField] KeyCode höger;
    [SerializeField] public float playSpeed = 1.6f;
    [SerializeField] TrailRenderer tr;
    [SerializeField] Rigidbody2D rb; 
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public int coins;

    //Player stats - Adrian
    public float playHP;
    public float playMAXHP = 100;
    public float playAttackSpeed;
    public float playDMG;

    //audio for different events - Ocean
    public AudioSource dash;
    public AudioSource powerUp;
    public AudioSource axeSlash;
    public AudioSource swordSlash;
    private AudioSource source;
    public AudioClip[] sounds;
    
    // difficulty manager för save.
    public DifficultyMAnager dm;
    public bool hardisenable = false;
    public bool impossibleenable = false;

    public bool usingSword = false;
    public bool usingAxe = false;

    //Creates weapons - Zion
    SpriteRenderer sprite;
    class Weapons
    {
        public string name;
        public float dmg;
        public float attackSpeed;

        public Weapons(string name, float dmg, float attackspeed)
        {
            this.name = name;
            this.dmg = dmg;
            this.attackSpeed = attackspeed;
        }
    }
    Weapons sword = new Weapons("Sword", 20, 3);
    Weapons axe = new Weapons("Axe", 30, 5);


    float timerdeath = 0;

    // Start is called before the first frame update
    void Start()
    {
        playHP = playMAXHP;
        runningAnimation = GetComponent<Animator>();
        animPA = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        sRSprint = GetComponent<SpriteRenderer>();
        sRSlash = GetComponent<SpriteRenderer>();
        andeath = GetComponent<Animator>();
    }

    void Update()
    {
        healthBar.SetHealth(playHP);

        //Movement and dashing - Casper
        if (isDashing)
        {
            return; 
        }
        if (Input.GetKey(vänster))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * playSpeed;
        }
        if (Input.GetKey(höger))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * playSpeed;
        }
        if (Input.GetKey(up) && transform.position.y < 100)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * playSpeed;
        }
        if (Input.GetKey(down) && transform.position.y > -100)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * playSpeed;
        }

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
            dash.Play();
        }
        if (Input.GetKeyDown(KeyCode.Q) && canDash)
        {
            StartCoroutine(Dash2());
            dash.Play();
        }

        // The Animation for run cycle- Zion
      
        if (isrunning == true)
        {
            runningAnimation.SetBool("isRunning",true);
            if ( runningAnimation != null)
            {
                isrunning = false;// just standing - Zion
            }
        }
        if (usingAxe == true)
        {
            runningAnimation.SetBool("isRunningWAx", true);
            if (usingAxe != null)
            {
                isrunningWAx = false;// just standing - Zion
            }
        }
        
        
        //check what weapon is used - Zion
        if (usingAxe == true)
        {
            playAttackSpeed = axe.attackSpeed;
            playDMG = axe.dmg;
            axeSlash.Play();
        }
        else if (usingSword == true)
        {
            playAttackSpeed = sword.attackSpeed;
            playDMG = sword.dmg;
            swordSlash.Play();
            
        }
        
        // the player will switch-Zion
        if (Input.GetKey(vänster))
        {
            if (true)
            {
                sRSprint.flipX = true;
            }
            if (sRSprint != null)
            {
                sRSprint.flipX = true;
            }
        }
        if (Input.GetKey(höger))
        {
            if (true)
            {
                sRSprint.flipX = false;
            }

        }


        //Both activates the attack object and sets a duration timer that deactivates it - Adrian
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer >= playAttackSpeed)
        {
            attack.SetActive(true);
            timer = 0;
            isAttacking = true;
            if (usingAxe == true)
            {
                axeSlash.Play();
            }
            else if (usingSword == true)
            {
                swordSlash.Play();
            }
        }

        // animation for attack-swoshen- Zion
        if (attack == true)
        {
            animPA.SetBool("swosh1", true);
            attackDis += Time.deltaTime;
            if (attackDis > 0.5f)
            {
              animPA.SetBool("swosh1", false);
                attack.SetActive(false);
                swosh1 = false;
                attackDis = 0;
                isAttacking = false;
            }
        }
        //condition for death screen - Adrian
        if (playHP <= 0)
        {
            print("hasdied?");
            // animation when player dies and a timer in 1.1 seconds before deathscreen- Zion
            animPA.SetBool("isdying", true);
            //if (isDying == true)
            //{
                animPA.SetBool("isRunning", false);
                Time.timeScale = 1;
                timerdeath += Time.deltaTime;
                print("timer");
                if (timerdeath > 1.1f)
                {
                    print("heh");
                    deathScreenBool = true;
                    timerdeath = 0;
                    isDying = false;
                }
            //}
        }
        if (deathScreenBool == true)
        {
            print("hasdied");
            deathScreen.Activate_deathscreen();
        }
    }

    //function for dashing right - Casper
    private IEnumerator Dash()
    {
        canDash = false; 
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        if (isDashing == false)
        {
            rb.velocity = new Vector2(0f,  0f);
        }
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true; 
    }

    //function for dashing left - Casper
    private IEnumerator Dash2()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        if (isDashing == false)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
            sprite.color = Color.red;
            sprite.color = Color.white;
            playHP -= enemy.GetComponent<Enemy>().enemyDMG;
            print(playHP);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
            sprite.color = Color.red;
            sprite.color = Color.white;
            playHP -= enemy.GetComponent<Enemy>().enemyDMG;
            print(playHP);
        }
    }

    public void savePlayer ()
    {
        savesystem.SavePlayer(this);
    }
    public void loadPlayer()
    {
        PlayerData data = savesystem.LoadPlayer();

        playHP = data.hp;
        playAttackSpeed = data.attacksp;
        playDMG = data.dmg;
        playSpeed = data.speed;
        hardisenable = data.hardlockedstate;
        impossibleenable = data.impossiblelockedstate;


    }

}
