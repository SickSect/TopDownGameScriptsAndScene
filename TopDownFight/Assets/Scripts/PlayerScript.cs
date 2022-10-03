using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerScript : MonoBehaviour
{
    private BoxCollider2D   boxCollider;
    private Vector3         moveDelta;
    private RaycastHit2D    hit;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void SwapSprite(float x)
    {
        if (x > 0)
            transform.localScale = Vector3.one;
        else if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Mover()
    {
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y * 6), Mathf.Abs(moveDelta.y * Time.deltaTime * 6), LayerMask.GetMask("Act", "Block"));
        if (hit.collider == null)
            transform.Translate(0, moveDelta.y * Time.deltaTime * 6, 0);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x * 6, 0), Mathf.Abs(moveDelta.x * Time.deltaTime * 6), LayerMask.GetMask("Act", "Block"));
        if (hit.collider == null)
            transform.Translate(moveDelta.x * Time.deltaTime * 6, 0, 0);
    }

    private void FixedUpdate()
    {
        //Get input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //Reset pos
        moveDelta = new Vector3(x, y, 0);
        //Swap sprite
        SwapSprite(moveDelta.x);
        // Move or not
        Mover();
    }
}
