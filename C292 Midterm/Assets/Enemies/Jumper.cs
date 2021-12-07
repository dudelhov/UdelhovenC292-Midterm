using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumper : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject player;
    Vector3 startPos;
    float timer;
    float health = 3;
    bool canDamage = false;
    Rigidbody2D rb;
    void Start()
    {
        startPos = transform.position;
        rb = transform.parent.GetComponent<Rigidbody2D>();
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


        float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground")))//different kind of ground check than the player. worked better for trigger
        {
            canDamage = false;
            if (distanceFromPlayer <= 5)
            {
                rb.AddForce(new Vector2(0, 30));
                canDamage = true;
            }
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
            if (canDamage)
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
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
