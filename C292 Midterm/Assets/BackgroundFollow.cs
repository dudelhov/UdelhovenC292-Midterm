using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float offsetY;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, 1);
    }
}
