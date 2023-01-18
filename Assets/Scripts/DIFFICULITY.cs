using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DIFFICULITY : MonoBehaviour
{
    public Enemy em; 
    public void Easydiff()
    {
        em.gameObject.GetComponent<Enemy>().isEasy = true;
    }
    public void Mediumdiff()
    {
        em.gameObject.GetComponent<Enemy>().isMedium = true;
    }
    public void HardDiff()
    {
        em.gameObject.GetComponent<Enemy>().isHard = true;
        
    }
    public void ImpossibleDiff()
    {
        em.gameObject.GetComponent<Enemy>().isImpossible = true;
        
    }
}
