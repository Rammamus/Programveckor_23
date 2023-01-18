using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kar�ktar : MonoBehaviour

{
    //Variables for attacking - Adrian
    public GameObject attack;
    public bool isAttacking = false;
    float attackDis = 0;
    float timer;
    
    // Variables for animation - Zion
    public Animator anim;
    bool isrunning = true;
    bool isrunningWA = true;
    bool idle = true;
    // Variable for SpriteRenderer - Zion
    public SpriteRenderer sR;
   
   



    //Variables for movement and dash - Casper
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode v�nster;
    [SerializeField] KeyCode h�ger;
    [SerializeField] public float playSpeed = 1.6f;
    [SerializeField] TrailRenderer tr;
    [SerializeField] Rigidbody2D rb; 
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

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

    public bool usingSword = false;
    public bool usingAxe = false;

    //Creates weapons - Zion
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

    // Start is called before the first frame update
    void Start()
    {
        playHP = playMAXHP;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        sR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Movement and dashing - Casper
        if (isDashing)
        {
            return; 
        }
        if (Input.GetKey(v�nster))
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(h�ger))
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(up) && transform.position.y < 100)
        {
            transform.position += new Vector3(0, 3, 0) * Time.deltaTime;
        }
        if (Input.GetKey(down) && transform.position.y > -100)
        {
            transform.position += new Vector3(0, -3, 0) * Time.deltaTime;
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
            anim.SetBool("isRunning",true);
            if ( anim != null)
            {
                isrunning = false;// just standing - Zion
            }
        }
        if (usingAxe == true) // should switch to the player with axe
        {
            anim.SetBool("isRunningWA", true);
            if (anim != null)
            {
                isrunningWA = false;
                
            }
        }
        // will switch side of player - Zion
        if (Input.GetKey(v�nster))
        {
            if (true)
            {
               sR.flipX = true;
            }
            if (sR != null)
            {
                sR.flipX = true;
            }
        }
        if (Input.GetKey(h�ger))
        {
            if (true)
            {
                sR.flipX = false;
            }
            
        }



        //check what weapon is used - Zion
        if (usingAxe == true)
        {
            playAttackSpeed = axe.attackSpeed;
            playDMG = axe.dmg;
        
        }
        else if (usingSword == true)
        {
            playAttackSpeed = sword.attackSpeed;
            playDMG = sword.dmg;
            
        }

        //Both activates the attack object and sets a duration timer that deactivates it - Adrian
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1) && timer >= playAttackSpeed)
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
        if (isAttacking == true)
        {
            attackDis += Time.deltaTime;
            if (attackDis > 1.5f)
            {
                attack.SetActive(false);
                isAttacking = false;
                attackDis = 0;
                

            }
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
           
        }
    }



}
