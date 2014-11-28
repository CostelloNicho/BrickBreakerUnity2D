// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using UnityEngine;

public class Ball : MonoBehaviour
{
	public float minMagnitude;
	public float maxMagnitude;
	protected void FixedUpdate()
	{
		Debug.Log(rigidbody2D.velocity.magnitude);
		if( rigidbody2D.isKinematic == false )
		{
			var newVelocity = rigidbody2D.velocity;
			if( rigidbody2D.velocity.magnitude < minMagnitude )
			{
				newVelocity *= 1.01f;
			}
			else if( rigidbody2D.velocity.magnitude > maxMagnitude )
			{
				newVelocity *= 0.99f;
			}				
			rigidbody2D.velocity = newVelocity;
		}
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Brick") return;
        
        //rigidbody2D.AddExplosionForce(100, collision.contacts[0].point.ToVector3(), 0.1f);
        Destroy(collision.gameObject);
        Messenger<int>.Broadcast(BrickBreakerEvents.PlayerScore, 10);

		var newVelocity = rigidbody2D.velocity;
		newVelocity *= 1.2f;
		rigidbody2D.velocity = newVelocity;
    }
}