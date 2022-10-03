using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairConnect : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject closet;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        int[] arrayPaired = new int[enemies.Length];
        int index = 0;
        for (int i = 0;i < enemies.Length; i++)
        {
            float distance = Mathf.Infinity;
            if (arrayPaired.Equals(i))
                continue;
            arrayPaired.SetValue(i, index++);
            Vector3 position = enemies[i].transform.position;
            for( int j = 0; j < enemies.Length; j++)
            {
                if (arrayPaired.Equals(j))
                        continue;
                Vector3 diff = enemies[j].transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closet = enemies[j];
                    distance = curDistance;
                }
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
