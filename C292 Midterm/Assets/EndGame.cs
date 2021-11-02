using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] CanvasGroup endScreen;
    float timer;
    float fadeDuration = 2;
    bool gameEnd = false;
    void Update()
    {
        if (gameEnd)
        {
            timer += Time.deltaTime;
            endScreen.alpha = timer / fadeDuration;
            if (Input.GetButtonDown("Submit"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameEnd = true;
        }
    }
}
