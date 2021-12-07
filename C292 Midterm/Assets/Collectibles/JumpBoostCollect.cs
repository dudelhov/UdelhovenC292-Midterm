using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostCollect : MonoBehaviour
{
    [SerializeField] RuntimeData data;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            data.jumpBoost = true;
            Destroy(gameObject);
        }
    }
}
