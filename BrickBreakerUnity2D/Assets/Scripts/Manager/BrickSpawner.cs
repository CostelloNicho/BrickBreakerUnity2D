// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using System.Collections.Generic;
using System.Security.Cryptography;
using Assets.Scripts.Managers;
using UnityEngine;

public class BrickSpawner : Singleton<BrickSpawner>
{
    public GameObject Brick;
    public Color[] Colors;

    public int Rows = 10;
    public int Columns = 10;

    public float EdgeBufferZone = 1f;
    public float SpawnOffset = 0.5f;

    private List<GameObject> _bricks;

    protected void Start()
    {
        _bricks = new List<GameObject>();
        SpawnBricks();
    }

    public void SpawnBricks()
    {
        foreach (GameObject brick in _bricks)
            Destroy(brick);
        
        CreateBrickBlock(Rows, Columns);
    }

    public void OnDisable ()
    {
        Messenger.RemoveListener(BrickBreakerEvents.ResetGame, SpawnBricks);
    }

    public void OnEnable ()
    {
        Messenger.AddListener(BrickBreakerEvents.ResetGame, SpawnBricks);
    }


    protected void CreateBrickBlock(int rows, int columns)
    {
        var xRange = ResolutionManager.HalfWidth * 1.85f;
        var yRange = ResolutionManager.HalfHeight * 0.85f;
        for (var column = 0; column < columns; column++)
        {
            for (var row = 0; row < rows; row++)
            {
                var x = ( row  / (rows-1f) ) * xRange;
                var y =  (column / (columns - 1f)) * yRange;
                var brickColor = Colors[Random.Range(0, Colors.Length)];
                var brickPosition = new Vector2(x - (xRange/2), y);
                SpawnBrick(brickPosition.ToVector3(), brickColor);
            }
        }
    }

    protected void SpawnBrick(Vector3 position, Color color)
    {
        var go = Instantiate(Brick, position, Quaternion.identity) as GameObject;
        if (go == null) return;
        go.transform.parent = transform;
        go.GetComponent<SpriteRenderer>().color = color;
        _bricks.Add(go);
    }
}