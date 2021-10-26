using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    [SerializeField] GameObject laserPrefabRight;
    [SerializeField] GameObject laserPrefabLeft;
    [SerializeField] GameObject laserPrefabUp;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                if (transform.parent.localScale.x == 1)
                    Instantiate(laserPrefabRight, transform.position, Quaternion.identity);
                else if (transform.parent.localScale.x == -1)
                    Instantiate(laserPrefabLeft, transform.position, Quaternion.identity);
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                Instantiate(laserPrefabUp, transform.position, Quaternion.identity * Quaternion.Euler(0f, 0f, 90f));
            }


        }
    }
}
