using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    [SerializeField]
    Timer newBallSpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();

        newBallSpawnTimer = Camera.main.GetComponent<Timer>();
        //newBallSpawnTimer = GetComponent<Timer>();
        newBallSpawnTimer.Duration = Random.Range(
            ConfigurationUtils.MinimumSpawnTime,
            ConfigurationUtils.MaximumSpawnTime
        );
        newBallSpawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (newBallSpawnTimer.Finished)
        {
            SpawnBall();

            newBallSpawnTimer.Duration = Random.Range(
                ConfigurationUtils.MinimumSpawnTime,
                ConfigurationUtils.MaximumSpawnTime
            );
            newBallSpawnTimer.Run();
        }
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
