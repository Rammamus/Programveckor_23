using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//svårhets graderna. -Casper.
public class DIFFICULITY : MonoBehaviour
{
    public Enemy em;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Easydiff()
    {
        StaticVariableHolder.test = "easy";
        StaticVariableHolder.staticEasy = true;
        StaticVariableHolder.staticMedium = false;
        StaticVariableHolder.staticHard = false;
        StaticVariableHolder.staticImpossible = false;
        em.gameObject.GetComponent<Enemy>().isEasy = true;
    }
    public void Mediumdiff()
    {
        StaticVariableHolder.test = "Medium";
        StaticVariableHolder.staticEasy = false;
        StaticVariableHolder.staticMedium = true;
        StaticVariableHolder.staticHard = false;
        StaticVariableHolder.staticImpossible = false;
        em.gameObject.GetComponent<Enemy>().isMedium = true;
    }
    public void HardDiff()
    {
        StaticVariableHolder.test = "Hard";
        StaticVariableHolder.staticEasy = false;
        StaticVariableHolder.staticMedium = false;
        StaticVariableHolder.staticHard = true;
        StaticVariableHolder.staticImpossible = false;
        em.gameObject.GetComponent<Enemy>().isHard = true;
        
    }
    public void ImpossibleDiff()
    {
        StaticVariableHolder.test = "Impos";
        StaticVariableHolder.staticEasy = false;
        StaticVariableHolder.staticMedium = false;
        StaticVariableHolder.staticHard = false;
        StaticVariableHolder.staticImpossible = true;
        em.gameObject.GetComponent<Enemy>().isImpossible = true;
        
    }
}
