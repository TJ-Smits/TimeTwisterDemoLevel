using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPosition : MonoBehaviour
{

    public WorldData worldData;
    public Transform alternatePositionTransform;

    public ObjectManipulation objects;

    public CharacterController controller;

    public float cooldown = 3.0f;

    private float _time;

    private void Start()
    {
        worldData.playerInWorld = "Present";
    }

    private void Update()
    {
        updateTime();

        if (Input.GetButtonDown("Fire1"))
        {
            if (_time <= 0.0f)
            {
                Vector3 playerTransform = transform.position;
                Vector3 alternatePosition = alternatePositionTransform.position;

                alternatePositionTransform.position = playerTransform;
                controller.enabled = false;
                transform.position = alternatePosition;
                controller.enabled = true;

                if (objects.interactedObject)
                {
                    Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 2f);
                    objects.interactedObject.MoveToTarget(objects.camera.ScreenToWorldPoint(position));
                }

                if (worldData.playerInWorld.Equals("Present"))
                {
                    worldData.playerInWorld = "Past";
                } 
                else
                {
                    worldData.playerInWorld = "Present";
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
