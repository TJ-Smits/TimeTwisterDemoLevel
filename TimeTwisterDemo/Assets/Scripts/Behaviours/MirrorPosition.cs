using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPosition : MonoBehaviour
{
    public WorldData worldData;

    public Transform player;

    private void Start()
    {
        transform.position = player.transform.position - worldData.WorldDistance;
    }

    // Update is called once per frame
    void Update()
    {

        if (worldData.playerInWorld.Equals("Present"))
        {
            transform.position = player.transform.position - worldData.WorldDistance;
        } 
        else
        {
            transform.position = player.transform.position + worldData.WorldDistance;
        }
    }
}
