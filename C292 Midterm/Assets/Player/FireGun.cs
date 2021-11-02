using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    [SerializeField] GameObject laserPrefabRight;
    [SerializeField] GameObject laserPrefabLeft;
    [SerializeField] GameObject laserPrefabUp;
    [SerializeField] AudioSource fireSound;
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.localRotation = new Quaternion(0, 0, 45, 45);
        }
        else
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            fireSound.Play();
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
