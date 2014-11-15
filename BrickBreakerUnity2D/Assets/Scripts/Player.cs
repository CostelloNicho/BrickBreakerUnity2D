using UnityEngine;
using System.Collections;
using Assets.Scripts.Managers;

public class Player : Singleton<Player> 
{
	private bool isBallHeld;
	private const int Speed = 6;
	private Vector2 origin;
	// Use this for initialization
	void Start () 
	{
		origin.x = 0f;
		origin.y = -ResolutionManager.HalfHeight;
		transform.position = origin.ToVector3();
	}
	
	public void Move(Direction direction)
	{
		Vector2 velocity = Vector2.zero;
		switch(direction)
		{
		case Direction.None:
			velocity = Vector2.zero;
			break;
		case Direction.Right:
			velocity.x = Speed;
			break;
		case Direction.Left:
			velocity.x = -Speed;
			break;
		}

		rigidbody2D.velocity = velocity;
	}

	public void ReleaseBall()
	{
		isBallHeld = false;
		//Fire the ball and begin
	}

	public void HoldBall()
	{
		isBallHeld = true;
		//
	}
}
