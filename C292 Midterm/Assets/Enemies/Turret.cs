using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject turretProjectile;
    float shootTimer = 1.75f;
    void Update()
    {
        if (transform.position.x <= Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x && transform.position.x >= Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0)).x)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= 1.75)
        {
            Instantiate(turretProjectile, transform.position, Quaternion.identity);
            shootTimer = 0;
        }
    }
}
