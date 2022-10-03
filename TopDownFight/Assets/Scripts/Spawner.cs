
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject[] enemies;
    public int amountEnemies;
    [SerializeField] private TilePainter coord;
    private float x;
    private float y;

    private void Awake()
    {
        int tmp = amountEnemies;
        x = (float)coord.width * 0.8f;
        y = (float)coord.height * 0.8f;
        while (amountEnemies-- > 0)
            SpawnEnemy();
        amountEnemies = tmp;
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(1f, x), Random.Range(1f, y),0), Quaternion.identity);
        //newEnemy.tag = "Act";
    }
}
