using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public interface IBoid
{
    Vector3 getVelocity();
    float getMaxVelocity();

    Vector3 getPosition();

    float getMass();
}


public class BaseControl : IBoid
{

    public Vector3 getVelocity()
    {
        throw new NotImplementedException();
    }

    public float getMaxVelocity()
    {
        throw new NotImplementedException();
    }

    public Vector3 getPosition()
    {
        throw new NotImplementedException();
    }

    public float getMass()
    {
        throw new NotImplementedException();
    }
}
