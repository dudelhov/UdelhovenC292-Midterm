using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    void Update()
    {
        transform.position = new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, 1);
    }
}
