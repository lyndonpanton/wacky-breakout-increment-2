using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        GameObject startingBall = Instantiate(ball) as GameObject;

        startingBall.transform.position = new Vector2(
            0,
            0
        );
    }
}
