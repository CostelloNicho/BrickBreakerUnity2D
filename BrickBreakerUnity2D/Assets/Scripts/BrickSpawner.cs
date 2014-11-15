using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;

public class BrickSpawner : MonoBehaviour 
{
	public GameObject brick;

	public List<GameObject> Bricks;

	public float EdgeBufferZone = 1f;
	public float SpawnOffset = 0.5f;

	protected void Start()
	{
		Bricks = new List<GameObject>();
		CreateBrickBlock(10,10);
	}

	protected void CreateBrickBlock(int rows, int columns)
	{
		//float x = Random.Range(0, ResolutionManager.HalfWidth - EdgeBufferZone);
		//float y = Random.Range(0, ResolutionManager.HalfHeight - EdgeBufferZone);

		for(int column = 0; column < columns; column++)
		{
			for(int row = 0; row < rows; row++)
			{
				Vector2 brickPosition;
				float xMax = ResolutionManager.HalfWidth - EdgeBufferZone;
				float yMax = ResolutionManager.HalfHeight - EdgeBufferZone;

				float x = ((row+1f)/rows) * (xMax * 2f);
				float y = ((column+1f)/columns) * yMax;

				brickPosition = new Vector2(x - ResolutionManager.HalfWidth,y);
				SpawnBrick(brickPosition.ToVector3());
	
				Bricks.Add(brick);
			}
		}

	}
	
	protected void SpawnBrick(Vector3 position)
	{
		var go = Instantiate(brick, position, Quaternion.identity)as GameObject;
		Bricks.Add(go);
	}

}
