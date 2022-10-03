using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damage = 3;
    public float pushForce = 5f;

    private void Awake()
    {
        Debug.Log("Install damage");
        damage = Random.Range(1, 10);
    }
    protected override void OnCollide(Collider2D coll)
    {
        
        if (coll.tag == "Enemy")
        {
            Debug.Log("TOUCH");
            Damage dmg = new Damage();
            dmg.damageAmount = damage;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;
            coll.SendMessage("RecieveDamage", dmg);
        }
    }
}
