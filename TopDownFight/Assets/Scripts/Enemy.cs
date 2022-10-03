using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public ContactFilter2D filter;
    public int xpValue = 1;
    //public float triggerLength = 100;
   // public float chaseLenght = 1;
    //private bool chasing;
    private bool collidingWithPlayer;
    public Transform playerTransform = null;
    private Vector3 startingPosition;
    private BoxCollider2D hitbox;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    private GameObject[] enemies;
    private GameObject closet;
    public bool havePair = false;

    protected override void Start()
    {
        //playerTransform = closet.transform;
        //playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (havePair == false)
        {
            GameObject closet = null;
            float distance = Mathf.Infinity;
            float curDistance;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy.transform.position != transform.position)
                {
                    curDistance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (curDistance < distance && enemy.GetComponent<Enemy>().havePair != true)
                    {
                        distance = curDistance;
                        closet = enemy;
                    }
                }
            }
            
            if (closet != null)
            {
                havePair = true;
                closet.GetComponent<Enemy>().havePair = true;
                closet.GetComponent<Enemy>().playerTransform = transform;
                playerTransform = closet.transform;
                Debug.Log("Find");
            }
        }
        else if (havePair == true && playerTransform != null)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) > 0.5f)
            {
                Debug.Log("Moving");
                //transform.position = Vector3.MoveTowards(playerTransform.position, transform.position, 2 * Time.deltaTime);
                UpdateMotor((playerTransform.position - transform.position).normalized);
            }
            else
            {
                collidingWithPlayer = false;
                Debug.Log("Fight process");
                boxCollider.OverlapCollider(filter, hits);
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i] == null)
                        continue;
                    if (hits[i].tag == "Enemy")
                    {
                        collidingWithPlayer = true;
                    }
                    hits[i] = null;
                }
            }
        }
        if (playerTransform == null)
        {
            Debug.Log("KILLED");
            havePair = false;
        }
            
        /*
          if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
          {
              if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                  chasing = true;
              if (chasing)
              {
                  if (!collidingWithPlayer)
                  {
                      UpdateMotor((playerTransform.position - transform.position).normalized);
                  }
              }
              else
              {
                  UpdateMotor(startingPosition - transform.position);
              }
          }
          else
          {
              UpdateMotor(startingPosition - transform.position);
              chasing = false;
          }

          collidingWithPlayer = false;
          //UpdateMotor(Vector3.zero);
          boxCollider.OverlapCollider(filter, hits);
          for (int i = 0; i < hits.Length; i++)
          {
              if (hits[i] == null)
                  continue;
              if (hits[i].tag == "Enemy")
              {
                  collidingWithPlayer = true;
              }
              hits[i] = null;
          }
        */
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.exp += xpValue;
        GameManager.instance.ShowText("+ " + xpValue.ToString() + "xp", 25, Color.magenta, transform.position, Vector3.up * 40, 0.5f);
    }
}
