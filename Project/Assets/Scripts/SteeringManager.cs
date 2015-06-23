using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SteeringManager {

    public Vector3 steering;
    public IBoid host;
 

    /// The constructor
    public SteeringManager(IBoid host)
    {
        this.host = host;
        this.steering = Vector3.zero;
    }
 
    //// The public API (one method for each behavior)
    //public function seek(target :Vector3D, slowingRadius :Number = 20) :void {}
    //public function flee(target :Vector3D) :void {}
    //public function wander() :void {}
    //public function evade(target :IBoid) :void {}
    //public function pursuit(target :IBoid) :void {}
 
    //// The update method. 
    //// Should be called after all behaviors have been invoked
    //public function update() :void {}
 
    //// Reset the internal steering force.
    //public function reset() :void {}
 
    //// The internal API
    //private function doSeek(target :Vector3D, slowingRadius :Number = 0) :Vector3D {}
    //private function doFlee(target :Vector3D) :Vector3D {}
    //private function doWander() :Vector3D {}
    //private function doEvade(target :IBoid) :Vector3D {}
    //private function doPursuit(target :IBoid) :Vector3D {}



    /// The publish method. 
    /// Receives a target to seek and a slowingRadius (used to perform arrive).
    public void seek(Vector3 target, float slowingRadius) 
    {
        steering += doSeek(target, slowingRadius);
    }
 
    /// The real implementation of seek (with arrival code included)
    private Vector3 doSeek(Vector3 target, float slowingRadius) 
    {
        Vector3 force = Vector3.zero;

        //var force :Vector3D;
        //var distance :Number;
 
        //desired = target.subtract(host.getPosition());
 
        //distance = desired.length;
        //desired.normalize();
 
        //if (distance <= slowingRadius) {
        //    desired.scaleBy(host.getMaxVelocity() * distance/slowingRadius);
        //} else {
        //    desired.scaleBy(host.getMaxVelocity());
        //}
 
        //force = desired.subtract(host.getVelocity());

        return force;
    }

    public void update()
    {
        Vector3 velocity  = host.getVelocity();
        Vector3 position  = host.getPosition();
 
        //truncate(steering, MAX_FORCE);
        //steering.scaleBy(1 / host.getMass());
 
        //velocity.incrementBy(steering);
        //truncate(velocity, host.getMaxVelocity());
 
        //position.incrementBy(velocity);
    }

    public Vector3 truncate(Vector3 vector, float max)
    {
        float i = max / vector.magnitude;

        i = i < 1.0f ? i : 1.0f;

        vector *= i;

        return vector;
    }
}
