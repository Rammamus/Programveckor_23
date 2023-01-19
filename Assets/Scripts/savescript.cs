using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savescript 
{
    public float hp;
    public DifficultyMAnager dm;
    public float speed;
    public float attacksp;
    public float styrka;
    public bool impossiblelockedstate;
    public bool hardlockedstate;
    

    public savescript (karäktar kr)
    {
        hp = kr.playHP;
        speed = kr.playSpeed;
        attacksp = kr.playAttackSpeed;
        styrka = kr.playDMG;
        

    }
}
