using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karäktar : MonoBehaviour

{
    //Variables for attacking - Adrian
    public BulletScript ProjectilePreFab;
    public Transform LaunchOffset;
    float timer;

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

    //Player stats - Adrian
    public float playHP;
    public float playMAXHP = 100;
    public float playAttackSpeed;
    public float playDMG;

    //audio for different events - Ocean
    public AudioSource dash;
    public AudioSource hurt;
    public AudioSource powerUp;

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
    }

    // Update is called once per frame
    void Update()
    {
        //Movement and dashing - Casper
        if (isDashing)
        {
            return; 
        }
        if (Input.GetKey(vänster))
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(höger))
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
            print("högerdash");
            dash.Play();
        }
        if (Input.GetKeyDown(KeyCode.Q) && canDash)
        {
            StartCoroutine(Dash2());
            print("vänsterdash");
            dash.Play();
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
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1) && timer >= playAttackSpeed)
        {
            print("he attack");
            Instantiate(ProjectilePreFab, LaunchOffset.position, transform.rotation);
            timer = 0;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
