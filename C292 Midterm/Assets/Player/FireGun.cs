using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    [SerializeField] GameObject laserPrefabRight;
    [SerializeField] GameObject laserPrefabLeft;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (transform.parent.localScale.x == 1)
                Instantiate(laserPrefabRight, transform.position, Quaternion.identity);
            else if (transform.parent.localScale.x == -1)
                Instantiate(laserPrefabLeft, transform.position, Quaternion.identity);


        }
    }
}
