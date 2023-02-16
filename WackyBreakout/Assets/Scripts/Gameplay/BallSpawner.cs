using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    Timer newBallSpawnTimer;


    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    // Start is called before the first frame update
    void Start()
    {

        newBallSpawnTimer = Camera.main.GetComponent<Timer>();
        //newBallSpawnTimer = GetComponent<Timer>();
        newBallSpawnTimer.Duration = Random.Range(
            ConfigurationUtils.MinimumSpawnTime,
            ConfigurationUtils.MaximumSpawnTime
        );
        newBallSpawnTimer.Run();

        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;

        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (newBallSpawnTimer.Finished && retrySpawn)
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
    {// make sure we don't spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            //Instantiate(prefabBall);
            GameObject startingBall = Instantiate(prefabBall) as GameObject;

            startingBall.transform.position = new Vector2(
                0,
                0
            );
        }
        else
        {
            retrySpawn = true;
            Debug.Log("beep");
        }
    }
}
