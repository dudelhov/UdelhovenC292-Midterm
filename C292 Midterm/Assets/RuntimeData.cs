using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New RuntimeData")]
public class RuntimeData : ScriptableObject
{
    public bool isShielded;
    public bool speedUp;
    public bool jumpBoost;
    public int coins;
}
