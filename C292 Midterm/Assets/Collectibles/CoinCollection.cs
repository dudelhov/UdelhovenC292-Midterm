using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    [SerializeField] TextMeshProUGUI coinText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            data.coins++;
            coinText.text = "Coins: " + data.coins;
            Destroy(gameObject);
        }
    }
}
