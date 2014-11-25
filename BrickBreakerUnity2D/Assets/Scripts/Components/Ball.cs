// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Brick") return;
        
        //rigidbody2D.AddExplosionForce(100, collision.contacts[0].point.ToVector3(), 0.1f);
        Destroy(collision.gameObject);
        Messenger<int>.Broadcast(BrickBreakerEvents.PlayerScore, 10);
    }
}