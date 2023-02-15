using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>	
public class Ball : MonoBehaviour
{
    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
	/// Update is called once per frame
	/// </summary>	
    void Update()
    {
        
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

    #endregion
}
