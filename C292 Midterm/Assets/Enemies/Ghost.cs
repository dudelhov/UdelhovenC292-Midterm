using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    [SerializeField] float speed = 1f;
    Vector3 startPos;
    float timer;
    float health = 2;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        timer += Time.deltaTime;
        if (timer < 2)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
        }
        else if (timer > 2)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
        if (timer > 4)
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
