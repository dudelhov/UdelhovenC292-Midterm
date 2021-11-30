using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    [SerializeField] RuntimeData data;

    void Awake()
    {
        data.isShielded = true;
        data.coins = 0;
        data.speedUp = false;
    }
}
