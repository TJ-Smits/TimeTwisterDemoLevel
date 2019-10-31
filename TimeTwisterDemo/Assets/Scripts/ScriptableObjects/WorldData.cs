using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WorldData : ScriptableObject
{
    public Vector3 WorldDistance = new Vector3(100.0f, 0.0f, 0.0f);

    public int amountOfWorlds = 2;

    public string playerInWorld = "Present";
}
