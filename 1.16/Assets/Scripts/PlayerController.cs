using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;

    public Platform CurrentPlatform;

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void ReachFinish()
    {
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerReachedFinish();
    }

    public void Die()
    {
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerDied();
    }
}
