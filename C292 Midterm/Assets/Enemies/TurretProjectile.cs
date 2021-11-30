using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    [SerializeField] float speed;
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (data.isShielded)
            {
                data.isShielded = false;
                Destroy(gameObject);
            }
            else if (!data.isShielded)
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentScene);
            }
        }
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }
}
