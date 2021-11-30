using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpCollect : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            data.speedUp = true;
            Destroy(gameObject);
        }
    }
}
