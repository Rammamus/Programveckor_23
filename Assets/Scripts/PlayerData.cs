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

    public PlayerData (karäktar kr)
    {
        hp = kr.playHP;
        attacksp = kr.playAttackSpeed;
        dmg = kr.playDMG;
        speed = kr.playSpeed;
    }
}
