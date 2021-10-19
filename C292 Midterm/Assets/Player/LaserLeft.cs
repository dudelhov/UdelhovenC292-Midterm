using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLeft : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
        if (transform.position.x <= Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0)).x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
