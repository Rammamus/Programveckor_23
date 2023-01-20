using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float attacksp;
    public float hp;
    public float dmg;
    public float speed;
    public bool hardlockedstate;
    public bool impossiblelockedstate;
    public ScoreScript ss;
    public int prishp;
    public int prisspeed;
    public int prisdmg;
    public int prisattacksp; // fixa save f�r shop priserna.
   // en del av save script -- casper
    public PlayerData (kar�ktar kr)
    {
        hp = kr.playHP;
        attacksp = kr.playAttackSpeed;
        dmg = kr.playDMG;
        speed = kr.playSpeed;
        
    }
}
