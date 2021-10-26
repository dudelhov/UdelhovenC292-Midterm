using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserUp : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
        if (transform.position.y >= Camera.main.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Destroyed Up");
            Destroy(gameObject);
        }
    }
}
