// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using Assets.Scripts.Managers;
using UnityEngine;

public class GamePlayManager : Singleton<GamePlayManager>
{
    private const int Speed = 6;
    public Transform Ball;
    public Transform Block;

    private bool _isBallHeld;
    private Vector2 origin;

    protected void Start()
    {
        _isBallHeld = false;
        origin.x = 0f;
        origin.y = -ResolutionManager.HalfHeight;
        Block.position = origin.ToVector3();
        HoldBall();
    }

    public void OnEnable()
    {
        Messenger.AddListener(BrickBreakerEvents.FireInputEvent, ReleaseBall);
        Messenger<Direction>.AddListener(BrickBreakerEvents.DirectionInputEvent, Move);
    }

    public void OnDisable()
    {
        Messenger.RemoveListener(BrickBreakerEvents.FireInputEvent, ReleaseBall);
        Messenger<Direction>.RemoveListener(BrickBreakerEvents.DirectionInputEvent, Move);
    }


    private void Move(Direction direction)
    {
        var velocity = Vector2.zero;
        switch (direction)
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

    private void HitBall(Vector3 velocity)
    {
        Ball.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void ReleaseBall()
    {
        if (!_isBallHeld) return;
        _isBallHeld = false;
        Ball.rigidbody2D.isKinematic = false;
        Ball.transform.parent = null;
        //Fire the ball and begin
        HitBall(Block.up*5);
    }

    private void HoldBall()
    {
        _isBallHeld = true;
        Ball.rigidbody2D.isKinematic = true;
        Ball.transform.parent = Block;
        var pos = Block.position;
        pos.y += 1;
        Ball.transform.position = pos;
    }
}