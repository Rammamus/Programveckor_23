using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform target;
    public GameObject prefab;

    void Start()
    {
        prefab = Instantiate(prefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        prefab.transform.rotation = target.rotation;
    }
}
