using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
    private BoxCollider2D boxColl;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
   // protected float uSpeed = 2.0f;
   // protected float xSpeed = 2.0f;

    protected virtual void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x, input.y , 0);

        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        //moveDelta += pushDir;
        //pushDir = Vector3.Lerp(pushDir, Vector3.zero, pushRecoverySpeed);
        //hit = Physics2D.BoxCast(transform.position, boxColl.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Block", "Act"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        //hit = Physics2D.BoxCast(transform.position, boxColl.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Block", "Act"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
