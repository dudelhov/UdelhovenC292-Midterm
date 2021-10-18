using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 800;
    Rigidbody2D rb;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            //Move Right
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            //Move Left
            transform.position -= new Vector3(Time.deltaTime * moveSpeed, 0, 0);

            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

}
