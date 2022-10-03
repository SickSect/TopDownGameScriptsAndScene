using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        //Debug.Log("am I here ?" + coll.name);
        if (coll.name == "Act") // Use with player after
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
