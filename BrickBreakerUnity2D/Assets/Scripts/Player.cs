using UnityEngine;
using System.Collections;
using Assets.Scripts.Managers;

public class Player : Singleton<Player>
{

    public GameObject Ball;

	private bool _isBallHeld;
	private const int Speed = 6;
	private Vector2 origin;
	// Use this for initialization
	protected void Start ()
	{
	    _isBallHeld = false;
		origin.x = 0f;
		origin.y = -ResolutionManager.HalfHeight;
		transform.position = origin.ToVector3();
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

		rigidbody2D.velocity = velocity;
	}

    public void HitBall(Vector3 velocity)
    {
        Ball.GetComponent<Rigidbody2D>().velocity = velocity;
    }

	public void ReleaseBall()
	{
		_isBallHeld = false;
        Ball.GetComponent<Rigidbody2D>().isKinematic = false;
	    Ball.transform.parent = null;
	    //Fire the ball and begin
	}

	public void HoldBall()
	{
		_isBallHeld = true;
	    Ball.GetComponent<Rigidbody2D>().isKinematic = true;
	    Ball.transform.parent = transform;
	    Vector3 pos = transform.position;
	    pos.y += 1;
	    Ball.transform.position = pos;

	}

    /// <summary>
    /// Handle a collisions between the ball and the Pad
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag != Ball.tag) return;
    }
}
