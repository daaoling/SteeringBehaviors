using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SteeringManager {

    public Vector3 steering;
    public BaseControl host;

    public float MAX_FORCE = 10.0f;

    /// The constructor
    public SteeringManager(BaseControl host)
    {
        this.host = host;
        this.steering = Vector3.zero;
    }

    #region The public API (one method for each behavior)
    public void seek(Vector3 target) { steering += doSeek(target); }
    public void flee(Vector3 target) { steering += doFlee(target); }
    public void arrival(Vector3 target, float slowingRadius) { steering += doArrival(target, slowingRadius); }

    //public function wander() :void {}
    //public function evade(target :IBoid) :void {}
    //public function pursuit(target :IBoid) :void {}
    #endregion

    #region The internal API
    private Vector3 doSeek(Vector3 target)
    {
        Vector3 force = Vector3.zero;

        var desired_velocity = (target - host.transform.position).normalized * host.MAX_VELOCITY;

        force = desired_velocity - host.velocity;

        return force;
    }
    private Vector3 doFlee(Vector3 target)
    {
        return -doSeek(target);
    }
    /// The real implementation of seek (with arrival code included)
    private Vector3 doArrival(Vector3 target, float slowingRadius)
    {
        Vector3 force = Vector3.zero;

        var desired_velocity = target - host.transform.position;
        var distance = desired_velocity.magnitude;
        if (distance <= slowingRadius)
        {
            desired_velocity = desired_velocity.normalized * host.MAX_VELOCITY * (distance / slowingRadius);
        }
        else
        {
            desired_velocity = desired_velocity.normalized * host.MAX_VELOCITY;
        }
        force = desired_velocity - host.velocity;

        return force;
    }

    //private function doWander() :Vector3D {}
    //private function doEvade(target :IBoid) :Vector3D {}
    //private function doPursuit(target :IBoid) :Vector3D {}
    #endregion


    /// The update method. 
    /// Should be called after all behaviors have been invoked
    public void update()
    {
        steering = truncate(steering, MAX_FORCE);
        steering /= host.mass;
        host.velocity = truncate(host.velocity + steering, host.MAX_VELOCITY);
        host.transform.position += host.velocity * Time.deltaTime;
    }

    /// Reset the internal steering force.
    public void reset()
    {
        steering = Vector3.zero;
    }

    #region Util
    private Vector3 truncate(Vector3 vector, float max)
    {
        float i = max / vector.magnitude;

        i = i < 1.0f ? i : 1.0f;

        vector *= i;

        return vector;
    }
    #endregion
}
