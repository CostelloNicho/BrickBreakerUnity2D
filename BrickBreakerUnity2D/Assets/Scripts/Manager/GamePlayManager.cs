using UnityEngine;
using System.Collections;
using Assets.Scripts.Managers;

public class GamePlayManager : Singleton<GamePlayManager>
{
	public Transform Block;
    public Transform Ball;

	private bool _isBallHeld;
	private const int Speed = 6;
	private Vector2 origin;

	protected void Start ()
	{
	    _isBallHeld = false;
		origin.x = 0f;
		origin.y = -ResolutionManager.HalfHeight;
		Block.position = origin.ToVector3();
        HoldBall();
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

		Block.rigidbody2D.velocity = velocity;
	}

    public void HitBall(Vector3 velocity)
    {
        Ball.GetComponent<Rigidbody2D>().velocity = velocity;
    }

	public void ReleaseBall()
	{
		_isBallHeld = false;
        Ball.rigidbody2D.isKinematic = false;
	    Ball.transform.parent = null;
	    //Fire the ball and begin
		HitBall(Block.up * 5);
	}

	public void HoldBall()
	{
		_isBallHeld = true;
		Ball.rigidbody2D.isKinematic = true;
	    Ball.transform.parent = Block;
	    Vector3 pos = Block.position;
	    pos.y += 1;
	    Ball.transform.position = pos;

	}
	
}
