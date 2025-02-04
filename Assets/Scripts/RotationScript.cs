﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public int speed;
    public float multiplier = 1;
    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime * speed * multiplier, Space.Self);
    }
}
