using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] CanvasGroup endScreen;
    float timer;
    float fadeDuration = 3;
    bool gameEnd = false;
    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            timer += Time.deltaTime;
            endScreen.alpha = timer / fadeDuration;
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
