﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetGravity(bool value)
    {
        rigidbody.useGravity = value;
    }

    public void MoveToTarget(Vector3 target)
    {
        rigidbody.MovePosition(target);
    }
}
