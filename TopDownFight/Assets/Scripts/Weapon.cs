using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    
    private int damagePoint = 1;
    private float pushForce = 4.0f;
    private SpriteRenderer spriteRenderer;
    private float coolDown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    private void Swing()
    {
       
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            Damage dmg = new Damage();
            dmg.damageAmount = damagePoint;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;
            coll.SendMessage("RecieveDamage", dmg);
        }
    }

}
