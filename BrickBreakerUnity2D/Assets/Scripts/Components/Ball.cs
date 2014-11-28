// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxMagnitude;
    public float minMagnitude;

    protected void FixedUpdate()
    {
        Debug.Log(rigidbody2D.velocity.magnitude);
        if (rigidbody2D.isKinematic == false)
        {
            var newVelocity = rigidbody2D.velocity;
            if (rigidbody2D.velocity.magnitude < minMagnitude)
            {
                newVelocity *= 1.01f;
            }
            else if (rigidbody2D.velocity.magnitude > maxMagnitude)
            {
                newVelocity *= 0.99f;
            }
            rigidbody2D.velocity = newVelocity;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            Messenger<int>.Broadcast(BrickBreakerEvents.PlayerScore, 10);

            var newVelocity = rigidbody2D.velocity;
            newVelocity *= 1.2f;
            rigidbody2D.velocity = newVelocity;
        }
        else if (collision.gameObject.tag == "Block")
        {
            var brickPosion = collision.transform.position.ToVector2();
            var contactPointPos = collision.contacts[0].point;
            var deltaX = contactPointPos.x - brickPosion.x;
            var halfWidth = collision.gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
            //values clamp between 0-1 + 1 
            var xVel = (deltaX/halfWidth);
            if (xVel < 0)
                xVel -= 1;
            else if (xVel > 0)
                xVel += 1;
            var newVelocity = rigidbody2D.velocity;
            if (newVelocity.x < xVel)
                newVelocity.x = xVel;
            else
                newVelocity.x *= xVel;
            rigidbody2D.velocity = newVelocity;
        }
    }
}