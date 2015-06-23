using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;





public class BaseControl : MonoBehaviour
{
    public Transform target;

    public Vector3 velocity;

    public SteeringManager steering;

    public float MAX_VELOCITY { get { return 3.0f; } }

    public float mass { get { return 1.0f; } }

    void Awake()
    {
        velocity = Vector3.zero;

        steering = new SteeringManager(this);
    }

    void Update()
    {
        if (needSeek) steering.seek(target.transform.position);

        steering.update();
    }

    bool needSeek = true;
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        {
            needSeek = false;

            steering.reset();
        }

    }
}
