using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>	
public class Ball : MonoBehaviour
{
    #region Preoperties

    Timer ballDeathTimer;

    Timer ballStartTimer;

    bool finished = false;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        // add start timer component
        ballStartTimer = gameObject.AddComponent<Timer>();
        ballStartTimer.Duration = 1;
        ballStartTimer.Run();

        // add death timer component
        ballDeathTimer = gameObject.AddComponent<Timer>();
        ballDeathTimer.Duration = ConfigurationUtils.BallLifeTime;
        ballDeathTimer.Run();

    }

    /// <summary>
	/// Update is called once per frame
	/// </summary>	
    void Update()
    {
        if (ballStartTimer.Finished && !finished)
        {
            finished = true;
            StartMoving();
        }

        if (ballDeathTimer.Finished)
        {
            //Camera.main.GetComponent<BallSpawner>()
            //    .SpawnBall();
            BallSpawner ballSpawner = Camera.main.GetComponent<BallSpawner>();
            ballSpawner.SpawnBall();

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void OnBecameInvisible()
    {
        if (!ballStartTimer.Finished)
        {
            BallSpawner ballSpawner = Camera.main.GetComponent<BallSpawner>();
            ballSpawner.SpawnBall();

            Destroy(gameObject);
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartMoving()
    {
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    #endregion
}
