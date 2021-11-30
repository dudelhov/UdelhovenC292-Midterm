using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRight : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
        if (transform.position.x >= Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Enemy Projectile")
        {
            Destroy(gameObject);
        }
    }
}
