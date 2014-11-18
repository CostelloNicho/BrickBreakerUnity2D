// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using System.Collections.Generic;
using Assets.Scripts.Managers;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject Brick;
    public List<GameObject> Bricks;
    public Color[] Colors;

    public float EdgeBufferZone = 1f;
    public float SpawnOffset = 0.5f;

    protected void Start()
    {
        Bricks = new List<GameObject>();
        CreateBrickBlock(10, 10);
    }

    protected void CreateBrickBlock(int rows, int columns)
    {
        for (var column = 0; column < columns; column++)
        {
            for (var row = 0; row < rows; row++)
            {
                var xMax = ResolutionManager.HalfWidth - EdgeBufferZone;
                var yMax = ResolutionManager.HalfHeight - EdgeBufferZone;
                var x = ( ( row + 1f ) / rows ) * ( xMax * 2f );
                var y = ( ( column + 1f ) / columns ) * yMax;
                var brickColor = Colors[Random.Range(0, Colors.Length)];
                var brickPosition = new Vector2(x - ResolutionManager.HalfWidth, y);
                SpawnBrick(brickPosition.ToVector3(), brickColor);
                Bricks.Add(Brick);
            }
        }
    }

    protected void SpawnBrick(Vector3 position, Color color)
    {
        var go = Instantiate(Brick, position, Quaternion.identity) as GameObject;
        if (go == null) return;
        go.transform.parent = transform;
        go.GetComponent<SpriteRenderer>().color = color;
        Bricks.Add(go);
    }
}