using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;
    protected Vector3 pushDir;
    private GameObject[] enemies;

    private void Start()
    {
        hitpoint = Random.Range(1, 100);
        maxHitpoint = hitpoint;
    }

    protected virtual void RecieveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDir = (transform.position - dmg.origin).normalized * dmg.pushForce;
            GameManager.instance.ShowText(dmg.damageAmount.ToString() + " damage", 20, Color.red, transform.position, Vector3.up, 0.5f);
            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

   

   protected virtual void Death()
   {
        Destroy(gameObject);
   }
}
