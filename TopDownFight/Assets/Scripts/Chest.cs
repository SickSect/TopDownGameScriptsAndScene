using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite emptyChest;
    [SerializeField] private int coinAmount = 10;

    protected override void OnCollect()
    {
        if (!collected)
        {
            //base.OnCollect();
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Debug.Log("+ "+ coinAmount + "coins!");
            GameManager.instance.ShowText("+ " + coinAmount.ToString() + " coins!", 25, Color.yellow,  transform.position, Vector3.up * 50, 3.0f);
        }
    }
}
