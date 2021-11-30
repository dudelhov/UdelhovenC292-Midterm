using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 800;
    [SerializeField] RuntimeData data;
    Rigidbody2D rb;
    bool isGrounded = false;
    float shieldTimer;
    float speedUpTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shield();
    }
    void Movement()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            //Move Right
            if (!data.speedUp)
            {
                transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
            }
            //Move Right with Speed Up
            else if (data.speedUp)
            {
                speedUpTimer += Time.deltaTime;
                if (speedUpTimer <= 4)
                {
                    transform.position += new Vector3(Time.deltaTime * moveSpeed * 1.5f, 0, 0);
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    data.speedUp = false;
                    speedUpTimer = 0;
                }
            }
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            //Move Left
            if (!data.speedUp)
            {
                transform.position -= new Vector3(Time.deltaTime * moveSpeed, 0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //Move Left with Speed Up
            else if (data.speedUp)
            {
                speedUpTimer += Time.deltaTime;
                if (speedUpTimer <= 4)
                {
                    transform.position -= new Vector3(Time.deltaTime * moveSpeed * 1.5f, 0, 0);
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    data.speedUp = false;
                    speedUpTimer = 0;
                }
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce));
                isGrounded = false;
            }
        }
    }

    void Shield()
    {
        if (data.isShielded)
        {
            transform.Find("Shield").gameObject.SetActive(true);
        }
        else if (!data.isShielded)
        {
            transform.Find("Shield").gameObject.SetActive(false);
        }

        if (!data.isShielded)
        {
            shieldTimer += Time.deltaTime;
            if (shieldTimer >= 6)
            {
                data.isShielded = true;
                shieldTimer = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Turret")
        {
            isGrounded = true;
        }
    }

}
