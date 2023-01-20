using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{

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

    public float damage;
    public karäktar player;
    [SerializeField] public bool isBigDog = false;
    public DifficultyMAnager dm;
    public Enemy em;
    Enemies BigDog = new Enemies("Boss", 300, 12.5f, 0.5f);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<karäktar>().playHP -= BigDog.dmg;

        }
    }

    private void Update()
    {
        if (BigDog.hp <= 0)
        {
            Destroy(this.gameObject);
        }

        if (BigDog.hp <= 0 && em.GetComponent<Enemy>().isMedium == true)
        {
            dm.GetComponent<DifficultyMAnager>().mediumIsBeat = true;
        }

        if (BigDog.hp <= 0 && em.GetComponent<Enemy>().isHard == true)
        {
            dm.GetComponent<DifficultyMAnager>().hardIsBeat = true;
        }

    }
}
