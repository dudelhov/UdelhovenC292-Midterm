using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bat : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject batProjectile;
    Vector3 startPos;
    float timer = 0;
    float health = 1;
    float dropTimer = 0;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Movement();
        Drop();
    }

    void Drop()
    {
        dropTimer += Time.deltaTime;
        if (dropTimer >= 1)
        {
            Instantiate(batProjectile, transform.position, Quaternion.identity);
            dropTimer = 0;
        }
    }
    void Movement()
    {
        timer += Time.deltaTime;
        if (timer < 4.5)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (timer > 4.5)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (timer > 9)
        {
            timer = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (data.isShielded)
            {
                data.isShielded = false;
            }
            else if (!data.isShielded)
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentScene);
            }
        }
        if (other.gameObject.tag == "Laser")
        {
            if (health == 1)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
                health -= 1;
            }
        }
    }
}
