using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOffsetScriprt : MonoBehaviour
{
    public Transform target;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab.transform.rotation = target.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) + 180f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
