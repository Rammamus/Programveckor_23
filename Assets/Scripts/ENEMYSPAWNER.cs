using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfEnemies= 0;
    public GameObject[] typeOfEnemies;

}

public class ENEMYSPAWNER : MonoBehaviour
{
    [SerializeField] Wave[] waves;
}
