using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DIFFICULITY : MonoBehaviour
{
    public Enemy em; 
    private void Easydiff()
    {
        em.gameObject.GetComponent<Enemy>().isEasy = true;
    }
    private void Mediumdiff()
    {
        em.gameObject.GetComponent<Enemy>().isMedium = true;
    }
    private void HardDiff()
    {
        em.gameObject.GetComponent<Enemy>().isHard = true;
    }
    private void ImpossibleDiff()
    {
        em.gameObject.GetComponent<Enemy>().isImpossible = true;
        print("funkar?");
    }
}
