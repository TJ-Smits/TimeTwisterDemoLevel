using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPosition : MonoBehaviour
{

    public WorldData worldData;
    public Transform alternatePositionTransform;

    public CharacterController controller;

    public float cooldown = 3.0f;

    private float _time;

    private void Update()
    {
        updateTime();

        if (Input.GetButtonDown("Fire1"))
        {
            if (_time <= 0.0f)
            {
                Vector3 alternatePosition = alternatePositionTransform.position;

                alternatePositionTransform.position = transform.position;
                //transform.position = alternatePosition;

                if (worldData.playerInWorld.Equals("Present"))
                {
                    worldData.playerInWorld = "Past";
                    controller.Move(-worldData.WorldDistance);
                } 
                else
                {
                    worldData.playerInWorld = "Present";
                    controller.transform.position -= worldData.WorldDistance;
                }
                
                Debug.Log("Switching places.");
                _time = cooldown;
            }

            Debug.Log("Waiting on cooldown.");
        }
    }

    private void updateTime()
    {
        _time -= Time.deltaTime;
    }
}
