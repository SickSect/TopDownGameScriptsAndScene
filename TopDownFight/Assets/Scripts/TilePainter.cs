using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    [SerializeField] private Tile floorTile;
    [SerializeField] private Tile wallTile;
    [SerializeField] private Tile exitTile;
    public int width;
    public int height;
    private Vector3Int position;
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap wall;
    [SerializeField] private Tilemap exit;
    //vector3Int
    private void Start()
    {
        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                position = new Vector3Int(i, j, 0);
                if (i == 3 && j == height)
                    exit.SetTile(position, exitTile);
                else if (i == 0 || i == width)
                    wall.SetTile(position, wallTile);
                else  if (j == 0 || j == height)
                    wall.SetTile(position, wallTile);
                else
                    floor.SetTile(position, floorTile);
            }
        }
    }
}
